Imports MySql.Data.MySqlClient

Public Class AttendanceForm
    Private Sub AttendanceForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(813, 454)
        Me.StartPosition = FormStartPosition.CenterScreen

        LoadCourses()
        LoadDates()
    End Sub

    ' Load Courses into ComboBox
    Private Sub LoadCourses()
        Try
            ConnectDB()
            Dim query As String = "SELECT CourseID, CourseName FROM CourseDetails"
            Dim cmd As New MySqlCommand(query, conn)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            CmbCourse.Items.Clear()
            While reader.Read()
                CmbCourse.Items.Add(reader("CourseID") & " - " & reader("CourseName"))
            End While

        Catch ex As Exception
            MessageBox.Show("Error loading courses: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub

    ' Load Dates into ComboBox
    Private Sub LoadDates()
        For i As Integer = 0 To 30
            CmbDate.Items.Add(DateTime.Now.AddDays(-i).ToString("yyyy-MM-dd"))
        Next
    End Sub

    ' Load Batches and Subjects based on Selected Course
    Private Sub CmbCourse_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbCourse.SelectedIndexChanged
        Try
            ConnectDB()
            Dim courseId As String = CmbCourse.Text.Split("-")(0).Trim()

            ' Load Batches
            Dim batchQuery As String = "SELECT DISTINCT Batch FROM StudentDetails WHERE Course = @CourseID"
            Dim batchCmd As New MySqlCommand(batchQuery, conn)
            batchCmd.Parameters.AddWithValue("@CourseID", courseId)

            Dim batchReader As MySqlDataReader = batchCmd.ExecuteReader()
            CmbBatch.Items.Clear()
            While batchReader.Read()
                CmbBatch.Items.Add(batchReader("Batch"))
            End While
            batchReader.Close()

            ' Load Subjects
            Dim subjectQuery As String = "SELECT SubjectName FROM CourseSubjects WHERE CourseID = @CourseID"
            Dim subjectCmd As New MySqlCommand(subjectQuery, conn)
            subjectCmd.Parameters.AddWithValue("@CourseID", courseId)

            Dim subjectReader As MySqlDataReader = subjectCmd.ExecuteReader()
            CmbSubject.Items.Clear()
            While subjectReader.Read()
                CmbSubject.Items.Add(subjectReader("SubjectName"))
            End While

        Catch ex As Exception
            MessageBox.Show("Error loading batches and subjects: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub

    ' Load Students based on Course, Batch, and Subject
    Private Sub CmbBatch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbBatch.SelectedIndexChanged
        Try
            ConnectDB()
            Dim courseId As String = CmbCourse.Text.Split("-")(0).Trim()
            Dim batch As String = CmbBatch.Text

            Dim query As String = "SELECT ApplicationNo, Name FROM StudentDetails WHERE Course = @CourseID AND Batch = @Batch"
            Dim adapter As New MySqlDataAdapter(query, conn)
            adapter.SelectCommand.Parameters.AddWithValue("@CourseID", courseId)
            adapter.SelectCommand.Parameters.AddWithValue("@Batch", batch)

            Dim table As New DataTable()
            adapter.Fill(table)
            DgvStudents.DataSource = table

            ' Add Attendance CheckBox Column
            If Not DgvStudents.Columns.Contains("Attendance") Then
                Dim chkColumn As New DataGridViewCheckBoxColumn
                chkColumn.HeaderText = "Present"
                chkColumn.Name = "Attendance"
                DgvStudents.Columns.Add(chkColumn)
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading students: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub

    ' Save Attendance
    Private Sub btnSaveAttendance_Click(sender As Object, e As EventArgs) Handles btnSaveAttendance.Click
        Try
            ConnectDB()

            Dim attendanceDate As String = CmbDate.Text
            Dim selectedSubject As String = CmbSubject.Text

            If String.IsNullOrEmpty(attendanceDate) OrElse String.IsNullOrEmpty(selectedSubject) Then
                MessageBox.Show("Please select both Date and Subject.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            For Each row As DataGridViewRow In DgvStudents.Rows
                Dim applicationNo As Integer = Convert.ToInt32(row.Cells("ApplicationNo").Value)
                Dim isPresent As Boolean = If(row.Cells("Attendance").Value, False)

                Dim query As String = "INSERT INTO Attendance (ApplicationNo, AttendanceDate, Subject, IsPresent) VALUES (@ApplicationNo, @AttendanceDate, @Subject, @IsPresent)"
                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ApplicationNo", applicationNo)
                cmd.Parameters.AddWithValue("@AttendanceDate", attendanceDate)
                cmd.Parameters.AddWithValue("@Subject", selectedSubject)
                cmd.Parameters.AddWithValue("@IsPresent", isPresent)
                cmd.ExecuteNonQuery()
            Next

            MessageBox.Show("Attendance Marked Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error saving attendance: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub
End Class
