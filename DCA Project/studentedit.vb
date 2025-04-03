Imports System.IO
Imports MySql.Data.MySqlClient

Public Class studentedit
    Private Sub StudentEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        LoadStudentData()
        DataGridView1.AllowUserToAddRows = False ' Prevent adding new rows
    End Sub

    Public Sub LoadStudentData(Optional searchText As String = "")
        Try
            ConnectDB()
            Dim query As String = "SELECT ApplicationNo, Name, DOB, Age, Sex, Caste, Religion, CurrentAddress, PermanentAddress, 
                                      Email, Phone, FatherName, FatherJob, MotherName, MotherJob, Qualification, University, 
                                      PassoutYear, Mark, Course, Batch, CourseStartDate, CourseEndDate, FeesPaid, FeesRemaining, 
                                      ExamDate, Result, ResultDate, CertificateCollectedDate, Image 
                               FROM StudentDetails"
            If searchText <> "" Then
                query &= " WHERE Name LIKE @SearchText"
            End If

            Dim adapter As New MySqlDataAdapter(query, conn)
            adapter.SelectCommand.Parameters.AddWithValue("@SearchText", "%" & searchText & "%")

            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Error loading student data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Try
            ConnectDB()

            ' Loop through each edited row
            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.IsNewRow Then Continue For ' Skip new rows

                Dim query As String = "UPDATE StudentDetails SET 
                                Name = @Name, DOB = @DOB, Age = @Age, Sex = @Sex, 
                                Caste = @Caste, Religion = @Religion, CurrentAddress = @CurrentAddress, 
                                PermanentAddress = @PermanentAddress, Email = @Email, Phone = @Phone, 
                                FatherName = @FatherName, FatherJob = @FatherJob, MotherName = @MotherName, 
                                MotherJob = @MotherJob, Qualification = @Qualification, University = @University, 
                                PassoutYear = @PassoutYear, Mark = @Mark, Course = @Course, Batch = @Batch, 
                                CourseStartDate = @CourseStartDate, CourseEndDate = @CourseEndDate, 
                                FeesPaid = @FeesPaid, FeesRemaining = @FeesRemaining, 
                                ExamDate = @ExamDate, Result = @Result, ResultDate = @ResultDate, 
                                CertificateCollectedDate = @CertificateCollectedDate, Image = @Image
                                WHERE ApplicationNo = @AppNo"

                Dim cmd As New MySqlCommand(query, conn)

                ' Add all parameters
                cmd.Parameters.AddWithValue("@AppNo", row.Cells("ApplicationNo").Value)
                cmd.Parameters.AddWithValue("@Name", row.Cells("Name").Value)
                cmd.Parameters.AddWithValue("@DOB", row.Cells("DOB").Value)
                cmd.Parameters.AddWithValue("@Age", row.Cells("Age").Value)
                cmd.Parameters.AddWithValue("@Sex", row.Cells("Sex").Value)
                cmd.Parameters.AddWithValue("@Caste", row.Cells("Caste").Value)
                cmd.Parameters.AddWithValue("@Religion", row.Cells("Religion").Value)
                cmd.Parameters.AddWithValue("@CurrentAddress", row.Cells("CurrentAddress").Value)
                cmd.Parameters.AddWithValue("@PermanentAddress", row.Cells("PermanentAddress").Value)
                cmd.Parameters.AddWithValue("@Email", row.Cells("Email").Value)
                cmd.Parameters.AddWithValue("@Phone", row.Cells("Phone").Value)
                cmd.Parameters.AddWithValue("@FatherName", row.Cells("FatherName").Value)
                cmd.Parameters.AddWithValue("@FatherJob", row.Cells("FatherJob").Value)
                cmd.Parameters.AddWithValue("@MotherName", row.Cells("MotherName").Value)
                cmd.Parameters.AddWithValue("@MotherJob", row.Cells("MotherJob").Value)
                cmd.Parameters.AddWithValue("@Qualification", row.Cells("Qualification").Value)
                cmd.Parameters.AddWithValue("@University", row.Cells("University").Value)
                cmd.Parameters.AddWithValue("@PassoutYear", row.Cells("PassoutYear").Value)
                cmd.Parameters.AddWithValue("@Mark", row.Cells("Mark").Value)
                cmd.Parameters.AddWithValue("@Course", row.Cells("Course").Value)
                cmd.Parameters.AddWithValue("@Batch", row.Cells("Batch").Value)
                cmd.Parameters.AddWithValue("@CourseStartDate", row.Cells("CourseStartDate").Value)
                cmd.Parameters.AddWithValue("@CourseEndDate", row.Cells("CourseEndDate").Value)
                cmd.Parameters.AddWithValue("@FeesPaid", row.Cells("FeesPaid").Value)
                cmd.Parameters.AddWithValue("@FeesRemaining", row.Cells("FeesRemaining").Value)
                cmd.Parameters.AddWithValue("@ExamDate", row.Cells("ExamDate").Value)
                cmd.Parameters.AddWithValue("@Result", row.Cells("Result").Value)
                cmd.Parameters.AddWithValue("@ResultDate", row.Cells("ResultDate").Value)
                cmd.Parameters.AddWithValue("@CertificateCollectedDate", row.Cells("CertificateCollectedDate").Value)

                ' Handling Image
                Dim imageData As Byte()

                If PictureBox1.Image IsNot Nothing Then
                    ' Convert PictureBox image to byte array
                    Using ms As New MemoryStream()
                        PictureBox1.Image.Save(ms, Imaging.ImageFormat.Jpeg)
                        imageData = ms.ToArray()
                    End Using
                Else
                    imageData = Nothing
                End If

                cmd.Parameters.AddWithValue("@Image", If(imageData IsNot Nothing, imageData, DBNull.Value))

                cmd.ExecuteNonQuery()
            Next

            MessageBox.Show("All changes saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error saving changes: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub


    ' Load Image when selecting a student
    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim selectedAppNo As String = DataGridView1.SelectedRows(0).Cells("ApplicationNo").Value.ToString()
            LoadStudentImage(selectedAppNo)
        End If
    End Sub

    ' Load and display student image in PictureBox
    Private Sub LoadStudentImage(applicationNo As String)
        Try
            ConnectDB()
            Dim query As String = "SELECT Image FROM StudentDetails WHERE ApplicationNo = @AppNo"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@AppNo", applicationNo)

            Dim imageData As Object = cmd.ExecuteScalar()

            If imageData IsNot DBNull.Value Then
                Dim imgBytes As Byte() = CType(imageData, Byte())
                Dim ms As New MemoryStream(imgBytes)
                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                PictureBox1.Image = Image.FromStream(ms)
            Else
                PictureBox1.Image = Nothing
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub
    ' Click event to upload and update image
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a student to update the image.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Open file dialog to select an image
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Try
                Dim selectedAppNo As String = DataGridView1.SelectedRows(0).Cells("ApplicationNo").Value.ToString()

                ' Convert image to byte array
                Dim imgBytes() As Byte = File.ReadAllBytes(openFileDialog.FileName)

                ' Update image in database
                ConnectDB()
                Dim query As String = "UPDATE StudentDetails SET Image = @Image WHERE ApplicationNo = @AppNo"
                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@AppNo", selectedAppNo)
                cmd.Parameters.AddWithValue("@Image", imgBytes)
                cmd.ExecuteNonQuery()

                ' Display the selected image in PictureBox
                Dim ms As New MemoryStream(imgBytes)
                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                PictureBox1.Image = Image.FromStream(ms)

                MessageBox.Show("Image updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error updating image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                CloseDB()
            End Try
        End If
    End Sub

    ' Delete selected student
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a student to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedAppNo As String = DataGridView1.SelectedRows(0).Cells("ApplicationNo").Value.ToString()

        Dim confirmDelete As DialogResult = MessageBox.Show("Are you sure you want to delete this student?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If confirmDelete = DialogResult.Yes Then
            Try
                ConnectDB()
                Dim query As String = "DELETE FROM StudentDetails WHERE ApplicationNo = @AppNo"
                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@AppNo", selectedAppNo)
                cmd.ExecuteNonQuery()

                ' Remove row from DataGridView
                DataGridView1.Rows.Remove(DataGridView1.SelectedRows(0))

                MessageBox.Show("Student deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error deleting student: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                CloseDB()
            End Try
        End If
    End Sub



    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        LoadStudentData(TextBox1.Text)
    End Sub
    Private Sub DataGridView1_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles DataGridView1.CellValidating
        Dim columnName As String = DataGridView1.Columns(e.ColumnIndex).Name
        Dim cellValue As String = e.FormattedValue.ToString().Trim()

        ' Phone number validation (must be 10 digits)
        If columnName = "Phone" Then
            If Not System.Text.RegularExpressions.Regex.IsMatch(cellValue, "^\d{10}$") Then
                MessageBox.Show("Phone number must be exactly 10 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                e.Cancel = True
            End If
        End If

        ' Qualification year validation (greater than 1900)
        If columnName = "PassoutYear" Then
            Dim qualYear As Integer
            If Not Integer.TryParse(cellValue, qualYear) OrElse qualYear <= 1900 Then
                MessageBox.Show("Qualification year must be greater than 1900.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                e.Cancel = True
            End If
        End If

        ' Date of Birth validation (Age must be 14 or above)
        If columnName = "DOB" Then
            Dim birthDate As Date
            If Date.TryParse(cellValue, birthDate) Then
                Dim today As Date = Date.Today
                Dim age As Integer = today.Year - birthDate.Year
                If (today.Month < birthDate.Month) Or (today.Month = birthDate.Month AndAlso today.Day < birthDate.Day) Then
                    age -= 1
                End If

                If age < 14 Then
                    MessageBox.Show("Age must be 14 or above.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    e.Cancel = True
                End If
            Else
                MessageBox.Show("Invalid Date of Birth format.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                e.Cancel = True
            End If
        End If

        ' Percentage validation (must be between 0 and 100)
        If columnName = "Percentage" Then
            Dim percentage As Double
            If Not Double.TryParse(cellValue, percentage) OrElse percentage < 0 OrElse percentage > 100 Then
                MessageBox.Show("Percentage must be a number between 0 and 100.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                e.Cancel = True
            End If
        End If
    End Sub

End Class
