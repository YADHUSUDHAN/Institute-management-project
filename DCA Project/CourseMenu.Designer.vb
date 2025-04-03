<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CourseMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCrsEdt = New System.Windows.Forms.Button()
        Me.btnCrsView = New System.Windows.Forms.Button()
        Me.btnCrsReg = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(278, 186)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 24)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Edit"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(151, 186)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 24)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "View"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 186)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 24)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Register"
        '
        'btnCrsEdt
        '
        Me.btnCrsEdt.BackgroundImage = Global.DCA_Project.My.Resources.Resources.edit
        Me.btnCrsEdt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCrsEdt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCrsEdt.Location = New System.Drawing.Point(257, 118)
        Me.btnCrsEdt.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCrsEdt.Name = "btnCrsEdt"
        Me.btnCrsEdt.Size = New System.Drawing.Size(95, 66)
        Me.btnCrsEdt.TabIndex = 8
        Me.btnCrsEdt.UseVisualStyleBackColor = True
        '
        'btnCrsView
        '
        Me.btnCrsView.BackgroundImage = Global.DCA_Project.My.Resources.Resources.file
        Me.btnCrsView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCrsView.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCrsView.Location = New System.Drawing.Point(132, 118)
        Me.btnCrsView.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCrsView.Name = "btnCrsView"
        Me.btnCrsView.Size = New System.Drawing.Size(95, 66)
        Me.btnCrsView.TabIndex = 9
        Me.btnCrsView.UseVisualStyleBackColor = True
        '
        'btnCrsReg
        '
        Me.btnCrsReg.BackgroundImage = Global.DCA_Project.My.Resources.Resources.register
        Me.btnCrsReg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCrsReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCrsReg.Location = New System.Drawing.Point(10, 118)
        Me.btnCrsReg.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCrsReg.Name = "btnCrsReg"
        Me.btnCrsReg.Size = New System.Drawing.Size(95, 66)
        Me.btnCrsReg.TabIndex = 10
        Me.btnCrsReg.UseVisualStyleBackColor = True
        '
        'CourseMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.DCA_Project.My.Resources.Resources.Sm1
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(797, 415)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCrsEdt)
        Me.Controls.Add(Me.btnCrsView)
        Me.Controls.Add(Me.btnCrsReg)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "CourseMenu"
        Me.Text = "Course Menu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnCrsEdt As Button
    Friend WithEvents btnCrsView As Button
    Friend WithEvents btnCrsReg As Button
End Class
