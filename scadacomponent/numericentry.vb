Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.Drawing.Size
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.Control
Imports System.Object
Imports System.ComponentModel.Component
Imports System.Windows.Forms.BorderStyle
Imports System.Windows.Forms.TextBox
Imports System.Windows.Forms.Button
Imports System.Windows.Forms.Label
Imports System.Data.SqlClient
Imports System.ComponentModel


Public Class numericentry
    Public Enum bittype
        Bit16
        Bit32
    End Enum
    Public Enum Record_Event
        DirectlyInAuditTrail
        WithMessageInAuditTrail
        NO
    End Enum
    Public Enum Record_Data
        InsertAlways
        UpdateAlways
    End Enum
    Public Enum Record_encyptedData
        Yes
        No
    End Enum
    Dim sql As New sqlclass
    Dim ad As Integer = 0
    Dim txt As String = "Value"

    'Public Property index As Integer
    '    Get
    '        Return ad
    '    End Get
    '    Set(ByVal value As Integer)
    '        ad = value
    '    End Set
    'End Property

    'labeltext

    ''----------------- hide properties-------------------''
    'Public Const defaultPropertyVisibility As Boolean = False
    '<Browsable(defaultPropertyVisibility), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    'Overloads Property AccessibleName As String
    '    Get

    '    End Get
    '    Set(value As String)

    '    End Set
    'End Property


    '<Browsable(defaultPropertyVisibility), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    'Overloads Property AccessibleDescription As String
    '    Get
    '    End Get
    '    Set(value As String)
    '    End Set
    'End Property
    '<Browsable(defaultPropertyVisibility), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    'Overloads Property accessiblerole As String
    '    Get
    '    End Get
    '    Set(value As String)
    '    End Set
    'End Property
    '<Browsable(defaultPropertyVisibility), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    'Overloads Property backgroundimage As Image
    '    Get
    '    End Get
    '    Set(value As Image)
    '    End Set
    'End Property
    '<Browsable(defaultPropertyVisibility), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    'Overloads Property backcolor As Color
    '    Get
    '    End Get
    '    Set(value As Color)
    '    End Set
    'End Property
    '<Browsable(defaultPropertyVisibility), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    'Overloads Property backgroundimagelayout As String
    '    Get
    '    End Get
    '    Set(value As String)
    '    End Set
    'End Property
    '<Browsable(defaultPropertyVisibility), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    'Overloads Property Cursor As String
    '    Get
    '    End Get
    '    Set(value As String)
    '    End Set
    'End Property
    '<Browsable(defaultPropertyVisibility), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    'Overloads Property RightToLeft As String
    '    Get
    '    End Get
    '    Set(value As String)
    '    End Set
    'End Property
    '<Browsable(defaultPropertyVisibility), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    'Overloads Property usewaitcursor As Boolean
    '    Get
    '    End Get
    '    Set(value As Boolean)
    '    End Set
    'End Property
    '<Browsable(defaultPropertyVisibility), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    'Overloads Property Font As Font
    '    Get
    '    End Get
    '    Set(value As Font)
    '    End Set
    'End Property
    '<Browsable(defaultPropertyVisibility), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    'Overloads Property ForeColor As Color
    '    Get
    '    End Get
    '    Set(value As Color)
    '    End Set
    'End Property
    '<Browsable(defaultPropertyVisibility), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    'Overloads Property AllowDrop As Boolean
    '    Get
    '    End Get
    '    Set(value As Boolean)
    '    End Set
    'End Property
    ''<Browsable(defaultPropertyVisibility), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    ''Overloads Property Enabled As Boolean
    ''    Get
    ''    End Get
    ''    Set(value As Boolean)
    ''    End Set
    ''End Property
    ''<Browsable(defaultPropertyVisibility), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    ''Overloads Property Visible As Boolean
    ''    Get
    ''    End Get
    ''    Set(value As Boolean)
    ''    End Set
    ''End Property
    '<Browsable(defaultPropertyVisibility), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    'Overloads Property TabStop As Boolean
    '    Get
    '    End Get
    '    Set(value As Boolean)
    '    End Set
    'End Property
    '<Browsable(defaultPropertyVisibility), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    'Overloads Property AutoValidate
    '    Get
    '    End Get
    '    Set(value)
    '    End Set
    'End Property
    '<Browsable(defaultPropertyVisibility), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    'Overloads Property ContextMenuStrip
    '    Get
    '    End Get
    '    Set(value)
    '    End Set
    'End Property
    '<Browsable(defaultPropertyVisibility), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    'Overloads Property ImeMode
    '    Get
    '    End Get
    '    Set(value)
    '    End Set
    'End Property
    '<Browsable(defaultPropertyVisibility), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    'Overloads Property TabIndex
    '    Get
    '    End Get
    '    Set(value)
    '    End Set
    'End Property
    ''<Browsable(defaultPropertyVisibility), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    ''Overloads Property anchor
    ''    Get
    ''    End Get
    ''    Set(value)
    ''    End Set
    ''End Property
    ''<Browsable(defaultPropertyVisibility), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    ''Overloads Property dock
    ''    Get
    ''    End Get
    ''    Set(value)
    ''    End Set
    ''End Property
    '<Browsable(defaultPropertyVisibility), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    'Overloads Property autoscroll As Boolean
    '    Get
    '    End Get
    '    Set(value As Boolean)
    '    End Set
    'End Property
    '<Browsable(defaultPropertyVisibility), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    'Overloads Property autoscrollmargin
    '    Get
    '    End Get
    '    Set(value)
    '    End Set
    'End Property
    '<Browsable(defaultPropertyVisibility), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    'Overloads Property autoscrollminsize
    '    Get
    '    End Get
    '    Set(value)
    '    End Set
    'End Property
    '<Browsable(defaultPropertyVisibility), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    'Overloads Property autosize As Boolean
    '    Get
    '    End Get
    '    Set(value As Boolean)
    '    End Set
    'End Property
    '<Browsable(defaultPropertyVisibility), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    'Overloads Property autosizemode
    '    Get
    '    End Get
    '    Set(value)
    '    End Set
    'End Property
    '<Browsable(defaultPropertyVisibility), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    'Overloads Property margin
    '    Get
    '    End Get
    '    Set(value)
    '    End Set
    'End Property
    '<Browsable(defaultPropertyVisibility), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    'Overloads Property maximumsize
    '    Get
    '    End Get
    '    Set(value)
    '    End Set
    'End Property
    '<Browsable(defaultPropertyVisibility), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    'Overloads Property minimumsize
    '    Get
    '    End Get
    '    Set(value)
    '    End Set
    'End Property
    '<Browsable(defaultPropertyVisibility), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    'Overloads Property padding
    '    Get
    '    End Get
    '    Set(value)
    '    End Set
    'End Property
    '<Browsable(defaultPropertyVisibility), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    'Overloads Property CausesValidation
    '    Get
    '    End Get
    '    Set(value)
    '    End Set
    'End Property
    '<Browsable(defaultPropertyVisibility), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    'Overloads Property Tag
    '    Get
    '    End Get
    '    Set(value)
    '    End Set
    'End Property
    '<Browsable(defaultPropertyVisibility), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    'Overloads Property Databindings
    '    Get
    '    End Get
    '    Set(value)
    '    End Set
    'End Property

    ''----------------- hide properties-------------------''



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

    Dim recordda As Record_Data
    <Category("_Misc")>
    Property RecordData As Record_Data
        Get
            Return recordda
        End Get
        Set(ByVal value As Record_Data)
            recordda = value

        End Set
    End Property

    'property for how data will be inserted in encrypted form or not
    Dim recorddataencrypted As Record_encyptedData
    <Category("_Misc")>
    Property Record_Encrypted_Data As Record_encyptedData
        Get
            Return recorddataencrypted
        End Get
        Set(ByVal value As Record_encyptedData)
            recorddataencrypted = value

        End Set
    End Property
    'property to set time for recording data in database
    Dim recordtime As Integer = 0
    <Category("_Misc")>
    Property Record_time_interval_in_sec As Integer
        Get

            Return recordtime
        End Get
        Set(ByVal value As Integer)
            recordtime = value

        End Set
    End Property
    Dim plc_id As Integer
    <Category("_Misc")>
    Property PlcId As Integer
        Get
            Return plc_id
        End Get
        Set(ByVal value As Integer)
            plc_id = value
        End Set
    End Property
    Public Property text1 As String
        Get
            Return Label1.Text
        End Get
        Set(ByVal value As String)
            'Label1.Text = FormatNumber(CDbl(value * rgain), _decimalval)
            Label1.Text = value
            'If No_of_DecimalValues > 0 Then
            '    Label1.Text = FormatNumber(CDbl(Label1.Text / rgain), _decimalval)
            'Else
            '    Label1.Text = Val(value) / rgain
            'End If
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
    Dim recordflag As Boolean
    <Browsable(False), Category("_Misc")>
    Property Recordvalue As Boolean
        Get
            Return recordflag
        End Get
        Set(ByVal value As Boolean)
            recordflag = value
        End Set
    End Property
    Dim recordev As Record_Event
    <Category("_MESSAGE")>
    Property _RecordEvent As Record_Event
        Get
            Return recordev
        End Get
        Set(ByVal value As Record_Event)
            recordev = value

        End Set
    End Property
    Dim headertxt As String = ""
    <Category("_Misc")>
    Property HeaderText As String
        Get

            Return headertxt
        End Get
        Set(ByVal value As String)
            headertxt = value

        End Set
    End Property

    Dim readadd As Integer = 0  'Address of plc for reading  at particular address
    Dim writeadd As Integer = 0 'Address of plc for writing at particular address

    Dim tbox As Boolean      '
    Dim data As Short
    ' Dim exactadd As String
    Dim labelvalue As String

    Private Sub numericentrytest_Click(sender As Object, e As System.EventArgs) Handles Me.Click

        '  
    End Sub

    'Private Sub numericentrytest_DoubleClick(sender As Object, e As System.EventArgs) Handles Me.DoubleClick
    '    If Windows.Forms.MouseButtons.Right Then
    '        '       Login_Register.levelid = 1
    '        If Login_Register.levelid = 1 Then
    '            ''        '   Panel1.Visible = True
    '            '            ''                showselected(Me, Me.ParentForm)

    '            Dim btnp As New buttonproperty(Me.ParentForm.Name, Me.Name, Me.Location.X, Me.Location.Y)
    '            ' btnp.StartPosition = FormStartPosition.CenterParent
    '            btnp.showselected(Me, Me.ParentForm)
    '            btnp.FormBorderStyle = Windows.Forms.FormBorderStyle.None
    '            '   btnp.Panel1.Location = Me.Location
    '            btnp.ShowDialog()
    '        End If
    '    Else
    '        If Readonly1 = False Then
    '            TextBox1.Text = Label1.Text
    '            TextBox1.Visible = True
    '            TextBox1.Enabled = True
    '            tbox = True
    '            Label1.Hide()
    '        End If
    '    End If
    'End Sub



    Private Sub UserControl1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TextBox1.Visible = False
        TextBox1.Enabled = False
        'sqlclass.server = ".\sqlexpress"
        'sqlclass.dbname = "phrencrydecry"
        'sqlclass.dbid = "rmsview"
        'sqlclass.dbpass = "rmsview"

        '   filllevels()
        ' Button1.BackColor = Color.Transparent
        '   Login_Register.levelid = 1
        If Login_Register.levelid IsNot Nothing And Login_Register.levelid <> 0 Then
            rightread(Me, Me.ParentForm)
            'showselected(Me, Me.ParentForm)
        Else
            ' If readonly1 Then
            ' Me.Enabled = False
            ' Else
            '  Me.Enabled = True
            control_enable = True
        End If

    End Sub
    'readaddress and write adddress are same
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
    Dim rgain As Double = 1
    ' Dim rgain As Double = 1
    <Category("_Misc")>
    Property Gain As Double
        Get
            Return rgain

        End Get
        Set(ByVal VALUE As Double)
            rgain = VALUE
            ' rgain = VALUE
        End Set
    End Property

    '<Category("_Misc")>
    'Property WriteGain As Double
    '    Get
    '        Return rgain

    '    End Get
    '    Set(ByVal VALUE As Double)
    '        rgain = VALUE
    '        rgain = VALUE
    '    End Set
    'End Property
    Dim _decimalval As Integer = 0
    <Category("_Misc"), Description("Set number of value to display after decimal")>
    Property No_of_DecimalValues As Integer
        Get
            Return _decimalval

        End Get
        Set(ByVal VALUE As Integer)
            _decimalval = VALUE
            ' Label1.Text = FormatNumber(CDbl(Label1.Text * rgain), _decimalval)
        End Set
    End Property


    Property TextProperty As String ' this property return the value with respective to gain

        Get
            If tbox Then
                Return Trim(TextBox1.Text)
            Else
                Return Label1.Text
            End If
        End Get
        Set(ByVal VALUE As String)
            If tbox Then
                TextBox1.Text = Trim(VALUE)
            Else
                '  If IsNumeric(VALUE) Then
                Label1.Text = Val(VALUE) / rgain

                '-- changes for decimal value
                'If No_of_DecimalValues > 0 Then
                '    Label1.Text = FormatNumber(CDbl(Label1.Text / rgain), _decimalval)
                'Else
                '    Label1.Text = Val(VALUE) / rgain
                'End If




                ' End If
            End If
        End Set
    End Property
    <Category("_Misc"), Description("The background color of control")>
    Property TextboxBackcolor As Color
        Get
            Return TextBox1.BackColor

        End Get
        Set(ByVal value As Color)
            TextBox1.BackColor = value
        End Set
    End Property
    <Category("_Misc"), Description("The background color to display text on control")>
    Property LabelBackcolor As Color
        Get
            Return Label1.BackColor

        End Get
        Set(ByVal value As Color)
            Label1.BackColor = value
        End Set
    End Property
    <Category("_Misc"), Description("The color which is use to display text")>
    Property TextboxForecolor As Color
        Get
            Return TextBox1.ForeColor

        End Get
        Set(ByVal value As Color)
            TextBox1.ForeColor = value
        End Set
    End Property
    <Browsable(False), _
