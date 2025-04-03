<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewAttendanceForm
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CmbBatch = New System.Windows.Forms.ComboBox()
        Me.CmbCourse = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DtpFromDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DtpToDate = New System.Windows.Forms.DateTimePicker()
        Me.DgvAttendance = New System.Windows.Forms.DataGridView()
        Me.btnLoadAttendance = New System.Windows.Forms.Button()
        Me.CmbSubject = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.DgvAttendance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 55)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 24)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Batch"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(11, 18)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 24)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Course"
        '
        'CmbBatch
        '
        Me.CmbBatch.FormattingEnabled = True
        Me.CmbBatch.Location = New System.Drawing.Point(116, 55)
        Me.CmbBatch.Name = "CmbBatch"
        Me.CmbBatch.Size = New System.Drawing.Size(121, 21)
        Me.CmbBatch.TabIndex = 3
        '
        'CmbCourse
        '
        Me.CmbCourse.FormattingEnabled = True
        Me.CmbCourse.Location = New System.Drawing.Point(116, 18)
        Me.CmbCourse.Name = "CmbCourse"
        Me.CmbCourse.Size = New System.Drawing.Size(121, 21)
        Me.CmbCourse.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 100)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 24)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Start date"
        '
        'DtpFromDate
        '
        Me.DtpFromDate.Location = New System.Drawing.Point(116, 100)
        Me.DtpFromDate.Name = "DtpFromDate"
        Me.DtpFromDate.Size = New System.Drawing.Size(200, 20)
        Me.DtpFromDate.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(334, 100)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 24)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "End date"
        '
        'DtpToDate
        '
        Me.DtpToDate.Location = New System.Drawing.Point(439, 100)
        Me.DtpToDate.Name = "DtpToDate"
        Me.DtpToDate.Size = New System.Drawing.Size(200, 20)
        Me.DtpToDate.TabIndex = 7
        '
        'DgvAttendance
        '
        Me.DgvAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvAttendance.Location = New System.Drawing.Point(15, 158)
        Me.DgvAttendance.Name = "DgvAttendance"
        Me.DgvAttendance.Size = New System.Drawing.Size(766, 280)
        Me.DgvAttendance.TabIndex = 8
        '
        'btnLoadAttendance
        '
        Me.btnLoadAttendance.Location = New System.Drawing.Point(677, 97)
        Me.btnLoadAttendance.Name = "btnLoadAttendance"
        Me.btnLoadAttendance.Size = New System.Drawing.Size(75, 23)
        Me.btnLoadAttendance.TabIndex = 9
        Me.btnLoadAttendance.Text = "View"
        Me.btnLoadAttendance.UseVisualStyleBackColor = True
        '
        'CmbSubject
        '
        Me.CmbSubject.FormattingEnabled = True
        Me.CmbSubject.Location = New System.Drawing.Point(400, 21)
        Me.CmbSubject.Name = "CmbSubject"
        Me.CmbSubject.Size = New System.Drawing.Size(134, 21)
        Me.CmbSubject.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(297, 18)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 24)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Subject"
        '
        'ViewAttendanceForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.CmbSubject)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnLoadAttendance)
        Me.Controls.Add(Me.DgvAttendance)
        Me.Controls.Add(Me.DtpToDate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DtpFromDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CmbBatch)
        Me.Controls.Add(Me.CmbCourse)
        Me.Name = "ViewAttendanceForm"
        Me.Text = "ViewAttendanceForm"
        CType(Me.DgvAttendance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents CmbBatch As ComboBox
    Friend WithEvents CmbCourse As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents DtpFromDate As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents DtpToDate As DateTimePicker
    Friend WithEvents DgvAttendance As DataGridView
    Friend WithEvents btnLoadAttendance As Button
    Friend WithEvents CmbSubject As ComboBox
    Friend WithEvents Label5 As Label
End Class
