Imports System.Drawing.Design
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms.Design
Imports System.Reflection
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class gridcomponent
    Dim sql As New sqlclass
    Dim initialised As Boolean = False
    Dim row As Integer
    Dim s3 As New List(Of addcolumn1)
    Dim ddown As New List(Of dropdown1)
    Dim row_hlt As Integer
    Public namearray() As String
    ' Friend highlight_row As Integer

    <Browsable(True), _
EditorBrowsable(EditorBrowsableState.Always), _
Category("_Binding"), _
Description("The items with sub items that should be displayed"), _
DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Property addDropDownValues As List(Of dropdown1)
        Get
            Return ddown

        End Get
        Set(ByVal value As List(Of dropdown1))
            ddown = value
        End Set
    End Property

    <Category("_Misc")>
    Property RowsCount As Integer
        Get
            Return row
        End Get
        Set(ByVal value As Integer)
            row = value
            Try
                generaterows(row)

            Catch ex As Exception
            End Try
        End Set
    End Property
    Dim read1 As Boolean = True
    <Category("_Misc")>
    Property _Readonly As Boolean
        Get
            Return read1
        End Get
        Set(ByVal value As Boolean)
            read1 = value
            If read1 = True Then
                'Me.Enabled = False

                'readwrite = False
            End If
        End Set
    End Property
    Dim directvisibleval As Boolean = True
    <Browsable(True), _
Category("_VISIBLE")> _
    Property Direct As Boolean


        Get
            Return directvisibleval
        End Get
        Set(value As Boolean)
            directvisibleval = value
            If directvisibleval = True Then
                indirectvisibleval = False
            End If
        End Set
    End Property
    Dim indirectvisibleval As Boolean = False
    <Browsable(True), _
Category("_VISIBLE")> _
    Property INDirect As Boolean


        Get
            Return indirectvisibleval
        End Get
        Set(value As Boolean)
            indirectvisibleval = value
            If indirectvisibleval = True Then
                directvisibleval = False
            End If
        End Set
    End Property
    Dim Address_Of_m As Integer = 0
    Dim Vissible_tagname As String = ""
    <Browsable(True), _
