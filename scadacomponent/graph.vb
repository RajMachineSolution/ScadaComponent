Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Drawing

Public Class graph
    Dim sql As New sqlclass
    '  Dim refrence_grid As DataGridView
    Public Enum update_graph_from
        Tag
        Time
    End Enum

    Dim update_points_with As update_graph_from
    <Browsable(True), _
Category("_Tag")> _
    Property _update_points_with As update_graph_from
        Get
            Return update_points_with
        End Get
        Set(value As update_graph_from)
            update_points_with = value
            If update_points_with = update_graph_from.Time Then
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
            If update_points_with = update_graph_from.Time Then
                '  Timer1.Enabled = True
                Timer1.Interval = timer_interval
            End If
        End Set
    End Property

    Dim refrence_grids As New List(Of number_of_grid)
    <Browsable(True), _
EditorBrowsable(EditorBrowsableState.Always), _
Category("_Reference"), _
DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Property Refrence_Grids_Name As List(Of number_of_grid)
        Get
            Return refrence_grids
        End Get
        Set(ByVal value As List(Of number_of_grid))
            refrence_grids = value
            'Add_series_in_graph()
        End Set

    End Property

    Sub Add_series_in_graph()
        Try
            Me.Series.Clear()
            For i = 0 To refrence_grids.Count - 1
                Me.Series.Add(i)
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    '<Category("_Reference")>
    'Property Refrence_Grid_Name As DataGridView
    '    Get
    '        Return refrence_grid
    '    End Get
    '    Set(ByVal value As DataGridView)
    '        refrence_grid = value
    '    End Set
    'End Property


    Public Enum Set_X_axis_range_from
        Direct
        Indirect
    End Enum
    Public Enum Set_Y_axis_range_from
        Direct
        Indirect
    End Enum


    Dim Xaxis_range As Set_X_axis_range_from
    'set wheater range for axis is change according to tag or not. if with tag then indirect else direct
    <Category("_Reference")>
    Property set_Xaxis_range As Set_X_axis_range_from

        Get
            Return Xaxis_range
        End Get
        Set(ByVal value As Set_X_axis_range_from)
            Xaxis_range = value
        End Set
    End Property



    Dim Yaxis_range As Set_Y_axis_range_from
    'set wheater range for axis is change according to tag or not. if with tag then indirect else direct
    <Category("_Reference")>
    Property set_Yaxis_range As Set_Y_axis_range_from

        Get
            Return Yaxis_range
        End Get
        Set(ByVal value As Set_Y_axis_range_from)
            Yaxis_range = value

        End Set
    End Property

    Dim xaxis_minimum_range As Integer = 0
    <Category("_Reference")>
    Property Xaxis_minimum As Integer
        Get
            Return xaxis_minimum_range
        End Get
        Set(ByVal value As Integer)
            If value < xaxis_maximum_range Then
                xaxis_minimum_range = value
                If set_Xaxis_range = Set_X_axis_range_from.Direct Then
                    Me.ChartAreas(0).AxisX.Minimum = xaxis_minimum_range
                End If
            End If


        End Set
    End Property

    Dim Yaxis_minimum_range As Integer = 0
    <Category("_Reference")>
    Property Yaxis_minimum As Integer
        Get
            Return Yaxis_minimum_range
        End Get
        Set(ByVal value As Integer)
            If value < Yaxis_maximum_range Then
                Yaxis_minimum_range = value
                If set_Yaxis_range = Set_Y_axis_range_from.Direct Then
                    Me.ChartAreas(0).AxisY.Minimum = Yaxis_minimum_range
                End If
            End If

        End Set
    End Property

    Dim xaxis_maximum_range As Integer = 1
    <Category("_Reference")>
    Property Xaxis_maximum As Integer
        Get
            Return xaxis_maximum_range
        End Get
        Set(ByVal value As Integer)
            If value > xaxis_minimum_range Then
                xaxis_maximum_range = value
                If set_Xaxis_range = Set_X_axis_range_from.Direct Then
                    Me.ChartAreas(0).AxisX.Maximum = xaxis_maximum_range
                End If
            End If

        End Set
    End Property

    Dim Yaxis_maximum_range As Integer = 1
    <Category("_Reference")>
    Property Yaxis_maximum As Integer
        Get
            Return Yaxis_maximum_range
        End Get
        Set(ByVal value As Integer)
            If value > Yaxis_minimum_range Then
                Yaxis_maximum_range = value
                If set_Yaxis_range = Set_Y_axis_range_from.Direct Then
                    Me.ChartAreas(0).AxisY.Maximum = Yaxis_maximum_range
                End If
            End If

        End Set
    End Property

    Dim xaxis_min_tag_id As Integer = 0
    Dim yaxis_min_tag_id As Integer = 0
    Dim xaxis_max_tag_id As Integer = 0
    Dim yaxis_max_tag_id As Integer = 0

    Dim xaxis_minimum_tag As String
    <Category("_Reference")>
    Property tag_for_Xaxis_minimum As String
        Get
            Return xaxis_minimum_tag
        End Get
        Set(ByVal value As String)
            xaxis_minimum_tag = value
        End Set
    End Property

    Dim yaxis_minimum_tag As String
    <Category("_Reference")>
    Property tag_for_Yaxis_minimum As String
        Get
            Return yaxis_minimum_tag
        End Get
        Set(ByVal value As String)
            yaxis_minimum_tag = value
        End Set
    End Property


    Dim xaxis_maximum_tag As String
    <Category("_Reference")>
    Property tag_for_Xaxis_maximum As String
        Get
            Return xaxis_maximum_tag
        End Get
        Set(ByVal value As String)
            xaxis_maximum_tag = value
        End Set
    End Property

    Dim yaxis_maximum_tag As String
    <Category("_Reference")>
    Property tag_for_Yaxis_maximum As String
        Get
            Return yaxis_maximum_tag
        End Get
        Set(ByVal value As String)
            yaxis_maximum_tag = value
        End Set
    End Property


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


    Public Enum Set_X_axis_section_from
        Direct
        Indirect
    End Enum
    Public Enum Set_Y_axis_section_from
        Direct
        Indirect
    End Enum

    Dim section_clr As Color = Color.Yellow
    <Browsable(True), _