Category("LIMITS")> _
    Property TextboxFont As Font
        Get
            Return TextBox1.Font

        End Get
        Set(ByVal value As Font)
            TextBox1.Font = value
        End Set
    End Property
    <Browsable(False)> _
    Property SizeTextbox As Size

        Get
            Return TextBox1.Size
        End Get
        Set(ByVal value As Size)
            TextBox1.Size = value
        End Set
    End Property
    <Browsable(False)> _
    Property TextboxBorderstyle As BorderStyle
        Get
            Return TextBox1.BorderStyle
        End Get
        Set(ByVal value As BorderStyle)
            TextBox1.BorderStyle = value
        End Set
    End Property
    <Browsable(False)> _
    Property TextboxTextAlign As HorizontalAlignment
        Get
            Return TextBox1.TextAlign
        End Get
        Set(ByVal value As HorizontalAlignment)
            TextBox1.TextAlign = value
        End Set
    End Property
    Dim write1 As Integer = 0
    <Browsable(False)> _
    Property Write As Integer
        Get
            Return write1
        End Get
        Set(ByVal value As Integer)

            write1 = value
            '  Write = write1
        End Set
    End Property
    Dim vtw As Double = 0
    <Browsable(False), Category("_Misc")> _
    Property ValuetoWrite As Long
        Get
            Return vtw
        End Get
        Set(ByVal value As Long)
            vtw = value
            '  Write = write1
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
    Dim bittypeval As bittype
    <Category("_Misc"), Description("Determine whether the control exept 16 bit value or 32 bit value")>
    Property BIT_TYPE As bittype
        Get
            Return bittypeval
        End Get
        Set(ByVal value As bittype)
            bittypeval = value
            '  Write = write1
        End Set
    End Property


    Public Enum directcompare
        _True
        _False
    End Enum
    Public Enum Indirectcompare
        _True
        _False
    End Enum
    Dim maxval As Double = 0.0
    Dim minval As Double = 0.0
    Dim maxvalD As String
    Dim minvalD As String
    Dim directcompareflag As Boolean
    Dim Comparisonval As Boolean
    Dim indirectcompareflag As Boolean
    Dim Comparison_Typeval As Comparison_Type
    Public Enum Comparison_Type
        Direct
        InDirect
    End Enum

    <Browsable(True), _
