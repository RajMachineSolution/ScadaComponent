Imports System.Drawing.Design
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms.Design
Imports System.Reflection
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports AxActUtlTypeLib
Imports System.Text.RegularExpressions

Public Class CustomDatagridView
    Dim sql As New sqlclass
    Dim initialised As Boolean = False
    Dim row As Integer
    Dim s3 As New List(Of addcolumn2)
    Dim ddown As New List(Of dropdown2)

    Public namearray() As String
    ' Friend highlight_row As Integer

    ''reference of grid from which columns x and y columns are shown in this
    'Dim AxActUtlType_1 As AxActUtlTypeLib.AxActUtlType

    'Property AxActUtlType1 As AxActUtlTypeLib.AxActUtlType
    '    Get
    '        Return AxActUtlType_1
    '    End Get
    '    Set(ByVal value As AxActUtlTypeLib.AxActUtlType)
    '        AxActUtlType_1 = value
    '    End Set
    'End Property




    Dim column_property As New List(Of Columns_Property_Class)
    <Browsable(True), _
EditorBrowsable(EditorBrowsableState.Always), _
Description("The items with sub items that should be displayed"), _
DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public Property ColumnsProperty As List(Of Columns_Property_Class)
        Get
            Return column_property
        End Get
        Set(ByVal value As List(Of Columns_Property_Class))
            column_property = value
        End Set
    End Property



    <Browsable(False), _