Category("_Section Area")> _
    Property section_color As Color
        Get
            Return section_clr
        End Get
        Set(value As Color)
            section_clr = value
        End Set
    End Property

    Dim Enable_section As Boolean = True
    <Browsable(True), _
Category("_Section Area")> _
    Property Enable_section_area As Boolean
        Get
            Return Enable_section
        End Get
        Set(value As Boolean)
            Enable_section = value

        End Set
    End Property

    Dim Xaxis_section As Set_X_axis_section_from
    'set wheater range for axis is change according to tag or not. if with tag then indirect else direct
    <Category("_Section Area")>
    Property set_Xaxis_section As Set_X_axis_section_from

        Get
            Return Xaxis_section
        End Get
        Set(ByVal value As Set_X_axis_section_from)
            Xaxis_section = value
        End Set
    End Property


    Dim yaxis_section As Set_Y_axis_section_from
    'set wheater range for axis is change according to tag or not. if with tag then indirect else direct
    <Category("_Section Area")>
    Property set_yaxis_section As Set_Y_axis_section_from
        Get
            Return yaxis_section
        End Get
        Set(ByVal value As Set_Y_axis_section_from)
            yaxis_section = value
        End Set
    End Property

    Dim Yaxis_section_cordinate As Integer = 0
    <Category("_Section Area")>
    Property Yaxis_section_area As Integer
        Get
            Return Yaxis_section_cordinate
        End Get
        Set(ByVal value As Integer)
            Yaxis_section_cordinate = value
        End Set
    End Property

    Dim Xaxis_section_cordinate As Integer = 0
    <Category("_Section Area")>
    Property Xaxis_section_area As Integer
        Get
            Return Xaxis_section_cordinate
        End Get
        Set(ByVal value As Integer)
            Xaxis_section_cordinate = value
        End Set
    End Property

    Dim yaxis_section_tag_id As Integer = 0
    Dim xaxis_section_tag_id As Integer = 0

    Dim xaxis_section_tag As String
    <Category("_Section Area")>
    Property tag_for_Xaxis_section As String
        Get
            Return xaxis_section_tag
        End Get
        Set(ByVal value As String)
            xaxis_section_tag = value
        End Set
    End Property

    Dim yaxis_section_tag As String
    <Category("_Section Area")>
    Property tag_for_Yaxis_section As String
        Get
            Return yaxis_section_tag
        End Get
        Set(ByVal value As String)
            yaxis_section_tag = value
        End Set
    End Property


    Dim xaxis_section_gain As Double = 1
    <Category("_Section Area")>
    Property gain_for_Xaxis_section As Double
        Get
            Return xaxis_section_gain
        End Get
        Set(ByVal value As Double)
            xaxis_section_gain = value
        End Set
    End Property

    Dim yaxis_section_gain As Double = 1
    <Category("_Section Area")>
    Property gain_for_Yaxis_section As Double
        Get
            Return yaxis_section_gain
        End Get
        Set(ByVal value As Double)
            yaxis_section_gain = value
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

    'show x-y point on the chart
    Dim show_lable As Boolean = True
    <Browsable(True), _
