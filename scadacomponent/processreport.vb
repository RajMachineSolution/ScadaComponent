Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing

Public Class processreport

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        AddHandler Pushbutton1.action, AddressOf printdoc
        AddHandler Pushbutton2.action, AddressOf printpreview
        AddHandler Pushbutton3.action, AddressOf printsetting
        ' Add any initialization after the InitializeComponent() call.

    End Sub


    'date time formats
    Public Enum Datedisplay_format
        ddMMyy '3
        MMddyy '1
        yyMMdd '11
        ddMMyyyy '103
        yyyyMMdd '111
        MMddyyyy '101
        ddMMMyyyy '106
    End Enum

    Public Enum Dateseparator
        Slash '/
        Dash  '-
    End Enum

    Dim displayformatecode As Integer = 3
    'date time format select property for user (dispaly date time in this format)
    Dim displaydateformate As Datedisplay_format
    <Category("_Date Formate")>
    Property Date_Display_format As Datedisplay_format
        Get
            Return displaydateformate
        End Get
        Set(ByVal value As Datedisplay_format)
            displaydateformate = value
            '  Write = write1
            If date_separatorvar = Dateseparator.Slash Then
                If displaydateformate = Datedisplay_format.ddMMyy Then
                    displayformatecode = 3
                ElseIf displaydateformate = Datedisplay_format.MMddyy Then
                    displayformatecode = 1
                ElseIf displaydateformate = Datedisplay_format.yyMMdd Then
                    displayformatecode = 11
                ElseIf displaydateformate = Datedisplay_format.yyyyMMdd Then
                    displayformatecode = 111
                ElseIf displaydateformate = Datedisplay_format.MMddyyyy Then
                    displayformatecode = 101
                ElseIf displaydateformate = Datedisplay_format.ddMMyyyy Then
                    displayformatecode = 103
                ElseIf displaydateformate = Datedisplay_format.ddMMMyyyy Then
                    displayformatecode = 106
                End If
            ElseIf date_separatorvar = Dateseparator.Dash Then
                If displaydateformate = Datedisplay_format.ddMMyy Then
                    displayformatecode = 5
                ElseIf displaydateformate = Datedisplay_format.MMddyy Then
                    displayformatecode = 10
                ElseIf displaydateformate = Datedisplay_format.yyMMdd Then
                    displayformatecode = 11
                    Date_Separator = Dateseparator.Slash
                ElseIf displaydateformate = Datedisplay_format.yyyyMMdd Then
                    displayformatecode = 23
                ElseIf displaydateformate = Datedisplay_format.MMddyyyy Then
                    displayformatecode = 110
                ElseIf displaydateformate = Datedisplay_format.ddMMyyyy Then
                    displayformatecode = 105
                ElseIf displaydateformate = Datedisplay_format.ddMMMyyyy Then
                    displayformatecode = 106
                End If
            End If
        End Set
    End Property

    'property for select date separator slash or dash
    Dim date_separatorvar As Dateseparator
    <Category("_Date Formate")>
    Property Date_Separator As Dateseparator
        Get
            Return date_separatorvar
        End Get
        Set(ByVal value As Dateseparator)
            If displaydateformate = Datedisplay_format.yyMMdd Then
                date_separatorvar = Dateseparator.Slash
            Else
                date_separatorvar = value
            End If


            If date_separatorvar = Dateseparator.Slash Then
                If displaydateformate = Datedisplay_format.ddMMyy Then
                    displayformatecode = 3
                ElseIf displaydateformate = Datedisplay_format.MMddyy Then
                    displayformatecode = 1
                ElseIf displaydateformate = Datedisplay_format.yyMMdd Then
                    displayformatecode = 11
                    '  Date_Separator = Dateseparator.Slash
                ElseIf displaydateformate = Datedisplay_format.yyyyMMdd Then
                    displayformatecode = 111
                ElseIf displaydateformate = Datedisplay_format.MMddyyyy Then
                    displayformatecode = 101
                ElseIf displaydateformate = Datedisplay_format.ddMMyyyy Then
                    displayformatecode = 103
                ElseIf displaydateformate = Datedisplay_format.ddMMMyyyy Then
                    displayformatecode = 106
                End If
            ElseIf date_separatorvar = Dateseparator.Dash Then
                If displaydateformate = Datedisplay_format.ddMMyy Then
                    displayformatecode = 5
                ElseIf displaydateformate = Datedisplay_format.MMddyy Then
                    displayformatecode = 10
                ElseIf displaydateformate = Datedisplay_format.yyMMdd Then
                    displayformatecode = 11
                    ' Date_Separator = Dateseparator.Slash
                ElseIf displaydateformate = Datedisplay_format.yyyyMMdd Then
                    displayformatecode = 23
                ElseIf displaydateformate = Datedisplay_format.MMddyyyy Then
                    displayformatecode = 110
                ElseIf displaydateformate = Datedisplay_format.ddMMyyyy Then
                    displayformatecode = 105
                ElseIf displaydateformate = Datedisplay_format.ddMMMyyyy Then
                    displayformatecode = 106
                End If
            End If

        End Set
    End Property



    Private Sub TextBox1_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles batchno.Click
        Try
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
        End Try ' vesselname.AutoCompleteCustomSource = sqlclass.Batchlist
    End Sub

    Private Sub batchno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles batchno.Click, batchno.GotFocus
        Try
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

    Private Sub lotno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lotno.Click
        Try
            If variableclass.on_screen_keyboard Then
                '  Process.Start(FileToCopy, "scadatagsystem rmsview rmsview")
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


    Public tempaudit As AuditTrail
    Public tempalarmreport As AlarmControl
    Public Structure pageDetails
        Dim columns As Integer
        Dim rows As Integer
        Dim startCol As Integer
        Dim startRow As Integer
    End Structure
    Dim dateformat = "3"
    Dim timelength = "5"
    Public pages As Dictionary(Of Integer, pageDetails)
    Dim maxPagesWide As Integer
    Dim maxPagesTall As Integer
    Dim sql As New sqlclass
    Dim reporton As Boolean = True
    Dim reportshow As Boolean = False
    Dim triggered1 As Boolean = False

    'Dim sb As StringBanner()
    'Property SelStringBanner As StringBanner()
    '    Get
    '        Return sb
    '    End Get
    '    Set(ByVal value As StringBanner())
    '        sb = value
    '    End Set
    'End Property

    'Turn On Batch Report
    <Category("_Misc")>
    Property BatchReportOn As Boolean
        Get
            Return reporton
        End Get
        Set(ByVal value As Boolean)
            reporton = value
        End Set
    End Property

    'Show updated BatchReport when new value comes
    <Category("_Misc")>
    Property BatchReportShow As Boolean
        Get
            Return reportshow
        End Get
        Set(ByVal value As Boolean)
            reportshow = value
            If reportshow = True Then
                If reporton = True Then
                    showbatchreport(batchn)
                    reportshow = False
                End If
            End If
        End Set
    End Property
    Dim printaudit As Boolean = True
    <Category("_Misc")>
    Property PrintAuditReport As Boolean
        Get
            Return printaudit
        End Get
        Set(ByVal value As Boolean)
            printaudit = value

        End Set
    End Property
    Dim printalarm As Boolean = True
    <Category("_Misc")>
    Property PrintAlarmReport As Boolean
        Get
            Return printalarm
        End Get
        Set(ByVal value As Boolean)
            printalarm = value

        End Set
    End Property
    'Whether trigger gets On to capture values
    <Browsable(False)>
    Property Triggered As Boolean
        Get
            Return triggered1

        End Get
        Set(ByVal value As Boolean)
            triggered1 = value
        End Set
    End Property

    ''Value of trigger  at M value
    <Browsable(False)>
    Dim trigger1 As String
    Property Trigger As String
        Get
            Return trigger1

        End Get
        Set(ByVal value As String)
            trigger1 = value
        End Set
    End Property
    ''Value of process description  at D value
    Dim process1 As String
    <Browsable(False)>
    Property processAdd As String
        Get
            Return process1

        End Get
        Set(ByVal value As String)
            process1 = value
        End Set
    End Property
    ''Value of process description  at D value
    Dim agam As String
    Property AgAmpAdd As String
        Get
            Return agam

        End Get
        Set(ByVal value As String)
            agam = value
        End Set
    End Property
    ''Value of process description  at D value
    Dim agspeed As String
    <Browsable(False)>
    Property agspaddAdd As String
        Get
            Return agspeed

        End Get
        Set(ByVal value As String)
            agspeed = value
        End Set
    End Property
    ''Value of process description  at D value
    Dim cham As String
    <Browsable(False)>
    Property champAdd As String
        Get
            Return cham

        End Get
        Set(ByVal value As String)
            cham = value
        End Set
    End Property
    ''Value of process description  at D value
    Dim chspeed As String
    <Browsable(False)>
    Property chspeedadd As String
        Get
            Return chspeed

        End Get
        Set(ByVal value As String)
            chspeed = value
        End Set
    End Property


    'All paramters list
    Dim readvalues1 As String()
    Property readvalues As String()
        Get
            Return readvalues1
        End Get
        Set(ByVal value As String())
            readvalues1 = value
        End Set
    End Property

    'batchnumber
    Dim batchn As String
    <Browsable(False)>
    Property batchnumber As String
        Get
            Return batchn
        End Get
        Set(ByVal value As String)
            batchn = value

        End Set
    End Property

    'Product Name
    Dim productn As String
    <Browsable(False)>
    Property Product_Name As String
        Get
            Return productn
        End Get
        Set(ByVal value As String)
            productn = value
        End Set
    End Property
    'Product Code
    Dim productc As String
    <Browsable(False)>
    Property ProductCode As String
        Get
            Return productc
        End Get
        Set(ByVal value As String)
            productc = value
        End Set
    End Property

    'Lot Numer
    Dim lotn As String
    <Browsable(False)>
    Property LotNumber As String
        Get
            Return lotn
        End Get
        Set(ByVal value As String)
            lotn = value
        End Set
    End Property

    Dim fltr As Boolean = False
    <Category("_Misc")>
    Property FilterOn As Boolean
        Get
            Return fltr
        End Get
        Set(ByVal value As Boolean)
            fltr = value
        End Set
    End Property



    'timer interval //not needed
    Dim tinterval As Integer
    <Browsable(False)>
    Property interval As Integer
        Get
            Return tinterval
        End Get
        Set(ByVal value As Integer)
            tinterval = value
            If tinterval <> 0 And taddress <> 0 Then
                writeInterval = True
            End If
        End Set
    End Property

    'timer address //not needed
    Dim taddress As Integer
    <Browsable(False)>
    Property intervalAddress As Integer
        Get
            Return taddress
        End Get
        Set(ByVal value As Integer)
            taddress = value
            If tinterval <> 0 And taddress <> 0 Then
                writeInterval = True
            End If
        End Set
    End Property
    Dim winterval As Boolean
    'write timer to plc //not needed
    <Browsable(False)>
    Property writeInterval As Boolean
        Get
            Return winterval
        End Get
        Set(ByVal value As Boolean)
            winterval = value
        End Set
    End Property
    'database name property
    Dim db As String = ""
    <Browsable(False)>
    Property database As String
        Get

            If sqlclass.database <> "" Then
                db = sqlclass.database
            End If
            Return db
        End Get
        Set(ByVal value As String)
            db = value
            If db <> "" Then
                sqlclass.database = db
            Else
                db = sqlclass.database
            End If
        End Set
    End Property
    Dim printop As Boolean
    <Category("_Misc")>
    Public Property PrintOption As Boolean
        Get
            Return printop
        End Get
        Set(ByVal value As Boolean)
            printop = value
            If printop = True Then
                Pushbutton1.Direct = True
                Pushbutton2.Direct = True
                Pushbutton3.Direct = True
            Else
                Pushbutton1.Direct = False
                Pushbutton2.Direct = False
                Pushbutton3.Direct = False
            End If
        End Set
    End Property
    Dim f As Font
    <Browsable(True), _
