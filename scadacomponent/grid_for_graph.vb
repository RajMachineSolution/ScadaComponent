Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class grid_for_graph
    Dim sql As New sqlclass

    Public Enum update_grid_from
        Tag
        Time
    End Enum
    'reference of grid from which columns x and y columns are shown in this
    Dim refrence_grid As DataGridView
    <Browsable(True), _
    Category("_Reference")>
    Property Refrence_Grid_Name As DataGridView
        Get
            Return refrence_grid
        End Get
        Set(ByVal value As DataGridView)
            refrence_grid = value
        End Set
    End Property

    'adding column to grid X
    Public x_column As String
    <Category("_Reference")>
    Property Column_name_for_x_axis As String
        Get
            Return x_column
        End Get
        Set(ByVal value As String)
            x_column = value
            Try
                'first clear columns if not cleaared and property change then extra column is added instead of removing earlier column first then add new
                Me.Columns.Clear()
                If x_column IsNot Nothing And x_column <> "" Then
                    '  Me.Columns.Add(x_column, x_column) 'header text and column name same for new column added in grid
                End If
                If y_column IsNot Nothing And y_column <> "" Then
                    ' Me.Columns.Add(y_column, y_column)
                End If
                generaterows(row_count)
            Catch ex As Exception
            End Try
        End Set
    End Property

    'adding column to grid y
    Public y_column As String
    <Category("_Reference")>
    Property Column_name_for_y_axis As String
        Get
            Return y_column
        End Get
        Set(ByVal value As String)
            y_column = value
            Try
                'first clear columns if not cleaared and property change then extra column is added instead of removing earlier column first then add new
                Me.Columns.Clear()
                If x_column IsNot Nothing And x_column <> "" Then
                    'Me.Columns.Add(x_column, x_column) 'header text and column name same for new column added in grid
                End If
                If y_column IsNot Nothing And y_column <> "" Then
                    '  Me.Columns.Add(y_column, y_column)
                End If
                generaterows(row_count)
            Catch ex As Exception
            End Try
        End Set
    End Property


    'number of row contained by grid
    Dim row_count As Integer
    <Category("_Reference")>
    Property Number_of_row As Integer
        Get
            Return row_count
        End Get
        Set(ByVal value As Integer)
            row_count = value
            Try
                generaterows(row_count)
            Catch ex As Exception
            End Try
        End Set
    End Property

    'add row to grid
    Sub generaterows(ByVal rows As Integer)
        If Me.Columns.Count > 0 Then
            If rows > 0 Then
                '  Me.RowHeadersWidata_tableh = "80"
                Me.Rows.Clear()
                Me.Rows.Add(rows)
                For i = 0 To rows - 1
                    Me.Rows(i).HeaderCell.Value = "" & i + 1
                Next
            End If
        End If
    End Sub

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
    'accoring to tag value  decide wheater grid is vissible or not
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


    Dim update_points_with As update_grid_from
    <Browsable(True), _
Category("_Tag")> _
    Property _update_points_with As update_grid_from
        Get
            Return update_points_with
        End Get
        Set(value As update_grid_from)
            update_points_with = value
            If update_points_with = update_grid_from.Time Then
                ' Timer1.Enabled = True
                Timer1.Interval = timer_interval
            End If
        End Set
    End Property

    Dim timer_interval As Integer = 100
    <Browsable(True), _
Category("_Tag")> _
    Property time_interval As Integer
        Get
            Return timer_interval
        End Get
        Set(value As Integer)
            timer_interval = value
            If update_points_with = update_grid_from.Time Then
                '  Timer1.Enabled = True
                Timer1.Interval = timer_interval
            End If
        End Set
    End Property

    Dim update_grid As Integer = 0
    Dim update_tag As String = ""
    <Browsable(True), _
Category("_Tag")> _
    Property Tag_for_update_points As String
        Get
            Return update_tag
        End Get
        Set(value As String)
            update_tag = value

        End Set
    End Property

    Dim clear_points_grid As Integer = 0
    Dim clear_point_tag As String = ""
    <Browsable(True), _
