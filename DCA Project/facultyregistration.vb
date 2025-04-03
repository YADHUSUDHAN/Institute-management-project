Imports MySql.Data.MySqlClient
Imports System.IO

Public Class facultyregistration
    Private Sub GenerateEmployeeID()
        Try
            ConnectDB()
            Dim query As String = "SELECT MAX(EmployeeID) FROM FacultyDetails"
            Dim cmd As New MySqlCommand(query, conn)
            Dim result = cmd.ExecuteScalar()

            If result IsNot DBNull.Value Then
                Dim lastID As Integer = Convert.ToInt32(result)
                TxtEmpid.Text = (lastID + 1).ToString()
            Else
                TxtEmpid.Text = "1001" ' Start from 1001 if no employee exists
            End If
        Catch ex As Exception
            MessageBox.Show("Error generating Employee ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub
    Private Sub facultyregistration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(813, 454)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Location = New Point((Screen.PrimaryScreen.Bounds.Width - Me.Width) \ 2,
                                (Screen.PrimaryScreen.Bounds.Height - Me.Height) \ 2)

        LoadCourses()
        GenerateEmployeeID()
    End Sub

    ' Load available courses dynamically from CourseDetails table
    Private Sub LoadCourses()
        Try
            ConnectDB()
            Dim query As String = "SELECT CourseID, CourseName FROM CourseDetails"
            Dim cmd As New MySqlCommand(query, conn)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            CmbEmpDept.Items.Clear()
            While reader.Read()
                CmbEmpDept.Items.Add(reader("CourseID").ToString() & " - " & reader("CourseName").ToString())
            End While
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading courses: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub

    ' Load subjects dynamically based on selected course
    Private Sub CmbEmpDept_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbEmpDept.SelectedIndexChanged
        ChkListEmpSub.Items.Clear()

        ' Extract CourseID from the selected item
        If CmbEmpDept.SelectedIndex = -1 Then Return
        Dim selectedCourseID As String = CmbEmpDept.SelectedItem.ToString().Split(" - ")(0)

        Try
            ConnectDB()
            Dim query As String = "SELECT SubjectName FROM CourseSubjects WHERE CourseID = @CourseID"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@CourseID", selectedCourseID)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                ChkListEmpSub.Items.Add(reader("SubjectName").ToString())
            End While
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading subjects: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub

    ' Method to clear all fields
    Private Sub BtnClr_Click(sender As Object, e As EventArgs) Handles BtnClr.Click
        TxtEmpid.Clear()
        TxtEmpname.Clear()
        DtpEmpDOB.Value = DateTime.Now
        TxtEmpPh.Clear()
        CmbEmpDept.SelectedIndex = -1
        ChkListEmpSub.Items.Clear()
        PictureBox1.Image = Nothing
    End Sub

    ' Method to save faculty details to database
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Try
            If TxtEmpid.Text = "" Or TxtEmpname.Text = "" Or TxtEmpPh.Text = "" Or CmbEmpDept.SelectedIndex = -1 Then
                MessageBox.Show("Please fill in all required fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Validate phone number (must be exactly 10 digits)
            If Not System.Text.RegularExpressions.Regex.IsMatch(TxtEmpPh.Text, "^\d{10}$") Then
                MessageBox.Show("Phone number must be exactly 10 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If ChkListEmpSub.CheckedItems.Count = 0 Then
                MessageBox.Show("Please select at least one subject.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ConnectDB()
            Dim selectedCourseID As String = CmbEmpDept.SelectedItem.ToString().Split(" - ")(0)

            ' Insert FacultyDetails into database
            Dim query As String = "INSERT INTO FacultyDetails (EmployeeID, Name, DOB, Phone, CourseID, Image) 
                               VALUES (@EmpID, @Name, @DOB, @Phone, @CourseID, @Image)"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@EmpID", TxtEmpid.Text)
            cmd.Parameters.AddWithValue("@Name", TxtEmpname.Text)
            cmd.Parameters.AddWithValue("@DOB", DtpEmpDOB.Value.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@Phone", TxtEmpPh.Text)
            cmd.Parameters.AddWithValue("@CourseID", selectedCourseID)

            ' Convert image to byte array
            Dim ms As New MemoryStream()
            If PictureBox1.Image IsNot Nothing Then
                PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
                cmd.Parameters.AddWithValue("@Image", ms.ToArray())
            Else
                cmd.Parameters.AddWithValue("@Image", DBNull.Value)
            End If

            cmd.ExecuteNonQuery()

            ' Insert subjects into FacultySubjects table
            For Each subject As String In ChkListEmpSub.CheckedItems
                Dim subQuery As String = "INSERT INTO FacultySubjects (FacultyID, SubjectName) VALUES (@FacultyID, @SubjectName)"
                Dim subCmd As New MySqlCommand(subQuery, conn)
                subCmd.Parameters.AddWithValue("@FacultyID", TxtEmpid.Text)
                subCmd.Parameters.AddWithValue("@SubjectName", subject)
                subCmd.ExecuteNonQuery()
            Next

            MessageBox.Show("Faculty details saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtEmpid.Clear()
            TxtEmpname.Clear()
            DtpEmpDOB.Value = DateTime.Now
            TxtEmpPh.Clear()
            CmbEmpDept.SelectedIndex = -1
            ChkListEmpSub.Items.Clear()
            PictureBox1.Image = Nothing
        Catch ex As Exception
            MessageBox.Show("Error saving data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub


    ' Method to upload image by clicking PictureBox
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(openFileDialog.FileName)
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        End If
    End Sub
End Class
