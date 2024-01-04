Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class TextboxControl


    Dim characterArray() As Char
    Dim asciiArray() As Byte


    Dim sql As New sqlclass
    Dim ad As Integer = 0
    Dim txt As String = "Value"

    <Category("_MESSAGE")>
     Public Enum Record_Event
        DirectlyInAuditTrail
        WithMessageInAuditTrail
        NO
    End Enum


    <Category("_Misc"), Description("Default text to show on control")>
    Public Property DefaultText As String
        Get
            Return TextBox1.Text
        End Get
        Set(ByVal value As String)
            TextBox1.Text = value
        End Set
    End Property

    Dim msg As String

    <Category("_MESSAGE"), Description("The description that will be recorded in audit report on operating control")>
    Property RecordMessage As String
        Get
            Return msg
        End Get
        Set(ByVal value As String)
            msg = value
        End Set
    End Property


    Dim Actionmsg As String = ""
     <Category("_MESSAGE"), Description("Description of action perform by control to record in audit report")>
    Property RecordActionMessage As String
        Get
            Return Actionmsg
        End Get
        Set(ByVal value As String)
            Actionmsg = value
        End Set
    End Property


    Dim recordev As Record_Event
    <Category("_MESSAGE")>
    Property RecordEvent As Record_Event
        Get
            Return recordev
        End Get
        Set(ByVal value As Record_Event)
            recordev = value

        End Set
    End Property


    Dim readadd As Integer = 0  'Address of plc for reading  at particular address
    Dim writeadd As Integer = 0 'Address of plc for writing at particular address

    <Browsable(False), _
Category("ADDRESS")> _
    Property ReadAddress As Integer
        Get
            Return readadd
        End Get
        Set(ByVal VALUE As Integer)
            readadd = VALUE
            writeadd = VALUE
        End Set

    End Property
    <Browsable(False), _
Category("ADDRESS")> _
    Property WriteAddress As Integer
        Get
            Return writeadd
        End Get
        Set(ByVal VALUE As Integer)
            writeadd = VALUE
            readadd = VALUE
        End Set
    End Property


    Dim tag_name As String
    <Browsable(True), _
Category("_ADDRESS"), Description("The tag which associated with control")> _
    Property TagName As String
        Get
            Return tag_name

        End Get
        Set(ByVal tag As String)
            tag_name = tag

            'writeadd = VALUE


            'Dim query As String = "open symmetric key symmetrickey1 decryption by certificate certificate1 select count(*) from tag_detail_data  where tagname='" & tag_name & "'"
            'If sqlclass.database <> "" Then
            '    sqlclass.rightcon()
            '    Dim sqlcmd As SqlCommand = New SqlCommand(query, sqlclass.rightcnn)
            '    Using reader As SqlDataReader = sqlcmd.ExecuteReader
            '        While reader.Read
            '            ' controlstatus 1 means visible property
            '            ' controlstatus 2 means enable property
            '            If reader.Item(0) = 0 Then
            '                MessageBox.Show("error")
            '            End If

            '            End While 

            '    End Using

            '    sqlcmd.Dispose()

            'End If




        End Set

    End Property





    Dim Readonly1 As Boolean = True
    <Category("_Misc"), Description("Indicates whether the control is enabled or not")>
    Property Read_Only As Boolean
        Get
            Return Readonly1
        End Get
        Set(ByVal value As Boolean)
            Readonly1 = value
        End Set
    End Property


    Dim no_of_characters As Integer
    <Category("_Misc"), Description("Indicates number of characters that can be store in textbox")>
    Property NoOfCharacters As Integer

        Get
            Return no_of_characters

        End Get

        Set(value As Integer)

            no_of_characters = value
            ' ReDim characterArray(no_of_characters - 1)
            ' ReDim asciiArray(no_of_characters - 1)


            TextBox1.MaxLength = no_of_characters
            TextBox2.MaxLength = no_of_characters

            ReDim characterArray(no_of_characters)
            ReDim asciiArray(no_of_characters)


        End Set

    End Property


    Dim directvisibleval As Boolean = True
    <Browsable(True), _
Category("_VISIBLE"), Description("Determines whether the control is visible or hidden")> _
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
 Category("_VISIBLE"), Description("Determines the condition to set control visible or hidden")> _
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

    Dim Address_of_M As Integer = 0
    Dim Vissible_tagname As String = ""
    <Browsable(True), _
