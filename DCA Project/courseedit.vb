Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions

Public Class CourseEdit

    Private Sub CourseEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(813, 454)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Location = New Point((Screen.PrimaryScreen.Bounds.Width - Me.Width) \ 2,
                                (Screen.PrimaryScreen.Bounds.Height - Me.Height) \ 2)

        DataGridView1.AllowUserToAddRows = False
        DataGridView1.ReadOnly = False
        LoadCourseData()
    End Sub

    Public Sub LoadCourseData()
        Try
            ConnectDB()
            Dim query As String = "SELECT c.CourseID, c.CourseName, c.Duration, c.Fees, 
                                  GROUP_CONCAT(s.SubjectName SEPARATOR ', ') AS Subjects 
                                  FROM CourseDetails c 
                                  LEFT JOIN CourseSubjects s ON c.CourseID = s.CourseID 
                                  GROUP BY c.CourseID"

            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Error loading courses: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        Try
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim courseID As String = row.Cells("CourseID").Value.ToString().Trim()
            Dim courseName As String = row.Cells("CourseName").Value.ToString().Trim()
            Dim duration As String = row.Cells("Duration").Value.ToString().Trim()
            Dim feesStr As String = row.Cells("Fees").Value.ToString().Trim()
            Dim subjects As String = row.Cells("Subjects").Value.ToString().Trim()

            ' Validation: Course Name and Duration cannot be empty
            If courseName = "" OrElse duration = "" Then
                MessageBox.Show("Course Name and Duration cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                LoadCourseData()
                Exit Sub
            End If

            ' Validation: Duration format (digits + "months", "years", "year", or both)
            Dim durationPattern As String = "^\d+\s*(months?|years?|year)?(\s*\d+\s*months?)?$"
            If Not Regex.IsMatch(duration, durationPattern, RegexOptions.IgnoreCase) Then
                MessageBox.Show("Invalid duration format. Example: '6 months', '2 years', '1 year 6 months'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                LoadCourseData()
                Exit Sub
            End If

            ' Validation: Fees should be a valid positive number
            Dim feeValue As Decimal
            If Not Decimal.TryParse(feesStr, feeValue) OrElse feeValue <= 0 Then
                MessageBox.Show("Invalid Fees. Enter a valid positive number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                LoadCourseData()
                Exit Sub
            End If

            ' Update CourseDetails table
            ConnectDB()
            Dim query As String = "UPDATE CourseDetails SET CourseName = @CourseName, Duration = @Duration, Fees = @Fees WHERE CourseID = @CourseID"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@CourseID", courseID)
            cmd.Parameters.AddWithValue("@CourseName", courseName)
            cmd.Parameters.AddWithValue("@Duration", duration)
            cmd.Parameters.AddWithValue("@Fees", feeValue)
            cmd.ExecuteNonQuery()

            ' Update CourseSubjects table (Delete old subjects and insert new ones)
            Dim deleteQuery As String = "DELETE FROM CourseSubjects WHERE CourseID = @CourseID"
            Dim deleteCmd As New MySqlCommand(deleteQuery, conn)
            deleteCmd.Parameters.AddWithValue("@CourseID", courseID)
            deleteCmd.ExecuteNonQuery()

            Dim subjectList As String() = subjects.Split(","c)
            For Each subject As String In subjectList
                Dim insertQuery As String = "INSERT INTO CourseSubjects (CourseID, SubjectName) VALUES (@CourseID, @SubjectName)"
                Dim insertCmd As New MySqlCommand(insertQuery, conn)
                insertCmd.Parameters.AddWithValue("@CourseID", courseID)
                insertCmd.Parameters.AddWithValue("@SubjectName", subject.Trim())
                insertCmd.ExecuteNonQuery()
            Next

            MessageBox.Show("Course details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error updating course details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub


    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Try
            If DataGridView1.SelectedRows.Count = 0 Then
                MessageBox.Show("Select a course to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim selectedCourseID As String = DataGridView1.SelectedRows(0).Cells("CourseID").Value.ToString()
            ConnectDB()

            Dim query As String = "DELETE FROM CourseDetails WHERE CourseID = @CourseID"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@CourseID", selectedCourseID)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Course deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadCourseData()
        Catch ex As Exception
            MessageBox.Show("Error deleting course: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub
End Class
