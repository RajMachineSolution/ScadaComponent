Imports System
Imports System.Windows.Forms
Imports System.Reflection
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms.Control
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Collections.Generic
Imports System.Web
Imports System.Drawing.Imaging
Imports System.Object
Imports System.ComponentModel.Component
Imports System.Windows.Forms.BorderStyle
Imports System.Windows.Forms.Border3DStyle
Imports System.Windows.Forms.Border3DSide
Imports System.Collections.CollectionBase
Imports System.Collections
Imports System.Collections.ObjectModel
Imports System.Windows.Forms.Design
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Menu
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.Serialization
Imports System.Runtime.InteropServices
Imports System.Security.Permissions
Imports System.Data.SqlClient
Imports System.Globalization

Public Class Login_Register
    Implements IMessageFilter
    Public Shared SecondsCount As Integer = 0
    Public OSK As System.Diagnostics.Process = Nothing
    Public Shared server = "", dbname = "", dbid = "", dbpass = ""
    Public Shared empid, Fname, plevel As String
    Public Shared tryloginuserid As String = "first"
    Public Shared trylogincount As Integer
    Public Shared lotno = "", batchno = ""
    '  Public Shared formnext As New Form
    Public Shared levelid, levelname As String
    Public Event Logon(ByVal empid As String, ByVal fname As String, ByVal plevel As String)
    Public Shared actionname() As String = {"Aduittrail", "EventList", "Alarm"}
    Public Event regon()
    Dim logindetailsflag As Boolean = False

    Public Shared PasswordExp As Boolean
    Dim PasswordExp1 As Boolean
    Dim evntlist As New eventlists
    Public Shared ideallogouttime As Integer = 0 'time for logout when system is ideal form given time In seconds
    <Browsable(False)>
    Property IdealLogoutTimeOFScada As Integer
        Get
            Return ideallogouttime
        End Get
        Set(ByVal value As Integer)
            ideallogouttime = value

        End Set
    End Property
    Public Shared db As String = ""
    Property database As String
        Get

            'If sqlclass.database <> "" Then
            '    db = sqlclass.database
            'End If
            Return db
        End Get
        Set(ByVal value As String)
            db = value
            'If db <> "" Then
            '    sqlclass.database = db
            'End If
        End Set
    End Property
    Public Shared useridlen As Integer
    <Browsable(False)>
    Property MinimumUseridLength As Integer
        Get
            Return useridlen
        End Get
        Set(ByVal value As Integer)
            useridlen = value

        End Set
    End Property
    Public Shared passlen As Integer
    <Browsable(False)>
    Property MinimumPasswordLength As Integer
        Get
            Return passlen
        End Get
        Set(ByVal value As Integer)
            passlen = value

        End Set
    End Property

    <Browsable(True), _
      EditorBrowsable(EditorBrowsableState.Always), _
      Category("SQL"), _
      Description("The items with sub items that should be displayed")> _
    Public Property Server_Name As String
        Get

            'If sqlclass.server <> "" Then
            '    server = sqlclass.server
            'End If
            Return server
        End Get
        Set(ByVal value As String)
            If value <> "" Then
                server = value
                '   sqlclass.server = value

            Else
                server = ""
                '   sqlclass.server = ""
            End If
        End Set
    End Property
    Public Property database_name As String
        Get
            Return dbname
        End Get
        Set(ByVal value As String)
            If value <> "" Then
                dbname = value
                ' sqlclass.dbname = value
            Else
                'sqlclass.dbname = ""
                dbname = ""
            End If
        End Set
    End Property
    Public Property Database_UserID As String
        Get
            Return dbid
        End Get
        Set(ByVal value As String)
            If value <> "" Then
                dbid = value
                ' sqlclass.dbid = value
            Else
                dbid = ""
                ' sqlclass.dbid = ""
            End If
        End Set
    End Property
    Public Property Database_Password As String
        Get
            Return dbpass
        End Get
        Set(ByVal value As String)
            If value <> "" Then
                dbpass = value
                ' sqlclass.dbpass = value
            Else
                dbpass = ""
                ' sqlclass.dbpass = ""
            End If
        End Set
    End Property
    <Browsable(False)>
     Public Property PasswordExpire As Boolean
        Get
            Return PasswordExp
        End Get
        Set(ByVal value As Boolean)
            '   If value = True Then
            'PasswordExp = value
            '  Else
            sqlclass.px = value
            PasswordExp = value
            PasswordExp1 = value
            'sqlclass.dbid = value
            'End If
        End Set
    End Property
    <Browsable(False)>
     Public Property PasswordExpireday As Integer
        Get
            Return PasswordExpday
        End Get
        Set(ByVal value As Integer)
            '  If value = True Then
            'PasswordExpday = value
            '  Else
            PasswordExpday = value
            'sqlclass.dbid = value
            ' End If
        End Set
    End Property



    Public Shared user_level As String() = {}
    Public Property Userlevel As String()
        Get
            Return user_level
        End Get
        Set(ByVal value As String())
            If value.Length <> 0 Then
                user_level = value
                '  userlevelinsert(user_level)
                'sqlclass.dbid = value
            Else
                user_level = New String() {}
            End If
        End Set
    End Property
    Public Shared Alarm_list As String() = {}
    <Browsable(True), _
     EditorBrowsable(EditorBrowsableState.Always), _
     Category("Define Levels"), _
     Description("The items with sub items that should be displayed")> _
    Public Property Alarmlist As String()
        Get
            Return Alarm_list
        End Get
        Set(ByVal value As String())
            If value.Length <> 0 Then
                Alarm_list = value
                'sqlclass.dbid = value
            Else
                Alarm_list = New String() {}
            End If
        End Set
    End Property
    Public Shared Alarm_Action As String() = {}
    <Browsable(True), _
     EditorBrowsable(EditorBrowsableState.Always), _
     Category("Define Levels"), _
     Description("The items with sub items that should be displayed")> _
    Public Property ALarmAction As String()
        Get
            Return Alarm_Action
        End Get
        Set(ByVal value As String())
            If value.Length <> 0 Then
                Alarm_Action = value
            Else
                Alarm_Action = New String() {}
                'sqlclass.dbid = value
            End If
        End Set
    End Property
    Public Shared Event_Name As String() = {}
    <Browsable(True), _
     EditorBrowsable(EditorBrowsableState.Always), _
     Category("Define Levels"), _
     Description("The items with sub items that should be displayed")> _
    Public Property EventName As String()
        Get
            Return Event_Name
        End Get
        Set(ByVal value As String())
            If value.Length <> 0 Then
                Event_Name = value
            Else
                Event_Name = New String() {}
                'sqlclass.dbid = value
            End If
        End Set
    End Property
    <Browsable(True), _
    EditorBrowsable(EditorBrowsableState.Always), _
    Category("Define Levels"), _
    Description("The items with sub items that should be displayed")> _
    Public Property RecordloginAction As Boolean
        Get
            Return logindetailsflag
        End Get
        Set(ByVal value As Boolean)

            logindetailsflag = value

        End Set
    End Property
    Public Shared passuppercase As Integer = 0
    <Browsable(False), _