Category("_VISIBLE")> _
    Property Show_XY_Point As Boolean
        Get
            Return show_lable
        End Get
        Set(value As Boolean)
            show_lable = value

        End Set
    End Property


    Sub clear_graph_points()
        visiblecode()
        If variableclass.tag(clear_points_grid) = 1 Then
            Me.Series(0).Points.Clear()
            writeIndb(clear_points_grid, 0, 0)
        End If
    End Sub

    Sub reset_min_max_axis()
        Try
            If counter = 0 Then
                If set_Xaxis_range = Set_X_axis_range_from.Indirect Then
                    If Val(variableclass.tag(xaxis_min_tag_id)) < Val(variableclass.tag(xaxis_max_tag_id)) Then
                        If xaxis_min_tag_id <> 0 And variableclass.tag(xaxis_min_tag_id) <> Me.ChartAreas(0).AxisX.Minimum Then
                            Me.ChartAreas(0).AxisX.Minimum = variableclass.tag(xaxis_min_tag_id)
                        End If
                        If xaxis_max_tag_id <> 0 And variableclass.tag(xaxis_max_tag_id) <> Me.ChartAreas(0).AxisX.Maximum Then
                            Me.ChartAreas(0).AxisX.Maximum = variableclass.tag(xaxis_max_tag_id)
                        End If
                    End If
                End If

            End If
            If set_Yaxis_range = Set_Y_axis_range_from.Indirect Then
                If Val(variableclass.tag(yaxis_min_tag_id)) < Val(variableclass.tag(yaxis_max_tag_id)) Then
                    If yaxis_min_tag_id <> 0 And variableclass.tag(yaxis_min_tag_id) <> Me.ChartAreas(0).AxisY.Minimum Then
                        Me.ChartAreas(0).AxisY.Minimum = variableclass.tag(yaxis_min_tag_id)
                    End If
                    If yaxis_max_tag_id <> 0 And variableclass.tag(yaxis_max_tag_id) <> Me.ChartAreas(0).AxisY.Maximum Then
                        Me.ChartAreas(0).AxisY.Maximum = variableclass.tag(yaxis_max_tag_id)
                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show("Axis Min-Max--" & ex.Message)
        End Try



    End Sub
    Dim add_section_line As Integer = 0
    Dim sline1 As StripLine = New StripLine()
    Dim sline As StripLine = New StripLine()
    Sub addsectionlines()
        Me.ChartAreas(0).AxisX.StripLines.Add(sline1)
        Me.ChartAreas(0).AxisY.StripLines.Add(sline)
    End Sub


    Sub create_section()
        Try

            If Enable_section = True Then
                If add_section_line = 0 Then
                    addsectionlines()
                    add_section_line = 1
                End If
                If set_Xaxis_section = Set_X_axis_section_from.Direct Then
                    ' Dim sline1 As StripLine = New StripLine()
                    sline1.IntervalOffset = Xaxis_section_cordinate
                    sline1.StripWidth = 1000000
                    'sline1.Text = "Section Area"
                    sline1.Interval = 0.0
                    sline1.BackColor = Me.ChartAreas(0).BackColor
                ElseIf set_Xaxis_section = Set_X_axis_section_from.Indirect And sline1.IntervalOffset <> Val(variableclass.tag(xaxis_section_tag_id)) Then
                    '  Dim sline1 As StripLine = New StripLine()
                    If Val(variableclass.tag(xaxis_section_tag_id)) > 0 Then
                        sline1.IntervalOffset = Val(variableclass.tag(xaxis_section_tag_id)) / xaxis_section_gain
                        sline1.StripWidth = 1000000
                        'sline1.Text = "Section Area"
                        sline1.Interval = 0.0
                        sline1.BackColor = Me.ChartAreas(0).BackColor

                    End If
                    '  Me.ChartAreas(0).AxisX.StripLines.Add(sline1)
                End If
                If set_yaxis_section = Set_Y_axis_section_from.Direct Then
                    ' Dim sline As StripLine = New StripLine()
                    sline.IntervalOffset = 0
                    sline.StripWidth = Yaxis_section_cordinate
                    'sline.Text = "Section Area"
                    sline.Interval = 0.0
                    sline.BackColor = section_color
                ElseIf set_yaxis_section = Set_Y_axis_section_from.Indirect Then
                    ' Dim sline As StripLine = New StripLine()
                    If Val(variableclass.tag(yaxis_section_tag_id)) > 0 And sline.StripWidth <> Val(variableclass.tag(yaxis_section_tag_id)) Then
                        sline.IntervalOffset = 0
                        sline.StripWidth = Val(variableclass.tag(yaxis_section_tag_id)) / yaxis_section_gain
                        ' sline.Text = "Section Area"
                        sline.Interval = 0.0
                        sline.BackColor = section_color

                    End If
                    'Me.ChartAreas(0).AxisY.StripLines.Add(sline)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Section Area--" & ex.Message)
        End Try

    End Sub

    Sub plot_points_on_graph()
        Try
            reset_min_max_axis()
            create_section()
            If update_points_with = update_graph_from.Tag Then
                If Timer1.Enabled = True Then
                    Timer1.Enabled = False
                End If
                If variableclass.tag(update_grid) = 1 Then
                    For j = 0 To refrence_grids.Count - 1
                        Me.ChartAreas(0).CursorX.IsUserSelectionEnabled = True

                        Me.Series(j).Points.Clear()
                        'when all x zero points not ploted correctly so adding a transperent dummu
                        Dim dummyPoint As New DataPoint(10000000, 0)
                        Me.Series(j).Points.Add(dummyPoint)

                        '  Me.Series(0).Points.AddXY(1, 0)
                        If refrence_grids(j).Refrence_Grid_Name.AllowUserToAddRows = True Then
                            For i = 0 To refrence_grids(j).Refrence_Grid_Name.RowCount - 2
                                If Not IsDBNull(refrence_grids(j).Refrence_Grid_Name.Rows(i).Cells(1).Value) And Not IsDBNull(refrence_grids(j).Refrence_Grid_Name.Rows(i).Cells(2).Value) Then
                                    Me.Series(j).Points.AddXY(Double.Parse(refrence_grids(j).Refrence_Grid_Name.Rows(i).Cells(1).Value), Double.Parse(refrence_grids(j).Refrence_Grid_Name.Rows(i).Cells(2).Value))
                                    If show_lable = True Then
                                        Me.Series(j).Points(i + 1).Label = Format("(" & refrence_grids(j).Refrence_Grid_Name.Rows(i).Cells(1).Value & "-" & refrence_grids(j).Refrence_Grid_Name.Rows(i).Cells(2).Value & ")")
                                    End If
                                End If
                                'If refrence_grid.Rows(i).Cells(grid_for_graph.x_column).ToString IsNot Nothing And refrence_grid.Rows(i).Cells(grid_for_graph.y_column).ToString IsNot Nothing Then
                                '    Me.Series(0).Points.AddXY(Double.Parse(refrence_grid.Rows(i).Cells(grid_for_graph.x_column).Value), Double.Parse(refrence_grid.Rows(i).Cells(grid_for_graph.y_column).Value))

                                'Else
                                'End If
                            Next


                        ElseIf refrence_grids(j).Refrence_Grid_Name.AllowUserToAddRows = False Then

                            For i = 0 To refrence_grids(j).Refrence_Grid_Name.RowCount - 1
                                If Not IsDBNull(refrence_grids(j).Refrence_Grid_Name.Rows(i).Cells(1).Value) And Not IsDBNull(refrence_grids(j).Refrence_Grid_Name.Rows(i).Cells(2).Value) Then
                                    Me.Series(j).Points.AddXY(Double.Parse(refrence_grids(j).Refrence_Grid_Name.Rows(i).Cells(1).Value), Double.Parse(refrence_grids(j).Refrence_Grid_Name.Rows(i).Cells(2).Value))
                                    If show_lable = True Then
                                        Me.Series(j).Points(i + 1).Label = Format("(" & refrence_grids(j).Refrence_Grid_Name.Rows(i).Cells(1).Value & "-" & refrence_grids(j).Refrence_Grid_Name.Rows(i).Cells(2).Value & ")")
                                    End If

                                End If
                                'If refrence_grid.Rows(i).Cells(grid_for_graph.x_column).ToString IsNot Nothing And refrence_grid.Rows(i).Cells(grid_for_graph.y_column).ToString IsNot Nothing Then

                                'Else

                                'End If
                            Next
                        End If
                        dummyPoint.Color = Color.Transparent

                        '   Me.Series(0).Points.RemoveAt(0)
                    Next                    'For i = 0 To refrence_grid.RowCount - 1
                    '    Me.Series(0).Points.AddXY(refrence_grid.Rows(i).Cells(1).Value, refrence_grid.Rows(i).Cells(2).Value)
                    'Next
                    'if points updated then set 0
                    ' update_grid = 0
                    writeIndb(update_grid, 0, 0)

                End If
            ElseIf update_points_with = update_graph_from.Time Then
                If Timer1.Enabled = False Then
                    Timer1.Enabled = True
                End If
            End If
        Catch ex As Exception
            MsgBox("plot points ----" & ex.Message)
        End Try


    End Sub

    Sub create_graph()
        '   Me.ChartAreas(0).CursorX.IsUserSelectionEnabled = True
        Me.Series(0).Points.AddXY(0, 0)
        '    Me.Series("Series2").Points.AddXY(0, 0)
    End Sub


    'Assign levels by right click
    Private Sub RECIPE_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown

        If e.Button = Windows.Forms.MouseButtons.Right Or Login_Register.levelid = Login_Register.mngr Then

            If Login_Register.levelid = 1 Then

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

    Dim counter = 0
    Dim range = 0
    'code for moving on next and previous page
    Sub nextpage()
        range = Me.ChartAreas(0).AxisX.Maximum - Me.ChartAreas(0).AxisX.Minimum
        Me.ChartAreas(0).AxisX.Minimum = Me.ChartAreas(0).AxisX.Minimum + range
        Me.ChartAreas(0).AxisX.Maximum = Me.ChartAreas(0).AxisX.Maximum + range
        counter = counter + 1
        'range = Xaxis_maximum - Xaxis_minimum
        'Xaxis_minimum = Xaxis_minimum + range
        'Xaxis_maximum = Xaxis_maximum + range
        'counter = counter + 1
    End Sub

    Sub previouspage()
        If counter > 0 Then
            range = Me.ChartAreas(0).AxisX.Maximum - Me.ChartAreas(0).AxisX.Minimum
            Me.ChartAreas(0).AxisX.Minimum = Me.ChartAreas(0).AxisX.Minimum - range
            Me.ChartAreas(0).AxisX.Maximum = Me.ChartAreas(0).AxisX.Maximum - range
            counter = counter - 1
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
        Try
            sql.scon3()
            Dim querystring As String = ""
            'for encrypted or  non_encypted tables
            If variableclass.is_encrypted Then
                querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id, convert(varchar, decryptbykey(Tag_name)) as Tag_name from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & update_tag & "' or convert(varchar, decryptbykey(Tag_name)) = '" & clear_point_tag & "' or convert(varchar, decryptbykey(Tag_name)) = '" & xaxis_minimum_tag & "' or convert(varchar, decryptbykey(Tag_name)) = '" & yaxis_minimum_tag & "' or convert(varchar, decryptbykey(Tag_name)) = '" & yaxis_maximum_tag & "' or convert(varchar, decryptbykey(Tag_name)) = '" & xaxis_maximum_tag & "' or convert(varchar, decryptbykey(Tag_name)) = '" & yaxis_section_tag & "' or convert(varchar, decryptbykey(Tag_name)) = '" & xaxis_section_tag & "' "
            Else
                querystring = "select Tag_id, Tag_name from Tag_data  where  Tag_name = '" & update_tag & "' or Tag_name = '" & clear_point_tag & "' or Tag_name = '" & xaxis_maximum_tag & "' or Tag_name = '" & yaxis_maximum_tag & "' or Tag_name = '" & xaxis_minimum_tag & "' or Tag_name = '" & yaxis_minimum_tag & "' or Tag_name = '" & xaxis_section_tag & "' or Tag_name = '" & yaxis_section_tag & "' "
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
                    If reader.Item("Tag_name") = xaxis_maximum_tag Then
                        xaxis_max_tag_id = reader.Item("Tag_id")
                        '  tempwrite = 1
                    End If
                    If reader.Item("Tag_name") = yaxis_maximum_tag Then
                        yaxis_max_tag_id = reader.Item("Tag_id")
                        'tempread = 1
                    End If
                    If reader.Item("Tag_name") = xaxis_minimum_tag Then
                        xaxis_min_tag_id = reader.Item("Tag_id")
                        ' tempwrite = 1
                    End If
                    If reader.Item("Tag_name") = yaxis_minimum_tag Then
                        yaxis_min_tag_id = reader.Item("Tag_id")
                        ' tempread = 1
                    End If
                    If reader.Item("Tag_name") = xaxis_section_tag Then
                        xaxis_section_tag_id = reader.Item("Tag_id")
                        ' tempwrite = 1
                    End If
                    If reader.Item("Tag_name") = yaxis_section_tag Then
                        yaxis_section_tag_id = reader.Item("Tag_id")
                        ' tempread = 1
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
        Catch ex As Exception
            MsgBox("update tag--" & ex.Message)
        End Try

    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Try
            For j = 0 To refrence_grids.Count - 1
                ' Me.ChartAreas(0).CursorX.IsUserSelectionEnabled = True

                Me.Series(j).Points.Clear()
                'when all x zero points not ploted correctly so adding a transperent dummu
                Dim dummyPoint As New DataPoint(10000000, 0)
                Me.Series(j).Points.Add(dummyPoint)

                '  Me.Series(0).Points.AddXY(1, 0)
                If refrence_grids(j).Refrence_Grid_Name.AllowUserToAddRows = True Then
                    For i = 0 To refrence_grids(j).Refrence_Grid_Name.RowCount - 2
                        If Not IsDBNull(refrence_grids(j).Refrence_Grid_Name.Rows(i).Cells(1).Value) And Not IsDBNull(refrence_grids(j).Refrence_Grid_Name.Rows(i).Cells(2).Value) Then
                            Me.Series(j).Points.AddXY(Double.Parse(refrence_grids(j).Refrence_Grid_Name.Rows(i).Cells(1).Value), Double.Parse(refrence_grids(j).Refrence_Grid_Name.Rows(i).Cells(2).Value))
                            If show_lable = True Then
                                Me.Series(j).Points(i + 1).Label = Format("(" & refrence_grids(j).Refrence_Grid_Name.Rows(i).Cells(1).Value & "-" & refrence_grids(j).Refrence_Grid_Name.Rows(i).Cells(2).Value & ")")
                            End If
                        End If
                        'If refrence_grid.Rows(i).Cells(grid_for_graph.x_column).ToString IsNot Nothing And refrence_grid.Rows(i).Cells(grid_for_graph.y_column).ToString IsNot Nothing Then
                        '    Me.Series(0).Points.AddXY(Double.Parse(refrence_grid.Rows(i).Cells(grid_for_graph.x_column).Value), Double.Parse(refrence_grid.Rows(i).Cells(grid_for_graph.y_column).Value))

                        'Else
                        'End If
                    Next


                ElseIf refrence_grids(j).Refrence_Grid_Name.AllowUserToAddRows = False Then

                    For i = 0 To refrence_grids(j).Refrence_Grid_Name.RowCount - 1
                        If Not IsDBNull(refrence_grids(j).Refrence_Grid_Name.Rows(i).Cells(1).Value) And Not IsDBNull(refrence_grids(j).Refrence_Grid_Name.Rows(i).Cells(2).Value) Then
                            Me.Series(j).Points.AddXY(Double.Parse(refrence_grids(j).Refrence_Grid_Name.Rows(i).Cells(1).Value), Double.Parse(refrence_grids(j).Refrence_Grid_Name.Rows(i).Cells(2).Value))
                            If show_lable = True Then
                                Me.Series(j).Points(i + 1).Label = Format("(" & refrence_grids(j).Refrence_Grid_Name.Rows(i).Cells(1).Value & "-" & refrence_grids(j).Refrence_Grid_Name.Rows(i).Cells(2).Value & ")")
                            End If

                        End If
                        'If refrence_grid.Rows(i).Cells(grid_for_graph.x_column).ToString IsNot Nothing And refrence_grid.Rows(i).Cells(grid_for_graph.y_column).ToString IsNot Nothing Then

                        'Else

                        'End If
                    Next
                End If
                dummyPoint.Color = Color.Transparent

                '   Me.Series(0).Points.RemoveAt(0)
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


End Class

Public Class number_of_grid
    ' Dim graphobj As New graph
    Dim refrence_grid As DataGridView
    Public Property Refrence_Grid_Name As DataGridView
        Get
            Return refrence_grid
        End Get
        Set(ByVal value As DataGridView)
            refrence_grid = value
            'graphobj.Add_series_in_graph()
        End Set
    End Property

End Class

