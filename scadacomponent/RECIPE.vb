Imports System.Drawing.Design
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms.Design
Imports System.Reflection
Imports System.Drawing
Imports System.Windows.Forms

Public Class RECIPE
    Dim initialised As Boolean = False
    Dim row As Integer
    Dim s3 As New List(Of addcolumn)
    Dim ddown As New List(Of dropdown)
    Dim row_hlt As Integer
    Public namearray() As String
    ' Friend highlight_row As Integer

    <Browsable(True), _
EditorBrowsable(EditorBrowsableState.Always), _
Category("Z"), _
Description("The items with sub items that should be displayed"), _
DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Property addDropDownValues As List(Of dropdown)
        Get
            Return ddown

        End Get
        Set(ByVal value As List(Of dropdown))
            ddown = value
        End Set
    End Property

    Property RowsCount As Integer
        Get
            Return row
        End Get
        Set(ByVal value As Integer)
            row = value
            Try
                generaterows(row)

                If row > 1 And row_hlt > 0 Then
                    If Me.Rows.Count = 0 Then
                        generaterows(row)
                    End If
                    For i = 0 To RowsCount - 1
                        Me.Rows(i).DefaultCellStyle.BackColor = Color.White
                    Next
                    Me.Rows(row_hlt - 1).DefaultCellStyle.BackColor = hlt_color

                End If
            Catch ex As Exception
            End Try
        End Set
    End Property

    Sub initialisearrays()
        If Me.RowsCount > 1 Then
            ReDim Me.namearray(Me.RowsCount - 1)
            ReDim Me.writearray(Me.Columns.Count - 1, Me.RowsCount - 1)
            ReDim Me.readarray(Me.Columns.Count - 1, Me.RowsCount - 1)
            initialised = True
        End If
    End Sub

    Property highlight_row As Integer
        Get
            If Me.RowsCount > 1 And row_hlt > 0 Then

                '      Me.Rows(row_hlt - 1).DefaultCellStyle.BackColor = hlt_color
            End If
            Return row_hlt
        End Get
        Set(ByVal value As Integer)
            ' If value = Nothing Then
            ' Else
            row_hlt = value
            If row > 1 And row_hlt > 0 Then
                Try
                    If Me.Rows.Count = 0 Then
                        'generaterows(row)
                    Else
                        For i = 0 To RowsCount - 1
                            Me.Rows(i).DefaultCellStyle.BackColor = Color.White
                        Next
                        Me.Rows(row_hlt - 1).DefaultCellStyle.BackColor = hlt_color
                    End If
                Catch ex As Exception
                End Try
            End If

        End Set
    End Property
    Dim hlt_color As Color = Color.Yellow
    Property highlight_color As Color
        Get
            Return hlt_color
        End Get
        Set(ByVal value As Color)
            hlt_color = value
        End Set
    End Property

    Dim plcregister As String
    Property PLC_register As String
        Get
            Return plcregister
        End Get
        Set(ByVal value As String)
            plcregister = value
        End Set

    End Property
    Dim namecolumn As String
    Property name_column As String
        Get
            Return namecolumn
        End Get
        Set(ByVal value As String)
            namecolumn = value
        End Set
    End Property
    Public readarray(,) As String

    Property READ_array As String(,)
        Get
            Return readarray
        End Get
        Set(ByVal value As String(,))
            readarray = value
        End Set
    End Property

    Public writearray(,) As String
    Property Write_array As String(,)
        Get
            Return writearray
        End Get
        Set(ByVal value As String(,))
            writearray = value
        End Set
    End Property

    Dim product__name As String
    Property Product_name As String
        Get
            Return product__name
        End Get
        Set(ByVal value As String)
            product__name = value
        End Set
    End Property

    Dim productcode As String
    Property Product_code As String
        Get
            Return productcode
        End Get
        Set(ByVal value As String)
            productcode = value
        End Set
    End Property
    Dim batchname As String
    Property batch_name As String
        Get
            Return batchname
        End Get
        Set(ByVal value As String)
            batchname = value
        End Set
    End Property
    Dim lotno As String
    Property lot_no As String
        Get
            Return lotno
        End Get
        Set(ByVal value As String)
            lotno = value
        End Set
    End Property



    <Browsable(True), _
  EditorBrowsable(EditorBrowsableState.Always), _
  Category("Z"), _
  Description("The items with sub items that should be displayed"), _
  DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Property ImageColumn As List(Of addcolumn)
        Get
            Return s3
        End Get
        Set(ByVal value As List(Of addcolumn))
            s3 = value
        End Set
    End Property



    Dim a As New List(Of DataGridViewColumn)
    Dim b As DataGridViewAutoSizeColumnMode
    Dim c As DataGridViewColumn

    Private Sub RECIPE_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Me.CellClick
        If e.RowIndex < 0 Then
            For Each column As DataGridViewColumn In Me.Columns
                column.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
            Exit Sub
        End If
        If e.ColumnIndex <> -1 Then


            Dim colType As Type = Me.Columns(e.ColumnIndex).GetType
            Dim value = colType.Name
            If value = "DataGridViewImageColumn" Then
                '1 is for off 2 is for ON
                Try

                    If Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag = 0 Then
                        writearray(e.ColumnIndex, e.RowIndex) = 1
                    Else
                        writearray(e.ColumnIndex, e.RowIndex) = 0
                    End If
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub

    Private Sub RECIPE_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Me.CellEndEdit
        Dim colType As Type = Me.Columns(e.ColumnIndex).GetType
        '--If colType.Name = "DataGridViewTextBoxColumn" Then

        Dim value = colType.Name
        If value = "DataGridViewTextBoxColumn" Then
            writearray(e.ColumnIndex, e.RowIndex) = Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
        End If
    End Sub
    'Property columnmode As DataGridViewAutoSizeColumnMode
    '    Get
    '        Return b
    '    End Get
    '    Set(ByVal value As DataGridViewAutoSizeColumnMode)
    '        b = value

    '    End Set
    'End Property

    Private Sub RECIPE_ControlAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles Me.ControlAdded
        Me.AllowUserToAddRows = False
        Me.AllowUserToDeleteRows = False
    End Sub

    'Dim namecolumn As DataGridViewColumn
    'Property name_column As DataGridViewColumn
    '    Get
    '        Return namecolumn
    '    End Get
    '    Set(ByVal value As DataGridViewColumn)
    '        namecolumn = value
    '    End Set
    'End Property

    Public Sub tryreadarray(ByVal t As String(,))
        readarray = t
    End Sub
    Public Sub trywitearray(ByVal t As String(,))
        writearray = t
    End Sub

    Sub adddatain_datagridview()
        For i = 0 To Me.ColumnCount - 1

            Dim colType As Type = Me.Columns(i).GetType
            '--If colType.Name = "DataGridViewTextBoxColumn" Then

            Dim value = colType.Name
            Select Case value
                Case "DataGridViewTextBoxColumn"
                    addtextbox(i)

                Case "DataGridViewImageColumn"
                    addimage(i)

                Case "DataGridViewComboBoxColumn"
                    adddropdown(i)
            End Select
        Next

    End Sub
    Sub addtextbox(ByVal i)
        For roww = 0 To Me.RowCount - 1
            Try
                Me.Rows(roww).Cells(i).Value = readarray(i, roww)
            Catch ex As Exception
            End Try

        Next

    End Sub
    Sub addimage(ByVal i)
        'Me.Columns(i).ImageLayout = DataGridViewImageCellLayout.Stretch
        For sc = 0 To s3.Count - 1
            If Me.Columns(i).HeaderText = s3(sc).colname Then

                For roww = 0 To RowCount - 1
                    'DataGridView1.Rows(row).Cells(i).Value = My.Resources.checkbox
                    If readarray(i, roww) = 0 Then
                        If Me.Rows(roww).Cells(i).tag <> 0 Or Me.Rows(roww).Cells(i).tag Is Nothing Then
                            ' Me.Rows(roww).Cells(i).Value = My.Resources.ResourceManager.GetObject(s3(sc).Setimagename1)
                            Try
                                Me.Rows(roww).Cells(i).Value = Image.FromFile(s3(sc).Setimagename1)

                                Me.Rows(roww).Cells(i).tag = 0
                            Catch ex As Exception
                            End Try
                        End If
                    End If
                    If readarray(i, roww) = 1 Then
                        If Me.Rows(roww).Cells(i).tag <> 1 Then
                            '        Me.Rows(roww).Cells(i).Value = My.Resources.ResourceManager.GetObject(s3(sc).Setimagename2)
                            Try
                                Me.Rows(roww).Cells(i).Value = Image.FromFile(s3(sc).Setimagename2)
                                ' Me.Columns(i).ImageLayout = DataGridViewImageCellLayout.Stretch
                                '  Me.ro()
                                '     Me. Me.Rows(roww).Cells(i).Imag

                                Me.Rows(roww).Cells(i).tag = 1
                            Catch ex As Exception
                            End Try
                        End If
                    End If


                Next
            End If
            'DataGridView1.Rows(row).Cells(i).Value = "sfg"
        Next
    End Sub
    Dim tempddl = 0
    Sub adddropdown(ByVal i)
        If tempddl = 0 Then
            Dim comboSource As New Dictionary(Of String, String)()
            For sc = 0 To ddown.Count - 1
                If Me.Columns(i).HeaderText = ddown(sc).ColumnName Then
                    If ddown(sc).Option1.Trim <> "" Then
                        comboSource.Add("0", ddown(sc).Option1.Trim)
                    End If
                    If ddown(sc).Option2.Trim <> "" Then
                        comboSource.Add("1", ddown(sc).Option2.Trim)
                    End If
                    If ddown(sc).Option3.Trim <> "" Then
                        comboSource.Add("2", ddown(sc).Option3.Trim)
                    End If
                    If ddown(sc).Option4.Trim <> "" Then
                        comboSource.Add("3", ddown(sc).Option4.Trim)
                    End If
                    If ddown(sc).Option5.Trim <> "" Then
                        comboSource.Add("4", ddown(sc).Option5.Trim)
                    End If
                    If ddown(sc).Option6.Trim <> "" Then
                        comboSource.Add("5", ddown(sc).Option6.Trim)

                    End If
                    If ddown(sc).Option7.Trim <> "" Then
                        comboSource.Add("6", ddown(sc).Option7.Trim)
                    End If
                    If ddown(sc).Option8.Trim <> "" Then
                        comboSource.Add("7", ddown(sc).Option8.Trim)
                    End If
                    If ddown(sc).Option9.Trim <> "" Then
                        comboSource.Add("8", ddown(sc).Option9.Trim)
                    End If
                    If ddown(sc).Option91.Trim <> "" Then
                        comboSource.Add("9", ddown(sc).Option91.Trim)
                    End If
                    'comboSource.Add("1", "Sunday")
                    'comboSource.Add("2", "Monday")
                    'comboSource.Add("3", "Tuesday")
                    'comboSource.Add("4", "Wednesday")
                    'comboSource.Add("5", "Thursday")
                    'comboSource.Add("6", "Friday")
                    'comboSource.Add("7", "Saturday")
                End If
            Next

            For roww = 0 To RowCount - 1


                Dim dgvcc As DataGridViewComboBoxCell

                dgvcc = Me.Rows(roww).Cells(i)

                dgvcc.DataSource = New BindingSource(comboSource, Nothing)
                dgvcc.DisplayMember = "Value"
                dgvcc.ValueMember = "Key"
                'dgvcc.Items.Add("comboitem1")
                'dgvcc.Items.Add("comboitem2")
                'dgvcc.Items.Add("comboitem3")
                ' Dim combo As DataGridViewComboBoxCell
                ' combo = CType(Me(i, roww), DataGridViewComboBoxCell)

                '  dgvcc.ValueMember = readarray(i, roww)
                '    DirectCast(combo.Item, KeyValuePair(Of String, String)).Key = readarray(i, roww)
                '     combo.Value = combo.Items(1)
            Next
            tempddl = 1
        End If
        For roww = 0 To Me.RowsCount - 1
            Dim dgvcc As DataGridViewComboBoxCell
            dgvcc = Me.Rows(roww).Cells(i)
            If dgvcc.Value <> readarray(i, roww) Then
                Try
                    dgvcc.Value = readarray(i, roww)
                Catch ex As Exception
                End Try
            End If
        Next
    End Sub

    Private Sub DataGridView1SelectAll_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Me.CurrentCellDirtyStateChanged


        RemoveHandler Me.CurrentCellDirtyStateChanged,
            AddressOf DataGridView1SelectAll_CurrentCellDirtyStateChanged

        If TypeOf Me.CurrentCell Is DataGridViewComboBoxCell Then
            Me.EndEdit()
            '    MsgBox(CurrentCell.Value)
            'Dim Checked As Boolean = CType(Me.CurrentCell.Value, Boolean)
            'If Checked Then
            '    '                MessageBox.Show("You have checked")
            '    Me.Rows(0).DefaultCellStyle.BackColor = Color.Yellow
            '    '  ev.insertalarmevent(Login_Register.empid, "Alarm Resolved by User", "", 0, 0, 0, 2)

            'Else
            '    Me.Rows(0).DefaultCellStyle.BackColor = Color.LightGreen

            'End If
            Try
                writearray(Me.CurrentCell.ColumnIndex, Me.CurrentCell.RowIndex) = CurrentCell.Value
            Catch ex As Exception
            End Try
        End If

        AddHandler Me.CurrentCellDirtyStateChanged,
            AddressOf DataGridView1SelectAll_CurrentCellDirtyStateChanged
    End Sub
    Sub generaterows(ByVal rows As Integer)
        If Me.Columns.Count > 0 Then
            If rows > 0 Then
                Me.RowHeadersWidth = "80"
                Me.Rows.Clear()
                Me.Rows.Add(rows)
                For i = 0 To rows - 1
                    Me.Rows(i).HeaderCell.Value = "" & i + 1
                Next
            End If
        End If
    End Sub
    Private Sub RECIPE_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        'sqlclass.server = ".\sqlexpress"
        'sqlclass.dbname = "phrencrydecry"
        'sqlclass.database = "phrencrydecry"
        'sqlclass.dbid = "rms"
        'sqlclass.dbpass = "rms"
        'Login_Register.levelid = 1
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ''        'filllevels()
            '   Login_Register.levelid = 1
            If Login_Register.levelid = 1 Or Login_Register.levelid = Login_Register.mngr Then
                ''        '   Panel1.Visible = True
                '            ''                showselected(Me, Me.ParentForm)

                Dim btnp As New buttonproperty(Me.Parent.Name, Me.Name, Me.Location.X, Me.Location.Y)
                ' btnp.StartPosition = FormStartPosition.CenterParent
                btnp.showselected(Me, Me.Parent)
                btnp.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                '   btnp.Panel1.Location = Me.Location
                btnp.ShowDialog()

            End If
        Else
            'If Not read1 Then
            '    pev = 1
            '    Button1.BorderStyle = BorderStyle.Fixed3D
            '    ' Button1.BackColor = Color.Yellow
            '    value = 1
            '    ' Label1.Text = ontext
            '    'Button1.Image = Me.ButtonONImage
            '    Button1.SizeMode = PictureBoxSizeMode.StretchImage

            '    'scada.write_to_plc(PushButton.plcaddress, 1)
            '    'Button1.BackColor = Color.LawnGreen
            '    '  Timer1.Enabled = True

            '    '      MsgBox(Me.Name & ": " & Me.ParentForm.Name)
            '    recordflag = Recordvalue
            '    If recordflag > 0 Then
            '        ev.insertscadaevent(Login_Register.empid, "Button Pressed", Login_Register.levelid, Me.RecordMessage, "", "", "", "", "", "", AuditTrail.lotn, AuditTrail.batchat, "Audittrail")
            '    End If
            '       End If
            ' MsgBox("mouse down")
        End If
        '  
    End Sub
