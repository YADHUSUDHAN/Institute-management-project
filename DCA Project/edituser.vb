Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text

Public Class EditUser
    Private Sub EditUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(813, 454)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Location = New Point((Screen.PrimaryScreen.Bounds.Width - Me.Width) \ 2,
                                (Screen.PrimaryScreen.Bounds.Height - Me.Height) \ 2)

        LoadUsers()
    End Sub

    ' Load user data into DataGridView
    Private Sub LoadUsers()
        Try
            ConnectDB()
            Dim query As String = "SELECT UserID, Username, '' AS Password, UserType FROM Users"
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table

            ' Make UserID read-only
            DataGridView1.Columns("UserID").ReadOnly = True
        Catch ex As Exception
            MessageBox.Show("Error loading users: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub

    ' Save changes when the user moves to another row
    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        Try
            ConnectDB()
            Dim userID As Integer = DataGridView1.Rows(e.RowIndex).Cells("UserID").Value
            Dim username As String = DataGridView1.Rows(e.RowIndex).Cells("Username").Value.ToString()
            Dim userType As String = DataGridView1.Rows(e.RowIndex).Cells("UserType").Value.ToString()
            Dim newPassword As String = DataGridView1.Rows(e.RowIndex).Cells("Password").Value.ToString()

            ' Update Username and UserType
            Dim query As String = "UPDATE Users SET Username = @Username, UserType = @UserType WHERE UserID = @UserID"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@UserID", userID)
            cmd.Parameters.AddWithValue("@Username", username)
            cmd.Parameters.AddWithValue("@UserType", userType)
            cmd.ExecuteNonQuery()

            ' If a new password is entered, update it
            If Not String.IsNullOrEmpty(newPassword) Then
                Dim hashedPassword As String = HashPassword(newPassword)
                Dim passQuery As String = "UPDATE Users SET Password = @Password WHERE UserID = @UserID"
                Dim passCmd As New MySqlCommand(passQuery, conn)
                passCmd.Parameters.AddWithValue("@UserID", userID)
                passCmd.Parameters.AddWithValue("@Password", hashedPassword)
                passCmd.ExecuteNonQuery()
            End If

            MessageBox.Show("User details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadUsers() ' Refresh DataGridView
        Catch ex As Exception
            MessageBox.Show("Error updating user: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub

    ' Delete selected user
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a user to delete!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim userID As Integer = DataGridView1.SelectedRows(0).Cells("UserID").Value
        Dim confirm As DialogResult = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If confirm = DialogResult.Yes Then
            Try
                ConnectDB()
                Dim query As String = "DELETE FROM Users WHERE UserID = @UserID"
                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@UserID", userID)
                cmd.ExecuteNonQuery()

                MessageBox.Show("User deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadUsers()
            Catch ex As Exception
                MessageBox.Show("Error deleting user: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                CloseDB()
            End Try
        End If
    End Sub

    ' Hash password before storing it in the database
    Private Function HashPassword(password As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(password)
            Dim hash As Byte() = sha256.ComputeHash(bytes)
            Return Convert.ToBase64String(hash)
        End Using
    End Function

    ' Show admin menu on closing
    Private Sub EditUser_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        SettingsMenu.Show()
    End Sub
End Class
