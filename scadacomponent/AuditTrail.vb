Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class AuditTrail

    'creating enum with all date formate in which user can choose to display

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
        Slash
        Dash
    End Enum

    Dim displayformatecode As Integer = 3
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

    Public Shared batchat As String
    Dim displayat1 As Integer = 0
    Dim sql As New sqlclass
    Dim dateformat = "3" '3 for dd-mm-yy 103 dd-mm-yyyy
    Dim timelength = "5"
    Public Structure pageDetailsaudittrail
        Dim columns As Integer
        Dim rows As Integer
        Dim startCol As Integer
        Dim startRow As Integer
    End Structure
    Public pagesaudittrail As Dictionary(Of Integer, pageDetailsaudittrail)
    Dim maxPagesWide As Integer
    Dim maxPagesTall As Integer
    Dim colwidth As Short()
    Dim tempbatchno = ""
    Dim templotno = ""
    <Category("_Misc")>
    Property displayAuditTrail As Boolean
        Get
            Return displayat1
        End Get
        Set(ByVal value As Boolean)

            displayat1 = value
            If displayat1 = True Then
                displayeventfilterbatch("AuditTrail", DataGridView1, TextBox1.Text, TextBox2.Text, 0)
                displayat1 = False
            End If
        End Set
    End Property

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
    <Category("_Misc")>
    Property batchname As String
        Get
            Return batchat
        End Get
        Set(ByVal value As String)
            batchat = value

        End Set
    End Property


    'Product Name
    Dim productn As String
    <Category("_Misc")>
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
    <Category("_Misc")>
    Property ProductCode As String
        Get
            Return productc
        End Get
        Set(ByVal value As String)
            productc = value
        End Set
    End Property

    'Lot Numer
    Public Shared lotn As String
    <Category("_Misc")>
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
    Dim col_actionperform As Boolean = True
    <Browsable(True), _
Category("_COLUMN SHOW/HIDE")> _
    Property ActionPerform_Column As Boolean
        Get
            Return col_actionperform
        End Get
        Set(ByVal value As Boolean)
            col_actionperform = value
        End Set
    End Property
    Dim col_details As Boolean = True
    <Browsable(True), _
Category("_COLUMN SHOW/HIDE")> _
    Property Details_Column As Boolean
        Get
            Return col_details
        End Get
        Set(ByVal value As Boolean)
            col_details = value
        End Set
    End Property
    Dim col_change As Boolean = True
    <Browsable(True), _
Category("_COLUMN SHOW/HIDE")> _
    Property Change_Column As Boolean
        Get
            Return col_change
        End Get
        Set(ByVal value As Boolean)
            col_change = value
        End Set
    End Property

    Dim change_reason As Boolean = True
    <Browsable(True), _
Category("_COLUMN SHOW/HIDE")> _
    Property Reason_for_Change As Boolean
        Get
            Return change_reason
        End Get
        Set(ByVal value As Boolean)
            change_reason = value
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
    <Category("_Misc")>
    Property ColumnWidth As Short()
        Get
            Return colwidth
        End Get
        Set(ByVal value As Short())
            colwidth = value
        End Set
    End Property

    Dim f As Font
    <Browsable(True), _
Category("_FONTCOMPONENT")> _
    Property FontComponent As Font
        Get
            Return f
        End Get
        Set(ByVal value As Font)
            f = value
        End Set
    End Property
    Dim SeconddisplayMadd As Integer
    Dim seconddisplaytag As String
    <Browsable(True), _
Category("_DisplaySecond")> _
    Public Property SecondDisplay_Tag As String
        Get
            Return seconddisplaytag
        End Get
        Set(ByVal value As String)

            seconddisplaytag = value
        End Set
    End Property

    Dim PageSize = 80
    <Browsable(True), _