Category("_LIMITS"), Description("Set the maximum value control will accept")> _
    Property Maxvalue As Double
        Get
            Return maxval
        End Get
        Set(ByVal value As Double)
            maxval = value
        End Set
    End Property
    <Browsable(True), _
Category("_LIMITS"), Description("Set the minimum value control will accept")> _
    Property Minvalue As Double
        Get
            Return minval
        End Get
        Set(ByVal value As Double)
            minval = value
        End Set
    End Property

    <Browsable(True), _
Category("_LIMITS"), Description("Determines whether the control accept value between range or not")> _
    Property Comparison As Boolean

        Get
            Return Comparisonval
        End Get
        Set(ByVal value As Boolean)
            Comparisonval = value

        End Set
    End Property
    <Browsable(True), _
Category("_LIMITS"), Description("Determine whether the range of control given direct or from tags")> _
    Property ComparisonType As Comparison_Type

        Get
            Return Comparison_Typeval
        End Get
        Set(ByVal value As Comparison_Type)
            Comparison_Typeval = value
            ' MaxvalueD.readonly = False
        End Set
    End Property
    <Browsable(True), _
Category("_LIMITS"), Description("Tag which set maximum value that control will accept")> _
    Property MaxvalueD As String
        Get
            Return maxvalD
        End Get
        Set(ByVal value As String)
            maxvalD = value
        End Set
    End Property
    <Browsable(True), _
