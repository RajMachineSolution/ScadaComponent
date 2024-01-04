Imports System.IO
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Text.RegularExpressions


Public Class CustomReceipe

    Dim receipe_load_d As New List(Of Columns_Property_Class)
    <Browsable(True), _
EditorBrowsable(EditorBrowsableState.Always), _
Description(""), _
DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public Property Receipe_Load_details As List(Of Columns_Property_Class)
        Get
            Return receipe_load_d
        End Get
        Set(ByVal value As List(Of Columns_Property_Class))
            receipe_load_d = value
        End Set
    End Property



    Public Enum FileLocationType
        select_at_RunTime
        ' given_in_Property
    End Enum

    Dim save_file_location As FileLocationType
    Public Property savefilelocation As FileLocationType
        Get
            Return save_file_location
        End Get
        Set(ByVal value As FileLocationType)

            save_file_location = value
        End Set
    End Property


    'reference of data grid from which receipe will be saved
    Dim linked_grid As DataGridView
    Property Linked_datagridview As DataGridView
        Get
            Return linked_grid
        End Get
        Set(ByVal value As DataGridView)
            linked_grid = value
        End Set
    End Property

    Public Function savefile()
        Try


            Dim saveFileDialog1 As New SaveFileDialog
            Dim UservariablevalueD As String() = {}
            Dim temp = 0
            ' Dim result As DialogResult = saveFileDialog1.ShowDialog()
            saveFileDialog1.Filter = "TXT Files (*.txt*)|*.txt"
            If saveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

                Dim FILENAME = saveFileDialog1.FileName
                ReDim UservariablevalueD(linked_grid.Rows.Count * linked_grid.Columns.Count)

                Dim string_to_write = ""
                For i = 0 To linked_grid.Columns.Count - 1
                    For j = 0 To linked_grid.Rows.Count - 1

                        ' Dim w1 As New Sstem.IO.StreamWriter(FILE_NAME)
                        Dim val = linked_grid.Rows(j).Cells(i).Value
                        If IsNothing(val) Then
                            val = 0
                        End If
                        If TypeOf Linked_datagridview Is scadacomponent.CustomDatagridView Then
                            Dim cdgv As scadacomponent.CustomDatagridView = CType(linked_grid, scadacomponent.CustomDatagridView)

                            If TypeOf linked_grid.Rows(j).Cells(i) Is DataGridViewComboBoxCell Then

                                Dim dropdownarray = cdgv.ColumnsProperty(i).List_of_DropDownValues
                                val = Array.IndexOf(dropdownarray, val)
                            End If

                            If TypeOf linked_grid.Rows(j).Cells(i) Is DataGridViewImageCell Then

                                Dim offimage = cdgv.ColumnsProperty(i).OFF_Image
                                Dim onimage = cdgv.ColumnsProperty(i).ON_Image

                                If val.Equals(onimage) Then
                                    val = 1
                                Else
                                    val = 0
                                End If
                            End If
                        End If


                        UservariablevalueD(temp) = i & "," & j & "=" & val
                        temp = temp + 1
                    Next
                Next

                Dim w1 As New System.IO.StreamWriter(FILENAME)
                If UservariablevalueD.Length > 0 Then
                    '     MsgBox(String.Join(",", UservariablevalueD))
                    'code for writing file
                    w1.WriteLine(String.Join(vbNewLine, UservariablevalueD))
                    w1.Close()
                End If
                ' MsgBox("Saved Successfully")
                Return FILENAME
            End If



        Catch ex As Exception
            ' MsgBox("Something went wrong")
            Return ""
        End Try
    End Function



    Dim receipe_string() As String

    Dim finalvalue = 0
    Public Function openfile()

        updatevalue()
        ReDim receipe_string(Receipe_Load_details.Count - 1)
        '    redeem(receipe_string(Receipe_Load_details.Count))

        ''first setting all string value to ""
        For i = 0 To Receipe_Load_details.Count - 1

            Dim var_type = Receipe_Load_details(i).Variable_Type

            receipe_string(Receipe_Load_details(i).Column_number) = ""

        Next



        '  Dim OpenFileDialog1 As New OpenFileDialog
        ' OpenFileDialog1.ShowDialog()
        Dim counter1 = 0
        Dim FILENAME = ""
        Try

            Dim OpenFileDialog1 As New OpenFileDialog
            Dim UservariablevalueD As String() = {}
            Dim temp = 0
            ' Dim result As DialogResult = saveFileDialog1.ShowDialog()
            OpenFileDialog1.Filter = "TXT Files (*.txt*)|*.txt"
            If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

                FILENAME = OpenFileDialog1.FileName
                ' ReDim UservariablevalueD(linked_grid.Rows.Count * linked_grid.Columns.Count)

                Dim string_to_write = ""
                Dim no_of_rows = 0

                Dim r1 As New System.IO.StreamReader(FILENAME)
                Dim msg = ""
                '  Dim tf = fo.Split(vbNewLine)
                ' Dim counter1 = 0
                Do
                    ' counter1 = counter1 + 1
                    no_of_rows = no_of_rows + 1


                    msg = r1.ReadLine

                    Dim arr = msg.Split("=")
                    Dim data = arr(0).Split(",")
                    Dim col = data(0)
                    If msg = "" Then
                        Exit Do
                    End If
                    Dim row = Integer.Parse(data(1))
                    Dim value = arr(1)
                    finalvalue = value
                    Dim colno = 0
                    ' Dim Address = 1000
                    'Dim vartype = "D"


                    Dim final_col_no = 0
                    '  Dim columnName = linked_grid.Columns(col).Name

                    For i = 0 To Receipe_Load_details.Count - 1
                        counter1 = counter1 + 1

                        If counter1 = 3200 Then
                            Dim x = 0
                        End If

                        If Receipe_Load_details(i).Column_number = col Then
                            final_col_no = col

                            Dim gain2 = Receipe_Load_details(i).Gain
                            'Dim available_add_or_tag = Receipe_Load_details(i).Tag

                            'Dim tag As Integer
                            'Dim devicetype = ""
                            'Dim m As Match = Regex.Match(available_add_or_tag, "^([A-Za-z]+)([0-9]+)$")
                            'If (m.Success) Then
                            '    devicetype = m.Groups(1).Value
                            '    tag = m.Groups(2).Value

                            'Else

                            'End If

                            If Receipe_Load_details(i).Variable_Type = 0 Then
                                If IsNumeric(value) Then
                                    If gain2 > 1 Then
                                        'plcclass.write_single_DValue(add_or_tag + row, value * gain2)
                                        ' d_arr(tag + row) = value * gain2
                                        receipe_string(col) = receipe_string(col) & "," & value * gain2

                                    Else
                                        ' plcclass.write_single_DValue(add_or_tag + row, value)
                                        '   d_arr(tag + row) = value
                                        receipe_string(col) = receipe_string(col) & "," & value

                                    End If
                                End If
                            ElseIf Receipe_Load_details(i).Variable_Type = 1 Then
                                If IsNumeric(value) Then
                                    Dim tempvtw = value
                                    If gain2 > 1 Then
                                        tempvtw = tempvtw * gain2
                                    End If


                                    '32 bit to 16 bit converterssss
                                    Dim Byte_Arr(3) As Byte
                                    Byte_Arr = BitConverter.GetBytes(Convert.ToInt32(tempvtw))
                                    ' plcclass.write_single_DValue(add_or_tag + row * 2, BitConverter.ToInt16(Byte_Arr, 0))
                                    '  d_arr(tag + row * 2) = BitConverter.ToInt16(Byte_Arr, 0)
                                    receipe_string(col) = receipe_string(col) & "," & BitConverter.ToInt16(Byte_Arr, 0)
                                    'plcclass.write_single_DValue(add_or_tag + row * 2 + 1, BitConverter.ToInt16(Byte_Arr, 2))
                                    ' d_arr(tag + row * 2 + 1) = BitConverter.ToInt16(Byte_Arr, 2)
                                    receipe_string(col) = receipe_string(col) & "," & BitConverter.ToInt16(Byte_Arr, 2)
                                    'write_value(Integer.Parse(add_or_tag) + e.RowIndex * 2, BitConverter.ToInt16(Byte_Arr, 0))
                                    'write_value(Integer.Parse(add_or_tag) + e.RowIndex * 2 + 1, BitConverter.ToInt16(Byte_Arr, 2))

                                End If

                            ElseIf Receipe_Load_details(i).Variable_Type = 2 Then
                                If IsNumeric(value) Then
                                    '  plcclass.wrtie_m_singlevalue(tag + row, value)
                                    ' m_arr(add_or_tag + row) = value
                                    receipe_string(col) = receipe_string(col) & "," & value
                                End If
                            Else

                                receipe_string(col) = receipe_string(col) & "," & value * gain2

                            End If



                        End If

                    Next








                Loop While msg IsNot ""



                ''for saving value in plc
                For i = 0 To Receipe_Load_details.Count - 1

                    Dim var_type = Receipe_Load_details(i).Variable_Type




                    If receipe_string(Receipe_Load_details(i).Column_number).Length() > 0 Then
                        receipe_string(Receipe_Load_details(i).Column_number) = receipe_string(Receipe_Load_details(i).Column_number).Remove(0, 1)
                    End If

                    '16bit 32bit
                    If var_type = 0 Or var_type = 1 Then

                        writeIndb(tempd(i), receipe_string(Receipe_Load_details(i).Column_number), receipe_string(Receipe_Load_details(i).Column_number))
                    Else
                        'Binary,string
                        'string
                        If var_type = 3 Then


                            Dim data_set As New DataSet
                            Dim data_adapter As New SqlDataAdapter
                            Dim data_table As DataTable = New DataTable
                            '   Dim rows_to_select = 0
                            Try
                                sqlclass.rightcon()
                                Dim select_query As String = "select Tag_id,Read_value from Tag_data"
                                'data_set.Clear()
                                'command for query execution
                                Dim cmd = New SqlCommand(select_query, sqlclass.rightcnn)
                                data_adapter.SelectCommand = cmd
                                'get datatable from database and show in grid
                                ' rows_to_select = data_adapter()
                                data_adapter.Fill(data_table)
                                ' DataGridView2.DataSource = data_table
                                sqlclass.rightcnn.Close()
                            Catch ex As Exception
                                '   MsgBox(ex.Message)
                            End Try




                            Dim available_values_array = receipe_string(Receipe_Load_details(i).Column_number).Split(",")
                            For j = 0 To available_values_array.Length - 1
                                ' data_table.Rows(j + 1)(0) = tempd(i) + j
                                data_table.Rows(tempd(i) + j - 1)(1) = available_values_array(j)
                                

                                '   writeIndb(tempd(i) + j, available_values_array(j), available_values_array(j))
                                '  System.Threading.Thread.Sleep(10)
                            Next
                            ' data_table.Rows(0)(0) = data_table.Rows(0)(0) + available_values_array.Length
                            ' data_table.Rows(0)(1) = tempd(i) + j
                            'update database
                            Dim sql_cmd_builder As New SqlCommandBuilder
                            sql_cmd_builder = New SqlCommandBuilder(data_adapter)
                            data_adapter.Update(data_table)


                        Else


                            Dim data_set As New DataSet
                            Dim data_adapter As New SqlDataAdapter
                            Dim data_table As DataTable = New DataTable
                            '   Dim rows_to_select = 0
                            Try
                                sqlclass.rightcon()
                                Dim select_query As String = "select Tag_id,value,id from Tag_detail_data where value is Null order by id asc"
                                'data_set.Clear()
                                'command for query execution
                                Dim cmd = New SqlCommand(select_query, sqlclass.rightcnn)
                                data_adapter.SelectCommand = cmd
                                'get datatable from database and show in grid
                                ' rows_to_select = data_adapter()
                                data_adapter.Fill(data_table)
                                ' DataGridView2.DataSource = data_table
                                sqlclass.rightcnn.Close()
                            Catch ex As Exception
                                '   MsgBox(ex.Message)
                            End Try




                            Dim available_values_array = receipe_string(Receipe_Load_details(i).Column_number).Split(",")
                            For j = 0 To available_values_array.Length - 1
                                data_table.Rows(j + 1)(0) = tempd(i) + j
                                data_table.Rows(j + 1)(1) = available_values_array(j)
                                '   writeIndb(tempd(i) + j, available_values_array(j), available_values_array(j))
                                '  System.Threading.Thread.Sleep(10)
                            Next
                            data_table.Rows(0)(0) = data_table.Rows(0)(0) + available_values_array.Length
                            ' data_table.Rows(0)(1) = tempd(i) + j
                            'update database
                            Dim sql_cmd_builder As New SqlCommandBuilder
                            sql_cmd_builder = New SqlCommandBuilder(data_adapter)
                            data_adapter.Update(data_table)
                        End If
                    End If

                Next
                '   MsgBox("Loaded Successfully")
            End If

        Catch ex As Exception
            'MsgBox("Something went wrong " & counter1)
            Dim f = finalvalue
            ' MsgBox("Invalid file")
            FILENAME = ""
        End Try



        Return FILENAME
    End Function
    'Dim methodstring = ""
    'Sub write_value(ByVal address As Integer, ByVal valtowrite As String)

    '    If methodstring = "D" Or methodstring = "d" Then
    '        'Write d
    '        valtowrite = Integer.Parse(valtowrite)
    '        plcclass.write_single_DValue(address, valtowrite)
    '    ElseIf methodstring = "M" Or methodstring = "m" Then
    '        'Write m
    '        valtowrite = Integer.Parse(valtowrite)
    '        plcclass.wrtie_m_singlevalue(address, valtowrite)
    '    ElseIf methodstring = "IV" Or methodstring = "iv" Or methodstring = "Iv" Or methodstring = "iV" Then
    '        'Write iv
    '        '   writeIndb(address, valtowrite)
    '    Else
    '        ' writeIndb(address, valtowrite)
    '    End If

    'End Sub



    'this array stores initial(start) tagid for each column according to given tag name for each column
    Dim tempd() As Integer

    'this function assign tagid to ach column
    Sub updatevalue()
        ReDim tempd(Receipe_Load_details.Count - 1)
        sqlclass.rightcon()
        For i = 0 To Receipe_Load_details.Count - 1
            '' Dim querystring As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & Me.Columns(i).DataPropertyName & "' "
            Dim querystring As String = ""
            'for encrypted or  non_encypted tables
            If variableclass.is_encrypted Then
                '    querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & Me.Columns(i).DataPropertyName & "' "
                querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & Me.Receipe_Load_details(i).Tag & "' "

            Else
                'querystring = "select Tag_id from Tag_data  where  Tag_name = '" & Me.Columns(i).DataPropertyName & "' "
                querystring = "select Tag_id from Tag_data  where  Tag_name = '" & Me.Receipe_Load_details(i).Tag & "' "
            End If

            Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sqlclass.rightcnn)
            sqlcmd1.ExecuteNonQuery()
            Using reader As SqlDataReader = sqlcmd1.ExecuteReader
                If reader.Read = True Then
                    tempd(i) = reader.Item("Tag_id") 'gives starting tag_id to each column
                Else
                    tempd(i) = 0
                    If IsNumeric(Me.Receipe_Load_details(i).Tag) Then

                    Else
                        '     Me.ReadOnly = True
                    End If

                End If
            End Using
            sqlcmd1.Dispose()
        Next

        sqlclass.rightcnn.Close()
        ''If tempstopflick = 0 Then
        ''    'to prevent grid from flickring
        ''    EnableDoubleBuffered(Me)
        ''    tempstopflick = 1
        ''End If

    End Sub



    Dim sql As New sqlclass
    Sub writeIndb(ByVal address As Integer, ByVal value As String, ByVal iv_value As String)
        Try
            Dim querystring As String = ""
            If address < variableclass.Iv_tag_start_id Then
                sql.scon2()
                sql.scon3()

                Dim select_query As String = "select Tag_id,value FROM Tag_detail_data where id = '1' "
                Dim cmd1 = New SqlCommand(select_query, sql.scn2)
                Dim reader As SqlDataReader = cmd1.ExecuteReader
                If reader.Read Then
                    If IsDBNull(reader.Item("Tag_id")) = False Then
                        If variableclass.is_encrypted Then
                            querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN  OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update Tag_detail_data set Tag_id = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'1'')) where id = 1 update Tag_detail_data set Tag_id = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & address & "')), value = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & value & "')) where id = 2 COMMIT TRANSACTION"
                        Else
                            querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN update Tag_detail_data set Tag_id = '" & reader.Item(0) + 1 & "' where id = 1 update Tag_detail_data set Tag_id = '" & address & "', value = '" & value & "' where id = '" & reader.Item(0) + 1 & "' COMMIT TRANSACTION"
                        End If
                        Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
                        sqlcmd1.ExecuteNonQuery()
                        sqlcmd1.Dispose()
                    Else
                        If variableclass.is_encrypted Then
                            querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN  OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update Tag_detail_data set Tag_id = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'1'')) where id = 1 update Tag_detail_data set Tag_id = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & address & "')), value = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & value & "')) where id = 2 COMMIT TRANSACTION"
                        Else
                            querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN update Tag_detail_data set Tag_id = '2' where id = 1 update Tag_detail_data set Tag_id = '" & address & "', value = '" & value & "' where id = 2 COMMIT TRANSACTION"
                        End If
                        Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
                        sqlcmd1.ExecuteNonQuery()
                        sqlcmd1.Dispose()
                    End If
                End If
                cmd1.Dispose()
                sql.scn3.Close()
                sql.scn2.Close()
            Else
                sql.scon3()
                If variableclass.is_encrypted Then
                    querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN  OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update Tag_data set  Read_value = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & iv_value & "')) where convert(varchar, decryptbykey(Tag_name)) = '" & address & "' COMMIT TRANSACTION"
                Else
                    querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN update Tag_data set Read_value = '" & iv_value & "' where Tag_id = '" & address & "' COMMIT TRANSACTION"
                End If
                Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
                sqlcmd1.ExecuteNonQuery()
                sqlcmd1.Dispose()
                sql.scn3.Close()
            End If

        Catch ex As Exception

        End Try
    End Sub




    'Public Sub update_tag_detail_data()
    '    Dim custom_datagridview = Me
    '    ' getdata_fromdatabase
    '    Dim data_set As New DataSet
    '    Dim data_adapter As New SqlDataAdapter
    '    Dim data_table As DataTable = New DataTable
    '    Try
    '        sqlclass.rightcon()
    '        Dim select_query As String = "select Tag_id, value, id from Tag_detail_data "
    '        'data_set.Clear()
    '        'command for query execution
    '        Dim cmd = New SqlCommand(select_query, sqlclass.rightcnn)
    '        data_adapter.SelectCommand = cmd
    '        'get datatable from database and show in grid
    '        data_adapter.Fill(data_table)
    '        ' DataGridView2.DataSource = data_table
    '        sqlclass.rightcnn.Close()
    '    Catch ex As Exception
    '        '   MsgBox(ex.Message)
    '    End Try




    '    For data_table

    '        Dim ddval = 0
    '        Dim imgval = 0

    '        Dim available_val_dd = custom_datagridview.Rows(roww).Cells(0).Value
    '        Dim available_val_img = custom_datagridview.Rows(roww).Cells(1).Value

    '        'getting dropdown and image value


    '        Dim dropdownarray = custom_datagridview.ColumnsProperty(0).List_of_DropDownValues
    '        ddval = Array.IndexOf(dropdownarray, available_val_dd)




    '        Dim offimage = custom_datagridview.ColumnsProperty(1).OFF_Image
    '        Dim onimage = custom_datagridview.ColumnsProperty(1).ON_Image

    '        If available_val_img.Equals(onimage) Then
    '            imgval = 1
    '        Else
    '            imgval = 0
    '        End If




    '        data_table.Rows(roww + 1)(1) = ddval
    '        data_table.Rows(roww + 1 + custom_datagridview.RowCount * 1)(1) = imgval
    '        data_table.Rows(roww + 1 + custom_datagridview.RowCount * 2)(1) = custom_datagridview.Rows(roww).Cells(2).Value * custom_datagridview.ColumnsProperty(2).Gain
    '        data_table.Rows(roww + 1 + custom_datagridview.RowCount * 3)(1) = custom_datagridview.Rows(roww).Cells(3).Value * custom_datagridview.ColumnsProperty(3).Gain

    '    Next





    '    'update database
    '    Dim sql_cmd_builder As New SqlCommandBuilder
    '    sql_cmd_builder = New SqlCommandBuilder(data_adapter)
    '    data_adapter.Update(data_table)

    'End Sub






    <TypeConverterAttribute(GetType(System.ComponentModel.ExpandableObjectConverter))> _
    Public Class Columns_Property_Class

        Public Enum var_Type
            Bit_16
            Bit_32
            Binary
            String_

        End Enum
        Dim d_type1
        <Browsable(True), Category("_Misc"), Description("")>
        Property Variable_Type As var_Type
            Get
                Return d_type1
            End Get
            Set(ByVal value As var_Type)
                d_type1 = value

            End Set
        End Property
        Dim gain1 = 1

        Property Gain As Integer
            Get
                Return gain1
            End Get
            Set(ByVal value As Integer)
                ' Button1.Image = value
                gain1 = value
            End Set
        End Property



        Dim colno = 0

        Property Column_number As Integer
            Get
                Return colno
            End Get
            Set(ByVal value As Integer)
                ' Button1.Image = value
                colno = value
            End Set
        End Property


        Dim add
        <Browsable(True), Category("_Misc"), Description("Start Tag ")>
        Property Tag As String
            Get
                Return add
            End Get
            Set(ByVal value As String)
                add = value

            End Set
        End Property

    End Class




End Class
