Public Class Studentmenuvb
    Public UserType As String ' Store user type

    ' Function to open child forms and restore parent when they close
    Private Sub OpenChildForm(childForm As Form)
        Me.Hide()  ' Hide Studentmenuvb
        'childForm.WindowState = FormWindowState.Maximized  ' Maximize child form
        childForm.Show()

        ' Restore Studentmenuvb when the child form closes
        AddHandler childForm.FormClosed, AddressOf RestoreParentForm
    End Sub

    ' Function to restore Studentmenuvb when a child form closes
    Private Sub RestoreParentForm(sender As Object, e As FormClosedEventArgs)
        Me.Show()
    End Sub

    ' Student Registration Button
    Private Sub btnStudReg_Click(sender As Object, e As EventArgs) Handles btnStudReg.Click
        OpenChildForm(New Registration())
    End Sub

    ' Student View Button
    Private Sub btnStudView_Click(sender As Object, e As EventArgs) Handles btnStudView.Click
        OpenChildForm(New StudentView())
    End Sub

    ' Student Edit Button
    Private Sub btnStudEdt_Click(sender As Object, e As EventArgs) Handles btnStudEdt.Click
        OpenChildForm(New studentedit())
    End Sub
    Private Sub btnMarkAttendance_Click(sender As Object, e As EventArgs) Handles btnMarkAttendance.Click
        OpenChildForm(New AttendanceForm())
    End Sub
    Private Sub btnViewAttendance_Click(sender As Object, e As EventArgs) Handles btnViewAttendance.Click
        OpenChildForm(New ViewAttendanceForm())
    End Sub
    Private Sub Studentmenuvb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(813, 454)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Location = New Point((Screen.PrimaryScreen.Bounds.Width - Me.Width) \ 2,
                                (Screen.PrimaryScreen.Bounds.Height - Me.Height) \ 2)

    End Sub
End Class
