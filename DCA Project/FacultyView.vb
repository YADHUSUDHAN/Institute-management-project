Imports MySql.Data.MySqlClient
Imports System.IO

Public Class FacultyView
    Private Sub FacultyView_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        FacultyMenu.Show()
    End Sub

    Private Sub FacultyView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(813, 454)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Location = New Point((Screen.PrimaryScreen.Bounds.Width - Me.Width) \ 2,
                                (Screen.PrimaryScreen.Bounds.Height - Me.Height) \ 2)

        DataGridView1.ReadOnly = True
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        LoadFacultyData()
    End Sub

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
            LoadFacultyImage(selectedEmpID)
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

    ' Load faculty subjects from FacultySubjects table
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

        Catch ex As Exception
            MessageBox.Show("Error loading subjects: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub
End Class
