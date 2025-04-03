<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AttendanceForm
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
        Me.CmbCourse = New System.Windows.Forms.ComboBox()
        Me.CmbBatch = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DgvStudents = New System.Windows.Forms.DataGridView()
        Me.btnSaveAttendance = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CmbSubject = New System.Windows.Forms.ComboBox()
        Me.CmbDate = New System.Windows.Forms.ComboBox()
        CType(Me.DgvStudents, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CmbCourse
        '
        Me.CmbCourse.FormattingEnabled = True
        Me.CmbCourse.Location = New System.Drawing.Point(116, 12)
        Me.CmbCourse.Name = "CmbCourse"
        Me.CmbCourse.Size = New System.Drawing.Size(121, 21)
        Me.CmbCourse.TabIndex = 0
        '
        'CmbBatch
        '
        Me.CmbBatch.FormattingEnabled = True
        Me.CmbBatch.Location = New System.Drawing.Point(116, 49)
        Me.CmbBatch.Name = "CmbBatch"
        Me.CmbBatch.Size = New System.Drawing.Size(121, 21)
        Me.CmbBatch.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(11, 12)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 24)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Course"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 49)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 24)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Batch"
        '
        'DgvStudents
        '
        Me.DgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvStudents.Location = New System.Drawing.Point(14, 99)
        Me.DgvStudents.Name = "DgvStudents"
        Me.DgvStudents.Size = New System.Drawing.Size(770, 270)
        Me.DgvStudents.TabIndex = 3
        '
        'btnSaveAttendance
        '
        Me.btnSaveAttendance.Location = New System.Drawing.Point(636, 375)
        Me.btnSaveAttendance.Name = "btnSaveAttendance"
        Me.btnSaveAttendance.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveAttendance.TabIndex = 4
        Me.btnSaveAttendance.Text = "save"
        Me.btnSaveAttendance.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(279, 12)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 24)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(279, 46)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 24)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Subject"
        '
        'CmbSubject
        '
        Me.CmbSubject.FormattingEnabled = True
        Me.CmbSubject.Location = New System.Drawing.Point(382, 49)
        Me.CmbSubject.Name = "CmbSubject"
        Me.CmbSubject.Size = New System.Drawing.Size(134, 21)
        Me.CmbSubject.TabIndex = 5
        '
        'CmbDate
        '
        Me.CmbDate.FormattingEnabled = True
        Me.CmbDate.Location = New System.Drawing.Point(382, 12)
        Me.CmbDate.Name = "CmbDate"
        Me.CmbDate.Size = New System.Drawing.Size(134, 21)
        Me.CmbDate.TabIndex = 5
        '
        'AttendanceForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSkyBlue
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.CmbDate)
        Me.Controls.Add(Me.CmbSubject)
        Me.Controls.Add(Me.btnSaveAttendance)
        Me.Controls.Add(Me.DgvStudents)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CmbBatch)
        Me.Controls.Add(Me.CmbCourse)
        Me.Name = "AttendanceForm"
        Me.Text = "AttendanceForm"
        CType(Me.DgvStudents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CmbCourse As ComboBox
    Friend WithEvents CmbBatch As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents DgvStudents As DataGridView
    Friend WithEvents btnSaveAttendance As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents CmbSubject As ComboBox
    Friend WithEvents CmbDate As ComboBox
End Class