Category("_LIMITS"), Description("Tag which set minimum value that control will accept")> _
    Property MinvalueD As String
        Get
            Return minvalD
        End Get
        Set(ByVal value As String)
            minvalD = value
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


    Dim f As Font
    <Browsable(True), _
Category("_FONTCOMPONENT"), Description("The font used to display text in control")> _
    Property FontComponent As Font


        Get
            Return f
        End Get
        Set(ByVal value As Font)
            f = value
            Label1.Font = f
            TextBox1.Font = f
        End Set
    End Property


    Private Sub TextBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Click
        'TextBox1.Text = Label1.Text
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

    Private Sub Label1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.Click
        'TextBox1.Text = Label1.Text
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

    Private Sub TextBox1_ClientSizeChanged(sender As Object, e As System.EventArgs) Handles TextBox1.ClientSizeChanged

    End Sub

    ''Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
    ''    'TextBox1.Text = Label1.Text
    ''    Try
    ''        '  Process.Start(FileToCopy, "scadatagsystem rmsview rmsview")
    ''        Dim pProcess() As Process = System.Diagnostics.Process.GetProcessesByName("finalKeyboarddesigned")
    ''        If pProcess.Count > 0 Then
    ''        Else
    ''            Dim FileToCopy = Application.StartupPath & "\resource\finalKeyboarddesigned.exe"
    ''            Dim startInfo As ProcessStartInfo = New ProcessStartInfo(FileToCopy)
    ''            Process.Start(startInfo)

    ''        End If


    ''    Catch ex As Exception
    ''        MessageBox.Show(ex.Message)
    ''    End Try
    ''End Sub


    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Escape Then

            If BIT_TYPE.ToString = "Bit16" Then
                write16bit()
                ' Label1.Focus()
            End If
            If BIT_TYPE.ToString = "Bit32" Then
                write32bit()
                '   Label1.Focus()
            End If
            'to stop firing leave event after enter event
            tempexecute = 1
            TextBox1.Visible = False
            TextBox1.Enabled = False
            Label1.Visible = True
        End If
    End Sub
    Dim Max_value, Min_value As Integer 'setting range when comparision is indirect
    ' Dim temp = 0 'read max and min value from database only one time
    Sub write16bit()

        If IsNumeric(TextBox1.Text) Then
            If Comparisonval = True Then
                If Comparison_Typeval.ToString = "Direct" Then
                    If Double.Parse(TextBox1.Text) >= Minvalue And Double.Parse(TextBox1.Text) <= Maxvalue Then
                    Else
                        MsgBox("Enter Correct value in a range " & Minvalue & " to " & Maxvalue)
                        TextBox1.Text = Label1.Text
                        TextBox1.Visible = False
                        Label1.Visible = True
                        Exit Sub
                    End If
                End If
                If Comparison_Typeval.ToString = "InDirect" Then

                    'If temp = 0 Then
                    sql.scon2()
                    'Dim querystring As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select convert(varchar, decryptbykey(tagname)), convert(varchar, decryptbykey(Readaddress_value)) from Tag_detail_data where  convert(varchar, decryptbykey(tagname)) = '" & minvalD & "' or  convert(varchar, decryptbykey(tagname)) = '" & maxvalD & "'"
                    Dim querystring As String = ""
                    'for encrypted or  non_encypted tables
                    If variableclass.is_encrypted Then
                        querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select convert(varchar, decryptbykey(tagname)), convert(varchar, decryptbykey(Readaddress_value)) from Tag_detail_data where  convert(varchar, decryptbykey(tagname)) = '" & minvalD & "' or  convert(varchar, decryptbykey(tagname)) = '" & maxvalD & "'"
                    Else
                        querystring = "select tagname, Readaddress_value from Tag_detail_data where tagname = '" & minvalD & "' or  tagname = '" & maxvalD & "'"
                    End If

                    Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn2)
                    Using reader As SqlDataReader = sqlcmd1.ExecuteReader
                        While reader.Read
                            If reader(0) = maxvalD Then
                                Max_value = reader(1)
                            ElseIf reader(0) = minvalD Then
                                Min_value = reader(1)
                            End If
                        End While
                    End Using
                    sqlcmd1.Dispose()
                    sql.scn2.Close()
                    ' temp = 1
                    'End If

                    'If TextBox1.Text >= variableclass.d(minvalD) * rgain And TextBox1.Text <= variableclass.d(maxvalD) * rgain Then
                    If TextBox1.Text >= Min_value / rgain And TextBox1.Text <= Max_value / rgain Then
                    Else
                        MsgBox("Enter Correct value in a range " & Min_value / rgain & " to " & Max_value / rgain & "")
                        TextBox1.Text = Label1.Text
                        TextBox1.Visible = False
                        Label1.Visible = True
                        Exit Sub
                    End If
                End If
            End If
            'first reson entered then move ahed
            If recordev.ToString = "WithMessageInAuditTrail" Then
                '      ev.insertscadaevent(Login_Register.empid, "Button Pressed", Login_Register.levelid, Me.RecordMessage, "", "", "", "", "", "", "", "", "Audittrail")
                '--popo messagebox for msg record
                If Label1.Text <> TextBox1.Text Then
                    Dim btnp As New EnterReason(Me.ParentForm.Name, Me.Name, Me.Location.X, Me.Location.Y, Label1.Text, TextBox1.Text, Me.RecordMessage, RecordActionMessage)
                    btnp.ShowDialog()
                    Label1.Text = vtw
                End If
            End If
            '  Dim x = TextBox1.Text * rgain
            If vtw = TextBox1.Text Then
                TextBox1.Visible = False
                TextBox1.Enabled = False
                Label1.Visible = True
                Exit Sub
            End If
            ' Write = 1
            '   vtw = TextBox1.Text * rgain
            Dim tempvtw = TextBox1.Text * rgain
            '--variableclass.wd(WriteAddress) = TextBox1.Text * rgain' this is used when for loop is used in an main form "compare" sub
            '-- writing through component
            Try
                If tempvtw >= -32768 And tempvtw <= 32767 Then
                    writeIndb(WriteAddress, tempvtw, tempvtw)

                Else
                    TextBox1.Text = Label1.Text
                    MessageBox.Show("Value Overflow", "Alert")
                    TextBox1.Visible = False
                    TextBox1.Enabled = False
                    Label1.Visible = True
                    Exit Sub
                End If

            Catch ex As ArithmeticException
                TextBox1.Text = Label1.Text
                MessageBox.Show("Value Overflow", "Alert")
            End Try

            If recordev.ToString = "DirectlyInAuditTrail" Then
                If Label1.Text <> TextBox1.Text Then
                    Dim ev As New eventlists
                    ev.insertscadaevent(Login_Register.empid, RecordActionMessage, Login_Register.levelid, RecordMessage, Label1.Text & " to " & TextBox1.Text, "", "", "", "", "", Login_Register.lotno, Login_Register.batchno, "Audittrail")
                End If
            End If
           
        End If
        TextBox1.Visible = False
        TextBox1.Enabled = False
        Label1.Visible = True

    End Sub

    'Sub writeIndb(ByVal address As Integer, ByVal value As String)
    '    Try
    '        sql.scon2()
    '        sql.scon3()
    '        Dim querystring As String = ""
    '        Dim select_query As String = "select Tag_id,value FROM Tag_detail_data where id = '1' "
    '        Dim cmd1 = New SqlCommand(select_query, sql.scn2)
    '        Dim reader As SqlDataReader = cmd1.ExecuteReader
    '        If reader.Read Then
    '            If IsDBNull(reader.Item("Tag_id")) = False Then
    '                If variableclass.is_encrypted Then
    '                    querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN  OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update Tag_detail_data set Tag_id = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'1'')) where id = 1 update Tag_detail_data set Tag_id = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & address & "')), value = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & value & "')) where id = 2 COMMIT TRANSACTION"
    '                Else
    '                    querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN update Tag_detail_data set Tag_id = '" & reader.Item(0) + 1 & "' where id = 1 update Tag_detail_data set Tag_id = '" & address & "', value = '" & value & "' where id = '" & reader.Item(0) + 1 & "' COMMIT TRANSACTION"
    '                End If
    '                Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
    '                sqlcmd1.ExecuteNonQuery()
    '                sqlcmd1.Dispose()
    '            Else
    '                If variableclass.is_encrypted Then
    '                    querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN  OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update Tag_detail_data set Tag_id = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'1'')) where id = 1 update Tag_detail_data set Tag_id = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & address & "')), value = EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & value & "')) where id = 2 COMMIT TRANSACTION"
    '                Else
    '                    querystring = "SET DEADLOCK_PRIORITY HIGH BEGIN TRAN update Tag_detail_data set Tag_id = '2' where id = 1 update Tag_detail_data set Tag_id = '" & address & "', value = '" & value & "' where id = 2 COMMIT TRANSACTION"
    '                End If
    '                Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
    '                sqlcmd1.ExecuteNonQuery()
    '                sqlcmd1.Dispose()

    '            End If
    '        End If
    '        cmd1.Dispose()
    '        sql.scn3.Close()
    '        sql.scn2.Close()
    '    Catch ex As Exception

    '    End Try
    'End Sub


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


    Sub write32bit()
        If IsNumeric(TextBox1.Text) Then
            If Comparisonval = True Then
                If Comparison_Typeval.ToString = "Direct" Then
                    If Double.Parse(TextBox1.Text) >= Minvalue And Double.Parse(TextBox1.Text) <= Maxvalue Then
                    Else
                        MsgBox("Enter Correct value in a range " & Minvalue & " to " & Maxvalue)
                        TextBox1.Text = Label1.Text
                        TextBox1.Visible = False
                        Label1.Visible = True
                        Exit Sub
                    End If
                End If
                If Comparison_Typeval.ToString = "InDirect" Then
                    Dim maxDadd, minDadd As Integer
                    sql.scon2()
                    '' Dim querystring As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select convert(varchar, decryptbykey(Tag_name)), tag_id from Tag_data where  convert(varchar, decryptbykey(Tag_name)) = '" & minvalD & "' or  convert(varchar, decryptbykey(Tag_name)) = '" & maxvalD & "'"
                    Dim querystring As String = ""
                    'for encrypted or  non_encypted tables
                    If variableclass.is_encrypted Then
                        querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select convert(varchar, decryptbykey(Tag_name)), tag_id from Tag_data where  convert(varchar, decryptbykey(Tag_name)) = '" & minvalD & "' or  convert(varchar, decryptbykey(Tag_name)) = '" & maxvalD & "'"

                    Else
                        querystring = "select Tag_name, tag_id from Tag_data where Tag_name = '" & minvalD & "' or  Tag_name = '" & maxvalD & "'"

                    End If

                    Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn2)
                    Using reader As SqlDataReader = sqlcmd1.ExecuteReader
                        While reader.Read
                            If reader(0) = maxvalD Then
                                maxDadd = reader(1)
                            ElseIf reader(0) = minvalD Then
                                minDadd = reader(1)
                            End If
                        End While
                    End Using
                    sqlcmd1.Dispose()
                    sql.scn2.Close()
                    Dim temp1 = readval(minDadd)
                    Dim temp2 = readval(maxDadd)
                    'gain se multiple ya divide krna hai ki nhi 
                    'MsgBox("min" & temp1 & "max " & temp2)
                    If TextBox1.Text >= (temp1 / rgain) And TextBox1.Text <= (temp2 / rgain) Then
                    Else
                        MsgBox("Enter Correct value in a range " & temp1 / rgain & " to " & temp2 / rgain)
                        TextBox1.Text = Label1.Text
                        TextBox1.Visible = False
                        Label1.Visible = True
                        Exit Sub
                    End If
                End If
            End If
            If recordev.ToString = "WithMessageInAuditTrail" Then
                '      ev.insertscadaevent(Login_Register.empid, "Button Pressed", Login_Register.levelid, Me.RecordMessage, "", "", "", "", "", "", "", "", "Audittrail")
                '--popo messagebox for msg record
                If Label1.Text <> TextBox1.Text Then
                    Dim btnp As New EnterReason(Me.ParentForm.Name, Me.Name, Me.Location.X, Me.Location.Y, Label1.Text, TextBox1.Text, Me.RecordMessage, RecordActionMessage)
                    btnp.ShowDialog()
                    Label1.Text = vtw
                End If
            End If
            If vtw = TextBox1.Text Then
                TextBox1.Visible = False
                TextBox1.Enabled = False
                Label1.Visible = True
                Exit Sub
            End If
            ' Write = 1
            Dim tempvtw = TextBox1.Text * rgain
            '32 bit to 16 bit converterssss
            Dim Byte_Arr(3) As Byte

            If variableclass.without_plc = False Then
                Try
                    Byte_Arr = BitConverter.GetBytes(Convert.ToInt32(tempvtw))
                    'this is used when for loop is used in an main form "compare" sub
                    '--variableclass.wd(WriteAddress) = BitConverter.ToInt16(Byte_Arr, 0)
                    '--variableclass.wd(WriteAddress + 1) = BitConverter.ToInt16(Byte_Arr, 2)
                    plcclass.write_single_DValue(WriteAddress, BitConverter.ToInt16(Byte_Arr, 0))

                    plcclass.write_single_DValue(WriteAddress + 1, BitConverter.ToInt16(Byte_Arr, 2))

                Catch ex As ArithmeticException
                    TextBox1.Text = Label1.Text
                    MessageBox.Show("Value Overflow", "Alert")
                End Try
            Else
                Try
                    Byte_Arr = BitConverter.GetBytes(Convert.ToInt32(tempvtw))
                    Dim value_to_write As String = BitConverter.ToInt16(Byte_Arr, 0) & "," & BitConverter.ToInt16(Byte_Arr, 2)
                    ' writeIndb(WriteAddress, value_to_write)
                    writeIndb(WriteAddress, value_to_write, tempvtw)
                Catch ex As ArithmeticException
                    TextBox1.Text = Label1.Text
                    MessageBox.Show("Value Overflow", "Alert")
                End Try
                'plcclass.write_single_DValue(WriteAddress, BitConverter.ToInt16(Byte_Arr, 0))
                'plcclass.write_single_DValue(WriteAddress + 1, BitConverter.ToInt16(Byte_Arr, 2))
            End If

            If recordev.ToString = "DirectlyInAuditTrail" Then
                If Label1.Text <> TextBox1.Text Then
                    Dim ev As New eventlists
                    ev.insertscadaevent(Login_Register.empid, RecordActionMessage, Login_Register.levelid, RecordMessage, Label1.Text & " to " & TextBox1.Text, "", "", "", "", "", Login_Register.lotno, Login_Register.batchno, "Audittrail")
                End If
            End If

        End If
        TextBox1.Visible = False
        TextBox1.Enabled = False

        Label1.Visible = True


    End Sub
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress

        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers
        '46 .
        '45 -


        If Val(Asc(e.KeyChar)) = 8 Or Asc(e.KeyChar) = 46 Or Asc(e.KeyChar) = 45 Then
        Else
            If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) Then
                e.Handled = True

            End If

        End If

    End Sub

    'on pressing enter write code executes and then on cell leave it executes 2nd time. only ek baar chle iss liye ye variable liya he
    Dim tempexecute = 0


    Private Sub TextBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Leave
        ' Label1.Text = TextBox1.Text

        'write to plc
        '       scada.write_to_plc(AxActUtlType1, plcaddress, Short.Parse(TextBox1.Text))
        If tempexecute = 0 Then
            If BIT_TYPE.ToString = "Bit16" Then
                write16bit()
            End If
            If BIT_TYPE.ToString = "Bit32" Then
                write32bit()
            End If
        Else
            tempexecute = 0
        End If

        TextBox1.Visible = False
        TextBox1.Enabled = False
        Label1.Visible = True
    End Sub

    Private Sub Label1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseClick, Me.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            '       Login_Register.levelid = 1
            If Login_Register.levelid = 1 Or Login_Register.levelid = Login_Register.mngr Then
                ''        '   Panel1.Visible = True
                '            ''                showselected(Me, Me.ParentForm)

                Dim btnp As New buttonproperty(Me.ParentForm.Name, Me.Name, Me.Location.X, Me.Location.Y)
                btnp.TopMost = True
                btnp.StartPosition = FormStartPosition.CenterParent
                btnp.showselected(Me, Me.ParentForm)
                '  btnp.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                '   btnp.Panel1.Location = Me.Location
                btnp.ShowDialog()
            End If
        Else
            If Readonly1 = False Then
                If control_enable = True Then
                    TextBox1.Text = Label1.Text
                    TextBox1.Visible = True
                    TextBox1.Enabled = True
                    TextBox1.Select()
                    '    tbox = True
                    Label1.Hide()
                Else
                    MessageBox.Show("Access Denied", "Alert")
                End If
            End If
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
    Dim tempdirect = 0
    Dim tempindirect = 0
    Function readval() As String

        visiblecode()

        If BIT_TYPE.ToString = "Bit16" Then
            vtw = Val(variableclass.tag(ReadAddress))
            Dim temp12
            If No_of_DecimalValues > 0 Then
                '  temp12 = FormatNumber(CDbl(variableclass.d(ReadAddress) / rgain), _decimalval)
                temp12 = FormatNumber(CDbl(Val(variableclass.tag(ReadAddress)) / rgain), _decimalval)
            Else
                ' temp12 = Val(variableclass.d(ReadAddress)) / rgain
                temp12 = Val(variableclass.tag(ReadAddress)) / rgain
                temp12 = Math.Round(Val(temp12))
            End If
            vtw = temp12
            text1 = temp12
            Return temp12
        Else
            vtw = Val(variableclass.tag(ReadAddress))
            Dim temp12
            If No_of_DecimalValues > 0 Then
                '  temp12 = FormatNumber(CDbl(variableclass.d(ReadAddress) / rgain), _decimalval)
                temp12 = FormatNumber(CDbl(Val(variableclass.tag(ReadAddress)) / rgain), _decimalval)
            Else
                ' temp12 = Val(variableclass.d(ReadAddress)) / rgain
                temp12 = Val(variableclass.tag(ReadAddress)) / rgain
                temp12 = Math.Round(Val(temp12))
            End If
            vtw = temp12
            text1 = temp12
            Return temp12
        End If
    End Function

    Function readval(ByVal add As Integer) As String
        If BIT_TYPE.ToString = "Bit16" Then
            ' Return variableclass.d(ReadAddress)
            Return Val(variableclass.tag(add))
        Else
            Return Val(variableclass.tag(add))
            'Dim t = 0
            'Dim value As Short

            'Dim ByteArr(3) As Byte
            'For i = 0 To 1
            '    'convert string value in to double because tag is an string type of array
            '    Short.TryParse(Val(variableclass.tag(add + i)), value)
            '    Dim Temp_Byte = BitConverter.GetBytes(value)
            '    ByteArr(i * 2) = Temp_Byte(0)
            '    ByteArr(i * 2 + 1) = Temp_Byte(1)
            'Next
            'Dim Temp_Int As Integer = BitConverter.ToInt32(ByteArr, 0)
            'Return Temp_Int
        End If
    End Function

    Private Sub UserControl1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Right Then
            '       Login_Register.levelid = 1
            If Login_Register.levelid = 1 Or Login_Register.levelid = Login_Register.mngr Then
                ''        '   Panel1.Visible = True
                '            ''                showselected(Me, Me.ParentForm)

                Dim btnp As New buttonproperty(Me.ParentForm.Name, Me.Name, Me.Location.X, Me.Location.Y)
                ' btnp.StartPosition = FormStartPosition.CenterParent

                btnp.TopMost = True
                btnp.showselected(Me, Me.ParentForm)
                '    btnp.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                '   btnp.Panel1.Location = Me.Location
                btnp.ShowDialog()
            End If
        Else
            If Readonly1 = False Then
                TextBox1.Text = Label1.Text
                TextBox1.Visible = True
                TextBox1.Enabled = True
                TextBox1.Select()
                '   tbox = True
                Label1.Hide()
            End If
        End If
    End Sub


    Dim getvissibleaddress = 0
    Dim pvisible As Boolean
    Dim penable As Boolean
    Public Sub propertyvisiblecode()
        'Dim cst = "::11:00:00"
        'Dim cspt = "::11:00:00"
        'Dim time = Datse(cspt)
        'Dim temp = time2.Subtract(time)eTime.Parse(cst)
        'Dim time2 = DateTime.Par
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

    'used instead of disabling control to show message of acess denied
    Dim control_enable As Boolean = True

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
                            ' Me.Enabled = True
                            control_enable = True
                            tempenable = 1
                        End If
                    Else
                        If tempenable = 1 Or tempenable = 0 Then
                            ' renable = False
                            'Me.Enabled = False
                            control_enable = False
                            tempenable = 2
                        End If

                    End If

                Else

                    If tempenable = 1 Or tempenable = 0 Then
                        '  renable = False
                        '  Me.Enabled = False
                        control_enable = False
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

        If temptimer = 0 Then
            If recordtime > 0 Then
                Timer1.Enabled = True
                Timer1.Interval = recordtime * 1000
                temptimer = 1
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
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If recordda.ToString = "InsertAlways" Then
            updatedata_insertquery()
        End If
        If recordda.ToString = "UpdateAlways" Then
            updatedata_updatequery()
        End If
    End Sub

    'this function insert numeric entry value in database after a given time interval
    Public Sub updatedata_insertquery()

        '  Dim sqlcon As SqlConnection = New SqlConnection With {.ConnectionString = "server=" & server & "; Database= " & dbname & ";user id= " & dbid & ";password=" & dbpass & ";"}

        ' sqlcon = New SqlConnection With {.ConnectionString = "server=.\sqlexpress; Database= Pharma;user id= rmsview;password=rmsview;"}
        Try
            sql.conn3()
            Dim sqlquery = ""
            If recorddataencrypted.ToString = "Yes" Then
                sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into componentdata_encrypted(c_id,c_name,c_value,c_type,c_date,c_time) values('" & Me.plc_id & "', EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & HeaderText & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & text1 & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Me.GetType.ToString & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.timee & "')))"
            Else
                sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into componentdata_unencrypted(c_id,c_name,c_value,c_type,c_date,c_time) values('" & Me.plc_id & "', '" & headertxt & "','" & text1 & "','" & Me.GetType.ToString & "','" & variableclass.datee & "','" & variableclass.timee & "')"
            End If

            Dim cmd = New SqlCommand(sqlquery, sql.cn3)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            sql.cn3.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    ' this function update values in database 
    Public Sub updatedata_updatequery()
        Try
            sql.conn3()
            sql.conn1()
            Dim tempsqlquery = ""
            If recorddataencrypted.ToString = "Yes" Then
                tempsqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Convert(varchar, DecryptByKey(c_name)) from componentdata_encrypted where CONVERT(varchar, DecryptByKey(c_name))='" & Me.headertxt & "' and CONVERT(varchar, DecryptByKey(c_type))='" & Me.GetType().ToString & "' and c_id='" & Me.plc_id & "'"
            Else
                tempsqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select c_name from componentdata_unencrypted where c_name='" & Me.headertxt & "' and c_type='" & Me.GetType().ToString & "' and c_id='" & Me.plc_id & "'"

            End If
            Dim cmd1 = New SqlCommand(tempsqlquery, sql.cn3)
            Dim sqlreader As SqlDataReader = cmd1.ExecuteReader
            If sqlreader.Read = True Then
                Dim sqlquery = ""
                If recorddataencrypted.ToString = "Yes" Then
                    sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update componentdata_encrypted set c_value=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & text1 & "')),c_date=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.datee & "')),c_time=EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & variableclass.timee & "'))  where CONVERT(varchar, DecryptByKey(c_name))='" & Me.headertxt & "' and c_id='" & Me.plc_id & "'"
                Else
                    sqlquery = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 update componentdata_unencrypted set c_value= '" & text1 & "',c_date='" & variableclass.datee.ToString & "',c_time='" & variableclass.timee.ToString & "'  where c_name='" & Me.headertxt & "' and c_id='" & Me.plc_id & "'"

                End If
                Dim sqlqueryvalues = ""

                Dim cmd = New SqlCommand(sqlquery, sql.cn1)
                cmd.ExecuteNonQuery()
                ' MsgBox(sqlquery)
                cmd.Dispose()
                sql.cn1.Close()

            Else
                sqlreader.Close()
                updatedata_insertquery()

            End If
            sqlreader.Close()
            sql.cn3.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub getdatamodbus(ByVal tagname As String)
        sql.conn2()
        Dim cmd1 = New SqlCommand("select top 1 Convert(varchar, DecryptByKey(c_value)) from componentdata where CONVERT(varchar, DecryptByKey(c_name))='" & tagname & "' order by convert(c_date, Convert(varchar, DecryptByKey(c_date))) desc, convert(c_time, Convert(varchar, DecryptByKey(c_time))) desc", sql.cn2)
        Dim sqlreader As SqlDataReader = cmd1.ExecuteReader
        If sqlreader.Read Then
            text1 = sqlreader.Item(0)
            'uncomment the below code to apply read gain on  numeric entry
            'If No_of_DecimalValues > 0 Then
            '    temp12 = FormatNumber(CDbl(Temp_Int / rgain), _decimalval)
            'Else
            '    temp12 = Temp_Int / rgain
            'End If
            'vtw = temp12
        End If
        sqlreader.Close()
        sql.cn2.Close()
    End Sub
End Class
