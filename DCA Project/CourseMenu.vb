Public Class CourseMenu
    Public UserType As String ' Store user type

    ' Function to open child forms and restore parent when they close
    Private Sub OpenChildForm(childForm As Form)
        Me.Hide() ' Hide CourseMenu
        'childForm.WindowState = FormWindowState.Maximized ' Maximize child form
        childForm.Show()

        ' Restore CourseMenu when the child form closes
        AddHandler childForm.FormClosed, AddressOf RestoreParentForm
    End Sub

    ' Function to restore CourseMenu when a child form closes
    Private Sub RestoreParentForm(sender As Object, e As FormClosedEventArgs)
        Me.Show()
    End Sub

    ' Course Registration Button
    Private Sub btnCrsReg_Click(sender As Object, e As EventArgs) Handles btnCrsReg.Click
        OpenChildForm(New Add_Course())
    End Sub

    ' Course View Button
    Private Sub btnCrsView_Click(sender As Object, e As EventArgs) Handles btnCrsView.Click
        OpenChildForm(New courseview())
    End Sub

    ' Course Edit Button
    Private Sub btnCrsEdt_Click(sender As Object, e As EventArgs) Handles btnCrsEdt.Click
        OpenChildForm(New CourseEdit())
    End Sub

    ' Restore Form1 when CourseMenu closes

    ' Hide Course Edit option for Faculty users
    Private Sub CourseMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(813, 454)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Location = New Point((Screen.PrimaryScreen.Bounds.Width - Me.Width) \ 2,
                                (Screen.PrimaryScreen.Bounds.Height - Me.Height) \ 2)

        If UserType = "Faculty" Then
            btnCrsEdt.Visible = False ' Hide Edit Course button for Faculty users
            Label3.Visible = False
        End If
    End Sub
End Class