Category("_Tag")> _
    Property Tag_for_clear_point As String
        Get
            Return clear_point_tag
        End Get
        Set(value As String)
            clear_point_tag = value

        End Set
    End Property

    'singnal for graph component to be cleared or updated
    Dim update_graph As Integer = 0
    Dim clear_graph As Integer = 0

    'copy given x and y axis column from refered grid 
    Sub reflect_grid()
        visiblecode()
        Try
            If update_points_with = update_grid_from.Tag Then
                If Timer1.Enabled = True Then
                    Timer1.Enabled = False
                End If

                If update_grid = 1 Then
                    ''If refrence_grid IsNot Nothing Then
                    ''    Try

                    ''        '   Dim data_table As DataTable = New DataTable

                    ''        'data_table.Columns.Add("Sno")
                    ''        'data_table.Columns.Add(x_column)
                    ''        'data_table.Columns.Add(y_column)
                    ''        '  data_table = TryCast(Me.DataSource, DataTable)
                    ''        ' Dim row As DataRow
                    ''        'data_table.Rows.Add(Number_of_row)
                    ''        ''   
                    ''        If temp = 0 Then
                    ''            Me.DataSource = Nothing
                    ''            Me.Rows.Clear()

                    ''            '   Me.Columns.Remove(x_column)
                    ''            '   Me.Columns.Remove(y_column)
                    ''            ''  Me.Columns.Add("Sno", "Sno")
                    ''            '' Me.Columns.Add(x_column, x_column)
                    ''            ''  Me.Columns.Add(y_column, y_column)
                    ''            temp = 1
                    ''        End If

                    ''        data_table.Rows.Clear()
                    ''        '  Me.Rows.Add(Number_of_row)
                    ''        If refrence_grid.AllowUserToAddRows = True Then
                    ''            If Number_of_row <> refrence_grid.RowCount - 1 Then
                    ''                Number_of_row = refrence_grid.RowCount - 1
                    ''                data_table.Rows.Add(Number_of_row)
                    ''            End If

                    ''            For i = 0 To refrence_grid.RowCount - 2
                    ''                data_table.Rows.Add()
                    ''                data_table.Rows(i)(0) = i + 1
                    ''                '' Me.Rows(i).Cells("Sno").Value = i + 1
                    ''                data_table.Rows(i)(1) = refrence_grid.Rows(i).Cells(x_column).Value
                    ''                data_table.Rows(i)(2) = refrence_grid.Rows(i).Cells(y_column).Value
                    ''                ''Me.Rows(i).Cells("Sno").Value = i + 1
                    ''                ''Me.Rows(i).Cells(x_column).Value = refrence_grid.Rows(i).Cells(x_column).Value
                    ''                ''Me.Rows(i).Cells(y_column).Value = refrence_grid.Rows(i).Cells(y_column).Value
                    ''            Next
                    ''        ElseIf refrence_grid.AllowUserToAddRows = False Then
                    ''            If Number_of_row <> refrence_grid.RowCount Then
                    ''                Number_of_row = refrence_grid.RowCount
                    ''                data_table.Rows.Add(Number_of_row)
                    ''            End If

                    ''            For i = 0 To refrence_grid.RowCount - 1
                    ''                data_table.Rows.Add()
                    ''                data_table.Rows(i)(0) = i + 1
                    ''                '' Me.Rows(i).Cells("Sno").Value = i + 1
                    ''                data_table.Rows(i)(1) = refrence_grid.Rows(i).Cells(x_column).Value
                    ''                data_table.Rows(i)(2) = refrence_grid.Rows(i).Cells(y_column).Value
                    ''                'Me.Rows(i).Cells("Sno").Value = i + 1
                    ''                'Me.Rows(i).Cells(x_column).Value = refrence_grid.Rows(i).Cells(x_column).Value
                    ''                'Me.Rows(i).Cells(y_column).Value = refrence_grid.Rows(i).Cells(y_column).Value
                    ''            Next
                    ''        End If
                    ''        Me.DataSource = data_table
                    ''        ' update_database()
                    ''        'update_graph = 1
                    ''    Catch ex As Exception
                    ''        MsgBox("grid---" & ex.Message)
                    ''    End Try
                    ''End If
                    ''  update_database()
                    getdata_fromdatabase()
                    update_graph = 1
                    '' writeIndb(update_grid, 1)
                End If
            ElseIf update_points_with = update_grid_from.Time Then
                If Timer1.Enabled = False Then
                    Timer1.Enabled = True
                End If
            End If
            If clear_points_grid = 1 Then
                Me.Rows.Clear()
                clear_graph = 1
                'writeIndb(clear_points_grid, 1)
            End If
        Catch ex As Exception
            '  MsgBox(ex.Message)
        End Try

    End Sub

    ' Dim Me.Name As String = Me.Name
    Dim temp_getdata = 0

    Dim data_set As New DataSet
    Dim data_adapter As New SqlDataAdapter

    'get datafrom database table and store in grid
    Public Sub getdata_fromdatabase()
        Try
            '   If temp_getdata = 0 Then
            'create connection
            Me.Columns.Clear()
            '   Me.DataSource
            sql.conn1()
            Dim select_query As String = "select Sno, x as " & x_column & ", y as " & y_column & " from " & Me.Name & " "
            'data_set.Clear()
            'command for query execution
            Dim cmd = New SqlCommand(select_query, sql.cn1)
            data_adapter.SelectCommand = cmd

            'get datatable from database and show in grid
            Dim data_table As DataTable = New DataTable
            data_adapter.Fill(data_table)
            Me.DataSource = data_table
            sql.cn1.Close()
            If data_table.Rows.Count > 0 Then
                update_graph = 1
            End If
            Me.Refresh()
            temp_getdata = 1
            '     End If
        Catch ex As Exception
            '   MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub cleardata_fromdatabase()
        Try
            'create connection
            '' Me.Columns.Clear()
            '   Me.DataSource
            sql.conn1()
            Dim select_query As String = "truncate table " & Me.Name & " "
            'data_set.Clear()
            'command for query execution
            Dim cmd = New SqlCommand(select_query, sql.cn1)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            sql.cn1.Close()

            Me.Refresh()
        Catch ex As Exception
            '   MsgBox(ex.Message)
        End Try

    End Sub


    Dim sql_cmd_builder As New SqlCommandBuilder
    'update database from grid table
    Sub update_database()
        Try
            'cleardata_fromdatabase()
            '  sql.conn1()
            '  sql_cmd_builder = New SqlCommandBuilder(data_adapter)
            'Dim data_table As DataTable = New DataTable
            ''get datatable from database and show in grid
            'data_adapter.Fill(data_table)
            'Me.DataSource = data_table
            ''    Dim Update_Table = CType(Me.DataSource, DataTable)
            ' data_adapter.Update(data_table)
            ' data_set.Tables(Me.Name).AcceptChanges()
            '  data_adapter.Update(data_set, Me.Name)

            ' Me.Refresh()
            '  sql.cn1.Close()
        Catch ex As Exception
            '   MsgBox(ex.Message)
        End Try

    End Sub

    'create table in database
    Sub create_database_table()
        Try
            sql.conn1()
            sql.conn2()
            Dim select_table_query = "select * from sys.TABLES where name = '" & Me.Name & "' "
            Dim cmd = New SqlCommand(select_table_query, sql.cn1)
            Using reader As SqlDataReader = cmd.ExecuteReader
                If reader.Read Then
                Else
                    cmd.Dispose()
                    Dim create_table_query = "create table " & Me.Name & "( SNo int identity(1,1) NOT NULL PRIMARY KEY, x varchar(max) null, y varchar(max) null)"
                    cmd = New SqlCommand(create_table_query, sql.cn2)
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()
                End If
                reader.Close()
            End Using
            sql.cn2.Close()
            sql.cn1.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try

    End Sub



    'Assign levels by right click
    Private Sub RECIPE_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown

        If e.Button = Windows.Forms.MouseButtons.Right Then

            If Login_Register.levelid = 1 Or Login_Register.levelid = Login_Register.mngr Then

                Dim btnp As New buttonproperty(Me.Parent.FindForm.Name, Me.Name, Me.Location.X, Me.Location.Y)
                btnp.TopMost = True
                btnp.showselected(Me, Me.FindForm)
                btnp.StartPosition = FormStartPosition.CenterParent
                btnp.ShowDialog()
            End If
        Else

        End If
        '  
    End Sub


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
                sql.scon3()
                Dim querystring As String = ""
                'for encrypted or  non_encypted tables
                If variableclass.is_encrypted Then
                    querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id from Tag_data  where convert(varchar, decryptbykey(Tag_name)) = '" & Vissible_tagname & "'"
                Else
                    querystring = "select Tag_id from Tag_data  where Tag_name = '" & Vissible_tagname & "'"
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


    ''Sub writeIndb(ByVal address As Integer, ByVal value As Integer)
    ''    Try
    ''        sql.scon2()
    ''        sql.scon3()
    ''        Dim querystring As String = ""
    ''        Dim select_query As String = "select Tag_id,value FROM Tag_detail_data where id = '1' "
    ''        Dim cmd1 = New SqlCommand(select_query, sql.scn2)
    ''        Dim reader As SqlDataReader = cmd1.ExecuteReader
    ''        If reader.Read Then
    ''            If IsDBNull(reader.Item("Tag_id")) = False Then
    ''                If variableclass.is_encrypted Then
    ''                    querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN  OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update Tag_detail_data set Tag_id = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'1'')) where id = 1 update Tag_detail_data set Tag_id = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & address & "')), value = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & value & "')) where id = 2 COMMIT TRANSACTION"
    ''                Else
    ''                    querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN update Tag_detail_data set Tag_id = '" & reader.Item(0) + 1 & "' where id = 1 update Tag_detail_data set Tag_id = '" & address & "', value = '" & value & "' where id = '" & reader.Item(0) + 1 & "' COMMIT TRANSACTION"
    ''                End If
    ''                Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
    ''                sqlcmd1.ExecuteNonQuery()
    ''                sqlcmd1.Dispose()
    ''            Else
    ''                If variableclass.is_encrypted Then
    ''                    querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN  OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update Tag_detail_data set Tag_id = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'1'')) where id = 1 update Tag_detail_data set Tag_id = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & address & "')), value = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & value & "')) where id = 2 COMMIT TRANSACTION"
    ''                Else
    ''                    querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN update Tag_detail_data set Tag_id = '2' where id = 1 update Tag_detail_data set Tag_id = '" & address & "', value = '" & value & "' where id = 2 COMMIT TRANSACTION"
    ''                End If
    ''                Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
    ''                sqlcmd1.ExecuteNonQuery()
    ''                sqlcmd1.Dispose()
    ''            End If
    ''        End If
    ''        cmd1.Dispose()
    ''        sql.scn3.Close()
    ''        sql.scn2.Close()
    ''    Catch ex As Exception

    ''    End Try
    ''End Sub

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


    Dim tempwrite = 0 'if it is 1 means user entered tag is exist in database and its value is assigned to write address else wirteaddress = 0
    Dim tempread = 0  'if it is 1 means user entered tag is exist in database and its value is assigned to read address  else readaddress = 0
    'function which update read and write address of component from tag name
    Sub updatevalue()
        sql.scon3()
        Dim querystring As String = ""
        'for encrypted or  non_encypted tables
        If variableclass.is_encrypted Then
            querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id, convert(varchar, decryptbykey(Tag_name)) as Tag_name from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & update_tag & "' or convert(varchar, decryptbykey(Tag_name)) = '" & clear_point_tag & "' "
        Else
            querystring = "select Tag_id, Tag_name from Tag_data  where  Tag_name = '" & update_tag & "' or Tag_name = '" & clear_point_tag & "' "
        End If
        ' Dim querystring As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id, convert(varchar, decryptbykey(Tag_name)) as Tag_name from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & update_tag & "' or convert(varchar, decryptbykey(Tag_name)) = '" & clear_point_tag & "' "

        Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
        sqlcmd1.ExecuteNonQuery()
        Using reader As SqlDataReader = sqlcmd1.ExecuteReader

            While reader.Read
                If reader.Item("Tag_name") = update_tag Then
                    update_grid = reader.Item("Tag_id")
                    tempwrite = 1
                End If
                If reader.Item("Tag_name") = clear_point_tag Then
                    clear_points_grid = reader.Item("Tag_id")
                    tempread = 1
                End If
            End While
            If tempwrite = 0 Then
                update_grid = 0
                '  Me._Readonly = True
            End If
            If tempread = 0 Then
                clear_points_grid = 0
                '    Me._Readonly = True
            End If
        End Using
        ' sqlcmd1.Dispose()
        sql.scn3.Close()
    End Sub
    ' Dim data_table As New DataTable
    Dim temp = 0
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        'If refrence_grid IsNot Nothing Then
        '    Try

        '        '   Dim data_table As DataTable = New DataTable

        '        'data_table.Columns.Add("Sno")
        '        'data_table.Columns.Add(x_column)
        '        'data_table.Columns.Add(y_column)
        '        '  data_table = TryCast(Me.DataSource, DataTable)
        '        ' Dim row As DataRow
        '        'data_table.Rows.Add(Number_of_row)
        '        ''   
        '        If temp = 0 Then
        '            Me.DataSource = Nothing
        '            Me.Rows.Clear()

        '            '   Me.Columns.Remove(x_column)
        '            '   Me.Columns.Remove(y_column)
        '            ''  Me.Columns.Add("Sno", "Sno")
        '            '' Me.Columns.Add(x_column, x_column)
        '            ''  Me.Columns.Add(y_column, y_column)
        '            temp = 1
        '        End If

        '        data_table.Rows.Clear()
        '        '  Me.Rows.Add(Number_of_row)
        '        If refrence_grid.AllowUserToAddRows = True Then
        '            If Number_of_row <> refrence_grid.RowCount - 1 Then
        '                Number_of_row = refrence_grid.RowCount - 1
        '                data_table.Rows.Add(Number_of_row)
        '            End If

        '            For i = 0 To refrence_grid.RowCount - 2
        '                data_table.Rows.Add()
        '                data_table.Rows(i)(0) = i + 1
        '                '' Me.Rows(i).Cells("Sno").Value = i + 1
        '                data_table.Rows(i)(1) = refrence_grid.Rows(i).Cells(x_column).Value
        '                data_table.Rows(i)(2) = refrence_grid.Rows(i).Cells(y_column).Value
        '                ''Me.Rows(i).Cells("Sno").Value = i + 1
        '                ''Me.Rows(i).Cells(x_column).Value = refrence_grid.Rows(i).Cells(x_column).Value
        '                ''Me.Rows(i).Cells(y_column).Value = refrence_grid.Rows(i).Cells(y_column).Value
        '            Next
        '        ElseIf refrence_grid.AllowUserToAddRows = False Then
        '            If Number_of_row <> refrence_grid.RowCount Then
        '                Number_of_row = refrence_grid.RowCount
        '                data_table.Rows.Add(Number_of_row)
        '            End If

        '            For i = 0 To refrence_grid.RowCount - 1
        '                data_table.Rows.Add()
        '                data_table.Rows(i)(0) = i + 1
        '                '' Me.Rows(i).Cells("Sno").Value = i + 1
        '                data_table.Rows(i)(1) = refrence_grid.Rows(i).Cells(x_column).Value
        '                data_table.Rows(i)(2) = refrence_grid.Rows(i).Cells(y_column).Value
        '                'Me.Rows(i).Cells("Sno").Value = i + 1
        '                'Me.Rows(i).Cells(x_column).Value = refrence_grid.Rows(i).Cells(x_column).Value
        '                'Me.Rows(i).Cells(y_column).Value = refrence_grid.Rows(i).Cells(y_column).Value
        '            Next
        '        End If
        '        Me.DataSource = data_table
        getdata_fromdatabase()
        ' update_database()
        update_graph = 1
        '    Catch ex As Exception
        '        MsgBox("grid---" & ex.Message)
        '    End Try
        'End If
    End Sub
End Class