Category("_VISIBLE")> _
    Property Vissible_Tag As String


        Get
            Return Vissible_tagname
        End Get
        Set(value As String)
            Vissible_tagname = value

        End Set
    End Property
 

    <Category("_Misc")>
    Property highlight_row As Integer
        Get

            Return row_hlt
        End Get
        Set(ByVal value As Integer)
            ' If value = Nothing Then
            ' Else
            row_hlt = value



        End Set
    End Property
    Dim hlt_color As Color = Color.Yellow
    <Category("_Misc")>
    Property highlight_color As Color
        Get
            Return hlt_color
        End Get
        Set(ByVal value As Color)
            hlt_color = value
        End Set
    End Property


    Dim namecolumn As String
    <Category("_Misc")>
    Property name_column As String
        Get
            Return namecolumn
        End Get
        Set(ByVal value As String)
            namecolumn = value
        End Set
    End Property






    <Browsable(True), _
  EditorBrowsable(EditorBrowsableState.Always), _
  Category("_Binding"), _
  Description("The items with sub items that should be displayed"), _
  DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Property ImageColumn As List(Of addcolumn1)
        Get
            Return s3
        End Get
        Set(ByVal value As List(Of addcolumn1))
            s3 = value
        End Set
    End Property



    Dim a As New List(Of DataGridViewColumn)
    Dim b As DataGridViewAutoSizeColumnMode
    Dim c As DataGridViewColumn

    'tempd() stores initial tag id of each column
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
                        '         writearray(e.ColumnIndex, e.RowIndex) = 1

                        If variableclass.without_plc = True Then
                            'tempd() stores initial tag id of each column
                            writeIndb(tempd(Me.CurrentCell.ColumnIndex) + e.RowIndex, 1)
                            'variableclass.d(Integer.Parse(variblevalue) + e.RowIndex) = 1
                        Else
                            ' plcclass.write_single_DValue(Integer.Parse(variblevalue) + e.RowIndex, 1)
                        End If

                    Else


                        If variableclass.without_plc = True Then
                            writeIndb(tempd(Me.CurrentCell.ColumnIndex) + e.RowIndex, 0)
                        Else
                            'plcclass.write_single_DValue(Integer.Parse(variblevalue) + e.RowIndex, 0)
                        End If


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
            Try

                If IsNumeric(Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                    If variableclass.without_plc = True Then
                        writeIndb(tempd(Me.CurrentCell.ColumnIndex) + e.RowIndex, Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
                        'variableclass.d(Integer.Parse(variblevalue) + e.RowIndex) = Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                    Else
                        '  plcclass.write_single_DValue(Integer.Parse(variblevalue) + e.RowIndex, Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
                    End If

                End If
    

            Catch ex As ArithmeticException
            MessageBox.Show("Value Overflow", "Alert")
        End Try
        End If
    End Sub
   

    Private Sub RECIPE_ControlAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles Me.ControlAdded
        Me.AllowUserToAddRows = False
        Me.AllowUserToDeleteRows = False
    End Sub

    

    'read and show value in each column of grid
    Sub adddatain_datagridview()
        visiblecode()
        highlightrow()

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
              
                Me.Rows(roww).Cells(i).Value = variableclass.tag(tempd(i) + roww)


            Catch ex As Exception
            End Try

        Next

    End Sub
    Sub addimage(ByVal i)

        For sc = 0 To s3.Count - 1
            If Me.Columns(i).HeaderText = s3(sc).colname Then

                For roww = 0 To RowCount - 1
                    '          

                    Try
                       
                        If variableclass.tag(tempd(i) + roww) = 0 Then
                            If Me.Rows(roww).Cells(i).tag <> 0 Or Me.Rows(roww).Cells(i).tag Is Nothing Then
                                ' Me.Rows(roww).Cells(i).Value = My.Resources.ResourceManager.GetObject(s3(sc).Setimagename1)
                                Try
                                    Me.Rows(roww).Cells(i).Value = Image.FromFile(s3(sc).Setimagename1)

                                    Me.Rows(roww).Cells(i).tag = 0
                                Catch ex As Exception
                                End Try
                            End If
                        End If
                        If variableclass.tag(tempd(i) + roww) = 1 Then
                            If Me.Rows(roww).Cells(i).tag <> 1 Then
                                Try
                                    Me.Rows(roww).Cells(i).Value = Image.FromFile(s3(sc).Setimagename2)
                                   
                                    Me.Rows(roww).Cells(i).tag = 1
                                Catch ex As Exception
                                End Try
                            End If
                        End If


                    Catch ex As Exception
                    End Try
                 

                Next
            End If

        Next
      
    End Sub
    Dim tempddl = 0
    Sub adddropdown(ByVal i)
        If tempddl = 0 Then
            Dim comboSource As New Dictionary(Of String, String)()
            For sc = 0 To ddown.Count - 1
                If Me.Columns(i).HeaderText = ddown(sc).ColumnName Then
                    For k = 0 To ddown(sc).List_of_Combobox.Count - 1
                        comboSource.Add(ddown(sc).List_of_Combobox(k), ddown(sc).List_of_Combobox(k))
                    Next
                End If
            Next

            For roww = 0 To RowCount - 1


                Dim dgvcc As DataGridViewComboBoxCell

                dgvcc = Me.Rows(roww).Cells(i)

                dgvcc.DataSource = New BindingSource(comboSource, Nothing)
                dgvcc.DisplayMember = "Value"
                dgvcc.ValueMember = "Key"
             
            Next
            tempddl = 1
        End If

        For roww = 0 To Me.RowsCount - 1
            Dim dgvcc As DataGridViewComboBoxCell
            dgvcc = Me.Rows(roww).Cells(i)
            Dim index = 0
            Dim temp = ""
            For sc = 0 To ddown.Count - 1

                Try
               



                    'Me.Rows(roww).Cells(i).Value = variableclass.d(Integer.Parse(variblevalue) + roww)
                    If Me.Columns(i).HeaderText = ddown(sc).ColumnName Then
                        'temp=ddown(sc).List_of_Combobox.FindIndex(ddown(sc).List_of_Combobox,

                        temp = ddown(sc).List_of_Combobox(variableclass.tag(tempd(i) + roww))
                    End If

                Catch ex As Exception
                End Try

            Next
            If dgvcc.Value <> temp Then
                Try

                    dgvcc.Value = temp
                   
                Catch ex As Exception
                End Try
            End If

        Next

    End Sub

    'tempd() stores initial tag id of each column
    Private Sub DataGridView1SelectAll_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Me.CurrentCellDirtyStateChanged


        RemoveHandler Me.CurrentCellDirtyStateChanged,
            AddressOf DataGridView1SelectAll_CurrentCellDirtyStateChanged

        If TypeOf Me.CurrentCell Is DataGridViewComboBoxCell Then
            Me.EndEdit()
      
            Try
                
                Dim index = 0
                Dim temp = ""
                For sc = 0 To ddown.Count - 1
                    If Me.Columns(Me.CurrentCell.ColumnIndex).HeaderText = ddown(sc).ColumnName Then
                        index = Array.IndexOf(ddown(sc).List_of_Combobox, CurrentCell.Value)

                    End If
                Next

                If variableclass.without_plc = True Then
                    'tempd() stores initial tag id of each column
                    'writes values of cell in database
                    writeindb(tempd(Me.CurrentCell.ColumnIndex) + Me.CurrentCell.RowIndex, index)
                Else
                    'plcclass.write_single_DValue(variblevalue + Me.CurrentCell.RowIndex, index)
                End If


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

                Dim btnp As New buttonproperty(Me.Parent.FindForm.Name, Me.Name, Me.Location.X, Me.Location.Y)
                ' btnp.StartPosition = FormStartPosition.CenterParent
                btnp.TopMost = True
                btnp.showselected(Me, Me.FindForm)
                '  btnp.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                '   btnp.Panel1.Location = Me.Location
                btnp.StartPosition = FormStartPosition.CenterParent
                btnp.ShowDialog()

            End If
        Else
         
        End If
        '  
    End Sub
    '-- new code to the rights of component
    Dim rvisible As Boolean = True
    Dim renable As Boolean = True
    'check rights given to grid from database
    Public Sub rightread(ByVal btn As Control, ByVal frm As Form)
        '  sql.scn3.Close()

        If btn IsNot Nothing And frm IsNot Nothing Then
            renable = True
            If Login_Register.levelid Is Nothing Then
                Login_Register.levelid = 0
            End If
            If Login_Register.levelid = 1 Then
                ' btn.Visible = True
                ' btn.Enabled = True
                rvisible = True
                renable = True
            Else
                '  btn.Enabled = False
                renable = True
                Dim query As String = "open symmetric key symmetrickey1 decryption by certificate certificate1 select convert(varchar, decryptbykey(controlproperty)),controlstatus from controlrights  where levelid=" & Login_Register.levelid & " and convert(varchar, decryptbykey(formname))='" & frm.Name & "' and convert(varchar, decryptbykey(controlname))='" & btn.Name & "'"
                If sqlclass.database <> "" Then

                    '      If sql.scn3.State <> ConnectionState.Open Or sql.scn3 Is Nothing Then
                    sqlclass.rightcon()
                    'End If
                    Dim sqlcmd As SqlCommand = New SqlCommand(query, sqlclass.rightcnn)
                    Using reader As SqlDataReader = sqlcmd.ExecuteReader
                        While reader.Read
                            ' controlstatus 1 means visible property
                            ' controlstatus 2 means enable property
                            If reader.Item(1) = 1 Then

                                If reader.Item(0) = True Then
                                    ' btn.Visible = True
                                    rvisible = True
                                Else
                                    '  btn.Visible = False
                                    rvisible = False
                                End If
                            Else
                                If reader.Item(0) = True Then
                                    '   btn.Enabled = True
                                    renable = True
                                Else
                                    '   btn.Enabled = False
                                    renable = False
                                End If
                            End If
                        End While

                    End Using
                    sqlclass.rightcnn.Close()
                
                End If
            End If
        End If
    End Sub
    Dim pvisible As Boolean
    Dim penable As Boolean
    Dim tempdirect = 0
    Dim tempindirect = 0
    Dim Getvissibleaddress = 0
    Public Sub propertyvisiblecode()
        'Dim cst = "::11:00:00"
        'Dim cspt = "::11:00:00"
        'Dim time = DateTime.Parse(cst)
        'Dim time2 = DateTime.Parse(cspt)
        'Dim temp = time2.Subtract(time)
        If Direct = False Then
            ' If tempdirect = 0 Or tempdirect = 2 Then
            'Me.Visible = False
            pvisible = False
            ' tempdirect = 1
            ' End If
        Else
            'If tempdirect = 1 Or tempdirect = 0 Then
            'Me.Visible = True
            pvisible = True
            ' tempdirect = 2
            ' End If

        End If
        If Me.INDirect = True Then
            If Getvissibleaddress = 0 Then
                Sql.scon3()
                '' Dim querystring As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select tag_id from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & Vissible_tagname & "'"

                Dim querystring As String = ""
                'for encrypted or  non_encypted tables
                If variableclass.is_encrypted Then
                    querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select tag_id from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & Vissible_tagname & "'"
                Else
                    querystring = "select tag_id from Tag_data  where  Tag_name = '" & Vissible_tagname & "'"
                End If


                Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
                sqlcmd1.ExecuteNonQuery()
                Using reader As SqlDataReader = sqlcmd1.ExecuteReader
                    If reader.Read = True Then
                        Address_Of_m = reader.Item("Tag_id")
                    End If
                End Using
                ' sqlcmd1.Dispose()
                Sql.scn3.Close()
                Getvissibleaddress = 1
            End If
            If variableclass.tag(Address_Of_m) = 1 Then
                ' If tempindirect = 0 Or tempindirect = 2 Then
                '  Me.Visible = True
                pvisible = True
                '  tempindirect = 1
                'End If
            Else
                '    If tempindirect = 1 Or tempindirect = 0 Then
                'Me.Visible = False
                pvisible = False
                ' tempindirect = 2
                ' End If
            End If
        End If

    End Sub
    Dim tempvisible = 0
    Dim tempenable = 0
    Sub visiblecode()
        propertyvisiblecode()
        If rvisible = True Then

            If pvisible = True Then

                '    rvisible = True
                If tempvisible = 0 Or tempvisible = 2 Then
                    Me.Visible = True
                    tempvisible = 1
                End If
                If renable = True Then

                    If Not (_Readonly) Then

                        '  renable = True
                        If tempenable = 0 Or tempenable = 2 Then
                            Me.Enabled = True
                            tempenable = 1
                        End If
                    Else
                        If tempenable = 1 Or tempenable = 0 Then
                            '  renable = False
                            Me.Enabled = False
                            Me.ForeColor = Color.White
                            tempenable = 2
                        End If

                    End If

                Else

                    If tempenable = 1 Or tempenable = 0 Then
                        '  renable = False
                        Me.Enabled = False
                        tempenable = 2
                    End If
                End If

            Else
                If tempvisible = 1 Or tempvisible = 0 Then
                    'Me.Visible = True
                    '   rvisible = False
                    Me.Visible = False
                    tempvisible = 2
                End If

            End If

        Else
            If tempdirect = 1 Or tempdirect = 0 Then
                'Me.Visible = True
                '  rvisible = False
                Me.Visible = False
                tempvisible = 2
            End If
        End If




    End Sub
    Sub highlightrow()
        Try
            If Me.Rows.Count = 0 Then
                'generaterows(row)
            Else
                If row_hlt > 0 Then
                    For i = 0 To RowsCount - 1
                        Me.Rows(i).DefaultCellStyle.BackColor = Color.White
                    Next
                    Me.Rows(row_hlt - 1).DefaultCellStyle.BackColor = hlt_color
                    '  Console.Write("1")
                End If
               
            End If
        Catch ex As Exception
        End Try

    End Sub

    'write value in database
    Sub writeIndb(ByVal address As Integer, ByVal value As Integer)
        Try

       
        sql.scon3()
            '  Dim querystring As String = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN  OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update Tag_detail_data set writeaddress_value = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & value & "'))  where  Tag_id = '" & address & "' COMMIT TRANSACTION"
            Dim querystring As String = ""
            'for encrypted or  non_encypted tables
            If variableclass.is_encrypted Then
                querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN  OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update Tag_detail_data set writeaddress_value = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & value & "'))  where  Tag_id = '" & address & "' COMMIT TRANSACTION"
            Else
                querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN  update Tag_detail_data set writeaddress_value = '" & value & "'  where  Tag_id = '" & address & "' COMMIT TRANSACTION"
            End If

            Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
        sqlcmd1.ExecuteNonQuery()
        sqlcmd1.Dispose()
        sql.scn3.Close()
        Catch ex As Exception

        End Try
    End Sub
    'this array stores initial(start) tagid for each column according to given tag name for each column
    Dim tempd() As Integer
    Dim tempstopflick = 0
    'this function assign tagid to ach column
    Sub updatevalue()
        ReDim tempd(ColumnCount - 1)
        sql.scon3()
        For i = 0 To ColumnCount - 1
            '' Dim querystring As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & Me.Columns(i).DataPropertyName & "' "
            Dim querystring As String = ""
            'for encrypted or  non_encypted tables
            If variableclass.is_encrypted Then
                querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & Me.Columns(i).DataPropertyName & "' "
            Else
                querystring = "select Tag_id from Tag_data  where  Tag_name = '" & Me.Columns(i).DataPropertyName & "' "
            End If

            Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
            sqlcmd1.ExecuteNonQuery()
            Using reader As SqlDataReader = sqlcmd1.ExecuteReader
                If reader.Read = True Then
                    tempd(i) = reader.Item("Tag_id") 'gives starting tag_id to each column
                Else
                    tempd(i) = 0
                    Me.ReadOnly = True
                End If
            End Using
            sqlcmd1.Dispose()
        Next

        sql.scn3.Close()
        If tempstopflick = 0 Then
            'to prevent grid from flickring
            EnableDoubleBuffered(Me)
            tempstopflick = 1
        End If
        
    End Sub
    Public Sub EnableDoubleBuffered(ByVal dgv As DataGridView)

        Dim dgvType As Type = dgv.[GetType]()

        Dim pi As PropertyInfo = dgvType.GetProperty("DoubleBuffered", _
                                                     BindingFlags.Instance Or BindingFlags.NonPublic)

        pi.SetValue(dgv, True, Nothing)

    End Sub

End Class

Public Class addcolumn1


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
Public Class dropdown1
    Dim col As String()
    Sub getcolumnnames()
        Dim r As New gridcomponent
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
    Dim _listcombobox As String()
    Property List_of_Combobox As String()
        Get
            Return _listcombobox
        End Get
        Set(ByVal value As String())
            _listcombobox = value
        End Set
    End Property


End Class

