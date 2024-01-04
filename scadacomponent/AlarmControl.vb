Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class AlarmControl

    'date time formats with /
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
    'date time format select property for user (dispaly date time in this format)
    Dim displaydateformate As Datedisplay_format
    <Category("_Date Formate"), DisplayName("_Date Display format")>
    Property Date_Display_format As Datedisplay_format
        Get
            Return displaydateformate
        End Get
        Set(ByVal value As Datedisplay_format)
            displaydateformate = value
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
    Dim date_separatorvar As Datedisplay_format
    <Category("_Date Formate"), DisplayName("_Date Separator")>
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


    Dim alarmdetail As New List(Of alarms)
    Public Enum DateTime_Record
        FromPlc
        FromPc
    End Enum
    Dim dateformat = "3"
    Dim timelength = "5"
    Dim DateTime_Recordvalue As DateTime_Record
    Public alarmflag() As Boolean
    Dim tempbatchno = ""
    Dim templotno = ""
    <Category("_Misc"), DisplayName("_DateTime Record")>
    Property DateTimeRecord As DateTime_Record
        Get
            Return DateTime_Recordvalue
        End Get
        Set(ByVal value As DateTime_Record)
            DateTime_Recordvalue = value
            '  Write = write1
        End Set
    End Property
    Public Structure pageDetails
        Dim columns As Integer
        Dim rows As Integer
        Dim startCol As Integer
        Dim startRow As Integer
    End Structure
    Public pages As Dictionary(Of Integer, pageDetails)
    Dim maxPagesWide As Integer
    Dim maxPagesTall As Integer

    '  Inherits DataGridView
    Public Shared sql As New sqlclass
    Dim _alarmon As Boolean = False
    <Category("_Misc"), DisplayName("_AlarmOn")>
    Public Property AlarmOn As Boolean
        Get
            Return _alarmon
        End Get
        Set(ByVal value As Boolean)
            _alarmon = value
            If _alarmon = True Then
                alarmselect(dgv1, "", "", 0)
            End If
        End Set
    End Property
    Dim ack As Boolean = True
    <Category("_Misc"), DisplayName("_Acknowledge")>
    Public Property Acknowledge As Boolean
        Get
            Return ack
        End Get
        Set(ByVal value As Boolean)
            ack = value

        End Set
    End Property
    Dim ackbit As Integer
    <Category("_Misc"), DisplayName("_AcknowledgeBit")>
    Public Property AcknowledgeBit As Integer
        Get
            Return ackbit
        End Get
        Set(ByVal value As Integer)
            ackbit = value

        End Set
    End Property
    Dim Historydis As Boolean = True
    <Category("_Misc"), DisplayName("_History Display")>
    Public Property HistoryDisplay As Boolean
        Get
            Return Historydis
        End Get
        Set(ByVal value As Boolean)
            Historydis = value

        End Set
    End Property

    Dim db As String = ""
    <Browsable(False)>
    Property database As String
        Get

            If sqlclass.dbname <> "" Then
                db = sqlclass.dbname
            End If
            Return db
        End Get
        Set(ByVal value As String)
            db = value
            If db <> "" Then
                sqlclass.dbname = db
            Else
                db = sqlclass.dbname
            End If
        End Set
    End Property
    <Browsable(True), DisplayName("_Alarm Detail"), _
EditorBrowsable(EditorBrowsableState.Always), _
Category("_Misc"), _
DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Property Alarm_Detail As List(Of alarms)
        Get
            Return alarmdetail
        End Get
        Set(ByVal value As List(Of alarms))
            alarmdetail = value
        End Set
    End Property
    Dim maddress As String()
    <Browsable(False)>
    Public Property AlarmAddresses As String()
        Get
            Return maddress
        End Get
        Set(ByVal value As String())
            maddress = value
        End Set
    End Property
    Public Shared alist As String() = {}
    <Browsable(False)>
    Public Property AlarmList As String()
        Get
            Return alist
        End Get
        Set(ByVal value As String())
            If value.Count <> 0 Then
                alist = value
            Else
                alist = New String() {}

            End If
        End Set
    End Property
    Dim batchn As String = ""
    <Category("_Misc")>
    Public Property BatchName As String
        Get
            Return batchn
        End Get
        Set(ByVal value As String)
            batchn = value

        End Set
    End Property

    'Product Name
    'Product Code
    'Lot Numer
    Dim fltr As Boolean = False
    <Category("_Misc"), DisplayName("_Filter On")>
    Property FilterOn As Boolean
        Get
            Return fltr
        End Get
        Set(ByVal value As Boolean)
            fltr = value
        End Set
    End Property


    Dim displayalarm As Boolean
    <Category("_Misc"), DisplayName("_Alarm Display")>
    Public Property AlarmDisplay As Boolean
        Get
            Return displayalarm
        End Get
        Set(ByVal value As Boolean)
            displayalarm = value
            If displayalarm = True Then
                alarmselect(dgv1, "", "", 0)
                displayalarm = False
            End If
        End Set
    End Property
    Dim SeconddisplayMadd As Integer
    Dim seconddisplaytag As String
    <Browsable(True), _
Category("_DisplaySecond"), DisplayName("_SecondDisplay Tag")> _
    Public Property SecondDisplay_Tag As String
        Get
            Return seconddisplaytag
        End Get
        Set(ByVal value As String)
            seconddisplaytag = value
        End Set
    End Property
    Dim printop As Boolean
    <Category("_Misc"), DisplayName("_Print Option")>
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
Category("_FONTCOMPONENT"), DisplayName("_Font Component")> _
    Property FontComponent As Font
        Get
            Return f
        End Get
        Set(ByVal value As Font)
            f = value
        End Set
    End Property
    Dim colwidth As Short()
    <Category("_Misc"), DisplayName("_Column Width")>
    Property ColumnWidth As Short()
        Get
            Return colwidth
        End Get
        Set(ByVal value As Short())
            colwidth = value
        End Set
    End Property

    Dim PageSize = 80
    <Browsable(True), _
