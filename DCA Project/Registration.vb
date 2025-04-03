Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Registration
    Private Sub GetNextApplicationNo()
        Try
            ConnectDB()
            Dim query As String = "SELECT MAX(ApplicationNo) FROM StudentDetails"
            Dim cmd As New MySqlCommand(query, conn)
            Dim result As Object = cmd.ExecuteScalar()

            ' If no records exist, start from 1000; otherwise, increment the max ApplicationNo
            If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                txtApplicationno.Text = (Convert.ToInt32(result) + 1).ToString()
            Else
                txtApplicationno.Text = "1000"
            End If

            txtApplicationno.ReadOnly = True ' Make the Application Number read-only
        Catch ex As Exception
            MessageBox.Show("Error fetching Application Number: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub

    Private Sub Registration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(813, 454)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Location = New Point((Screen.PrimaryScreen.Bounds.Width - Me.Width) \ 2,
                                (Screen.PrimaryScreen.Bounds.Height - Me.Height) \ 2)
        Me.AutoScroll = True
        LoadCourses() ' Populate CourseID in ComboBox
        LoadBatches()
        GetNextApplicationNo()

    End Sub
    Private Sub LoadBatches()
        Try
            ConnectDB()
            Dim query As String = "SELECT DISTINCT Batch FROM StudentDetails WHERE Batch IS NOT NULL"
            Dim cmd As New MySqlCommand(query, conn)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            ComboBoxBatch.Items.Clear()

            While reader.Read()
                ComboBoxBatch.Items.Add(reader("Batch").ToString())
            End While

            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading batches: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub

    Private Sub LoadCourses()
        Try
            ConnectDB()
            Dim query As String = "SELECT CourseID FROM CourseDetails"
            Dim cmd As New MySqlCommand(query, conn)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            cmbcourse.Items.Clear() ' Clear existing items before adding new ones

            While reader.Read()
                cmbcourse.Items.Add(reader("CourseID").ToString())
            End While

            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading courses: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub
    Private Sub cmbcourse_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcourse.SelectedIndexChanged
        If cmbcourse.SelectedIndex = -1 Then Exit Sub

        Try
            ConnectDB()
            Dim query As String = "SELECT Fees FROM CourseDetails WHERE CourseID = @CourseID"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@CourseID", cmbcourse.Text)

            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                Dim courseFees As Decimal = Convert.ToDecimal(reader("Fees"))
                txtFeesPaid.Text = "0" ' Default paid fees
                txtFeesRemaining.Text = courseFees.ToString("0.00") ' Set initial remaining fees
                txtFeesRemaining.ReadOnly = True ' Make it read-only
            End If

            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error fetching course fees: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub
    Private Sub txtFeesPaid_TextChanged(sender As Object, e As EventArgs) Handles txtFeesPaid.TextChanged
        Dim courseFees As Decimal
        Dim feesPaid As Decimal

        ' Ensure course fees is loaded
        If Not Decimal.TryParse(txtFeesRemaining.Text, courseFees) Then Exit Sub

        ' Validate paid fees input
        If Decimal.TryParse(txtFeesPaid.Text, feesPaid) AndAlso feesPaid >= 0 Then
            Dim remainingFees As Decimal = courseFees - feesPaid
            txtFeesRemaining.Text = remainingFees.ToString("0.00")
        Else
            txtFeesRemaining.Text = courseFees.ToString("0.00") ' Reset if invalid input
        End If
    End Sub

    Private Sub dtpDOB_ValueChanged(sender As Object, e As EventArgs) Handles dtpDOB.ValueChanged
        Dim birthDate As Date = dtpDOB.Value
        Dim today As Date = Date.Today
        Dim age As Integer = today.Year - birthDate.Year
        If (today.Month < birthDate.Month) Or (today.Month = birthDate.Month AndAlso today.Day < birthDate.Day) Then
            age -= 1
        End If
        txtAge.Text = age.ToString()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        txtCaddress.Text = txtPaddress.Text
    End Sub



    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        ' Validation for empty fields
        If String.IsNullOrWhiteSpace(txtApplicationno.Text) OrElse
       String.IsNullOrWhiteSpace(txtName.Text) OrElse
       String.IsNullOrWhiteSpace(txtCaste.Text) OrElse
       String.IsNullOrWhiteSpace(txtReligion.Text) OrElse
       String.IsNullOrWhiteSpace(txtCaddress.Text) OrElse
       String.IsNullOrWhiteSpace(txtPaddress.Text) OrElse
       String.IsNullOrWhiteSpace(txtemail.Text) OrElse
       String.IsNullOrWhiteSpace(txtphone.Text) OrElse
       String.IsNullOrWhiteSpace(txtfathername.Text) OrElse
       String.IsNullOrWhiteSpace(txtfatherjob.Text) OrElse
       String.IsNullOrWhiteSpace(txtmothername.Text) OrElse
       String.IsNullOrWhiteSpace(txtmotherjob.Text) OrElse
       String.IsNullOrWhiteSpace(txtqual.Text) OrElse
       String.IsNullOrWhiteSpace(txtqualuniv.Text) OrElse
       String.IsNullOrWhiteSpace(txtqualyear.Text) OrElse
       String.IsNullOrWhiteSpace(txtmark.Text) OrElse
       String.IsNullOrWhiteSpace(cmbcourse.Text) OrElse
       String.IsNullOrWhiteSpace(ComboBoxBatch.Text) Then
            MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Age validation (must be 14 or above)
        Dim birthDate As Date = dtpDOB.Value
        Dim today As Date = Date.Today
        Dim age As Integer = today.Year - birthDate.Year
        If (today.Month < birthDate.Month) Or (today.Month = birthDate.Month AndAlso today.Day < birthDate.Day) Then
            age -= 1
        End If
        If age < 14 Then
            MessageBox.Show("Age must be 14 or above.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Mobile number validation (10 digits and only numbers)
        If Not System.Text.RegularExpressions.Regex.IsMatch(txtphone.Text, "^\d{10}$") Then
            MessageBox.Show("Phone number must be exactly 10 digits and contain only numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Email validation
        If Not System.Text.RegularExpressions.Regex.IsMatch(txtemail.Text, "^[^@\s]+@[^@\s]+\.[^@\s]+$") Then
            MessageBox.Show("Enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Marks validation (0-100 percentage)
        Dim mark As Integer
        If Not Integer.TryParse(txtmark.Text, mark) OrElse mark < 0 OrElse mark > 100 Then
            MessageBox.Show("Marks must be a valid percentage between 0 and 100.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Qualification year validation (greater than 1900 and only digits)
        Dim qualYear As Integer
        If Not Integer.TryParse(txtqualyear.Text, qualYear) OrElse qualYear <= 1900 Then
            MessageBox.Show("Qualification year must be greater than 1900 and contain only numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Fetch Course Fees from DB
        Dim courseFees As Decimal = 0
        Try
            ConnectDB()
            Dim query As String = "SELECT Fees FROM CourseDetails WHERE CourseID = @CourseID"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@CourseID", cmbcourse.Text)
            Dim result As Object = cmd.ExecuteScalar()
            If result IsNot Nothing Then
                courseFees = Convert.ToDecimal(result)
            End If
        Catch ex As Exception
            MessageBox.Show("Error fetching course fees: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            CloseDB()
        End Try

        ' Fees Paid Validation
        Dim feesPaid As Decimal
        If Not Decimal.TryParse(txtFeesPaid.Text, feesPaid) OrElse feesPaid < 0 OrElse feesPaid > courseFees Then
            MessageBox.Show("Fees Paid must be a valid amount between 0 and the total course fees.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Calculate Fees Remaining
        Dim feesRemaining As Decimal = courseFees - feesPaid
        txtFeesRemaining.Text = feesRemaining.ToString("F2")

        ' Course Date Validation
        If DateTimePickerCoursestart.Value >= DateTimePickerCourseend.Value Then
            MessageBox.Show("Course Start Date must be before the End Date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' If all validations pass, proceed to save the data
        Try
            ConnectDB()
            Dim query As String = "INSERT INTO StudentDetails (ApplicationNo, Name, DOB, Age, Sex, Caste, Religion, CurrentAddress, PermanentAddress, Email, Phone, FatherName, FatherJob, MotherName, MotherJob, Qualification, University, PassoutYear, Mark, Course, Batch, CourseStartDate, CourseEndDate, FeesPaid, FeesRemaining, Image) " &
                               "VALUES (@AppNo, @Name, @DOB, @Age, @Sex, @Caste, @Religion, @CAddress, @PAddress, @Email, @Phone, @FatherName, @FatherJob, @MotherName, @MotherJob, @Qualification, @University, @PassoutYear, @Mark, @Course, @Batch, @CourseStartDate, @CourseEndDate, @FeesPaid, @FeesRemaining, @Image)"

            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@AppNo", txtApplicationno.Text)
            cmd.Parameters.AddWithValue("@Name", txtName.Text)
            cmd.Parameters.AddWithValue("@DOB", dtpDOB.Value.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@Age", txtAge.Text)
            cmd.Parameters.AddWithValue("@Sex", ComSex.Text)
            cmd.Parameters.AddWithValue("@Caste", txtCaste.Text)
            cmd.Parameters.AddWithValue("@Religion", txtReligion.Text)
            cmd.Parameters.AddWithValue("@CAddress", txtCaddress.Text)
            cmd.Parameters.AddWithValue("@PAddress", If(CheckBox1.Checked, txtCaddress.Text, txtPaddress.Text))
            cmd.Parameters.AddWithValue("@Email", txtemail.Text)
            cmd.Parameters.AddWithValue("@Phone", txtphone.Text)
            cmd.Parameters.AddWithValue("@FatherName", txtfathername.Text)
            cmd.Parameters.AddWithValue("@FatherJob", txtfatherjob.Text)
            cmd.Parameters.AddWithValue("@MotherName", txtmothername.Text)
            cmd.Parameters.AddWithValue("@MotherJob", txtmotherjob.Text)
            cmd.Parameters.AddWithValue("@Qualification", txtqual.Text)
            cmd.Parameters.AddWithValue("@University", txtqualuniv.Text)
            cmd.Parameters.AddWithValue("@PassoutYear", txtqualyear.Text)
            cmd.Parameters.AddWithValue("@Mark", txtmark.Text)
            cmd.Parameters.AddWithValue("@Course", cmbcourse.Text)
            cmd.Parameters.AddWithValue("@Batch", ComboBoxBatch.Text)
            cmd.Parameters.AddWithValue("@CourseStartDate", DateTimePickerCoursestart.Value)
            cmd.Parameters.AddWithValue("@CourseEndDate", DateTimePickerCourseend.Value)
            cmd.Parameters.AddWithValue("@FeesPaid", feesPaid)
            cmd.Parameters.AddWithValue("@FeesRemaining", feesRemaining)
            ' Convert image to byte array
            Dim ms As New MemoryStream()
            If PictureBox1.Image IsNot Nothing Then
                PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
                cmd.Parameters.AddWithValue("@Image", ms.ToArray())
            Else
                cmd.Parameters.AddWithValue("@Image", DBNull.Value)
            End If
            cmd.ExecuteNonQuery()
            ClearForm()
            MessageBox.Show("Data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseDB()
        End Try
    End Sub
    Private Sub ClearForm()
        ' Clear all textboxes
        txtApplicationno.Clear()
        txtName.Clear()
        txtCaste.Clear()
        txtReligion.Clear()
        txtCaddress.Clear()
        txtPaddress.Clear()
        txtemail.Clear()
        txtphone.Clear()
        txtfathername.Clear()
        txtfatherjob.Clear()
        txtmothername.Clear()
        txtmotherjob.Clear()
        txtqual.Clear()
        txtqualuniv.Clear()
        txtqualyear.Clear()
        txtmark.Clear()
        txtFeesPaid.Clear()
        txtFeesRemaining.Clear()

        ' Reset dropdowns and combo boxes
        ComSex.SelectedIndex = -1
        cmbcourse.SelectedIndex = -1
        ComboBoxBatch.SelectedIndex = -1

        ' Reset date pickers
        dtpDOB.Value = Date.Today
        DateTimePickerCoursestart.Value = Date.Today
        DateTimePickerCourseend.Value = Date.Today

        ' Reset checkboxes
        CheckBox1.Checked = False

        ' Reset ImageBox (if applicable)
        PictureBox1.Image = Nothing

        ' Reset age field
        txtAge.Clear()
    End Sub
    Private Sub BtnClear_Click(sender As Object, e As EventArgs)
        ClearForm()
        MessageBox.Show("All fields have been cleared.", "Reset", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        ' Open File Dialog for selecting an image
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Display the selected image in PictureBox
            PictureBox1.Image = Image.FromFile(openFileDialog.FileName)
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        End If
    End Sub
End Class
