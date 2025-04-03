
Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions

Public Class Add_Course
    Private Sub Add_Course_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(813, 454)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Location = New Point((Screen.PrimaryScreen.Bounds.Width - Me.Width) \ 2,
                                (Screen.PrimaryScreen.Bounds.Height - Me.Height) \ 2)
        Me.AutoScroll = True
    End Sub


    Private Sub BtnAddSubject_Click(sender As Object, e As EventArgs) Handles BtnAddSubject.Click
        If TextBox_Subject.Text.Trim() <> "" Then
            ListBox1.Items.Add(TextBox_Subject.Text.Trim())
            TextBox_Subject.Clear()
        Else
            MessageBox.Show("Enter a subject name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub BtnSaveCourse_Click(sender As Object, e As EventArgs) Handles BtnSaveCourse.Click
        ' Trimmed input values
        Dim courseID As String = TextBox1.Text.Trim()
        Dim courseName As String = TextBox2.Text.Trim()
        Dim duration As String = TextBox3.Text.Trim()
        Dim fees As String = TextBox4.Text.Trim()

        ' Validation: All fields must be filled
        If courseID = "" OrElse courseName = "" OrElse duration = "" OrElse fees = "" OrElse ListBox1.Items.Count = 0 Then
            MessageBox.Show("All fields must be filled, and at least one subject must be added.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Validation: Duration should match the correct pattern (digits + "months", "years", or both)
        Dim durationPattern As String = "^\d+\s*(months?|years?|year)?(\s*\d+\s*months?)?$"
        If Not System.Text.RegularExpressions.Regex.IsMatch(duration, durationPattern, RegexOptions.IgnoreCase) Then
            MessageBox.Show("Invalid duration format. Example: '6 months', '2 years', '1 year 6 months'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Validation: Fees should be a valid positive number
        Dim feeValue As Decimal
        If Not Decimal.TryParse(fees, feeValue) OrElse feeValue <= 0 Then
            MessageBox.Show("Invalid Fees. Enter a valid positive number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            ConnectDB()

            ' Insert Course Details
            Dim queryCourse As String = "INSERT INTO CourseDetails (CourseID, CourseName, Duration, Fees) VALUES (@CourseID, @CourseName, @Duration, @Fees)"
            Dim cmdCourse As New MySqlCommand(queryCourse, conn)
            cmdCourse.Parameters.AddWithValue("@CourseID", courseID)
            cmdCourse.Parameters.AddWithValue("@CourseName", courseName)
            cmdCourse.Parameters.AddWithValue("@Duration", duration)
            cmdCourse.Parameters.AddWithValue("@Fees", feeValue)
            cmdCourse.ExecuteNonQuery()

            ' Insert Subjects
            For Each subject As String In ListBox1.Items
                Dim querySubject As String = "INSERT INTO CourseSubjects (CourseID, SubjectName) VALUES (@CourseID, @SubjectName)"
                Dim cmdSubject As New MySqlCommand(querySubject, conn)
                cmdSubject.Parameters.AddWithValue("@CourseID", courseID)
                cmdSubject.Parameters.AddWithValue("@SubjectName", subject)
                cmdSubject.ExecuteNonQuery()
            Next

            MessageBox.Show("Course and subjects added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Clear Fields
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox_Subject.Clear()
            ListBox1.Items.Clear()

        Catch ex As Exception
            MessageBox.Show("Error adding course: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub


    Private Sub Btnclear_Click(sender As Object, e As EventArgs) Handles Btnclear.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox_Subject.Clear()
        ListBox1.Items.Clear()
    End Sub
End Class