Category("_VISIBLE"), Description("The tag which determines whether the control is visible or hidden")> _
    Property Visible_Tag As String

        Get
            Return Vissible_tagname
        End Get
        Set(value As String)
            Vissible_tagname = value
        End Set
    End Property

    <Category("_Misc"), Description("The background color of control")>
    Property TextboxBackcolor As Color
        Get
            Return TextBox1.BackColor

        End Get
        Set(ByVal value As Color)
            TextBox1.BackColor = value
            TextBox2.BackColor = value
        End Set
    End Property


    <Category("_Misc"), Description("The foreground color of control")>
    Property TextboxForecolor As Color
        Get
            Return TextBox1.ForeColor

        End Get
        Set(ByVal value As Color)
            TextBox1.ForeColor = value
            TextBox2.ForeColor = value
        End Set
    End Property


    Private Sub UserControl1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'first enable and visible control to false then works as condition

        TextBox2.Visible = False
        TextBox2.Enabled = False

        'read the available rights to user if any user has logged-in else only enable the control to false
        If Login_Register.levelid IsNot Nothing And Login_Register.levelid <> 0 Then
            rightread(Me, Me.ParentForm)
        Else
            '  Me.Enabled = True
            control_enable = False
        End If

    End Sub


    'when enter or escape key is pressed, write the value of written text 
    Private Sub TextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown

        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Escape Then
            write()
        End If

    End Sub

    'when leave event fires, write the value of written text
    Private Sub TextBox2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.Leave
        write()
    End Sub

    'when key is press, dont enter any character if no_of_character = 0
    Private Sub TextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress, TextBox2.KeyPress
        If (no_of_characters = 0) Then
            e.Handled = True
        End If
    End Sub



    ' when mouse right button down event fires, if user is admin then shows the form to assign rights to all user else if readonly is false then visible and enable the write_textbox and hide the read_textbox 
    Private Sub TextBox1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox1.MouseDown, TextBox2.MouseDown, Me.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then

            If Login_Register.levelid = 1 Or Login_Register.levelid = Login_Register.mngr Then
                Dim btnp As New buttonproperty(Me.ParentForm.Name, Me.Name, Me.Location.X, Me.Location.Y)
                btnp.TopMost = True
                btnp.StartPosition = FormStartPosition.CenterParent
                btnp.showselected(Me, Me.ParentForm)
                btnp.ShowDialog()
            End If
        Else
            If Readonly1 = False Then
                If control_enable = True Then
                    TextBox2.Text = TextBox1.Text
                    TextBox2.Visible = True
                    TextBox2.Enabled = True
                    TextBox2.Select()
                    TextBox1.Hide()
                Else
                    MessageBox.Show("Access Denied", "Alert")
                End If
                
            End If


        End If

    End Sub




    'TextBox1-to read
    'TextBox2-to write
    Dim value_to_write As String
    Sub write()
        value_to_write = ""
        'getting value from textbox and adding "" at the end and converting in character array 
        Dim vtw As String = TextBox2.Text

        vtw = vtw.PadRight(no_of_characters, "")

        characterArray = vtw.ToCharArray()


        'to convert char array into ascii array
        For i = 0 To characterArray.Length - 1
            asciiArray(i) = Asc(characterArray(i))
        Next



        'to write value in plc
        Dim x As Integer = 0
        Dim y As Integer = 0

        While x < no_of_characters


            'Dim return_value = plcclass.write_single_D_Value(writeadd + y, BitConverter.ToUInt16(asciiArray, x))
            'If return_value = False Then
            '    TextBox2.Text = TextBox1.Text
            'End If

            'write in db for tag system
            value_to_write = value_to_write & "," & BitConverter.ToUInt16(asciiArray, x)
            '' writeIndb(writeadd + y, BitConverter.ToUInt16(asciiArray, x))

            x = x + 2
            y = y + 1

        End While
        value_to_write = value_to_write.Remove(0, 1)
        'writeIndb(writeadd, value_to_write)
        writeIndb(writeadd, value_to_write, TextBox2.Text)
        ' to record event based on condition

        If recordev.ToString = "DirectlyInAuditTrail" Then
            If TextBox1.Text <> TextBox2.Text Then
                If TextBox1.Text.Contains("'") Then
                    TextBox1.Text = TextBox1.Text.Replace("'", "''")
                End If
                If TextBox2.Text.Contains("'") Then
                    TextBox2.Text = TextBox2.Text.Replace("'", "''")
                End If
                Dim ev As New eventlists
                ev.insertscadaevent(Login_Register.empid, RecordActionMessage, Login_Register.levelid, RecordMessage, TextBox1.Text & " to " & TextBox2.Text, "", "", "", "", "", Login_Register.lotno, Login_Register.batchno, "Audittrail")
            End If
        End If
        If recordev.ToString = "WithMessageInAuditTrail" Then
            '      ev.insertscadaevent(Login_Register.empid, "Button Pressed", Login_Register.levelid, Me.RecordMessage, "", "", "", "", "", "", "", "", "Audittrail")
            '--popo messagebox for msg record
            If TextBox1.Text <> TextBox2.Text Then
                Dim btnp As New EnterReason(Me.ParentForm.Name, Me.Name, Me.Location.X, Me.Location.Y, TextBox1.Text, TextBox2.Text, Me.RecordMessage, RecordActionMessage)
                btnp.ShowDialog()
                TextBox1.Text = vtw
            End If
        End If

        TextBox2.Visible = False
        TextBox2.Enabled = False
        TextBox1.Visible = True

    End Sub


    Dim tempdirect = 0
    Dim tempindirect = 0
    'to read the value at textbox
    Sub readval()
        visiblecode()
        TextBox1.Text = variableclass.tag(readadd)

    End Sub



  

    'this is used to read the rights available for control in database 
    Dim rvisible As Boolean = True
    Dim renable As Boolean = True
    Public Sub rightread(ByVal btn As Control, ByVal frm As Form)
        '  sql.scn3.Close()

        If btn IsNot Nothing And frm IsNot Nothing Then
            renable = True
            If Login_Register.levelid Is Nothing Then
                Login_Register.levelid = 0
            End If
            If Login_Register.levelid = 1 Then
                rvisible = True
                renable = True
            Else
                renable = True
                Dim query As String = "open symmetric key symmetrickey1 decryption by certificate certificate1 select convert(varchar, decryptbykey(controlproperty)),controlstatus from controlrights  where levelid=" & Login_Register.levelid & " and convert(varchar, decryptbykey(formname))='" & frm.Name & "' and convert(varchar, decryptbykey(controlname))='" & btn.Name & "'"
                If sqlclass.database <> "" Then
                    sqlclass.rightcon()
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

                    sqlcmd.Dispose()

                End If
            End If
        End If
    End Sub

    'this is used to read the properties available for control 
    Dim getvissibleaddress = 0
    Dim pvisible As Boolean
    Dim penable As Boolean
    Public Sub propertyvisiblecode()
       
        If Direct = False Then
            pvisible = False
        Else
            pvisible = True
        End If

        If Me.INDirect = True Then
            If Getvissibleaddress = 0 Then
                sql.scon3()
                '' Dim querystring As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id from Tag_data  where  convert(varchar, decryptbykey(Tag_name))  = '" & Vissible_tagname & "'"
                Dim querystring As String = ""
                'for encrypted or  non_encypted tables
                If variableclass.is_encrypted Then
                    querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id from Tag_data  where  convert(varchar, decryptbykey(Tag_name))  = '" & Vissible_tagname & "'"
                Else
                    querystring = "select Tag_id from Tag_data  where  Tag_name  = '" & Vissible_tagname & "'"
                End If

                Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
                sqlcmd1.ExecuteNonQuery()
                Using reader As SqlDataReader = sqlcmd1.ExecuteReader
                    If reader.Read = True Then
                        Address_of_M = reader.Item("Tag_id")
                    End If
                End Using
                sql.scn3.Close()
                Getvissibleaddress = 1
            End If

            If variableclass.tag(Me.Address_of_M) = 1 Then
                pvisible = True
            Else
                pvisible = False
            End If
        End If

    End Sub

    'used instead of disabling control to show message of acess denied
    Dim control_enable As Boolean = True

    'this is used to visible and enable the control
    Dim tempvisible = 0
    Dim tempenable = 0
    Sub visiblecode()
        propertyvisiblecode()
        If rvisible = True Then

            If pvisible = True Then

                If tempvisible = 0 Or tempvisible = 2 Then
                    Me.Visible = True
                    tempvisible = 1
                End If
                If renable = True Then

                    If Not (Readonly1) Then

                        If tempenable = 0 Or tempenable = 2 Then
                            ' Me.Enabled = True
                            control_enable = True
                            tempenable = 1

                        End If
                    Else
                        If tempenable = 1 Or tempenable = 0 Then

                            ' Me.Enabled = False
                            control_enable = False
                            tempenable = 2

                        End If
                    End If

                Else
                    If tempenable = 1 Or tempenable = 0 Then

                        'Me.Enabled = False
                        control_enable = False
                        tempenable = 2
                    End If
                End If
            Else
                If tempvisible = 1 Or tempvisible = 0 Then
                    Me.Visible = False
                    tempvisible = 2
                End If
            End If
        Else
            If tempdirect = 1 Or tempdirect = 0 Then
                Me.Visible = False
                tempvisible = 2

            End If
        End If
    End Sub

    'this method updates the value of writeaddress and readaddress variable 
    'getting the tagid using tagname and assigning that id to writeaddress and readaddress
    'so we can use this writeaddress and readaddress as a unique key to add or update the data in tag table
    Sub updatevalue()
        sql.scon3()
        ''  Dim querystring As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id from Tag_data  where  convert(varchar, decryptbykey(Tag_name))  = '" & TagName & "' "
        Dim querystring As String = ""
        'for encrypted or  non_encypted tables
        If variableclass.is_encrypted Then
            querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id from Tag_data  where  convert(varchar, decryptbykey(Tag_name))  = '" & TagName & "' "
        Else
            querystring = "select Tag_id from Tag_data  where Tag_name  = '" & TagName & "' "
        End If


        Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
        sqlcmd1.ExecuteNonQuery()
        Using reader As SqlDataReader = sqlcmd1.ExecuteReader
            If reader.Read = True Then
                WriteAddress = reader.Item("Tag_id")
                ReadAddress = reader.Item("Tag_id")
            Else
                WriteAddress = 0
                ReadAddress = 0
                Me.Read_Only = True
            End If
        End Using
        sqlcmd1.Dispose()
        sql.scn3.Close()
       ' MessageBox.Show("in updatevalue " & WriteAddress)
    End Sub

    ''Sub writeIndb(ByVal address As Integer, ByVal value As String)
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

End Class
