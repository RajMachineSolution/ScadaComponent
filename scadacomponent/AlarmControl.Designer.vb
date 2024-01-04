<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AlarmControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateTimePicker4 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Pushbutton3 = New scadacomponent.pushbutton()
        Me.Pushbutton2 = New scadacomponent.pushbutton()
        Me.Pushbutton1 = New scadacomponent.pushbutton()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.AllowUserToResizeColumns = False
        Me.dgv1.AllowUserToResizeRows = False
        Me.dgv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.dgv1.Location = New System.Drawing.Point(0, 117)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.RowHeadersVisible = False
        Me.dgv1.Size = New System.Drawing.Size(617, 283)
        Me.dgv1.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "Acknowledged"
        Me.Column1.Image = Global.scadacomponent.My.Resources.Resources.notAcknowledged
        Me.Column1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch
        Me.Column1.Name = "Column1"
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column1.Width = 40
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(226, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 27)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "ALARM REPORT"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(497, 83)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(115, 29)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Search"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TextBox1.Location = New System.Drawing.Point(149, 86)
        Me.TextBox1.MaxLength = 7
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 18
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintDocument1
        '
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(76, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 17)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Batch No."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(345, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 17)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "To"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(55, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 17)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "From"
        '
        'DateTimePicker4
        '
        Me.DateTimePicker4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker4.Location = New System.Drawing.Point(508, 41)
        Me.DateTimePicker4.Name = "DateTimePicker4"
        Me.DateTimePicker4.Size = New System.Drawing.Size(105, 26)
        Me.DateTimePicker4.TabIndex = 25
        '
        'DateTimePicker3
        '
        Me.DateTimePicker3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker3.Location = New System.Drawing.Point(233, 41)
        Me.DateTimePicker3.Name = "DateTimePicker3"
        Me.DateTimePicker3.Size = New System.Drawing.Size(105, 26)
        Me.DateTimePicker3.TabIndex = 24
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker2.Location = New System.Drawing.Point(371, 41)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(135, 26)
        Me.DateTimePicker2.TabIndex = 23
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(96, 41)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(135, 26)
        Me.DateTimePicker1.TabIndex = 22
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.HeaderText = "Acknowledged"
        Me.DataGridViewImageColumn1.Image = Global.scadacomponent.My.Resources.Resources.notAcknowledged
        Me.DataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.Width = 80
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.scadacomponent.My.Resources.Resources.box1
        Me.PictureBox1.Location = New System.Drawing.Point(10, 42)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(39, 24)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 28
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.scadacomponent.My.Resources.Resources.box1
        Me.PictureBox2.Location = New System.Drawing.Point(10, 78)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(39, 24)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 29
        Me.PictureBox2.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(289, 86)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 17)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Lot No."
        '
        'TextBox2
        '
        Me.TextBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TextBox2.Location = New System.Drawing.Point(349, 85)
        Me.TextBox2.MaxLength = 2
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 32
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(188, 412)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(0, 15)
        Me.Label6.TabIndex = 43
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button3.Location = New System.Drawing.Point(96, 406)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 25)
        Me.Button3.TabIndex = 42
        Me.Button3.Text = "Next >>"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(15, 406)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 25)
        Me.Button2.TabIndex = 41
        Me.Button2.Text = "<< Previous"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Pushbutton3
        '
        Me.Pushbutton3._Readonly = False
        Me.Pushbutton3._RecordEvent = scadacomponent.pushbutton.Record_Event.NO
        Me.Pushbutton3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pushbutton3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pushbutton3.ButtonOffBackcolor = System.Drawing.Color.Transparent
        Me.Pushbutton3.ButtonOFFImage = Global.scadacomponent.My.Resources.Resources.page_setup
        Me.Pushbutton3.ButtonOffText = ""
        Me.Pushbutton3.ButtonONBackcolor = System.Drawing.Color.Transparent
        Me.Pushbutton3.ButtonONImage = Global.scadacomponent.My.Resources.Resources.page_setup
        Me.Pushbutton3.ButtonOnText = ""
        Me.Pushbutton3.ButtonText = ""
        Me.Pushbutton3.Buttontype = scadacomponent.pushbutton.Button_type._Set
        Me.Pushbutton3.ButtonTypeRecordMessage = ""
        Me.Pushbutton3.buttonvalue = False
        Me.Pushbutton3.database = ""
        Me.Pushbutton3.Direct = False
        Me.Pushbutton3.Imageoff = Nothing
        Me.Pushbutton3.Imageon = Nothing
        Me.Pushbutton3.INDirect = False
        Me.Pushbutton3.Location = New System.Drawing.Point(571, 2)
        Me.Pushbutton3.Name = "Pushbutton3"
        Me.Pushbutton3.Read_TagName = "default#0"
        Me.Pushbutton3.ReadAddress = 500
        Me.Pushbutton3.readwrite = False
        Me.Pushbutton3.RecordActionMessage = Nothing
        Me.Pushbutton3.RecordMessage = "Press"
        Me.Pushbutton3.Size = New System.Drawing.Size(34, 31)
        Me.Pushbutton3.TabIndex = 37
        Me.Pushbutton3.TextBackcolor = System.Drawing.Color.Empty
        Me.Pushbutton3.ToggleReSetRecordMessage = ""
        Me.Pushbutton3.ToggleSetRecordMessage = ""
        Me.Pushbutton3.Visible = False
        Me.Pushbutton3.Visible_Tag = ""
        Me.Pushbutton3.Write_TagName = "default#0"
        Me.Pushbutton3.WriteAddress = 500
        '
        'Pushbutton2
        '
        Me.Pushbutton2._Readonly = False
        Me.Pushbutton2._RecordEvent = scadacomponent.pushbutton.Record_Event.NO
        Me.Pushbutton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pushbutton2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pushbutton2.ButtonOffBackcolor = System.Drawing.Color.Transparent
        Me.Pushbutton2.ButtonOFFImage = Global.scadacomponent.My.Resources.Resources.print_preview
        Me.Pushbutton2.ButtonOffText = ""
        Me.Pushbutton2.ButtonONBackcolor = System.Drawing.Color.Transparent
        Me.Pushbutton2.ButtonONImage = Global.scadacomponent.My.Resources.Resources.print_preview
        Me.Pushbutton2.ButtonOnText = ""
        Me.Pushbutton2.ButtonText = ""
        Me.Pushbutton2.Buttontype = scadacomponent.pushbutton.Button_type._Set
        Me.Pushbutton2.ButtonTypeRecordMessage = ""
        Me.Pushbutton2.buttonvalue = False
        Me.Pushbutton2.database = ""
        Me.Pushbutton2.Direct = False
        Me.Pushbutton2.Imageoff = Nothing
        Me.Pushbutton2.Imageon = Nothing
        Me.Pushbutton2.INDirect = False
        Me.Pushbutton2.Location = New System.Drawing.Point(531, 3)
        Me.Pushbutton2.Name = "Pushbutton2"
        Me.Pushbutton2.Read_TagName = "default#0"
        Me.Pushbutton2.ReadAddress = 500
        Me.Pushbutton2.readwrite = False
        Me.Pushbutton2.RecordActionMessage = Nothing
        Me.Pushbutton2.RecordMessage = "Alarm List Preview"
        Me.Pushbutton2.Size = New System.Drawing.Size(34, 31)
        Me.Pushbutton2.TabIndex = 36
        Me.Pushbutton2.TextBackcolor = System.Drawing.Color.Empty
        Me.Pushbutton2.ToggleReSetRecordMessage = ""
        Me.Pushbutton2.ToggleSetRecordMessage = ""
        Me.Pushbutton2.Visible = False
        Me.Pushbutton2.Visible_Tag = ""
        Me.Pushbutton2.Write_TagName = "default#0"
        Me.Pushbutton2.WriteAddress = 500
        '
        'Pushbutton1
        '
        Me.Pushbutton1._Readonly = False
        Me.Pushbutton1._RecordEvent = scadacomponent.pushbutton.Record_Event.NO
        Me.Pushbutton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pushbutton1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pushbutton1.ButtonOffBackcolor = System.Drawing.Color.Transparent
        Me.Pushbutton1.ButtonOFFImage = Global.scadacomponent.My.Resources.Resources.print_icon
        Me.Pushbutton1.ButtonOffText = ""
        Me.Pushbutton1.ButtonONBackcolor = System.Drawing.Color.Transparent
        Me.Pushbutton1.ButtonONImage = Global.scadacomponent.My.Resources.Resources.print_icon
        Me.Pushbutton1.ButtonOnText = ""
        Me.Pushbutton1.ButtonText = ""
        Me.Pushbutton1.Buttontype = scadacomponent.pushbutton.Button_type._Set
        Me.Pushbutton1.ButtonTypeRecordMessage = ""
        Me.Pushbutton1.buttonvalue = False
        Me.Pushbutton1.database = ""
        Me.Pushbutton1.Direct = False
        Me.Pushbutton1.Imageoff = Nothing
        Me.Pushbutton1.Imageon = Nothing
        Me.Pushbutton1.INDirect = False
        Me.Pushbutton1.Location = New System.Drawing.Point(491, 2)
        Me.Pushbutton1.Name = "Pushbutton1"
        Me.Pushbutton1.Read_TagName = "default#0"
        Me.Pushbutton1.ReadAddress = 500
        Me.Pushbutton1.readwrite = False
        Me.Pushbutton1.RecordActionMessage = Nothing
        Me.Pushbutton1.RecordMessage = "Audit List Print"
        Me.Pushbutton1.Size = New System.Drawing.Size(34, 31)
        Me.Pushbutton1.TabIndex = 35
        Me.Pushbutton1.TextBackcolor = System.Drawing.Color.Empty
        Me.Pushbutton1.ToggleReSetRecordMessage = ""
        Me.Pushbutton1.ToggleSetRecordMessage = ""
        Me.Pushbutton1.Visible = False
        Me.Pushbutton1.Visible_Tag = ""
        Me.Pushbutton1.Write_TagName = "default#0"
        Me.Pushbutton1.WriteAddress = 500
        '
        'AlarmControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Pushbutton3)
        Me.Controls.Add(Me.Pushbutton2)
        Me.Controls.Add(Me.Pushbutton1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DateTimePicker4)
        Me.Controls.Add(Me.DateTimePicker3)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgv1)
        Me.Name = "AlarmControl"
        Me.Size = New System.Drawing.Size(620, 439)
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker4 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Pushbutton3 As scadacomponent.pushbutton
    Friend WithEvents Pushbutton2 As scadacomponent.pushbutton
    Friend WithEvents Pushbutton1 As scadacomponent.pushbutton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button

End Class
