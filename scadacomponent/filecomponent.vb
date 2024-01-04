Imports System.IO
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.ComponentModel


Public Class filecomponent
    Dim user_variableD As String() = {}
    Dim vc As New variableclass
    Dim sql As New sqlclass
    Public Enum record_Filein
        InDatabase
        InSystem
    End Enum
    <Browsable(False)>
    Public Property UservariableD As String()
        Get
            Return user_variableD
        End Get
        Set(ByVal value As String())
            If value.Length <> 0 Then
                user_variableD = value
                '  userlevelinsert(user_level)
                'sqlclass.dbid = value
            Else
                user_variableD = New String() {}
            End If
        End Set
    End Property

    Dim UservariablevalueD As String() = {}

    Dim user_variableM As String() = {}
    <Browsable(False)>
    Public Property UservariableM As String()
        Get
            Return user_variableM
        End Get
        Set(ByVal value As String())
            If value.Length <> 0 Then
                user_variableM = value
                '  userlevelinsert(user_level)
                'sqlclass.dbid = value
            Else
                user_variableM = New String() {}
            End If
        End Set
    End Property
    Dim internal_variableindex As String() = {}
    <Browsable(False)>
    Public Property internalvariableindex As String()
        Get
            Return internal_variableindex
        End Get
        Set(ByVal value As String())
            If value.Length <> 0 Then
                internal_variableindex = value
                '  userlevelinsert(user_level)
                'sqlclass.dbid = value
            Else
                internal_variableindex = New String() {}
            End If
        End Set
    End Property
    Dim internal_variablevalue As String() = {}


    Dim UservariablevalueM As String() = {}

    Dim Tag_list As String() = {}
    'list of names of all tag included in recipe
    Public Property TagList As String()
        Get
            Return Tag_list
        End Get
        Set(ByVal value As String())
            If value.Length <> 0 Then
                Tag_list = value
                '  userlevelinsert(user_level)
                'sqlclass.dbid = value
            Else
                Tag_list = New String() {}
            End If
        End Set
    End Property
    Dim file_path As String = ""
    Public Property FilePath As String
        Get
            Return file_path
        End Get
        Set(ByVal value As String)
            If value.Length <> 0 Then
                file_path = value
                '  userlevelinsert(user_level)
                'sqlclass.dbid = value
            Else
                file_path = ""
            End If
        End Set
    End Property
    Dim file_name As String = ""
    Public Property Filename As String
        Get
            Return file_name
        End Get
        Set(ByVal value As String)
            If value.Length <> 0 Then
                file_name = value
                '  userlevelinsert(user_level)
                'sqlclass.dbid = value
            Else
                file_name = ""
            End If
        End Set
    End Property
    Dim file_extension As String = ""
    <Browsable(False)>
    Public Property Fileextension As String
        Get
            Return file_extension
        End Get
        Set(ByVal value As String)
            If value.Length <> 0 Then
                file_extension = value
                '  userlevelinsert(user_level)
                'sqlclass.dbid = value
            Else
                file_extension = ""
            End If
        End Set
    End Property
    ' to store file detail in database or in system
    Dim record_file As record_Filein
    Public Property Record_file_In As record_Filein
        Get
            Return record_file
        End Get
        Set(ByVal value As record_Filein)

            record_file = value
            '  userlevelinsert(user_level)
            'sqlclass.dbid = value
        End Set
    End Property
    Dim filenamein_database As Boolean = False
    Public Property Filenameindatabase As Boolean
        Get
            Return filenamein_database
        End Get
        Set(ByVal value As Boolean)

            filenamein_database = value
            '  userlevelinsert(user_level)
            'sqlclass.dbid = value
        End Set
    End Property
    Dim recordevent As Boolean = False
    Public Property Recordfileevent As Boolean
        Get
            Return recordevent
        End Get
        Set(ByVal value As Boolean)

            recordevent = value
            '  userlevelinsert(user_level)
            'sqlclass.dbid = value
        End Set
    End Property
    Dim filesave_id As String = ""
    Public Property fileId As String
        Get
            Return filesave_id
        End Get
        Set(ByVal value As String)
            If value.Length <> 0 Then
                filesave_id = value
                '  userlevelinsert(user_level)
                'sqlclass.dbid = value
            Else
                filesave_id = ""
            End If
        End Set
    End Property
    '------------file save in database/system------------------
    Public Sub savefile()
        Dim ev As New eventlists
        If Record_file_In.ToString = "InDatabase" Then

            If Filename.Trim.Length <> 0 Then
            Else
                MessageBox.Show("Please enter file name to save file", "Message")
                Exit Sub
            End If
            'check file with same name and id already exist or not
            If checkfile(filesave_id, Filename) = True Then
                Dim result As Integer = MessageBox.Show("Recipe Already exist! Do you to want overwrite it ?", "Save Recipe", MessageBoxButtons.YesNoCancel)
                If result = DialogResult.Cancel Then
                    ' MessageBox.Show("Cancel pressed")
                ElseIf result = DialogResult.No Then
                    '    MessageBox.Show("No pressed")
                ElseIf result = DialogResult.Yes Then
                    'delete existing recipe
                    deletefilefromdb()
                    'save new recipe
                    updatefile()
                    MessageBox.Show("Recipe saved successfully", "Message")
                End If

            Else
                'save recipe
                updatefile()
                If Filenameindatabase = True Then
                    Dim recipeid As Integer = GetRecipeID(Filename, fileId)
                    If recipeid = 0 Then
                        ' saveCIPrecipe(recipename)
                        savefileInDB(Filename, fileId)
                        MessageBox.Show("Recipe saved successfully", "Message")
                    End If
                End If
                If Recordfileevent = True Then
                    '-- record event in database
                End If

            End If
        Else
            '-------code for saving recipe file in system
            If (Not System.IO.Directory.Exists(FilePath & "\")) Then
                System.IO.Directory.CreateDirectory(FilePath & "\")
            End If
            If Filename.Trim.Length <> 0 Or FilePath.Trim.Length <> 0 Then
            Else
                MessageBox.Show("Please enter file name and filepath to save file", "Message")
                Exit Sub
            End If

            Dim FILE_NAME As String = FilePath & "\" & Filename & ".txt"
            Dim encryptedfile = FILE_NAME.Substring(0, (FILE_NAME.ToString.Length - 4)) & "_enc.encrypt"
            '  Dim encryptedfile = FilePath & "\" & Filename & ".txt"
            'read value on each tag and store with tagname from table
            'ReDim UservariablevalueD(TagList.Count)
            resizearray()
            Dim temp = 0
            sql.scon3()
            For i = 0 To TagList.Length - 1

                Dim querystring As String = ""
                If TagList(i).Contains("#") Then
                    ''querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select convert(varchar, decryptbykey(tagname)) as tagname, convert(varchar, decryptbykey(Readaddress_value)) as Readaddress_value from Tag_detail_data  where  convert(varchar, decryptbykey(tagname)) = '" & TagList(i) & "'"
                    querystring = ""
                    'for encrypted or  non_encypted tables
                    If variableclass.is_encrypted Then
                        querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select convert(varchar, decryptbykey(tagname)) as tagname, convert(varchar, decryptbykey(Readaddress_value)) as Readaddress_value from Tag_detail_data  where  convert(varchar, decryptbykey(tagname)) = '" & TagList(i) & "'"
                    Else
                        querystring = "select tagname, Readaddress_value from Tag_detail_data  where  tagname = '" & TagList(i) & "'"
                    End If

                Else
                    '' querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select convert(varchar, decryptbykey(tagname)) as tagname, convert(varchar, decryptbykey(Readaddress_value)) as Readaddress_value from Tag_detail_data  where  convert(varchar, decryptbykey(tagname)) like '" & TagList(i) & "#%'"
                    querystring = ""
                    'for encrypted or  non_encypted tables
                    If variableclass.is_encrypted Then
                        querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select convert(varchar, decryptbykey(tagname)) as tagname, convert(varchar, decryptbykey(Readaddress_value)) as Readaddress_value from Tag_detail_data  where  convert(varchar, decryptbykey(tagname)) like '" & TagList(i) & "#%'"
                    Else
                        querystring = "select tagname , Readaddress_value from Tag_detail_data  where  tagname like '" & TagList(i) & "#%'"
                    End If


                End If
            Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
                Using reader As SqlDataReader = sqlcmd1.ExecuteReader
                    While (reader.Read)
                        'store tagname and corresponding value in uservariablevalueD array to write in file
                        UservariablevalueD(temp) = reader.Item("tagname") & " = " & reader.Item("readaddress_value")
                        temp = temp + 1
                    End While
                    reader.Close()
                End Using
            Next
            sql.scn3.Close()
            If System.IO.File.Exists(encryptedfile) = True Then

                Dim result As Integer = MessageBox.Show("Recipe Already exist! Do you to want overwrite it ?", "Save Recipe", MessageBoxButtons.YesNoCancel)
                If result = DialogResult.Cancel Then
                    ' MessageBox.Show("Cancel pressed")
                ElseIf result = DialogResult.No Then
                    '    MessageBox.Show("No pressed")
                ElseIf result = DialogResult.Yes Then
                    ev.DecryptFile(encryptedfile)
                    Dim w1 As New System.IO.StreamWriter(FILE_NAME)

                    '15 numeric entries
                    If UservariablevalueD.Length > 0 Then
                        '     MsgBox(String.Join(",", UservariablevalueD))
                        'code for writing file
                        w1.WriteLine(String.Join(",", UservariablevalueD))

                    End If

                    If Recordfileevent = True Then
                        '-- record event in database
                    End If
                    w1.Close()
                    ev.EncryptFile(FILE_NAME)
                End If

            Else
                Dim w As New System.IO.StreamWriter(FILE_NAME, True)

                '15 numeric entries
                If UservariablevalueD.Length > 0 Then
                    '   MsgBox(String.Join(",", UservariablevalueD))
                    'code for writing file
                    w.WriteLine(String.Join(",", UservariablevalueD))
                End If

                If Filenameindatabase = True Then
                    Dim recipeid As Integer = GetRecipeID(Filename, filesave_id)
                    If recipeid = 0 Then
                        ' saveCIPrecipe(recipename)
                        savefileInDB(Filename, filesave_id)
                        MessageBox.Show("Recipe saved successfully", "Message")
                    End If
                End If
                If Recordfileevent = True Then
                    '-- record event in database
                End If
                w.Close()
                ev.EncryptFile(FILE_NAME)
            End If
        End If

    End Sub
    '--savefile this function same the file on the basis properties 
    'Public Sub save_file()
    '    Dim ev As New eventlists
    '    If (Not System.IO.Directory.Exists(FilePath & "\")) Then
    '        System.IO.Directory.CreateDirectory(FilePath & "\")
    '    End If
    '    If Filename.Trim.Length <> 0 Or FilePath.Trim.Length <> 0 Then
    '    Else
    '        MessageBox.Show("Please enter file name and filepath to save file", "Message")
    '        Exit Sub
    '    End If



    '    Dim FILE_NAME As String = FilePath & "\" & Filename & ".txt"
    '    Dim encryptedfile = FILE_NAME.Substring(0, (FILE_NAME.ToString.Length - 4)) & "_enc.encrypt"
    '    '  Dim encryptedfile = FilePath & "\" & Filename & ".txt"
    '    For i = 0 To TagList.Length - 1
    '        sql.scon3()

    '        Dim querystring As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select readaddress_value from Tag_detail_data  where  tagname = '" & TagList(i) & "'"
    '        Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
    '        sqlcmd1.ExecuteNonQuery()
    '        Using reader As SqlDataReader = sqlcmd1.ExecuteReader

    '            UservariablevalueD(i) = TagList(i) & " = " & reader.Item("readaddress_value")


    '            reader.Close()
    '        End Using

    '        ' sqlcmd1.Dispose()

    '        sql.scn3.Close()
    '    Next
    '    'For i = 0 To UservariableD.Length - 1
    '    '    UservariablevalueD(i) = "D" & UservariableD(i) & "=" & variableclass.d(UservariableD(i))
    '    'Next
    '    'For i = 0 To UservariableM.Length - 1
    '    '    UservariablevalueM(i) = "M" & UservariableM(i) & "=" & variableclass.m(UservariableM(i))
    '    '    ' m(Component12.UservariableM(i)) = Component12.UservariablevalueM(i)
    '    'Next
    '    'For i = 0 To internalvariableindex.Length - 1
    '    '    internal_variablevalue(i) = "I" & internalvariableindex(i) & "=" & variableclass.iv(internalvariableindex(i))
    '    '    ' m(Component12.UservariableM(i)) = Component12.UservariablevalueM(i)
    '    'Next
    '    If System.IO.File.Exists(encryptedfile) = True Then

    '        Dim result As Integer = MessageBox.Show("Recipe Already exist! Do you to want overwrite it ?", "Save Recipe", MessageBoxButtons.YesNoCancel)
    '        If result = DialogResult.Cancel Then
    '            ' MessageBox.Show("Cancel pressed")
    '        ElseIf result = DialogResult.No Then
    '            '    MessageBox.Show("No pressed")
    '        ElseIf result = DialogResult.Yes Then
    '            ev.DecryptFile(encryptedfile)
    '            Dim w1 As New System.IO.StreamWriter(FILE_NAME)

    '            '15 numeric entries
    '            If UservariablevalueD.Length > 0 Then
    '                '     MsgBox(String.Join(",", UservariablevalueD))
    '                w1.WriteLine(String.Join(",", UservariablevalueD))

    '            End If
    '            'If UservariablevalueM.Length > 0 Then
    '            '    '    MsgBox(String.Join(",", UservariablevalueM))
    '            '    w1.WriteLine(String.Join(",", UservariablevalueM))

    '            'End If
    '            'If internal_variablevalue.Length > 0 Then
    '            '    '   MsgBox(String.Join(",", internal_variablevalue))
    '            '    w1.WriteLine(String.Join(",", internal_variablevalue))

    '            'End If
    '            If Recordfileevent = True Then
    '                '-- record event in database
    '            End If
    '            w1.Close()
    '            ev.EncryptFile(FILE_NAME)
    '        End If

    '    Else
    '        Dim w As New System.IO.StreamWriter(FILE_NAME, True)

    '        '15 numeric entries
    '        If UservariablevalueD.Length > 0 Then
    '            '   MsgBox(String.Join(",", UservariablevalueD))
    '            w.WriteLine(String.Join(",", UservariablevalueD))
    '        End If
    '        'If UservariablevalueM.Length > 0 Then
    '        '    '  MsgBox(String.Join(",", UservariablevalueM))
    '        '    w.WriteLine(String.Join(",", UservariablevalueM))
    '        'End If
    '        'If internal_variablevalue.Length > 0 Then
    '        '    ' MsgBox(String.Join(",", internal_variablevalue))
    '        '    w.WriteLine(String.Join(",", internal_variablevalue))

    '        'End If
    '        If Filenameindatabase = True Then
    '            Dim recipeid As Integer = GetRecipeID(Filename, filesave_id)
    '            If recipeid = 0 Then
    '                ' saveCIPrecipe(recipename)
    '                savefileInDB(Filename, filesave_id)
    '                MessageBox.Show("Recipe saved successfully", "Message")
    '            End If
    '        End If
    '        If Recordfileevent = True Then
    '            '-- record event in database
    '        End If
    '        w.Close()
    '        ev.EncryptFile(FILE_NAME)
    '    End If

    'End Sub

    Function GetRecipeID(ByVal recipe As String, ByVal type As Integer) As Integer

        Dim query As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 Select recipeid from recipesaved where CONVERT(varchar, DecryptByKey(recipename))='" & recipe & "'  and typerecipe='" & type & "'"
        sql.scon1()
        Dim sqlcmd As SqlCommand = New SqlCommand(query, sql.scn1)
        Dim reader As SqlDataReader = sqlcmd.ExecuteReader
        If reader.Read Then
            Return reader.Item(0)
        Else
            Return 0
        End If
        reader.Close()
        sqlcmd.Dispose()
        sql.scn1.Close()
    End Function
    '-- save filename in database with fileid
    Sub savefileInDB(ByVal fname As String, ByVal type As Integer)
        'Insert new recipe in database with recipename and type
        sql.scon2()
        Dim querystring As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into recipesaved (recipename,typerecipe) values (EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & Filename & "')),'" & type & "')"
        Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn2)
        sqlcmd1.ExecuteNonQuery()
        sqlcmd1.Dispose()
        sql.scn2.Close()


    End Sub
    Dim numobj As New numericentry
    '-- openfile this sub open the ssaved file if exist and then assign the value to uservariablevalue 
    Dim tf() As String
    Public Sub openfile()
        Dim ev As New eventlists
        Dim fo As String
        Dim i As Integer = 0
        Dim j As Integer

        Dim FILE_NAME As String
        If Record_file_In.ToString = "InDatabase" Then
            If Filename.Trim.Length <> 0 Then
            Else
                MessageBox.Show("Please enter file name", "Message")
                Exit Sub
            End If
            ' FILE_NAME = FilePath & "\" & Filename & ".txt"

            Try
                'check wheather recipe file exist or not
                If checkfile(filesave_id, Filename) = True Then
                    Dim query As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 Select CONVERT(varchar, DecryptByKey(tagname)) as tagname, CONVERT(varchar, DecryptByKey(value)) as value from recipe_file where CONVERT(varchar, DecryptByKey(file_name))='" & Filename & "'  and file_id ='" & filesave_id & "'"
                    sql.scon1()
                    Dim sqlcmd As SqlCommand = New SqlCommand(query, sql.scn1)
                    Dim reader As SqlDataReader = sqlcmd.ExecuteReader
                    While reader.Read
                        'write saved values of tags on corresonding address
                        writeIndb(reader.Item("tagname"), reader.Item("value"))

                    End While
                    reader.Close()
                    sqlcmd.Dispose()
                    sql.scn1.Close()
                    MessageBox.Show("Recipe Loaded Successfully", "Message")
                Else
                    MessageBox.Show("Recipe Doesn't Exist", "Message")
                End If
                ' Dim filepath As String = "D:\Fidus\" & ComPar(0, i) & ".txt"

            Catch ex As Exception
                ' ev.EncryptFile(FILE_NAME)
                MsgBox("Class1- loadtoarray: " & ex.Message)

            End Try
        Else
            '-------if file exist in system----------
            If Filename.Trim.Length <> 0 Or FilePath.Trim.Length <> 0 Then
            Else
                MessageBox.Show("Please enter file name and filepath to open file", "Message")
                Exit Sub
            End If
            FILE_NAME = FilePath & "\" & Filename & ".txt"

            Try
                ' OpenFileDialog1.ShowDialog()
                If File.Exists(FILE_NAME) = True Then
                    ev.EncryptFile(FILE_NAME)
                End If
                ' Dim filepath As String = "D:\Fidus\" & ComPar(0, i) & ".txt"
                Dim encryptedFile As String = (FILE_NAME.Substring(0, FILE_NAME.Length - 4)) & "_enc.encrypt"
                '  Dim encryptedFile As String = FILE_NAME
                If File.Exists(encryptedFile) = True Then
                    ev.DecryptFile(encryptedFile)


                    If File.Exists(FILE_NAME) Then

                        Dim b As New System.IO.StreamReader(FILE_NAME)


                        'this sub  ReDim tf(TagList.Length)
                        resizearray()
                        fo = (b.ReadLine)
                        '   MsgBox(fo)
                        tf = fo.Split(",")

                        If fo = "" Then
                            '  Exit Sub
                        Else
                            For i = 0 To tf.Length - 2
                                'MsgBox(tf(i))
                                Dim temp1index = tf(i).Substring(0, tf(i).IndexOf("=") - 1) 'this is the address 
                                ' MsgBox(temp1index)
                                Dim temp2valve = tf(i).Substring(tf(i).IndexOf("=") + 1) ' value of the address
                                '  MsgBox(temp2valve)
                                ' variableclass.wd(temp1index) = temp2valve
                                If variableclass.without_plc = True Then
                                    ' variableclass.d(temp1index) = temp2valve
                                    writeIndb(temp1index, temp2valve)
                                Else

                                    plcclass.write_single_DValue(temp1index, temp2valve)

                                End If
                            Next
                        End If

                        b.Close()
                        ev.EncryptFile(FILE_NAME)

                        MessageBox.Show("Recipe Loaded Successfully", "Message")

                    Else
                        MessageBox.Show("Recipe Doesn't Exist", "Message")
                    End If

                    ' ev.EncryptFile(FILE_NAME)

                End If
            Catch ex As Exception
                ' ev.EncryptFile(FILE_NAME)
                MsgBox("Class1- loadtoarray: " & ex.Message)

            End Try
        End If

    End Sub
    'Public Sub open_file()
    '    Dim ev As New eventlists
    '    Dim fo As String
    '    Dim i As Integer = 0
    '    Dim j As Integer
    '    Dim tf() As String
    '    Dim FILE_NAME As String
    '    If Filename.Trim.Length <> 0 Or FilePath.Trim.Length <> 0 Then
    '    Else
    '        MessageBox.Show("Please enter file name and filepath to open file", "Message")
    '        Exit Sub
    '    End If
    '    FILE_NAME = FilePath & "\" & Filename & ".txt"

    '    Try
    '        ' OpenFileDialog1.ShowDialog()
    '        If File.Exists(FILE_NAME) = True Then
    '            ev.EncryptFile(FILE_NAME)
    '        End If
    '        ' Dim filepath As String = "D:\Fidus\" & ComPar(0, i) & ".txt"
    '        Dim encryptedFile As String = (FILE_NAME.Substring(0, FILE_NAME.Length - 4)) & "_enc.encrypt"
    '        '  Dim encryptedFile As String = FILE_NAME
    '        If File.Exists(encryptedFile) = True Then
    '            ev.DecryptFile(encryptedFile)


    '            If File.Exists(FILE_NAME) Then

    '                Dim b As New System.IO.StreamReader(FILE_NAME)


    '                '   ReDim tf(UservariableD.Length)
    '                ReDim tf(TagList.Length)
    '                fo = (b.ReadLine)
    '                '   MsgBox(fo)
    '                tf = fo.Split(",")

    '                If fo = "" Then
    '                    '  Exit Sub
    '                Else
    '                    For i = 0 To tf.Length - 2
    '                        'MsgBox(tf(i))
    '                        Dim temp1index = tf(i).Substring(1, tf(i).IndexOf("=") - 1) 'this is the address 
    '                        ' MsgBox(temp1index)
    '                        Dim temp2valve = tf(i).Substring(tf(i).IndexOf("=") + 1) ' value of the address
    '                        '  MsgBox(temp2valve)
    '                        ' variableclass.wd(temp1index) = temp2valve
    '                        If variableclass.without_plc = True Then
    '                            ' variableclass.d(temp1index) = temp2valve
    '                            writeIndb(temp1index, temp2valve)
    '                        Else

    '                            plcclass.write_single_DValue(temp1index, temp2valve)

    '                        End If
    '                    Next
    '                End If

    '                'ReDim tf(UservariableM.Length)
    '                'fo = (b.ReadLine)
    '                'tf = fo.Split(",")
    '                ''  MsgBox(fo)
    '                'If fo = "" Then
    '                '    '  Exit Sub
    '                'Else
    '                '    For i = 0 To tf.Length - 2
    '                '        Dim temp1index = tf(i).Substring(1, tf(i).IndexOf("=") - 1) 'this is the address 
    '                '        Dim temp2valve = tf(i).Substring(tf(i).IndexOf("=") + 1) ' value of the address

    '                '        'variableclass.wm(temp1index) = temp2valve
    '                '        ' plcclass.wrtie_m_singlevalue(temp1index, temp2valve)
    '                '        If variableclass.without_plc = True Then
    '                '            variableclass.m(temp1index) = temp2valve
    '                '        Else

    '                '            plcclass.wrtie_m_singlevalue(temp1index, temp2valve)
    '                '        End If
    '                '    Next
    '                'End If
    '                'ReDim tf(internalvariableindex.Length)
    '                'fo = (b.ReadLine)
    '                'tf = fo.Split(",")
    '                ''    MsgBox(fo)
    '                'If fo = "" Then
    '                '    '  Exit Sub
    '                'Else
    '                '    For i = 0 To tf.Length - 2
    '                '        Dim temp1index = tf(i).Substring(1, tf(i).IndexOf("=") - 1)
    '                '        Dim temp2valve = tf(i).Substring(tf(i).IndexOf("=") + 1)

    '                '        variableclass.iv(temp1index) = temp2valve
    '                '        ' plcclass.write_single_DValue(temp1index, temp2valve)
    '                '    Next
    '                'End If

    '                ''MsgBox("No. of rows updated = " & " " & dgv3.RowCount - 1)

    '                ''When connected to plc... simply write value to plc 
    '                ''For demo I am simply setting value directly
    '                ''which should not be done when plc is connected

    '                'If Recordfileevent = True Then
    '                '    '-- record event in database
    '                'End If
    '                b.Close()
    '                ev.EncryptFile(FILE_NAME)

    '                MessageBox.Show("Recipe Loaded Successfully", "Message")

    '            Else
    '                MessageBox.Show("Recipe Doesn't Exist", "Message")
    '            End If

    '            ' ev.EncryptFile(FILE_NAME)

    '        End If
    '    Catch ex As Exception
    '        ' ev.EncryptFile(FILE_NAME)
    '        MsgBox("Class1- loadtoarray: " & ex.Message)

    '    End Try
    'End Sub
    Public Sub deletefile()
        If Record_file_In.ToString = "InDatabase" Then
            'delete file deletes saved in database
            deletefilefromdb()
            If filenamein_database = True Then
                Dim sql As New sqlclass
                sql.scon2()
                Dim querystring As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 delete from recipesaved where CONVERT(varchar, DecryptByKey(recipename))='" & Filename & "' and typerecipe='" & fileId & "'"
                Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn2)
                sqlcmd1.ExecuteNonQuery()
                sqlcmd1.Dispose()
                sql.scn2.Close()
            End If
            MessageBox.Show("recipe deleted")
        Else
            Dim FileToDelete As String
            FileToDelete = FilePath & "\" & Filename & ".txt"

            Try
                ' OpenFileDialog1.ShowDialog()
                If File.Exists(FileToDelete) = True Then
                    'ev.EncryptFile(file_name)
                End If
                ' Dim filepath As String = "D:\Fidus\" & ComPar(0, i) & ".txt"
                Dim encryptedFile As String = (FileToDelete.Substring(0, FileToDelete.Length - 4)) & "_enc.encrypt"

                FileToDelete = encryptedFile

                If System.IO.File.Exists(FileToDelete) = True Then
                    Dim result As Integer = MessageBox.Show("! Do you  want to delete Recipe ?", "Delete Recipe", MessageBoxButtons.YesNoCancel)
                    If result = DialogResult.Cancel Then
                        ' MessageBox.Show("Cancel pressed")
                    ElseIf result = DialogResult.No Then
                        '    MessageBox.Show("No pressed")
                    ElseIf result = DialogResult.Yes Then
                        If filenamein_database = True Then
                            Dim sql As New sqlclass
                            sql.scon2()
                            Dim querystring As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 delete from recipesaved where CONVERT(varchar, DecryptByKey(recipename))='" & Filename & "' and typerecipe='" & fileId & "'"
                            Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn2)
                            sqlcmd1.ExecuteNonQuery()
                            sqlcmd1.Dispose()
                            sql.scn2.Close()
                        End If
                        System.IO.File.Delete(FileToDelete)
                        If Recordfileevent = True Then
                            '-- record event in database
                        End If
                        MessageBox.Show("File Deleted Sucessfully", "Message")
                    End If
                End If
            Catch ex As Exception
            End Try

        End If


    End Sub

    'it checks wheater file with same id and name exist in database if exist return true else false
    Function checkfile(ByVal file_id As Integer, ByVal file_name As String) As Boolean
        Dim query As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 Select CONVERT(varchar, DecryptByKey(file_name)) from Recipe_file where file_id ='" & file_id & "'  and CONVERT(varchar, DecryptByKey(file_name))='" & file_name & "'"
        sql.scon1()
        Dim sqlcmd As SqlCommand = New SqlCommand(query, sql.scn1)
        Dim reader As SqlDataReader = sqlcmd.ExecuteReader
        If reader.Read Then
            Return True
        Else
            Return False
        End If
        reader.Close()
        sqlcmd.Dispose()
        sql.scn1.Close()
    End Function

    'it delete recipe deltail saved in database
    Sub deletefilefromdb()
        Dim sql As New sqlclass
        sql.scon2()
        Dim querystring As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 delete from Recipe_file where CONVERT(varchar, DecryptByKey(file_name)) ='" & Filename & "' and file_id ='" & filesave_id & "'"
        Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn2)
        sqlcmd1.ExecuteNonQuery()
        sqlcmd1.Dispose()
        sql.scn2.Close()
    End Sub

    'assign tag_id for each tagname entered in taglist
    Sub updatefile()
        Dim querystring As String = ""
        sql.scon3()
        sql.scon2()
        For i = 0 To TagList.Length - 1
            'query return current value for each tagname entered in taglist
            If TagList(i).Contains("#") Then
                '   querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id, convert(varchar, decryptbykey(readaddress_value)) as readaddress_value, convert(varchar, decryptbykey(Tagname)) as Tagname from Tag_detail_data  where  convert(varchar, decryptbykey(Tagname)) = '" & TagList(i) & "'"
                querystring = ""
                'for encrypted or  non_encypted tables
                If variableclass.is_encrypted Then
                    querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id, convert(varchar, decryptbykey(readaddress_value)) as readaddress_value, convert(varchar, decryptbykey(Tagname)) as Tagname from Tag_detail_data  where  convert(varchar, decryptbykey(Tagname)) = '" & TagList(i) & "'"
                Else
                    querystring = "select Tag_id, readaddress_value, Tagname from Tag_detail_data  where Tagname = '" & TagList(i) & "'"
                End If

            Else

                '  querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id, convert(varchar, decryptbykey(readaddress_value)) as readaddress_value, convert(varchar, decryptbykey(Tagname)) as Tagname from Tag_detail_data  where  convert(varchar, decryptbykey(Tagname)) like '" & TagList(i) & "#%'"
                querystring = ""
                'for encrypted or  non_encypted tables
                If variableclass.is_encrypted Then
                    querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id, convert(varchar, decryptbykey(readaddress_value)) as readaddress_value, convert(varchar, decryptbykey(Tagname)) as Tagname from Tag_detail_data  where  convert(varchar, decryptbykey(Tagname)) like '" & TagList(i) & "#%'"
                Else
                    querystring = "Tag_id, readaddress_value, Tagname from Tag_detail_data  where Tagname like '" & TagList(i) & "#%'"
                End If

            End If
            Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
            sqlcmd1.ExecuteNonQuery()
            Using reader As SqlDataReader = sqlcmd1.ExecuteReader
                While reader.Read
                    'this query insert recipe in databse with tagname and given values
                    Dim query As String = " OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into recipe_file (file_id, file_name, tagname, value)values('" & filesave_id & "', EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & file_name & "')), EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & reader.Item("tagname") & "')), EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & reader.Item("readaddress_value") & "'))) "
                    Dim sqlcmd2 As SqlCommand = New SqlCommand(query, sql.scn2)
                    sqlcmd2.ExecuteNonQuery()
                    sqlcmd2.Dispose()

                End While


                reader.Close()
            End Using
        Next
        ' sqlcmd1.Dispose()
        sql.scn2.Close()
        sql.scn3.Close()
    End Sub

    'this function write saved value of recipe on corresponding tagname when file is opened
    Sub writeIndb(ByVal tag As String, ByVal value As Integer)
        Try
            sql.scon3()
            ' Dim querystring As String = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update Tag_detail_data set writeaddress_value = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & value & "'))  where  convert(varchar, decryptbykey(tagname)) = '" & tag & "' COMMIT TRANSACTION"
            Dim querystring As String = ""
            'for encrypted or  non_encypted tables
            If variableclass.is_encrypted Then
                querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update Tag_detail_data set writeaddress_value = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & value & "'))  where  convert(varchar, decryptbykey(tagname)) = '" & tag & "' COMMIT TRANSACTION"
            Else
                querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN update Tag_detail_data set writeaddress_value = '" & value & "'  where tagname = '" & tag & "' COMMIT TRANSACTION"
            End If

            Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
            sqlcmd1.ExecuteNonQuery()
            sqlcmd1.Dispose()
            sql.scn3.Close()
        Catch ex As Exception

        End Try

       
    End Sub

    'this sub resize uservariable and tf array which stores tagname and thier values when file is save in system and open from system 
    'this is required because in file system tags are read and write from same table when file saved or open this cannot be done from diffrent tables because of 32 bit and string tag
    Dim count = 0
    Sub resizearray()

        For i = 0 To TagList.Length - 1
            sql.scon3()
            If TagList(i).Contains("#") Then
                ' Dim querystring As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select count(*) from Tag_detail_data where convert(varchar, decryptbykey(tagname)) = '" & TagList(i) & "' "
                Dim querystring As String = ""
                'for encrypted or  non_encypted tables
                If variableclass.is_encrypted Then
                    querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select count(*) from Tag_detail_data where convert(varchar, decryptbykey(tagname)) = '" & TagList(i) & "' "
                Else
                    querystring = "select count(*) from Tag_detail_data where tagname = '" & TagList(i) & "' "
                End If

                Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
                count = count + sqlcmd1.ExecuteScalar()
                sqlcmd1.Dispose()
            Else
                '' Dim querystring As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select count(*) from Tag_detail_data where convert(varchar, decryptbykey(tagname)) like '" & TagList(i) & "#%'"
                Dim querystring As String = ""
                'for encrypted or  non_encypted tables
                If variableclass.is_encrypted Then
                    querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select count(*) from Tag_detail_data where convert(varchar, decryptbykey(tagname)) like '" & TagList(i) & "#%'"
                Else
                    querystring = "select count(*) from Tag_detail_data where tagname like '" & TagList(i) & "#%'"
                End If

                Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
                count = count + sqlcmd1.ExecuteScalar()
                sqlcmd1.Dispose()
            End If
        Next
        ReDim UservariablevalueD(count)
        ReDim tf(count)
        sql.scn3.Close()
    End Sub
End Class
