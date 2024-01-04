<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class registerdetails
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
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.detailsgrid = New System.Windows.Forms.DataGridView()
        Me.Panel7.SuspendLayout()
        CType(Me.detailsgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.LightSeaGreen
        Me.Button4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(508, 53)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(110, 36)
        Me.Button4.TabIndex = 13
        Me.Button4.Text = "Refresh"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.MediumAquamarine
        Me.Panel7.Controls.Add(Me.Label30)
        Me.Panel7.Location = New System.Drawing.Point(27, 11)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(466, 30)
        Me.Panel7.TabIndex = 12
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Transparent
        Me.Label30.Location = New System.Drawing.Point(152, 3)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(157, 23)
        Me.Label30.TabIndex = 7
        Me.Label30.Text = "Registered Details"
        '
        'detailsgrid
        '
        Me.detailsgrid.AllowUserToAddRows = False
        Me.detailsgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.detailsgrid.Location = New System.Drawing.Point(27, 40)
        Me.detailsgrid.Name = "detailsgrid"
        Me.detailsgrid.ReadOnly = True
        Me.detailsgrid.Size = New System.Drawing.Size(466, 286)
        Me.detailsgrid.TabIndex = 11
        '
        'registerdetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(631, 345)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.detailsgrid)
        Me.Name = "registerdetails"
        Me.Text = "registerdetails"
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        CType(Me.detailsgrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents detailsgrid As System.Windows.Forms.DataGridView
End Class
