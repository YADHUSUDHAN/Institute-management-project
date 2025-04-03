Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text

Public Class addUser
    Private Sub BtnCreate_Click(sender As Object, e As EventArgs) Handles BtnCreate.Click
        If TxtUsrname.Text = "" Or TxtPass.Text = "" Or TxtCnfmPass.Text = "" Or CmbUsrType.SelectedIndex = -1 Then
            MessageBox.Show("All fields are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If TxtPass.Text <> TxtCnfmPass.Text Then
            MessageBox.Show("Passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            ConnectDB()
            Dim hashedPassword As String = HashPassword(TxtPass.Text)
            Dim query As String = "INSERT INTO Users (Username, Password, UserType) VALUES (@Username, @Password, @UserType)"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@Username", TxtUsrname.Text)
            cmd.Parameters.AddWithValue("@Password", hashedPassword)
            cmd.Parameters.AddWithValue("@UserType", CmbUsrType.SelectedItem.ToString())
            cmd.ExecuteNonQuery()
            MessageBox.Show("User created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub

    Private Function HashPassword(password As String) As String
        Dim sha256 As SHA256 = SHA256.Create()
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(password)
        Dim hash As Byte() = sha256.ComputeHash(bytes)
        Return Convert.ToBase64String(hash)
    End Function

    Private Sub CheckBoxShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxShowpassword.CheckedChanged
        TxtPass.UseSystemPasswordChar = Not CheckBoxShowpassword.Checked
        TxtCnfmPass.UseSystemPasswordChar = Not CheckBoxShowpassword.Checked
    End Sub

    Private Sub ClearFields()
        TxtUsrname.Text = ""
        TxtPass.Text = ""
        TxtCnfmPass.Text = ""
        CmbUsrType.SelectedIndex = -1
        CheckBoxShowpassword.Checked = False
    End Sub

    Private Sub addUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(813, 454)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Location = New Point((Screen.PrimaryScreen.Bounds.Width - Me.Width) \ 2,
                                (Screen.PrimaryScreen.Bounds.Height - Me.Height) \ 2)

    End Sub
End Class