End Class

Public Class addcolumn


    '        Public Enum Tastiness
    '            Keystone
    '            Coors
    '            Guiness
    '        End Enum
    ' this _value property only have three value 1,2,3
    Private _value As String = Nothing
    Property Values() As String
        Get
            Return _value
        End Get
        Set(ByVal value As String)
            _value = value

        End Set
    End Property
    'Private img As Image = Nothing
    ''Private imgname As String = ""
    'Public Property Setimage() As Image
    '    Get
    '        Return img
    '    End Get
    '    Set(ByVal value As Image)
    '        img = value
    '    End Set
    'End Property
    Private imgname1 As String = ""

    <EditorAttribute(GetType(FileNameEditor), GetType(UITypeEditor))>
    Public Property Setimagename1() As String
        Get
            Return imgname1
        End Get
        Set(ByVal value As String)
            '    PictureBox4.Image = My.Resources.ResourceManager.GetObject("loading4")
            ' in this we are the extracting the file name of the selected file without extension 
            '   imgname1 = IO.Path.GetFileNameWithoutExtension(value)

            imgname1 = IO.Path.GetFullPath(value)

        End Set
    End Property
    Private imgname2 As String = ""

    <EditorAttribute(GetType(FileNameEditor), GetType(UITypeEditor))>
    Public Property Setimagename2() As String
        Get
            Return imgname2
        End Get
        Set(ByVal value As String)
            '    PictureBox4.Image = My.Resources.ResourceManager.GetObject("loading4")
            ' in this we are the extracting the file name of the selected file without extension 
            '   imgname2 = IO.Path.GetFileNameWithoutExtension(value)
            imgname2 = IO.Path.GetFullPath(value)

        End Set
    End Property
    Public colname As String = ""
    '<EditorAttribute(GetType(FileNameEditor), GetType(UITypeEditor))>
    Public Property Setcolname() As String
        Get
            Return colname
        End Get
        Set(ByVal value As String)
            '    PictureBox4.Image = My.Resources.ResourceManager.GetObject("loading4")
            ' in this we are the extracting the file name of the selected file without extension 
            colname = value

        End Set
    End Property
