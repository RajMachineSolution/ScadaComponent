
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Public Class tank
    Dim g As System.Drawing.Graphics
    Dim pen1 As New System.Drawing.Pen(Color.Blue, 2)
    Dim img As Boolean
    Dim brush As New System.Drawing.SolidBrush(Color.Orange)
    Private Sub Cylinder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Dim show1 As Boolean = True

    Dim db As String = ""
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
            End If
        End Set
    End Property
    Property ShowCyl As Boolean
        Get
            Return show1
        End Get
        Set(ByVal value As Boolean)
            show1 = value
            '   show_cyl()
        End Set
    End Property
  
  

 
 
   
  
    Dim Min_tank_value As Integer
    Property Minimum_tank_value As Integer
        Get
            Return Min_tank_value
        End Get
        Set(ByVal value As Integer)
            Min_tank_value = value
        End Set
    End Property
    Dim Max_tank_value As Integer
    Property Maximum_tank_value As Integer
        Get
            Return Max_tank_value
        End Get
        Set(ByVal value As Integer)
            Max_tank_value = value
        End Set
    End Property
    Public fill_d_val As Integer
    Dim fill_d_add As Integer
    Property fill_address_d As Integer
        Get
            Return fill_d_add
        End Get
        Set(ByVal value As Integer)
            fill_d_add = value
            '  show_cyl()
        End Set
    End Property

    'Private Sub show_cyl()
    '    Dim tempfill = 0
    '    Dim ff = 0
    '    If fill_d_val >= Minimum_tank_value And fill_d_val <= Maximum_tank_value Then
    '        tempfill = fill_d_val - Minimum_tank_value
    '        Dim hr = pb1.Height
    '        Dim span = Maximum_tank_value - Minimum_tank_value
    '        Dim ac = tempfill


    '        ff = (ac / span) * pb1.Height
    '    End If


    '    Dim br2 As New LinearGradientBrush(New Point(1, pb1.Height), New Point(pb1.Width - 2, pb1.Height), Color.SkyBlue, Color.CornflowerBlue)

    '    Dim a As Integer = Integer.Parse(Convert.ToInt32((pb1.Height / 100)) * ff)
    '    'Dim y_coordinate As Integer = (pb1.Location.Y + (pb1.Height)) * (1 - ff / 100)
    '    Dim y_coordinate As Integer = (pb1.Location.Y) + pb1.Height - (ff)

    '    Dim y_height As Integer = (ff / pb1.Height) * 100
    '    If show1 = True Then
    '        pb1.Refresh()
    '        g = pb1.CreateGraphics

    '        g.DrawRectangle(pen1, pb1.Location.X, pb1.Location.Y, pb1.Width, pb1.Height)
    '        g.FillRectangle(br2, pb1.Location.X + 1, y_coordinate - 1, pb1.Width - 2, ff)
    '        '        show1 = False
    '    End If
    'End Sub
    Dim fillvalue
  
    Dim tempfill_d_val = 0
    Sub fill_tank_d_address()
        If tempfill_d_val <> fill_d_val Then
            tempfill_d_val = fill_d_val
        Else
            ' Exit Sub
        End If
        tankfillp()
    End Sub
    Private Sub tankfill()
        Dim tempfill = 0
        Dim ff = 0
        If fill_d_val >= Minimum_tank_value And fill_d_val <= Maximum_tank_value Then
            tempfill = fill_d_val - Minimum_tank_value
            Dim hr = pb1.Height
            Dim span = Maximum_tank_value - Minimum_tank_value
            Dim ac = tempfill


            ff = (ac / span) * pb1.Height
        End If


        Dim br2 As New LinearGradientBrush(New Point(1, pb1.Height), New Point(pb1.Width - 2, pb1.Height), Color.SkyBlue, Color.CornflowerBlue)

        Dim a As Integer = Integer.Parse(Convert.ToInt32((pb1.Height / 100)) * ff)
        'Dim y_coordinate As Integer = (pb1.Location.Y + (pb1.Height)) * (1 - ff / 100)
        Dim y_coordinate As Integer = (pb1.Location.Y) + pb1.Height - (ff)

        Dim y_height As Integer = (ff / pb1.Height) * 100
        If show1 = True Then
            pb1.Refresh()
            g = pb1.CreateGraphics

            g.DrawRectangle(pen1, pb1.Location.X, pb1.Location.Y, pb1.Width, pb1.Height)
            g.FillRectangle(br2, pb1.Location.X + 1, y_coordinate - 1, pb1.Width - 2, ff)
            '        show1 = False
        End If
    End Sub
    Private Sub tankfillp()
        Dim tempfill = 0
        Dim ff = 0
        If fill_d_val >= Minimum_tank_value And fill_d_val <= Maximum_tank_value Then
            tempfill = fill_d_val - Minimum_tank_value
            Dim hr = pb1.Height
            Dim span = Maximum_tank_value - Minimum_tank_value
            Dim ac = tempfill


            ff = (ac / span) * pb1.Height
        End If


        Dim br2 As New LinearGradientBrush(New Point(1, pb1.Height), New Point(pb1.Width - 2, pb1.Height), Color.SkyBlue, Color.CornflowerBlue)
        Panel2.Height = ff
        Panel2.BackColor = ColorTranslator.FromHtml("#74ccf4")
        'Dim a As Integer = Integer.Parse(Convert.ToInt32((pb1.Height / 100)) * ff)
        ''Dim y_coordinate As Integer = (pb1.Location.Y + (pb1.Height)) * (1 - ff / 100)
        'Dim y_coordinate As Integer = (pb1.Location.Y) + pb1.Height - (ff)

        'Dim y_height As Integer = (ff / pb1.Height) * 100
        'If show1 = True Then
        '    pb1.Refresh()
        '    g = pb1.CreateGraphics

        '    g.DrawRectangle(pen1, pb1.Location.X, pb1.Location.Y, pb1.Width, pb1.Height)
        '    g.FillRectangle(br2, pb1.Location.X + 1, y_coordinate - 1, pb1.Width - 2, ff)
        '    '        show1 = False
        'End If
    End Sub
End Class