Category("_Misc"), DisplayName("_Page Size")> _
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
    Public Sub displaysecondaddress(ByVal Tag As String)

    End Sub
    Dim tempvar = 0
    Dim totalpages = 1
    Dim PageIndex = 1
    Dim TotalCount = 0
    Public Function alarmselect(ByVal dataview1 As DataGridView, ByVal batch As String, ByVal lot As String, ByVal flag As Integer) As DataGridView
        'if flag is 0 means alarmselect is called from same form
        ' flag is 1 then alarmselect is called from other form like processdetails will call this function for printing alarm report with batch/process report
        If tempvar = 0 Then
            Try
                sql.scon3()
                'query get tag_id from given tag name to display address
                '  Dim querystring As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & seconddisplaytag & "'"
                Dim querystring As String = ""
                'for encrypted or  non_encypted tables
                If variableclass.is_encrypted Then
                    querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id from Tag_data  where  convert(varchar(max), decryptbykey(Tag_name)) = '" & seconddisplaytag & "'"
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
        '  If variableclass.m(SeconddisplayMadd) = 1 Then
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
        Dim sqlquery As String = ""
        dataview1.DataSource = Nothing
        Dim ackdate = ""
        Dim acktime = ""
        Dim ds As New DataSet
        Try
            If sqlclass.dbname <> "" Then
                sql.scon1()
                If TextBox1.Enabled = True Then
                    tempbatchno = batch
                    templotno = lot
                End If
                If ack = True Then
                    ackdate = "ACKNOWLEDGE DATE"
                    acktime = "ACKNOWLEDGE TIME"
                Else
                    'acktime = " "
                    'ackdate = " "
                    acktime = "at"
                    ackdate = "ad"
                End If
                If PictureBox1.Tag = "uchk" Or flag = 1 Then
                    If batch <> "" Then
                        If lot <> "" Then
                            'sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select (select CONVERT(varchar, DecryptByKey(fname)) from employeeinfo where empid=e.empid) as 'USER NAME',CONVERT(varchar(max), DecryptByKey(eventname)) as 'ALARM DETAILS' ,CONVERT(varchar(10), DecryptByKey(date)) as 'ALARM DATE',CONVERT(varchar(" & timelength & "), DecryptByKey(time)) as  'ALARM TIME',CONVERT(varchar, DecryptByKey(var1)) as '" & ackdate & "',CONVERT(varchar(" & timelength & "), DecryptByKey (var2)) as '" & acktime & "',CONVERT(varchar, DecryptByKey(var3)) as 'RESOLVED DATE',CONVERT(varchar(" & timelength & "), DecryptByKey(var4)) as 'RESOLVED TIME',CONVERT(varchar, DecryptByKey(var5)) as statusuuu from AlarmList as e where CONVERT(varchar, DecryptByKey(action)) like 'Alarm' and (CONVERT(varchar, DecryptByKey(var10)) like '" & batch & "' and CONVERT(varchar, DecryptByKey(var9)) like '" & lot & "') " & _
                            '       " order by convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ") desc,convert(time,CONVERT(varchar, DecryptByKey(time))) desc"
                            If Date_Display_format = Datedisplay_format.ddMMMyyyy And Date_Separator = Dateseparator.Slash Then
                                sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select (select CONVERT(varchar(max), DecryptByKey(fname)) from employeeinfo where empid=e.empid) as 'USER NAME',CONVERT(varchar(max), DecryptByKey(eventname)) +'  '+COALESCE(CONVERT(varchar(max), DecryptByKey(var6)),'') as 'ALARM DETAILS' ,Replace(convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(date)), 5)," & displayformatecode & "),' ','/') as 'ALARM DATE',CONVERT(varchar(" & timelength & "), DecryptByKey(time)) as  'ALARM TIME',replace(convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(var1)), 5)," & displayformatecode & "),' ','/') as '" & ackdate & "',CONVERT(varchar(" & timelength & "), DecryptByKey (var2)) as '" & acktime & "',replace(convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(var3)), 5)," & displayformatecode & "),' ','/') as 'RESOLVED DATE',CONVERT(varchar(" & timelength & "), DecryptByKey(var4)) as 'RESOLVED TIME',CONVERT(varchar, DecryptByKey(var5)) as statusuuu from AlarmList as e where CONVERT(varchar, DecryptByKey(action)) like 'Alarm' and (CONVERT(varchar(max), DecryptByKey(var10)) like '" & batch & "' and CONVERT(varchar(max), DecryptByKey(var9)) like '" & lot & "') " & _
                                 " order by convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ") desc,convert(time,CONVERT(varchar, DecryptByKey(time))) desc"

                            ElseIf Date_Display_format = Datedisplay_format.ddMMMyyyy And Date_Separator = Dateseparator.Dash Then
                                sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select (select CONVERT(varchar(max), DecryptByKey(fname)) from employeeinfo where empid=e.empid) as 'USER NAME',CONVERT(varchar(max), DecryptByKey(eventname)) +'  '+COALESCE(CONVERT(varchar(max), DecryptByKey(var6)),'') as 'ALARM DETAILS' ,replace(convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(date)), 5)," & displayformatecode & "),' ','-') as 'ALARM DATE',CONVERT(varchar(" & timelength & "), DecryptByKey(time)) as  'ALARM TIME',replace(convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(var1)), 5)," & displayformatecode & "),' ','-') as '" & ackdate & "',CONVERT(varchar(" & timelength & "), DecryptByKey (var2)) as '" & acktime & "',replace(convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(var3)), 5)," & displayformatecode & "),' ','-') as 'RESOLVED DATE',CONVERT(varchar(" & timelength & "), DecryptByKey(var4)) as 'RESOLVED TIME',CONVERT(varchar, DecryptByKey(var5)) as statusuuu from AlarmList as e where CONVERT(varchar, DecryptByKey(action)) like 'Alarm' and (CONVERT(varchar(max), DecryptByKey(var10)) like '" & batch & "' and CONVERT(varchar(max), DecryptByKey(var9)) like '" & lot & "') " & _
                                 " order by convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ") desc,convert(time,CONVERT(varchar, DecryptByKey(time))) desc"

                            Else
                                sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select (select CONVERT(varchar(max), DecryptByKey(fname)) from employeeinfo where empid=e.empid) as 'USER NAME',CONVERT(varchar(max), DecryptByKey(eventname)) +'  '+COALESCE(CONVERT(varchar(max), DecryptByKey(var6)),'') as 'ALARM DETAILS' ,convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(date)), 5)," & displayformatecode & ") as 'ALARM DATE',CONVERT(varchar(" & timelength & "), DecryptByKey(time)) as  'ALARM TIME',convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(var1)), 5)," & displayformatecode & ") as '" & ackdate & "',CONVERT(varchar(" & timelength & "), DecryptByKey (var2)) as '" & acktime & "',convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(var3)), 5)," & displayformatecode & ") as 'RESOLVED DATE',CONVERT(varchar(" & timelength & "), DecryptByKey(var4)) as 'RESOLVED TIME',CONVERT(varchar, DecryptByKey(var5)) as statusuuu from AlarmList as e where CONVERT(varchar, DecryptByKey(action)) like 'Alarm' and (CONVERT(varchar(max), DecryptByKey(var10)) like '" & batch & "' and CONVERT(varchar(max), DecryptByKey(var9)) like '" & lot & "') " & _
                                 " order by convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ") desc,convert(time,CONVERT(varchar, DecryptByKey(time))) desc"

                            End If

                        Else
                            'sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select (select CONVERT(varchar, DecryptByKey(fname)) from employeeinfo where empid=e.empid) as 'USER NAME',CONVERT(varchar(max), DecryptByKey(eventname)) as 'ALARM DETAILS' ,CONVERT(varchar(10), DecryptByKey(date)) as 'ALARM DATE',CONVERT(varchar(" & timelength & "), DecryptByKey(time)) as  'ALARM TIME',CONVERT(varchar, DecryptByKey(var1)) as '" & ackdate & "',CONVERT(varchar(" & timelength & "), DecryptByKey (var2)) as '" & acktime & "',CONVERT(varchar, DecryptByKey(var3)) as 'RESOLVED DATE',CONVERT(varchar(" & timelength & "), DecryptByKey(var4)) as 'RESOLVED TIME',CONVERT(varchar, DecryptByKey(var5)) as statusuuu from AlarmList as e where CONVERT(varchar, DecryptByKey(action)) like 'Alarm' and (CONVERT(varchar, DecryptByKey(var10)) like '" & TextBox1.Text & "') " & _
                            '        " order by convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ") desc,convert(time,CONVERT(varchar, DecryptByKey(time))) desc"
                            If Date_Display_format = Datedisplay_format.ddMMMyyyy And Date_Separator = Dateseparator.Slash Then
                                sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select (select CONVERT(varchar(max), DecryptByKey(fname)) from employeeinfo where empid=e.empid) as 'USER NAME',CONVERT(varchar(max), DecryptByKey(eventname)) +'  '+COALESCE(CONVERT(varchar(max), DecryptByKey(var6)),'') as 'ALARM DETAILS' ,replace(convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(date)), 5)," & displayformatecode & "),' ','/') as 'ALARM DATE',CONVERT(varchar(" & timelength & "), DecryptByKey(time)) as  'ALARM TIME',replace(convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(var1)), 5),' ','/')," & displayformatecode & ") as '" & ackdate & "',CONVERT(varchar(" & timelength & "), DecryptByKey (var2)) as '" & acktime & "',replace(convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(var3)), 5)," & displayformatecode & "),' ','/') as 'RESOLVED DATE',CONVERT(varchar(" & timelength & "), DecryptByKey(var4)) as 'RESOLVED TIME',CONVERT(varchar, DecryptByKey(var5)) as statusuuu from AlarmList as e where CONVERT(varchar, DecryptByKey(action)) like 'Alarm' and (CONVERT(varchar(max), DecryptByKey(var10)) like '" & TextBox1.Text & "') " & _
                                    " order by convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ") desc,convert(time,CONVERT(varchar, DecryptByKey(time))) desc"

                            ElseIf Date_Display_format = Datedisplay_format.ddMMMyyyy And Date_Separator = Dateseparator.Dash Then
                                sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select (select CONVERT(varchar, DecryptByKey(fname)) from employeeinfo where empid=e.empid) as 'USER NAME',CONVERT(varchar(max), DecryptByKey(eventname)) +'  '+COALESCE(CONVERT(varchar(max), DecryptByKey(var6)),'') as 'ALARM DETAILS' ,replace(convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(date)), 5)," & displayformatecode & "),' ','-') as 'ALARM DATE',CONVERT(varchar(" & timelength & "), DecryptByKey(time)) as  'ALARM TIME',replace(convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(var1)), 5)," & displayformatecode & "),' ','-') as '" & ackdate & "',CONVERT(varchar(" & timelength & "), DecryptByKey (var2)) as '" & acktime & "',replace(convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(var3)), 5)," & displayformatecode & "),' ','-') as 'RESOLVED DATE',CONVERT(varchar(" & timelength & "), DecryptByKey(var4)) as 'RESOLVED TIME',CONVERT(varchar, DecryptByKey(var5)) as statusuuu from AlarmList as e where CONVERT(varchar, DecryptByKey(action)) like 'Alarm' and (CONVERT(varchar(max), DecryptByKey(var10)) like '" & TextBox1.Text & "') " & _
                                    " order by convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ") desc,convert(time,CONVERT(varchar, DecryptByKey(time))) desc"

                            Else
                                sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select (select CONVERT(varchar, DecryptByKey(fname)) from employeeinfo where empid=e.empid) as 'USER NAME',CONVERT(varchar(max), DecryptByKey(eventname)) +'  '+COALESCE(CONVERT(varchar(max), DecryptByKey(var6)),'') as 'ALARM DETAILS' ,convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(date)), 5)," & displayformatecode & ") as 'ALARM DATE',CONVERT(varchar(" & timelength & "), DecryptByKey(time)) as  'ALARM TIME',convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(var1)), 5)," & displayformatecode & ") as '" & ackdate & "',CONVERT(varchar(" & timelength & "), DecryptByKey (var2)) as '" & acktime & "',convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(var3)), 5)," & displayformatecode & ") as 'RESOLVED DATE',CONVERT(varchar(" & timelength & "), DecryptByKey(var4)) as 'RESOLVED TIME',CONVERT(varchar, DecryptByKey(var5)) as statusuuu from AlarmList as e where CONVERT(varchar, DecryptByKey(action)) like 'Alarm' and (CONVERT(varchar(max), DecryptByKey(var10)) like '" & TextBox1.Text & "') " & _
                                    " order by convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ") desc,convert(time,CONVERT(varchar, DecryptByKey(time))) desc"

                            End If


                        End If

                    Else
                        'sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select (select CONVERT(varchar, DecryptByKey(fname)) from employeeinfo where empid=e.empid) as 'USER NAME',CONVERT(varchar(max), DecryptByKey(eventname)) as 'ALARM DETAILS' ,CONVERT(varchar(10), DecryptByKey(date)) as 'ALARM DATE',CONVERT(varchar(" & timelength & "), DecryptByKey(time)) as  'ALARM TIME',CONVERT(varchar, DecryptByKey(var1)) as '" & ackdate & "',CONVERT(varchar(" & timelength & "), DecryptByKey (var2)) as '" & acktime & "',CONVERT(varchar, DecryptByKey(var3)) as 'RESOLVED DATE',CONVERT(varchar(" & timelength & "), DecryptByKey(var4)) as 'RESOLVED TIME',CONVERT(varchar, DecryptByKey(var5)) as statusuuu from AlarmList as e where CONVERT(varchar, DecryptByKey(action)) like 'Alarm'  "
                        If Date_Display_format = Datedisplay_format.ddMMMyyyy And Date_Separator = Dateseparator.Slash Then
                            sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select (select CONVERT(varchar(max), DecryptByKey(fname)) from employeeinfo where empid=e.empid) as 'USER NAME',CONVERT(varchar(max), DecryptByKey(eventname)) +'  '+COALESCE(CONVERT(varchar(max), DecryptByKey(var6)),'') as 'ALARM DETAILS' ,replace(convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(date)), 5)," & displayformatecode & "),' ','/') as 'ALARM DATE',CONVERT(varchar(" & timelength & "), DecryptByKey(time)) as  'ALARM TIME',replace(convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(var1)), 5)," & displayformatecode & "),' ','/') as '" & ackdate & "',CONVERT(varchar(" & timelength & "), DecryptByKey (var2)) as '" & acktime & "',replace(convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(var3)), 5)," & displayformatecode & "),' ','/') as 'RESOLVED DATE',CONVERT(varchar(" & timelength & "), DecryptByKey(var4)) as 'RESOLVED TIME',CONVERT(varchar, DecryptByKey(var5)) as statusuuu from AlarmList as e where CONVERT(varchar, DecryptByKey(action)) like 'Alarm'  "

                        ElseIf Date_Display_format = Datedisplay_format.ddMMMyyyy And Date_Separator = Dateseparator.Dash Then
                            sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select (select CONVERT(varchar(max), DecryptByKey(fname)) from employeeinfo where empid=e.empid) as 'USER NAME',CONVERT(varchar(max), DecryptByKey(eventname)) +'  '+COALESCE(CONVERT(varchar(max), DecryptByKey(var6)),'') as 'ALARM DETAILS' ,replace(convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(date)), 5)," & displayformatecode & "),' ','-') as 'ALARM DATE',CONVERT(varchar(" & timelength & "), DecryptByKey(time)) as  'ALARM TIME',replace(convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(var1)), 5)," & displayformatecode & "),' ','-') as '" & ackdate & "',CONVERT(varchar(" & timelength & "), DecryptByKey (var2)) as '" & acktime & "',replace(convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(var3)), 5)," & displayformatecode & "),' ','-') as 'RESOLVED DATE',CONVERT(varchar(" & timelength & "), DecryptByKey(var4)) as 'RESOLVED TIME',CONVERT(varchar, DecryptByKey(var5)) as statusuuu from AlarmList as e where CONVERT(varchar, DecryptByKey(action)) like 'Alarm'  "

                        Else
                            sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select (select CONVERT(varchar(max), DecryptByKey(fname)) from employeeinfo where empid=e.empid) as 'USER NAME',CONVERT(varchar(max), DecryptByKey(eventname)) +'  '+COALESCE(CONVERT(varchar(max), DecryptByKey(var6)),'') as 'ALARM DETAILS' ,convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(date)), 5)," & displayformatecode & ") as 'ALARM DATE',CONVERT(varchar(" & timelength & "), DecryptByKey(time)) as  'ALARM TIME',convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(var1)), 5)," & displayformatecode & ") as '" & ackdate & "',CONVERT(varchar(" & timelength & "), DecryptByKey (var2)) as '" & acktime & "',convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(var3)), 5)," & displayformatecode & ") as 'RESOLVED DATE',CONVERT(varchar(" & timelength & "), DecryptByKey(var4)) as 'RESOLVED TIME',CONVERT(varchar, DecryptByKey(var5)) as statusuuu from AlarmList as e where CONVERT(varchar, DecryptByKey(action)) like 'Alarm'  "

                        End If

                        If HistoryDisplay = False Then
                            sqlquery = sqlquery & " and CONVERT(varchar, DecryptByKey(var5))<>4"
                        End If

                        Dim temp = " order by convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ") desc,convert(time,CONVERT(varchar, DecryptByKey(time))) desc"
                        sqlquery = sqlquery & temp
                    End If

                Else
                    Dim tempsql = ""
                    'Dim tempsql = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select (select CONVERT(varchar, DecryptByKey(fname)) from employeeinfo where empid=e.empid) as 'USER NAME',CONVERT(varchar(max), DecryptByKey(eventname)) as 'ALARM NAME' ,CONVERT(varchar(10), DecryptByKey(date)) as 'ALARM DATE',CONVERT(varchar(" & timelength & "), DecryptByKey(time)) as  'ALARM TIME',CONVERT(varchar, DecryptByKey(var1)) as '" & ackdate & "',CONVERT(varchar(" & timelength & "), DecryptByKey (var2)) as '" & acktime & "',CONVERT(varchar, DecryptByKey(var3)) as 'RESOLVED DATE',CONVERT(varchar(" & timelength & "), DecryptByKey(var4)) as 'RESOLVED TIME',CONVERT(varchar, DecryptByKey(var5)) as statusuuu from AlarmList as e where CONVERT(varchar, DecryptByKey(action)) like 'Alarm' "
                    If Date_Display_format = Datedisplay_format.ddMMMyyyy And Date_Separator = Dateseparator.Slash Then
                        tempsql = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select (select CONVERT(varchar(max), DecryptByKey(fname)) from employeeinfo where empid=e.empid) as 'USER NAME',CONVERT(varchar(max), DecryptByKey(eventname)) +'  '+COALESCE(CONVERT(varchar(max), DecryptByKey(var6)),'') as 'ALARM NAME' ,replace(convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(date)), 5)," & displayformatecode & "),' ','/') as 'ALARM DATE',CONVERT(varchar(" & timelength & "), DecryptByKey(time)) as  'ALARM TIME',replace(convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(var1)), 5)," & displayformatecode & "),' ','/') as '" & ackdate & "',CONVERT(varchar(" & timelength & "), DecryptByKey (var2)) as '" & acktime & "',replace(convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(var3)), 5)," & displayformatecode & "),' ','/') as 'RESOLVED DATE',CONVERT(varchar(" & timelength & "), DecryptByKey(var4)) as 'RESOLVED TIME',CONVERT(varchar, DecryptByKey(var5)) as statusuuu from AlarmList as e where CONVERT(varchar, DecryptByKey(action)) like 'Alarm' "

                    ElseIf Date_Display_format = Datedisplay_format.ddMMMyyyy And Date_Separator = Dateseparator.Dash Then
                        tempsql = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select (select CONVERT(varchar(max), DecryptByKey(fname)) from employeeinfo where empid=e.empid) as 'USER NAME',CONVERT(varchar(max), DecryptByKey(eventname)) +'  '+COALESCE(CONVERT(varchar(max), DecryptByKey(var6)),'') as 'ALARM NAME' ,replace(convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(date)), 5)," & displayformatecode & "),' ','-') as 'ALARM DATE',CONVERT(varchar(" & timelength & "), DecryptByKey(time)) as  'ALARM TIME',replace(convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(var1)), 5)," & displayformatecode & "),' ','-') as '" & ackdate & "',CONVERT(varchar(" & timelength & "), DecryptByKey (var2)) as '" & acktime & "',replace(convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(var3)), 5)," & displayformatecode & "),' ','-') as 'RESOLVED DATE',CONVERT(varchar(" & timelength & "), DecryptByKey(var4)) as 'RESOLVED TIME',CONVERT(varchar, DecryptByKey(var5)) as statusuuu from AlarmList as e where CONVERT(varchar, DecryptByKey(action)) like 'Alarm' "

                    Else
                        tempsql = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select (select CONVERT(varchar(max), DecryptByKey(fname)) from employeeinfo where empid=e.empid) as 'USER NAME',CONVERT(varchar(max), DecryptByKey(eventname)) +'  '+COALESCE(CONVERT(varchar(max), DecryptByKey(var6)),'') as 'ALARM NAME' ,convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(date)), 5)," & displayformatecode & ") as 'ALARM DATE',CONVERT(varchar(" & timelength & "), DecryptByKey(time)) as  'ALARM TIME',convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(var1)), 5)," & displayformatecode & ") as '" & ackdate & "',CONVERT(varchar(" & timelength & "), DecryptByKey (var2)) as '" & acktime & "',convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(var3)), 5)," & displayformatecode & ") as 'RESOLVED DATE',CONVERT(varchar(" & timelength & "), DecryptByKey(var4)) as 'RESOLVED TIME',CONVERT(varchar, DecryptByKey(var5)) as statusuuu from AlarmList as e where CONVERT(varchar, DecryptByKey(action)) like 'Alarm' "

                    End If

                    If batch <> "" Then
                        If fromdate <> todate Then
                            sqlquery = tempsql & " and (CONVERT(varchar, DecryptByKey(var10)) like '" & batch & "') and " & _
                                "((convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")>='" & frominc & "'  " & _
                    "  and  convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")<='" & todec & "' ) or" & _
                    "( convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")='" & todate & "' " & _
                    "  and convert(time,CONVERT(varchar, DecryptByKey(time)))<='" & totime & "')" & _
                    "or ( convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")='" & fromdate & "'" & _
                      "  and convert(time,CONVERT(varchar, DecryptByKey(time)))>='" & fromtime & "'))" & _
                    " order by convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ") desc,convert(time,CONVERT(varchar, DecryptByKey(time))) desc"
                        Else
                            sqlquery = tempsql & " and (CONVERT(varchar, DecryptByKey(var10)) like '" & batch & "') " & _
               "and ( convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")='" & todate & "' " & _
            "  and convert(time,CONVERT(varchar, DecryptByKey(time)))<='" & totime & "')" & _
            "and ( convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")='" & fromdate & "'" & _
            "  and convert(time,CONVERT(varchar, DecryptByKey(time)))>='" & fromtime & "')" & _
            " order by convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ") desc,convert(time,CONVERT(varchar, DecryptByKey(time))) desc"

                        End If
                    Else
                        If fromdate <> todate Then
                            sqlquery = tempsql & " and  " & _
                            "((convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")>='" & frominc & "'  " & _
                "  and  convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")<='" & todec & "' ) or" & _
                "( convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")='" & todate & "' " & _
                "  and convert(time,CONVERT(varchar, DecryptByKey(time)))<='" & totime & "')" & _
                "or ( convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")='" & fromdate & "'" & _
                  "  and convert(time,CONVERT(varchar, DecryptByKey(time)))>='" & fromtime & "'))" & _
                " order by convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ") desc,convert(time,CONVERT(varchar, DecryptByKey(time))) desc"
                        Else
                            sqlquery = tempsql & _
                           "and ( convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")='" & todate & "' " & _
            "  and convert(time,CONVERT(varchar, DecryptByKey(time)))<='" & totime & "')" & _
            "and ( convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ")='" & fromdate & "'" & _
            "  and convert(time,CONVERT(varchar, DecryptByKey(time)))>='" & fromtime & "')" & _
            " order by convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ") desc,convert(time,CONVERT(varchar, DecryptByKey(time))) desc"

                        End If

                    End If
                End If

                ' when search button is clicked then only this will be initialized,not on previous and next button
                If searchbuttonclick = 1 Or PageIndex = totalpages Then

                    'to get total returned rows count and total pages, current page index
                    Dim tempsqlqueryold() As String
                    'only getting where condition to  get number of returned records by ignoring order by using  tempsqlqueryold(1).Remove(tempsqlqueryold(1).Length - 18
                    tempsqlqueryold = sqlquery.Split(New String() {"as e where"}, StringSplitOptions.None)
                    Dim sqlq1 = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select count(eno) from AlarmList where " & tempsqlqueryold(1).Remove(tempsqlqueryold(1).Length - 122)
                    '  MsgBox(sqlq1)
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
                    ' searchbuttonclick = 1
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
                tempsql1 = tempsql1.Remove(tempsql1.Length - 122)
                'eno1,USER NAME,ALARM DETAILS,ALARM DATE,ALARM TIME,ad,at,RESOLVED DATE,RESOLVED TIME,statusuuu
                Dim finalsqlquery1 = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select * from (select  ROW_NUMBER() OVER(ORDER BY eno ASC) AS eno1," & tempsql1 & ") as temp where( eno1 BETWEEN " & (TotalCount - (PageSize - 1)) & " And " & TotalCount & ") order by eno1 desc"
                'MsgBox(sqlquery)
                ' MsgBox(finalsqlquery1)
                '
                '   Dim cmd = New SqlCommand(sqlquery, sql.scn1)
                Dim cmd = New SqlCommand(finalsqlquery1, sql.scn1)

                cmd.CommandTimeout = 60

                Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)

                da.Fill(ds)
                'for removing eno1 column
                ds.Tables(0).Columns.RemoveAt(0)
                '        ds.Tables(0).Columns.Item(5).Dispose()
                If ack = False Then
                    ds.Tables(0).Columns.RemoveAt(4)
                    ds.Tables(0).Columns.RemoveAt(4)
                End If
                dataview1.Font = f
                dataview1.DataSource = ds.Tables(0)

                For i = 1 To dataview1.ColumnCount - 1
                    dataview1.Columns(i).ReadOnly = True
                Next

                dataview1color(dgv1)
                If flag = 0 Then
                    printsize(dataview1)
                Else
                    printsize(dataview1)
                End If

                ' dgv1.Columns(9).Visible = False
                '  dgv1.Columns(9).Width = 0
                If ack = False Then

                    dataview1.Columns(0).Visible = False
                    'For j = 0 To dgv1.RowCount - 1
                    '    dgv1.Rows(j).Cells(5).Value = ""
                    '    dgv1.Rows(j).Cells(6).Value = ""

                    'Next
                    'dgv1.Columns(5).Visible = False
                    'dgv1.Columns(6).Visible = False
                    'dgv1.Columns(5).Width = 1
                    'dgv1.Columns(6).Width = 1

                End If

                sql.scn1.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return dataview1

    End Function
    Sub printsize(ByVal dg As DataGridView)
        If dg.Columns.Count > 3 Then
            If ack = True Then
                'dg.Columns(2).Width = 230
                'dg.Columns(3).Width = 70
                'dg.Columns(4).Width = 55
                'If ack = True Then
                '    dg.Columns(5).Width = 75
                '    dg.Columns(6).Width = 75
                'End If
                'dg.Columns(7).Width = 65
                'dg.Columns(8).Width = 55
                dg.Columns(9).Width = 0
                dg.Columns(9).Visible = False
            Else
                'dg.Columns(1).Width = 140
                'dg.Columns(2).Width = 240
                'dg.Columns(3).Width = 70
                'dg.Columns(4).Width = 70
                'dg.Columns(5).Width = 82
                'dg.Columns(6).Width = 82
                dg.Columns(7).Width = 0
                dg.Columns(7).Visible = False
            End If
        End If
        For i = 0 To dg.ColumnCount - 1
            Try
                dg.Columns(i).Width = colwidth(i)
            Catch ex As Exception
                Exit For
            End Try
        Next
    End Sub
    Sub printsizeotherform(ByVal dg As DataGridView)
        If dg.Columns.Count > 3 Then
            If ack = True Then
                dg.Columns(1).Width = 230
                dg.Columns(2).Width = 70
                dg.Columns(3).Width = 55
                If ack = True Then
                    dg.Columns(4).Width = 75
                    dg.Columns(5).Width = 75
                End If
                dg.Columns(6).Width = 65
                dg.Columns(7).Width = 55
                dg.Columns(8).Width = 0
                '  dg.Columns(9).Width = 0
                dg.Columns(8).Visible = False
            Else
                dg.Columns(1).Width = 100
                dg.Columns(2).Width = 240
                dg.Columns(3).Width = 70
                dg.Columns(4).Width = 70
                ' If ack = True Then
                ' dgv1.Columns(5).Width = 75
                'dgv1.Columns(6).Width = 75
                'End If
                dg.Columns(5).Width = 70
                dg.Columns(6).Width = 70
                dg.Columns(7).Width = 0
                dg.Columns(7).Visible = False
            End If
        End If
    End Sub


    'for ack
    Public Sub alarmresolved(ByVal alamname As String, ByVal statuss As Integer, ByVal dt As String, ByVal tm As String)
        'Status states the alarmaction
        'status=1 - Alarm Appeared
        'Status=2 - Alarm Acknowledged
        'Status=3 - Alarm Resolved
        'Status=4 - 1,2,3 all condition done(Alarm Appeared,Alarm Acknowledged,Alarm Resolved bhi ho gya)

        If db <> "" Then
            sql.scon1()
            Dim s = ""
            'If dt = "" Then
            '    s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select top 1 CONVERT(varchar(10), DecryptByKey(date)),CONVERT(varchar, DecryptByKey(time)),CONVERT(varchar, DecryptByKey(var5)) as status from AlarmList where CONVERT(varchar(max), DecryptByKey(eventname))='" & alamname & "'  and CONVERT(varchar, DecryptByKey(action))= 'Alarm'  order by CONVERT(varchar, DecryptByKey(date)) desc,CONVERT(varchar, DecryptByKey(time)) desc "

            'Else
            '    s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select top 1 CONVERT(varchar(10), DecryptByKey(date)),CONVERT(varchar, DecryptByKey(time)),CONVERT(varchar, DecryptByKey(var5)) as status from AlarmList where CONVERT(varchar(max), DecryptByKey(eventname))='" & alamname & "' and CONVERT(varchar(10), DecryptByKey(date))='" & dt & "' and CONVERT(varchar(" & timelength & "), DecryptByKey(time))='" & tm & "'  and CONVERT(varchar, DecryptByKey(action))= 'Alarm'  order by CONVERT(varchar, DecryptByKey(date)) desc,CONVERT(varchar, DecryptByKey(time)) desc "
            'End If
            If dt = "" Then
                s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select top 1 CONVERT(varchar(10), DecryptByKey(date)),CONVERT(varchar, DecryptByKey(time)),CONVERT(varchar, DecryptByKey(var5)) as status,eno from AlarmList where CONVERT(varchar(max), DecryptByKey(eventname))='" & alamname & "' and CONVERT(varchar(max), DecryptByKey(action))='Alarm' order by eno desc "

            Else
                Dim date1 As String = Format(dt, "yyyy/MM/dd")

                If Date_Display_format = Datedisplay_format.ddMMMyyyy And Date_Separator = Dateseparator.Slash Then
                    s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select top 1 CONVERT(varchar(10), DecryptByKey(date)),CONVERT(varchar, DecryptByKey(time)),CONVERT(varchar, DecryptByKey(var5)) as status,eno from AlarmList where CONVERT(varchar(max), DecryptByKey(eventname))='" & alamname & "' and  replace(convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(date)), 5)," & displayformatecode & "),' ','/')='" & dt & "' and CONVERT(varchar(" & timelength & "), DecryptByKey(time))='" & tm & "' and CONVERT(varchar(max), DecryptByKey(action))='Alarm' order by eno desc "

                ElseIf Date_Display_format = Datedisplay_format.ddMMMyyyy And Date_Separator = Dateseparator.Dash Then
                    s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select top 1 CONVERT(varchar(10), DecryptByKey(date)),CONVERT(varchar, DecryptByKey(time)),CONVERT(varchar, DecryptByKey(var5)) as status,eno from AlarmList where CONVERT(varchar(max), DecryptByKey(eventname))='" & alamname & "' and  replace(convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(date)), 5)," & displayformatecode & "),' ','/')='" & dt & "' and CONVERT(varchar(" & timelength & "), DecryptByKey(time))='" & tm & "' and CONVERT(varchar(max), DecryptByKey(action))='Alarm' order by eno desc "

                Else
                    s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select top 1 CONVERT(varchar(10), DecryptByKey(date)),CONVERT(varchar, DecryptByKey(time)),CONVERT(varchar, DecryptByKey(var5)) as status,eno from AlarmList where CONVERT(varchar(max), DecryptByKey(eventname))='" & alamname & "' and  convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(date)), 5)," & displayformatecode & ")='" & dt & "' and CONVERT(varchar(" & timelength & "), DecryptByKey(time))='" & tm & "' and CONVERT(varchar(max), DecryptByKey(action))='Alarm' order by eno desc "

                End If
            End If

            Dim sqlcmd1 As SqlCommand = New SqlCommand(s, sql.scn1)
            Dim reader As SqlDataReader = sqlcmd1.ExecuteReader
            If reader.Read Then

                'End If
                Dim d = reader.Item(0)
                Dim t = reader.Item(1)

                Dim stat = reader.Item(2)
                If statuss = 3 And stat = 1 Then
                    stat = 3
                End If
                If statuss = 2 And stat = 3 Then
                    stat = 4
                End If
                If statuss = 2 And stat = 1 Then
                    stat = 2
                End If
                If statuss = 3 And stat = 2 Then
                    stat = 4
                End If
                ' Dim u = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update AlarmList set  var2='d',var3='t',var9='status' where date='cd'and time='ct'and var1='alamname'"
                ' Dim u = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update AlarmList set  var2=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "')),var3=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & DateTime.Now.ToString("HH:mm:ss") & "')),var9='EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & stat & "'))' where CONVERT(varchar, DecryptByKey(date)='" & d & "' and CONVERT(varchar, DecryptByKey(time))='" & t & "' and CONVERT(varchar, DecryptByKey(var1)='" & alamname & "'"
                Dim u = ""
                If statuss = 2 Then
                    u = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update AlarmList set  var1=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "')),var2=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.timee & "')),var5=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & stat & "')) where CONVERT(varchar(10), DecryptByKey(date))='" & d & "' and CONVERT(varchar, DecryptByKey(time))='" & t & "' and CONVERT(varchar(max), DecryptByKey(eventname))='" & alamname & "'"
                Else
                    u = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update AlarmList set  var3=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "')),var4=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.timee & "')),var5=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & stat & "')) where CONVERT(varchar(10), DecryptByKey(date))='" & d & "' and CONVERT(varchar(" & timelength & "), DecryptByKey(time))='" & t & "' and CONVERT(varchar(max), DecryptByKey(eventname))='" & alamname & "'"
                End If

                sql.conn2()

                '    Dim s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select top 1 CONVERT(varchar, DecryptByKey(date)),CONVERT(varchar, DecryptByKey(time)),CONVERT(varchar, DecryptByKey(var9)) as status from AlarmList where CONVERT(varchar, DecryptByKey(var1))='" & alamname & "' order by CONVERT(varchar, DecryptByKey(date)) desc,CONVERT(varchar, DecryptByKey(time)) desc "
                Dim sqlcmd2 As SqlCommand = New SqlCommand(u, sql.cn2)
                sqlcmd2.ExecuteNonQuery()
                sql.cn2.Close()
            End If
            alarmselect(dgv1, TextBox1.Text.Trim, TextBox2.Text, 0)
            reader.Close()
            sql.scn1.Close()

        End If

    End Sub
    Public Sub dataview1color(ByVal dataview1 As DataGridView)
        Dim cc = dataview1.ColumnCount - 1
        For i = dataview1.Rows.Count - 1 To 0 Step -1
            Dim temp = dataview1.Rows(i).Cells(cc).Value
            'If i = 0 Then
            If temp = 1 Then
                dataview1.Rows(i).DefaultCellStyle.BackColor = Color.LightSalmon
                dataview1.Rows(i).Cells(0).Tag = "nack"
                dataview1.Rows(i).Cells(0).Value = My.Resources.notAcknowledged

            End If
            If temp = 2 Then
                dataview1.Rows(i).DefaultCellStyle.BackColor = Color.LightSkyBlue
                dataview1.Rows(i).Cells(0).ReadOnly = True
                dataview1.Rows(i).Cells(0).Tag = "ack"
                dataview1.Rows(i).Cells(0).Value = My.Resources.acknowledged

            End If
            '-- old code
            'If temp = 3 Then
            '    If Not IsDBNull(dataview1.Rows(i).Cells(5).Value) Then
            '        Dim img As New DataGridViewImageCell
            '        img = dgv1.Rows(i).Cells(0)
            '        If dataview1.Rows(i).Cells(5).Value <> "" Then
            '            dataview1.Rows(i).DefaultCellStyle.BackColor = Color.White
            '            dataview1.Rows(i).Cells(0).ReadOnly = True
            '            dataview1.Rows(i).Cells(0).Tag = "ack"

            '            dataview1.Rows(i).Cells(0).Value = My.Resources.acknowledged
            '            If Historydis = False Then

            '                Dim currencyManager1 = BindingContext(dgv1.DataSource)
            '                currencyManager1.SuspendBinding()
            '                dataview1.Rows(i).Visible = False
            '                'MyGrid.Rows[5].Visible = false
            '                currencyManager1.ResumeBinding()

            '            End If
            '        Else
            '            dataview1.Rows(i).DefaultCellStyle.BackColor = Color.LawnGreen
            '            dataview1.Rows(i).Cells(0).Tag = "nack"
            '            dataview1.Rows(i).Cells(0).Value = My.Resources.notAcknowledged
            '        End If
            '    Else
            '        dataview1.Rows(i).Cells(0).Tag = "nack"
            '        dataview1.Rows(i).Cells(0).Value = My.Resources.notAcknowledged
            '        dataview1.Rows(i).DefaultCellStyle.BackColor = Color.LawnGreen
            '    End If

            'End If
            '--new code
            If temp = 3 Then
                If Not IsDBNull(dataview1.Rows(i).Cells(5).Value) Then
                    Dim img As New DataGridViewImageCell
                    img = dgv1.Rows(i).Cells(0)
                    If dataview1.Rows(i).Cells(5).Value <> "" Then
                        dataview1.Rows(i).DefaultCellStyle.BackColor = Color.White
                        dataview1.Rows(i).Cells(0).ReadOnly = True
                        dataview1.Rows(i).Cells(0).Tag = "ack"

                        dataview1.Rows(i).Cells(0).Value = My.Resources.acknowledged
                        'If Historydis = False Then

                        '    Dim currencyManager1 = BindingContext(dgv1.DataSource)
                        '    currencyManager1.SuspendBinding()
                        '    dataview1.Rows(i).Visible = False
                        '    'MyGrid.Rows[5].Visible = false
                        '    currencyManager1.ResumeBinding()

                        'End If
                    Else
                        dataview1.Rows(i).DefaultCellStyle.BackColor = Color.LawnGreen
                        dataview1.Rows(i).Cells(0).Tag = "nack"
                        dataview1.Rows(i).Cells(0).Value = My.Resources.notAcknowledged
                    End If
                Else
                    dataview1.Rows(i).Cells(0).Tag = "nack"
                    dataview1.Rows(i).Cells(0).Value = My.Resources.notAcknowledged
                    dataview1.Rows(i).DefaultCellStyle.BackColor = Color.LawnGreen
                End If

            End If
            If temp = 4 Then

                dataview1.Rows(i).DefaultCellStyle.BackColor = Color.White
                dataview1.Rows(i).Cells(0).ReadOnly = True
                dataview1.Rows(i).Cells(0).Tag = "ack"
                dataview1.Rows(i).Cells(0).Value = My.Resources.acknowledged

            End If
        Next
    End Sub

    Private Sub dgv1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellClick
        If e.RowIndex < 0 Then
            For Each column As DataGridViewColumn In dgv1.Columns
                column.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        End If

    End Sub

    Private Sub dgv1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellContentClick
        If e.ColumnIndex = 0 Then
            If dgv1.Rows(e.RowIndex).Cells(0).ReadOnly = False Then

                If dgv1.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag = "nack" Then
                    dgv1.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag = "ack"
                    dgv1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = My.Resources.acknowledged
                End If
                If TypeOf dgv1.CurrentCell Is DataGridViewImageCell Then
                    dgv1.EndEdit()
                    Dim imgtag As String = CType(dgv1.CurrentCell.Tag, String)
                    If imgtag = "ack" Then
                        '                MessageBox.Show("You have checked"4
                        ' DataView1.Rows(0).DefaultCellStyle.BackColor = Color.Yellow
                        ' ev.insertalarmevent(Login_Register.empid, "Alarm Resolved by User", "", 0, 0, 0, 2)
                        alarmresolved(dgv1.Rows(dgv1.CurrentRow.Index).Cells(2).Value, 2, dgv1.Rows(dgv1.CurrentRow.Index).Cells(3).Value, dgv1.Rows(dgv1.CurrentRow.Index).Cells(4).Value)
                        '  plcclass.wrtie_m_singlevalue(AcknowledgeBit, 1)
                        alarmselect(dgv1, TextBox1.Text.Trim, TextBox2.Text, 0)
                    Else
                        'DataView1.Rows(0).DefaultCellStyle.BackColor = Color.LightGreen

                    End If
                End If
            End If
        End If
    End Sub


    Private Sub TextBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Click
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
        End Try '  TextBox1.AutoCompleteCustomSource = sqlclass.Batchlist

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

    Private Sub AlarmControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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



        If Me.AlarmOn = True Then
            alarmselect(dgv1, TextBox1.Text.Trim, TextBox2.Text, 0)
            'dataview1color(dgv1)
        End If
        If Login_Register.levelid IsNot Nothing And Login_Register.levelid > 0 Then

            propertiesread(Me, Me.ParentForm)
            'showselected(Me, Me.ParentForm)
        Else
            ' If readonly1 Then
            Me.Enabled = True
            ' Else
            ' Me.Enabled = True
        End If

    End Sub




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
            Dim query As String = "open symmetric key symmetrickey1 decryption by certificate certificate1 select convert(varchar(max), decryptbykey(controlproperty)),controlstatus from controlrights  where levelid=" & Login_Register.levelid & " and convert(varchar(max), decryptbykey(formname))='" & frm.Name & "' and convert(varchar(max), decryptbykey(controlname))='" & btn.Name & "'"
            If sqlclass.dbname <> "" Then
                '   sql.scon3()
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

                            Else
                                btn.Enabled = False
                            End If
                        End If
                    End While
                End Using
                sqlclass.rightcnn.Close()
                '  sqlcmd.Dispose()
                'sql.scn3.Close()
            End If
        End If
    End Sub

    Private Sub AlarmControl_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
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
                'btnp.FormBorderStyle = Windows.Forms.FormBorderStyle.None
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
        'sql.getBatchlist()
        'TextBox1.AutoCompleteCustomSource = sqlclass.Batchlist
        searchbuttonclick = 1

        alarmselect(dgv1, TextBox1.Text.Trim, TextBox2.Text.Trim, 0)

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

    End Sub
    Sub printdoc()
        If dgv1.Rows.Count = 0 Then
            MsgBox("No Data")
            '   Exit Sub
        End If
        'dgv1.Columns(8).Visible = False
        startPage = 0
        If PrintDialog1.ShowDialog = DialogResult.OK Then
            '   Dim ev As New AlarmLists
            '      ev.insertscadaevent(Login_Register.empid, "Print SipReport", "", "", "", "", "", "", "", "", "", "", "Audittrail")
            PrintDocument1.Print()
        End If
        ' dgv1.Columns(7).Visible = True
    End Sub
    Sub printpreview()
        If dgv1.Rows.Count = 0 Then
            MsgBox("No Data")
            ' Exit Sub
        End If
        ' dgv1.Columns(7).Visible = False
        startPage = 0
        Dim ppd As New PrintPreviewDialog
        ppd.Document = PrintDocument1
        ppd.WindowState = FormWindowState.Maximized
        ppd.ShowDialog()
        '  dgv1.Columns(7).Visible = True
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


    Public Sub PrintDocument1_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint
        ''this removes the printed page margins
        PrintDocument1.OriginAtMargins = True
        PrintDocument1.DefaultPageSettings.Margins = New Drawing.Printing.Margins(0, 0, 0, 0)
        Dim dv As DataGridView = dgv1
        'If ack = False Then

        '    dv.Columns(0).Visible = False
        '    For j = 0 To dgv1.RowCount - 1
        '        dv.Rows(j).Cells(5).Value = ""
        '        dv.Rows(j).Cells(6).Value = ""

        '    Next
        '    dv.Columns(5).Visible = False
        '    dv.Columns(6).Visible = False
        '    dv.Columns(5).Width = 1
        '    dv.Columns(6).Width = 1

        'End If
        ' MsgBox(dv.Columns.Count)
        Dim temp = 0
        'If i = 1 Then
        'End If

        pages = New Dictionary(Of Integer, pageDetails)
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
        pages.Add(pageCounter, New pageDetails)

        Dim columnCounter As Integer = 0

        '-- Dim columnSum As Integer = dv.RowHeadersWidth
        Dim columnSum As Integer = dv.RowHeadersWidth

        Dim tempRowHeadersWidth = 0
        If dgv1.RowHeadersVisible = True Then
            tempRowHeadersWidth = dv.RowHeadersWidth
            columnSum = dv.RowHeadersWidth

        Else
            tempRowHeadersWidth = 0
            columnSum = 0
        End If
        'columnSum = 0
        For c As Integer = 0 To dv.Columns.Count - 1

            If columnSum + dv.Columns(c).Width < maxWidth Then
                columnSum += dv.Columns(c).Width
                columnCounter += 1
            Else
                pages(pageCounter) = New pageDetails With {.columns = columnCounter, .rows = 0, .startCol = pages(pageCounter).startCol}
                '--columnSum = dv.RowHeadersWidth + dv.Columns(c).Width
                columnSum = tempRowHeadersWidth + dv.Columns(c).Width
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
    Dim startPage As Integer = 0
    Public Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim i = 1
        Dim productname, productcode, lotno As String
        'Dim rect1 As New Rectangle(50, 50, CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Width), Panel1.Height + 200)
        '  Dim rect2 As New Rectangle(50, 50, CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Width), Panel3.Height + 200)

        '  Dim i As Integer = TabControl2.SelectedTab.Name.Substring(3)
        ' Dim dv As DataGridView = CType(TabControl2.TabPages(i - 1).Controls("dataview" & (i)), DataGridView)
        Dim dv As DataGridView = dgv1
        'Dim txtbx As TextBox = CType(TabControl2.TabPages(i - 1).Controls("text" & (i)), TextBox)

        ''sample txtbox
        Dim txtbx As TextBox = TextBox1

        Dim rect As New Rectangle(20, 20, CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Width), txtbx.Height)
        Dim rect1 As New Rectangle(0, 55, CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Width), 80)
        Dim temp = 0
        If i = 1 Then
            temp = 1
        End If
        Dim sf As New StringFormat
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center
        'Dim drawFont As New Font("Arial", 10, FontStyle.Regular)
        'Dim drawFontbold As New Font("Arial", 10, FontStyle.Bold)

        Dim drawFont As Font
        drawFont = f
        Dim drawFontbold As New Font(f.FontFamily, f.Size, FontStyle.Bold)
        '  e.Graphics.DrawImage(My.Resources.lupinvsmal, New Point(40, 20))
        e.Graphics.DrawString("", drawFontbold, Brushes.Black, New Point((e.PageBounds.Width / 2) - 140, 20))
        e.Graphics.DrawString("ALARM REPORT ", drawFontbold, Brushes.Black, New Point((e.PageBounds.Width / 2) - 100, 40))
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
                s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select   CONVERT(varchar(max), DecryptByKey(recipename)) as recipe ,CONVERT(varchar(max), DecryptByKey(var2)) as 'batch',CONVERT(varchar(max), DecryptByKey(var3)) as 'lot',CONVERT(varchar(max), DecryptByKey(var4)) as 'batchsizee',CONVERT(varchar(max), DecryptByKey(var1)) as 'username',CONVERT(varchar(max), DecryptByKey(var6)) as 'b1',CONVERT(varchar(max), DecryptByKey(var7)) as b2 ,CONVERT(varchar(max), DecryptByKey(var8)) as b3,CONVERT(varchar(max), DecryptByKey(var9)) as 'b4',CONVERT(varchar(max), DecryptByKey(var10)) as b5 ,CONVERT(varchar(max), DecryptByKey(var11)) as b6,CONVERT(varchar(max), DecryptByKey(var12)) as rpm,CONVERT(varchar(max), DecryptByKey(var13)) as printinterval,CONVERT(varchar(max), DecryptByKey(var14)) as noofcycle,CONVERT(varchar(max), DecryptByKey(time)) as 'timee',CONVERT(varchar(max), DecryptByKey(date)) as 'datee',processid,(select CONVERT(varchar(max), DecryptByKey(fname)) from employeeinfo where empid=p.empid) as Name from processinfo as p where CONVERT(varchar(max), DecryptByKey(var2)) = '" & tempbatchno & "' and CONVERT(varchar(max), DecryptByKey(var3)) like '" & templotno & "'"
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
        Dim tempy = 150
        Dim tempx = 60

        '        Try

        Dim newpage = 0


        For p As Integer = startPage To pages.Count - 1
            If p <> 0 Then
                newpage = 1
            End If

            ' If p = pages.Count - 1 Then
            ' e.Graphics.DrawString("Remark:", drawFont, Brushes.Black, 40, e.PageBounds.Height - 120)
            e.Graphics.DrawString("REMARK :", drawFont, Brushes.Black, 60, e.PageBounds.Height - 80)
            'e.Graphics.DrawString("STERILIZATION HOLD TIME  " & Label19.Text, drawFont, Brushes.Black, 400, e.PageBounds.Height - 80)
            e.Graphics.DrawString("DONE BY (SIGN/DATE)	:", drawFont, Brushes.Black, 60, e.PageBounds.Height - 40)

            e.Graphics.DrawString("CHECKED BY (SIGN/DATE)	:", drawFont, Brushes.Black, 400, e.PageBounds.Height - 40)

            ' End If
            'If p = 0 Then

            'startY = 220
            'tempy = 220
            ' Else
            startY = 150
            tempy = 150
            '  End If
            e.Graphics.DrawString("PAGE NUMBER " & p + 1 & " of " & pages.Count, drawFont, Brushes.Black, e.PageBounds.Width - 500, e.PageBounds.Height - 25)
            Dim cell As New Rectangle(startX, startY, dv.RowHeadersWidth, dv.ColumnHeadersHeight)
            'e.Graphics.FillRectangle(New SolidBrush(SystemColors.ControlLight), cell)
            'e.Graphics.DrawRectangle(Pens.Black, cell)

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
            ' If p = 0 Then
            '     startY = 220
            ' Else
            startY = tempy
            'End If
            If dgv1.RowCount = 0 Then
                Exit Sub
            End If


            For c As Integer = pages(p).startCol To pages(p).startCol + pages(p).columns - 1
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
            ' Else
            startY = tempy + dv.ColumnHeadersHeight
            'End If


            For r As Integer = pages(p).startRow + newpage To pages(p).startRow + pages(p).rows
                startX = tempx
                For c As Integer = pages(p).startCol To pages(p).startCol + pages(p).columns - 1


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


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If dgv1.Rows.Count = 0 Then
            MsgBox("No Data")
            Exit Sub
        End If
        If PrintDialog1.ShowDialog = DialogResult.OK Then
            ' Dim ev As New AlarmLists
            '  ev.insertscadaevent(Login_Register.empid, "Print AlarmList", "", "", "", "", "", "", "", "", "", "", "Audittrail")

            PrintDocument1.Print()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If dgv1.Rows.Count = 0 Then
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
            'sql.getLotlist(TextBox1.Text)
            'TextBox2.AutoCompleteCustomSource = sqlclass.lotlist

        End If
    End Sub



    Private Sub TextBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Leave
        ' TextBox1.AutoCompleteCustomSource = Nothing

    End Sub
    Dim alarmResolvedTime = ""
    Dim alarmAppearedTime = ""
    Sub getAlarmtimeFromPLC()

        alarmAppearedTime = variableclass.timee

        alarmResolvedTime = variableclass.timee
    End Sub

    Dim ev As New eventlists

    Dim temptimecheck = 0
    Dim ts, ts1, ts3 As New TimeSpan
    Dim temp = 0
    Public Sub Check_For_Alarms()
        Try
            ' CheckForPendingAlarms()
            '    getAlarmtimeFromPLC()
            ' For j = 0 To list10.Count - 1
            Dim valuechangedCounter = 0
            If dgv1.RowCount = 0 Then
                valuechangedCounter = valuechangedCounter + 1
            End If
            If temp = 0 Then
                CheckForPendingAlarms()
                temp = 1
                valuechangedCounter = valuechangedCounter + 1
            End If


            Dim tempalarmcontrol As AlarmControl = Me
            '  If TypeOf tempalarmcontrol Is scadacomponent.AlarmControl Then
            'tempa()



            Dim alarmtemp = 0
            For i = 0 To tempalarmcontrol.AlarmAddresses.Count - 1
                If tempalarmcontrol.DateTimeRecord = AlarmControl.DateTime_Record.FromPc Then
                    alarmResolvedTime = DateTime.Now.ToString("HH:mm:ss")
                    alarmAppearedTime = DateTime.Now.ToString("HH:mm:ss")
                End If
                If tempalarmcontrol.DateTimeRecord = AlarmControl.DateTime_Record.FromPlc Then
                    getAlarmtimeFromPLC()
                End If
                ' If variableclass.m(tempalarmcontrol.AlarmAddresses(i)) = 1 Then
                If Val(variableclass.tag(tempalarmcontrol.AlarmAddresses(i))) = 1 Then
                    '*/    If D(tempalarmcontrol.AlarmAddresses(i)) = 1 Then

                    If tempalarmcontrol.alarmflag(i) = False Then
                        'alarm appeared for first time
                        alarmtemp = 1
                        insertalarmAppeared1withTime(alarmAppearedTime, Login_Register.empid, i, 1, "", "", tempalarmcontrol)
                        '   wrtie_m_singlevalue(11, 1)

                        valuechangedCounter = valuechangedCounter + 1
                        tempalarmcontrol.alarmflag(i) = True
                        ' End If
                        If tempalarmcontrol.FilterOn = False Then
                            'tempalarmcontrol.AlarmDisplay = True
                        End If
                        '   tempalarmcontrol.AlarmDisplay = True
                    Else
                        'Appeared alarm pending' 
                        tempalarmcontrol.alarmflag(i) = True
                    End If
                Else
                    If tempalarmcontrol.alarmflag(i) = True Then
                        alarmresolvedwithtime(alarmResolvedTime, tempalarmcontrol.AlarmList(i), 3, "", "", tempalarmcontrol)
                        'alarm got resolved in real'
                        valuechangedCounter = valuechangedCounter + 1
                        tempalarmcontrol.alarmflag(i) = False
                    Else
                        'no alarm
                        tempalarmcontrol.alarmflag(i) = False
                    End If

                End If

            Next
            '  End If
            ' Next

            If valuechangedCounter > 0 Then
                If tempalarmcontrol.FilterOn = False Then
                    '   tempalarmcontrol.AlarmDisplay = True
                End If
                tempalarmcontrol.AlarmDisplay = True
            End If
        Catch ex As Exception
            'MsgBox("Class1- check_for_alarms: " & ex.Message)
            ev.insertscadaevent(Login_Register.empid, "check for alarm", ex.Message, "detecting alarm", "", "", "", "", "", "", "", "", "error")

        End Try

        'If temptimecheck = 1 Then
        '    ' MessageBox.Show(ts.TotalMilliseconds)
        '    ' MessageBox.Show(ts3.TotalMilliseconds)
        '    MessageBox.Show(ts1.TotalMilliseconds)


        '    temptimecheck = 0
        'End If
    End Sub
    'Insert New Alarm with Time from PLC
    Public Sub insertalarmAppeared1withTime(ByVal time1 As String, ByVal empid As Integer, ByVal alarmlistindex As Integer, ByVal status As Integer, ByVal currprocess As String, ByVal procedss_id As String, ByRef tempalm As AlarmControl) 'this method is used in scada to record Alarm action of scada
        'alarmlistindex returns index of list of alarms entered in properrty of login_register
        'alarmname from alarmlistindex needs to be passed in eventname
        '   Dim stwatch3 As New stopwatch
        'Status states the alarmaction
        'status=1 - Alarm Appeared
        'Status=2 - Alarm Acknowledged
        'Status=3 - Alarm Resolved
        'Status=4- 1,2,3 all condition done(Alarm Appeared,Alarm Acknowledged,Alarm Resolved bhi ho gya)
        Try

            sql.conn1()
            sql.conn2()

            Dim s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select top 1 CONVERT(varchar(max), DecryptByKey(var5)) as status from AlarmList where CONVERT(varchar(max), DecryptByKey(eventname))='" & tempalm.AlarmList(alarmlistindex) & "' and CONVERT(varchar(max), DecryptByKey(action))='Alarm' order by convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ") desc,convert(time, Convert(varchar, DecryptByKey(time))) desc "

            Dim sqlcmd1 As SqlCommand = New SqlCommand(s, sql.cn1)
            Dim reader As SqlDataReader = sqlcmd1.ExecuteReader
            Dim t = time1
            'sql.cn2.Open()
            If reader.Read Then
                If reader.Item(0) = 3 Or reader.Item(0) = 4 Then
                    '--while inserting alarm checking for respective alarm (alarm resolved hai) toh insert kare new alarm  agr alarm is not resolved then no alarm insert

                    Dim sqlquery As String = ""
                    'Dim t = DateTime.Now.ToString("HH:mm:ss")
                    If tempalm.alarmdetail(alarmlistindex).Enable_unique_id = True Then
                        If tempalm.AlarmList.Count = 0 Then
                            sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into AlarmList (empid,date,time,eventname,var5,var10,action,var9,var6)values('" & empid & "',EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & t & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'Alarm')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & status & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Login_Register.batchno & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'Alarm')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Login_Register.lotno & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & variableclass.tag(tempalm.tagid_of_uniqueid_tag(alarmlistindex)) & "')))"
                        Else
                            sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into AlarmList (empid,date,time,eventname,var5,var10,action,var9,var6)values('" & empid & "',EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & t & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & tempalm.AlarmList(alarmlistindex) & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & status & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Login_Register.batchno & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'Alarm')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Login_Register.lotno & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & variableclass.tag(tempalm.tagid_of_uniqueid_tag(alarmlistindex)) & "')))"
                        End If
                    Else
                        If tempalm.AlarmList.Count = 0 Then
                            sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into AlarmList (empid,date,time,eventname,var5,var10,action,var9)values('" & empid & "',EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & t & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'Alarm')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & status & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Login_Register.batchno & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'Alarm')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Login_Register.lotno & "')))"
                        Else
                            sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into AlarmList (empid,date,time,eventname,var5,var10,action,var9)values('" & empid & "',EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & t & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & tempalm.AlarmList(alarmlistindex) & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & status & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Login_Register.batchno & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'Alarm')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Login_Register.lotno & "')))"
                        End If
                    End If



                    Dim cmd = New SqlCommand(sqlquery, sql.cn2)
                    cmd.CommandTimeout = 60
                    cmd.ExecuteNonQuery()

                End If
            Else
                '--koi data nhi h alram toh insert new alarm
                Dim sqlquery As String = ""
                'Dim t = DateTime.Now.ToString("HH:mm:ss")
                ' connetionString = "Data Source=.\sqlexpress;Network Library=DBMSSOCN;INITIAL CATALOG=Pharma;user id=mohit;password=Mohit"
                If tempalm.alarmdetail(alarmlistindex).Enable_unique_id = True Then
                    If tempalm.AlarmList.Count = 0 Then
                        sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into AlarmList (empid,date,time,eventname,var5,var10,action,var9,var6)values('" & empid & "',EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & t & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'Alarm')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & status & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Login_Register.batchno & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'Alarm')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Login_Register.lotno & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & variableclass.tag(tempalm.tagid_of_uniqueid_tag(alarmlistindex)) & "')))"
                    Else
                        sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into AlarmList (empid,date,time,eventname,var5,var10,action,var9,var6)values('" & empid & "',EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & t & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & tempalm.AlarmList(alarmlistindex) & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & status & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Login_Register.batchno & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'Alarm')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Login_Register.lotno & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & variableclass.tag(tempalm.tagid_of_uniqueid_tag(alarmlistindex)) & "')))"
                    End If
                Else
                    If tempalm.AlarmList.Count = 0 Then
                        sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into AlarmList (empid,date,time,eventname,var5,var10,action,var9)values('" & empid & "',EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & t & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'Alarm')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & status & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Login_Register.batchno & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'Alarm')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Login_Register.lotno & "')))"
                    Else
                        sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into AlarmList (empid,date,time,eventname,var5,var10,action,var9)values('" & empid & "',EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & t & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar(max),'" & tempalm.AlarmList(alarmlistindex) & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & status & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Login_Register.batchno & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'Alarm')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Login_Register.lotno & "')))"
                    End If
                End If

                Dim cmd = New SqlCommand(sqlquery, sql.cn2)
                cmd.CommandTimeout = 60
                cmd.ExecuteNonQuery()

            End If

            sql.cn2.Close()
            sql.cn1.Close()

        Catch ex As Exception
            'MsgBox("Class1- insertalarmAppeared1: " & ex.Message)
            'Dim ev As New AlarmLists
            'ev.insertscadaevent(1, "", "", "", "", "", "", "", "", "", "", "", "")
            ev.insertscadaevent(Login_Register.empid, "ALarm component error", ex.Message, "insert new alarm", "", "", "", "", "", "", "", "", "error")
            'ev.insertscadaevent(Login_Register.empid, "employeeidzerocip", , , , , , , "', "", "", "", "", "error")

        End Try

    End Sub
    'Alarm resolved function Automatically with Time from PLC
    Sub alarmresolvedwithtime(ByVal time1 As String, ByVal alamname As String, ByVal statuss As Integer, ByVal dt As String, ByVal tm As String, ByRef tempalm As AlarmControl)
        Try
            'Status states the alarmaction
            'status=1 - Alarm Appeared
            'Status=2 - Alarm Acknowledged
            'Status=3 - Alarm Resolved
            'Status=4- 1,2,3 all condition done(Alarm Appeared,Alarm Acknowledged,Alarm Resolved bhi ho gya)

            Dim alarmname As String
            alarmname = alamname
            'If alamname.Length > 30 Then
            '    alarmname = alamname.Substring(0, 30)
            'Else
            '    alarmname = alamname
            'End If
            sql.conn1()
            Dim s = ""
            'If dt = "" Then
            '    s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select top 1 CONVERT(varchar(10), DecryptByKey(date)),CONVERT(varchar, DecryptByKey(time)),CONVERT(varchar, DecryptByKey(var5)) as status from AlarmList where CONVERT(varchar(max), DecryptByKey(eventname)) like '" & alarmname & "'  and CONVERT(varchar, DecryptByKey(action))= 'Alarm'  order by eno desc"
            'Else
            '    s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select top 1 CONVERT(varchar(10), DecryptByKey(date)),CONVERT(varchar, DecryptByKey(time)),CONVERT(varchar, DecryptByKey(var5)) as status from AlarmList where CONVERT(varchar(max), DecryptByKey(eventname)) like'" & alarmname & "' and CONVERT(varchar(10), DecryptByKey(date))='" & dt & "' and CONVERT(varchar, DecryptByKey(time))='" & tm & "'  and CONVERT(varchar, DecryptByKey(action))= 'Alarm' order by convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ") desc,convert(time, Convert(varchar, DecryptByKey(time))) desc "
            'End If
            If dt = "" Then
                s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select top 1 CONVERT(varchar(10), DecryptByKey(date)),CONVERT(varchar, DecryptByKey(time)),CONVERT(varchar, DecryptByKey(var5)) as status,eno from AlarmList where CONVERT(varchar(max), DecryptByKey(eventname)) like '" & alarmname & "'  order by eno desc "
            Else
                s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select top 1 CONVERT(varchar(10), DecryptByKey(date)),CONVERT(varchar, DecryptByKey(time)),CONVERT(varchar, DecryptByKey(var5)) as status,eno from AlarmList where CONVERT(varchar(max), DecryptByKey(eventname)) like'" & alarmname & "' and CONVERT(varchar(10), DecryptByKey(date))='" & dt & "' and CONVERT(varchar, DecryptByKey(time))='" & tm & "' order by eno desc "
            End If

            Dim sqlcmd1 As SqlCommand = New SqlCommand(s, sql.cn1)
            Dim reader As SqlDataReader = sqlcmd1.ExecuteReader
            Dim t1 As String = time1
            If reader.Read Then

                'End If
                Dim d = reader.Item(0)
                Dim t = reader.Item(1)
                Dim stat = reader.Item(2)
                Dim tempeno = reader.Item(3)

                If statuss = 3 And stat = 1 Then
                    stat = 3
                End If
                If statuss = 2 And stat = 3 Then
                    stat = 4
                End If
                If statuss = 2 And stat = 1 Then
                    stat = 2
                End If
                If statuss = 3 And stat = 2 Then
                    stat = 4
                End If

                Dim u = ""
                'If statuss = 2 Then
                '    u = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update AlarmList set  var1=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "')),var2=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & t1 & "')),var5=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & stat & "')) where CONVERT(varchar(10), DecryptByKey(date))='" & d & "' and CONVERT(varchar, DecryptByKey(time))='" & t & "' and CONVERT(varchar(max), DecryptByKey(eventname))='" & alarmname & "' and CONVERT(varchar, DecryptByKey(action))= 'Alarm' "
                'Else
                '    u = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update AlarmList set  var3=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "')),var4=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & t1 & "')),var5=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & stat & "')) where CONVERT(varchar(10), DecryptByKey(date))='" & d & "' and CONVERT(varchar, DecryptByKey(time))='" & t & "' and CONVERT(varchar(max), DecryptByKey(eventname))='" & alarmname & "' and CONVERT(varchar, DecryptByKey(action))= 'Alarm' "
                'End If
                If statuss = 2 Then
                    u = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update AlarmList set  var1=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "')),var2=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & t1 & "')),var5=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & stat & "')) where eno=" & tempeno
                Else
                    u = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update AlarmList set  var3=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "')),var4=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & t1 & "')),var5=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & stat & "')) where eno=" & tempeno
                End If
                sql.conn2()

                '    Dim s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select top 1 CONVERT(varchar, DecryptByKey(date)),CONVERT(varchar, DecryptByKey(time)),CONVERT(varchar, DecryptByKey(var9)) as status from AlarmList where CONVERT(varchar, DecryptByKey(var1))='" & alamname & "' order by CONVERT(varchar, DecryptByKey(date)) desc,CONVERT(varchar, DecryptByKey(time)) desc "
                Dim sqlcmd2 As SqlCommand = New SqlCommand(u, sql.cn2)
                sqlcmd2.ExecuteNonQuery()
                sql.cn2.Close()
            End If
            '  If tempalm.FilterOn = False Then
            'tempalm.AlarmDisplay = True
            'End If
            ' tempalm.AlarmDisplay = True
            'alarmselect(dgv1, batchn)
            reader.Close()
            sql.cn1.Close()
        Catch ex As Exception
            ' MsgBox("Class1- alarmresolved: " & ex.Message)
            ev.insertscadaevent(Login_Register.empid, "alarmresolved error", ex.Message, "", "", "", "", "", "", "", "", "", "error")

        End Try
    End Sub

    'Check for all alarms with status 1 and 2
    'Get bit from alarmname
    'Check for the bit.. if alarm still stays do nothing else resolve alarm with current time

    Public Sub CheckForPendingAlarms()
        Try

            Dim query As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1" & _
    " Select Convert(varchar, DecryptByKey( Date))" & _
    ",CONVERT(varchar, DecryptByKey(time))" & _
    ", CONVERT(varchar(max), DecryptByKey(eventname))" & _
    ",CONVERT(varchar(max), DecryptByKey(var1))" & _
    ",CONVERT(varchar(max), DecryptByKey(var2))" & _
    ",CONVERT(varchar(max), DecryptByKey(var3))" & _
    ",CONVERT(varchar(max), DecryptByKey(var4))" & _
    ",CONVERT(varchar(max), DecryptByKey(var5))" & _
    " fROM AlarmList where (CONVERT(varchar, DecryptByKey(var5))='1' or CONVERT(varchar, DecryptByKey(var5))='2') and  CONVERT(varchar, DecryptByKey(action))='Alarm'"
            sql.conn2()

            Dim sqlcmd2 As SqlCommand = New SqlCommand(query, sql.cn2)

            Dim read1 As SqlDataReader = sqlcmd2.ExecuteReader
            While read1.Read
                Dim aindex As Integer = Array.IndexOf(AlarmControl.alist, read1.Item(2))
                If aindex <> -1 Then
                    ' If variableclass.m(AlarmAddresses(aindex)) = 0 Then
                    If Val(variableclass.tag(AlarmAddresses(aindex))) = 0 Then
                        '*/ If d(Form1.AlarmControl1.AlarmAddresses(aindex)) = 0 Then
                        Dim dt As String = read1.Item(0)
                        Dim tm = read1.Item(1)
                        alarmresolvedautomatically(read1.Item(2), 3, dt, tm)

                    End If
                End If
            End While
            read1.Close()

            sqlcmd2.Dispose()
            sql.cn2.Close()
        Catch ex As Exception
            MsgBox("Class1- CheckForPendingAlarms: " & ex.Message)
        End Try
    End Sub
    'Alarm resolved function Automatically
    Sub alarmresolvedautomatically(ByVal alamname As String, ByVal statuss As Integer, ByVal dt As String, ByVal tm As String)
        Try
            ' Dim stwatch As New Stopwatch
            Dim alarmname As String
            If alamname.Length > 30 Then
                alarmname = alamname.Substring(0, 30)
            Else
                alarmname = alamname
            End If
            sql.conn1()
            Dim s = ""
            'If dt = "" Then
            '    s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select top 1 CONVERT(varchar(10), DecryptByKey(date)),CONVERT(varchar, DecryptByKey(time)),CONVERT(varchar, DecryptByKey(var5)) as status from AlarmList where CONVERT(varchar, DecryptByKey(eventname)) like '" & alarmname & "' and CONVERT(varchar, DecryptByKey(action)) like 'Alarm' order by convert(date,CONVERT(varchar, DecryptByKey(date)),5) desc,convert(time, Convert(varchar, DecryptByKey(time))) desc "
            'Else
            '    ' s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select top 1 CONVERT(varchar(10), DecryptByKey(date)),CONVERT(varchar, DecryptByKey(time)),CONVERT(varchar, DecryptByKey(var5)) as status from AlarmList where CONVERT(varchar, DecryptByKey(eventname)) like'" & alarmname & "' and  CONVERT(varchar, DecryptByKey(action)) like 'Alarm' and CONVERT(varchar(10), DecryptByKey(date))='" & dt & "' and CONVERT(varchar, DecryptByKey(time))='" & tm & "'order by convert(date,CONVERT(varchar, DecryptByKey(date)),103) desc,convert(time, Convert(varchar, DecryptByKey(time))) desc "
            '    s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select top 1 CONVERT(varchar(10), DecryptByKey(date)),CONVERT(varchar, DecryptByKey(time)),CONVERT(varchar, DecryptByKey(var5)) as status from AlarmList where CONVERT(varchar(max), DecryptByKey(eventname)) like'" & alarmname & "' and CONVERT(varchar(10), DecryptByKey(date))='" & dt & "' and CONVERT(varchar, DecryptByKey(time))='" & tm & "' and CONVERT(varchar(max), DecryptByKey(action))='Alarm' order by convert(date,CONVERT(varchar, DecryptByKey(date))," & dateformat & ") desc,convert(time, Convert(varchar, DecryptByKey(time))) desc "

            'End If
            If dt = "" Then
                s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select top 1 CONVERT(varchar(10), DecryptByKey(date)),CONVERT(varchar, DecryptByKey(time)),CONVERT(varchar, DecryptByKey(var5)) as status,eno from AlarmList where CONVERT(varchar(max), DecryptByKey(eventname)) like '" & alarmname & "' and CONVERT(varchar(max), DecryptByKey(action))='Alarm' order by eno desc "
            Else
                s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select top 1 CONVERT(varchar(10), DecryptByKey(date)),CONVERT(varchar, DecryptByKey(time)),CONVERT(varchar, DecryptByKey(var5)) as status,eno from AlarmList where CONVERT(varchar(max), DecryptByKey(eventname)) like'" & alarmname & "' and CONVERT(varchar(10), DecryptByKey(date))='" & dt & "' and CONVERT(varchar, DecryptByKey(time))='" & tm & "' and CONVERT(varchar(max), DecryptByKey(action))='Alarm' order by eno desc "
            End If

            Dim sqlcmd1 As SqlCommand = New SqlCommand(s, sql.cn1)
            '  stwatch.Start()
            Dim reader As SqlDataReader = sqlcmd1.ExecuteReader
            If reader.Read Then

                'End If
                Dim d = reader.Item(0)
                Dim t = reader.Item(1)
                Dim stat = reader.Item(2)
                Dim tempeno = reader.Item(3)
                If statuss = 3 And stat = 1 Then
                    stat = 3
                End If
                If statuss = 2 And stat = 3 Then
                    stat = 4
                End If
                If statuss = 2 And stat = 1 Then
                    stat = 2
                End If
                If statuss = 3 And stat = 2 Then
                    stat = 4
                End If
                Dim u = ""
                'If statuss = 2 Then
                '    u = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update AlarmList set  var1=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "')),var2=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.timee & "')),var5=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & stat & "')) where CONVERT(varchar(10), DecryptByKey(date))='" & d & "' and CONVERT(varchar, DecryptByKey(time))='" & t & "' and CONVERT(varchar, DecryptByKey(eventname))='" & alarmname & "' and CONVERT(varchar, DecryptByKey(action))= 'Alarm' "
                'Else
                '    u = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update AlarmList set  var3=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "')),var4=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.timee & "')),var5=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & stat & "')) where CONVERT(varchar(10), DecryptByKey(date))='" & d & "' and CONVERT(varchar, DecryptByKey(time))='" & t & "' and CONVERT(varchar, DecryptByKey(eventname))='" & alarmname & "'  and CONVERT(varchar, DecryptByKey(action))= 'Alarm' "
                'End If

                If statuss = 2 Then
                    u = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update AlarmList set  var1=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "')),var2=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.timee & "')),var5=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & stat & "')) where eno=" & tempeno
                Else
                    u = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update AlarmList set  var3=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "')),var4=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.timee & "')),var5=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & stat & "')) where eno=" & tempeno
                End If
                sql.conn2()

                '    Dim s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select top 1 CONVERT(varchar, DecryptByKey(date)),CONVERT(varchar, DecryptByKey(time)),CONVERT(varchar, DecryptByKey(var9)) as status from AlarmList where CONVERT(varchar, DecryptByKey(var1))='" & alamname & "' order by CONVERT(varchar, DecryptByKey(date)) desc,CONVERT(varchar, DecryptByKey(time)) desc "
                Dim sqlcmd2 As SqlCommand = New SqlCommand(u, sql.cn2)
                sqlcmd2.ExecuteNonQuery()
                sql.cn2.Close()
            End If
            'If FilterOn = False Then
            '    AlarmDisplay = True
            'End If
            'alarmselect(dgv1, batchn)
            'reader.Close()
            'stwatch.Stop()
            'ts = stwatch.Elapsed.Add(ts1)
            temptimecheck = 1
            sql.cn1.Close()
        Catch ex As Exception
            MsgBox("Class1- alarmresolved: " & ex.Message)
        End Try
    End Sub



    Sub updatevalue()
        sql.scon3()
        ReDim AlarmAddresses(alarmdetail.Count)
        ReDim AlarmList(alarmdetail.Count)
        ' ReDim tagid_of_uniqueid_tag(alarmdetail.Count)
        For i = 0 To alarmdetail.Count - 1
            '' Dim querystring As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & alarmdetail(i).AlarmTag & "'"
            Dim querystring As String = ""
            'for encrypted or  non_encypted tables
            If variableclass.is_encrypted Then
                querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id from Tag_data  where  convert(varchar(max), decryptbykey(Tag_name)) = '" & alarmdetail(i).AlarmTag & "'"
            Else
                querystring = "select Tag_id from Tag_data  where Tag_name = '" & alarmdetail(i).AlarmTag & "'"
            End If


            Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
            sqlcmd1.ExecuteNonQuery()
            Using reader As SqlDataReader = sqlcmd1.ExecuteReader
                If reader.Read = True Then
                    AlarmAddresses(i) = reader(0)
                    AlarmList(i) = alarmdetail(i).AlarmName
                Else
                    AlarmAddresses(i) = 0
                    AlarmList(i) = ""
                End If
                reader.Close()
            End Using
        Next
        ' sqlcmd1.Dispose()
        sql.scn3.Close()
        update_unique_tag_id()
    End Sub

    'strores tag_id of each given tag for unique id 
    Dim tagid_of_uniqueid_tag() As String

    Sub update_unique_tag_id()
        sql.scon3()
        ReDim tagid_of_uniqueid_tag(alarmdetail.Count)
        For i = 0 To alarmdetail.Count - 1
            '' Dim querystring As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & alarmdetail(i).AlarmTag & "'"
            Dim querystring As String = ""
            'for encrypted or  non_encypted tables
            If variableclass.is_encrypted Then
                querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id from Tag_data  where  convert(varchar(max), decryptbykey(Tag_name)) = '" & alarmdetail(i).unique_id_Tag & "'"
            Else
                querystring = "select Tag_id from Tag_data  where Tag_name = '" & alarmdetail(i).unique_id_Tag & "'"
            End If


            Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
            sqlcmd1.ExecuteNonQuery()
            Using reader As SqlDataReader = sqlcmd1.ExecuteReader
                If reader.Read = True Then
                    tagid_of_uniqueid_tag(i) = reader(0)
                Else
                    tagid_of_uniqueid_tag(i) = 0
                End If
                reader.Close()
            End Using
        Next
        ' sqlcmd1.Dispose()
        sql.scn3.Close()
    End Sub

    Private Sub Button3_Click_1(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        If picturebox1tag <> PictureBox1.Tag Or picturebox2tag <> PictureBox2.Tag Or datetimepicker1value <> DateTimePicker1.Value Or datetimepicker2value <> DateTimePicker2.Value Or datetimepicker3value <> DateTimePicker3.Value Or datetimepicker4value <> DateTimePicker4.Value Or textbox1value <> TextBox1.Text Or textbox2value <> TextBox2.Text Then
            MsgBox("Filters Are Changed, Please Click Search Button")
            Return
        End If
        searchbuttonclick = 0

        PageIndex = PageIndex - 1
        TotalCount = TotalCount - PageSize
        alarmselect(dgv1, TextBox1.Text.Trim, TextBox2.Text.Trim, 0)

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

    Private Sub Button2_Click_1(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If picturebox1tag <> PictureBox1.Tag Or picturebox2tag <> PictureBox2.Tag Or datetimepicker1value <> DateTimePicker1.Value Or datetimepicker2value <> DateTimePicker2.Value Or datetimepicker3value <> DateTimePicker3.Value Or datetimepicker4value <> DateTimePicker4.Value Or textbox1value <> TextBox1.Text Or textbox2value <> TextBox2.Text Then
            MsgBox("Filters Are Changed, Please Click Search Button")
            Return
        End If
        searchbuttonclick = 0
        PageIndex = PageIndex + 1
        TotalCount = TotalCount + PageSize
        alarmselect(dgv1, TextBox1.Text.Trim, TextBox2.Text.Trim, 0)
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

    Private Sub AlarmControl_VisibleChanged(sender As Object, e As System.EventArgs) Handles Me.VisibleChanged
        If Me.Visible And dgv1.RowCount <> 0 Then
            alarmselect(dgv1, "", "", 0)

        End If
    End Sub
End Class





Public Class alarms
    Dim Alarm_tag As String
    Public Property AlarmTag As String
        Get
            Return Alarm_tag
        End Get
        Set(ByVal value As String)
            Alarm_tag = value
        End Set
    End Property
    Dim alarm_name As String
    Public Property AlarmName As String
        Get
            Return alarm_name
        End Get
        Set(ByVal value As String)
            '   If value.Count <> 0 Then
            alarm_name = value
            '  Else


            ' End If
        End Set
    End Property

    'tag on which unique id is generated
    Dim alarm_unique_id_tag As String
    Public Property unique_id_Tag As String
        Get
            Return alarm_unique_id_tag
        End Get
        Set(ByVal value As String)
            '   If value.Count <> 0 Then
            alarm_unique_id_tag = value
            '  Else
            ' End If
        End Set
    End Property

    'property for enabling any unique_id with alarm if required
    Dim enable_error_id As Boolean = False

    Public Property Enable_unique_id As Boolean
        Get
            Return enable_error_id
        End Get
        Set(ByVal value As Boolean)
            enable_error_id = value

        End Set
    End Property
End Class
