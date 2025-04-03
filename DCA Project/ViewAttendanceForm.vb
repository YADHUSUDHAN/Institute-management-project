Imports MySql.Data.MySqlClient

Public Class ViewAttendanceForm
    Private Sub ViewAttendanceForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(813, 454)
        Me.StartPosition = FormStartPosition.CenterScreen

        DtpFromDate.Value = DateTime.Now.AddDays(-7)
        DtpToDate.Value = DateTime.Now

        LoadCourses()
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

    ' Load Batches based on Selected Course
    Private Sub CmbCourse_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbCourse.SelectedIndexChanged
        Try
            ConnectDB()
            Dim courseId As String = CmbCourse.Text.Split("-")(0).Trim()
            Dim query As String = "SELECT DISTINCT Batch FROM StudentDetails WHERE Course = @CourseID"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@CourseID", courseId)

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            CmbBatch.Items.Clear()
            While reader.Read()
                CmbBatch.Items.Add(reader("Batch"))
            End While

        Catch ex As Exception
            MessageBox.Show("Error loading batches: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub

    ' Load Attendance Records
    Private Sub btnLoadAttendance_Click(sender As Object, e As EventArgs) Handles btnLoadAttendance.Click
        Try
            ConnectDB()
            Dim courseId As String = CmbCourse.Text.Split("-")(0).Trim()
            Dim batch As String = CmbBatch.Text
            Dim fromDate As String = DtpFromDate.Value.ToString("yyyy-MM-dd")
            Dim toDate As String = DtpToDate.Value.ToString("yyyy-MM-dd")

            Dim query As String = "SELECT A.AttendanceDate, S.ApplicationNo, S.Name, A.Subject, A.IsPresent 
                                   FROM Attendance A
                                   JOIN StudentDetails S ON A.ApplicationNo = S.ApplicationNo
                                   WHERE S.Course = @CourseID AND S.Batch = @Batch 
                                   AND A.AttendanceDate BETWEEN @FromDate AND @ToDate
                                   ORDER BY A.AttendanceDate"

            Dim adapter As New MySqlDataAdapter(query, conn)
            adapter.SelectCommand.Parameters.AddWithValue("@CourseID", courseId)
            adapter.SelectCommand.Parameters.AddWithValue("@Batch", batch)
            adapter.SelectCommand.Parameters.AddWithValue("@FromDate", fromDate)
            adapter.SelectCommand.Parameters.AddWithValue("@ToDate", toDate)

            Dim table As New DataTable()
            adapter.Fill(table)
            DgvAttendance.DataSource = table

            ' Set column headers
            DgvAttendance.Columns("Subject").HeaderText = "Subject Name"

        Catch ex As Exception
            MessageBox.Show("Error loading attendance: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub
End Class