End Class

<TypeConverterAttribute(GetType(System.ComponentModel.ExpandableObjectConverter))> _
Public Class dropdown
    Dim col As String()
    Sub getcolumnnames()
        Dim r As New RECIPE
        ReDim col(r.Columns.Count)
        For i = 0 To r.Columns.Count - 1
            col(i) = r.Columns(i).HeaderText
        Next
    End Sub


    Private _name As String
    Property ColumnName() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property
    Private op1 As String = ""
    Private op2 As String = ""
    Private op3 As String = ""
    Private op4 As String = ""
    Private op5 As String = ""
    Private op6 As String = ""
    Private op7 As String = ""
    Private op8 As String = ""
    Private op9 As String = ""
    Private op10 As String = ""

    Property Option1 As String
        Get
            Return op1
        End Get
        Set(ByVal value As String)
            op1 = value
        End Set
    End Property


    Property Option2 As String
        Get
            Return op2
        End Get
        Set(ByVal value As String)
            op2 = value
        End Set
    End Property
    Property Option3 As String
        Get
            Return op3
        End Get
        Set(ByVal value As String)
            op3 = value
        End Set
    End Property
    Property Option4 As String
        Get
            Return op4
        End Get
        Set(ByVal value As String)
            op4 = value
        End Set
    End Property
    Property Option5 As String
        Get
            Return op5
        End Get
        Set(ByVal value As String)
            op5 = value
        End Set
    End Property
    Property Option6 As String
        Get
            Return op6
        End Get
        Set(ByVal value As String)
            op6 = value
        End Set
    End Property
    Property Option7 As String
        Get
            Return op7
        End Get
        Set(ByVal value As String)
            op7 = value
        End Set
    End Property
    Property Option8 As String
        Get
            Return op8
        End Get
        Set(ByVal value As String)
            op8 = value
        End Set
    End Property

    Property Option9 As String
        Get
            Return op9
        End Get
        Set(ByVal value As String)
            op9 = value
        End Set
    End Property
    Property Option91 As String
        Get
            Return op10
        End Get
        Set(ByVal value As String)
            op10 = value
        End Set
    End Property

