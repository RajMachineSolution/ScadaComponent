Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing
Public Class processreportdetails
    Public Structure pageDetails
        Dim columns As Integer
        Dim rows As Integer
        Dim startCol As Integer
        Dim startRow As Integer
    End Structure
    Public pages As Dictionary(Of Integer, pageDetails)
    Dim maxPagesWide As Integer
    Dim maxPagesTall As Integer
    Dim sql As New sqlclass
    Dim reporton As Boolean = True
    Dim reportshow As Boolean = False
    Dim triggered1 As Boolean = False
    Dim processid
    Dim batch_lot = 0
    Dim tempdate = ""
    Dim temptime = ""
    Dim tempoperatorname = ""
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
    Dim tempnoofcycle = 0
    Public Sub selectdefaultvalue()
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
        Dim tempprocessid = batch_lot
        s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select   CONVERT(varchar, DecryptByKey(recipename)) as recipe ,CONVERT(varchar, DecryptByKey(var2)) as 'batch',CONVERT(varchar, DecryptByKey(var3)) as 'lot',CONVERT(varchar, DecryptByKey(var4)) as 'batchsizee',CONVERT(varchar, DecryptByKey(var1)) as 'username',CONVERT(varchar, DecryptByKey(var6)) as 'b1',CONVERT(varchar, DecryptByKey(var7)) as b2 ,CONVERT(varchar, DecryptByKey(var8)) as b3,CONVERT(varchar, DecryptByKey(var9)) as 'b4',CONVERT(varchar, DecryptByKey(var10)) as b5 ,CONVERT(varchar, DecryptByKey(var11)) as b6,CONVERT(varchar, DecryptByKey(var12)) as rpm,CONVERT(varchar, DecryptByKey(var13)) as printinterval,CONVERT(varchar, DecryptByKey(var14)) as noofcycle,CONVERT(varchar, DecryptByKey(time)) as 'timee',CONVERT(varchar, DecryptByKey(date)) as 'datee',processid from processinfo  where CONVERT(varchar, DecryptByKey(date)) like '" & tempdate & "' and CONVERT(varchar(5), DecryptByKey(time)) like '" & temptime & "'"
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
            processid = sqlreader.Item("processid")
            Label20.Text = sqlreader.Item("rpm")
            tempnoofcycle = sqlreader.Item("noofcycle")
            If sqlreader.Item("noofcycle") = 1 Then
                Label15.Text = sqlreader.Item("b1")
                Label14.Text = ""
                Label13.Text = ""
                Label25.Text = ""
                Label24.Text = ""
                Label23.Text = ""
                lbl_bl2.Text = ""
                lbl_bl3.Text = ""
                lbl_bl4.Text = ""
                lbl_bl5.Text = ""
                lbl_bl6.Text = ""
            End If
            If sqlreader.Item("noofcycle") = 2 Then
                Label15.Text = sqlreader.Item("b1")
                Label14.Text = sqlreader.Item("b2")
                Label13.Text = ""
                Label25.Text = ""
                Label24.Text = ""
                Label23.Text = ""
                lbl_bl3.Text = ""
                lbl_bl4.Text = ""
                lbl_bl5.Text = ""
                lbl_bl6.Text = ""
            End If
            If sqlreader.Item("noofcycle") = 3 Then
                Label15.Text = sqlreader.Item("b1")
                Label14.Text = sqlreader.Item("b2")
                Label13.Text = sqlreader.Item("b3")

                Label25.Text = ""
                Label24.Text = ""
                Label23.Text = ""
                lbl_bl4.Text = ""
                lbl_bl5.Text = ""
                lbl_bl6.Text = ""
            End If
            If sqlreader.Item("noofcycle") = 4 Then
                Label15.Text = sqlreader.Item("b1")
                Label14.Text = sqlreader.Item("b2")
                Label13.Text = sqlreader.Item("b3")
                Label25.Text = sqlreader.Item("b4")
                Label24.Text = ""
                Label23.Text = ""

                lbl_bl5.Text = ""
                lbl_bl6.Text = ""
            End If
            If sqlreader.Item("noofcycle") = 5 Then
                Label15.Text = sqlreader.Item("b1")
                Label14.Text = sqlreader.Item("b2")
                Label13.Text = sqlreader.Item("b3")
                Label25.Text = sqlreader.Item("b4")
                Label24.Text = sqlreader.Item("b5")

                Label23.Text = ""

                lbl_bl6.Text = ""
            End If
            If sqlreader.Item("noofcycle") = 6 Then
                Label15.Text = sqlreader.Item("b1")
                Label14.Text = sqlreader.Item("b2")
                Label13.Text = sqlreader.Item("b3")
                Label25.Text = sqlreader.Item("b4")
                Label24.Text = sqlreader.Item("b5")
                Label23.Text = sqlreader.Item("b6")
            End If

            Label19.Text = sqlreader.Item("printinterval")
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
        s = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select   CONVERT(varchar(10), DecryptByKey(DATE)) +'  '+CONVERT(varchar, DecryptByKey(time)) as 'DATE & TIME',CONVERT(varchar, DecryptByKey(var1)) as 'ACTUALTIME',CONVERT(varchar, DecryptByKey(var2)) as 'RPM',CONVERT(varchar, DecryptByKey(var3)) as 'PROCESS DESCRIPTION' from processdata as e where processid='" & tempprocessid & "' " & _
                                 "order by  sno"

        Dim cmd = New SqlCommand(s, sql.cn1)
        cmd.CommandTimeout = 60
        da = New SqlDataAdapter(cmd)
        da.Fill(ds)
        DataGrid.DataSource = ds.Tables(0)
        DataGrid.Columns(0).Width = 120
        If DataGrid.RowCount > 0 Then
            DataGrid.Columns(DataGrid.Columns.Count - 1).Width = "250"
        End If
        alternatecolours(DataGrid)
        sql.cn1.Close()
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
            ' Exit Sub
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
            '   Exit Sub
        End If
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
        Dim dv As DataGridView = DataGrid
        'Dim txtbx As TextBox = CType(TabControl2.TabPages(i - 1).Controls("text" & (i)), TextBox)

        ''sample txtbox
        '   Dim txtbx As TextBox = TextBox1

        ' Dim rect As New Rectangle(20, 20, CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Width), txtbx.Height)
        Dim rect1 As New Rectangle(0, 55, CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Width), 80)
        Dim temp = 0
        If i = 1 Then
            ' temp = 1
        End If
        Dim sf As New StringFormat
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center

        ' e.Graphics.DrawImage(My.Resources.lupinvsmal, New Point(20, 20))
        'e.Graphics.DrawString("Lupin Limited, Pithampur-Unit 1", vv.Font, Brushes.Black, New Point(20, 75))
        'e.Graphics.DrawString("Production", vv.Font, Brushes.Black, New Point(710, 75))
        ''e.Graphics.DrawString(txtbx.Text, txtbx.Font, Brushes.Black, rect, sf)
        'e.Graphics.DrawString("High Shear Mixer Granulator M/c Operation Details", vv.Font, Brushes.Black, rect1, sf)
        Dim drawFont As New Font("Arial", 10, FontStyle.Regular)
        Dim drawFontBOLD As New Font("Arial", 10, FontStyle.Bold)
        e.Graphics.DrawString("", drawFontBOLD, Brushes.Black, New Point((e.PageBounds.Width / 2) - 140, 20))
        e.Graphics.DrawString("BATCH REPORT ", drawFontBOLD, Brushes.Black, New Point((e.PageBounds.Width / 2) - 100, 40))
        e.Graphics.DrawString("PRODUCT NAME		", drawFontBOLD, Brushes.Black, 80, 60)
        e.Graphics.DrawString(Label4.Text, drawFont, Brushes.Black, 250, 60)
        e.Graphics.DrawString("BATCH NUMBER	    ", drawFontBOLD, Brushes.Black, 80, 80)
        e.Graphics.DrawString(Label5.Text, drawFont, Brushes.Black, 250, 80)
        e.Graphics.DrawString("LOT NUMBER	    ", drawFontBOLD, Brushes.Black, 80, 100)
        e.Graphics.DrawString(Label6.Text, drawFont, Brushes.Black, 250, 100)
        e.Graphics.DrawString("OFFICER NAME		", drawFontBOLD, Brushes.Black, 480, 60)
        e.Graphics.DrawString(Label9.Text, drawFont, Brushes.Black, 630, 60)
        e.Graphics.DrawString("OPERATOR NAME	    ", drawFontBOLD, Brushes.Black, 480, 80)
        e.Graphics.DrawString("BATCH SIZE(KG'S)	    ", drawFontBOLD, Brushes.Black, 480, 100)
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
        ' e.Graphics.DrawString("OPERATOR NAME	    " & Label8.Text, drawFont, Brushes.Black, 480, 160)
        '    e.Graphics.DrawString("Report Title", drawFont, Brushes.Gray, 20, e.PageBounds.Height - 90)
        ' e.Graphics.DrawString("Printed", drawFont, Brushes.Gray, 20, e.PageBounds.Height - 76)
        ' e.Graphics.DrawString(Label2.Text, Label2.Font, Brushes.Black, rect1, sf)

        sf.Alignment = StringAlignment.Near

        Dim startX As Integer = 100
        Dim startY As Integer = 200
        Dim tempy = 0

        '        Try




        Dim newpage = 0

        For p As Integer = startPage To pages.Count - 1
            If p <> 0 Then
                newpage = 1
            End If
            '  If p = pages.Count - 1 Then
            e.Graphics.DrawString("REMARK :", drawFont, Brushes.Black, 80, e.PageBounds.Height - 85)
            'e.Graphics.DrawString("STERILIZATION HOLD TIME  " & Label19.Text, drawFont, Brushes.Black, 400, e.PageBounds.Height - 80)
            e.Graphics.DrawString("DONE BY (SIGN/DATE)	:", drawFont, Brushes.Black, 80, e.PageBounds.Height - 60)

            e.Graphics.DrawString("CHECKED BY (SIGN/DATE)	:", drawFont, Brushes.Black, 400, e.PageBounds.Height - 60)

            'End If
            If p = 0 Then
                startY = 260
                tempy = 220
       
            Else
                startY = 150
                tempy = 150
            End If
            e.Graphics.DrawString("Page Number " & p + 1 & " of " & pages.Count, drawFont, Brushes.Black, e.PageBounds.Width - 500, e.PageBounds.Height - 32)
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
                    e.Graphics.DrawString(dv.Columns(c).HeaderCell.Value.ToString, drawFontBOLD, Brushes.Black, cell, sf)
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
            End If

        Next
        'Catch ex As Exception

        ' End Try
        If temp = 1 Then
            ' dv.Columns(0).Visible = True
        End If

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