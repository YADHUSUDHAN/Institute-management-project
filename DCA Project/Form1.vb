Public Class Form1
    Public UserType As String ' Store user type

    ' Function to open child forms and restore parent when they close
    Private Sub OpenChildForm(childForm As Form)
        Me.Hide() ' Hide Form1
        'childForm.WindowState = FormWindowState.Maximized ' Maximize child form
        childForm.Show()

        ' Restore Form1 when the child form closes
        AddHandler childForm.FormClosed, AddressOf RestoreParentForm
    End Sub

    ' Function to restore Form1 when a child form closes
    Private Sub RestoreParentForm(sender As Object, e As FormClosedEventArgs)
        Me.Show()
    End Sub

    ' Student Menu Button
    Private Sub btnStud_Click(sender As Object, e As EventArgs) Handles btnStud.Click
        OpenChildForm(New Studentmenuvb())
    End Sub

    ' Faculty Menu Button
    Private Sub btnFaculty_Click(sender As Object, e As EventArgs) Handles btnFaculty.Click
        OpenChildForm(New FacultyMenu())
    End Sub

    ' Course Menu Button
    Private Sub btnCourse_Click(sender As Object, e As EventArgs) Handles btnCourse.Click
        OpenChildForm(New CourseMenu())
    End Sub

    ' Settings Menu Button
    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        OpenChildForm(New SettingsMenu())
    End Sub

    ' Restore login form when closing Form1
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    ' Hide admin options if user is Faculty
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(813, 454)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Location = New Point((Screen.PrimaryScreen.Bounds.Width - Me.Width) \ 2,
                                (Screen.PrimaryScreen.Bounds.Height - Me.Height) \ 2)
        If UserType = "Faculty" Then
            Label4.Visible = False
            btnSettings.Visible = False
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Txtlogin.Show()
    End Sub
End Class