EditorBrowsable(EditorBrowsableState.Always), _
Category("Binding"), _
Description("The items with sub items that should be displayed"), _
DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Property addDropDownValues As List(Of dropdown2)
        Get
            Return ddown

        End Get
        Set(ByVal value As List(Of dropdown2))
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


            Catch ex As Exception
            End Try
        End Set
    End Property
    'Dim iLogicalStationNumber As Integer = 0

    'Property LogicStationNumber As Integer
    '    Get
    '        Return iLogicalStationNumber
    '    End Get
    '    Set(ByVal value As Integer)
    '        iLogicalStationNumber = value
    '    End Set
    'End Property



    Dim readdatatrigger As String
    Property Read_data_Trigger_Tag As String
        Get
            Return readdatatrigger
        End Get
        Set(ByVal value As String)
            readdatatrigger = value
        End Set
    End Property


    Dim read1 As Boolean = True
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
Category("VISIBLE")> _
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
Category("VISIBLE")> _
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
Category("VISIBLE")> _
    Property Vissible_Tag As String


        Get
            Return Vissible_tagname
        End Get
        Set(value As String)
            Vissible_tagname = value

        End Set
    End Property

    '    Dim Address_Of_m_val As Integer = 0
    '    <Browsable(True), _
    'Category("VISIBLE")> _
    '    Property Address_Of_M As Integer


    '        Get
    '            Return Address_Of_m_val
    '        End Get
    '        Set(value As Integer)
    '            Address_Of_m_val = value

    '        End Set
    '    End Property

    Dim row_hlt As String
    Property highlight_row_tag As String
        Get
            Return row_hlt
        End Get
        Set(ByVal value As String)
            ' If value = Nothing Then
            ' Else
            row_hlt = value
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


    Dim namecolumn As String
    <Browsable(False)>
    Property name_column As String
        Get
            Return namecolumn
        End Get
        Set(ByVal value As String)
            namecolumn = value
        End Set
    End Property






    <Browsable(False), _
  EditorBrowsable(EditorBrowsableState.Always), _
  Category("Binding"), _
  Description("The items with sub items that should be displayed"), _
  DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Property ImageColumn As List(Of addcolumn2)
        Get
            Return s3
        End Get
        Set(ByVal value As List(Of addcolumn2))
            s3 = value
        End Set
    End Property



    Dim a As New List(Of DataGridViewColumn)
    Dim b As DataGridViewAutoSizeColumnMode
    Dim c As DataGridViewColumn

    Dim tempvalue = ""


    Private Sub RECIPE_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Me.CellClick

    End Sub



    'Private Sub RECIPE_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Me.CellClick
    '    If e.RowIndex < 0 Then
    '        For Each column As DataGridViewColumn In Me.Columns
    '            column.SortMode = DataGridViewColumnSortMode.NotSortable
    '        Next
    '        Exit Sub
    '    End If


    '    'only Image type column and column index is more than 0

    '    'col type
    '    'd16
    '    'd32
    '    'm'iv

    '    'var_type
    '    'textbox
    '    'image
    '    'dropdown

    '    If e.ColumnIndex >= 0 Then

    '        Dim var_type = column_property(e.ColumnIndex).Variable_Type
    '        Dim col_type = column_property(e.ColumnIndex).Column_Type
    '        Dim add_or_tag = column_property(e.ColumnIndex).Address_or_Tag
    '        Dim action = column_property(e.ColumnIndex).Action


    '        Dim devicetype = ""
    '        Dim variblevalue = 0

    '        'for getting type of used device and address
    '        '   Dim m As Match = Regex.Match(add_or_tag, "^([A-Za-z]+)([0-9]+)(.)([0-9]+)$")
    '        Dim m As Match = Regex.Match(add_or_tag, "^([A-Za-z]+)([0-9]+)$")

    '        If (m.Success) Then
    '            devicetype = m.Groups(1).Value
    '            add_or_tag = m.Groups(2).Value
    '            methodstring = devicetype
    '            Dim a = m.Groups(3).Value
    '            Dim b = m.Groups(4).Value
    '        Else
    '            Exit Sub
    '        End If
    '        ' Dim main_d(8000) As Short
    '        ' Dim myarray(8000) As Short
    '        myarray = getArray(devicetype)




    '        If var_type = 0 Then

    '            If col_type = 0 Then


    '            ElseIf col_type = 1 Then

    '                If action = 0 Then
    '                    'momentary
    '                ElseIf action = 1 Then
    '                    'set
    '                    write_value(Integer.Parse(add_or_tag) + e.RowIndex, 1)
    '                ElseIf action = 2 Then
    '                    'reset
    '                    write_value(Integer.Parse(add_or_tag) + e.RowIndex, 0)
    '                Else
    '                    'toggle
    '                    If myarray(Integer.Parse(add_or_tag) + e.RowIndex) = 0 Then
    '                        write_value(Integer.Parse(add_or_tag) + e.RowIndex, 1)
    '                    Else
    '                        write_value(Integer.Parse(add_or_tag) + e.RowIndex, 0)
    '                    End If
    '                End If



    '            Else



    '            End If


    '        ElseIf var_type = 1 Then

    '            If col_type = 0 Then


    '            ElseIf col_type = 1 Then


    '                Dim ByteArr(3) As Byte
    '                For k = 0 To 1
    '                    'Dim Temp_Byte = BitConverter.GetBytes(list(i)((roww * 2) + k))
    '                    Dim Temp_Byte = BitConverter.GetBytes(myarray((Integer.Parse(add_or_tag) + e.RowIndex * 2) + k))

    '                    ByteArr(k * 2) = Temp_Byte(0)
    '                    ByteArr(k * 2 + 1) = Temp_Byte(1)
    '                Next
    '                Dim Temp_Int As Integer = BitConverter.ToInt32(ByteArr, 0)


    '                If action = 0 Then
    '                    'momentary
    '                ElseIf action = 1 Then
    '                    'set
    '                    Dim tempvtw = "1"
    '                    '32 bit to 16 bit converterssss
    '                    Dim Byte_Arr(3) As Byte
    '                    Byte_Arr = BitConverter.GetBytes(Convert.ToInt32(tempvtw))
    '                    'this is used when for loop is used in an main form "compare" sub
    '                    '--variableclass.wd(WriteAddress) = BitConverter.ToInt16(Byte_Arr, 0)
    '                    '--variableclass.wd(WriteAddress + 1) = BitConverter.ToInt16(Byte_Arr, 2)
    '                    write_value(Integer.Parse(add_or_tag) + e.RowIndex * 2, BitConverter.ToInt16(Byte_Arr, 0))
    '                    write_value(Integer.Parse(add_or_tag) + e.RowIndex * 2 + 1, BitConverter.ToInt16(Byte_Arr, 2))
    '                ElseIf action = 2 Then
    '                    'reset
    '                    Dim tempvtw = "0"
    '                    '32 bit to 16 bit converterssss
    '                    Dim Byte_Arr(3) As Byte
    '                    Byte_Arr = BitConverter.GetBytes(Convert.ToInt32(tempvtw))
    '                    'this is used when for loop is used in an main form "compare" sub
    '                    '--variableclass.wd(WriteAddress) = BitConverter.ToInt16(Byte_Arr, 0)
    '                    '--variableclass.wd(WriteAddress + 1) = BitConverter.ToInt16(Byte_Arr, 2)
    '                    write_value(Integer.Parse(add_or_tag) + e.RowIndex * 2, BitConverter.ToInt16(Byte_Arr, 0))
    '                    write_value(Integer.Parse(add_or_tag) + e.RowIndex * 2 + 1, BitConverter.ToInt16(Byte_Arr, 2))
    '                Else
    '                    'toggle

    '                    If Temp_Int = 0 Then
    '                        'write_value(Integer.Parse(add_or_tag) + e.RowIndex, 1)

    '                        Dim tempvtw = "1"
    '                        '32 bit to 16 bit converterssss
    '                        Dim Byte_Arr(3) As Byte
    '                        Byte_Arr = BitConverter.GetBytes(Convert.ToInt32(tempvtw))
    '                        'this is used when for loop is used in an main form "compare" sub
    '                        '--variableclass.wd(WriteAddress) = BitConverter.ToInt16(Byte_Arr, 0)
    '                        '--variableclass.wd(WriteAddress + 1) = BitConverter.ToInt16(Byte_Arr, 2)
    '                        write_value(Integer.Parse(add_or_tag) + e.RowIndex * 2, BitConverter.ToInt16(Byte_Arr, 0))
    '                        write_value(Integer.Parse(add_or_tag) + e.RowIndex * 2 + 1, BitConverter.ToInt16(Byte_Arr, 2))
    '                    Else
    '                        ' write_value(Integer.Parse(add_or_tag) + e.RowIndex, 0)
    '                        Dim tempvtw = "0"
    '                        '32 bit to 16 bit converterssss
    '                        Dim Byte_Arr(3) As Byte
    '                        Byte_Arr = BitConverter.GetBytes(Convert.ToInt32(tempvtw))
    '                        'this is used when for loop is used in an main form "compare" sub
    '                        '--variableclass.wd(WriteAddress) = BitConverter.ToInt16(Byte_Arr, 0)
    '                        '--variableclass.wd(WriteAddress + 1) = BitConverter.ToInt16(Byte_Arr, 2)
    '                        write_value(Integer.Parse(add_or_tag) + e.RowIndex * 2, BitConverter.ToInt16(Byte_Arr, 0))
    '                        write_value(Integer.Parse(add_or_tag) + e.RowIndex * 2 + 1, BitConverter.ToInt16(Byte_Arr, 2))
    '                    End If
    '                End If




    '            Else


    '            End If

    '        ElseIf var_type = 2 Then
    '            If col_type = 0 Then

    '            ElseIf col_type = 1 Then

    '                If action = 0 Then
    '                    'momentary
    '                ElseIf action = 1 Then
    '                    'set
    '                    write_value(Integer.Parse(add_or_tag) + e.RowIndex, 1)
    '                ElseIf action = 2 Then
    '                    'reset
    '                    write_value(Integer.Parse(add_or_tag) + e.RowIndex, 0)
    '                Else
    '                    'toggle
    '                    If myarray(Integer.Parse(add_or_tag) + e.RowIndex) = 0 Then
    '                        write_value(Integer.Parse(add_or_tag) + e.RowIndex, 1)
    '                    Else
    '                        write_value(Integer.Parse(add_or_tag) + e.RowIndex, 0)
    '                    End If
    '                End If




    '            Else

    '            End If
    '        Else
    '            If col_type = 0 Then

    '            ElseIf col_type = 1 Then


    '                If action = 0 Then
    '                    'momentary
    '                ElseIf action = 1 Then
    '                    'set
    '                    write_value(tempd(Me.CurrentCell.ColumnIndex) + e.RowIndex, "1")
    '                ElseIf action = 2 Then
    '                    'reset
    '                    write_value(tempd(Me.CurrentCell.ColumnIndex) + e.RowIndex, "0")
    '                Else
    '                    'toggle
    '                    If variableclass.tag(tempd(Me.CurrentCell.ColumnIndex) + e.RowIndex) = "0" Then
    '                        write_value(tempd(Me.CurrentCell.ColumnIndex) + e.RowIndex, "1")
    '                    Else
    '                        write_value(tempd(Me.CurrentCell.ColumnIndex) + e.RowIndex, "0")
    '                    End If

    '                End If





    '            Else

    '            End If
    '        End If





    '    End If



    'End Sub

    Dim methodstring As String
    Dim myarray(8000) As Short
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
    '        writeIndb(address, valtowrite)
    '    Else
    '        writeIndb(address, valtowrite)
    '    End If

    'End Sub

    Private Sub CustomDatagridView_ReadOnlyChanged(sender As Object, e As System.EventArgs) Handles Me.ReadOnlyChanged
        Dim k = 0
    End Sub









    Private Sub CustomDatagridView_SelectionChanged(sender As Object, e As System.EventArgs) Handles Me.SelectionChanged

        ''Dim i As Integer
        ''i = Me.CurrentRow.Index
        ''If i > 0 Then
        ''    writeIndb(tempd(2) + i, Me.Rows(i - 1).Cells(2).Value * column_property(2).Gain)
        ''    writeIndb(tempd(3) + i, Me.Rows(i - 1).Cells(3).Value * column_property(3).Gain)
        ''    ' Me.Rows(i).Cells(0).Value = Me.Rows(i - 1).Cells(0).Value
        ''    'Me.Rows(i).Cells(1).Value = Me.Rows(i - 1).Cells(1).Value
        ''    'Me.Rows(i).Cells(2).Value = Me.Rows(i - 1).Cells(2).Value
        ''End If
        'custom code



    End Sub


    Public row_repeate = False

    Private Sub CustomDatagridView_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles Me.CellBeginEdit


        ''custom code  for not editing first row first call
        'If e.RowIndex = 0 And e.ColumnIndex = 0 Then
        '    writeIndb(tempd(0), 9)
        '    e.Cancel = True
        'End If

        'custom code
        'For making first row first column readonly

        If e.RowIndex = 0 And e.ColumnIndex = 0 Then
            writeIndb(tempd(0), 9, 9)
            e.Cancel = True
        End If






        'custom code for row repeate

        If row_repeate Then

            Dim custom_datagridview = Me

            Dim i As Integer
            i = Me.CurrentRow.Index
            If i > 1 Then


                Dim ddval = 0
                Dim imgval = 0

                Dim available_val_dd = custom_datagridview.Rows(i - 1).Cells(0).Value
                Dim available_val_img = custom_datagridview.Rows(i - 1).Cells(1).Value

                'getting dropdown and image value


                Dim dropdownarray = custom_datagridview.ColumnsProperty(0).List_of_DropDownValues
                ddval = Array.IndexOf(dropdownarray, available_val_dd)




                Dim offimage = custom_datagridview.ColumnsProperty(1).OFF_Image
                Dim onimage = custom_datagridview.ColumnsProperty(1).ON_Image

                If available_val_img.Equals(onimage) Then
                    imgval = 1
                Else
                    imgval = 0
                End If


                ' If tagvalue(tempd(2) + i) = 0 Then
                If Me.Rows(i - 1).Cells(0).Value <> "" And Me.Rows(i).Cells(0).Value = "" Then
                    Me.Rows(i).Cells(0).Value = Me.Rows(i - 1).Cells(0).Value
                    Me.Rows(i).Cells(1).Value = Me.Rows(i - 1).Cells(1).Value
                    Me.Rows(i).Cells(2).Value = Me.Rows(i - 1).Cells(2).Value
                    Me.Rows(i).Cells(3).Value = Me.Rows(i - 1).Cells(3).Value


                    writeIndb(tempd(0) + i, ddval, ddval)

                    If Me.Rows(i).Cells(2).Value.ToString.Contains("+") Then
                        writeIndb(tempd(1) + i, 1, 1)
                    Else
                        writeIndb(tempd(1) + i, imgval, imgval)
                    End If

                    writeIndb(tempd(2) + i, Me.Rows(i - 1).Cells(2).Value * custom_datagridview.ColumnsProperty(2).Gain, Me.Rows(i - 1).Cells(2).Value * custom_datagridview.ColumnsProperty(2).Gain)
                    writeIndb(tempd(3) + i, Me.Rows(i - 1).Cells(3).Value * custom_datagridview.ColumnsProperty(3).Gain, Me.Rows(i - 1).Cells(3).Value * custom_datagridview.ColumnsProperty(3).Gain)

                End If

                'End If

            End If

        End If






        ''Try
        ''    If variableclass.onscreenkeyboard = True Then

        ''        '  Process.Start(FileToCopy, "scadatagsystem rmsview rmsview")
        ''        Dim pProcess() As Process = System.Diagnostics.Process.GetProcessesByName("finalKeyboarddesigned")
        ''        If pProcess.Count > 0 Then
        ''        Else
        ''            Dim FileToCopy = Application.StartupPath & "\resource\finalKeyboarddesigned.exe"
        ''            Dim startInfo As ProcessStartInfo = New ProcessStartInfo(FileToCopy)
        ''            Process.Start(startInfo)

        ''        End If
        ''    End If

        ''Catch ex As Exception
        ''    MessageBox.Show(ex.Message)
        ''End Try


    End Sub

    Private Sub cell_endedit(ByVal sender As Object, ByVal e As EventArgs)
        ' Private Sub RECIPE_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Me.CellLeave

        Try



            'only textbox type

            Dim var_type = column_property(Me.CurrentCell.ColumnIndex).Variable_Type
            Dim col_type = column_property(Me.CurrentCell.ColumnIndex).Column_Type
            Dim add_or_tag = column_property(Me.CurrentCell.ColumnIndex).Tag
            Dim inputtype2 = column_property(Me.CurrentCell.ColumnIndex).InputType
            Dim gain2 = column_property(Me.CurrentCell.ColumnIndex).Gain
            Dim noofdecimal = column_property((Me.CurrentCell.ColumnIndex)).No_of_DecimalValues



            Dim devicetype = ""
            Dim variblevalue = 0

            'for getting type of used device and address
            '   Dim m As Match = Regex.Match(add_or_tag, "^([A-Za-z]+)([0-9]+)(.)([0-9]+)$")
            ''Dim m As Match = Regex.Match(add_or_tag, "^([A-Za-z]+)([0-9]+)$")

            ''If (m.Success) Then
            ''    devicetype = m.Groups(1).Value
            ''    add_or_tag = m.Groups(2).Value
            ''    methodstring = devicetype
            ''    myarray = getArray(devicetype)
            ''    Dim a = m.Groups(3).Value
            ''    Dim b = m.Groups(4).Value
            ''Else
            ''    '  myarray = getArray("IV")
            ''    If var_type > 2 Then
            ''        methodstring = devicetype
            ''    Else
            ''        '  Exit Sub

            ''    End If
            ''End If





            If var_type = 0 Then

                If col_type = 0 Then
                    ''
                    Try
                        If IsNumeric(Me.Rows(Me.CurrentCell.RowIndex).Cells(Me.CurrentCell.ColumnIndex).Value) Then
                            If gain2 > 1 Then
                                writeIndb(tempd(Me.CurrentCell.ColumnIndex) + Me.CurrentCell.RowIndex, (Me.Rows(Me.CurrentCell.RowIndex).Cells(Me.CurrentCell.ColumnIndex).Value) * gain2, (Me.Rows(Me.CurrentCell.RowIndex).Cells(Me.CurrentCell.ColumnIndex).Value) * gain2)
                            Else
                                writeIndb(tempd(Me.CurrentCell.ColumnIndex) + Me.CurrentCell.RowIndex, (Me.Rows(Me.CurrentCell.RowIndex).Cells(Me.CurrentCell.ColumnIndex).Value), (Me.Rows(Me.CurrentCell.RowIndex).Cells(Me.CurrentCell.ColumnIndex).Value))
                            End If

                        End If
                    Catch ex As Exception
                        MessageBox.Show("Value Overflow", "Alert")
                    End Try

                ElseIf col_type = 1 Then


                Else



                End If


            ElseIf var_type = 1 Then

                If col_type = 0 Then
                    ''
                    Try

                        If IsNumeric(Me.Rows(Me.CurrentCell.RowIndex).Cells(Me.CurrentCell.ColumnIndex).Value) Then
                            Dim tempvtw = Me.Rows(Me.CurrentCell.RowIndex).Cells(Me.CurrentCell.ColumnIndex).Value
                            If gain2 > 1 Then
                                tempvtw = tempvtw * gain2
                            End If


                            '32 bit to 16 bit converterssss
                            Dim Byte_Arr(3) As Byte
                            Byte_Arr = BitConverter.GetBytes(Convert.ToInt32(tempvtw))
                            ' writeIndb(Integer.Parse(add_or_tag) + e.RowIndex * 2, BitConverter.ToInt16(Byte_Arr, 0))
                            'writeIndb(Integer.Parse(add_or_tag) + e.RowIndex * 2 + 1, BitConverter.ToInt16(Byte_Arr, 2))

                            Dim finalvalue = BitConverter.ToInt16(Byte_Arr, 0) & "," & BitConverter.ToInt16(Byte_Arr, 2)

                            writeIndb(tempd(Me.CurrentCell.ColumnIndex) + Me.CurrentCell.RowIndex, finalvalue, tempvtw)
                        End If

                    Catch ex As Exception
                        MessageBox.Show("Value Overflow", "Alert")
                    End Try

                ElseIf col_type = 1 Then


                Else


                End If

            ElseIf var_type = 2 Then
                If col_type = 0 Then
                    ''
                    If IsNumeric(Me.Rows(Me.CurrentCell.RowIndex).Cells(Me.CurrentCell.ColumnIndex).Value) Then
                        If myarray(Integer.Parse(add_or_tag) + Me.CurrentCell.RowIndex) = 0 Then
                            If Integer.Parse(Me.Rows(Me.CurrentCell.RowIndex).Cells(Me.CurrentCell.ColumnIndex).Value) > 0 Then
                                writeIndb(tempd(Me.CurrentCell.ColumnIndex) + Me.CurrentCell.RowIndex, 1, 1)
                            End If

                        Else
                            If Integer.Parse(Me.Rows(Me.CurrentCell.RowIndex).Cells(Me.CurrentCell.ColumnIndex).Value) = 0 Then
                                writeIndb(tempd(Me.CurrentCell.ColumnIndex) + Me.CurrentCell.RowIndex, Me.Rows(Me.CurrentCell.RowIndex).Cells(Me.CurrentCell.ColumnIndex).Value, Me.Rows(Me.CurrentCell.RowIndex).Cells(Me.CurrentCell.ColumnIndex).Value)
                            End If

                        End If
                    End If


                ElseIf col_type = 1 Then

                Else

                End If
            Else
                If col_type = 0 Then

                    If inputtype2 = 0 Then
                        If IsNumeric(Me.Rows(Me.CurrentCell.RowIndex).Cells(Me.CurrentCell.ColumnIndex).Value) Then
                            'write_value(tempd(Me.CurrentCell.ColumnIndex) + e.RowIndex, Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
                            If gain2 > 1 Then
                                writeIndb(tempd(Me.CurrentCell.ColumnIndex) + Me.CurrentCell.RowIndex, (Me.Rows(Me.CurrentCell.RowIndex).Cells(Me.CurrentCell.ColumnIndex).Value) * gain2, (Me.Rows(Me.CurrentCell.RowIndex).Cells(Me.CurrentCell.ColumnIndex).Value) * gain2)
                            Else
                                writeIndb(tempd(Me.CurrentCell.ColumnIndex) + Me.CurrentCell.RowIndex, (Me.Rows(Me.CurrentCell.RowIndex).Cells(Me.CurrentCell.ColumnIndex).Value), (Me.Rows(Me.CurrentCell.RowIndex).Cells(Me.CurrentCell.ColumnIndex).Value))
                            End If
                        Else
                            If IsNothing(Me.Rows(Me.CurrentCell.RowIndex).Cells(Me.CurrentCell.ColumnIndex).Value) Then
                                writeIndb(tempd(Me.CurrentCell.ColumnIndex) + Me.CurrentCell.RowIndex, "", "")
                            End If
                            'MsgBox("INVALID INPUT")
                        End If
                    Else
                        writeIndb(tempd(Me.CurrentCell.ColumnIndex) + Me.CurrentCell.RowIndex, Me.Rows(Me.CurrentCell.RowIndex).Cells(Me.CurrentCell.ColumnIndex).Value, Me.Rows(Me.CurrentCell.RowIndex).Cells(Me.CurrentCell.ColumnIndex).Value)

                    End If



                ElseIf col_type = 1 Then




                Else

                End If
            End If


            'custom code

            ' write_value(tempd(e.ColumnIndex) + e.RowIndex, Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

            Dim entered_value As String = Me.Rows(Me.CurrentCell.RowIndex).Cells(Me.CurrentCell.ColumnIndex).Value

            If entered_value.Contains("+") Then
                writeIndb(tempd(1) + Me.CurrentCell.RowIndex, 1, 1)
                '  Me.Rows(e.RowIndex).Cells(1).Value = My.Resources.Resources.plus12

            Else
                ' Me.Rows(e.RowIndex).Cells(1).Value = My.Resources.Resources.normal3
            End If

        Catch ex As Exception
            '  MsgBox("INVALID INPUT")
        End Try





    End Sub


   



    Private Sub RECIPE_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)  ' Handles Me.CellEndEdit
        ' Private Sub RECIPE_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Me.CellLeave

        Try



            'only textbox type

            Dim var_type = column_property(e.ColumnIndex).Variable_Type
            Dim col_type = column_property(e.ColumnIndex).Column_Type
            Dim add_or_tag = column_property(e.ColumnIndex).Tag
            Dim inputtype2 = column_property(e.ColumnIndex).InputType
            Dim gain2 = column_property(e.ColumnIndex).Gain
            Dim noofdecimal = column_property((e.ColumnIndex)).No_of_DecimalValues



            Dim devicetype = ""
            Dim variblevalue = 0

            'for getting type of used device and address
            '   Dim m As Match = Regex.Match(add_or_tag, "^([A-Za-z]+)([0-9]+)(.)([0-9]+)$")
            ''Dim m As Match = Regex.Match(add_or_tag, "^([A-Za-z]+)([0-9]+)$")

            ''If (m.Success) Then
            ''    devicetype = m.Groups(1).Value
            ''    add_or_tag = m.Groups(2).Value
            ''    methodstring = devicetype
            ''    myarray = getArray(devicetype)
            ''    Dim a = m.Groups(3).Value
            ''    Dim b = m.Groups(4).Value
            ''Else
            ''    '  myarray = getArray("IV")
            ''    If var_type > 2 Then
            ''        methodstring = devicetype
            ''    Else
            ''        '  Exit Sub

            ''    End If
            ''End If





            If var_type = 0 Then

                If col_type = 0 Then
                    ''
                    Try
                        If IsNumeric(Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                            If gain2 > 1 Then
                                writeIndb(tempd(e.ColumnIndex) + e.RowIndex, (Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) * gain2, (Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) * gain2)
                            Else
                                writeIndb(tempd(e.ColumnIndex) + e.RowIndex, (Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), (Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value))
                            End If

                        End If
                    Catch ex As Exception
                        MessageBox.Show("Value Overflow", "Alert")
                    End Try

                ElseIf col_type = 1 Then


                Else



                End If


            ElseIf var_type = 1 Then

                If col_type = 0 Then
                    ''
                    Try

                        If IsNumeric(Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                            Dim tempvtw = Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                            If gain2 > 1 Then
                                tempvtw = tempvtw * gain2
                            End If


                            '32 bit to 16 bit converterssss
                            Dim Byte_Arr(3) As Byte
                            Byte_Arr = BitConverter.GetBytes(Convert.ToInt32(tempvtw))
                            ' writeIndb(Integer.Parse(add_or_tag) + e.RowIndex * 2, BitConverter.ToInt16(Byte_Arr, 0))
                            'writeIndb(Integer.Parse(add_or_tag) + e.RowIndex * 2 + 1, BitConverter.ToInt16(Byte_Arr, 2))

                            Dim finalvalue = BitConverter.ToInt16(Byte_Arr, 0) & "," & BitConverter.ToInt16(Byte_Arr, 2)

                            writeIndb(tempd(e.ColumnIndex) + e.RowIndex, finalvalue, tempvtw)
                        End If

                    Catch ex As Exception
                        MessageBox.Show("Value Overflow", "Alert")
                    End Try

                ElseIf col_type = 1 Then


                Else


                End If

            ElseIf var_type = 2 Then
                If col_type = 0 Then
                    ''
                    If IsNumeric(Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                        If myarray(Integer.Parse(add_or_tag) + e.RowIndex) = 0 Then
                            If Integer.Parse(Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) > 0 Then
                                writeIndb(tempd(e.ColumnIndex) + e.RowIndex, 1, 1)
                            End If

                        Else
                            If Integer.Parse(Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) = 0 Then
                                writeIndb(tempd(e.ColumnIndex) + e.RowIndex, Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
                            End If

                        End If
                    End If


                ElseIf col_type = 1 Then

                Else

                End If
            Else
                If col_type = 0 Then

                    If inputtype2 = 0 Then
                        If IsNumeric(Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                            'write_value(tempd(Me.CurrentCell.ColumnIndex) + e.RowIndex, Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
                            If gain2 > 1 Then
                                writeIndb(tempd(e.ColumnIndex) + e.RowIndex, (Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) * gain2, (Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) * gain2)
                            Else
                                writeIndb(tempd(e.ColumnIndex) + e.RowIndex, (Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), (Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value))
                            End If
                        Else
                            If IsNothing(Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                                writeIndb(tempd(e.ColumnIndex) + e.RowIndex, "", "")
                            End If
                            'MsgBox("INVALID INPUT")
                        End If
                    Else
                        writeIndb(tempd(e.ColumnIndex) + e.RowIndex, Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

                    End If



                ElseIf col_type = 1 Then




                Else

                End If
            End If


            'custom code

            ' write_value(tempd(e.ColumnIndex) + e.RowIndex, Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

            Dim entered_value As String = Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value

            If entered_value.Contains("+") Then
                writeIndb(tempd(1) + e.RowIndex, 1, 1)
                '  Me.Rows(e.RowIndex).Cells(1).Value = My.Resources.Resources.plus12

            Else
                ' Me.Rows(e.RowIndex).Cells(1).Value = My.Resources.Resources.normal3
            End If

        Catch ex As Exception
            '  MsgBox("INVALID INPUT")
        End Try





    End Sub

    Public Sub add_row()
        Dim custom_datagridview = Me
        ' getdata_fromdatabase
        Dim data_set As New DataSet
        Dim data_adapter As New SqlDataAdapter
        Dim data_table As DataTable = New DataTable
        Try
            sqlclass.rightcon()
            Dim select_query As String = "select Tag_name, Read_value, Tag_id from Tag_data where tag_name like 'receipe%' order by Tag_id asc"
            'data_set.Clear()
            'command for query execution
            Dim cmd = New SqlCommand(select_query, sqlclass.rightcnn)
            data_adapter.SelectCommand = cmd
            'get datatable from database and show in grid
            data_adapter.Fill(data_table)
            ' DataGridView2.DataSource = data_table
            sqlclass.rightcnn.Close()
        Catch ex As Exception
            '   MsgBox(ex.Message)
        End Try


        Dim i = custom_datagridview.CurrentRow.Index

        If i <= 0 Then
            Exit Sub
        End If


        For roww = 98 To i Step -1

            Dim ddval = 0
            Dim imgval = 0

            Dim available_val_dd = custom_datagridview.Rows(roww).Cells(0).Value
            Dim available_val_img = custom_datagridview.Rows(roww).Cells(1).Value

            'getting dropdown and image value


            Dim dropdownarray = custom_datagridview.ColumnsProperty(0).List_of_DropDownValues
            ddval = Array.IndexOf(dropdownarray, available_val_dd)




            Dim offimage = custom_datagridview.ColumnsProperty(1).OFF_Image
            Dim onimage = custom_datagridview.ColumnsProperty(1).ON_Image

            If available_val_img.Equals(onimage) Then
                imgval = 1
            Else
                imgval = 0
            End If




            data_table.Rows(roww + 1)(1) = ddval
            data_table.Rows(roww + 1 + custom_datagridview.RowCount * 1)(1) = imgval
            data_table.Rows(roww + 1 + custom_datagridview.RowCount * 2)(1) = custom_datagridview.Rows(roww).Cells(2).Value * custom_datagridview.ColumnsProperty(2).Gain
            data_table.Rows(roww + 1 + custom_datagridview.RowCount * 3)(1) = custom_datagridview.Rows(roww).Cells(3).Value * custom_datagridview.ColumnsProperty(3).Gain

        Next

        data_table.Rows(i)(1) = 0
        data_table.Rows(i + custom_datagridview.RowCount * 1)(1) = 0
        data_table.Rows(i + custom_datagridview.RowCount * 2)(1) = 0
        data_table.Rows(i + custom_datagridview.RowCount * 3)(1) = 0



        'update database
        Dim sql_cmd_builder As New SqlCommandBuilder
        sql_cmd_builder = New SqlCommandBuilder(data_adapter)
        data_adapter.Update(data_table)

    End Sub


    Public Sub remove_row()

        Dim custom_datagridview = Me
        ' getdata_fromdatabase
        Dim data_set As New DataSet
        Dim data_adapter As New SqlDataAdapter
        Dim data_table As DataTable = New DataTable
        Try
            sqlclass.rightcon()
            Dim select_query As String = "select Tag_name, Read_value, Tag_id from Tag_data where tag_name like 'receipe%' order by Tag_id asc"
            'data_set.Clear()
            'command for query execution
            Dim cmd = New SqlCommand(select_query, sqlclass.rightcnn)
            data_adapter.SelectCommand = cmd
            'get datatable from database and show in grid
            data_adapter.Fill(data_table)
            ' DataGridView2.DataSource = data_table
            sqlclass.rightcnn.Close()
        Catch ex As Exception
            '   MsgBox(ex.Message)
        End Try


        Dim i = custom_datagridview.CurrentRow.Index

        If i <= 0 Then
            Exit Sub
        End If



        For roww = i To custom_datagridview.RowCount - 2

            Dim ddval = 0
            Dim imgval = 0

            Dim available_val_dd = custom_datagridview.Rows(roww + 1).Cells(0).Value
            Dim available_val_img = custom_datagridview.Rows(roww + 1).Cells(1).Value

            'getting dropdown and image value


            Dim dropdownarray = custom_datagridview.ColumnsProperty(0).List_of_DropDownValues
            ddval = Array.IndexOf(dropdownarray, available_val_dd)




            Dim offimage = custom_datagridview.ColumnsProperty(1).OFF_Image
            Dim onimage = custom_datagridview.ColumnsProperty(1).ON_Image

            If available_val_img.Equals(onimage) Then
                imgval = 1
            Else
                imgval = 0
            End If


            data_table.Rows(roww)(1) = ddval
            data_table.Rows(roww + custom_datagridview.RowCount * 1)(1) = imgval
            data_table.Rows(roww + custom_datagridview.RowCount * 2)(1) = custom_datagridview.Rows(roww + 1).Cells(2).Value * custom_datagridview.ColumnsProperty(2).Gain
            data_table.Rows(roww + custom_datagridview.RowCount * 3)(1) = custom_datagridview.Rows(roww + 1).Cells(3).Value * custom_datagridview.ColumnsProperty(3).Gain

        Next


        data_table.Rows(99)(1) = 0
        data_table.Rows(99 + custom_datagridview.RowCount * 1)(1) = 0
        data_table.Rows(99 + custom_datagridview.RowCount * 2)(1) = 0
        data_table.Rows(99 + custom_datagridview.RowCount * 3)(1) = 0





        'update database
        Dim sql_cmd_builder As New SqlCommandBuilder
        sql_cmd_builder = New SqlCommandBuilder(data_adapter)
        data_adapter.Update(data_table)



    End Sub

    Public Sub clear_data()

        'custom code
        Dim length As Double


        Dim custom_datagridview = Me
        ' getdata_fromdatabase
        Dim data_set As New DataSet
        Dim data_adapter As New SqlDataAdapter
        Dim data_table As DataTable = New DataTable
        Try
            sqlclass.rightcon()
            Dim select_query As String = "select Tag_name, Read_value, Tag_id from Tag_data where tag_name like 'receipe%' order by Tag_id asc"
            'data_set.Clear()
            'command for query execution
            Dim cmd = New SqlCommand(select_query, sqlclass.rightcnn)
            data_adapter.SelectCommand = cmd
            'get datatable from database and show in grid
            data_adapter.Fill(data_table)
            ' DataGridView2.DataSource = data_table
            sqlclass.rightcnn.Close()
        Catch ex As Exception
            '   MsgBox(ex.Message)
        End Try


        '    Dim i = custom_datagridview.CurrentRow.Index


        For roww = 0 To Me.RowCount - 1



            Dim x = getAbsoluteValue(roww)
            '  Dim value = Me.Rows(roww).Cells(2).Value
            ' writeIndb(tempd(1) + roww, 0)
            ' writeIndb(tempd(2) + roww, (length - x) * gain2)

            data_table.Rows(roww + custom_datagridview.RowCount * 0)(1) = 0
            data_table.Rows(roww + custom_datagridview.RowCount * 1)(1) = 0
            data_table.Rows(roww + custom_datagridview.RowCount * 2)(1) = 0
            data_table.Rows(roww + custom_datagridview.RowCount * 3)(1) = 0





        Next






        'update database
        Dim sql_cmd_builder As New SqlCommandBuilder
        sql_cmd_builder = New SqlCommandBuilder(data_adapter)
        data_adapter.Update(data_table)





    End Sub


    Public Sub exchange_length()
        'custom code
        Dim length As Double


        Dim custom_datagridview = Me
        ' getdata_fromdatabase
        Dim data_set As New DataSet
        Dim data_adapter As New SqlDataAdapter
        Dim data_table As DataTable = New DataTable
        Try
            sqlclass.rightcon()
            Dim select_query As String = "select Tag_name, Read_value, Tag_id from Tag_data where tag_name like 'receipe%' order by Tag_id asc"
            'data_set.Clear()
            'command for query execution
            Dim cmd = New SqlCommand(select_query, sqlclass.rightcnn)
            data_adapter.SelectCommand = cmd
            'get datatable from database and show in grid
            data_adapter.Fill(data_table)
            ' DataGridView2.DataSource = data_table
            sqlclass.rightcnn.Close()
        Catch ex As Exception
            '   MsgBox(ex.Message)
        End Try


        Dim i = custom_datagridview.CurrentRow.Index


        For roww = 0 To Me.RowCount - 1


            If roww = 0 Then
                length = Me.Rows(roww).Cells(2).Value
            Else
                Dim x = getAbsoluteValue(roww)
                '  Dim value = Me.Rows(roww).Cells(2).Value
                ' writeIndb(tempd(1) + roww, 0)
                ' writeIndb(tempd(2) + roww, (length - x) * gain2)

                data_table.Rows(roww + custom_datagridview.RowCount * 1)(1) = 0
                data_table.Rows(roww + custom_datagridview.RowCount * 2)(1) = (length - x) * column_property(2).Gain
                '   Me.BeginEdit()
                '  Me.CurrentCell = Me.Rows(roww).Cells(2)
                ''''  Me.Rows(roww).Cells(2).Value = (length - x) * gain2
                ' Me.CommitEdit(DataGridViewDataErrorContexts.Commit)
                ' Me.RECIPE_CellEndEdit(Me, roww)
                '  Me.CurrentCell = Me.Rows(roww).Cells(3)
                '  Me.EndEdit()
                ' Me.CurrentCell = Me.Rows(roww).Cells(3)

                '   SendKeys.Send("{TAB}")
            End If



        Next






        'update database
        Dim sql_cmd_builder As New SqlCommandBuilder
        sql_cmd_builder = New SqlCommandBuilder(data_adapter)
        data_adapter.Update(data_table)






    End Sub

    Dim last_x_value As Double
    Public Function getAbsoluteValue(ByVal i As Integer)



        If i = 0 Then
            last_x_value = 0
            Exit Function
        End If

        'Dim ddval = 0
        Dim imgval = 0
        'Dim available_val_dd = Sourcegrid.Rows(i).Cells(0).Value
        Dim available_val_img = Me.Rows(i).Cells(1).Value

        'getting dropdown and image value

        ' Dim cdgv As scadacomponent.CustomDatagridView = CType(Sourcegrid, scadacomponent.CustomDatagridView)

        '   If TypeOf Sourcegrid.Rows(i).Cells(0).Value Is DataGridViewComboBoxCell Then

        '    Dim dropdownarray = cdgv.ColumnsProperty(0).List_of_DropDownValues
        ' ddval = Array.IndexOf(dropdownarray, available_val_dd)
        ' End If

        'If TypeOf Sourcegrid.Rows(i).Cells(1).Value Is DataGridViewImageCell Then

        Dim offimage = Me.ColumnsProperty(1).OFF_Image
        Dim onimage = Me.ColumnsProperty(1).ON_Image

        If available_val_img.Equals(onimage) Then
            imgval = 1
        Else
            imgval = 0
        End If


        ' End If


        'getting X and Y current cell value
        Dim x_value As Double = Me.Rows(i).Cells(2).Value
        Dim y_value As Double = Me.Rows(i).Cells(3).Value

        Dim temp_x_value As Double = x_value

        If imgval = 1 Then
            x_value = x_value + last_x_value
            last_x_value = x_value
            Return x_value
        Else
            last_x_value = x_value
            Return x_value
        End If

        'If ddval = 1 Or ddval = 2 Or ddval = 3 Then


        '    destinationgrid1.Rows.Add(1)
        '    destinationgrid1.Rows(source_grid_index1).Cells(0).Value = x_value
        '    destinationgrid1.Rows(source_grid_index1).Cells(1).Value = y_value
        '    source_grid_index1 = source_grid_index1 + 1

        'ElseIf ddval = 4 Or ddval = 5 Or ddval = 6 Then


        '    destinationgrid2.Rows.Add(1)
        '    destinationgrid2.Rows(source_grid_index2).Cells(0).Value = x_value
        '    destinationgrid2.Rows(source_grid_index2).Cells(1).Value = y_value
        '    source_grid_index2 = source_grid_index2 + 1
        'End If

        'If ddval <> 9 Then
        '    last_x_value = temp_x_value


        'End If


        '  destinationgrid.Rows(i).Cells(0).Value = Sourcegrid.Rows(i).Cells(2).Value
        '  destinationgrid.Rows(i).Cells(1).Value = Sourcegrid.Rows(i).Cells(3).Value





        'CustomDatagridView5.ColumnCount
        'DataGridView.CurrentCell.Value = newValue.ToString()
    End Function




    Public Sub exchange_dropdown(ByVal val1 As String, ByVal val2 As String)

        'custom code

        ' write_value(tempd(e.ColumnIndex) + e.RowIndex, Me.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
        Dim gain2 = column_property(2).Gain

        Dim value_to_set1 = 0
        Dim value_to_set2 = 0

        If val1 = "DP1" Then
            value_to_set1 = 1
        ElseIf val1 = "DP2" Then
            value_to_set1 = 2
        ElseIf val1 = "DP3" Then
            value_to_set1 = 3
        End If

        If val2 = "DP5" Then
            value_to_set2 = 5
        ElseIf val2 = "DP6" Then
            value_to_set2 = 6
        ElseIf val2 = "DP7" Then
            value_to_set2 = 7
        End If




        For roww = 0 To Me.RowCount - 1
            Dim selectedvalue = Me.Rows(roww).Cells(0).Value

            If selectedvalue = val1 Then
                writeIndb(tempd(0) + roww, value_to_set2, value_to_set2)
            End If

            If selectedvalue = val2 Then
                writeIndb(tempd(0) + roww, value_to_set1, value_to_set1)
            End If
        Next

    End Sub



    'Dim write_momentary_zero = False
    ' Dim write_momentary_one = False
    '   Dim rowwno = 0

    Private Sub grid_CellMouseDown(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Me.CellMouseDown
        Try

            If e.RowIndex < 0 Then
                For Each column As DataGridViewColumn In Me.Columns
                    column.SortMode = DataGridViewColumnSortMode.NotSortable
                Next
                Exit Sub
            End If


            If [ReadOnly] Then
                Exit Sub

            End If

            'only Image type column and column index is more than 0

            'col type
            'd16
            'd32
            'm'iv

            'var_type
            'textbox
            'image
            'dropdown

            If e.ColumnIndex >= 0 Then

                Dim var_type = column_property(e.ColumnIndex).Variable_Type
                Dim col_type = column_property(e.ColumnIndex).Column_Type
                Dim add_or_tag = column_property(e.ColumnIndex).Tag
                Dim action = column_property(e.ColumnIndex).Action
                Dim devicetype = ""
                ' Dim variblevalue = 0
                '
                'for getting type of used device and address
                '   Dim m As Match = Regex.Match(add_or_tag, "^([A-Za-z]+)([0-9]+)(.)([0-9]+)$")
                ''Dim m As Match = Regex.Match(add_or_tag, "^([A-Za-z]+)([0-9]+)$")

                ''If (m.Success) Then
                ''    devicetype = m.Groups(1).Value
                ''    add_or_tag = m.Groups(2).Value
                ''    myarray = getArray(devicetype)
                ''    methodstring = devicetype
                ''    Dim a = m.Groups(3).Value
                ''    Dim b = m.Groups(4).Value
                ''Else
                ''    '  myarray = getArray("IV")
                ''    If var_type > 2 Then
                ''        methodstring = devicetype
                ''    Else
                ''        'Exit Sub

                ''    End If
                ''End If


                If var_type = 0 Then

                    If col_type = 0 Then


                    ElseIf col_type = 1 Then

                        If action = 0 Then
                            'set
                            ' write_value(Integer.Parse(add_or_tag) + e.RowIndex, 1)
                            writeIndb(tempd(e.ColumnIndex) + e.RowIndex, 1, 1)
                        ElseIf action = 1 Then
                            'reset
                            '  write_value(Integer.Parse(add_or_tag) + e.RowIndex, 0)
                            writeIndb(tempd(e.ColumnIndex) + e.RowIndex, 0, 0)
                        Else
                            'toggle
                            If variableclass.tag(tempd(e.ColumnIndex) + e.RowIndex) = "0" Then
                                ' write_value(Integer.Parse(add_or_tag) + e.RowIndex, 1)
                                writeIndb(tempd(e.ColumnIndex) + e.RowIndex, 1, 1)
                            Else
                                '  write_value(Integer.Parse(add_or_tag) + e.RowIndex, 0)
                                writeIndb(tempd(e.ColumnIndex) + e.RowIndex, 0, 0)
                            End If
                        End If



                    Else



                    End If


                ElseIf var_type = 1 Then

                    If col_type = 0 Then


                    ElseIf col_type = 1 Then


                        'Dim ByteArr(3) As Byte
                        'For k = 0 To 1
                        '    'Dim Temp_Byte = BitConverter.GetBytes(list(i)((roww * 2) + k))
                        '    Dim Temp_Byte = BitConverter.GetBytes(myarray((Integer.Parse(add_or_tag) + e.RowIndex * 2) + k))

                        '    ByteArr(k * 2) = Temp_Byte(0)
                        '    ByteArr(k * 2 + 1) = Temp_Byte(1)
                        'Next
                        ' Dim Temp_Int As Integer = BitConverter.ToInt32(ByteArr, 0)
                        Dim Temp_Int As Integer = variableclass.tag(tempd(e.ColumnIndex) + e.RowIndex) = "0"


                        If action = 0 Then
                            'set
                            Dim tempvtw = "1"
                            '32 bit to 16 bit converterssss
                            Dim Byte_Arr(3) As Byte
                            Byte_Arr = BitConverter.GetBytes(Convert.ToInt32(tempvtw))
                            'this is used when for loop is used in an main form "compare" sub
                            '--variableclass.wd(WriteAddress) = BitConverter.ToInt16(Byte_Arr, 0)
                            '--variableclass.wd(WriteAddress + 1) = BitConverter.ToInt16(Byte_Arr, 2)
                            '  write_value(Integer.Parse(add_or_tag) + e.RowIndex * 2, BitConverter.ToInt16(Byte_Arr, 0))
                            '   write_value(Integer.Parse(add_or_tag) + e.RowIndex * 2 + 1, BitConverter.ToInt16(Byte_Arr, 2))
                            Dim final = BitConverter.ToInt16(Byte_Arr, 0) & "," & BitConverter.ToInt16(Byte_Arr, 2)
                            writeIndb(tempd(e.ColumnIndex) + e.RowIndex, final, tempvtw)
                        ElseIf action = 1 Then
                            'reset
                            Dim tempvtw = "0"
                            '32 bit to 16 bit converterssss
                            Dim Byte_Arr(3) As Byte
                            Byte_Arr = BitConverter.GetBytes(Convert.ToInt32(tempvtw))
                            'this is used when for loop is used in an main form "compare" sub
                            '--variableclass.wd(WriteAddress) = BitConverter.ToInt16(Byte_Arr, 0)
                            '--variableclass.wd(WriteAddress + 1) = BitConverter.ToInt16(Byte_Arr, 2)
                            ' write_value(Integer.Parse(add_or_tag) + e.RowIndex * 2, BitConverter.ToInt16(Byte_Arr, 0))
                            ' write_value(Integer.Parse(add_or_tag) + e.RowIndex * 2 + 1, BitConverter.ToInt16(Byte_Arr, 2))
                            Dim final = BitConverter.ToInt16(Byte_Arr, 0) & "," & BitConverter.ToInt16(Byte_Arr, 2)
                            writeIndb(tempd(e.ColumnIndex) + e.RowIndex, final, tempvtw)
                        Else
                            'toggle

                            If Temp_Int = 0 Then
                                'write_value(Integer.Parse(add_or_tag) + e.RowIndex, 1)

                                Dim tempvtw = "1"
                                '32 bit to 16 bit converterssss
                                Dim Byte_Arr(3) As Byte
                                Byte_Arr = BitConverter.GetBytes(Convert.ToInt32(tempvtw))
                                'this is used when for loop is used in an main form "compare" sub
                                '--variableclass.wd(WriteAddress) = BitConverter.ToInt16(Byte_Arr, 0)
                                '--variableclass.wd(WriteAddress + 1) = BitConverter.ToInt16(Byte_Arr, 2)
                                '  write_value(Integer.Parse(add_or_tag) + e.RowIndex * 2, BitConverter.ToInt16(Byte_Arr, 0))
                                ' write_value(Integer.Parse(add_or_tag) + e.RowIndex * 2 + 1, BitConverter.ToInt16(Byte_Arr, 2))
                                Dim final = BitConverter.ToInt16(Byte_Arr, 0) & "," & BitConverter.ToInt16(Byte_Arr, 2)
                                writeIndb(tempd(e.ColumnIndex) + e.RowIndex, final, tempvtw)
                            Else
                                ' write_value(Integer.Parse(add_or_tag) + e.RowIndex, 0)
                                Dim tempvtw = "0"
                                '32 bit to 16 bit converterssss
                                Dim Byte_Arr(3) As Byte
                                Byte_Arr = BitConverter.GetBytes(Convert.ToInt32(tempvtw))
                                'this is used when for loop is used in an main form "compare" sub
                                '--variableclass.wd(WriteAddress) = BitConverter.ToInt16(Byte_Arr, 0)
                                '--variableclass.wd(WriteAddress + 1) = BitConverter.ToInt16(Byte_Arr, 2)
                                ' write_value(Integer.Parse(add_or_tag) + e.RowIndex * 2, BitConverter.ToInt16(Byte_Arr, 0))
                                ' write_value(Integer.Parse(add_or_tag) + e.RowIndex * 2 + 1, BitConverter.ToInt16(Byte_Arr, 2))
                                Dim final = BitConverter.ToInt16(Byte_Arr, 0) & "," & BitConverter.ToInt16(Byte_Arr, 2)
                                writeIndb(tempd(e.ColumnIndex) + e.RowIndex, final, tempvtw)
                            End If
                        End If




                    Else


                    End If

                ElseIf var_type = 2 Then
                    If col_type = 0 Then

                    ElseIf col_type = 1 Then

                        If action = 0 Then
                            'set
                            '   write_value(Integer.Parse(add_or_tag) + e.RowIndex, 1)

                            writeIndb(tempd(e.ColumnIndex) + e.RowIndex, 1, 1)
                        ElseIf action = 1 Then
                            'reset
                            ' write_value(Integer.Parse(add_or_tag) + e.RowIndex, 0)
                            writeIndb(tempd(e.ColumnIndex) + e.RowIndex, 0, 0)
                        Else
                            'toggle
                            If variableclass.tag(tempd(e.ColumnIndex) + e.RowIndex) = "0" Then
                                ' write_value(Integer.Parse(add_or_tag) + e.RowIndex, 1)
                                writeIndb(tempd(e.ColumnIndex) + e.RowIndex, 1, 1)
                            Else
                                ' write_value(Integer.Parse(add_or_tag) + e.RowIndex, 0)
                                writeIndb(tempd(e.ColumnIndex) + e.RowIndex, 0, 0)
                            End If
                        End If




                    Else

                    End If
                Else
                    If col_type = 0 Then

                    ElseIf col_type = 1 Then


                        If action = 0 Then
                            'set
                            'write_value(tempd(Me.CurrentCell.ColumnIndex) + e.RowIndex, "1")
                            writeIndb(tempd(e.ColumnIndex) + e.RowIndex, "1", "1")
                        ElseIf action = 1 Then
                            'reset
                            ' write_value(tempd(Me.CurrentCell.ColumnIndex) + e.RowIndex, "0")
                            writeIndb(tempd(e.ColumnIndex) + e.RowIndex, "0", "0")
                        Else
                            'toggle
                            If variableclass.tag(tempd(e.ColumnIndex) + e.RowIndex) = "0" Then
                                ' write_value(tempd(Me.CurrentCell.ColumnIndex) + e.RowIndex, "1")
                                writeIndb(tempd(e.ColumnIndex) + e.RowIndex, "1", "1")
                            Else
                                ' write_value(tempd(Me.CurrentCell.ColumnIndex) + e.RowIndex, "0")
                                writeIndb(tempd(e.ColumnIndex) + e.RowIndex, "0", "0")
                            End If

                        End If





                    Else

                    End If
                End If





            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub grid_CellMouseUp(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Me.CellMouseUp
        If e.RowIndex < 0 Then
            For Each column As DataGridViewColumn In Me.Columns
                column.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
            Exit Sub
        End If


        'only Image type column and column index is more than 0

        'col type
        'd16
        'd32
        'm'iv

        'var_type
        'textbox
        'image
        'dropdown

        If e.ColumnIndex >= 0 Then

            Dim var_type = column_property(e.ColumnIndex).Variable_Type
            Dim col_type = column_property(e.ColumnIndex).Column_Type
            Dim add_or_tag = column_property(e.ColumnIndex).Tag
            Dim action = column_property(e.ColumnIndex).Action



            If var_type = 0 Then

                If col_type = 0 Then


                ElseIf col_type = 1 Then

                    If action = 0 Then
                        'set
                        ' write_momentary_one = True
                        ' rowwno = e.RowIndex
                        'write_value(Integer.Parse(add_or_tag) + e.RowIndex, 0)
                    ElseIf action = 1 Then
                        'reset
                    ElseIf action = 2 Then
                        'toggle

                    Else
                        'toggle

                    End If



                Else



                End If


            ElseIf var_type = 1 Then

                If col_type = 0 Then


                ElseIf col_type = 1 Then


                    'Dim ByteArr(3) As Byte
                    'For k = 0 To 1
                    '    'Dim Temp_Byte = BitConverter.GetBytes(list(i)((roww * 2) + k))
                    '    Dim Temp_Byte = BitConverter.GetBytes(main_d((Integer.Parse(add_or_tag) + e.RowIndex * 2) + k))

                    '    ByteArr(k * 2) = Temp_Byte(0)
                    '    ByteArr(k * 2 + 1) = Temp_Byte(1)
                    'Next
                    'Dim Temp_Int As Integer = BitConverter.ToInt32(ByteArr, 0)


                    If action = 0 Then
                        'set
                        'Dim tempvtw = "0"
                        ''32 bit to 16 bit converterssss
                        'Dim Byte_Arr(3) As Byte
                        'Byte_Arr = BitConverter.GetBytes(Convert.ToInt32(tempvtw))
                        ''this is used when for loop is used in an main form "compare" sub
                        ''--variableclass.wd(WriteAddress) = BitConverter.ToInt16(Byte_Arr, 0)
                        ''--variableclass.wd(WriteAddress + 1) = BitConverter.ToInt16(Byte_Arr, 2)
                        'plcclass.write_value(Integer.Parse(add_or_tag) + e.RowIndex * 2, BitConverter.ToInt16(Byte_Arr, 0))
                        'plcclass.write_value(Integer.Parse(add_or_tag) + e.RowIndex * 2 + 1, BitConverter.ToInt16(Byte_Arr, 2))
                    ElseIf action = 1 Then
                        'reset

                    Else
                        'toggle

                    End If




                Else


                End If

            ElseIf var_type = 2 Then
                If col_type = 0 Then

                ElseIf col_type = 1 Then

                    If action = 0 Then

                        'set
                        'plcclass.write_value(Integer.Parse(add_or_tag) + e.RowIndex, 0)
                    ElseIf action = 1 Then
                        'reset

                    Else
                        'toggle




                    End If




                Else

                End If
            Else
                If col_type = 0 Then

                ElseIf col_type = 1 Then


                    If action = 0 Then
                        'set
                    ElseIf action = 1 Then
                        'reset
                    Else
                        'toggle
                    End If

                Else

                End If
            End If





        End If

    End Sub



    Private Sub RECIPE_ControlAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs)
        Me.AllowUserToAddRows = False
        Me.AllowUserToDeleteRows = False
    End Sub



    '  Dim colarray_1(100) As Array
    'Dim list As New ArrayList()


    Shared main_d(8000) As Short 'this is main array contains all d values

    ' ''Public Shared d(1500) As Short
    'Function Read_d_Values(ByVal read_start As String, ByVal type As String, ByVal colnumber As Integer)
    '    Dim D_arr() As Short
    '    Try
    '        ' Dim ireturncode As Integer = 0
    '        '  Dim read_start As String = "D0"
    '        ' read_start = "D0"
    '        Dim no_of_device As Integer
    '        If type = "D_32_Bit" Then
    '            no_of_device = row * 2
    '            ReDim D_arr(no_of_device)
    '        Else
    '            no_of_device = row
    '            ReDim D_arr(no_of_device)
    '        End If

    '        AxActUtlType1.Connect()
    '        AxActUtlType1.ActLogicalStationNumber = iLogicalStationNumber
    '        iReturnCode1 = AxActUtlType1.Open()
    '        plcclass.ax = AxActUtlType1
    '        Dim str = "D" & read_start

    '        Dim ireturncode = AxActUtlType1.ReadDeviceBlock2(str, no_of_device, main_d(Integer.Parse(read_start)))


    '        If ireturncode = 0 Then
    '            Return True
    '        Else
    '            Return False
    '        End If

    '    Catch ex As Exception
    '        MsgBox("Class1- read_all_d_values: " & ex.Message)
    '    End Try

    'End Function

    ''this method reads all d values 
    'Function Read_all_d_Values()

    '    Try



    '        Dim ireturncode = AxActUtlType1.ReadDeviceBlock2("D0", 8000, main_d(0))

    '        If ireturncode = 0 Then
    '            Return True
    '        Else
    '            Return False
    '        End If

    '    Catch ex As Exception
    '        MsgBox("Class1- read_all_d_values: " & ex.Message)
    '    End Try

    'End Function


    'Dim main_m(8000)
    'Sub read_m_values(ByVal read_strt As String, ByVal type As String, ByVal colnumber As Integer)
    '    Try
    '        Dim M16B(500) As Short

    '        Dim Temp(15) As Short
    '        Dim Read_Start = "M" & read_strt
    '        Dim No_of_Device = 500
    '        Dim iReturnCode = AxActUtlType.ReadDeviceBlock2(Read_Start, No_of_Device, M16B(0))
    '        If iReturnCode = 0 Then
    '            For i = 0 To No_of_Device - 1
    '                Temp = Bin_Arr(M16B(i))
    '                For j = 0 To 15
    '                    M_arr(j + i * 16) = Temp(j)
    '                Next
    '            Next
    '        End If

    '    Catch ex As Exception
    '    End Try

    'End Sub

    '' Dim main_m16_bit(8000)
    'Shared main_m(8000) As Short 'main M array contains all m values
    'Sub read_m_values(ByVal read_strt As String, ByVal type As String, ByVal colnumber As Integer)
    '    Try

    '        Dim read_start As Integer
    '        read_start = read_strt / 16
    '        Dim read_end As Integer
    '        read_end = ((read_strt + row) / 16) + 1

    '        Dim No_of_Device = read_end - read_start

    '        Dim M16B(1000) As Short

    '        Dim Temp(15) As Short
    '        Dim Read_Str = "M" & read_start
    '        ' Dim No_of_Device = 500

    '        AxActUtlType1.Connect()
    '        AxActUtlType1.ActLogicalStationNumber = iLogicalStationNumber
    '        iReturnCode1 = AxActUtlType1.Open()
    '        Dim iReturnCode = AxActUtlType1.ReadDeviceBlock2("M62", 100, M16B(62))
    '        MsgBox(M16B(0))
    '        MsgBox(M16B(1))
    '        MsgBox(M16B(61))
    '        MsgBox(M16B(62))

    '        MsgBox(M16B(63))

    '        If iReturnCode = 0 Then
    '            For i = 0 To No_of_Device - 1
    '                Temp = Bin_Arr(M16B(i))
    '                For j = 0 To 15
    '                    main_m((read_start * 16) + j + i * 16) = Temp(j)
    '                Next
    '            Next
    '        End If
    '        '  msgbox(main_m(1000))
    '    Catch ex As Exception
    '    End Try

    'End Sub

    'Dim M_arr(8000)
    ''reads all m values
    'Sub read_all_m_values()
    '    Try
    '        Dim M16B(500) As Short

    '        Dim Temp(15) As Short
    '        Dim Read_Start = "M0"
    '        'Dim No_of_Device = 500
    '        Dim No_of_Device = 479
    '        'AxActUtlType1.Connect()
    '        'AxActUtlType1.ActLogicalStationNumber = iLogicalStationNumber
    '        'iReturnCode1 = AxActUtlType1.Open()
    '        Dim iReturnCode = AxActUtlType1.ReadDeviceBlock2(Read_Start, No_of_Device, M16B(0))
    '        If iReturnCode = 0 Then
    '            For i = 0 To No_of_Device - 1
    '                Temp = Bin_Arr(M16B(i))
    '                For j = 0 To 15
    '                    M_arr(j + i * 16) = Temp(j)

    '                    main_m(j + i * 16) = Temp(j)
    '                Next
    '            Next
    '        End If
    '        ' MsgBox(main_m(1001))
    '    Catch ex As Exception


    '    End Try

    'End Sub



    'Dim main_iv(8000)
    ''not using currently
    'Sub read_iv_values(ByVal read_strt As String, ByVal type As String, ByVal colnumber As Integer)
    '    Try

    '        Dim read_start As Integer
    '        read_start = read_strt / 16
    '        Dim read_end As Integer
    '        read_end = ((read_strt + row) / 16) + 1

    '        Dim No_of_Device = read_end - read_start

    '        Dim M16B(1000) As Short

    '        Dim Temp(15) As Short
    '        Dim Read_Str = "M" & read_start
    '        ' Dim No_of_Device = 500

    '        AxActUtlType1.Connect()
    '        AxActUtlType1.ActLogicalStationNumber = iLogicalStationNumber
    '        iReturnCode1 = AxActUtlType1.Open()
    '        Dim iReturnCode = AxActUtlType1.ReadDeviceBlock2("M62", 100, M16B(62))
    '        MsgBox(M16B(0))
    '        MsgBox(M16B(1))
    '        MsgBox(M16B(61))
    '        MsgBox(M16B(62))

    '        MsgBox(M16B(63))

    '        If iReturnCode = 0 Then
    '            For i = 0 To No_of_Device - 1
    '                Temp = Bin_Arr(M16B(i))
    '                For j = 0 To 15
    '                    main_m((read_start * 16) + j + i * 16) = Temp(j)
    '                Next
    '            Next
    '        End If
    '        '  msgbox(main_m(1000))
    '    Catch ex As Exception
    '    End Try

    'End Sub




    'Dim Iv_arr(10000)
    ''not using currently
    'Sub read_IV_values()
    '    Try
    '        Iv_arr = variableclass.tag
    '    Catch ex As Exception
    '    End Try

    'End Sub

    Function Bin_Arr(ByVal Dec_txt As Integer) As Short()
        Dim Temp_Byte(1), ByteArr(3), Dec As Byte
        Dim sd(15) As Short
        Dim temp_short, bit_no As Integer
        temp_short = Dec_txt
        Temp_Byte = BitConverter.GetBytes(temp_short)
        For i = 0 To 1
            Dec = Temp_Byte(i)
            bit_no = 0
            For bit_no = 0 To 7
                If Dec Mod 2 = 0 Then
                    sd(i * 8 + bit_no) = 0
                Else
                    sd(i * 8 + bit_no) = 1
                End If
                Dec = Dec \ 2
            Next
        Next
        Bin_Arr = sd
    End Function

    'Dim AxActUtlType
    Dim added = False

    Dim iReturnCode1 As Integer              'Return code

    Public Event action()
    Public Event dirty_state_change_event_action()
    Public tempvariable = 0
    Public execute_action = False

    Public make_plc_con = True
    '  Dim connection_var = True

    Public Shared timer_started = False
    Public Shared timer_stopped = False
    Public Shared timer_start = False

    Dim get_readdatatrigger = 0
    Dim readdatatrigger_id
    Sub adddatain_datagridview()

        'If timer_start = False Then
        '    Timer1.Enabled = True
        '    timer_start = True
        'End If

        ' System.Threading.Thread.Sleep(50)
        visiblecode()
        highlightrow()

        If execute_action = True Then
            tempvariable = tempvariable + 1
        End If
        ''adding values to all drop down
        adddropdown()


        If get_readdatatrigger = 0 Then
            sql.scon3()
            '' Dim querystring As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select tag_id from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & Vissible_tagname & "'"

            'readdatatrigger
            Dim querystring As String = ""
            'for encrypted or  non_encypted tables
            If variableclass.is_encrypted Then
                querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select tag_id from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & readdatatrigger & "'"
            Else
                querystring = "select tag_id from Tag_data  where  Tag_name = '" & readdatatrigger & "'"
            End If


            Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
            sqlcmd1.ExecuteNonQuery()
            Using reader As SqlDataReader = sqlcmd1.ExecuteReader
                If reader.Read = True Then
                    readdatatrigger_id = reader.Item("Tag_id")
                End If
            End Using
            ' sqlcmd1.Dispose()
            sql.scn3.Close()
            get_readdatatrigger = 1
        End If


        If readdatatrigger_id = 0 Then
            Dim counter = 0
            Try
                ' Dim myTime As DateTime = DateTime.Now
                Dim myTime = Now.ToString("HH:mm:ss.fffffff")
                For i = 0 To column_property.Count - 1
                    For j = 0 To Columns.Count - 1
                        ' If Columns(j).HeaderText = ColumnsProperty(i)._ColumnName Then
                        If i = j Then
                            'If Me.Columns(i).columnty = DataGridViewButtonCell Then

                            'End If
                            'If TypeOf Me.Columns(j) Is DataGridViewButtonColumn Then

                            'End If

                            Read_data(i)
                            counter = counter + 1
                        End If
                    Next
                Next
                Dim myTime1 = Now.ToString("HH:mm:ss.fffffff")
                Dim y = 0
            Catch ex As Exception
                Dim x = counter

            End Try
        Else


            If variableclass.tag(readdatatrigger_id) = "0" Then




            Else
                'this method shows the data in grid
                Dim counter = 0
                Try
                    ' Dim myTime As DateTime = DateTime.Now
                    Dim myTime = Now.ToString("HH:mm:ss.fffffff")
                    For i = 0 To column_property.Count - 1
                        For j = 0 To Columns.Count - 1
                            ' If Columns(j).HeaderText = ColumnsProperty(i)._ColumnName Then
                            If i = j Then
                                Read_data(i)
                                counter = counter + 1
                            End If
                        Next
                    Next
                    Dim myTime1 = Now.ToString("HH:mm:ss.fffffff")
                    Dim y = 0
                Catch ex As Exception
                    Dim x = counter

                End Try
            End If
        End If


        If (execute_action = True) Then
            If tempvariable > 10 Then
                RaiseEvent action()
                tempvariable = 0
                execute_action = False
            End If



        End If


    End Sub

    'Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
    '    'perform your db access here and set the result in _success
    '    Read_all_d_Values()
    '    read_all_m_values()
    'End Sub

    Function getArray(ByVal type As String)
        If type = "D" Or type = "d" Then
            '   Return main_d
        ElseIf type = "M" Or type = "m" Then
            '   Return main_m
        ElseIf type = "IV" Or type = "iv" Or type = "Iv" Or type = "iV" Then
            '  Return variableclass.tag
        Else
            '  Return variableclass.tag
        End If


    End Function


    'Dim valchanged = 0
    Sub Read_data(ByVal i As Integer)

        'If valchanged > 0 And valchanged < 5 Then
        '    valchanged = valchanged + 1
        '    If valchanged = 5 Then
        '        valchanged = 0
        '    End If
        '    Exit Sub
        'End If

        Try


            Dim var_type = column_property(i).Variable_Type
            Dim col_type = column_property(i).Column_Type
            Dim add_or_tag = column_property(i).Tag
            Dim inputtype2 = column_property(i).InputType
            Dim gain2 = column_property(i).Gain
            Dim noofdecimal = column_property(i).No_of_DecimalValues


            '  Dim devicetype = ""
            '   Dim variblevalue = 0

            'for getting type of used device and address
            '   Dim m As Match = Regex.Match(add_or_tag, "^([A-Za-z]+)([0-9]+)(.)([0-9]+)$")
            'Dim m As Match = Regex.Match(add_or_tag, "^([A-Za-z]+)([0-9]+)$")

            'If (m.Success) Then
            '    devicetype = m.Groups(1).Value
            '    add_or_tag = m.Groups(2).Value

            '    'myarray is assigned with the required array
            '    myarray = getArray(devicetype)

            '    Dim a = m.Groups(3).Value
            '    Dim b = m.Groups(4).Value
            'Else
            '    '  myarray = getArray("IV")
            '    If var_type > 2 Then
            '        methodstring = devicetype
            '    Else
            '        '  Exit Sub

            '    End If
            'End If


            'if bit-16
            If var_type = 0 Then
                If col_type = 0 Then
                    ' textbox
                    For roww = 0 To Me.RowCount - 1

                        Dim value_on_tag = variableclass.tag(tempd(i) + roww)


                        Dim vts
                        If noofdecimal > 0 Then
                            ' variableclass.tag(tempd(i) + roww)
                            vts = FormatNumber(CDbl(value_on_tag / gain2), noofdecimal, , , TriState.False)
                        Else
                            '  vts = (value_on_tag + roww) / gain2
                            vts = (value_on_tag) / gain2
                            vts = Math.Round(Val(vts))
                        End If

                        Me.Rows(roww).Cells(i).Value = vts
                    Next

                ElseIf col_type = 1 Then
                    ' image
                    For roww = 0 To Me.RowCount - 1

                        Dim value_on_tag = variableclass.tag(tempd(i) + roww)

                        If value_on_tag = 0 Then
                            Me.Rows(roww).Cells(i).Value = column_property(i).OFF_Image
                        Else
                            Me.Rows(roww).Cells(i).Value = column_property(i).ON_Image
                        End If

                    Next


                Else
                    ' dropdown
                    Dim ddvalue = column_property(i).List_of_DropDownValues
                    For roww = 0 To Me.RowCount - 1
                        Dim value_on_tag = variableclass.tag(tempd(i) + roww)
                        If value_on_tag >= ddvalue.Length Or value_on_tag < 0 Then
                            '  Me.rows(roww).cells(i).value = ddvalue(0)
                            Me.Rows(roww).Cells(i).Value = Nothing
                        Else
                            Me.Rows(roww).Cells(i).Value = ddvalue(value_on_tag)
                        End If
                    Next

                End If

                'if bit-32
            ElseIf var_type = 1 Then

                If col_type = 0 Then
                    ' textbox
                    For roww = 0 To Me.RowCount - 1

                        Dim value_on_tag = variableclass.tag(tempd(i) + roww)


                        Dim vts
                        If noofdecimal > 0 Then
                            ' variableclass.tag(tempd(i) + roww)
                            vts = FormatNumber(CDbl(value_on_tag / gain2), noofdecimal, , , TriState.False)
                        Else
                            ' vts = (value_on_tag + roww) / gain2
                            vts = (value_on_tag) / gain2
                            vts = Math.Round(Val(vts))
                        End If

                        Me.Rows(roww).Cells(i).Value = vts
                    Next

                ElseIf col_type = 1 Then
                    ' image
                    For roww = 0 To Me.RowCount - 1

                        Dim value_on_tag = variableclass.tag(tempd(i) + roww)

                        If value_on_tag = 0 Then
                            Me.Rows(roww).Cells(i).Value = column_property(i).OFF_Image
                        Else
                            Me.Rows(roww).Cells(i).Value = column_property(i).ON_Image
                        End If

                    Next


                Else
                    ' dropdown
                    Dim ddvalue = column_property(i).List_of_DropDownValues
                    For roww = 0 To Me.RowCount - 1
                        Dim value_on_tag = variableclass.tag(tempd(i) + roww)
                        If value_on_tag >= ddvalue.Length Or value_on_tag < 0 Then
                            '  Me.rows(roww).cells(i).value = ddvalue(0)
                            Me.Rows(roww).Cells(i).Value = Nothing
                        Else
                            Me.Rows(roww).Cells(i).Value = ddvalue(value_on_tag)
                        End If
                    Next

                End If
                'binary
            ElseIf var_type = 2 Then
                If col_type = 0 Then
                    'textbox
                    For roww = 0 To Me.RowCount - 1

                        Dim value_on_tag = variableclass.tag(tempd(i) + roww)
                        '   Me.Rows(roww).Cells(i).Value = list(i)(roww)
                        Me.Rows(roww).Cells(i).Value = value_on_tag
                        'Dim a = myarray(1001)

                    Next
                ElseIf col_type = 1 Then
                    'image
                    For roww = 0 To Me.RowCount - 1
                        Dim value_on_tag = variableclass.tag(tempd(i) + roww)
                        If value_on_tag = 0 Then
                            Me.Rows(roww).Cells(i).Value = column_property(i).OFF_Image
                        Else
                            Me.Rows(roww).Cells(i).Value = column_property(i).ON_Image
                        End If
                    Next
                Else
                    'dropdown
                    Dim ddvalue = column_property(i).List_of_DropDownValues
                    For roww = 0 To Me.RowCount - 1
                        Dim value_on_tag = variableclass.tag(tempd(i) + roww)
                        If value_on_tag >= ddvalue.Length Or value_on_tag < 0 Then
                            '  Me.rows(roww).cells(i).value = ddvalue(0)
                            Me.Rows(roww).Cells(i).Value = Nothing
                        Else
                            Me.Rows(roww).Cells(i).Value = ddvalue(value_on_tag)
                        End If
                    Next
                End If
            Else

                If col_type = 0 Then
                    For roww = 0 To Me.RowCount - 1
                        ' If TypeOf Me.Rows(roww).Cells(i) Is DataGridViewButtonCell Then
                        'Me.Rows(roww).Cells(i).Value = ""
                        ' Else
                            If inputtype2 = 0 Then
                                '    Me.Rows(roww).Cells(i).Value = variableclass.tag(tempd(i) + roww)
                                Dim Temp_Int = variableclass.tag(tempd(i) + roww)


                                Dim vts

                                If Temp_Int = "" Then
                                    vts = ""
                                Else
                                    If noofdecimal > 0 Then
                                        '  temp12 = FormatNumber(CDbl(variableclass.d(ReadAddress) / rgain), _decimalval)
                                        vts = FormatNumber(CDbl(Temp_Int / gain2), noofdecimal, , , TriState.False)
                                    Else
                                        ' temp12 = Val(variableclass.d(ReadAddress)) / rgain
                                        vts = Temp_Int / gain2
                                        vts = Math.Round(Val(vts))
                                    End If
                                    Me.Rows(roww).Cells(i).Value = vts
                                End If

                            Else
                                Me.Rows(roww).Cells(i).Value = variableclass.tag(tempd(i) + roww)

                            End If
                            ' End If

                    Next
                ElseIf col_type = 1 Then

                    For roww = 0 To Me.RowCount - 1
                        If variableclass.tag(tempd(i) + roww) = "0" Then

                            Me.Rows(roww).Cells(i).Value = column_property(i).OFF_Image
                        Else
                            Me.Rows(roww).Cells(i).Value = column_property(i).ON_Image
                        End If
                    Next

                Else
                    Dim ddvalue = column_property(i).List_of_DropDownValues
                    For roww = 0 To Me.RowCount - 1
                        If variableclass.tag(tempd(i) + roww) >= ddvalue.Length Or variableclass.tag(tempd(i) + roww) < 0 Then
                            '  Me.rows(roww).cells(i).value = ddvalue(0)
                            Me.Rows(roww).Cells(i).Value = Nothing
                        Else
                            Me.Rows(roww).Cells(i).Value = ddvalue(variableclass.tag(tempd(i) + roww))
                        End If
                    Next
                End If
            End If


        Catch ex As Exception
            '   MsgBox(ex)
        End Try
    End Sub

    'variable for detecting whether values are added to dropdown or not
    Dim ddlistadded = False
    Sub adddropdown()

        Try
            If ddlistadded = False Then


                For i = 0 To Me.Columns.Count - 1
                    For j = 0 To Me.column_property.Count - 1
                        'If Me.Columns(i).HeaderText = Me.column_property(j)._ColumnName Then
                        If i = j Then
                            If Me.column_property(j).Column_Type = 2 Then

                                Dim ddvalues = column_property(j).List_of_DropDownValues

                                Dim comboSource As New Dictionary(Of String, String)()

                                For sc = 0 To ddvalues.Count - 1
                                    comboSource.Add(ddvalues(sc), ddvalues(sc))
                                Next

                                For roww = 0 To RowCount - 1

                                    Dim dgvcc As DataGridViewComboBoxCell

                                    dgvcc = Me.Rows(roww).Cells(i)

                                    dgvcc.DataSource = New BindingSource(comboSource, Nothing)
                                    dgvcc.DisplayMember = "Value"
                                    dgvcc.ValueMember = "Key"

                                Next
                            End If
                        End If
                    Next
                Next
                ddlistadded = True
            End If
        Catch ex As Exception
            MsgBox("Some Properties mismatching in CustomDataGridView " & ex.ToString)
        End Try

    End Sub

    'Sub getfilelength(filename As String)
    '    Dim no_of_rows = 0
    '    Dim r1 As New System.IO.StreamReader(filename)
    '    Dim msg = ""
    '    '  Dim tf = fo.Split(vbNewLine)
    '    ' Dim counter1 = 0
    '    Do
    '        msg = r1.ReadLine

    '        Dim arr = msg.Split("=")
    '        Dim data = arr(0).Split(",")
    '        Dim col = data(0)

    '        '  Dim row = Integer.Parse(data(1))
    '        Dim value = arr(1)
    '        finalvalue = value
    '        no_of_rows = no_of_rows + 1
    '    Loop
    '    ' counter1 = counter1 + 1

    'End Sub





    Private Sub DataGridView1SelectAll_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Me.CurrentCellDirtyStateChanged


        RemoveHandler Me.CurrentCellDirtyStateChanged,
            AddressOf DataGridView1SelectAll_CurrentCellDirtyStateChanged

        If TypeOf Me.CurrentCell Is DataGridViewComboBoxCell Then
            Me.EndEdit()




            Dim var_type = column_property(Me.CurrentCell.ColumnIndex).Variable_Type
            Dim col_type = column_property(Me.CurrentCell.ColumnIndex).Column_Type
            Dim add_or_tag = column_property(Me.CurrentCell.ColumnIndex).Tag
            Dim ddvalues = column_property(Me.CurrentCell.ColumnIndex).List_of_DropDownValues

            Dim devicetype = ""
            Dim variblevalue = 0

            'for getting type of used device and address
            '   Dim m As Match = Regex.Match(add_or_tag, "^([A-Za-z]+)([0-9]+)(.)([0-9]+)$")
            '' Dim m As Match = Regex.Match(add_or_tag, "^([A-Za-z]+)([0-9]+)$")

            ''If (m.Success) Then
            ''    devicetype = m.Groups(1).Value
            ''    add_or_tag = m.Groups(2).Value
            ''    methodstring = devicetype
            ''    myarray = getArray(devicetype)
            ''    Dim a = m.Groups(3).Value
            ''    Dim b = m.Groups(4).Value
            ''Else
            ''    '      myarray = getArray("IV")
            ''    If var_type > 2 Then
            ''        methodstring = devicetype
            ''    Else
            ''        '    Exit Sub

            ''    End If
            ''End If

            ''custom code
            If CurrentCell.Value = "Length+Section" Then
                CurrentCell.Value = ""
            End If





            'Dim tempd = Me.Columns(Me.CurrentCell.ColumnIndex).DataPropertyName
            If var_type = 0 Then

                If col_type = 0 Then

                ElseIf col_type = 1 Then

                Else
                    Dim index = Array.IndexOf(ddvalues, CurrentCell.Value)
                    ' writeIndb(Integer.Parse(add_or_tag) + Me.CurrentCell.RowIndex, index)
                    writeIndb(tempd(Me.CurrentCell.ColumnIndex) + Me.CurrentCell.RowIndex, index, index)
                End If


            ElseIf var_type = 1 Then

                If col_type = 0 Then

                ElseIf col_type = 1 Then

                Else
                    Dim index = Array.IndexOf(ddvalues, CurrentCell.Value)
                    ' write_value(Integer.Parse(add_or_tag) + e.RowIndex, 0)
                    Dim tempvtw = index
                    '32 bit to 16 bit converterssss
                    Dim Byte_Arr(3) As Byte
                    Byte_Arr = BitConverter.GetBytes(Convert.ToInt32(tempvtw))
                    'this is used when for loop is used in an main form "compare" sub
                    '--variableclass.wd(WriteAddress) = BitConverter.ToInt16(Byte_Arr, 0)
                    '--variableclass.wd(WriteAddress + 1) = BitConverter.ToInt16(Byte_Arr, 2)
                    ' write_value(Integer.Parse(add_or_tag) + Me.CurrentCell.RowIndex * 2, BitConverter.ToInt16(Byte_Arr, 0))
                    ' write_value(Integer.Parse(add_or_tag) + Me.CurrentCell.RowIndex * 2 + 1, BitConverter.ToInt16(Byte_Arr, 2))
                    Dim final_value = BitConverter.ToInt16(Byte_Arr, 0) & "," & BitConverter.ToInt16(Byte_Arr, 2)

                    writeIndb(tempd(Me.CurrentCell.ColumnIndex) + Me.CurrentCell.RowIndex, final_value, tempvtw)
                End If

            ElseIf var_type = 2 Then
                If col_type = 0 Then

                ElseIf col_type = 1 Then

                Else
                    Dim index = Array.IndexOf(ddvalues, CurrentCell.Value)
                    'write_value(Integer.Parse(add_or_tag) + Me.CurrentCell.RowIndex, index)
                    writeIndb(tempd(Me.CurrentCell.ColumnIndex) + Me.CurrentCell.RowIndex, index, index)
                End If
            Else
                If col_type = 0 Then

                ElseIf col_type = 1 Then

                Else
                    Dim index = Array.IndexOf(ddvalues, CurrentCell.Value)
                    'write_value(add_or_tag + Me.CurrentCell.RowIndex, index)
                    ' write_value(tempd(Me.CurrentCell.ColumnIndex) + Me.CurrentCell.RowIndex, index)
                    writeIndb(tempd(Me.CurrentCell.ColumnIndex) + Me.CurrentCell.RowIndex, index, index)
                End If
            End If








            '    MsgBox(CurrentCell.Value)
            'Dim Checked As Boolean = CType(Me.CurrentCell.Value, Boolean)
            'If Checked Then
            '    '                MessageBox.Show("You have checked")
            '    Me.Rows(0).DefaultCellStyle.BackColor = Color.Yellow
            '    '  ev.insertalarmevent(Login_Register.empid, "Alarm Resolved by User", "", 0, 0, 0, 2)

            'Else
            '    Me.Rows(0).DefaultCellStyle.BackColor = Color.LightGreen

            'End If
            'Try
            '    Dim tempd = Me.Columns(Me.CurrentCell.ColumnIndex).DataPropertyName

            '    Dim index = 0
            '    Dim temp = ""
            '    For sc = 0 To ddown.Count - 1
            '        If Me.Columns(Me.CurrentCell.ColumnIndex).HeaderText = ddown(sc).ColumnName Then
            '            index = Array.IndexOf(ddown(sc).List_of_Combobox, CurrentCell.Value)

            '        End If
            '    Next
            '   write_value(tempd + Me.CurrentCell.RowIndex, index)
            '    ' writearray(Me.CurrentCell.ColumnIndex, Me.CurrentCell.RowIndex) = CurrentCell.Value
            'Catch ex As Exception
            'End Try
        Else
            Me.EndEdit()
            cell_endedit(sender, e)
        End If

        RaiseEvent dirty_state_change_event_action()

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

    Dim readvalue As String = ""
    'this function return tag value given tag name
    Public Function tagvalue(ByVal tagname As String)
        Try

            readvalue = ""
            sqlclass.rightcon()
            ' Dim querystring1 As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select convert(varchar, decryptbykey(Read_value)) as Read_value  from Tag_data  where  convert(varchar, decryptbykey(Tag_name))  = '" & tagname & "'"
            Dim querystring1 As String = ""

            'for encrypted or  non_encypted tables
            If variableclass.is_encrypted Then
                querystring1 = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select convert(varchar, decryptbykey(Read_value)) as Read_value  from Tag_data  where  convert(varchar, decryptbykey(Tag_name))  = '" & tagname & "'"
            Else
                querystring1 = "select  Read_value  from Tag_data  where  Tag_name  = '" & tagname & "'"
            End If



            Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring1, sqlclass.rightcnn)
            sqlcmd1.ExecuteNonQuery()
            Using reader As SqlDataReader = sqlcmd1.ExecuteReader
                If reader.Read Then
                    readvalue = (reader.Item("Read_value"))
                End If
            End Using
            sqlcmd1.Dispose()
            sqlclass.rightcnn.Close()
            Return readvalue
        Catch ex As Exception
            '  MsgBox("tagvalue:" & ex.Message)
        End Try
    End Function

    Dim readvalue1 As String = ""
    'this function return tag value given tag name
    Public Function tagvalue(ByVal tagid As Integer)
        Try

            readvalue1 = ""
            sqlclass.rightcon()
            ' Dim querystring1 As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select convert(varchar, decryptbykey(Read_value)) as Read_value  from Tag_data  where  convert(varchar, decryptbykey(Tag_name))  = '" & tagname & "'"
            Dim querystring1 As String = ""

            'for encrypted or  non_encypted tables
            If variableclass.is_encrypted Then
                querystring1 = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select convert(varchar, decryptbykey(Read_value)) as Read_value  from Tag_data  where  convert(varchar, decryptbykey(Tag_id))  = '" & tagid & "'"
            Else
                querystring1 = "select  Read_value  from Tag_data  where  Tag_id  = '" & tagid & "'"
            End If



            Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring1, sqlclass.rightcnn)
            sqlcmd1.ExecuteNonQuery()
            Using reader As SqlDataReader = sqlcmd1.ExecuteReader
                If reader.Read Then
                    readvalue1 = (reader.Item("Read_value"))
                End If
            End Using
            sqlcmd1.Dispose()
            sqlclass.rightcnn.Close()
            Return readvalue1
        Catch ex As Exception
            '  MsgBox("tagvalue:" & ex.Message)
        End Try
    End Function

    Public Function tagvalue_bulk(ByVal tagid As Integer)
        Try

            readvalue1 = ""
            ' sqlclass.rightcon()
            ' Dim querystring1 As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select convert(varchar, decryptbykey(Read_value)) as Read_value  from Tag_data  where  convert(varchar, decryptbykey(Tag_name))  = '" & tagname & "'"
            Dim querystring1 As String = ""

            'for encrypted or  non_encypted tables
            If variableclass.is_encrypted Then
                querystring1 = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select convert(varchar, decryptbykey(Read_value)) as Read_value  from Tag_data  where  convert(varchar, decryptbykey(Tag_id))  = '" & tagid & "'"
            Else
                querystring1 = "select  Read_value  from Tag_data  where  Tag_id  = '" & tagid & "'"
            End If



            Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring1, sqlclass.rightcnn)
            sqlcmd1.ExecuteNonQuery()
            Using reader As SqlDataReader = sqlcmd1.ExecuteReader
                If reader.Read Then
                    readvalue1 = (reader.Item("Read_value"))
                End If
            End Using
            sqlcmd1.Dispose()
            ' sqlclass.rightcnn.Close()
            Return readvalue1
        Catch ex As Exception
            '  MsgBox("tagvalue:" & ex.Message)
        End Try
    End Function

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
            If Login_Register.levelid = 1 Then
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
    '-- new code to the rights of component
    Dim rvisible As Boolean = True
    Dim renable As Boolean = False
    Public Sub rightread(ByVal btn As Control, ByVal frm As Form)
        '  sql.scn3.Close()

        If btn IsNot Nothing And frm IsNot Nothing Then
            renable = False
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
                    'tempdirect = 0
                    'tempindirect = 0
                    ''  visiblecode(btn)
                    'visiblecode()
                    '  sqlcmd.Dispose()

                    '  sql.scn3.Close()
                End If
            End If
        End If
    End Sub
    Dim pvisible As Boolean
    Dim penable As Boolean
    Dim tempdirect = 0
    Dim tempindirect = 0
    'Public Sub propertyvisiblecode()
    '    'Dim cst = "::11:00:00"
    '    'Dim cspt = "::11:00:00"
    '    'Dim time = DateTime.Parse(cst)
    '    'Dim time2 = DateTime.Parse(cspt)
    '    'Dim temp = time2.Subtract(time)
    '    If Direct = False Then
    '        ' If tempdirect = 0 Or tempdirect = 2 Then
    '        'Me.Visible = False
    '        pvisible = False
    '        ' tempdirect = 1
    '        ' End If
    '    Else
    '        'If tempdirect = 1 Or tempdirect = 0 Then
    '        'Me.Visible = True
    '        pvisible = True
    '        ' tempdirect = 2
    '        ' End If

    '    End If
    '    If Me.INDirect = True Then
    '        If variableclass.m(Me.Address_Of_M) = 1 Then
    '            ' If tempindirect = 0 Or tempindirect = 2 Then
    '            '  Me.Visible = True
    '            pvisible = True
    '            '  tempindirect = 1
    '            'End If
    '        Else
    '            '    If tempindirect = 1 Or tempindirect = 0 Then
    '            'Me.Visible = False
    '            pvisible = False
    '            ' tempindirect = 2
    '            ' End If
    '        End If
    '    End If

    'End Sub

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
                sql.scon3()
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
                sql.scn3.Close()
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
                            '  Me.ReadOnly = False
                            tempenable = 1
                        End If
                    Else
                        If tempenable = 1 Or tempenable = 0 Then
                            '  renable = False
                            Me.Enabled = False
                            ' Me.ReadOnly = True
                            Me.ForeColor = Color.White
                            tempenable = 2
                        End If

                    End If

                Else

                    If tempenable = 1 Or tempenable = 0 Then
                        '  renable = False
                        Me.Enabled = False
                        '  Me.ReadOnly = True
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

    Public manual_scroll = True
    Dim Get_hlt_tag
    Dim highlight_row_tag_id = 0
    Sub highlightrow()
        Try

            If Get_hlt_tag = 0 Then
                sql.scon3()
                '' Dim querystring As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select tag_id from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & Vissible_tagname & "'"

                Dim querystring As String = ""
                'for encrypted or  non_encypted tables
                If variableclass.is_encrypted Then
                    querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select tag_id from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & highlight_row_tag & "'"
                Else
                    querystring = "select tag_id from Tag_data  where  Tag_name = '" & highlight_row_tag & "'"
                End If


                Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
                sqlcmd1.ExecuteNonQuery()
                Using reader As SqlDataReader = sqlcmd1.ExecuteReader
                    If reader.Read = True Then
                        highlight_row_tag_id = reader.Item("Tag_id")
                    End If
                End Using
                ' sqlcmd1.Dispose()
                sql.scn3.Close()
                Get_hlt_tag = 1
            End If



            If Me.Rows.Count = 0 Then
                'generaterows(row)
            Else
                For i = 0 To RowsCount - 1
                    Me.Rows(i).DefaultCellStyle.BackColor = Color.White
                Next
                'If myarray(row_hlt) > 0 Then
                '    Me.Rows(main_d(row_hlt) - 1).DefaultCellStyle.BackColor = hlt_color

                'End If
                'If variableclass.tag(highlight_row_tag_id) - 1 >= 0 Then
                '    Me.Rows(variableclass.tag(highlight_row_tag_id) - 1).DefaultCellStyle.BackColor = hlt_color
                If variableclass.tag(highlight_row_tag_id) >= 0 Then
                    Me.Rows(variableclass.tag(highlight_row_tag_id)).DefaultCellStyle.BackColor = hlt_color

                    If manual_scroll Then

                    Else
                        If variableclass.tag(highlight_row_tag_id) > 8 Then
                            Me.FirstDisplayedScrollingRowIndex = variableclass.tag(highlight_row_tag_id) - 5
                        Else
                            Me.FirstDisplayedScrollingRowIndex = 0
                        End If

                    End If
                End If




                ' Me.FirstDisplayedScrollingRowIndex = 50

                ' Console.Write("1")
            End If
        Catch ex As Exception
        End Try

    End Sub


    ' ''write value in database
    ''Sub writeIndb_bulk(ByVal address As Integer, ByVal value As String)
    ''    Try


    ''        ' Sql.scon3()
    ''        '  sqlclass.rightcon()
    ''        '  Dim querystring As String = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN  OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update Tag_detail_data set writeaddress_value = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & value & "'))  where  Tag_id = '" & address & "' COMMIT TRANSACTION"
    ''        Dim querystring As String = ""
    ''        'for encrypted or  non_encypted tables
    ''        If variableclass.is_encrypted Then
    ''            querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN  OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update Tag_detail_data set writeaddress_value = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & value & "'))  where  Tag_id = '" & address & "' COMMIT TRANSACTION"
    ''        Else
    ''            querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN  update Tag_detail_data set writeaddress_value = '" & value & "'  where  Tag_id = '" & address & "' COMMIT TRANSACTION"
    ''        End If

    ''        Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sqlclass.rightcnn)
    ''        sqlcmd1.ExecuteNonQuery()
    ''        sqlcmd1.Dispose()
    ''    Catch ex As Exception

    ''    End Try
    ''End Sub


    'write value in database

    'Dim val_change = 0
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
            ' System.Threading.Thread.Sleep(50)
        Catch ex As Exception

        End Try
        ' valchanged = 1
        ' val_change = val_change + 1
    End Sub



    'Sub writeIndb(ByVal address As Integer, ByVal value As String)
    '    Try
    '        sql.scon2()
    '        sql.scon3()
    '        Dim querystring As String = ""
    '        Dim select_query As String = "select Tag_id,value FROM Tag_detail_data where id = '1' "
    '        Dim cmd1 = New SqlCommand(select_query, sql.scn2)
    '        Dim reader As SqlDataReader = cmd1.ExecuteReader
    '        If reader.Read Then
    '            If IsDBNull(reader.Item("Tag_id")) = False Then
    '                If variableclass.is_encrypted Then
    '                    querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN  OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update Tag_detail_data set Tag_id = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'1'')) where id = 1 update Tag_detail_data set Tag_id = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & address & "')), value = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & value & "')) where id = 2 COMMIT TRANSACTION"
    '                Else
    '                    querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN update Tag_detail_data set Tag_id = '" & reader.Item(0) + 1 & "' where id = 1 update Tag_detail_data set Tag_id = '" & address & "', value = '" & value & "' where id = '" & reader.Item(0) + 1 & "' COMMIT TRANSACTION"
    '                End If
    '                Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
    '                sqlcmd1.ExecuteNonQuery()
    '                sqlcmd1.Dispose()
    '            Else
    '                If variableclass.is_encrypted Then
    '                    querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN  OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update Tag_detail_data set Tag_id = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'1'')) where id = 1 update Tag_detail_data set Tag_id = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & address & "')), value = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & value & "')) where id = 2 COMMIT TRANSACTION"
    '                Else
    '                    querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN update Tag_detail_data set Tag_id = '2' where id = 1 update Tag_detail_data set Tag_id = '" & address & "', value = '" & value & "' where id = 2 COMMIT TRANSACTION"
    '                End If
    '                Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
    '                sqlcmd1.ExecuteNonQuery()
    '                sqlcmd1.Dispose()
    '            End If
    '        End If
    '        cmd1.Dispose()
    '        sql.scn3.Close()
    '        sql.scn2.Close()
    '    Catch ex As Exception

    '    End Try
    'End Sub

    ''write value in database
    'Sub writeIndb_using_tagname(ByVal tagname As String, ByVal value As String)
    '    Try


    '        ' Sql.scon3()
    '        sqlclass.rightcon()
    '        '  Dim querystring As String = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN  OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update Tag_detail_data set writeaddress_value = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & value & "'))  where  Tag_id = '" & address & "' COMMIT TRANSACTION"
    '        Dim querystring As String = ""
    '        'for encrypted or  non_encypted tables
    '        If variableclass.is_encrypted Then
    '            querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN  OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update Tag_detail_data set writeaddress_value = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & value & "'))  where  Tagname = '" & tagname & "' COMMIT TRANSACTION"
    '        Else
    '            querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN  update Tag_detail_data set writeaddress_value = '" & value & "'  where  Tagname = '" & tagname & "' COMMIT TRANSACTION"
    '        End If

    '        Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sqlclass.rightcnn)
    '        sqlcmd1.ExecuteNonQuery()
    '        sqlcmd1.Dispose()
    '        sqlclass.rightcnn.Close()
    '    Catch ex As Exception

    '    End Try
    'End Sub






    'this array stores initial(start) tagid for each column according to given tag name for each column
    Dim tempd() As Integer
    Dim tempstopflick = 0
    'this function assign tagid to ach column
    Sub updatevalue()
        ReDim tempd(ColumnCount - 1)
        sqlclass.rightcon()
        For i = 0 To ColumnsProperty.Count - 1
            '' Dim querystring As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & Me.Columns(i).DataPropertyName & "' "
            Dim querystring As String = ""
            'for encrypted or  non_encypted tables
            If variableclass.is_encrypted Then
                '    querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & Me.Columns(i).DataPropertyName & "' "
                querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & Me.column_property(i).Tag & "' "

            Else
                'querystring = "select Tag_id from Tag_data  where  Tag_name = '" & Me.Columns(i).DataPropertyName & "' "
                querystring = "select Tag_id from Tag_data  where  Tag_name = '" & Me.column_property(i).Tag & "' "
            End If

            Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sqlclass.rightcnn)
            sqlcmd1.ExecuteNonQuery()
            Using reader As SqlDataReader = sqlcmd1.ExecuteReader
                If reader.Read = True Then
                    tempd(i) = reader.Item("Tag_id") 'gives starting tag_id to each column
                Else
                    tempd(i) = 0
                    If IsNumeric(Me.column_property(i).Tag) Then

                    Else
                        '     Me.ReadOnly = True
                    End If

                End If
            End Using
            sqlcmd1.Dispose()
        Next

        sqlclass.rightcnn.Close()
        If tempstopflick = 0 Then
            'to prevent grid from flickring
            EnableDoubleBuffered(Me)
            tempstopflick = 1
        End If

    End Sub
    Public Sub EnableDoubleBuffered(ByVal dgv As CustomDatagridView)

        Dim dgvType As Type = dgv.[GetType]()

        Dim pi As PropertyInfo = dgvType.GetProperty("DoubleBuffered", _
                                                     BindingFlags.Instance Or BindingFlags.NonPublic)

        pi.SetValue(dgv, True, Nothing)

    End Sub



















    Private Sub CustomDatagridView_CellValueChanged(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Me.CellValueChanged
        RaiseEvent dirty_state_change_event_action()
    End Sub
End Class

Public Class addcolumn2

    Private _value As String = Nothing
    Property Values() As String
        Get
            Return _value
        End Get
        Set(ByVal value As String)
            _value = value

        End Set
    End Property

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
Public Class dropdown2
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


<TypeConverterAttribute(GetType(System.ComponentModel.ExpandableObjectConverter))> _
Public Class Columns_Property_Class


    'Public Enum var_Type
    '    D_16_Bit
    '    D_32_Bit
    '    M
    '    IV
    'End Enum

    Public Enum var_Type
        Bit_16
        Bit_32
        Binary
        String_

    End Enum

    Dim col As String()


    Private _name As String
    <Browsable(True), Category("_Misc"), Description("")>
    Property _ColumnName() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

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

    Dim add
    <Browsable(True), Category("_Misc"), Description("Start Tag")>
    Property Tag As String
        Get
            Return add
        End Get
        Set(ByVal value As String)
            add = value

        End Set
    End Property

    Public Enum col_type
        TextBox
        Image
        DropDown
    End Enum
    Dim col_type1
    <Browsable(True), Category("_Misc"), Description("")>
    Property Column_Type As col_type
        Get
            Return col_type1
        End Get
        Set(ByVal value As col_type)
            col_type1 = value


        End Set
    End Property

    Dim _listcombobox As String()
    <Browsable(True), Category("DropDown Column"), Description("DropDownColumn values")>
    Property List_of_DropDownValues As String()
        Get
            Return _listcombobox
        End Get
        Set(ByVal value As String())
            _listcombobox = value
        End Set
    End Property

    Dim offimage
    <Browsable(True), Category("Image Column"), Description("Image When value is 0")>
    Property OFF_Image As Image
        Get
            Return offimage
        End Get
        Set(ByVal value As Image)
            ' Button1.Image = value
            offimage = value
        End Set
    End Property

    Dim onimage
    <Browsable(True), Category("Image Column"), Description("Image When value is 1")>
    Property ON_Image As Image
        Get
            Return onimage
        End Get
        Set(ByVal value As Image)
            ' Button1.Image = value
            onimage = value
        End Set
    End Property



    Public Enum image_action_type
        ' Momentary
        _Set
        Reset
        Toggle
    End Enum

    Dim img_action_type1 As image_action_type
    <Browsable(True), Category("Image Column"), Description("action when click on image")>
    Property Action As image_action_type
        Get
            Return img_action_type1
        End Get
        Set(ByVal value As image_action_type)
            ' Button1.Image = value
            img_action_type1 = value
        End Set
    End Property


    Public Enum input_type
        Numeric
        Text
    End Enum

    Dim input_type1 = 1
    <Browsable(True), Category("TextBox Column"), Description("whether numeric or text type input to IV value")>
    Property InputType As input_type
        Get
            Return input_type1
        End Get
        Set(ByVal value As input_type)
            ' Button1.Image = value
            input_type1 = value
        End Set
    End Property



    Dim gain1 = 1
    <Browsable(True), Category("TextBox Column"), Description("in multiple of 10 , for numeric 16 bit and 32 bit")>
    Property Gain As Integer
        Get
            Return gain1
        End Get
        Set(ByVal value As Integer)
            ' Button1.Image = value
            gain1 = value
        End Set
    End Property


    Dim _decimalval As Integer = 0
    <Category("TextBox Column"), Description("Set number of value to display after decimal")>
    Property No_of_DecimalValues As Integer
        Get
            Return _decimalval

        End Get
        Set(ByVal VALUE As Integer)
            _decimalval = VALUE
            ' Label1.Text = FormatNumber(CDbl(Label1.Text * rgain), _decimalval)
        End Set
    End Property

End Class




