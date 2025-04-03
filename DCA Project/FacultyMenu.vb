Public Class FacultyMenu
    Public UserType As String ' Store user type

    ' Function to open child forms and restore parent when they close
    Private Sub OpenChildForm(childForm As Form)
        Me.Hide() ' Hide FacultyMenu
        'childForm.WindowState = FormWindowState.Maximized ' Maximize child form
        childForm.Show()

        ' Restore FacultyMenu when the child form closes
        AddHandler childForm.FormClosed, AddressOf RestoreParentForm
    End Sub

    ' Function to restore FacultyMenu when a child form closes
    Private Sub RestoreParentForm(sender As Object, e As FormClosedEventArgs)
        Me.Show()
    End Sub

    ' Faculty Registration Button
    Private Sub btnFcltyReg_Click(sender As Object, e As EventArgs) Handles btnFcltyReg.Click
        OpenChildForm(New facultyregistration())
    End Sub

    ' Faculty View Button
    Private Sub btnFcltyView_Click(sender As Object, e As EventArgs) Handles btnFcltyView.Click
        OpenChildForm(New FacultyView())
    End Sub

    ' Faculty Edit Button
    Private Sub btnFcltyEdt_Click(sender As Object, e As EventArgs) Handles btnFcltyEdt.Click
        OpenChildForm(New FacultyEdit())
    End Sub

    Private Sub FacultyMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(813, 454)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Location = New Point((Screen.PrimaryScreen.Bounds.Width - Me.Width) \ 2,
                                (Screen.PrimaryScreen.Bounds.Height - Me.Height) \ 2)

    End Sub
End Class