Category("Password Complexcity")> _
    Property PasswordUpperCase As Integer
        Get
            Return passuppercase
        End Get
        Set(value As Integer)
            passuppercase = value
        End Set
    End Property
    Public Shared passlowercase As Integer = 0
    <Browsable(False), _
Category("Password Complexcity")> _
    Property PasswordLowerCase As Integer
        Get
            Return passlowercase
        End Get
        Set(value As Integer)
            passlowercase = value
        End Set
    End Property
    Public Shared passspecialchar As Integer = 0
    <Browsable(False), _
Category("Password Complexcity")> _
    Property PasswordSpecialCharacter As Integer
        Get
            Return passspecialchar
        End Get
        Set(value As Integer)
            passspecialchar = value
        End Set
    End Property
    Public Shared passnumericchar As Integer = 0
    <Browsable(False), _
Category("Password Complexcity")> _
    Property PasswordNumericCharacter As Integer
        Get
            Return passnumericchar
        End Get
        Set(value As Integer)
            passnumericchar = value
        End Set
    End Property
    Public Shared passprevoiuscheck As Integer = 0
    <Browsable(True), _
Category("Password Complexcity")> _
    Property Previous_password_Checkcount As Integer
        Get
            Return passprevoiuscheck
        End Get
        Set(value As Integer)
            passprevoiuscheck = value
        End Set
    End Property
    Dim tempadminrights = ""
    <Browsable(True), _
