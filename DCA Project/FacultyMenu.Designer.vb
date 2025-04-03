<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FacultyMenu
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnFcltyEdt = New System.Windows.Forms.Button()
        Me.btnFcltyView = New System.Windows.Forms.Button()
        Me.btnFcltyReg = New System.Windows.Forms.Button()
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
        Me.Label3.TabIndex = 5
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
        Me.Label2.TabIndex = 6
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
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Register"
        '
        'btnFcltyEdt
        '
        Me.btnFcltyEdt.BackgroundImage = Global.DCA_Project.My.Resources.Resources.edit
        Me.btnFcltyEdt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFcltyEdt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFcltyEdt.Location = New System.Drawing.Point(256, 118)
        Me.btnFcltyEdt.Margin = New System.Windows.Forms.Padding(2)
        Me.btnFcltyEdt.Name = "btnFcltyEdt"
        Me.btnFcltyEdt.Size = New System.Drawing.Size(95, 66)
        Me.btnFcltyEdt.TabIndex = 2
        Me.btnFcltyEdt.UseVisualStyleBackColor = True
        '
        'btnFcltyView
        '
        Me.btnFcltyView.BackgroundImage = Global.DCA_Project.My.Resources.Resources.file
        Me.btnFcltyView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFcltyView.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFcltyView.Location = New System.Drawing.Point(133, 118)
        Me.btnFcltyView.Margin = New System.Windows.Forms.Padding(2)
        Me.btnFcltyView.Name = "btnFcltyView"
        Me.btnFcltyView.Size = New System.Drawing.Size(95, 66)
        Me.btnFcltyView.TabIndex = 3
        Me.btnFcltyView.UseVisualStyleBackColor = True
        '
        'btnFcltyReg
        '
        Me.btnFcltyReg.BackgroundImage = Global.DCA_Project.My.Resources.Resources.register
        Me.btnFcltyReg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFcltyReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFcltyReg.Location = New System.Drawing.Point(10, 118)
        Me.btnFcltyReg.Margin = New System.Windows.Forms.Padding(2)
        Me.btnFcltyReg.Name = "btnFcltyReg"
        Me.btnFcltyReg.Size = New System.Drawing.Size(95, 66)
        Me.btnFcltyReg.TabIndex = 4
        Me.btnFcltyReg.UseVisualStyleBackColor = True
        '
        'FacultyMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.DCA_Project.My.Resources.Resources.Sm1
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(797, 415)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnFcltyEdt)
        Me.Controls.Add(Me.btnFcltyView)
        Me.Controls.Add(Me.btnFcltyReg)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FacultyMenu"
        Me.Text = "FacultyMenu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnFcltyReg As Button
    Friend WithEvents btnFcltyView As Button
    Friend WithEvents btnFcltyEdt As Button
End Class
