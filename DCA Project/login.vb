Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text

Public Class Txtlogin
    ' Function to open child forms and restore parent when they close
    Private Sub OpenChildForm(childForm As Form)
        Me.Hide() ' Hide Login Form
        'childForm.WindowState = FormWindowState.Maximized ' Maximize child form
        childForm.Show()

        ' Restore Login Form when the child form closes
        AddHandler childForm.FormClosed, AddressOf RestoreParentForm
    End Sub

    ' Function to restore Login Form when a child form closes
    Private Sub RestoreParentForm(sender As Object, e As FormClosedEventArgs)
        Me.Show()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
            ConnectDB()

            ' Query to fetch the stored password hash for the entered username
            Dim query As String = "SELECT Password, UserType FROM Users WHERE Username = @Username"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@Username", txtUsername.Text)

            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                Dim storedHash As String = reader("Password").ToString()
                Dim userType As String = reader("UserType").ToString()

                ' Compare the entered password hash with the stored hash
                If VerifyPassword(txtPassword.Text, storedHash) Then
                    Dim mainForm As New Form1()
                    mainForm.UserType = userType
                    OpenChildForm(mainForm) ' Open Form1 as child
                Else
                    MessageBox.Show("Invalid Username or Password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Invalid Username or Password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub

    Private Sub Txtlogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(813, 454)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Location = New Point((Screen.PrimaryScreen.Bounds.Width - Me.Width) \ 2,
                                (Screen.PrimaryScreen.Bounds.Height - Me.Height) \ 2)

        ' Load saved username if Remember Me was checked
        If Not String.IsNullOrEmpty(My.Settings.Username) Then
            txtUsername.Text = My.Settings.Username
            chkRememberMe.Checked = True
        End If


    End Sub

    ' Hash password using SHA-256
    Private Function HashPassword(password As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(password)
            Dim hash As Byte() = sha256.ComputeHash(bytes)
            Return Convert.ToBase64String(hash)
        End Using
    End Function

    ' Verify if entered password matches the stored hash
    Private Function VerifyPassword(enteredPassword As String, storedHash As String) As Boolean
        Return HashPassword(enteredPassword) = storedHash
    End Function
End Class
