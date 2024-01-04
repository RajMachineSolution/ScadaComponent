Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class CustomTrackbar
    Dim sql As New sqlclass




    Dim tag_name As String
    Dim address_id
    <Browsable(True), _
Category("_ADDRESS"), Description("The tag which associated with control")> _
    Property TagName As String
        Get
            Return tag_name

        End Get
        Set(ByVal tag As String)
            tag_name = tag
            'writeadd = VALUE
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
    Dim directvisibleval As Boolean = True
    <Browsable(True), _
Category("_VISIBLE"), Description("Determines whether the control is visible or hidden")> _
    Property Direct As Boolean


        Get
            Return directvisibleval
        End Get
        Set(ByVal value As Boolean)
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
        Set(ByVal value As Boolean)
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
        Set(ByVal value As String)
            Vissible_tagname = value

        End Set
    End Property


    Public Property set_labelvalue As String
        Get
            '  Return Label1.Text
        End Get
        Set(ByVal value As String)
            'Label1.Text = FormatNumber(CDbl(value * rgain), _decimalval)
            '  Label1.Text = value
            'If No_of_DecimalValues > 0 Then
            '    Label1.Text = FormatNumber(CDbl(Label1.Text / rgain), _decimalval)
            'Else
            '    Label1.Text = Val(value) / rgain
            'End If
        End Set
    End Property

    Dim is_dragover = True
    Private Sub CustomTrackbar_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles Me.DragOver
        is_dragover = True
    End Sub

    Private Sub customtrackbar_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
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
        End If
    End Sub



    '   Dim tempvalue
    ' Dim is_scrolled = False
    Private Sub TrackBar1_Scroll(sender As System.Object, e As System.EventArgs) Handles Me.Scroll
        '  tempvalue = Me.Value
        is_dragover = False
        writeIndb(address_id, Me.Value, Me.Value)

    End Sub

    Dim valueset = False
    Function readval() As String

        visiblecode()
        Dim vts = Val(variableclass.tag(address_id))

        '  set_labelvalue = vts

        '  If valueset = False Then

        If vts <= Maximum And vts >= Minimum And is_dragover = True Then
            Me.Value = vts

            ' valueset = True
        End If
        '
        'End If


        'tempvalue = vts

        Return vts
    End Function

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


    'Sub writeIndb(ByVal address As Integer, ByVal value As Integer)
    '    Try


    '        sql.scon3()
    '        '' Dim querystring As String = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update Tag_detail_data set writeaddress_value = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & value & "'))  where  Tag_id = '" & address & "' COMMIT TRANSACTION"
    '        Dim querystring As String = ""

    '        'for encrypted or  non_encypted tables
    '        If variableclass.is_encrypted Then
    '            querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update Tag_detail_data set writeaddress_value = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & value & "'))  where  Tag_id = '" & address & "' COMMIT TRANSACTION"

    '        Else
    '            querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN update Tag_detail_data set writeaddress_value = '" & value & "' where  Tag_id = '" & address & "' COMMIT TRANSACTION"

    '        End If

    '        Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
    '        sqlcmd1.ExecuteNonQuery()
    '        sqlcmd1.Dispose()
    '        sql.scn3.Close()
    '    Catch ex As Exception

    '    End Try
    'End Sub




    Dim getvissibleaddress = 0
    Dim pvisible As Boolean
    Dim penable As Boolean
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
            If getvissibleaddress = 0 Then
                sql.scon3()
                '' Dim querystring As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & Vissible_tagname & "'"
                Dim querystring As String = ""
                'for encrypted or  non_encypted tables
                If variableclass.is_encrypted Then
                    querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & Vissible_tagname & "'"

                Else
                    querystring = "select Tag_id from Tag_data  where  Tag_name = '" & Vissible_tagname & "'"

                End If

                Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
                sqlcmd1.ExecuteNonQuery()
                Using reader As SqlDataReader = sqlcmd1.ExecuteReader
                    If reader.Read = True Then
                        Address_of_M = reader.Item("Tag_id")
                    End If
                End Using
                ' sqlcmd1.Dispose()
                sql.scn3.Close()
                getvissibleaddress = 1
            End If
            'If variableclass.m(Me.Address_of_M) = 1 Then
            If Val(variableclass.tag(Me.Address_of_M)) = 1 Then
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
    Dim temptimer = 0
    Sub visiblecode()
        propertyvisiblecode()
        If rvisible = True Then

            If pvisible = True Then

                '  rvisible = True
                If tempvisible = 0 Or tempvisible = 2 Then
                    Me.Visible = True
                    tempvisible = 1
                End If
                If renable = True Then

                    If Not (Readonly1) Then

                        '  renable = True
                        If tempenable = 0 Or tempenable = 2 Then
                            Me.Enabled = True
                            tempenable = 1
                        End If
                    Else
                        If tempenable = 1 Or tempenable = 0 Then
                            ' renable = False
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
                    '  rvisible = False
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


    Sub updatevalue()
        sql.scon3()
        '' Dim querystring As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & TagName & "' "
        Dim querystring As String = ""
        'for encrypted or  non_encypted tables
        If variableclass.is_encrypted Then
            querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & TagName & "' "

        Else
            querystring = "select Tag_id from Tag_data  where  Tag_name = '" & TagName & "' "

        End If

        Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
        sqlcmd1.ExecuteNonQuery()
        Using reader As SqlDataReader = sqlcmd1.ExecuteReader
            If reader.Read = True Then
                address_id = reader.Item("Tag_id")

            Else
                address_id = 0
                Me.Read_Only = True
            End If
        End Using
        sqlcmd1.Dispose()
        sql.scn3.Close()
    End Sub



    Dim tempdirect = 0
    Dim tempindirect = 0
    Public Sub propertiesread(ByVal btn As Control, ByVal frm As Form)
        If btn IsNot Nothing And frm IsNot Nothing Then
            If Login_Register.levelid Is Nothing Then
                Login_Register.levelid = 0
            End If
            If Login_Register.levelid = 1 Then
                btn.Visible = True
                btn.Enabled = True
                tempdirect = 0
                tempindirect = 0
                'visiblecode(btn)
                visiblecode()

            Else
                btn.Enabled = True

                Dim query As String = "open symmetric key symmetrickey1 decryption by certificate certificate1 select convert(varchar, decryptbykey(controlproperty)),controlstatus from controlrights  where levelid=" & Login_Register.levelid & " and convert(varchar, decryptbykey(formname))='" & frm.Name & "' and convert(varchar, decryptbykey(controlname))='" & btn.Name & "'"

                sql.conn3()
                Dim sqlcmd As SqlCommand = New SqlCommand(query, sql.cn3)
                Using reader As SqlDataReader = sqlcmd.ExecuteReader
                    While reader.Read

                        If reader.Item(1) = 1 Then

                            If reader.Item(0) = True Then
                                btn.Visible = True

                            Else
                                btn.Visible = False

                            End If
                        Else
                            If reader.Item(0) = True Then
                                btn.Enabled = True
                                Me.Enabled = True
                            Else
                                btn.Enabled = False
                                Me.Enabled = False

                            End If
                        End If
                    End While
                End Using
                tempdirect = 0
                tempindirect = 0
                'visiblecode(btn)
                visiblecode()
                sqlcmd.Dispose()
                sql.cn3.Close()
            End If
        End If
    End Sub
    '-- new code to the rights of component
    Dim rvisible As Boolean = True
    Dim renable As Boolean = True
    Public Sub rightread(ByVal btn As Control, ByVal frm As Form)
        '  sql.scn3.Close()

        If btn IsNot Nothing And frm IsNot Nothing Then
            '  renable = False
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
                '  renable = False
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
                    sqlclass.rightcnn.Close()

                    'sql.scn3.Close()
                End If
            End If
        End If
    End Sub


End Class
