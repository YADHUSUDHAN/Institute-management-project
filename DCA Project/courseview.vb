
Imports MySql.Data.MySqlClient

Public Class courseview



    Private Sub courseview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(813, 454)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Location = New Point((Screen.PrimaryScreen.Bounds.Width - Me.Width) \ 2,
                                (Screen.PrimaryScreen.Bounds.Height - Me.Height) \ 2)

        DataGridView1.AllowUserToAddRows = False
        LoadCourseData()
    End Sub

    Public Sub LoadCourseData(Optional searchText As String = "")
        Try
            ConnectDB()
            Dim query As String = "SELECT c.CourseID, c.CourseName, c.Duration, c.Fees, GROUP_CONCAT(s.SubjectName SEPARATOR ', ') AS Subjects 
                                   FROM CourseDetails c 
                                   LEFT JOIN CourseSubjects s ON c.CourseID = s.CourseID 
                                   GROUP BY c.CourseID"

            If searchText <> "" Then
                query &= " HAVING c.CourseName LIKE @SearchText"
            End If

            Dim adapter As New MySqlDataAdapter(query, conn)
            adapter.SelectCommand.Parameters.AddWithValue("@SearchText", "%" & searchText & "%")

            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Error loading courses: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        LoadCourseData(TextBox1.Text)
    End Sub
End Class
