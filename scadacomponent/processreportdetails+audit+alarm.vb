Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing
Public Class processreportdetails_audit_alarm
    Public Structure pageDetails
        Dim columns As Integer
        Dim rows As Integer
        Dim startCol As Integer
        Dim startRow As Integer
    End Structure
    Public pages As Dictionary(Of Integer, pageDetails)
    Dim maxPagesWide As Integer
    Dim maxPagesTall As Integer
    '  Dim dgv1 As New DataGridView
    Public audit As AuditTrail
    Public tempalarmreport As AlarmControl
    Public Structure pageDetailsalarm
        Dim columns As Integer
        Dim rows As Integer
        Dim startCol As Integer
        Dim startRow As Integer
    End Structure
    Public pagesalarm As Dictionary(Of Integer, pageDetailsalarm)
    Public Structure pageDetailsaudittrail
        Dim columns As Integer
        Dim rows As Integer
        Dim startCol As Integer
        Dim startRow As Integer
    End Structure
    Public pagesaudittrail As Dictionary(Of Integer, pageDetailsaudittrail)
    Dim maxPagesWidealarm As Integer
    Dim maxPagesTallalarm As Integer
    Dim dgvaudittrail As New DataGridView


    'code for display date time in report
    Dim displayformatecode As Integer

    Dim sql As New sqlclass
    Dim reporton As Boolean = True
    Dim reportshow As Boolean = False
    Dim triggered1 As Boolean = False
    Dim includeauditreport_print As Boolean
    Dim includealarmreport_print As Boolean

    Dim processid
    Dim batch_lot = 0
    Dim tempdate = ""
    Dim temptime = ""
    Dim tempoperatorname = ""
    Dim f As Font
    Dim timelength = "5"
    Sub New(ByVal pid As Integer)
        batch_lot = pid
        ' This call is required by the designer.
        InitializeComponent()
        AddHandler Pushbutton1.action, AddressOf printdoc
        AddHandler Pushbutton2.action, AddressOf printpreview
        AddHandler Pushbutton3.action, AddressOf printsetting
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Sub New(ByVal pid As String, ByVal dt As String, ByVal timee As String, ByVal opname As String)
        batch_lot = pid
        tempdate = dt
        temptime = timee
        tempoperatorname = opname

        ' This call is required by the designer.
        InitializeComponent()
        AddHandler Pushbutton1.action, AddressOf printdoc
        AddHandler Pushbutton2.action, AddressOf printpreview
        AddHandler Pushbutton3.action, AddressOf printsetting
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Sub New(ByVal pid As String, ByVal dt As String, ByVal timee As String, ByVal opname As String, ByVal printaudit As String, ByVal printalarm As String, ByVal FFONT As Font, ByVal temppaudit As AuditTrail, ByVal temppalarm As AlarmControl, ByVal timlen As String, ByVal displaydatecode As Integer)
        batch_lot = pid
        tempdate = dt
        temptime = timee
        tempoperatorname = opname
        includeauditreport_print = printaudit
        includealarmreport_print = printalarm
        f = FFONT
        audit = temppaudit
        timelength = timlen
        tempalarmreport = temppalarm
        displayformatecode = displaydatecode
        ' This call is required by the designer.
        InitializeComponent()
        AddHandler Pushbutton1.action, AddressOf printdoc
        AddHandler Pushbutton2.action, AddressOf printpreview
        AddHandler Pushbutton3.action, AddressOf printsetting
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Dim tempnoofcycle = 0
    Public Sub selectdefaultvalue()
        Dim s As String = ""
        sql.conn1()
        'var1  load_username
        'var2   Form1.txtbatchno.Text
        'var3    Form1.txtlotno.Text
        'var4   batch size / used for product code
        'var5   lbl_username 


        Dim tempprocessid = batch_lot
        '        s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select   CONVERT(varchar, DecryptByKey(recipename)) as recipe ,CONVERT(varchar, DecryptByKey(var2)) as 'batch',CONVERT(varchar, DecryptByKey(var3)) as 'lot',CONVERT(varchar, DecryptByKey(var4)) as 'batchsizee',CONVERT(varchar, DecryptByKey(var1)) as 'username',CONVERT(varchar, DecryptByKey(var6)) as 'b1',CONVERT(varchar, DecryptByKey(var7)) as b2 ,CONVERT(varchar, DecryptByKey(var8)) as b3,CONVERT(varchar, DecryptByKey(var9)) as 'b4',CONVERT(varchar, DecryptByKey(var10)) as b5 ,CONVERT(varchar, DecryptByKey(var11)) as b6,CONVERT(varchar, DecryptByKey(var12)) as rpm,CONVERT(varchar, DecryptByKey(var13)) as printinterval,CONVERT(varchar, DecryptByKey(var14)) as noofcycle,CONVERT(varchar, DecryptByKey(time)) as 'timee',CONVERT(varchar, DecryptByKey(date)) as 'datee',processid from processinfo  where CONVERT(varchar, DecryptByKey(date)) like '" & tempdate & "' and CONVERT(varchar(" & timelength & "), DecryptByKey(time)) like '" & temptime & "'"
    If displayformatecode = 106 Then
            s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select   CONVERT(varchar, DecryptByKey(recipename)) as recipe ,CONVERT(varchar, DecryptByKey(var2)) as 'batch',CONVERT(varchar, DecryptByKey(var3)) as 'lot',CONVERT(varchar, DecryptByKey(var4)) as 'batchsizee',CONVERT(varchar, DecryptByKey(var1)) as 'username',CONVERT(varchar, DecryptByKey(var6)),CONVERT(varchar, DecryptByKey(var7)),CONVERT(varchar, DecryptByKey(var8)),CONVERT(varchar, DecryptByKey(var9)),CONVERT(varchar, DecryptByKey(var10)),CONVERT(varchar, DecryptByKey(var11)),CONVERT(varchar, DecryptByKey(var12)),CONVERT(varchar, DecryptByKey(var13)),CONVERT(varchar, DecryptByKey(var14))," _
        & " CONVERT(varchar, DecryptByKey(var15)),CONVERT(varchar, DecryptByKey(var16)),CONVERT(varchar, DecryptByKey(var17)),CONVERT(varchar, DecryptByKey(var18)),CONVERT(varchar, DecryptByKey(var19)),CONVERT(varchar, DecryptByKey(var20)),CONVERT(varchar, DecryptByKey(var21)),CONVERT(varchar, DecryptByKey(var22)),CONVERT(varchar, DecryptByKey(var23))," _
        & " CONVERT(varchar, DecryptByKey(var24)),CONVERT(varchar, DecryptByKey(var25)),CONVERT(varchar, DecryptByKey(var26)),CONVERT(varchar, DecryptByKey(var27)),CONVERT(varchar, DecryptByKey(var28)),CONVERT(varchar, DecryptByKey(var29)),CONVERT(varchar, DecryptByKey(var30)),CONVERT(varchar, DecryptByKey(var31)),CONVERT(varchar, DecryptByKey(var32))," _
        & " CONVERT(varchar, DecryptByKey(var33)),CONVERT(varchar, DecryptByKey(var34)),CONVERT(varchar, DecryptByKey(var35)),CONVERT(varchar, DecryptByKey(var36)),CONVERT(varchar, DecryptByKey(var37)),CONVERT(varchar, DecryptByKey(var38)),CONVERT(varchar, DecryptByKey(var39)),CONVERT(varchar, DecryptByKey(var40)),CONVERT(varchar, DecryptByKey(var41))," _
        & " CONVERT(varchar, DecryptByKey(var42)),CONVERT(varchar, DecryptByKey(var43)),CONVERT(varchar, DecryptByKey(var44)),CONVERT(varchar, DecryptByKey(var45)),CONVERT(varchar, DecryptByKey(var46)),CONVERT(varchar, DecryptByKey(var47)),CONVERT(varchar, DecryptByKey(var48)),CONVERT(varchar, DecryptByKey(var49)),CONVERT(varchar, DecryptByKey(var50))," _
        & " CONVERT(varchar, DecryptByKey(var51)),CONVERT(varchar, DecryptByKey(var52)),CONVERT(varchar, DecryptByKey(var53)),CONVERT(varchar, DecryptByKey(var54)),CONVERT(varchar, DecryptByKey(var55)),CONVERT(varchar, DecryptByKey(var56)),CONVERT(varchar, DecryptByKey(var57)),CONVERT(varchar, DecryptByKey(var58)),CONVERT(varchar, DecryptByKey(var59))," _
        & " CONVERT(varchar, DecryptByKey(var60)),CONVERT(varchar, DecryptByKey(var61)),CONVERT(varchar, DecryptByKey(var62))," _
        & " CONVERT(varchar, DecryptByKey(time)) as 'timee',replace(convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(date)), 5)," & displayformatecode & "),' ','/') as 'datee',processid from processinfo where replace(convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(date)), 5)," & displayformatecode & "),' ','/') like '" & tempdate & "' and CONVERT(varchar(" & timelength & "), DecryptByKey(time)) like '" & temptime & "'"

    
        Else
            s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select   CONVERT(varchar, DecryptByKey(recipename)) as recipe ,CONVERT(varchar, DecryptByKey(var2)) as 'batch',CONVERT(varchar, DecryptByKey(var3)) as 'lot',CONVERT(varchar, DecryptByKey(var4)) as 'batchsizee',CONVERT(varchar, DecryptByKey(var1)) as 'username',CONVERT(varchar, DecryptByKey(var6)),CONVERT(varchar, DecryptByKey(var7)),CONVERT(varchar, DecryptByKey(var8)),CONVERT(varchar, DecryptByKey(var9)),CONVERT(varchar, DecryptByKey(var10)),CONVERT(varchar, DecryptByKey(var11)),CONVERT(varchar, DecryptByKey(var12)),CONVERT(varchar, DecryptByKey(var13)),CONVERT(varchar, DecryptByKey(var14))," _
          & " CONVERT(varchar, DecryptByKey(var15)),CONVERT(varchar, DecryptByKey(var16)),CONVERT(varchar, DecryptByKey(var17)),CONVERT(varchar, DecryptByKey(var18)),CONVERT(varchar, DecryptByKey(var19)),CONVERT(varchar, DecryptByKey(var20)),CONVERT(varchar, DecryptByKey(var21)),CONVERT(varchar, DecryptByKey(var22)),CONVERT(varchar, DecryptByKey(var23))," _
          & " CONVERT(varchar, DecryptByKey(var24)),CONVERT(varchar, DecryptByKey(var25)),CONVERT(varchar, DecryptByKey(var26)),CONVERT(varchar, DecryptByKey(var27)),CONVERT(varchar, DecryptByKey(var28)),CONVERT(varchar, DecryptByKey(var29)),CONVERT(varchar, DecryptByKey(var30)),CONVERT(varchar, DecryptByKey(var31)),CONVERT(varchar, DecryptByKey(var32))," _
          & " CONVERT(varchar, DecryptByKey(var33)),CONVERT(varchar, DecryptByKey(var34)),CONVERT(varchar, DecryptByKey(var35)),CONVERT(varchar, DecryptByKey(var36)),CONVERT(varchar, DecryptByKey(var37)),CONVERT(varchar, DecryptByKey(var38)),CONVERT(varchar, DecryptByKey(var39)),CONVERT(varchar, DecryptByKey(var40)),CONVERT(varchar, DecryptByKey(var41))," _
          & " CONVERT(varchar, DecryptByKey(var42)),CONVERT(varchar, DecryptByKey(var43)),CONVERT(varchar, DecryptByKey(var44)),CONVERT(varchar, DecryptByKey(var45)),CONVERT(varchar, DecryptByKey(var46)),CONVERT(varchar, DecryptByKey(var47)),CONVERT(varchar, DecryptByKey(var48)),CONVERT(varchar, DecryptByKey(var49)),CONVERT(varchar, DecryptByKey(var50))," _
          & " CONVERT(varchar, DecryptByKey(var51)),CONVERT(varchar, DecryptByKey(var52)),CONVERT(varchar, DecryptByKey(var53)),CONVERT(varchar, DecryptByKey(var54)),CONVERT(varchar, DecryptByKey(var55)),CONVERT(varchar, DecryptByKey(var56)),CONVERT(varchar, DecryptByKey(var57)),CONVERT(varchar, DecryptByKey(var58)),CONVERT(varchar, DecryptByKey(var59))," _
          & " CONVERT(varchar, DecryptByKey(var60)),CONVERT(varchar, DecryptByKey(var61)),CONVERT(varchar, DecryptByKey(var62))," _
          & " CONVERT(varchar, DecryptByKey(time)) as 'timee',convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(date)), 5)," & displayformatecode & ") as 'datee',processid from processinfo where convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(date)), 5)," & displayformatecode & ") like '" & tempdate & "' and CONVERT(varchar(" & timelength & "), DecryptByKey(time)) like '" & temptime & "'"

        End If

        Dim cmd = New SqlCommand(s, sql.cn1)
        cmd.CommandTimeout = 60

        Dim sqlreader As SqlDataReader = cmd.ExecuteReader
        If sqlreader.Read Then
            Label4.Text = sqlreader.Item("recipe")
            Label5.Text = sqlreader.Item("batch")
            Label6.Text = sqlreader.Item("lot")
            Label9.Text = sqlreader.Item("username")
            Label8.Text = tempoperatorname
            Label7.Text = sqlreader.Item("batchsizee")
            ' Label17.Text = sqlreader.Item(59)
            processid = sqlreader.Item("processid")

            inlet_set.Text = sqlreader.Item(5)
            inlet_min.Text = sqlreader.Item(6)
            inlet_max.Text = sqlreader.Item(7)
            inlet_loal.Text = sqlreader.Item(8)
            inlet_hial.Text = sqlreader.Item(9)

            bed_set.Text = sqlreader.Item(10)
            bed_min.Text = sqlreader.Item(11)
            bed_max.Text = sqlreader.Item(12)
            bed_loal.Text = sqlreader.Item(13)
            bed_hial.Text = sqlreader.Item(14)

            exh_set.Text = sqlreader.Item(15)
            exh_min.Text = sqlreader.Item(16)
            exh_max.Text = sqlreader.Item(17)
            exh_loal.Text = sqlreader.Item(18)
            exh_hial.Text = sqlreader.Item(19)

            rh_set.Text = sqlreader.Item(20)
            rh_min.Text = sqlreader.Item(21)
            rh_max.Text = sqlreader.Item(22)
            rh_loal.Text = sqlreader.Item(23)
            rh_hial.Text = sqlreader.Item(24)

            cfm_set.Text = sqlreader.Item(25)
            cfm_min.Text = sqlreader.Item(26)
            cfm_max.Text = sqlreader.Item(27)
            cfm_loal.Text = sqlreader.Item(28)
            cfm_hial.Text = sqlreader.Item(29)

            atm_set.Text = sqlreader.Item(30)
            atm_min.Text = sqlreader.Item(31)
            atm_max.Text = sqlreader.Item(32)
            atm_loal.Text = sqlreader.Item(33)
            atm_hial.Text = sqlreader.Item(34)

            pan_set.Text = sqlreader.Item(35)
            pan_min.Text = sqlreader.Item(36)
            pan_max.Text = sqlreader.Item(37)
            pan_loal.Text = sqlreader.Item(38)
            pan_hial.Text = sqlreader.Item(39)

            exh_rpm_set.Text = sqlreader.Item(40)
            exh_rpm_min.Text = sqlreader.Item(41)
            exh_rpm_max.Text = sqlreader.Item(42)
            exh_rpm_loal.Text = sqlreader.Item(43)
            exh_rpm_hial.Text = sqlreader.Item(44)

            dos_rpm_set.Text = sqlreader.Item(45)
            dos_rpm_min.Text = sqlreader.Item(46)
            dos_rpm_max.Text = sqlreader.Item(47)
            dos_rpm_loal.Text = sqlreader.Item(48)
            dos_rpm_hial.Text = sqlreader.Item(49)

            prejog_ontime.Text = sqlreader.Item(50)
            prejog_offtime.Text = sqlreader.Item(51)
            prejog_cycle.Text = sqlreader.Item(52)

            spray_ontime.Text = sqlreader.Item(53)
            spray_offtime.Text = sqlreader.Item(54)
            spray_cycle.Text = sqlreader.Item(55)

            postjog_ontime.Text = sqlreader.Item(56)
            postjog_offtime.Text = sqlreader.Item(57)
            postjog_cycle.Text = sqlreader.Item(58)

            Label27.Text = sqlreader.Item(59)
            Label28.Text = sqlreader.Item(60)
            Label29.Text = sqlreader.Item(61)


            '   Label19.Text = sqlreader.Item("printinterval")
        End If
        cmd.Dispose()
        sql.cn1.Close()

    End Sub
    Sub selectsipdata()

        'eventname me report ka type like report name 
        'var10 me processid jaegi
        'var1 temprature in deg
        'var2 pressure in bar

        'var3 status

        Dim s As String = ""
        sql.conn1()
        Dim da As SqlDataAdapter
        Dim ds As New DataSet
        Dim tempprocessid = processid
        's = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select   (select CONVERT(varchar, DecryptByKey(fname)) as Name from employeeinfo where empid=e.empid) as Name, CONVERT (varchar, DecryptByKey(date)) as Date,CONVERT(varchar, DecryptByKey(time)) as Time,CONVERT(varchar, DecryptByKey(var1)) as 'Temprature In Deg',CONVERT(varchar, DecryptByKey(var2)) as 'PRESSURE IN BAR',CONVERT(varchar, DecryptByKey(var3)) as 'STATUS' from Eventlist as e where CONVERT(varchar, DecryptByKey(eventname))='SipReport' and CONVERT(varchar, DecryptByKey(var10))='" & tempprocessid & "' " & _
        '                   "order by  convert(date,CONVERT(varchar, DecryptByKey(date)),103) ,       convert(time, Convert(varchar, DecryptByKey(time)))"
        's = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select   CONVERT(varchar(10), DecryptByKey(DATE)) +'  '+CONVERT(varchar(" & timelength & "), DecryptByKey(time)) as 'DATE & TIME',CONVERT(varchar, DecryptByKey(var1)) as 'ACTUALTIME',CONVERT(varchar, DecryptByKey(var2)) as 'RPM',CONVERT(varchar, DecryptByKey(var3)) as 'PROCESS DESCRIPTION' from processdata as e where processid='" & tempprocessid & "' " & _
        ' "order by  sno"
      
        If displayformatecode = 106 Then
            s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select   replace(convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(date)), 5)," & displayformatecode & "),' ','/') +'  '+CONVERT(varchar(" & timelength & "), DecryptByKey(time)) as 'DATE & TIME',CONVERT(varchar, DecryptByKey(var1)) as 'Inlet Temp',CONVERT(varchar, DecryptByKey(var2)) as 'Bed Temp',CONVERT(varchar, DecryptByKey(var3)) as 'Exh Temp',CONVERT(varchar, DecryptByKey(var4)) as 'Inlet Rh',CONVERT(varchar, DecryptByKey(var5)) as 'Air Flow',CONVERT(varchar, DecryptByKey(var6)) as 'Atm Air',CONVERT(varchar, DecryptByKey(var7)) as 'Pan(RPM)',CONVERT(varchar, DecryptByKey(var8)) as 'Exh Blower(RPM)',CONVERT(varchar, DecryptByKey(var9)) as 'Dosing Pump(RPM)',CONVERT(varchar, DecryptByKey(var10)) as 'PROCESS DESCRIPTION' from processdata as e where processid='" & tempprocessid & "' " & _
                                   "order by  sno"

        Else
         s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select   convert(varchar,convert(date,CONVERT(varchar, DecryptByKey(date)), 5)," & displayformatecode & ") +'  '+CONVERT(varchar(" & timelength & "), DecryptByKey(time)) as 'DATE & TIME',CONVERT(varchar, DecryptByKey(var1)) as 'Inlet Temp',CONVERT(varchar, DecryptByKey(var2)) as 'Bed Temp',CONVERT(varchar, DecryptByKey(var3)) as 'Exh Temp',CONVERT(varchar, DecryptByKey(var4)) as 'Inlet Rh',CONVERT(varchar, DecryptByKey(var5)) as 'Air Flow',CONVERT(varchar, DecryptByKey(var6)) as 'Atm Air',CONVERT(varchar, DecryptByKey(var7)) as 'Pan(RPM)',CONVERT(varchar, DecryptByKey(var8)) as 'Exh Blower(RPM)',CONVERT(varchar, DecryptByKey(var9)) as 'Dosing Pump(RPM)',CONVERT(varchar, DecryptByKey(var10)) as 'PROCESS DESCRIPTION' from processdata as e where processid='" & tempprocessid & "' " & _
                                    "order by  sno"
        End If

        Dim cmd = New SqlCommand(s, sql.cn1)
        cmd.CommandTimeout = 60
        da = New SqlDataAdapter(cmd)
        da.Fill(ds)
        DataGrid.DataSource = ds.Tables(0)
        DataGrid.Columns(0).Width = 120
        If DataGrid.RowCount > 0 Then
            DataGrid.Columns(DataGrid.Columns.Count - 1).Width = "250"
        End If
        sql.cn1.Close()
        alternatecolours(DataGrid)
        'and (CONVERT(varchar, DecryptByKey(var10)) like '" & Label5.Text & "' and CONVERT(varchar, DecryptByKey(var9)) like '" & Label6.Text & "')
        's = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select (select CONVERT(varchar, DecryptByKey(fname)) from employeeinfo where empid=e.empid) as Name,CONVERT(varchar(max), DecryptByKey(eventname)) as 'Alarm Name' ,CONVERT(varchar(10), DecryptByKey(date)) as 'Alarm Date',CONVERT(varchar(5), DecryptByKey(time)) as  'Alarm Time',CONVERT(varchar, DecryptByKey(var1)) as 'Acknowledge Date',CONVERT(varchar(5), DecryptByKey (var2)) as 'Acknowledge Time',CONVERT(varchar, DecryptByKey(var3)) as 'Resolved Date',CONVERT(varchar(5), DecryptByKey(var4)) as 'Resolved Time' from eventlist as e where CONVERT(varchar, DecryptByKey(action)) like 'Alarm' and (CONVERT(varchar, DecryptByKey(var10)) like '" & Label5.Text & "' and CONVERT(varchar, DecryptByKey(var9)) like '" & Label6.Text & "')  order by convert(date,CONVERT(varchar, DecryptByKey(date)),3) desc,convert(time,CONVERT(varchar, DecryptByKey(time))) desc"
        'cmd = New SqlCommand(s, sql.cn1)
        'cmd.CommandTimeout = 60
        'Dim da1 As SqlDataAdapter
        'Dim ds1 As New DataSet
        'da1 = New SqlDataAdapter(cmd)
        'da1.Fill(ds1)
        'dgv1.DataSource = ds1.Tables(0)
        'Dim t = dgv1.RowCount
        If includealarmreport_print = True Then
            '  dgvalarm.DataSource = Nothing
            '   tempalarmreport = New AlarmControl
            tempalarmreport.Acknowledge = False
            Dim tempdgv = tempalarmreport.alarmselect(dgvalarm, Label5.Text, Label6.Text, 1) ' this return a datagridview from alarm control component and them binding in temprary varible for printing
            dgvalarm.DataSource = tempdgv.DataSource
        End If
        If includeauditreport_print = True Then
            '  audit = New AuditTrail
            dgvaudittrail = audit.displayeventfilterbatch("AuditTrail", DataGridView1, Label5.Text, Label6.Text, 1)
        End If
        'datagrid.Columns(3).Width = 163
    End Sub
    Public Sub alternatecolours(ByVal dgv As DataGridView)
        For i = 0 To dgv.Rows.Count - 1 Step 2
            dgv.Rows(i).DefaultCellStyle.BackColor = Color.LightCyan
            If i + 1 <= dgv.Rows.Count - 1 Then
                dgv.Rows(i + 1).DefaultCellStyle.BackColor = Color.MintCream
            End If
        Next

    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs)

        ' Label12.Text = DateTime.Now.ToString("HH:mm:ss")
        '    Label12.Text = variableclass.d(195).ToString & ":" & variableclass.d(196).ToString & ":" & variableclass.d(197).ToString
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs)
        If DataGrid.Rows.Count = 0 Then
            MsgBox("No Data")
            Exit Sub
        End If
        If PrintDialog1.ShowDialog = DialogResult.OK Then
            'Dim ev As New eventlists
            'ev.insertscadaevent(Login_Register.empid, "Print SipReport", "", "", "", "", "", "", "", "", "", "", "Audittrail")

            PrintDocument1.Print()
        End If
    End Sub
    Sub printdoc()
        If DataGrid.Rows.Count = 0 Then
            MsgBox("No Data")
            Exit Sub
        End If
        tempalarm = 0
        tempaudit = 0
        If PrintDialog1.ShowDialog = DialogResult.OK Then
            'Dim ev As New eventlists
            'ev.insertscadaevent(Login_Register.empid, "Print SipReport", "", "", "", "", "", "", "", "", "", "", "Audittrail")

            PrintDocument1.Print()
        End If
    End Sub
    Sub printpreview()
        If DataGrid.Rows.Count = 0 Then
            MsgBox("No Data")
            Exit Sub
        End If
        tempalarm = 0
        tempaudit = 0
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

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs)
        If DataGrid.Rows.Count = 0 Then
            MsgBox("No Data")
            Exit Sub
        End If
        Dim ppd As New PrintPreviewDialog
        ppd.Document = PrintDocument1
        ppd.WindowState = FormWindowState.Maximized
        ppd.ShowDialog()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs)
        With PageSetupDialog1
            .Document = PrintDocument1
            .PageSettings = PrintDocument1.DefaultPageSettings
        End With
        If PageSetupDialog1.ShowDialog = DialogResult.OK Then
            PrintDocument1.DefaultPageSettings = PageSetupDialog1.PageSettings
        End If
    End Sub

    Private Sub PrintDocument1_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint
        ''this removes the printed page margins
        PrintDocument1.OriginAtMargins = True
        PrintDocument1.DefaultPageSettings.Margins = New Drawing.Printing.Margins(0, 0, 0, 0)
        Dim dv As DataGridView = DataGrid
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


        rowCounter = 1
        '--------------------------------------------------------alarm report-----------------------------
        If includealarmreport_print = True Then
            Dim dvalarm As DataGridView = dgvalarm
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
            Dim tempalarm = 0
            'If i = 1 Then
            'End If
            rowCounter = 0
            pagesalarm = New Dictionary(Of Integer, pageDetailsalarm)
            Dim maxWidthalarm = 0
            Dim maxHeightalarm = 0

            If PrintDocument1.DefaultPageSettings.Landscape = True Then
                maxWidth = CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Height) - 40
                maxHeight = CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Width) - 250
            Else


                maxWidth = CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Width) - 40
                maxHeight = CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Height) - 250
            End If
            '  Dim pageCounteralarm As Integer = 0
            pageCounter = 0
            pagesalarm.Add(pageCounter, New pageDetailsalarm)

            columnCounter = 0

            '-- Dim columnSum As Integer = dv.RowHeadersWidth
            columnSum = dvalarm.RowHeadersWidth

            Dim tempRowHeadersWidth = 0
            If dgvalarm.RowHeadersVisible = True Then
                tempRowHeadersWidth = dvalarm.RowHeadersWidth
                columnSum = dvalarm.RowHeadersWidth

            Else
                tempRowHeadersWidth = 0
                columnSum = 0
            End If
            'columnSum = 0
            For c As Integer = 0 To dvalarm.Columns.Count - 1

                If columnSum + dvalarm.Columns(c).Width < maxWidth Then
                    columnSum += dvalarm.Columns(c).Width
                    columnCounter += 1
                Else
                    pagesalarm(pageCounter) = New pageDetailsalarm With {.columns = columnCounter, .rows = 0, .startCol = pagesalarm(pageCounter).startCol}
                    '--columnSum = dv.RowHeadersWidth + dv.Columns(c).Width
                    columnSum = tempRowHeadersWidth + dvalarm.Columns(c).Width
                    columnCounter = 1
                    pageCounter += 1
                    pagesalarm.Add(pageCounter, New pageDetailsalarm With {.startCol = c})
                End If
                If c = dvalarm.Columns.Count - 1 Then
                    If pagesalarm(pageCounter).columns = 0 Then
                        pagesalarm(pageCounter) = New pageDetailsalarm With {.columns = columnCounter, .rows = 0, .startCol = pagesalarm(pageCounter).startCol}
                    End If
                End If
            Next

            maxPagesWide = pagesalarm.Keys.Max + 1

            pageCounter = 0
            ' maxPagesWide = pages.Keys.Max + 1


            rowSum = dvalarm.ColumnHeadersHeight

            For r As Integer = 0 To dvalarm.Rows.Count - 2
                If rowSum + dvalarm.Rows(r).Height < maxHeight Then
                    rowSum += dvalarm.Rows(r).Height
                    rowCounter += 1
                Else
                    pagesalarm(pageCounter) = New pageDetailsalarm With {.columns = pagesalarm(pageCounter).columns, .rows = rowCounter, .startCol = pagesalarm(pageCounter).startCol, .startRow = pagesalarm(pageCounter).startRow}
                    For x As Integer = 1 To maxPagesWide - 1
                        pagesalarm(pageCounter + x) = New pageDetailsalarm With {.columns = pagesalarm(pageCounter + x).columns, .rows = rowCounter, .startCol = pagesalarm(pageCounter + x).startCol, .startRow = pagesalarm(pageCounter).startRow}
                    Next

                    pageCounter += maxPagesWide
                    For x As Integer = 0 To maxPagesWide - 1
                        pagesalarm.Add(pageCounter + x, New pageDetailsalarm With {.columns = pagesalarm(x).columns, .rows = 0, .startCol = pagesalarm(x).startCol, .startRow = r})
                    Next

                    rowSum = dvalarm.ColumnHeadersHeight + dvalarm.Rows(r).Height
                    rowCounter = 1
                End If
                If r = dvalarm.Rows.Count - 2 Then
                    For x As Integer = 0 To maxPagesWide - 1
                        If pagesalarm(pageCounter + x).rows = 0 Then
                            pagesalarm(pageCounter + x) = New pageDetailsalarm With {.columns = pagesalarm(pageCounter + x).columns, .rows = rowCounter, .startCol = pagesalarm(pageCounter + x).startCol, .startRow = pagesalarm(pageCounter + x).startRow}
                        End If
                    Next
                End If
            Next

            maxPagesTall = maxPagesTall + (pages.Count \ maxPagesWide)
        End If

        '-------------------------------------------audit report-------------------------------------------------------

        rowCounter = 0
        If includeauditreport_print = True Then
            pagesaudittrail = New Dictionary(Of Integer, pageDetailsaudittrail)
            If PrintDocument1.DefaultPageSettings.Landscape = True Then
                maxWidth = CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Height) - 40
                maxHeight = CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Width) - 250
            Else


                maxWidth = CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Width) - 40
                maxHeight = CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Height) - 250
            End If
            pageCounter = 0
            pagesaudittrail.Add(pageCounter, New pageDetailsaudittrail)

            columnCounter = 0

            columnSum = dgvaudittrail.RowHeadersWidth
            Dim tempRowHeadersWidth = 0
            If dgvaudittrail.RowHeadersVisible = True Then
                tempRowHeadersWidth = dgvaudittrail.RowHeadersWidth
                columnSum = dgvaudittrail.RowHeadersWidth
            Else
                tempRowHeadersWidth = 0
                columnSum = 0
            End If
            For c As Integer = 0 To dgvaudittrail.Columns.Count - 1
                If columnSum + dgvaudittrail.Columns(c).Width < maxWidth Then
                    columnSum += dgvaudittrail.Columns(c).Width
                    columnCounter += 1
                Else
                    pagesaudittrail(pageCounter) = New pageDetailsaudittrail With {.columns = columnCounter, .rows = 0, .startCol = pagesaudittrail(pageCounter).startCol}
                    columnSum = tempRowHeadersWidth + dgvaudittrail.Columns(c).Width
                    columnCounter = 1
                    pageCounter += 1
                    pagesaudittrail.Add(pageCounter, New pageDetailsaudittrail With {.startCol = c})
                End If
                If c = dgvaudittrail.Columns.Count - 1 Then
                    If pagesaudittrail(pageCounter).columns = 0 Then
                        pagesaudittrail(pageCounter) = New pageDetailsaudittrail With {.columns = columnCounter, .rows = 0, .startCol = pagesaudittrail(pageCounter).startCol}
                    End If
                End If
            Next

            maxPagesWide = pagesaudittrail.Keys.Max + 1

            pageCounter = 0



            rowSum = dgvaudittrail.ColumnHeadersHeight

            For r As Integer = 0 To dgvaudittrail.Rows.Count - 2
                If rowSum + dgvaudittrail.Rows(r).Height < maxHeight Then
                    rowSum += dgvaudittrail.Rows(r).Height
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

                    rowSum = dgvaudittrail.ColumnHeadersHeight + dgvaudittrail.Rows(r).Height
                    rowCounter = 1
                End If
                If r = dgvaudittrail.Rows.Count - 2 Then
                    For x As Integer = 0 To maxPagesWide - 1
                        If pagesaudittrail(pageCounter + x).rows = 0 Then
                            pagesaudittrail(pageCounter + x) = New pageDetailsaudittrail With {.columns = pagesaudittrail(pageCounter + x).columns, .rows = rowCounter, .startCol = pagesaudittrail(pageCounter + x).startCol, .startRow = pagesaudittrail(pageCounter + x).startRow}
                        End If
                    Next
                End If
            Next

            maxPagesTall = pagesaudittrail.Count \ maxPagesWide




        End If

        If temp = 1 Then
            ' dv.Columns(0).Visible = True
        End If
    End Sub
    Dim tempalarm = 0
    Dim tempaudit = 0
    Dim startPage As Integer = 0

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim i = 2
        '-------------------------------------------------batch report--------------------------------------------------------------------
        Dim productname, productcode, lotno As String
        Dim dv As DataGridView = DataGrid
        Dim rect1 As New Rectangle(0, 55, CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Width), 80)
        Dim temp = 0
        If i = 1 Then
            ' temp = 1
        End If
        Dim sf As New StringFormat
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center

        ' e.Graphics.DrawImage(My.Resources.lupinvsmal, New Point(20, 20))
        ' Dim drawFont As New Font("Arial", 10, FontStyle.Regular)
        'Dim drawFontbold As New Font("Arial", 10, FontStyle.Bold)
        Dim drawFont As Font
        drawFont = f
        Dim drawFontbold As New Font(f.FontFamily, f.Size, FontStyle.Bold)
        sf.Alignment = StringAlignment.Near

        Dim startX As Integer = 100
        Dim startY As Integer = 200
        Dim tempy = 0

        '        Try




        Dim newpage = 0
        If tempalarm = 0 Then
            'For p As Integer = startPage To pages.Count - 1
            '    e.Graphics.DrawString("LUPIN LIMITED PITHAMPUR UNIT -2", drawFont, Brushes.Black, New Point((e.PageBounds.Width / 2) - 140, 20))
            '    e.Graphics.DrawString("BATCH REPORT BB - 302", drawFont, Brushes.Black, New Point((e.PageBounds.Width / 2) - 100, 40))
            '    e.Graphics.DrawString("PRODUCT NAME		", drawFont, Brushes.Black, 80, 60)
            '    e.Graphics.DrawString(Label4.Text, drawFont, Brushes.Black, 250, 60)
            '    e.Graphics.DrawString("BATCH NUMBER	    ", drawFont, Brushes.Black, 80, 80)
            '    e.Graphics.DrawString(Label5.Text, drawFont, Brushes.Black, 250, 80)
            '    e.Graphics.DrawString("LOT NUMBER	    ", drawFont, Brushes.Black, 80, 100)
            '    e.Graphics.DrawString(Label6.Text, drawFont, Brushes.Black, 250, 100)
            '    e.Graphics.DrawString("OFFICER NAME		", drawFont, Brushes.Black, 480, 60)
            '    e.Graphics.DrawString(Label9.Text, drawFont, Brushes.Black, 630, 60)
            '    e.Graphics.DrawString("OPERATOR NAME	    ", drawFont, Brushes.Black, 480, 80)
            '    e.Graphics.DrawString("BATCH SIZE(KG'S)	    ", drawFont, Brushes.Black, 480, 100)
            '    e.Graphics.DrawString(Label8.Text, drawFont, Brushes.Black, 630, 80)
            '    e.Graphics.DrawString(Label7.Text, drawFont, Brushes.Black, 630, 100)
            '    '  e.Graphics.DrawString("Time:" & Label12.Text, drawFont, Brushes.Black, e.PageBounds.Width - 200, 100)
            '    e.Graphics.DrawLine(Pens.Black, 80, 120, e.PageBounds.Width - 100, 120)
            '    'blender time header
            '    e.Graphics.DrawString(lbl_bl1.Text, drawFont, Brushes.Black, 80, 140)
            '    e.Graphics.DrawString(lbl_bl2.Text, drawFont, Brushes.Black, 80, 160)
            '    e.Graphics.DrawString(lbl_bl3.Text, drawFont, Brushes.Black, 80, 180)

            '    e.Graphics.DrawString(lbl_bl4.Text, drawFont, Brushes.Black, 480, 140)
            '    e.Graphics.DrawString(lbl_bl5.Text, drawFont, Brushes.Black, 480, 160)
            '    e.Graphics.DrawString(lbl_bl6.Text, drawFont, Brushes.Black, 480, 180)
            '    'blender time value

            '    e.Graphics.DrawString(Label15.Text, drawFont, Brushes.Black, 250, 140)
            '    e.Graphics.DrawString(Label14.Text, drawFont, Brushes.Black, 250, 160)
            '    e.Graphics.DrawString(Label13.Text, drawFont, Brushes.Black, 250, 180)
            '    e.Graphics.DrawString(Label25.Text, drawFont, Brushes.Black, 650, 140)
            '    e.Graphics.DrawString(Label24.Text, drawFont, Brushes.Black, 650, 160)
            '    e.Graphics.DrawString(Label23.Text, drawFont, Brushes.Black, 650, 180)
            '    e.Graphics.DrawString("BLENDING RPM", drawFont, Brushes.Black, 80, 200)
            '    e.Graphics.DrawString("PRINT INTERNAL (MIN)", drawFont, Brushes.Black, 480, 200)
            '    e.Graphics.DrawString(Label20.Text, drawFont, Brushes.Black, 250, 200)
            '    e.Graphics.DrawString(Label19.Text, drawFont, Brushes.Black, 650, 200)
            '    e.Graphics.DrawLine(Pens.Black, 80, 220, e.PageBounds.Width - 100, 220)
            '    If p <> 0 Then
            '        newpage = 1
            '    End If
            '    '  If p = pages.Count - 1 Then
            '    e.Graphics.DrawString("Remark:", drawFont, Brushes.Black, 80, e.PageBounds.Height - 80)
            '    'e.Graphics.DrawString("STERILIZATION HOLD TIME  " & Label19.Text, drawFont, Brushes.Black, 400, e.PageBounds.Height - 80)
            '    e.Graphics.DrawString("DONE BY (SIGN/DATE)	:", drawFont, Brushes.Black, 80, e.PageBounds.Height - 60)

            '    e.Graphics.DrawString("CHECKED BY (SIGN/DATE)	:", drawFont, Brushes.Black, 400, e.PageBounds.Height - 60)

            '    'End If
            '    If p = 0 Then
            '        startY = 260
            '        tempy = 220

            '    Else
            '        startY = 150
            '        tempy = 150
            '    End If
            '    e.Graphics.DrawString("Page Number " & p + 1 & " of " & pages.Count, drawFont, Brushes.Black, e.PageBounds.Width - 180, e.PageBounds.Height - 32)
            '    Dim cell As New Rectangle(startX, startY, dv.RowHeadersWidth, dv.ColumnHeadersHeight)
            '    '-- below code if for row header comment code from 1 to 2 if header is not required in printing

            '    '--1
            '    'e.Graphics.FillRectangle(New SolidBrush(SystemColors.ControlLight), cell)
            '    'e.Graphics.DrawRectangle(Pens.Black, cell)

            '    'startY += dv.ColumnHeadersHeight

            '    'For r As Integer = pages(p).startRow To pages(p).startRow + pages(p).rows
            '    '    cell = New Rectangle(startX, startY, dv.RowHeadersWidth, dv.Rows(r).Height)
            '    '    e.Graphics.FillRectangle(New SolidBrush(SystemColors.ControlLight), cell)
            '    '    e.Graphics.DrawRectangle(Pens.Black, cell)
            '    '    If r <> 0 Then
            '    '        '     MsgBox(DataGridView3.Rows(r).HeaderCell.Value.ToString)
            '    '        '    e.Graphics.DrawString(dv.Rows(r).HeaderCell.Value.ToString, TextBox10.Font, Brushes.Black, cell, sf)
            '    '    End If
            '    '    startY += dv.Rows(r).Height
            '    'Next

            '    'startX += cell.Width
            '    '--2
            '    If p = 0 Then
            '        startY = 240
            '    Else
            '        startY = 240
            '    End If


            '    For c As Integer = pages(p).startCol To pages(p).startCol + pages(p).columns - 1
            '        If (temp = 1 And c = 0) Or (temp = 1 And c = dv.Columns.Count - 1) Then

            '        Else
            '            ' End If
            '            cell = New Rectangle(startX, startY, dv.Columns(c).Width, dv.ColumnHeadersHeight)
            '            e.Graphics.FillRectangle(New SolidBrush(SystemColors.ControlLight), cell)
            '            e.Graphics.DrawRectangle(Pens.Black, cell)
            '            e.Graphics.DrawString(dv.Columns(c).HeaderCell.Value.ToString, drawFont, Brushes.Black, cell, sf)
            '            startX += dv.Columns(c).Width
            '        End If
            '    Next
            '    If p = 0 Then
            '        startY = 240 + dv.ColumnHeadersHeight
            '    Else
            '        startY = 240 + dv.ColumnHeadersHeight
            '    End If



            '    For r As Integer = pages(p).startRow + newpage To pages(p).startRow + pages(p).rows
            '        '--  startX = 50 + dv.RowHeadersWidth this is used when row header is  included
            '        startX = 100 ' this is used when row header is not included

            '        For c As Integer = pages(p).startCol To pages(p).startCol + pages(p).columns - 1
            '            cell = New Rectangle(startX, startY, dv.Columns(c).Width, dv.Rows(r).Height)
            '            If (c = 0 And temp = 1) Or (temp = 1 And c = dv.Columns.Count - 1) Then
            '                startX += 0
            '            Else
            '                e.Graphics.DrawRectangle(Pens.Black, cell)
            '                '  MsgBox(dv(c, r).Value.ToString)
            '                e.Graphics.DrawString(dv(c, r).Value.ToString, drawFont, Brushes.Black, cell, sf)
            '                startX += dv.Columns(c).Width
            '            End If
            '            '  e.Graphics.DrawString(dv.Rows(r).Cells(0).Value.ToString, TextBox10.Font, Brushes.Black, cell, sf)
            '            '  startX += dv.Columns(c).Width
            '            'f
            '        Next
            '        startY += dv.Rows(r).Height
            '    Next

            '    If p <> pages.Count - 1 Then
            '        startPage = p + 1
            '        e.HasMorePages = True
            '        Return
            '    Else
            '        startPage = 0
            '        tempalarm = 1

            '        e.HasMorePages = True
            '        Return
            '    End If

            'Next

            '---
            For p As Integer = startPage To pages.Count - 1
                e.Graphics.DrawString("", drawFontbold, Brushes.Black, New Point((e.PageBounds.Width / 2) - 140, 20))
                e.Graphics.DrawString("BATCH REPORT ", drawFontbold, Brushes.Black, New Point((e.PageBounds.Width / 2) - 100, 40))
                e.Graphics.DrawString("PRODUCT NAME		", drawFontbold, Brushes.Black, 80, 60)
                e.Graphics.DrawString(Label4.Text, drawFont, Brushes.Black, 250, 60)
                e.Graphics.DrawString("BATCH NUMBER	    ", drawFontbold, Brushes.Black, 80, 80)
                e.Graphics.DrawString(Label5.Text, drawFont, Brushes.Black, 250, 80)
                e.Graphics.DrawString("LOT NUMBER	    ", drawFontbold, Brushes.Black, 80, 100)
                e.Graphics.DrawString(Label6.Text, drawFont, Brushes.Black, 250, 100)
                e.Graphics.DrawString("SUPERVISOR NAME		", drawFontbold, Brushes.Black, 480, 60)
                e.Graphics.DrawString(Label9.Text, drawFont, Brushes.Black, 630, 60)
                e.Graphics.DrawString("OPERATOR NAME	    ", drawFontbold, Brushes.Black, 480, 80)
                e.Graphics.DrawString("BATCH SIZE(KG'S)	    ", drawFontbold, Brushes.Black, 480, 100)
                e.Graphics.DrawString(Label8.Text, drawFont, Brushes.Black, 630, 80)
                e.Graphics.DrawString(Label7.Text, drawFont, Brushes.Black, 630, 100)
                '  e.Graphics.DrawString("Time:" & Label12.Text, drawFont, Brushes.Black, e.PageBounds.Width - 200, 100)
                e.Graphics.DrawLine(Pens.Black, 80, 120, e.PageBounds.Width - 100, 120)
                'blender time header
                e.Graphics.DrawString(lbl_bl1.Text, drawFont, Brushes.Black, 80, 140)
                e.Graphics.DrawString(lbl_bl2.Text, drawFont, Brushes.Black, 80, 160)
                e.Graphics.DrawString(lbl_bl3.Text, drawFont, Brushes.Black, 80, 180)

                e.Graphics.DrawString(lbl_bl4.Text, drawFont, Brushes.Black, 480, 140)
                e.Graphics.DrawString(lbl_bl5.Text, drawFont, Brushes.Black, 480, 160)
                e.Graphics.DrawString(lbl_bl6.Text, drawFont, Brushes.Black, 480, 180)
                'blender time value

                e.Graphics.DrawString(Label15.Text, drawFont, Brushes.Black, 250, 140)
                e.Graphics.DrawString(Label14.Text, drawFont, Brushes.Black, 250, 160)
                e.Graphics.DrawString(Label13.Text, drawFont, Brushes.Black, 250, 180)
                e.Graphics.DrawString(Label25.Text, drawFont, Brushes.Black, 650, 140)
                e.Graphics.DrawString(Label24.Text, drawFont, Brushes.Black, 650, 160)
                e.Graphics.DrawString(Label23.Text, drawFont, Brushes.Black, 650, 180)
                e.Graphics.DrawString("BLENDING RPM", drawFont, Brushes.Black, 80, 200)
                e.Graphics.DrawString("PRINT INTERNAL (MIN)", drawFont, Brushes.Black, 480, 200)
                e.Graphics.DrawString(Label20.Text, drawFont, Brushes.Black, 250, 200)
                e.Graphics.DrawString(Label19.Text, drawFont, Brushes.Black, 650, 200)
                e.Graphics.DrawLine(Pens.Black, 80, 220, e.PageBounds.Width - 100, 220)
                If p <> 0 Then
                    newpage = 1
                End If
                '  If p = pages.Count - 1 Then
                e.Graphics.DrawString("REMARK :", drawFont, Brushes.Black, 80, e.PageBounds.Height - 80)
                'e.Graphics.DrawString("STERILIZATION HOLD TIME  " & Label19.Text, drawFont, Brushes.Black, 400, e.PageBounds.Height - 80)
                e.Graphics.DrawString("DONE BY (SIGN/DATE)	:", drawFont, Brushes.Black, 60, e.PageBounds.Height - 40)

                e.Graphics.DrawString("CHECKED BY (SIGN/DATE)	:", drawFont, Brushes.Black, 400, e.PageBounds.Height - 40)

                'End If
                If p = 0 Then
                    startY = 260
                    tempy = 220

                Else
                    startY = 150
                    tempy = 150
                End If
                e.Graphics.DrawString("PAGE NUMBER " & p + 1 & " of " & pages.Count, drawFont, Brushes.Black, e.PageBounds.Width - 500, e.PageBounds.Height - 25)
                Dim cell As New Rectangle(startX, startY, dv.RowHeadersWidth, dv.ColumnHeadersHeight)
                '-- below code if for row header comment code from 1 to 2 if header is not required in printing

                '--1
                'e.Graphics.FillRectangle(New SolidBrush(SystemColors.ControlLight), cell)
                'e.Graphics.DrawRectangle(Pens.Black, cell)

                'startY += dv.ColumnHeadersHeight

                'For r As Integer = pages(p).startRow To pages(p).startRow + pages(p).rows
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
                '--2
                If p = 0 Then
                    startY = 240
                Else
                    startY = 240
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
                If dv.RowCount = 0 Then
                    Exit Sub
                End If
                If p = 0 Then
                    startY = 240 + dv.ColumnHeadersHeight
                Else
                    startY = 240 + dv.ColumnHeadersHeight
                End If



                For r As Integer = pages(p).startRow + newpage To pages(p).startRow + pages(p).rows
                    '--  startX = 50 + dv.RowHeadersWidth this is used when row header is  included
                    startX = 100 ' this is used when row header is not included

                    For c As Integer = pages(p).startCol To pages(p).startCol + pages(p).columns - 1
                        cell = New Rectangle(startX, startY, dv.Columns(c).Width, dv.Rows(r).Height)
                        If (c = 0 And temp = 1) Or (temp = 1 And c = dv.Columns.Count - 1) Then
                            startX += 0
                        Else
                            e.Graphics.DrawRectangle(Pens.Black, cell)
                            '  MsgBox(dv(c, r).Value.ToString)
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
                    If includealarmreport_print = True Then
                        tempalarm = 1

                        e.HasMorePages = True
                        Return
                    Else
                        If includeauditreport_print = True Then
                            tempaudit = 1
                            tempalarm = 2
                            e.HasMorePages = True
                            Return
                        End If
                    End If
                End If

            Next
        End If



        '----------------------------------------------------------------------alarm report------------------------------------------------------------------------

        Dim tempx = 60
        startX = 60
        ' startPage = 0
        If tempalarm = 1 Then
            temp = 1

            For p As Integer = startPage To pagesalarm.Count - 1
                e.Graphics.DrawString("", drawFontbold, Brushes.Black, New Point((e.PageBounds.Width / 2) - 140, 20))
                e.Graphics.DrawString("ALARM REPORT", drawFontbold, Brushes.Black, New Point((e.PageBounds.Width / 2) - 100, 40))
                e.Graphics.DrawString("PRODUCT NAME		", drawFontbold, Brushes.Black, 80, 60)
                e.Graphics.DrawString(Label4.Text, drawFont, Brushes.Black, 250, 60)
                e.Graphics.DrawString("BATCH NUMBER	    ", drawFontbold, Brushes.Black, 80, 80)
                e.Graphics.DrawString(Label5.Text, drawFont, Brushes.Black, 250, 80)
                e.Graphics.DrawString("LOT NUMBER	    ", drawFontbold, Brushes.Black, 80, 100)
                e.Graphics.DrawString(Label6.Text, drawFont, Brushes.Black, 250, 100)
                e.Graphics.DrawString("SUPERVISOR NAME		", drawFontbold, Brushes.Black, 480, 60)
                e.Graphics.DrawString(Label9.Text, drawFont, Brushes.Black, 630, 60)
                e.Graphics.DrawString("OPERATOR NAME	    ", drawFontbold, Brushes.Black, 480, 80)
                e.Graphics.DrawString("BATCH SIZE(KG'S)	    ", drawFontbold, Brushes.Black, 480, 100)
                e.Graphics.DrawString(Label8.Text, drawFont, Brushes.Black, 630, 80)
                e.Graphics.DrawString(Label7.Text, drawFont, Brushes.Black, 630, 100)
                '  e.Graphics.DrawString("Time:" & Label12.Text, drawFont, Brushes.Black, e.PageBounds.Width - 200, 100)

                '  e.Graphics.DrawString("Time:" & Label12.Text, drawFont, Brushes.Black, e.PageBounds.Width - 200, 100)

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
                e.Graphics.DrawString("PAGE NUMBER " & p + 1 & " of " & pagesalarm.Count, drawFont, Brushes.Black, e.PageBounds.Width - 500, e.PageBounds.Height - 25)
                Dim cell As New Rectangle(startX, startY, dgvalarm.RowHeadersWidth, dgvalarm.ColumnHeadersHeight)
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

                If dgvalarm.RowCount = 0 Then
                    'tempalarm=2 indicates alarm report printed
                    tempalarm = 2
                    If includeauditreport_print = True Then
                        tempaudit = 1 ' this indicates start printing audit trail
                        e.HasMorePages = True
                        Return
                    Else
                        Exit Sub
                    End If
                    ' Exit Sub
                End If
                For c As Integer = pagesalarm(p).startCol To pagesalarm(p).startCol + pagesalarm(p).columns - 1
                    If (temp = 1 And c = 0) Or (temp = 1 And c = dgvalarm.Columns.Count - 1) Then

                    Else
                        ' End If
                        cell = New Rectangle(startX, startY, dgvalarm.Columns(c).Width, dgvalarm.ColumnHeadersHeight)
                        e.Graphics.FillRectangle(New SolidBrush(SystemColors.ControlLight), cell)
                        e.Graphics.DrawRectangle(Pens.Black, cell)
                        e.Graphics.DrawString(dgvalarm.Columns(c).HeaderCell.Value.ToString, drawFontbold, Brushes.Black, cell, sf)
                        startX += dgvalarm.Columns(c).Width
                    End If
                Next
                '    If p = 0 Then
                ' startY = 220 + dgv1.ColumnHeadersHeight
                ' Else
                startY = tempy + dgvalarm.ColumnHeadersHeight
                'End If
                'if dgv1 has no row then we have to print blank alarm report and continue printing audit trail after this



                For r As Integer = pagesalarm(p).startRow + newpage To pagesalarm(p).startRow + pagesalarm(p).rows
                    startX = tempx
                    For c As Integer = pagesalarm(p).startCol To pagesalarm(p).startCol + pagesalarm(p).columns - 1


                        cell = New Rectangle(startX, startY, dgvalarm.Columns(c).Width, dgvalarm.Rows(r).Height)
                        If (c = 0 And temp = 1) Or (temp = 1 And c = dgvalarm.Columns.Count - 1) Then
                            startX += 0
                        Else
                            e.Graphics.DrawRectangle(Pens.Black, cell)
                            e.Graphics.DrawString(dgvalarm(c, r).Value.ToString, drawFont, Brushes.Black, cell, sf)
                            startX += dgvalarm.Columns(c).Width
                        End If
                        '  e.Graphics.DrawString(dgv1.Rows(r).Cells(0).Value.ToString, TextBox10.Font, Brushes.Black, cell, sf)
                        '  startX += dgv1.Columns(c).Width
                        'f
                    Next
                    startY += dgvalarm.Rows(r).Height
                Next

                If p <> pagesalarm.Count - 1 Then
                    startPage = p + 1
                    e.HasMorePages = True
                    Return
                Else
                    startPage = 0
                    If includeauditreport_print = True Then
                        tempalarm = 2
                        tempaudit = 1
                        e.HasMorePages = True
                        Return
                    End If
                End If

            Next


        End If




        '-------------------------------------------------------audit trail----------------------------------------------------------------------




        startX = 60
        startY = 150
        tempy = 0

        '        Try
        newpage = 0
        If tempaudit = 1 Then
            temp = 0
            For p As Integer = startPage To pagesaudittrail.Count - 1
                e.Graphics.DrawString("", drawFontbold, Brushes.Black, New Point((e.PageBounds.Width / 2) - 140, 20))
                e.Graphics.DrawString("EVENT REPORT", drawFontbold, Brushes.Black, New Point((e.PageBounds.Width / 2) - 100, 40))
                e.Graphics.DrawString("PRODUCT NAME		", drawFontbold, Brushes.Black, 80, 60)
                e.Graphics.DrawString(Label4.Text, drawFont, Brushes.Black, 250, 60)
                e.Graphics.DrawString("BATCH NUMBER	    ", drawFontbold, Brushes.Black, 80, 80)
                e.Graphics.DrawString(Label5.Text, drawFont, Brushes.Black, 250, 80)
                e.Graphics.DrawString("LOT NUMBER	    ", drawFontbold, Brushes.Black, 80, 100)
                e.Graphics.DrawString(Label6.Text, drawFont, Brushes.Black, 250, 100)
                e.Graphics.DrawString("SUPERVISOR NAME		", drawFontbold, Brushes.Black, 480, 60)
                e.Graphics.DrawString(Label9.Text, drawFont, Brushes.Black, 630, 60)
                e.Graphics.DrawString("OPERATOR NAME	    ", drawFontbold, Brushes.Black, 480, 80)
                e.Graphics.DrawString("BATCH SIZE(KG'S)	    ", drawFontbold, Brushes.Black, 480, 100)
                e.Graphics.DrawString(Label8.Text, drawFont, Brushes.Black, 630, 80)
                e.Graphics.DrawString(Label7.Text, drawFont, Brushes.Black, 630, 100)
                '  e.Graphics.DrawString("Time:" & Label12.Text, drawFont, Brushes.Black, e.PageBounds.Width - 200, 100)

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
                Dim cell As New Rectangle(startX, startY, dgvaudittrail.RowHeadersWidth, dgvaudittrail.ColumnHeadersHeight)
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
                If dgvaudittrail.RowCount = 0 Then
                    Exit Sub
                End If

                For c As Integer = pagesaudittrail(p).startCol To pagesaudittrail(p).startCol + pagesaudittrail(p).columns - 1
                    If (temp = 1 And c = 0) Or (temp = 1 And c = dgvaudittrail.Columns.Count - 1) Then

                    Else
                        ' End If
                        cell = New Rectangle(startX, startY, dgvaudittrail.Columns(c).Width, dgvaudittrail.ColumnHeadersHeight)
                        e.Graphics.FillRectangle(New SolidBrush(SystemColors.ControlLight), cell)
                        e.Graphics.DrawRectangle(Pens.Black, cell)
                        e.Graphics.DrawString(dgvaudittrail.Columns(c).HeaderCell.Value.ToString, drawFontbold, Brushes.Black, cell, sf)
                        startX += dgvaudittrail.Columns(c).Width
                    End If
                Next

                '    If p = 0 Then
                ' startY = 220 + dv.ColumnHeadersHeight
                'Else
                startY = tempy + dgvaudittrail.ColumnHeadersHeight
                ' End If



                For r As Integer = pagesaudittrail(p).startRow + newpage To pagesaudittrail(p).startRow + pagesaudittrail(p).rows

                    startX = 19 + dgvaudittrail.RowHeadersWidth
                    For c As Integer = pagesaudittrail(p).startCol To pagesaudittrail(p).startCol + pagesaudittrail(p).columns - 1
                        cell = New Rectangle(startX, startY, dgvaudittrail.Columns(c).Width, dgvaudittrail.Rows(r).Height)
                        If (c = 0 And temp = 1) Or (temp = 1 And c = dgvaudittrail.Columns.Count - 1) Then
                            startX += 0
                        Else
                            e.Graphics.DrawRectangle(Pens.Black, cell)
                            e.Graphics.DrawString(dgvaudittrail(c, r).Value.ToString, drawFont, Brushes.Black, cell, sf)
                            startX += dgvaudittrail.Columns(c).Width
                        End If
                        '  e.Graphics.DrawString(dv.Rows(r).Cells(0).Value.ToString, TextBox10.Font, Brushes.Black, cell, sf)
                        '  startX += dv.Columns(c).Width
                        'f
                    Next
                    startY += dgvaudittrail.Rows(r).Height
                Next

                If p <> pagesaudittrail.Count - 1 Then
                    startPage = p + 1
                    e.HasMorePages = True
                    Return
                Else
                    startPage = 0
                    tempaudit = 2
                End If

            Next


        End If



        tempalarm = 0
        tempaudit = 0




    End Sub


    Private Sub processdetails_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Private Sub sipreport_Load(sender As System.Object, e As System.EventArgs) me.Load
        Me.StartPosition = FormStartPosition.CenterParent
        DataGrid.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        selectdefaultvalue()
        selectsipdata()
        '  End Sub
    End Sub
End Class