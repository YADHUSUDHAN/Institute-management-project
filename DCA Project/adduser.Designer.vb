<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class addUser
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
        Me.BtnCreate = New System.Windows.Forms.Button()
        Me.CmbUsrType = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtUsrname = New System.Windows.Forms.TextBox()
        Me.TxtPass = New System.Windows.Forms.TextBox()
        Me.TxtCnfmPass = New System.Windows.Forms.TextBox()
        Me.CheckBoxShowpassword = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(47, 103)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 25)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "User Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(47, 141)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Password"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(47, 244)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 25)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "User type"
        '
        'BtnCreate
        '
        Me.BtnCreate.Location = New System.Drawing.Point(415, 304)
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.Size = New System.Drawing.Size(115, 31)
        Me.BtnCreate.TabIndex = 3
        Me.BtnCreate.Text = "Create"
        Me.BtnCreate.UseVisualStyleBackColor = True
        '
        'CmbUsrType
        '
        Me.CmbUsrType.FormattingEnabled = True
        Me.CmbUsrType.Items.AddRange(New Object() {"Admin", "Faculty"})
        Me.CmbUsrType.Location = New System.Drawing.Point(284, 250)
        Me.CmbUsrType.Name = "CmbUsrType"
        Me.CmbUsrType.Size = New System.Drawing.Size(246, 21)
        Me.CmbUsrType.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(47, 195)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(186, 25)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Confirm Password"
        '
        'TxtUsrname
        '
        Me.TxtUsrname.Location = New System.Drawing.Point(284, 108)
        Me.TxtUsrname.Name = "TxtUsrname"
        Me.TxtUsrname.Size = New System.Drawing.Size(246, 20)
        Me.TxtUsrname.TabIndex = 5
        '
        'TxtPass
        '
        Me.TxtPass.Location = New System.Drawing.Point(284, 141)
        Me.TxtPass.Name = "TxtPass"
        Me.TxtPass.Size = New System.Drawing.Size(246, 20)
        Me.TxtPass.TabIndex = 5
        '
        'TxtCnfmPass
        '
        Me.TxtCnfmPass.Location = New System.Drawing.Point(284, 200)
        Me.TxtCnfmPass.Name = "TxtCnfmPass"
        Me.TxtCnfmPass.Size = New System.Drawing.Size(246, 20)
        Me.TxtCnfmPass.TabIndex = 5
        '
        'CheckBoxShowpassword
        '
        Me.CheckBoxShowpassword.AutoSize = True
        Me.CheckBoxShowpassword.Location = New System.Drawing.Point(284, 230)
        Me.CheckBoxShowpassword.Name = "CheckBoxShowpassword"
        Me.CheckBoxShowpassword.Size = New System.Drawing.Size(102, 17)
        Me.CheckBoxShowpassword.TabIndex = 6
        Me.CheckBoxShowpassword.Text = "Show Password"
        Me.CheckBoxShowpassword.UseVisualStyleBackColor = True
        '
        'addUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSkyBlue
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.CheckBoxShowpassword)
        Me.Controls.Add(Me.TxtCnfmPass)
        Me.Controls.Add(Me.TxtPass)
        Me.Controls.Add(Me.TxtUsrname)
        Me.Controls.Add(Me.CmbUsrType)
        Me.Controls.Add(Me.BtnCreate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "addUser"
        Me.ShowIcon = False
        Me.Text = "Add User"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents BtnCreate As Button
    Friend WithEvents CmbUsrType As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtUsrname As TextBox
    Friend WithEvents TxtPass As TextBox
    Friend WithEvents TxtCnfmPass As TextBox
    Friend WithEvents CheckBoxShowpassword As CheckBox
End Class