Category("_FONTCOMPONENT")> _
    Property FontComponent As Font


        Get
            Return f
        End Get
        Set(value As Font)
            f = value

        End Set
    End Property
    Dim SeconddisplayMadd As Integer
    Dim seconddisplaytag As String
    <Browsable(True), _
Category("_DisplaySecond")> _
    Public Property SecondDisplay_Tag As String
        Get
            Return SecondDisplayTag
        End Get
        Set(ByVal value As String)

            seconddisplaytag = value
        End Set
    End Property

    Dim PageSize = 80
    <Browsable(True), _
Category("_Misc")> _
    Public Property Page_Size As Integer
        Get
            Return PageSize
        End Get
        Set(ByVal value As Integer)
            PageSize = value
        End Set
    End Property


    Public Sub propertiesread(ByVal btn As Control, ByVal frm As Form)
        If btn IsNot Nothing And frm IsNot Nothing Then
            If Login_Register.levelid Is Nothing Then
                Login_Register.levelid = 0
            End If
            If Login_Register.levelid = 1 Then
                btn.Visible = True
                btn.Enabled = True
                Exit Sub
            Else
                btn.Enabled = True
            End If
            Dim query As String = "open symmetric key symmetrickey1 decryption by certificate certificate1 select convert(varchar, decryptbykey(controlproperty)),controlstatus from controlrights  where levelid=" & Login_Register.levelid & " and convert(varchar, decryptbykey(formname))='" & frm.Name & "' and convert(varchar, decryptbykey(controlname))='" & btn.Name & "'"
            If sqlclass.dbname <> "" Then
                sql.scon3()
                Dim sqlcmd As SqlCommand = New SqlCommand(query, sql.scn3)
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

                            Else
                                btn.Enabled = False
                            End If
                        End If

                    End While
                End Using
                sqlcmd.Dispose()
                sql.scn3.Close()
            End If
        End If

    End Sub

    Private Sub BatchReport_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            '       Login_Register.levelid = 1
            If Login_Register.levelid = 1 Or Login_Register.levelid = Login_Register.mngr Then
                ''        '   Panel1.Visible = True
                '            ''                showselected(Me, Me.ParentForm)

                Dim btnp As New buttonproperty(Me.ParentForm.Name, Me.Name, Me.Location.X, Me.Location.Y)
                ' btnp.StartPosition = FormStartPosition.CenterParent
                btnp.TopMost = True
                btnp.showselected(Me, Me.ParentForm)
                btnp.StartPosition = FormStartPosition.CenterScreen    '   btnp.Panel1.Location = Me.Location
                btnp.ShowDialog()
            End If
        End If

    End Sub

    Private Sub BatchReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Button3.Enabled = False
        Button2.Enabled = False

        PictureBox1.Tag = "uchk"
        PictureBox1.Image = My.Resources.box1
        PictureBox2.Tag = "uchk"
        PictureBox2.Image = My.Resources.box1

        DateTimePicker3.Format = DateTimePickerFormat.Time
        DateTimePicker3.ShowUpDown = True
        DateTimePicker3.Format = DateTimePickerFormat.Custom
        DateTimePicker3.CustomFormat = "HH:mm:ss"

        DateTimePicker4.Format = DateTimePickerFormat.Time
        DateTimePicker4.ShowUpDown = True
        DateTimePicker4.Format = DateTimePickerFormat.Custom
        DateTimePicker4.CustomFormat = "HH:mm:ss"

        'DateTimePicker1.Format = DateTimePickerFormat.Custom
        'DateTimePicker1.CustomFormat = "dd/MM/yyyy"
        'DateTimePicker2.Format = DateTimePickerFormat.Custom
        'DateTimePicker2.CustomFormat = "dd/MM/yyyy"

        'Display Date and time in Datepicker according to selected formate
        If date_separatorvar = Dateseparator.Slash Then
            If displaydateformate = Datedisplay_format.ddMMyy Then
                DateTimePicker1.Format = DateTimePickerFormat.Custom
                DateTimePicker1.CustomFormat = "dd/MM/yy"
                DateTimePicker2.Format = DateTimePickerFormat.Custom
                DateTimePicker2.CustomFormat = "dd/MM/yy"
            ElseIf displaydateformate = Datedisplay_format.MMddyy Then
                DateTimePicker1.Format = DateTimePickerFormat.Custom
                DateTimePicker1.CustomFormat = "MM/dd/yy"
                DateTimePicker2.Format = DateTimePickerFormat.Custom
                DateTimePicker2.CustomFormat = "MM/dd/yy"
            ElseIf displaydateformate = Datedisplay_format.yyMMdd Then
                DateTimePicker1.Format = DateTimePickerFormat.Custom
                DateTimePicker1.CustomFormat = "yy/MM/dd"
                DateTimePicker2.Format = DateTimePickerFormat.Custom
                DateTimePicker2.CustomFormat = "yy/MM/dd"
            ElseIf displaydateformate = Datedisplay_format.yyyyMMdd Then
                DateTimePicker1.Format = DateTimePickerFormat.Custom
                DateTimePicker1.CustomFormat = "yyyy/MM/dd"
                DateTimePicker2.Format = DateTimePickerFormat.Custom
                DateTimePicker2.CustomFormat = "yyyy/MM/dd"
            ElseIf displaydateformate = Datedisplay_format.MMddyyyy Then
                DateTimePicker1.Format = DateTimePickerFormat.Custom
                DateTimePicker1.CustomFormat = "MM/dd/yyyy"
                DateTimePicker2.Format = DateTimePickerFormat.Custom
                DateTimePicker2.CustomFormat = "MM/dd/yyyy"
            ElseIf displaydateformate = Datedisplay_format.ddMMyyyy Then
                DateTimePicker1.Format = DateTimePickerFormat.Custom
                DateTimePicker1.CustomFormat = "dd/MM/yyyy"
                DateTimePicker2.Format = DateTimePickerFormat.Custom
                DateTimePicker2.CustomFormat = "dd/MM/yyyy"
            ElseIf displaydateformate = Datedisplay_format.ddMMMyyyy Then
                DateTimePicker1.Format = DateTimePickerFormat.Custom
                DateTimePicker1.CustomFormat = "dd/MMM/yyyy"
                DateTimePicker2.Format = DateTimePickerFormat.Custom
                DateTimePicker2.CustomFormat = "dd/MMM/yyyy"
            End If
        ElseIf date_separatorvar = Dateseparator.Dash Then
            If displaydateformate = Datedisplay_format.ddMMyy Then
                DateTimePicker1.Format = DateTimePickerFormat.Custom
                DateTimePicker1.CustomFormat = "dd-MM-yy"
                DateTimePicker2.Format = DateTimePickerFormat.Custom
                DateTimePicker2.CustomFormat = "dd-MM-yy"
            ElseIf displaydateformate = Datedisplay_format.MMddyy Then
                DateTimePicker1.Format = DateTimePickerFormat.Custom
                DateTimePicker1.CustomFormat = "MM-dd-yy"
                DateTimePicker2.Format = DateTimePickerFormat.Custom
                DateTimePicker2.CustomFormat = "MM-dd-yy"
            ElseIf displaydateformate = Datedisplay_format.yyMMdd Then
                DateTimePicker1.Format = DateTimePickerFormat.Custom
                DateTimePicker1.CustomFormat = "yy-MM-dd"
                DateTimePicker2.Format = DateTimePickerFormat.Custom
                DateTimePicker2.CustomFormat = "yy-MM-dd"
            ElseIf displaydateformate = Datedisplay_format.yyyyMMdd Then
                DateTimePicker1.Format = DateTimePickerFormat.Custom
                DateTimePicker1.CustomFormat = "yyyy-MM-dd"
                DateTimePicker2.Format = DateTimePickerFormat.Custom
                DateTimePicker2.CustomFormat = "yyyy-MM-dd"
            ElseIf displaydateformate = Datedisplay_format.MMddyyyy Then
                DateTimePicker1.Format = DateTimePickerFormat.Custom
                DateTimePicker1.CustomFormat = "MM-dd-yyyy"
                DateTimePicker2.Format = DateTimePickerFormat.Custom
                DateTimePicker2.CustomFormat = "MM-dd-yyyy"
            ElseIf displaydateformate = Datedisplay_format.ddMMyyyy Then
                DateTimePicker1.Format = DateTimePickerFormat.Custom
                DateTimePicker1.CustomFormat = "dd-MM-yyyy"
                DateTimePicker2.Format = DateTimePickerFormat.Custom
                DateTimePicker2.CustomFormat = "dd-MM-yyyy"
            ElseIf displaydateformate = Datedisplay_format.ddMMMyyyy Then
                DateTimePicker1.Format = DateTimePickerFormat.Custom
                DateTimePicker1.CustomFormat = "dd-MMM-yyyy"
                DateTimePicker2.Format = DateTimePickerFormat.Custom
                DateTimePicker2.CustomFormat = "dd-MMM-yyyy"
            End If
        End If

        DateTimePicker1.Value = Date.Now
        DateTimePicker2.Value = Date.Now

        DateTimePicker3.Value = DateTime.Now
        DateTimePicker4.Value = DateTime.Now

        DateTimePicker1.Enabled = False
        DateTimePicker2.Enabled = False
        DateTimePicker3.Enabled = False
        DateTimePicker4.Enabled = False

        batchno.Enabled = False
        batchno.Text = ""

        lotno.Enabled = False
        lotno.Text = ""

        If Login_Register.levelid IsNot Nothing And Login_Register.levelid > 0 Then
            propertiesread(Me, Me.ParentForm)
            '   sql.getBatchlist()
            '   TextBox1.AutoCompleteCustomSource = sqlclass.Batchlist
            showbatchreport(batchn)

            alternatecolours(dgvbr)
            'showselected(Me, Me.ParentForm)
        Else
            ' If readonly1 Then
            Me.Enabled = True
            ' Else
            ' Me.Enabled = True
        End If




    End Sub

    'Public Sub insertbatchreport(ByVal agspeed As String, ByVal agamp As String, ByVal chspeed As String, ByVal champ As String, ByVal processdesc As String)


    '    sql.conn1()
    '    ' Dim a As String = "EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,"
    '    Dim s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into Eventlist(empid,date,time,eventname,var1,var2,var3,var4,var5,var10,action) values('" & Login_Register.empid & "',EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Date.Now.ToString("dd-MM-yyyy") & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & DateTime.Now.ToString("HH:mm:ss") & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT (varchar,'Batch Report')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT (varchar,'" & agspeed & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & agamp & "')),EncryptByKey(Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & chspeed & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & champ & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & processdesc & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & TextBox3.Text & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'EventList')))"
    '    Dim cmd = New SqlCommand(s, sql.cn1)
    '    cmd.CommandTimeout = 60
    '    cmd.ExecuteNonQuery()
    '    sql.cn1.Close()

    'End Sub
    Dim tempvar = 0
    Dim totalpages = 1
    Dim PageIndex = 1
    Dim TotalCount = 0
    Public Sub showbatchreport(ByVal batch As String)
        If tempvar = 0 Then
            Try
                sql.scon3()
                'query get tag_id from given tag name to display address
                '' Dim querystring As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & seconddisplaytag & "'"
                Dim querystring As String = ""

                'for encrypted or  non_encypted tables
                If variableclass.is_encrypted Then
                    querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & seconddisplaytag & "'"

                Else
                    querystring = "select Tag_id from Tag_data  where  Tag_name = '" & seconddisplaytag & "'"

                End If

                Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
                sqlcmd1.ExecuteNonQuery()
                Using reader As SqlDataReader = sqlcmd1.ExecuteReader
                    If reader.Read = True Then
                        SeconddisplayMadd = reader(0)

                    Else
                        SeconddisplayMadd = 0

                    End If
                    reader.Close()
                End Using

                ' sqlcmd1.Dispose()
                sql.scn3.Close()
                tempvar = 1
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        ' If variableclass.m(SeconddisplayMadd) = 1 Then
        If Val(variableclass.tag(SeconddisplayMadd)) = 1 Then
            timelength = "9"
        Else
            timelength = "5"
        End If


        ' Dim fromdate As Date = DateTimePicker1.Value
        'Dim fromdate As Date = DateTimePicker1.Value
        'Dim todate As Date = DateTimePicker2.Value
        'Dim frominc As Date = fromdate.AddDays(1)
        'Dim todec As Date = todate.AddDays(-1)
        Dim frmdate As Date = DateTimePicker1.Value
        Dim tdate As Date = DateTimePicker2.Value
        Dim frminc As Date = frmdate.AddDays(1)
        Dim tdec As Date = tdate.AddDays(-1)
        'converting idate in string and formate yyyy/mm/dd because if formate of computersystem is changed other then yyyy/mm/dd then error occured
        Dim fromdate As String = Format(frmdate, "yyyy/MM/dd")
        Dim todate As String = Format(tdate, "yyyy/MM/dd")
        Dim frominc As String = Format(frminc, "yyyy/MM/dd")
        Dim todec As String = Format(tdec, "yyyy/MM/dd")


        Dim fromtime As String = DateTimePicker3.Value.ToString("HH:mm:ss")
        Dim totime As String = DateTimePicker4.Value.ToString("HH:mm:ss")
        Dim s As String = ""
        sql.scon1()
        Dim da As SqlDataAdapter
        Dim ds As New DataSet

        If PictureBox1.Tag = "uchk" Or PictureBox1.Tag = Nothing Then
            's = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select   CONVERT(varchar, DecryptByKey(var2))+'_'+CONVERT(varchar, DecryptByKey(var3)) as 'BATCH_LOT No.',(select CONVERT(varchar, DecryptByKey(fname)) as 'USER NAME' from employeeinfo where empid=e.empid) as 'USER NAME', CONVERT (varchar(10), DecryptByKey(date)) as DATE,CONVERT(varchar(" & timelength & "), DecryptByKey(time)) as TIME,CONVERT(varchar, DecryptByKey(recipename)) as 'PRODUCT NAME'"
            If Date_Display_format = Datedisplay_format.ddMMMyyyy And Date_Separator = Dateseparator.Slash Then
                s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select   CONVERT(varchar, DecryptByKey(var2))+'_'+CONVERT(varchar, DecryptByKey(var3)) as 'BATCH_LOT No.',(select CONVERT(varchar, DecryptByKey(fname)) as 'USER NAME' from employeeinfo where empid=e.empid) as 'USER NAME', replace(convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(date)), 5)," & displayformatecode & "),' ','/') as DATE,CONVERT(varchar(" & timelength & "), DecryptByKey(time)) as TIME,CONVERT(varchar, DecryptByKey(recipename)) as 'PRODUCT NAME'"

            ElseIf Date_Display_format = Datedisplay_format.ddMMMyyyy And Date_Separator = Dateseparator.Dash Then
                s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select   CONVERT(varchar, DecryptByKey(var2))+'_'+CONVERT(varchar, DecryptByKey(var3)) as 'BATCH_LOT No.',(select CONVERT(varchar, DecryptByKey(fname)) as 'USER NAME' from employeeinfo where empid=e.empid) as 'USER NAME', replace(convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(date)), 5)," & displayformatecode & "),' ','/') as DATE,CONVERT(varchar(" & timelength & "), DecryptByKey(time)) as TIME,CONVERT(varchar, DecryptByKey(recipename)) as 'PRODUCT NAME'"

            Else
                s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select   CONVERT(varchar, DecryptByKey(var2))+'_'+CONVERT(varchar, DecryptByKey(var3)) as 'BATCH_LOT No.',(select CONVERT(varchar, DecryptByKey(fname)) as 'USER NAME' from employeeinfo where empid=e.empid) as 'USER NAME', convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(date)), 5)," & displayformatecode & ") as DATE,CONVERT(varchar(" & timelength & "), DecryptByKey(time)) as TIME,CONVERT(varchar, DecryptByKey(recipename)) as 'PRODUCT NAME'"

            End If
            If batchno.Text <> "" Then
                If lotno.Text <> "" Then
                    '    s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select   processid as 'Sno.',(select CONVERT(varchar, DecryptByKey(fname)) as 'User Name' from employeeinfo where empid=e.empid) as Name,CASE WHEN processtype = 0 THEN 'CIP' ELSE CASE WHEN processtype = 1 THEN 'VLT' else 'SIP' end  END as Process, CONVERT (varchar, DecryptByKey(vesselname)) as 'Equipment Id', CONVERT (varchar, DecryptByKey(date)) as Date,CONVERT(varchar, DecryptByKey(time)) as Time,CONVERT(varchar, DecryptByKey(recipename)) as 'Recipe Name' from processinfo as e where CONVERT(varchar, DecryptByKey(var10))='" & vesselname.Text & "'  " & _
                    '            " order by  convert(date,CONVERT(varchar, DecryptByKey(date)),"& dateformat &") ,       convert(time, Convert(varchar, DecryptByKey(time)))"
                    s = s & " from processinfo as e where  (CONVERT(varchar, DecryptByKey(var2)) like '" & batchno.Text & "') and (CONVERT(varchar, DecryptByKey(var3)) like '" & lotno.Text & "') " & _
                         " order by processid desc"

                Else
                    s = s & " from processinfo as e where  (CONVERT(varchar, DecryptByKey(var2)) like '" & batchno.Text & "') " & _
                   " order by processid desc"
                End If
                '    '--newprocessqueery
                '  s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select   CONVERT(varchar, DecryptByKey(var2))+'_'+CONVERT(varchar, DecryptByKey(var3)) as 'Batch No.',(select CONVERT(varchar, DecryptByKey(fname)) as 'User Name' from employeeinfo where empid=e.empid) as Name, CONVERT (varchar(10), DecryptByKey(date)) as Date,CONVERT(varchar, DecryptByKey(time)) as Time,CONVERT(varchar, DecryptByKey(recipename)) as 'Recipe Name' from processinfo as e where  CONVERT(varchar, DecryptByKey(vesselname)) LIKe '%" & batchno.Text & "%'" & _
                '         " order by processid desc"
                ' End If
            Else
                s = s & " from processinfo as e" & _
            " order by  processid desc"

            End If

        Else
            's = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select   CONVERT(varchar, DecryptByKey(var2))+'_'+CONVERT(varchar, DecryptByKey(var3)) as 'BATCH_LOT No.',(select CONVERT(varchar, DecryptByKey(fname)) as 'User Name' from employeeinfo where empid=e.empid) as 'USER NAME', CONVERT (varchar(10), DecryptByKey(date)) as DATE,CONVERT(varchar(" & timelength & "), DecryptByKey(time)) as TIME,CONVERT(varchar, DecryptByKey(recipename)) as 'PRODUCT NAME'"
           If Date_Display_format = Datedisplay_format.ddMMMyyyy And Date_Separator = Dateseparator.Slash Then
                s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select   CONVERT(varchar, DecryptByKey(var2))+'_'+CONVERT(varchar, DecryptByKey(var3)) as 'BATCH_LOT No.',(select CONVERT(varchar, DecryptByKey(fname)) as 'User Name' from employeeinfo where empid=e.empid) as 'USER NAME', replace(convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(date)), 5)," & displayformatecode & "),' ','/') as DATE,CONVERT(varchar(" & timelength & "), DecryptByKey(time)) as TIME,CONVERT(varchar, DecryptByKey(recipename)) as 'PRODUCT NAME'"

            ElseIf Date_Display_format = Datedisplay_format.ddMMMyyyy And Date_Separator = Dateseparator.Dash Then
                s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select   CONVERT(varchar, DecryptByKey(var2))+'_'+CONVERT(varchar, DecryptByKey(var3)) as 'BATCH_LOT No.',(select CONVERT(varchar, DecryptByKey(fname)) as 'User Name' from employeeinfo where empid=e.empid) as 'USER NAME', replace(convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(date)), 5)," & displayformatecode & "),' ','/') as DATE,CONVERT(varchar(" & timelength & "), DecryptByKey(time)) as TIME,CONVERT(varchar, DecryptByKey(recipename)) as 'PRODUCT NAME'"

            Else
                s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select   CONVERT(varchar, DecryptByKey(var2))+'_'+CONVERT(varchar, DecryptByKey(var3)) as 'BATCH_LOT No.',(select CONVERT(varchar, DecryptByKey(fname)) as 'User Name' from employeeinfo where empid=e.empid) as 'USER NAME', convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(date)), 5)," & displayformatecode & ") as DATE,CONVERT(varchar(" & timelength & "), DecryptByKey(time)) as TIME,CONVERT(varchar, DecryptByKey(recipename)) as 'PRODUCT NAME'"

            End If

            If batchno.Text <> "" Then
                'Shows Single batch data
                If fromdate <> todate Then
                    s = s & " from processinfo as e where  CONVERT(varchar, DecryptByKey(vesselname)) Like '%" & batchno.Text & "%'" & _
                      "and  ((convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")>='" & frominc & "'  " & _
      "  and  convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")<='" & todec & "' ) or" & _
      "( convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")='" & todate & "' " & _
      "  and convert(time,CONVERT(varchar, DecryptByKey(time)))<='" & totime & "')" & _
      "or ( convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")='" & fromdate & "'" & _
        "  and convert(time,CONVERT(varchar, DecryptByKey(time)))>='" & fromtime & "'))" & _
        "      order by  processid desc"
                Else
                    s = s & " from processinfo as e where CONVERT(varchar, DecryptByKey(vesselname)) Like '%" & batchno.Text & "%' and " & _
                       "( convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")='" & todate & "' " & _
                       "  and convert(time,CONVERT(varchar, DecryptByKey(time)))<='" & totime & "')" & _
                       "and ( convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")='" & fromdate & "'" & _
                         "  and convert(time,CONVERT(varchar, DecryptByKey(time)))>='" & fromtime & "')" & _
                         "      order by  processid desc"

                End If
            Else
                'Shows all batch data
                If fromdate <> todate Then
                    s = s & " from processinfo as e where   ((convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")>='" & frominc & "'  " & _
            "  and  convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")<='" & todec & "' ) or" & _
            "( convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")='" & todate & "' " & _
            "  and convert(time,CONVERT(varchar, DecryptByKey(time)))<='" & totime & "')" & _
            "or ( convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")='" & fromdate & "'" & _
              "  and convert(time,CONVERT(varchar, DecryptByKey(time)))>='" & fromtime & "'))" & _
              "      order by  processid desc"
                Else
                    s = s & " from processinfo as e where " & _
                       "( convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")='" & todate & "' " & _
                       "  and convert(time,CONVERT(varchar, DecryptByKey(time)))<='" & totime & "')" & _
                       "and ( convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")='" & fromdate & "'" & _
                         "  and convert(time,CONVERT(varchar, DecryptByKey(time)))>='" & fromtime & "')" & _
                         "      order by  processid desc "

                End If
            End If

        End If


        ' when search button is clicked then only this will be initialized,not on previous and next button
        If searchbuttonclick = 1 Or PageIndex = totalpages Then

            'to get total returned rows count and total pages, current page index
            Dim tempsqlqueryold() As String
            'only getting where condition to  get number of returned records by ignoring order by using  tempsqlqueryold(1).Remove(tempsqlqueryold(1).Length - 18
            tempsqlqueryold = s.Split(New String() {"as e where"}, StringSplitOptions.None)
            Dim sqlq1 = ""
            'error in getting tempsqlqueryold(1)
            Try
                sqlq1 = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select count(processid) from processinfo where " & tempsqlqueryold(1).Remove(tempsqlqueryold(1).Length - 25)

            Catch ex As Exception
                sqlq1 = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select count(processid) from processinfo"
            End Try

            'MsgBox(sqlq1)
            '  Clipboard.SetText(sqlq1)

            If sqlclass.dbname <> "" Then
                '   sql.scon3()
                sql.scon1()
                Dim sqlcmd As SqlCommand = New SqlCommand(sqlq1, sql.scn1)
                Using reader As SqlDataReader = sqlcmd.ExecuteReader
                    If reader.Read Then
                        TotalCount = reader.Item(0)
                        If reader.Item(0) Mod PageSize = 0 Then
                            If TotalCount = 0 Then
                                totalpages = (TotalCount \ PageSize) + 1
                                PageIndex = (TotalCount \ PageSize) + 1
                            Else
                                totalpages = (TotalCount \ PageSize)
                                PageIndex = (TotalCount \ PageSize)
                            End If

                        Else
                            totalpages = (TotalCount \ PageSize) + 1
                            PageIndex = (TotalCount \ PageSize) + 1
                        End If

                    End If
                End Using
                '  sqlcmd.Dispose()
                'sql.scn3.Close()
            End If
            '  searchbuttonclick = 0
            If PageIndex = 1 Then
                Button3.Enabled = False

            Else
                Button3.Enabled = True

            End If
            If PageIndex = totalpages Then
                Button2.Enabled = False
            Else
                Button2.Enabled = True
            End If

            Label6.Text = "page " & totalpages - PageIndex + 1 & " of " & totalpages
            picturebox1tag = PictureBox1.Tag
            picturebox2tag = PictureBox2.Tag
            datetimepicker1value = DateTimePicker1.Value
            datetimepicker2value = DateTimePicker2.Value
            datetimepicker3value = DateTimePicker3.Value
            datetimepicker4value = DateTimePicker4.Value
            textbox1value = batchno.Text
            textbox2value = lotno.Text
        End If


        Dim tempsql1 = s.Remove(0, 78)
        tempsql1 = tempsql1.Remove(tempsql1.Length - 25)
        Dim finalsqlquery1 = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select * from (select  ROW_NUMBER() OVER(ORDER BY processid ASC) AS processid1," & tempsql1 & ") as temp where( processid1 BETWEEN " & (TotalCount - (PageSize - 1)) & " And " & TotalCount & ") order by processid1 desc"



        Dim cmd = New SqlCommand(finalsqlquery1, sql.scn1)


        '    Dim cmd = New SqlCommand(s, sql.scn1)
        cmd.CommandTimeout = 60
        da = New SqlDataAdapter(cmd)
        da.Fill(ds)
        'for removing processid1 column
        ds.Tables(0).Columns.RemoveAt(0)

        dgvbr.Font = f
        dgvbr.DataSource = ds.Tables(0)
        alternatecolours(dgvbr)
        dgvbr.Columns(0).Width = 150
        dgvbr.Columns(1).Width = 110
        dgvbr.Columns(2).Width = 100
        dgvbr.Columns(3).Width = 100
        dgvbr.Columns(4).Width = 150
        sql.scn1.Close()
    End Sub
    Public Sub alternatecolours(ByVal dgv As DataGridView)
        For i = 0 To dgv.Rows.Count - 1 Step 2
            dgv.Rows(i).DefaultCellStyle.BackColor = Color.LightCyan
            If i + 1 <= dgv.Rows.Count - 1 Then
                dgv.Rows(i + 1).DefaultCellStyle.BackColor = Color.MintCream
            End If
        Next

    End Sub

    'Public Sub InsertEventList()
    '    'Event – M300 event Log Trigger Log D300 D302 D304 D306 D308 D310 D312 D314 D316 D318
    '    'D300-agspeed
    '    'd302-agampere
    '    'd304- chspeed
    '    'd306- chamampere

    '    Dim process As String = ""
    '    Dim speedag = "Off", ampag = "0.00", speedch = "Off", ampch = "0.00"

    '    ampag = D(302)
    '    ampch = D(306)

    '    If D(300) = 1 Then
    '        speedag = "Slow"
    '    ElseIf D(300) = 2 Then
    '        speedag = "Fast"
    '    Else
    '        speedag = "Off"
    '    End If
    '    If D(304) = 1 Then
    '        speedch = "Slow"
    '    ElseIf D(304) = 2 Then
    '        speedch = "Fast"
    '    Else

    '        speedch = "Off"
    '    End If
    '    If M(510) = 1 Then
    '        If process_start = 0 Then
    '            process = "Process Start"
    '        Else
    '            process = "Under Process"
    '        End If
    '    Else
    '        process = "Process Abort"

    '    End If
    '    If M(512) = 1 Then
    '        process_start = 0
    '        process = "Process Stop"
    '        MsgBox(process)
    '    End If
    '    insertbatchreport(speedag, ampag, speedch, ampch, process)

    'End Sub
    Dim searchbuttonclick = 0
    'variables when the search button is press , so we can detect filter changes
    Dim picturebox1tag
    Dim picturebox2tag
    Dim datetimepicker1value
    Dim datetimepicker2value
    Dim datetimepicker3value
    Dim datetimepicker4value
    Dim textbox1value
    Dim textbox2value
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'sql.getBatchlist()
        'TextBox1.AutoCompleteCustomSource = sqlclass.Batchlist
        searchbuttonclick = 1
        showbatchreport(batchn)
        'to enable or disable previous next buttons
        If PageIndex = 1 Then
            Button3.Enabled = False

        Else
            Button3.Enabled = True

        End If
        If PageIndex = totalpages Then
            Button2.Enabled = False
        Else
            Button2.Enabled = True
        End If
        Label6.Text = "page " & totalpages - PageIndex + 1 & " of " & totalpages

        '  sql.getBatchlist()
        ' TextBox1.AutoCompleteCustomSource = sqlclass.Batchlist

        picturebox1tag = PictureBox1.Tag
        picturebox2tag = PictureBox2.Tag
        datetimepicker1value = DateTimePicker1.Value
        datetimepicker2value = DateTimePicker2.Value
        datetimepicker3value = DateTimePicker3.Value
        datetimepicker4value = DateTimePicker4.Value
        textbox1value = batchno.Text
        textbox2value = lotno.Text
    End Sub

    Private Sub PrintDocument1_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint
        ''this removes the printed page margins
        PrintDocument1.OriginAtMargins = True
        PrintDocument1.DefaultPageSettings.Margins = New Drawing.Printing.Margins(0, 0, 0, 0)
        Dim dv As DataGridView = dgvbr
        Dim temp = 0
        'If i = 1 Then
        'End If

        pages = New Dictionary(Of Integer, pageDetails)
        Dim maxWidth = 0
        Dim maxHeight = 0

        If PrintDocument1.DefaultPageSettings.Landscape = True Then
            maxWidth = CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Height) - 40
            maxHeight = CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Width) - 350
        Else


            maxWidth = CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Width) - 40
            maxHeight = CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Height) - 350
        End If
        Dim pageCounter As Integer = 0
        pages.Add(pageCounter, New pageDetails)

        Dim columnCounter As Integer = 0

        Dim columnSum As Integer = dv.RowHeadersWidth

        For c As Integer = 0 To dv.Columns.Count - 1
            If columnSum + dv.Columns(c).Width < maxWidth Then
                columnSum += dv.Columns(c).Width
                columnCounter += 1
            Else
                pages(pageCounter) = New pageDetails With {.columns = columnCounter, .rows = 0, .startCol = pages(pageCounter).startCol}
                columnSum = dv.RowHeadersWidth + dv.Columns(c).Width
                columnCounter = 1
                pageCounter += 1
                pages.Add(pageCounter, New pageDetails With {.startCol = c})
            End If
            If c = dv.Columns.Count - 1 Then
                If pages(pageCounter).columns = 0 Then
                    pages(pageCounter) = New pageDetails With {.columns = columnCounter, .rows = 0, .startCol = pages(pageCounter).startCol}
                End If
            End If
        Next

        maxPagesWide = pages.Keys.Max + 1

        pageCounter = 0

        Dim rowCounter As Integer = 0

        Dim rowSum As Integer = dv.ColumnHeadersHeight

        For r As Integer = 0 To dv.Rows.Count - 2
            If rowSum + dv.Rows(r).Height < maxHeight Then
                rowSum += dv.Rows(r).Height
                rowCounter += 1
            Else
                pages(pageCounter) = New pageDetails With {.columns = pages(pageCounter).columns, .rows = rowCounter, .startCol = pages(pageCounter).startCol, .startRow = pages(pageCounter).startRow}
                For x As Integer = 1 To maxPagesWide - 1
                    pages(pageCounter + x) = New pageDetails With {.columns = pages(pageCounter + x).columns, .rows = rowCounter, .startCol = pages(pageCounter + x).startCol, .startRow = pages(pageCounter).startRow}
                Next

                pageCounter += maxPagesWide
                For x As Integer = 0 To maxPagesWide - 1
                    pages.Add(pageCounter + x, New pageDetails With {.columns = pages(x).columns, .rows = 0, .startCol = pages(x).startCol, .startRow = r})
                Next

                rowSum = dv.ColumnHeadersHeight + dv.Rows(r).Height
                rowCounter = 1
            End If
            If r = dv.Rows.Count - 2 Then
                For x As Integer = 0 To maxPagesWide - 1
                    If pages(pageCounter + x).rows = 0 Then
                        pages(pageCounter + x) = New pageDetails With {.columns = pages(pageCounter + x).columns, .rows = rowCounter, .startCol = pages(pageCounter + x).startCol, .startRow = pages(pageCounter + x).startRow}
                    End If
                Next
            End If
        Next

        maxPagesTall = pages.Count \ maxPagesWide
        If temp = 1 Then
            ' dv.Columns(0).Visible = True
        End If
    End Sub
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim i = 2
        Dim productname, productcode, lotno As String
        'Dim rect1 As New Rectangle(50, 50, CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Width), Panel1.Height + 200)
        '  Dim rect2 As New Rectangle(50, 50, CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Width), Panel3.Height + 200)

        '  Dim i As Integer = TabControl2.SelectedTab.Name.Substring(3)
        ' Dim dv As DataGridView = CType(TabControl2.TabPages(i - 1).Controls("dataview" & (i)), DataGridView)
        Dim dv As DataGridView = dgvbr
        'Dim txtbx As TextBox = CType(TabControl2.TabPages(i - 1).Controls("text" & (i)), TextBox)

        ''sample txtbox
        Dim txtbx As TextBox = batchno

        Dim rect As New Rectangle(20, 20, CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Width), txtbx.Height)
        Dim rect1 As New Rectangle(0, 55, CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Width), 80)
        Dim temp = 0
        If i = 1 Then
            ' temp = 1
        End If
        Dim sf As New StringFormat
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center

        '  e.Graphics.DrawImage(My.Resources.lupinvsmal, New Point(40, 20))
        e.Graphics.DrawString("", Label1.Font, Brushes.Black, New Point((e.PageBounds.Width / 2) - 140, 20))
        e.Graphics.DrawString("BATCH REPORT ", Label1.Font, Brushes.Black, New Point((e.PageBounds.Width / 2) - 100, 40))

        ' e.Graphics.DrawString("Production", batchno.Font, Brushes.Black, New Point(710, 75))
        'e.Graphics.DrawString(txtbx.Text, txtbx.Font, Brushes.Black, rect, sf)
        '   e.Graphics.DrawString("Batch Report", txtbx.Font, Brushes.Black, rect1, sf)
        Dim drawFont As New Font("Arial", 8.75)

        '    e.Graphics.DrawString("Report Title", drawFont, Brushes.Gray, 20, e.PageBounds.Height - 90)
        ' e.Graphics.DrawString("Printed", drawFont, Brushes.Gray, 20, e.PageBounds.Height - 76)
        '    e.Graphics.DrawString("Checked By:", drawFont, Brushes.Black, 40, e.PageBounds.Height - 100)
        e.Graphics.DrawString("DONE BY (SIGN/DATE)	:", drawFont, Brushes.Black, 80, e.PageBounds.Height - 60)

        e.Graphics.DrawString("CHECKED BY (SIGN/DATE)	:", drawFont, Brushes.Black, 400, e.PageBounds.Height - 60)

        ' e.Graphics.DrawString(Label2.Text, Label2.Font, Brushes.Black, rect1, sf)

        sf.Alignment = StringAlignment.Near

        Dim startX As Integer = 70
        Dim startY As Integer = 150
        Dim tempy = 150
        Dim tempx = 70
        Static startPage As Integer = 0
        '        Try


        Dim newpage = 0

        For p As Integer = startPage To pages.Count - 1
            If p <> 0 Then
                newpage = 1
            End If
            If p = pages.Count - 1 Then
                '  e.Graphics.DrawString("Remark:", drawFont, Brushes.Black, 40, e.PageBounds.Height - 120)
                e.Graphics.DrawString("REMARK :", drawFont, Brushes.Black, 60, e.PageBounds.Height - 73)
                'e.Graphics.DrawString("STERILIZATION HOLD TIME  " & Label19.Text, drawFont, Brushes.Black, 400, e.PageBounds.Height - 80)
                e.Graphics.DrawString("DONE BY (SIGN/DATE)	:", drawFont, Brushes.Black, 60, e.PageBounds.Height - 40)

                e.Graphics.DrawString("CHECKED BY (SIGN/DATE)	:", drawFont, Brushes.Black, 400, e.PageBounds.Height - 40)

            End If
            If p = 0 Then
                '  startY = 150
                tempy = 150
                'e.Graphics.DrawLine(Pens.Black, 30, 108, e.PageBounds.Width - 50, 108)
                'e.Graphics.DrawLine(Pens.Black, 30, 108, 30, 200)
                'e.Graphics.DrawLine(Pens.Black, 30, 200, e.PageBounds.Width - 50, 200)
                'e.Graphics.DrawLine(Pens.Black, e.PageBounds.Width - 50, 200, e.PageBounds.Width - 50, 108)
                'e.Graphics.DrawString("Date                   :" & Date.Now.ToString("dd-MM-yyyy"), drawFont, Brushes.Black, 38, 110)
                'e.Graphics.DrawString("Equipment Id    : HSG-2304", drawFont, Brushes.Black, 38, 125)
                'e.Graphics.DrawString("Product Name   :" & productn, drawFont, Brushes.Black, 38, 140)
                'e.Graphics.DrawString("Productcode     :" & productc, drawFont, Brushes.Black, 38, 155)
                'e.Graphics.DrawString("Batch Number  :" & batchn, drawFont, Brushes.Black, 38, 170)
                'e.Graphics.DrawString("Lot Number      :" & lotn, drawFont, Brushes.Black, 38, 185)
            Else
                ' startY = 150
                tempy = 150
            End If
            e.Graphics.DrawString("Page Number " & p + 1 & " of " & pages.Count, drawFont, Brushes.Black, e.PageBounds.Width - 180, e.PageBounds.Height - 32)
            Dim cell As New Rectangle(startX, startY, dv.RowHeadersWidth, dv.ColumnHeadersHeight)
            If dv.RowHeadersVisible = True Then
                e.Graphics.FillRectangle(New SolidBrush(SystemColors.ControlLight), cell)
                e.Graphics.DrawRectangle(Pens.Black, cell)

                startY += dv.ColumnHeadersHeight

                For r As Integer = pages(p).startRow To pages(p).startRow + pages(p).rows
                    cell = New Rectangle(startX, startY, dv.RowHeadersWidth, dv.Rows(r).Height)
                    e.Graphics.FillRectangle(New SolidBrush(SystemColors.ControlLight), cell)
                    e.Graphics.DrawRectangle(Pens.Black, cell)
                    If r <> 0 Then
                        '     MsgBox(DataGridView3.Rows(r).HeaderCell.Value.ToString)
                        '    e.Graphics.DrawString(dv.Rows(r).HeaderCell.Value.ToString, TextBox10.Font, Brushes.Black, cell, sf)
                    End If
                    startY += dv.Rows(r).Height
                Next

                startX += cell.Width
                If p = 0 Then
                    startY = 150
                Else
                    startY = 150
                End If
            Else

                startY = 150
            End If
            For c As Integer = pages(p).startCol To pages(p).startCol + pages(p).columns - 1
                If (temp = 1 And c = 0) Or (temp = 1 And c = dv.Columns.Count - 1) Then

                Else
                    ' End If
                    cell = New Rectangle(startX, startY, dv.Columns(c).Width, dv.ColumnHeadersHeight)
                    e.Graphics.FillRectangle(New SolidBrush(SystemColors.ControlLight), cell)
                    e.Graphics.DrawRectangle(Pens.Black, cell)
                    e.Graphics.DrawString(dv.Columns(c).HeaderCell.Value.ToString, batchno.Font, Brushes.Black, cell, sf)
                    startX += dv.Columns(c).Width
                End If
            Next
            If p = 0 Then
                startY = tempy + dv.ColumnHeadersHeight
            Else
                startY = tempy + dv.ColumnHeadersHeight
            End If



            For r As Integer = pages(p).startRow + newpage To pages(p).startRow + pages(p).rows
                If dv.RowHeadersVisible = True Then
                    startX = tempx + dv.RowHeadersWidth
                Else

                    startX = tempx
                End If

                For c As Integer = pages(p).startCol To pages(p).startCol + pages(p).columns - 1
                    cell = New Rectangle(startX, startY, dv.Columns(c).Width, dv.Rows(r).Height)
                    If (c = 0 And temp = 1) Or (temp = 1 And c = dv.Columns.Count - 1) Then
                        startX += 0
                    Else
                        e.Graphics.DrawRectangle(Pens.Black, cell)
                        e.Graphics.DrawString(dv(c, r).Value.ToString, batchno.Font, Brushes.Black, cell, sf)
                        startX += dv.Columns(c).Width
                    End If
                    '  e.Graphics.DrawString(dv.Rows(r).Cells(0).Value.ToString, TextBox10.Font, Brushes.Black, cell, sf)
                    '  startX += dv.Columns(c).Width
                    'f
                Next
                startY += dv.Rows(r).Height
            Next

            If p <> pages.Count - 1 Then
                startPage = p + 1
                e.HasMorePages = True
                Return
            Else
                startPage = 0
            End If

        Next
        'Catch ex As Exception

        ' End Try
        If temp = 1 Then
            ' dv.Columns(0).Visible = True
        End If

    End Sub
    Sub printdoc()
        If dgvbr.Rows.Count = 0 Then
            MsgBox("No Data")
            Exit Sub
        End If
        If PrintDialog1.ShowDialog = DialogResult.OK Then
            ' Dim ev As New eventlists
            '            ev.insertscadaevent(Login_Register.empid, "Print SipReport", "", "", "", "", "", "", "", "", "", "", "Audittrail")

            PrintDocument1.Print()
        End If
    End Sub
    Sub printpreview()
        If dgvbr.Rows.Count = 0 Then
            MsgBox("No Data")
            Exit Sub
        End If
        Dim ppd As New PrintPreviewDialog
        ppd.Document = PrintDocument1
        ppd.WindowState = FormWindowState.Maximized
        ppd.ShowDialog()
    End Sub
    Sub printsetting()
        With PageSetupDialog1
            .Document = PrintDocument1
            .PageSettings = PrintDocument1.DefaultPageSettings
        End With
        If PageSetupDialog1.ShowDialog = DialogResult.OK Then
            PrintDocument1.DefaultPageSettings = PageSetupDialog1.PageSettings
        End If
    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '  Dim i As Integer = TabControl2.SelectedTab.Name.Substring(3)
        ' Dim dv As DataGridView = CType(TabControl2.TabPages(i - 1).Controls("dataview" & (i)), DataGridView)
        If dgvbr.Rows.Count = 0 Then
            MsgBox("No Data")
            Exit Sub
        End If
        If PrintDialog1.ShowDialog = DialogResult.OK Then
            Dim ev As New eventlists
            ' ev.insertscadaevent(Login_Register.empid, "Print BatchReport", "", "", "", "", "", "", "", "", "", "", "Audittrail")

            PrintDocument1.Print()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If dgvbr.Rows.Count = 0 Then
            MsgBox("No Data")
            Exit Sub
        End If
        Dim ppd As New PrintPreviewDialog
        ppd.Document = PrintDocument1
        ppd.WindowState = FormWindowState.Maximized
        ppd.ShowDialog()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        With PageSetupDialog1
            .Document = PrintDocument1
            .PageSettings = PrintDocument1.DefaultPageSettings
        End With
        If PageSetupDialog1.ShowDialog = DialogResult.OK Then
            PrintDocument1.DefaultPageSettings = PageSetupDialog1.PageSettings
        End If
    End Sub



    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        PictureBox2.Tag = "uchk"
        PictureBox2.Image = My.Resources.box1
        batchno.Enabled = False
        batchno.Text = ""

        lotno.Enabled = False
        lotno.Text = ""

        If PictureBox1.Tag = "uchk" Then
            PictureBox1.Tag = "chk"
            PictureBox1.Image = My.Resources.checked1
            DateTimePicker1.Enabled = True
            DateTimePicker2.Enabled = True
            DateTimePicker3.Enabled = True
            DateTimePicker4.Enabled = True
            Me.FilterOn = True
        Else
            PictureBox1.Tag = "uchk"
            PictureBox1.Image = My.Resources.box1
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
            DateTimePicker3.Enabled = False
            DateTimePicker4.Enabled = False
            Me.FilterOn = False

        End If
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click

        PictureBox1.Tag = "uchk"
        PictureBox1.Image = My.Resources.box1
        DateTimePicker1.Enabled = False
        DateTimePicker2.Enabled = False
        DateTimePicker3.Enabled = False
        DateTimePicker4.Enabled = False


        If PictureBox2.Tag = "uchk" Then
            PictureBox2.Tag = "chk"
            PictureBox2.Image = My.Resources.checked1
            batchno.Enabled = True
            lotno.Enabled = True

            Me.FilterOn = True
        Else
            PictureBox2.Tag = "uchk"
            PictureBox2.Image = My.Resources.box1
            batchno.Enabled = False
            batchno.Text = ""
            lotno.Enabled = False
            lotno.Text = ""

            Me.FilterOn = False
        End If


    End Sub


    Private Sub TextBox2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lotno.Click
        If batchno.Text <> "" Then
            Dim sql As New sqlclass
            '  sql.getLotlist(batchno.Text)
            '  TextBox2.AutoCompleteCustomSource = sqlclass.lotlist

        End If
    End Sub

    Private Sub dgvbr_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvbr.CellClick
        If e.RowIndex < 0 Then
            For Each column As DataGridViewColumn In dgvbr.Columns
                column.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
            Exit Sub
        End If

        If e.ColumnIndex = 0 Then
            Dim t = dgvbr.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            Dim tempbatchlot = dgvbr.Rows(e.RowIndex).Cells(0).Value.ToString.Trim
            Dim tempdate = dgvbr.Rows(e.RowIndex).Cells(2).Value.ToString.Trim
            Dim temptime = dgvbr.Rows(e.RowIndex).Cells(3).Value.ToString.Trim
            Dim tempname = dgvbr.Rows(e.RowIndex).Cells(1).Value.ToString.Trim


            'Dim prodata As New processreportdetails(tempbatchlot, tempdate, temptime, tempname)
            'prodata.StartPosition = FormStartPosition.CenterParent
            'prodata.ShowDialog()
            Dim prodata1 As New processreportdetails_audit_alarm(tempbatchlot, tempdate, temptime, tempname, printaudit, printalarm, f, tempaudit, tempalarmreport, timelength, displayformatecode)
            prodata1.StartPosition = FormStartPosition.CenterParent
            prodata1.ShowDialog()

            '   Dim  dgvbr.Rows(e.RowIndex).Cells(2).Value


            '  MsgBox(t)
        End If

    End Sub

    Private Sub TextBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles batchno.Click
        ' vesselname.AutoCompleteCustomSource = sqlclass.Batchlist
    End Sub
    Private Sub TextBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles batchno.Leave
        'vesselname.AutoCompleteCustomSource = Nothing
    End Sub



    'Private Sub dgvbr_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvbr.CellDoubleClick
    '    If e.ColumnIndex = 0 Then
    '        Dim t = dgvbr.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
    '        Dim tempprotypename = dgvbr.Rows(e.RowIndex).Cells(2).Value.ToString.Trim
    '        Dim tempprotype = 0
    '        If tempprotypename = "CIP" Then
    '            tempprotype = 0
    '        End If
    '        If tempprotypename = "VLT" Then
    '            tempprotype = 1
    '        End If
    '        If tempprotypename = "SIP" Then
    '            tempprotype = 2
    '        End If
    '        '   Dim  dgvbr.Rows(e.RowIndex).Cells(2).Value


    '        '  MsgBox(t)
    '    End If
    'End Sub

    Private Sub Button2_Click_1(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If picturebox1tag <> PictureBox1.Tag Or picturebox2tag <> PictureBox2.Tag Or datetimepicker1value <> DateTimePicker1.Value Or datetimepicker2value <> DateTimePicker2.Value Or datetimepicker3value <> DateTimePicker3.Value Or datetimepicker4value <> DateTimePicker4.Value Or textbox1value <> batchno.Text Or textbox2value <> lotno.Text Then
            MsgBox("Filters Are Changed, Please Click Search Button")
            Return
        End If
        searchbuttonclick = 0

        PageIndex = PageIndex + 1
        TotalCount = TotalCount + PageSize
        showbatchreport(batchn)
        '  MsgBox(PageIndex & totalpages)


        If PageIndex = 1 Then
            Button3.Enabled = False
        Else
            Button3.Enabled = True
        End If
        If PageIndex = totalpages Then
            Button2.Enabled = False
        Else
            Button2.Enabled = True
        End If

        Label6.Text = "page " & totalpages - PageIndex + 1 & " of " & totalpages
    End Sub

    Private Sub Button3_Click_1(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        If picturebox1tag <> PictureBox1.Tag Or picturebox2tag <> PictureBox2.Tag Or datetimepicker1value <> DateTimePicker1.Value Or datetimepicker2value <> DateTimePicker2.Value Or datetimepicker3value <> DateTimePicker3.Value Or datetimepicker4value <> DateTimePicker4.Value Or textbox1value <> batchno.Text Or textbox2value <> lotno.Text Then
            MsgBox("Filters Are Changed, Please Click Search Button")
            Return
        End If

        searchbuttonclick = 0

        PageIndex = PageIndex - 1
        TotalCount = TotalCount - PageSize
        showbatchreport(batchn)

        '  MsgBox(PageIndex & totalpages)

        If PageIndex = 1 Then
            Button3.Enabled = False

        Else
            Button3.Enabled = True

        End If
        If PageIndex = totalpages Then
            Button2.Enabled = False
        Else
            Button2.Enabled = True
        End If


        Label6.Text = "page " & totalpages - PageIndex + 1 & " of " & totalpages
    End Sub
End Class
Public Class abcd2


    '        Public Enum Tastiness
    '            Keystone
    '            Coors
    '            Guiness
    '        End Enum

    Private _name As String = Nothing
    Property Values() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value

        End Set
    End Property
    Private st As String = ""

    Property SetText As String
        Get
            Return st
        End Get
        Set(ByVal value As String)
            st = value
        End Set
    End Property
End Class