Category("_Misc"), Description("Maximum number of rows on a page")> _
    Public Property Page_Size As Integer
        Get
            Return PageSize
        End Get
        Set(ByVal value As Integer)
            PageSize = value
        End Set
    End Property

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        AddHandler Pushbutton1.action, AddressOf printdoc
        AddHandler Pushbutton2.action, AddressOf printpreview
        AddHandler Pushbutton3.action, AddressOf printsetting
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub AuditTrail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Button2.Enabled = False
        Button3.Enabled = False

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

        TextBox1.Enabled = False
        TextBox1.Text = ""

        TextBox2.Enabled = False
        TextBox2.Text = ""
        If Login_Register.levelid IsNot Nothing And Login_Register.levelid > 0 Then
            propertiesread(Me, Me.ParentForm)
            '  sql.getBatchlist()
            '   TextBox1.AutoCompleteCustomSource = sqlclass.Batchlist
            displayeventfilterbatch("AuditTrail", DataGridView1, "", "", 0)
            alternatecolours(DataGridView1)
            'showselected(Me, Me.ParentForm)
        Else
            ' If readonly1 Then
            Me.Enabled = True
            ' Else
            ' Me.Enabled = True
        End If


    End Sub
    Dim tempvar = 0

    Dim totalpages = 1
    Dim PageIndex = 1
    Dim TotalCount = 0


    Public Function displayeventfilterbatch(ByVal filtername As String, ByVal dg As DataGridView, ByVal batchno As String, ByVal lotno As String, ByVal flag As Integer) As DataGridView ' this method return the dataset for the parameter passed in it od eventlist
        If tempvar = 0 Then 'this tempvar is used because display second address is initialize only one(first) time query does not executes on every search
            Try
                sql.scon3()
                'query get tag_id from given tag name to display address
                '  Dim querystring As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id from Tag_data  where convert(varchar, decryptbykey(Tag_name)) = '" & seconddisplaytag & "'"
                Dim querystring As String = ""
                'for encrypted or  non_encypted tables
                If variableclass.is_encrypted Then
                    querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id from Tag_data  where convert(varchar, decryptbykey(Tag_name)) = '" & seconddisplaytag & "'"
                Else
                    querystring = "select Tag_id from Tag_data  where Tag_name = '" & seconddisplaytag & "'"
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
        'If variableclass.m(SeconddisplayMadd) = 1 Then
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

        '   Dim datee1 As DateTime = date1.Date
        Dim selectvar(100) As Boolean
        Dim ds = New DataSet



        selectvar(0) = True
        selectvar(1) = True
        selectvar(2) = True
        selectvar(3) = True
        selectvar(8) = True
        selectvar(9) = True
        Try
            If sqlclass.dbname <> "" Then
                sql.scon1()
                If TextBox1.Enabled = True Then
                    tempbatchno = batchno
                    templotno = lotno
                End If

                ' Dim sqlquery As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select (select CONVERT(varchar(max), DecryptByKey(fname)) from employeeinfo where empid=e.empid) as 'USER NAME',CONVERT(varchar(10), DecryptByKey(date)) as DATE,CONVERT(varchar(" & timelength & "), DecryptByKey(time)) as TIME  "
                'sirf select date me formate change karne ke liye 
                Dim sqlquery As String = ""
                If Date_Display_format = Datedisplay_format.ddMMMyyyy And Date_Separator = Dateseparator.Slash Then
                    sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select (select CONVERT(varchar(max), DecryptByKey(fname)) from employeeinfo where empid=e.empid) as 'USER NAME',replace(convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(date)), 5)," & displayformatecode & "),' ','/') as DATE,CONVERT(varchar(" & timelength & "), DecryptByKey(time)) as TIME  "

                ElseIf Date_Display_format = Datedisplay_format.ddMMMyyyy And Date_Separator = Dateseparator.Dash Then
                    sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select (select CONVERT(varchar(max), DecryptByKey(fname)) from employeeinfo where empid=e.empid) as 'USER NAME',replace(convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(date)), 5)," & displayformatecode & "),' ','/') as DATE,CONVERT(varchar(" & timelength & "), DecryptByKey(time)) as TIME  "

                Else
                    sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select (select CONVERT(varchar(max), DecryptByKey(fname)) from employeeinfo where empid=e.empid) as 'USER NAME',convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(date)), 5)," & displayformatecode & ") as DATE,CONVERT(varchar(" & timelength & "), DecryptByKey(time)) as TIME  "

                End If
                If col_actionperform = True Then
                    sqlquery = sqlquery + ",CONVERT(varchar, DecryptByKey(eventname)) as 'ACTION PERFORM'"
                End If
                If col_details = True Then
                    sqlquery = sqlquery + ",CONVERT(varchar(max), DecryptByKey(var2)) as DETAIL"
                End If
                If col_change = True Then
                    sqlquery = sqlquery + ",CONVERT(varchar(max), DecryptByKey(var3)) as CHANGE"

                End If

                If change_reason = True Then
                    sqlquery = sqlquery + ",CONVERT(varchar(max), DecryptByKey(var4)) as 'REASON FOR CHANGE'"
                End If

                Dim i = 0
                'For i = 0 To selectvar.Length - 1

                '    If selectvar(i) = True Then
                '        sqlquery = sqlquery & ",CONVERT(varchar(max), DecryptByKey(var" & i + 1 & "))"
                '    End If
                'Next
                If filtername = "" Then
                    If batchno = "" Then
                        sqlquery = sqlquery + " from eventlist as e order by CONVERT(varchar, DecryptByKey(date)) desc,CONVERT(varchar, DecryptByKey(time)) desc,eno desc"

                    Else
                        sqlquery = sqlquery + " from eventlist as e where CONVERT(varchar(max), DecryptByKey(var10))='" & batchno & "' or CONVERT(varchar(max), DecryptByKey(var10))='' order by convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ") desc,CONVERT(varchar, DecryptByKey(time)) desc,eno desc  "

                    End If
                Else
                    If PictureBox1.Tag = "uchk" Or flag = 1 Then
                        If batchno = "" Then
                            sqlquery = sqlquery + " from eventlist as e where CONVERT(varchar(max), DecryptByKey(action)) like '" & filtername & "'" & _
                            "order by eno desc "
                            '--convert(date,CONVERT(varchar, DecryptByKey(date)),103) desc,convert(time,CONVERT(varchar, DecryptByKey(time))) desc,
                            'If TextBox2.Text <> "" Then
                            '    sqlquery = sqlquery + " from eventlist as e where CONVERT(varchar(max), DecryptByKey(action)) like '" & filtername & "' and  CONVERT(varchar(max), DecryptByKey(var9))='" & TextBox2.Text & "' )" & _
                            '"order by eno desc "
                            'End If
                        Else
                            If lotno <> "" Then
                                sqlquery = sqlquery + " from eventlist as e where CONVERT(varchar(max), DecryptByKey(action)) like '" & filtername & "' and (CONVERT(varchar(max), DecryptByKey(var10))='" & batchno & "' and CONVERT(varchar(max), DecryptByKey(var9))='" & lotno & "' )" & _
                            "order by eno desc "
                            Else
                                sqlquery = sqlquery + " from eventlist as e where CONVERT(varchar(max), DecryptByKey(action)) like '" & filtername & "' and (CONVERT(varchar(max), DecryptByKey(var10))='" & batchno & "' )" & _
                            "order by eno desc "
                            End If

                        End If

                    Else

                        If TextBox1.Text = "" Then
                            If fromdate <> todate Then
                                sqlquery = sqlquery + " from eventlist as e where CONVERT(varchar(max), DecryptByKey(action)) like '" & filtername & "'" & _
            "and ((convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")>'" & fromdate & "'  " & _
            "and convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")<'" & todate & "' ) or" & _
            "(convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")='" & todate & "' " & _
            "and convert(time,CONVERT(varchar, DecryptByKey(time)))<='" & totime & "')" & _
            "or (convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")='" & fromdate & "'" & _
              "  and convert(time,CONVERT(varchar, DecryptByKey(time)))>='" & fromtime & "'))" & _
                    "order by eno desc "
                                'var10 is used for batch no.
                            Else
                                sqlquery = sqlquery + " from eventlist as e where CONVERT(varchar(max), DecryptByKey(action)) like '" & filtername & "'" & _
            "and (convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")='" & todate & "' " & _
            "and convert(time,CONVERT(varchar, DecryptByKey(time)))<='" & totime & "')" & _
            "and (convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")='" & fromdate & "'" & _
              "  and convert(time,CONVERT(varchar, DecryptByKey(time)))>='" & fromtime & "')" & _
                    "order by eno desc "

                            End If

                        Else
                            If fromdate <> todate Then
                                sqlquery = sqlquery + " from eventlist as e where CONVERT(varchar(max), DecryptByKey(action)) like '" & filtername & "' and (CONVERT(varchar(max), DecryptByKey(var10))='" & batchno & "' )" & _
            "and  ((convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")>'" & fromdate & "'  " & _
            "and  convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")<'" & todate & "' ) or" & _
            "( convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")='" & todate & "' " & _
            "  and convert(time,CONVERT(varchar, DecryptByKey(time)))<='" & totime & "')" & _
            "or ( convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")='" & fromdate & "'" & _
              "  and convert(time,CONVERT(varchar, DecryptByKey(time)))>='" & fromtime & "'))" & _
                    "order by eno desc "
                                'var10 is used for batch no.
                            Else
                                sqlquery = sqlquery + " from eventlist as e where CONVERT(varchar(max), DecryptByKey(action)) like '" & filtername & "' and (CONVERT(varchar(max), DecryptByKey(var10))='" & batchno & "' )" & _
                                "and (convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")='" & todate & "' " & _
           "and convert(time,CONVERT(varchar, DecryptByKey(time)))<='" & totime & "')" & _
           "and (convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")='" & fromdate & "'" & _
             "  and convert(time,CONVERT(varchar, DecryptByKey(time)))>='" & fromtime & "')" & _
                   "order by eno desc "

                            End If
                        End If
                    End If
                End If


                'extra code

                ' when search button is clicked then only this will be initialized,not on previous and next button
                If searchbuttonclick = 1 Or PageIndex = totalpages Then

                    'to get total returned rows count and total pages, current page index
                    Dim tempsqlqueryold() As String
                    'only getting where condition to  get number of returned records by ignoring order by using  tempsqlqueryold(1).Remove(tempsqlqueryold(1).Length - 18
                    tempsqlqueryold = sqlquery.Split(New String() {"as e where"}, StringSplitOptions.None)
                    Dim sqlq1 = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select count(eno) from EventList where " & tempsqlqueryold(1).Remove(tempsqlqueryold(1).Length - 18)

                    'MsgBox(sqlq1)
                    '    Clipboard.SetText(sqlq1)

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
                    textbox1value = TextBox1.Text
                    textbox2value = TextBox2.Text
                End If



                Dim tempsql1 = sqlquery.Remove(0, 78)
                tempsql1 = tempsql1.Remove(tempsql1.Length - 18)
                Dim finalsqlquery1 = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select * from (select  ROW_NUMBER() OVER(ORDER BY eno ASC) AS eno1," & tempsql1 & ") as temp where( eno1 BETWEEN " & (TotalCount - (PageSize - 1)) & " And " & TotalCount & ") order by eno1 desc"
                Dim cmd = New SqlCommand(finalsqlquery1, sql.scn1)

                'extra code

                ' Dim cmd = New SqlCommand(sqlquery, sql.scn1)
                cmd.CommandTimeout = 60

                Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)

                da.Fill(ds)


                'for removing eno1 column
                ds.Tables(0).Columns.RemoveAt(0)

                dg.Font = f
                dg.DataSource = ds.Tables(0)

                alternatecolours(DataGridView1)
                'dg.Columns(0).Width = 180
                'dg.Columns(1).Width = 70
                'dg.Columns(2).Width = 60
                'dg.Columns(3).Width = 230
                'dg.Columns(4).Width = 170
                For i = 0 To dg.ColumnCount - 1
                    Try
                        dg.Columns(i).Width = colwidth(i)
                    Catch ex As Exception
                        Exit For
                    End Try
                Next
                'dg.Columns(0).Width = 180
                'dg.Columns(1).Width = 70
                'dg.Columns(2).Width = 60
                'dg.Columns(3).Width = 150
                'dg.Columns(4).Width = 170
                'dg.Columns(5).Width = 150
                sql.scn1.Close()
                Return dg
                ' cnn1.Open()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

            MsgBox("Can not open connection ! ")
        End Try
        Return dg
    End Function
    Public Sub alternatecolours(ByVal dgv As DataGridView)
        For i = 0 To dgv.Rows.Count - 1 Step 2
            dgv.Rows(i).DefaultCellStyle.BackColor = Color.LightCyan
            If i + 1 <= dgv.Rows.Count - 1 Then
                dgv.Rows(i + 1).DefaultCellStyle.BackColor = Color.MintCream
            End If
        Next

    End Sub


    Public Sub propertiesread(ByVal btn As Control, ByVal frm As Form)
        '  MsgBox(btn.Name)
        '  MsgBox(frm.Name)
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
            '   MsgBox("chla")
            Dim query As String = "open symmetric key symmetrickey1 decryption by certificate certificate1 select convert(varchar, decryptbykey(controlproperty)),controlstatus from controlrights  where levelid=" & Login_Register.levelid & " and convert(varchar, decryptbykey(formname))='" & frm.Name & "' and convert(varchar, decryptbykey(controlname))='" & btn.Name & "'"
            If sqlclass.dbname <> "" Then
                '  sql.scon3()
                sqlclass.rightcon()
                Dim sqlcmd As SqlCommand = New SqlCommand(query, sqlclass.rightcnn)
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
                                '  MsgBox("enable")
                            Else
                                btn.Enabled = False
                            End If
                        End If
                    End While
                End Using
                sqlclass.rightcnn.Close()
                'sqlcmd.Dispose()
                'sql.scn3.Close()
            End If
        End If
    End Sub

    Private Sub AuditTrail_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            '       Login_Register.levelid = 1
            If Login_Register.levelid = 1 Or Login_Register.levelid = Login_Register.mngr Then
                ''        '   Panel1.Visible = True
                '            ''                showselected(Me, Me.ParentForm)

                Dim btnp As New buttonproperty(Me.ParentForm.Name, Me.Name, Me.Location.X, Me.Location.Y)
                ' btnp.StartPosition = FormStartPosition.CenterParent
                btnp.TopMost = True
                btnp.showselected(Me, Me.ParentForm)
                btnp.StartPosition = FormStartPosition.CenterScreen
                '   btnp.Panel1.Location = Me.Location
                btnp.ShowDialog()
            End If
        End If

    End Sub

    Dim searchbuttonclick = 1
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
        searchbuttonclick = 1

        '     Dim sql As New sqlclass
        displayeventfilterbatch("AuditTrail", DataGridView1, TextBox1.Text, TextBox2.Text, 0)
        '  sql.getBatchlist()
        ' TextBox1.AutoCompleteCustomSource = sqlclass.Batchlist

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
        textbox1value = TextBox1.Text
        textbox2value = TextBox2.Text


    End Sub

    Private Sub PrintDocument1_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint
        ''this removes the printed page margins
        PrintDocument1.OriginAtMargins = True
        PrintDocument1.DefaultPageSettings.Margins = New Drawing.Printing.Margins(0, 0, 0, 0)
        displayeventfilterbatch("AuditTrail", DataGridView1, TextBox1.Text, TextBox2.Text, 0)
        Dim dv As DataGridView = DataGridView1
        Dim temp = 0
        'If i = 1 Then
        'End If

        pagesaudittrail = New Dictionary(Of Integer, pageDetailsaudittrail)
        Dim maxWidth = 0
        Dim maxHeight = 0

        If PrintDocument1.DefaultPageSettings.Landscape = True Then
            maxWidth = CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Height) - 40
            maxHeight = CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Width) - 250
        Else


            maxWidth = CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Width) - 40
            maxHeight = CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Height) - 250
        End If
        Dim pageCounter As Integer = 0
        pagesaudittrail.Add(pageCounter, New pageDetailsaudittrail)

        Dim columnCounter As Integer = 0

        Dim columnSum As Integer = dv.RowHeadersWidth
        Dim tempRowHeadersWidth = 0
        If DataGridView1.RowHeadersVisible = True Then
            tempRowHeadersWidth = dv.RowHeadersWidth
            columnSum = dv.RowHeadersWidth
        Else
            tempRowHeadersWidth = 0
            columnSum = 0
        End If
        For c As Integer = 0 To dv.Columns.Count - 1
            If columnSum + dv.Columns(c).Width < maxWidth Then
                columnSum += dv.Columns(c).Width
                columnCounter += 1
            Else
                pagesaudittrail(pageCounter) = New pageDetailsaudittrail With {.columns = columnCounter, .rows = 0, .startCol = pagesaudittrail(pageCounter).startCol}
                columnSum = tempRowHeadersWidth + dv.Columns(c).Width
                columnCounter = 1
                pageCounter += 1
                pagesaudittrail.Add(pageCounter, New pageDetailsaudittrail With {.startCol = c})
            End If
            If c = dv.Columns.Count - 1 Then
                If pagesaudittrail(pageCounter).columns = 0 Then
                    pagesaudittrail(pageCounter) = New pageDetailsaudittrail With {.columns = columnCounter, .rows = 0, .startCol = pagesaudittrail(pageCounter).startCol}
                End If
            End If
        Next

        maxPagesWide = pagesaudittrail.Keys.Max + 1

        pageCounter = 0

        Dim rowCounter As Integer = 0

        Dim rowSum As Integer = dv.ColumnHeadersHeight

        For r As Integer = 0 To dv.Rows.Count - 2
            If rowSum + dv.Rows(r).Height < maxHeight Then
                rowSum += dv.Rows(r).Height
                rowCounter += 1
            Else
                pagesaudittrail(pageCounter) = New pageDetailsaudittrail With {.columns = pagesaudittrail(pageCounter).columns, .rows = rowCounter, .startCol = pagesaudittrail(pageCounter).startCol, .startRow = pagesaudittrail(pageCounter).startRow}
                For x As Integer = 1 To maxPagesWide - 1
                    pagesaudittrail(pageCounter + x) = New pageDetailsaudittrail With {.columns = pagesaudittrail(pageCounter + x).columns, .rows = rowCounter, .startCol = pagesaudittrail(pageCounter + x).startCol, .startRow = pagesaudittrail(pageCounter).startRow}
                Next

                pageCounter += maxPagesWide
                For x As Integer = 0 To maxPagesWide - 1
                    pagesaudittrail.Add(pageCounter + x, New pageDetailsaudittrail With {.columns = pagesaudittrail(x).columns, .rows = 0, .startCol = pagesaudittrail(x).startCol, .startRow = r})
                Next

                rowSum = dv.ColumnHeadersHeight + dv.Rows(r).Height
                rowCounter = 1
            End If
            If r = dv.Rows.Count - 2 Then
                For x As Integer = 0 To maxPagesWide - 1
                    If pagesaudittrail(pageCounter + x).rows = 0 Then
                        pagesaudittrail(pageCounter + x) = New pageDetailsaudittrail With {.columns = pagesaudittrail(pageCounter + x).columns, .rows = rowCounter, .startCol = pagesaudittrail(pageCounter + x).startCol, .startRow = pagesaudittrail(pageCounter + x).startRow}
                    End If
                Next
            End If
        Next

        maxPagesTall = pagesaudittrail.Count \ maxPagesWide
        If temp = 1 Then
            ' dv.Columns(0).Visible = True
        End If
    End Sub
    Dim startPage As Integer = 0
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim i = 2
        Dim productname, productcode, lotno As String
        'Dim rect1 As New Rectangle(50, 50, CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Width), Panel1.Height + 200)
        '  Dim rect2 As New Rectangle(50, 50, CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Width), Panel3.Height + 200)

        '  Dim i As Integer = TabControl2.SelectedTab.Name.Substring(3)
        ' Dim dv As DataGridView = CType(TabControl2.TabPages(i - 1).Controls("dataview" & (i)), DataGridView)
        Dim dv As DataGridView = DataGridView1
        'Dim txtbx As TextBox = CType(TabControl2.TabPages(i - 1).Controls("text" & (i)), TextBox)

        ''sample txtbox
        Dim txtbx As TextBox = TextBox1

        Dim rect As New Rectangle(20, 20, CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Width), txtbx.Height)
        Dim rect1 As New Rectangle(0, 55, CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Width), 80)
        Dim temp = 0
        ' Dim drawFont As New Font("Arial", 9, FontStyle.Regular)
        'Dim drawFontbold As New Font("Arial", 9, FontStyle.Bold)

        Dim drawFont As Font
        drawFont = f
        Dim drawFontbold As New Font(f.FontFamily, f.Size, FontStyle.Bold)
        'drawFontbold = f
        ' = FontStyle.Bold


        If i = 1 Then
            ' temp = 1
        End If
        Dim sf, rf As New StringFormat
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center
        rf.Alignment = StringAlignment.Near
        rf.LineAlignment = StringAlignment.Near


        '        e.Graphics.DrawString("RMS MIS", txtbx.Font, Brushes.Black, New Point(38, 75))
        '       e.Graphics.DrawString("Intervention Project Report", txtbx.Font, Brushes.Black, New Point(38, 90))

        '  e.Graphics.DrawImage(My.Resources.lupinvsmal, New Point(40, 20))
        e.Graphics.DrawString("", drawFontbold, Brushes.Black, New Point((e.PageBounds.Width / 2) - 140, 20))
        e.Graphics.DrawString("EVENT REPORT", drawFontbold, Brushes.Black, New Point((e.PageBounds.Width / 2) - 100, 40))

        If TextBox1.Enabled = True Then
            If TextBox1.Text = tempbatchno And templotno = TextBox2.Text Then
                Dim s As String = ""
                sql.conn1()
                'var1  load_username
                'var2   Form1.txtbatchno.Text
                'var3    Form1.txtlotno.Text
                'var4   batch size
                'var5   lbl_username 
                'var6   blender1
                'var7   blender2
                'var8   blender3 
                'var9   blender4
                'var10  blender5
                'var11  blender6
                'var12  numeric_rpm 
                'var13  numeric_printinterval
                'var14  numeric_noofcycle
                'Dim tempprocessid = batch_lot
                s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select   CONVERT(varchar, DecryptByKey(recipename)) as recipe ,CONVERT(varchar, DecryptByKey(var2)) as 'batch',CONVERT(varchar, DecryptByKey(var3)) as 'lot',CONVERT(varchar, DecryptByKey(var4)) as 'batchsizee',CONVERT(varchar, DecryptByKey(var1)) as 'username',CONVERT(varchar, DecryptByKey(var6)) as 'b1',CONVERT(varchar, DecryptByKey(var7)) as b2 ,CONVERT(varchar, DecryptByKey(var8)) as b3,CONVERT(varchar, DecryptByKey(var9)) as 'b4',CONVERT(varchar, DecryptByKey(var10)) as b5 ,CONVERT(varchar, DecryptByKey(var11)) as b6,CONVERT(varchar, DecryptByKey(var12)) as rpm,CONVERT(varchar, DecryptByKey(var13)) as printinterval,CONVERT(varchar, DecryptByKey(var14)) as noofcycle,CONVERT(varchar, DecryptByKey(time)) as 'timee',CONVERT(varchar, DecryptByKey(date)) as 'datee',processid,(select CONVERT(varchar, DecryptByKey(fname)) from employeeinfo where empid=p.empid) as Name from processinfo as p where CONVERT(varchar, DecryptByKey(var2)) = '" & tempbatchno & "' and CONVERT(varchar, DecryptByKey(var3)) like '" & templotno & "'"
                Dim cmd = New SqlCommand(s, sql.cn1)
                cmd.CommandTimeout = 60

                Dim sqlreader As SqlDataReader = cmd.ExecuteReader
                If sqlreader.Read Then
                    'sqlreader.Item("recipe")
                    'sqlreader.Item("batch")
                    'sqlreader.Item("lot")
                    'sqlreader.Item("username")
                    'tempoperatorname()
                    'sqlreader.Item("batchsizee")
                    'sqlreader.Item("processid")
                    'sqlreader.Item("rpm")
                    'sqlreader.Item("noofcycle")

                    e.Graphics.DrawString("PRODUCT NAME		", drawFontbold, Brushes.Black, 80, 60)
                    e.Graphics.DrawString(sqlreader.Item("recipe"), drawFont, Brushes.Black, 250, 60)
                    e.Graphics.DrawString("BATCH NUMBER	    ", drawFontbold, Brushes.Black, 80, 80)
                    e.Graphics.DrawString(sqlreader.Item("batch"), drawFont, Brushes.Black, 250, 80)
                    e.Graphics.DrawString("LOT NUMBER	    ", drawFontbold, Brushes.Black, 80, 100)
                    e.Graphics.DrawString(sqlreader.Item("lot"), drawFont, Brushes.Black, 250, 100)
                    e.Graphics.DrawString("SUPERVISOR NAME		", drawFontbold, Brushes.Black, 480, 60)
                    e.Graphics.DrawString(sqlreader.Item("username"), drawFont, Brushes.Black, 630, 60)
                    e.Graphics.DrawString("OPERATOR NAME	    ", drawFontbold, Brushes.Black, 480, 80)
                    e.Graphics.DrawString(sqlreader.Item("name"), drawFont, Brushes.Black, 630, 80)
                    e.Graphics.DrawString("BATCH SIZE(KG'S)	    ", drawFontbold, Brushes.Black, 480, 100)
                    e.Graphics.DrawString(sqlreader.Item("batchsizee"), drawFont, Brushes.Black, 630, 100)

                End If
                sql.cn1.Close()
            End If
        End If
        sf.Alignment = StringAlignment.Near

        Dim startX As Integer = 60
        Dim startY As Integer = 150
        Dim tempy = 0

        '        Try
        Dim newpage = 0
        For p As Integer = startPage To pagesaudittrail.Count - 1
            If p <> 0 Then
                newpage = 1
            End If

            '   If p = pages.Count - 1 Then
            ' e.Graphics.DrawString("Remark:", drawFont, Brushes.Black, 40, e.PageBounds.Height - 120)
            e.Graphics.DrawString("REMARK :", drawFont, Brushes.Black, 60, e.PageBounds.Height - 80)
            'e.Graphics.DrawString("STERILIZATION HOLD TIME  " & Label19.Text, drawFont, Brushes.Black, 400, e.PageBounds.Height - 80)
            e.Graphics.DrawString("DONE BY (SIGN/DATE)	:", drawFont, Brushes.Black, 60, e.PageBounds.Height - 40)

            e.Graphics.DrawString("CHECKED BY (SIGN/DATE)	:", drawFont, Brushes.Black, 400, e.PageBounds.Height - 40)

            '    End If
            '  If p = 0 Then
            startY = 150
            tempy = 150
            'End If
            e.Graphics.DrawString("PAGE NUMBER " & p + 1 & " of " & pagesaudittrail.Count, drawFont, Brushes.Black, e.PageBounds.Width - 500, e.PageBounds.Height - 25)
            Dim cell As New Rectangle(startX, startY, dv.RowHeadersWidth, dv.ColumnHeadersHeight)
            '   e.Graphics.FillRectangle(New SolidBrush(SystemColors.ControlLight), cell)
            '  e.Graphics.DrawRectangle(Pens.Black, cell)

            'startY += dv.ColumnHeadersHeight

            'For r As Integer = pages(p).startRow + newpage To pages(p).startRow + pages(p).rows
            '    cell = New Rectangle(startX, startY, dv.RowHeadersWidth, dv.Rows(r).Height)
            '    e.Graphics.FillRectangle(New SolidBrush(SystemColors.ControlLight), cell)
            '    e.Graphics.DrawRectangle(Pens.Black, cell)
            '    If r <> 0 Then
            '        '     MsgBox(DataGridView3.Rows(r).HeaderCell.Value.ToString)
            '        '    e.Graphics.DrawString(dv.Rows(r).HeaderCell.Value.ToString, TextBox10.Font, Brushes.Black, cell, sf)
            '    End If
            '    startY += dv.Rows(r).Height
            'Next

            'startX += cell.Width
            ''If p = 0 Then
            ''startY = 220
            '' Else
            startY = 150
            ' End If

            If dv.RowCount = 0 Then
                Exit Sub
            End If
            For c As Integer = pagesaudittrail(p).startCol To pagesaudittrail(p).startCol + pagesaudittrail(p).columns - 1
                If (temp = 1 And c = 0) Or (temp = 1 And c = dv.Columns.Count - 1) Then

                Else
                    ' End If
                    cell = New Rectangle(startX, startY, dv.Columns(c).Width, dv.ColumnHeadersHeight)
                    e.Graphics.FillRectangle(New SolidBrush(SystemColors.ControlLight), cell)
                    e.Graphics.DrawRectangle(Pens.Black, cell)
                    e.Graphics.DrawString(dv.Columns(c).HeaderCell.Value.ToString, drawFontbold, Brushes.Black, cell, sf)
                    startX += dv.Columns(c).Width
                End If
            Next

            '    If p = 0 Then
            ' startY = 220 + dv.ColumnHeadersHeight
            'Else
            startY = tempy + dv.ColumnHeadersHeight
            ' End If



            For r As Integer = pagesaudittrail(p).startRow + newpage To pagesaudittrail(p).startRow + pagesaudittrail(p).rows

                startX = 19 + dv.RowHeadersWidth
                For c As Integer = pagesaudittrail(p).startCol To pagesaudittrail(p).startCol + pagesaudittrail(p).columns - 1
                    cell = New Rectangle(startX, startY, dv.Columns(c).Width, dv.Rows(r).Height)
                    If (c = 0 And temp = 1) Or (temp = 1 And c = dv.Columns.Count - 1) Then
                        startX += 0
                    Else
                        e.Graphics.DrawRectangle(Pens.Black, cell)
                        e.Graphics.DrawString(dv(c, r).Value.ToString, drawFont, Brushes.Black, cell, sf)
                        startX += dv.Columns(c).Width
                    End If
                    '  e.Graphics.DrawString(dv.Rows(r).Cells(0).Value.ToString, TextBox10.Font, Brushes.Black, cell, sf)
                    '  startX += dv.Columns(c).Width
                    'f
                Next
                startY += dv.Rows(r).Height
            Next

            If p <> pagesaudittrail.Count - 1 Then
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
        If DataGridView1.Rows.Count = 0 Then
            MsgBox("No Data")
            ' Exit Sub
        End If
        If PrintDialog1.ShowDialog = DialogResult.OK Then
            '  Dim ev As New eventlists
            '   ev.insertscadaevent(Login_Register.empid, "Print SipReport", "", "", "", "", "", "", "", "", "", "", "Audittrail")
            startPage = 0
            PrintDocument1.Print()
        End If
    End Sub
    Sub printpreview()
        If DataGridView1.Rows.Count = 0 Then
            MsgBox("No Data")
            'Exit Sub
        End If
        startPage = 0
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
        If DataGridView1.Rows.Count = 0 Then
            MsgBox("No Data")
            Exit Sub
        End If
        If PrintDialog1.ShowDialog = DialogResult.OK Then
            Dim ev As New eventlists
            ' ev.insertscadaevent(Login_Register.empid, "Print AduitTrail", "", "", "", "", "", "", "", "", "", "", "Audittrail")
            PrintDocument1.Print()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If DataGridView1.Rows.Count = 0 Then
            MsgBox("No Data")
            Exit Sub
        End If
        startPage = 0
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
        TextBox1.Enabled = False
        TextBox1.Text = ""
        TextBox2.Enabled = False
        TextBox2.Text = ""


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
            TextBox1.Enabled = True
            TextBox2.Enabled = True
            Me.FilterOn = True
        Else
            PictureBox2.Tag = "uchk"
            PictureBox2.Image = My.Resources.box1
            TextBox1.Enabled = False
            TextBox1.Text = ""
            TextBox2.Enabled = False
            TextBox2.Text = ""

            Me.FilterOn = False
        End If



    End Sub

    Private Sub TextBox2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.Click
        If TextBox1.Text <> "" Then
            Dim sql As New sqlclass
            '  sql.getLotlist(TextBox1.Text)
            ' TextBox2.AutoCompleteCustomSource = sqlclass.lotlist

        End If
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex < 0 Then
            For Each column As DataGridViewColumn In DataGridView1.Columns
                column.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        End If

    End Sub

    Private Sub TextBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Click
        '  If TextBox1.Text <> "" Then
        Dim sql As New sqlclass
        '   sql.getBatchlist()
        ' TextBox2.AutoCompleteCustomSource = sqlclass.lotlist
        '   TextBox1.AutoCompleteCustomSource = sqlclass.Batchlist
        ' End If


    End Sub

    Private Sub TextBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Leave
        'TextBox1.AutoCompleteCustomSource = Nothing
    End Sub

    Private Sub Button2_Click_1(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If picturebox1tag <> PictureBox1.Tag Or picturebox2tag <> PictureBox2.Tag Or datetimepicker1value <> DateTimePicker1.Value Or datetimepicker2value <> DateTimePicker2.Value Or datetimepicker3value <> DateTimePicker3.Value Or datetimepicker4value <> DateTimePicker4.Value Or textbox1value <> TextBox1.Text Or textbox2value <> TextBox2.Text Then
            MsgBox("Filters Are Changed, Please Click Search Button")
            Return
        End If

        searchbuttonclick = 0

        PageIndex = PageIndex + 1
        TotalCount = TotalCount + PageSize
        displayeventfilterbatch("AuditTrail", DataGridView1, TextBox1.Text, TextBox2.Text, 0)
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
        If picturebox1tag <> PictureBox1.Tag Or picturebox2tag <> PictureBox2.Tag Or datetimepicker1value <> DateTimePicker1.Value Or datetimepicker2value <> DateTimePicker2.Value Or datetimepicker3value <> DateTimePicker3.Value Or datetimepicker4value <> DateTimePicker4.Value Or textbox1value <> TextBox1.Text Or textbox2value <> TextBox2.Text Then
            MsgBox("Filters Are Changed, Please Click Search Button")
            Return
        End If

        searchbuttonclick = 0

        PageIndex = PageIndex - 1
        TotalCount = TotalCount - PageSize
        displayeventfilterbatch("AuditTrail", DataGridView1, TextBox1.Text, TextBox2.Text, 0)

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

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.Click
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

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.Click
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
