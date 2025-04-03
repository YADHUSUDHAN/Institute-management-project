<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class facultyregistration
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtEmpid = New System.Windows.Forms.TextBox()
        Me.TxtEmpname = New System.Windows.Forms.TextBox()
        Me.TxtEmpPh = New System.Windows.Forms.TextBox()
        Me.DtpEmpDOB = New System.Windows.Forms.DateTimePicker()
        Me.CmbEmpDept = New System.Windows.Forms.ComboBox()
        Me.BtnClr = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.ChkListEmpSub = New System.Windows.Forms.CheckedListBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(40, 132)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Employee ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(40, 179)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(40, 228)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(129, 25)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Date of birth"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(40, 267)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(152, 25)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Phone number"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(40, 321)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 25)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Department"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(40, 364)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 25)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Subjects"
        '
        'TxtEmpid
        '
        Me.TxtEmpid.Location = New System.Drawing.Point(278, 137)
        Me.TxtEmpid.Name = "TxtEmpid"
        Me.TxtEmpid.Size = New System.Drawing.Size(302, 20)
        Me.TxtEmpid.TabIndex = 2
        '
        'TxtEmpname
        '
        Me.TxtEmpname.Location = New System.Drawing.Point(278, 184)
        Me.TxtEmpname.Name = "TxtEmpname"
        Me.TxtEmpname.Size = New System.Drawing.Size(302, 20)
        Me.TxtEmpname.TabIndex = 2
        '
        'TxtEmpPh
        '
        Me.TxtEmpPh.Location = New System.Drawing.Point(278, 273)
        Me.TxtEmpPh.Name = "TxtEmpPh"
        Me.TxtEmpPh.Size = New System.Drawing.Size(302, 20)
        Me.TxtEmpPh.TabIndex = 2
        '
        'DtpEmpDOB
        '
        Me.DtpEmpDOB.Location = New System.Drawing.Point(278, 233)
        Me.DtpEmpDOB.Name = "DtpEmpDOB"
        Me.DtpEmpDOB.Size = New System.Drawing.Size(302, 20)
        Me.DtpEmpDOB.TabIndex = 3
        '
        'CmbEmpDept
        '
        Me.CmbEmpDept.FormattingEnabled = True
        Me.CmbEmpDept.Location = New System.Drawing.Point(278, 321)
        Me.CmbEmpDept.Name = "CmbEmpDept"
        Me.CmbEmpDept.Size = New System.Drawing.Size(302, 21)
        Me.CmbEmpDept.TabIndex = 4
        '
        'BtnClr
        '
        Me.BtnClr.Location = New System.Drawing.Point(582, 424)
        Me.BtnClr.Name = "BtnClr"
        Me.BtnClr.Size = New System.Drawing.Size(75, 23)
        Me.BtnClr.TabIndex = 5
        Me.BtnClr.Text = "clear"
        Me.BtnClr.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(682, 424)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 5
        Me.BtnSave.Text = "save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(656, 85)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(101, 97)
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(37, 59)
        Me.Label23.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(512, 44)
        Me.Label23.TabIndex = 8
        Me.Label23.Text = "FACULTY REGISTRATION "
        '
        'ChkListEmpSub
        '
        Me.ChkListEmpSub.FormattingEnabled = True
        Me.ChkListEmpSub.Location = New System.Drawing.Point(278, 364)
        Me.ChkListEmpSub.Name = "ChkListEmpSub"
        Me.ChkListEmpSub.Size = New System.Drawing.Size(256, 79)
        Me.ChkListEmpSub.TabIndex = 9
        '
        'facultyregistration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSkyBlue
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ChkListEmpSub)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnClr)
        Me.Controls.Add(Me.CmbEmpDept)
        Me.Controls.Add(Me.DtpEmpDOB)
        Me.Controls.Add(Me.TxtEmpPh)
        Me.Controls.Add(Me.TxtEmpname)
        Me.Controls.Add(Me.TxtEmpid)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "facultyregistration"
        Me.Text = "Faculty registration"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtEmpid As TextBox
    Friend WithEvents TxtEmpname As TextBox
    Friend WithEvents TxtEmpPh As TextBox
    Friend WithEvents DtpEmpDOB As DateTimePicker
    Friend WithEvents CmbEmpDept As ComboBox
    Friend WithEvents BtnClr As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label23 As Label
    Friend WithEvents ChkListEmpSub As CheckedListBox
End Class
