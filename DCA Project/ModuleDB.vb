Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Module ModuleDB
    ' Declare a public MySQL connection
    Public conn As MySqlConnection

    ' Function to initialize connection
    Public Sub ConnectDB()
        Try
            conn = New MySqlConnection("server=localhost;user=root;password=123456;database=proj")
            conn.Open()
        Catch ex As Exception
            MessageBox.Show("Database Connection Failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Function to close connection
    Public Sub CloseDB()
        Try
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Error Closing Database: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Module