End Class


''Partial Publisc Class UserControl1
'Inherits UserControl
'Implements IDataGridView
'Public Sub New()
'    InitializeComponent()
'End Sub
'<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
'<Browsable(False)> _
'Public ReadOnly Property DataGridView() As DataGridView Implements IDataGridView.DataGridView
'    Get
'        Return DataGridView1
'    End Get
'End Property
'Dim a As DataGridViewColumnCollection
'<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
'<Editor(GetType(ExtendedDataGridViewColumnCollectionEditor), GetType(UITypeEditor))> _
'<MergableProperty(False)> _
'Property MyDataGridColumns() As DataGridViewColumnCollection
'    Get
'        Return DataGridView1.Columns
'    End Get
'    Set(ByVal value As DataGridViewColumnCollection)
'        a = value
'    End Set
'End Property



'End Class

'Public Interface IDataGridView
'    ReadOnly Property DataGridView() As DataGridView
'End Interface

'Public Class ExtendedDataGridViewColumnCollectionEditor
'    Inherits UITypeEditor
'    Private dataGridViewColumnCollectionDialog As Form

'    Private Sub New()
'    End Sub

'    Private Shared Function CreateColumnCollectionDialog(ByVal provider As IServiceProvider) As Form
'        Dim assembly__1 = Assembly.Load(GetType(ControlDesigner).Assembly.ToString())
'        Dim type = assembly__1.[GetType]("System.Windows.Forms.Design.DataGridViewColumnCollectionDialog")

