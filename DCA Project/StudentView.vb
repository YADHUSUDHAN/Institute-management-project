Imports MySql.Data.MySqlClient

Public Class StudentView
    Public Sub LoadStudentData()
        Try
            ConnectDB()
            Dim query As String = "SELECT ApplicationNo, Name, DOB, Age, Sex, Caste, Religion, CurrentAddress, PermanentAddress, 
                                      Email, Phone, FatherName, FatherJob, MotherName, MotherJob, Qualification, University, 
                                      PassoutYear, Mark, Course, Batch, CourseStartDate, CourseEndDate, FeesPaid, FeesRemaining, 
                                      ExamDate, Result, ResultDate, CertificateCollectedDate, Image 
                               FROM StudentDetails"
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Error loading student data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub


    Private Sub StudentView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(813, 454)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Location = New Point((Screen.PrimaryScreen.Bounds.Width - Me.Width) \ 2,
                                (Screen.PrimaryScreen.Bounds.Height - Me.Height) \ 2)

        LoadStudentData()
        CmbSearchfield.Items.AddRange(New String() {"ApplicationNo", "Name", "Course", "Batch"})
        CmbSearchfield.SelectedIndex = 1 ' Default selection
        DataGridView1.ReadOnly = True
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
    End Sub

    ' Search Functionality
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            If CmbSearchfield.SelectedItem Is Nothing Then
                MessageBox.Show("Please select a search field.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim selectedField As String = CmbSearchfield.SelectedItem.ToString()
            Dim query As String = "SELECT ApplicationNo, Name, DOB, Age, Sex, Caste, Religion, CurrentAddress, PermanentAddress, 
                                      Email, Phone, FatherName, FatherJob, MotherName, MotherJob, Qualification, University, 
                                      PassoutYear, Mark, Course, Batch, CourseStartDate, CourseEndDate, FeesPaid, FeesRemaining, 
                                      ExamDate, Result, ResultDate, CertificateCollectedDate, Image 
                               FROM StudentDetails 
                               WHERE " & selectedField & " LIKE @SearchText"
            ConnectDB()

            Dim adapter As New MySqlDataAdapter(query, conn)
            adapter.SelectCommand.Parameters.AddWithValue("@SearchText", "%" & TextBox1.Text & "%")

            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Error searching student: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub

    ' Load Student Image
    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim selectedAppNo As String = DataGridView1.SelectedRows(0).Cells("ApplicationNo").Value.ToString()
            LoadStudentImage(selectedAppNo)
        End If
    End Sub

    Private Sub LoadStudentImage(applicationNo As String)
        Try
            ConnectDB()
            Dim query As String = "SELECT Image FROM StudentDetails WHERE ApplicationNo = @AppNo"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@AppNo", applicationNo)

            Dim imageData As Object = cmd.ExecuteScalar()

            If imageData IsNot DBNull.Value Then
                Dim imgBytes As Byte() = CType(imageData, Byte())
                Dim ms As New IO.MemoryStream(imgBytes)
                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                PictureBox1.Image = Image.FromStream(ms)
            Else
                PictureBox1.Image = Nothing ' No image available
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub
    ' Export DataGridView to CSV
    Private Sub ExportToCSV(dataGridView As DataGridView, filePath As String)
        Try
            Using writer As New IO.StreamWriter(filePath)
                ' Write the header
                For Each col As DataGridViewColumn In dataGridView.Columns
                    writer.Write(col.HeaderText & ",")
                Next
                writer.WriteLine()

                ' Write the data rows
                For Each row As DataGridViewRow In dataGridView.Rows
                    For Each cell As DataGridViewCell In row.Cells
                        writer.Write(cell.Value?.ToString() & ",")
                    Next
                    writer.WriteLine()
                Next
            End Using
            MessageBox.Show("Data exported to CSV successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error exporting to CSV: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnDownloadCSV_Click(sender As Object, e As EventArgs) Handles btnDownloadCSV.Click
        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "CSV files (*.csv)|*.csv"
        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            ExportToCSV(DataGridView1, saveFileDialog.FileName)
        End If
    End Sub



End Class
