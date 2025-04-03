Imports MySql.Data.MySqlClient
Imports System.IO

Public Class FacultyEdit

    Private Sub FacultyEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(813, 454)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Location = New Point((Screen.PrimaryScreen.Bounds.Width - Me.Width) \ 2,
                                (Screen.PrimaryScreen.Bounds.Height - Me.Height) \ 2)

        DataGridView1.AllowUserToAddRows = False ' Disable adding new rows
        LoadFacultyData()
    End Sub

    ' Load faculty details from database
    Public Sub LoadFacultyData(Optional searchText As String = "")
        Try
            ConnectDB()
            Dim query As String = "SELECT EmployeeID, Name, DOB, Phone, CourseID, Image FROM FacultyDetails"

            If searchText <> "" Then
                query &= " WHERE Name LIKE @SearchText"
            End If

            Dim adapter As New MySqlDataAdapter(query, conn)
            adapter.SelectCommand.Parameters.AddWithValue("@SearchText", "%" & searchText & "%")

            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Error loading faculty data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        LoadFacultyData(TextBox1.Text)
    End Sub

    ' Load faculty image and subjects when a row is selected
    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim selectedEmpID As String = DataGridView1.SelectedRows(0).Cells("EmployeeID").Value.ToString()
            Dim courseID As String = DataGridView1.SelectedRows(0).Cells("CourseID").Value.ToString()
            LoadFacultyImage(selectedEmpID)
            LoadSubjects(courseID)
            LoadFacultySubjects(selectedEmpID)
        End If
    End Sub

    ' Load faculty image
    Private Sub LoadFacultyImage(empID As String)
        Try
            ConnectDB()
            Dim query As String = "SELECT Image FROM FacultyDetails WHERE EmployeeID = @EmpID"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@EmpID", empID)

            Dim imageData As Object = cmd.ExecuteScalar()

            If imageData IsNot DBNull.Value Then
                Dim imgBytes As Byte() = CType(imageData, Byte())
                Dim ms As New MemoryStream(imgBytes)
                PictureBox1.Image = Image.FromStream(ms)
                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            Else
                PictureBox1.Image = Nothing ' No image available
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub

    ' Load subjects based on CourseID
    Private Sub LoadSubjects(courseID As String)
        Try
            ConnectDB()
            Dim query As String = "SELECT SubjectName FROM CourseSubjects WHERE CourseID = @CourseID"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@CourseID", courseID)

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            ChkListSubjects.Items.Clear()

            While reader.Read()
                ChkListSubjects.Items.Add(reader("SubjectName").ToString())
            End While
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading subjects: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub

    ' Load faculty subjects and check them in ChkListSubjects
    Private Sub LoadFacultySubjects(empID As String)
        Try
            ConnectDB()
            Dim query As String = "SELECT SubjectName FROM FacultySubjects WHERE FacultyID = @EmpID"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@EmpID", empID)

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            Dim subjects As New List(Of String)()

            While reader.Read()
                subjects.Add(reader("SubjectName").ToString())
            End While
            reader.Close()
            ' Display subjects in a ListBox or Label
            LblSubjects.Text = "Subjects: " & String.Join(", ", subjects)
            ' Mark checked subjects
            For i As Integer = 0 To ChkListSubjects.Items.Count - 1
                If subjects.Contains(ChkListSubjects.Items(i).ToString()) Then
                    ChkListSubjects.SetItemChecked(i, True)
                Else
                    ChkListSubjects.SetItemChecked(i, False)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error loading faculty subjects: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub

    ' Save updated faculty details
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Try
            If DataGridView1.SelectedRows.Count = 0 Then
                MessageBox.Show("Please select a faculty record to save changes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim selectedEmpID As String = DataGridView1.SelectedRows(0).Cells("EmployeeID").Value.ToString()
            ConnectDB()

            Dim query As String = "UPDATE FacultyDetails SET Name = @Name, DOB = @DOB, Phone = @Phone, CourseID = @CourseID, Image = @Image WHERE EmployeeID = @EmpID"
            Dim cmd As New MySqlCommand(query, conn)

            cmd.Parameters.AddWithValue("@EmpID", selectedEmpID)
            cmd.Parameters.AddWithValue("@Name", DataGridView1.SelectedRows(0).Cells("Name").Value)
            cmd.Parameters.AddWithValue("@DOB", DataGridView1.SelectedRows(0).Cells("DOB").Value)
            cmd.Parameters.AddWithValue("@Phone", DataGridView1.SelectedRows(0).Cells("Phone").Value)
            cmd.Parameters.AddWithValue("@CourseID", DataGridView1.SelectedRows(0).Cells("CourseID").Value)

            ' Save updated image if changed
            Dim ms As New MemoryStream()
            If PictureBox1.Image IsNot Nothing Then
                PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
                cmd.Parameters.AddWithValue("@Image", ms.ToArray())
            Else
                cmd.Parameters.AddWithValue("@Image", DBNull.Value)
            End If

            cmd.ExecuteNonQuery()
            UpdateFacultySubjects(selectedEmpID)

            MessageBox.Show("Faculty details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadFacultyData()
        Catch ex As Exception
            MessageBox.Show("Error saving faculty details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub

    ' Update faculty subjects in FacultySubjects table
    Private Sub UpdateFacultySubjects(empID As String)
        Try
            ConnectDB()
            Dim deleteQuery As String = "DELETE FROM FacultySubjects WHERE FacultyID = @EmpID"
            Dim deleteCmd As New MySqlCommand(deleteQuery, conn)
            deleteCmd.Parameters.AddWithValue("@EmpID", empID)
            deleteCmd.ExecuteNonQuery()

            For Each subject As String In ChkListSubjects.CheckedItems
                Dim insertQuery As String = "INSERT INTO FacultySubjects (FacultyID, SubjectName) VALUES (@EmpID, @SubjectName)"
                Dim insertCmd As New MySqlCommand(insertQuery, conn)
                insertCmd.Parameters.AddWithValue("@EmpID", empID)
                insertCmd.Parameters.AddWithValue("@SubjectName", subject)
                insertCmd.ExecuteNonQuery()
            Next
        Catch ex As Exception
            MessageBox.Show("Error updating subjects: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub
    Private Sub DataGridView1_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles DataGridView1.CellValidating
        Dim columnName As String = DataGridView1.Columns(e.ColumnIndex).Name
        Dim cellValue As String = e.FormattedValue.ToString().Trim()

        ' Name should not be empty
        If columnName = "Name" AndAlso String.IsNullOrWhiteSpace(cellValue) Then
            MessageBox.Show("Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            e.Cancel = True
        End If

        ' Phone must be 10 digits
        If columnName = "Phone" AndAlso Not System.Text.RegularExpressions.Regex.IsMatch(cellValue, "^\d{10}$") Then
            MessageBox.Show("Phone number must be exactly 10 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            e.Cancel = True
        End If

        ' DOB should be a valid date
        If columnName = "DOB" Then
            Dim dob As Date
            If Not Date.TryParse(cellValue, dob) Then
                MessageBox.Show("Enter a valid date of birth.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                e.Cancel = True
            End If
        End If

        ' CourseID should not be empty
        If columnName = "CourseID" AndAlso String.IsNullOrWhiteSpace(cellValue) Then
            MessageBox.Show("CourseID cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            e.Cancel = True
        End If
    End Sub

End Class