'        Dim ctr = type.GetConstructors(BindingFlags.NonPublic Or BindingFlags.Instance)(0)
'        Return DirectCast(ctr.Invoke(New Object() {provider}), Form)
'    End Function

'    Public Shared Sub SetLiveDataGridView(ByVal form As Form, ByVal grid As DataGridView)
'        Dim mi = form.[GetType]().GetMethod("SetLiveDataGridView", BindingFlags.NonPublic Or BindingFlags.Instance)
'        mi.Invoke(form, New Object() {grid})
'    End Sub

'    Public Overrides Function EditValue(ByVal context As ITypeDescriptorContext, ByVal provider As IServiceProvider, ByVal value As Object) As Object
'        If provider IsNot Nothing AndAlso context IsNot Nothing Then
'            Dim service = DirectCast(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)
'            If service Is Nothing OrElse context.Instance Is Nothing Then
'                Return value
'            End If

'            Dim host = DirectCast(provider.GetService(GetType(IDesignerHost)), IDesignerHost)
'            If host Is Nothing Then
'                Return value
'            End If

'            If dataGridViewColumnCollectionDialog Is Nothing Then
'                dataGridViewColumnCollectionDialog = CreateColumnCollectionDialog(provider)
'            End If

'            'Unfortunately we had to make property which returns inner datagridview  
'            'to access it here because we need to pass DataGridView into SetLiveDataGridView () method 
'            Dim grid = DirectCast(context.Instance, IDataGridView).DataGridView
'            'we have to set Site property because it will be accessed inside SetLiveDataGridView () method 
'            'and by default it's usually null, so if we do not set it here, we will get exception inside SetLiveDataGridView () 
'            Dim oldSite = grid.Site
'            grid.Site = DirectCast(context.Instance, UserControl).Site
'            'execute SetLiveDataGridView () via reflection 
'            SetLiveDataGridView(dataGridViewColumnCollectionDialog, grid)

'            Using transaction = host.CreateTransaction("DataGridViewColumnCollectionTransaction")
'                If service.ShowDialog(dataGridViewColumnCollectionDialog) = DialogResult.OK Then
'                    transaction.Commit()
'                Else
'                    transaction.Cancel()
'                End If
'            End Using
'            'we need to set Site property back to the previous value to prevent problems with serializing our control 
'            grid.Site = oldSite
'        End If

'        Return value
'    End Function

'    Public Overrides Function GetEditStyle(ByVal context As ITypeDescriptorContext) As UITypeEditorEditStyle
'        Return UITypeEditorEditStyle.Modal
'    End Function
'End Class