Category("Adminstrator Rights")> _
    Public Property AdminstratorRightsLevel As String
        Get
            Return tempadminrights
        End Get
        Set(ByVal value As String)

            tempadminrights = value

        End Set
    End Property
    Dim t As New ComboBox


  


    Public Shared PasswordExpday As Integer = 0



    Sub New()


        ' This call is required by the designer.
        InitializeComponent()

        PasswordExp1 = PasswordExpire
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub btnLlogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLlogin.Click
       
        login()

    End Sub

    Private Sub btnLReg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLReg.Click
        If empid = -1 Then
            MsgBox("Please login again to continue!")
            Exit Sub
        End If
        Dim reg As New register
        reg.TopMost = True
        reg.StartPosition = FormStartPosition.CenterParent
        reg.ShowDialog()
    

    End Sub

    Private Sub btnRLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtLid.Text = ""
        txtLpass.Text = ""
    End Sub







    Public Shared mngr As Integer
    Private Sub RegistrationControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        checkvalueforlogincheckbox()
        txtLid.Text = ""
        txtLpass.Text = ""
     
        ''  MsgBox(Event_Name.Length)
        ''  MsgBox(PasswordExpire)
        '' txtLid.Text = "Admin1"
        '' txtLpass.Text = "Admin1"
        'Server_Name = ".\sqlexpress"
        'Database_Password = "rmsview"
        'Database_UserID = "rmsview"
        'database_name = "scadatagsystem"

        btnLReg.Visible = False
        Button3.Visible = False
        Label11.Visible = False
        Dim sql As New sqlclass

        If sqlclass.database <> "" And sqlclass.server <> "" Then
            Dim query1 As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 Select levelid from leveldetails where CONVERT(varchar, DecryptByKey(levelname))='" & tempadminrights & "'"
            sql.scon1()
            Dim sqlcmd1 As SqlCommand = New SqlCommand(query1, sql.scn1)

            Dim reader As SqlDataReader = sqlcmd1.ExecuteReader

            'Dim i = 0, j = 0
            If reader.Read Then
                mngr = reader.Item(0)
            End If
            reader.Close()
            sqlcmd1.Dispose()
            sql.scn1.Close()

            ''  userlevelinsert(user_level)
            'Dim DataCollection As New AutoCompleteStringCollection()
            'getProductData(DataCollection)
            'TextBox5.AutoCompleteCustomSource = DataCollection
            'TextBox5.AutoCompleteMode = AutoCompleteMode.Suggest
            'TextBox5.AutoCompleteSource = AutoCompleteSource.CustomSource
            ''Timer1.Enabled = True
           
        End If
    End Sub





    Private Function IsAlphaNum(ByVal strInputText As String) As Boolean
        Return System.Text.RegularExpressions.Regex.IsMatch(strInputText, "(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,50})$")
    End Function

    Public Sub deactivate(ByVal id As Integer)
        Dim sql As New sqlclass

        Try
            '    If IsAlphaNum(TextBoxnewpass.Text) = True Then

            Dim query As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update  employeeinfo set active=2 where empid='" & id & "'"
            sql.scon1()
            Dim sqlcmd As SqlCommand = New SqlCommand(query, sql.scn1)

            sqlcmd.ExecuteNonQuery()
            sqlcmd.Dispose()
            sql.scn1.Close()
            evntlist.insertscadaevent(empid, "USER DEACTIVATED", "", "", "", "", "", "", "", "", "", "", "Audittrail")
            ' Label16.Text = "Successfully changed!!!"

        Catch ex As Exception

        End Try
    End Sub
    Public Function PreFilterMessage(ByRef m As System.Windows.Forms.Message) As Boolean Implements System.Windows.Forms.IMessageFilter.PreFilterMessage

        'Check for mouse movements and / or clicks
        Dim mouse As Boolean = (m.Msg >= &H200 And m.Msg <= &H20D) Or (m.Msg >= &HA0 And m.Msg <= &HAD)

        'Check for keyboard button presses
        Dim kbd As Boolean = (m.Msg >= &H100 And m.Msg <= &H109)

        If mouse Or kbd Then 'if any of these events occur
            '  If Not Timer1.Enabled Then MessageBox.Show("Waking up") 'wake up

            Timer1.Stop()
            SecondsCount = 0
            Timer1.Start()

            '  Return True

            'Else
            ' Return False
        End If
    End Function
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        'Counts each second
        SecondsCount += 1 'Increment

        If SecondsCount > 30 Then 'Two minutes have passed since being active
            Timer1.Stop()
            MessageBox.Show("Program has been inactive for 2 minutes…. Exiting Now…. Cheers!")
            Application.Exit()
        End If
    End Sub




    Public Sub userlevelinsert(ByVal ulevel As String()) ' multiple functionality is done by this method
        Dim sql As New sqlclass
        Dim templevelname As String() = {}
        ' sqlclass.server = Server_Name
        ' sqlclass.dbname = Database_Name
        'sqlclass.dbid = Database_UserID
        'sqlclass.dbpass = Database_Password
        Try
            '    If IsAlphaNum(TextBoxnewpass.Text) = True Then
            If sqlclass.server <> "" And sqlclass.dbname <> "" Then
                Dim query As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 Select CONVERT(varchar, DecryptByKey(levelname)) as levelname from leveldetails where levelid<>1 order by levelid asc "
                sql.scon1()
                Dim sqlcmd As SqlCommand = New SqlCommand(query, sql.scn1)

                Dim reader As SqlDataReader = sqlcmd.ExecuteReader
                Dim i = 0, j = 0
                While reader.Read
                    ReDim Preserve templevelname(i)
                    templevelname(i) = reader.Item(0)

                    i = i + 1

                End While
                sqlcmd.Dispose()
                reader.Close()
                Dim count = 0
                '     For i = 0 To templevelname.Length - 1
                If i = 0 Then
                    For j = 0 To ulevel.Length - 1
                        If Userlevel(j).Length = 0 Or Userlevel(j) = Nothing Then

                        Else

                            query = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into leveldetails(levelname) values(EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Userlevel(j) & "') ))"
                            '        sql.con1()
                            Dim sqlcmd1 As SqlCommand = New SqlCommand(query, sql.scn1)
                            evntlist.insertscadaevent(-1, "NEW USERLEVEL", "", "LEVEL=" + Userlevel(j), "", "", "", "", "", "", "", "", "Audittrail")

                            sqlcmd1.ExecuteNonQuery()

                            sqlcmd1.Dispose()
                        End If
                        'OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert the new value in database
                        'End If
                    Next
                    user_level = templevelname
                    Exit Sub
                End If
                If Userlevel.Length < i Then ' OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert new userlevel in database


                    For j = 0 To ulevel.Length - 1
                        If templevelname.Contains(Userlevel(j)) Then

                        Else
                            'query = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into leveldetails(levelname) values(EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Userlevel(j) & "') ))"
                            ''        sql.con1()
                            'Dim sqlcmd1 As SqlCommand = New SqlCommand(query, sql.scn1)
                            'evntlist.insertscadaevent(-1, "NEW USERLEVEL", "", "LEVEL=" + Userlevel(j), "", "", "", "", "", "", "", "", "Audittrail")

                            'sqlcmd1.ExecuteNonQuery()
                            'sqlcmd1.Dispose()
                            'OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert the new value in database
                        End If
                    Next
                End If
                If Userlevel.Length > i Then ' OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert new userlevel in database


                    For j = 0 To ulevel.Length - 1
                        If templevelname.Contains(Userlevel(j)) Then

                        Else
                            query = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into leveldetails(levelname) values(EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Userlevel(j) & "') ))"
                            '        sql.con1()
                            Dim sqlcmd1 As SqlCommand = New SqlCommand(query, sql.scn1)
                            evntlist.insertscadaevent(-1, "NEW USERLEVEL", "", "LEVEL=" + Userlevel(j), "", "", "", "", "", "", "", "", "Audittrail")

                            sqlcmd1.ExecuteNonQuery()
                            sqlcmd1.Dispose()
                            'OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert the new value in database
                        End If
                    Next
                End If
                '    MessageBox.Show(i & "    " & Userlevel.Length)
                If Userlevel.Length = i Then 'this condition is for  to rename the userlevel and suffle the userlevel


                    For j = 0 To ulevel.Length - 1
                        If templevelname(j) = Userlevel(j) Then

                        Else

                                '' query = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update leveldetails set levelname=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Userlevel(j) & "') ) where levelname=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & templevelname(j) & "')) "
                            query = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update leveldetails set levelname=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Userlevel(j) & "') ) where CONVERT(varchar, DecryptByKey(levelname)) ='" & templevelname(j) & "' "

                            Dim sqlcmd1 As SqlCommand = New SqlCommand(query, sql.scn1)
                                evntlist.insertscadaevent(-1, "USERLEVEL CHANGED", "", "From=" + templevelname(j) & " To=" + Userlevel(j), "", "", "", "", "", "", "", "", "Audittrail")
                                sqlcmd1.ExecuteNonQuery()
                                sqlcmd1.Dispose()



                            'OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert the new value in database
                        End If
                    Next
                End If
                sql.scn1.Close()
                ' Next
                If Userlevel.Length = 0 Then ' to intailise the user property if database contain userlevel 
                    ' For i = 0 To templevelname.Length - 1
                    user_level = templevelname
                    '   Next

                End If
            End If
        Catch ex As Exception
        End Try

    End Sub



    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox("update details")
    End Sub

    Private Sub getProductData(ByVal dataCollection As AutoCompleteStringCollection)
        Dim c As New sqlclass
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet()

        Dim SQL As String
        c.scon1()
        Try
            '    Dim files() As String = IO.Directory.GetFiles("D:\RMS\")

            '   For Each file As String In files
            SQL = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 Select CONVERT(varchar, DecryptByKey(fname)),CONVERT(varchar, DecryptByKey(userid))  from employeeinfo "
            'MsgBox("Connection Open ! ")
            Dim sqlcmd As SqlCommand = New SqlCommand(SQL, c.cn1)
            sqlcmd.CommandTimeout = 60
            '   connect.cmd.ExecuteNonQuery()
            da = New SqlDataAdapter(sqlcmd)
            ds = New DataSet
            da.Fill(ds)

            For Each row As DataRow In ds.Tables(0).Rows

                dataCollection.Add(row(0).ToString + "_" + row(1).ToString)
            Next
            ' Next
            sqlcmd.Dispose()
            c.cn1.Close()
        Catch ex As Exception
            MessageBox.Show("error ! ")
        End Try
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If empid = -1 Then
            MsgBox("Please login again to continue!")
            Exit Sub
        End If
        If plevel = 1 Or plevel = mngr Then
            Dim tempregdetails As New registerdetails
            tempregdetails.TopMost = True
            tempregdetails.StartPosition = FormStartPosition.CenterParent

            tempregdetails.tempregister = tempregdetails
            tempregdetails.filldata()
            tempregdetails.ShowDialog()

            'Dim frm As New regdetails
            'frm.StartPosition = FormStartPosition.CenterParent
            '' frm.TopLevel = False
            'frm.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            'frm.ShowDialog()
        Else
            Dim chang As New changepassword(Me.Location.X, Me.Location.Y)
            chang.TopMost = True
            chang.TextBoxconfirmnewpass.Text = ""
            chang.TextBoxnewpass.Text = ""
            chang.Label19.Text = ""
            chang.Label18.ForeColor = Color.Silver
            chang.StartPosition = FormStartPosition.CenterParent
            chang.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            chang.ShowDialog()

        End If

    End Sub
    Sub checkvalueforlogincheckbox()
        'Dim FILE_NAME As String
        'FILE_NAME = "D:\CIP\" & RECIPE & ".txt"

        'Try
        '    ' OpenFileDialog1.ShowDialog()
        '    If File.Exists(FILE_NAME) = True Then
        '        ev.EncryptFile(FILE_NAME)
        '    End If
        '    ' Dim filepath As String = "D:\Fidus\" & ComPar(0, i) & ".txt"
        '    Dim encryptedFile As String = (FILE_NAME.Substring(0, FILE_NAME.Length - 4)) & "_enc.encrypt"
        '    If File.Exists(encryptedFile) = True Then
        '        ev.DecryptFile(encryptedFile)



        '        If File.Exists(FILE_NAME) Then

        '            Dim b As New System.IO.StreamReader(FILE_NAME)


        '            Do While i < 31
        '                fo = (b.ReadLine)

        If (Not System.IO.Directory.Exists("c:\Chkdetail\")) Then
            '   System.IO.Directory.CreateDirectory(Application.StartupPath & "c:\\Chkdetail\")
            System.IO.Directory.CreateDirectory("c:\Chkdetail\")

        End If
        Dim FILE_NAME As String = "c:\Chkdetail\chk.txt"
        '  Dim encryptedfile = FILE_NAME.Substring(0, (FILE_NAME.ToString.Length - 4)) & "_enc.encrypt"

        '  MsgBox(FILE_NAME)
        If System.IO.File.Exists("c:\Chkdetail\chk.txt") = True Then


            Dim b As New System.IO.StreamReader(FILE_NAME)
            Dim temp = b.ReadToEnd
            If temp = "1" Then
                CheckBox1.Checked = True
            Else
                CheckBox1.Checked = False
            End If
            b.Close()
            '            Do While i < 31
            '                fo = (b.ReadLine)
        Else
            Dim w As New System.IO.StreamWriter(FILE_NAME, True)
            '-- 1 means checkbox selected 0 means not selected
            w.Write("1")


            w.Close()
            CheckBox1.Checked = True

        End If



    End Sub


    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.Click
        Dim FILE_NAME As String = "c:\Chkdetail\chk.txt"
        '  MsgBox(FILE_NAME)
        If System.IO.File.Exists("c:\Chkdetail\chk.txt") = True Then


            Dim b As New System.IO.StreamReader(FILE_NAME)

            '-- 1 means checkbox selected 0 means not selected




            Dim temp = b.ReadToEnd
            b.Close()
            Dim w As New System.IO.StreamWriter(FILE_NAME)
            If temp = "1" Then
                w.Write("0")
                CheckBox1.Checked = False
            Else
                w.Write("1")

                CheckBox1.Checked = True
            End If

            w.Close()

            '            Do While i < 31
            '                fo = (b.ReadLine)
        Else
            MsgBox(FILE_NAME)
            Dim w As New System.IO.StreamWriter(FILE_NAME, True)
            '-- 1 means checkbox selected 0 means not selected
            w.WriteLine("1")
            CheckBox1.Checked = True

            w.Close()

        End If
    End Sub

 
    Private Sub txtLpass_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtLpass.KeyPress
        If Asc(e.KeyChar) = 13 Then
            login()
        End If
    End Sub
    Sub login()
        Try

            Dim sql As New sqlclass
            Dim userid As String = txtLid.Text
            Dim pass As String = txtLpass.Text
            '   Dim wrapper As New Simple3Des(pass)
            ' Dim encryptpass As String = sqlclass.AES_Encrypt(pass, "r1m2s3")
            Dim encryptpass As String = pass
            Dim daycount
            Dim activeindex = 0
            Dim query As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 Select empid,CONVERT(varchar, DecryptByKey(fname)),plevel,active,CONVERT(varchar, DecryptByKey(passworddate)),(select CONVERT(varchar, DecryptByKey(levelname)) from leveldetails where levelid=e.plevel) as levelname from employeeinfo as e where DecryptByKey(UserID)='" & userid & "' and DecryptByKey(password)= '" & encryptpass & "' COLLATE SQL_Latin1_General_CP1_CS_AS and active<2"

            '            Dim query As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 Select empid,fname,plevel,active,passworddate from employeeinfo where UserID='" & userid & "' and password='" & encryptpass & "' and active<2" ' 0 is for first time login ,1 is for active ,2 is for deactive user 

            sql.scon1()
            Dim sqlcmd As SqlCommand = New SqlCommand(query, sql.scn1)
            Using reader As SqlDataReader = sqlcmd.ExecuteReader
                If tryloginuserid <> userid Then
                    tryloginuserid = userid
                    trylogincount = 0
                End If

                If reader.Read Then
                    If trylogincount >= 4 Then
                        'deactivate function
                        deactivate(reader.Item(0))
                        '   MsgBox("deactivate")
                        trylogincount = 0
                        Exit Sub
                    End If

                    empid = reader(0)
                    Fname = reader(1)
                    plevel = reader(2)
                    activeindex = reader(3)

                    levelname = reader.Item(5)

                    Dim dt As Date
                    '   Dim dte As String = reader(4).ToString("yyyy-MM-dd")
                    '     Dim dt As Date = DateTime.ParseExact(reader(4), "ddMMyyyy", CultureInfo.InvariantCulture)

                    '-- dt = DateTime.ParseExact(reader(4), "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    ''dt = DateTime.ParseExact(reader(4), "d/M/yy", Nothing)
                    dt = DateTime.ParseExact(reader(4), "d-M-yy", CultureInfo.InvariantCulture)
                    Dim dt11 As New Date
                    ' dt11 = Convert.ToDateTime(Date.Now) '.ToString("dd-MM-yyyy"))
                    ' variableclass.datee = "16/10/18"
                    ' variableclass.timee = "16:01:00"
                    ''dt11 = DateTime.ParseExact(variableclass.datee, "d/M/yy", Nothing)
                    dt11 = DateTime.ParseExact(variableclass.datee, "d-M-yy", CultureInfo.InvariantCulture)
                    '  dt11 = DateTime.ParseExact(variableclass.datee, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    'dt11 = DateTime.ParseExact(variableclass.datee, "d/M/yyyy", Nothing).ToString("dd/MM/yyyy")
                    '   dt11 = Convert.ToDateTime(Date.Now) '.ToString("dd-MM-yyyy"))
                    daycount = dt11.Subtract(dt).Days
                    daycount = daycount + 1
                    'MsgBox(PasswordExpire)
                    If PasswordExp1 = True Or activeindex = 0 Then
                        If empid <> 1 Then
                            If daycount >= PasswordExpday Or activeindex = 0 Or daycount < 0 Then
                                '  MsgBox("Password Change")
                                '   Panel3.Visible = False
                                txtLid.Text = ""
                                txtLpass.Text = ""
                                Dim chang As New changepassword(Me.Location.X, Me.Location.Y)
                                chang.TopMost = True
                                chang.TextBoxconfirmnewpass.Text = ""
                                chang.TextBoxnewpass.Text = ""
                                chang.Label19.Text = ""
                                chang.Label18.ForeColor = Color.Silver
                                chang.StartPosition = FormStartPosition.CenterParent
                                chang.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                                chang.ShowDialog()

                                '  pnl.Visible = True
                                Exit Sub
                                '  RaiseEvent Logon(empid, Fname, plevel, daycount, activeindex)
                            End If
                        End If
                    End If
                    'Dim query2 As String
                    'If plevel = mngr Then
                    '    query2 = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 Select levelid,CONVERT(varchar, DecryptByKey(levelname)) as levelname from leveldetails where levelid<>1 and levelid<>" & mngr
                    'Else
                    '    query2 = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 Select levelid,CONVERT(varchar, DecryptByKey(levelname)) as levelname from leveldetails where levelid<>1"
                    'End If
                    'sql.scon2()
                    'Dim sqlcmd1 As SqlCommand = New SqlCommand(query2, sqlclass.sqlcon)
                    ''  Dim reader As SqlDataReader = sqlcmd.ExecuteReader

                    Dim i = 0, j = 0
                    'While reader.Read
                    '    If String.Compare(reader.Item(1), "Manager", True) Then
                    '        mngr = reader.Item(0)
                    '        Exit While
                    '    End If
                    'End While

                    'sqlcmd1.ExecuteNonQuery()
                    'Dim DA = New SqlDataAdapter
                    'DA.SelectCommand = sqlcmd1
                    'Dim DataSet = New DataSet
                    'DA.Fill(DataSet)
                    'ComboBox1.DataSource = DataSet.Tables(0)
                    'ComboBox1.ValueMember = "levelid"
                    'ComboBox1.DisplayMember = "levelname"

                    btnLReg.Visible = False
                    Button3.Visible = False
                    Label11.Visible = False
                    '   sqlcmd1.Dispose()
                    ' sql.scn2.Close()

                    If plevel = 1 Or plevel = mngr Then

                        btnLReg.Visible = True
                        Button3.Visible = True
                        Label11.Visible = True

                    Else
                        btnLReg.Visible = False
                        '-  Button3.Visible = False
                        Button3.Visible = True
                        Label11.Visible = False
                    End If
                    levelid = plevel
                    If RecordloginAction = True Then
                        evntlist.insertscadaevent(empid, "LOGINBY USER", "", "", "", "", "", "", "", "", "", "", "Audittrail")
                    End If
                    txtLid.Text = ""
                    txtLpass.Text = ""
                    MessageBox.Show("Login Successful ! " & Fname & "", "Login")
                    'HomePage.Show()
                    '    Me.Close()
                    If CheckBox1.Checked = True Then
                        Me.Parent.Hide()
                    End If
                    RaiseEvent Logon(empid, Fname, plevel)

                Else
                    trylogincount = trylogincount + 1
                    evntlist.insertscadaevent(-1, "INVALID LOGIN", "USER ID+" + userid, "USER ID+" + userid, "", "", "", "", "", "", "", "", "Audittrail")
                    RaiseEvent Logon(2, "Default Login", 2)   'invalid login :-,-1 is of invalid login, userid is the id by which user try to login,0 is for invalid login   
                    btnLReg.Visible = False
                    Button3.Visible = False
                    Label11.Visible = False

                    MessageBox.Show("UserID and Password do not match! TRY Again!", "Login")
                End If
            End Using
            sqlcmd.Dispose()
            sql.scn1.Close()


        Catch ex As Exception


            MsgBox("Cant Connect:Login_click" & ex.Message)
            ''   Finally
            ''sqlclass.cnn1.Close()
        End Try


    End Sub


    Private Sub txtLpass_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLpass.Click, txtLpass.GotFocus
        Try
            'ON CLICK AND IF TEXTBOX GOT FOCUS KEYBOARD WILL BE POPUP AUTOMATICALLY

            '  Process.Start(FileToCopy, "scadatagsystem rmsview rmsview")
            If variableclass.on_screen_keyboard Then
                Dim pProcess() As Process = System.Diagnostics.Process.GetProcessesByName("finalKeyboarddesigned")
                If pProcess.Count > 0 Then
                Else
                    Dim FileToCopy = Application.StartupPath & "\resource\finalKeyboarddesigned.exe"
                    Dim startInfo As ProcessStartInfo = New ProcessStartInfo(FileToCopy)
                    Process.Start(startInfo)

                End If
            End If
           


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub txtLid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLid.Click, txtLid.GotFocus
        Try
            'ON CLICK AND IF TEXTBOX GOT FOCUS KEYBOARD WILL BE POPUP AUTOMATICALLY

            '  Process.Start(FileToCopy, "scadatagsystem rmsview rmsview")
            If variableclass.on_screen_keyboard Then
                Dim pProcess() As Process = System.Diagnostics.Process.GetProcessesByName("finalKeyboarddesigned")
                If pProcess.Count > 0 Then
                Else
                    Dim FileToCopy = Application.StartupPath & "\resource\finalKeyboarddesigned.exe"
                    Dim startInfo As ProcessStartInfo = New ProcessStartInfo(FileToCopy)
                    Process.Start(startInfo)

                End If
            End If
            


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class
