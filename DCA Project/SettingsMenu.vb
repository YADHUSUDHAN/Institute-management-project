Public Class SettingsMenu

    ' Function to open child forms and restore parent when they close
    Private Sub OpenChildForm(childForm As Form)
        Me.Hide() ' Hide SettingsMenu
        childForm.WindowState = FormWindowState.Maximized ' Maximize child form
        childForm.Show()

        ' Restore SettingsMenu when the child form closes
        AddHandler childForm.FormClosed, AddressOf RestoreParentForm
    End Sub

    ' Function to restore SettingsMenu when a child form closes
    Private Sub RestoreParentForm(sender As Object, e As FormClosedEventArgs)
        Me.Show()
    End Sub

    ' Add User Button
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenChildForm(New addUser())
    End Sub

    ' Edit User Button
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        OpenChildForm(New EditUser())
    End Sub

    Private Sub SettingsMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(813, 454)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Location = New Point((Screen.PrimaryScreen.Bounds.Width - Me.Width) \ 2,
                                (Screen.PrimaryScreen.Bounds.Height - Me.Height) \ 2)

    End Sub
End Class
