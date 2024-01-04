Imports System.ComponentModel
Imports System.Data.SqlClient
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
Imports System.Windows.Forms.PictureBox
Imports System
Imports System.Globalization
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Text
Imports System.IO
Imports System.Drawing.Design
Imports System.Windows.Forms.Design

Public Class multistate_lamp
    Public Enum Button_type
        Momentary
        _Set
        Reset
        Toggle
        Banner
    End Enum
    Public Enum Record_Event
        DirectlyInAuditTrail
        WithMessageInAuditTrail
        NO
    End Enum
    Public Event action()
    Dim sql As New sqlclass
    Dim value As Integer
    ' Dim offcolor As Color = Color.Red
    ' Dim oncolor As Color = Color.LawnGreen
    ' Dim offimage As Image
    ' Dim onimage As Image
    ' Dim ontext As String = "1"
    ' Dim offtext As String = "0"
    Public Shared plcwriteaddress As Integer = 0
    Public Shared plcreadaddress As Integer = 0
    Dim ev As New eventlists
    Dim recordflag As Integer = 1
    Public pd = 0
    Public pdf = 0
    Public pu = 0

   

    Dim TextonIndex As New List(Of lamp_state)

    <Browsable(True), Category("_Misc"), _
EditorBrowsable(EditorBrowsableState.Always), _
DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Property Define_lamp_state As List(Of lamp_state)    'any message to display in report table
        Get
            Return TextonIndex
        End Get
        Set(ByVal value As List(Of lamp_state))
            TextonIndex = value
        End Set
    End Property


    'try 2 method for generating dynamic enum

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
    Dim b_type As Button_type
    <Category("_Misc"), Description("Set type of control")>
    Property Buttontype As Button_type
        Get
            Return b_type
        End Get
        Set(ByVal value As Button_type)
            b_type = value

        End Set
    End Property


    Dim msg As String = ""
    <Category("_MESSAGE"), Description("The description that will be recorded in audit report on operating control")>
    Property RecordMessage As String
        Get
            Return msg
        End Get
        Set(ByVal value As String)
            msg = value
        End Set
    End Property
    Dim btntypemsg As String = ""
    <Browsable(True), _
Category("_MESSAGE"), Description("Description of change occured by operating control to record in audit report")> _
    Property ButtonTypeRecordMessage As String
        Get
            Return btntypemsg
        End Get
        Set(ByVal value As String)
            btntypemsg = value
        End Set
    End Property
    Dim togglesetmsg As String = ""
    <Browsable(True), _
Category("_MESSAGE"), Description("Description of change occured when toggle control is set on to record in audit reoprt")> _
    Property ToggleSetRecordMessage As String
        Get
            Return togglesetmsg
        End Get
        Set(ByVal value As String)
            togglesetmsg = value
        End Set
    End Property
    Dim toggleresetmsg As String = ""
    <Browsable(True), _
Category("_MESSAGE"), Description("Description of change occured when toggle control is set off to record in audit reoprt")> _
    Property ToggleReSetRecordMessage As String
        Get
            Return toggleresetmsg
        End Get
        Set(ByVal value As String)
            toggleresetmsg = value
        End Set
    End Property


    Dim tbackc As Color
    <Browsable(False), Category("_Misc"), Description("The background color to display text on control")>
    Property TextBackcolor As Color
        Get
            Return tbackc
        End Get
        Set(ByVal value As Color)
            tbackc = value
            Label2.BackColor = value
        End Set
    End Property
    Dim defaulttext As String = "Text"
    <Category("_Misc"), Description("Default text associated with control")>
    Property Default_Text As String
        Get
            Return defaulttext

        End Get
        Set(ByVal VALUE As String)
            defaulttext = VALUE
            Label2.Text = VALUE
        End Set
    End Property

    Dim defaultcolor As Color
    <Category("_Misc")>
    Property Default_back_Color As Color
        Get
            Return defaultcolor

        End Get
        Set(ByVal value As Color)
            defaultcolor = value
            Button1.BackColor = value
        End Set
    End Property

    '<Category("_Misc"), Description("Text associated with control when control is on")>
    'Property ButtonOnText As String
    '    Get
    '        Return ontext

    '    End Get
    '    Set(ByVal VALUE As String)
    '        ontext = VALUE
    '        If btnval = True Then
    '            Label2.Text = ontext
    '        End If

    '    End Set
    'End Property
    '<Category("_Misc"), Description("Text associated with control when control is off")>
    'Property ButtonOffText As String
    '    Get

    '        Return offtext

    '    End Get
    '    Set(ByVal VALUE As String)
    '        offtext = VALUE
    '        If btnval = False Then
    '            Label2.Text = offtext
    '        End If

    '    End Set
    'End Property
    '<Category("_Misc"), Description("Background color of control when control is off")>
    'Property ButtonOffBackcolor As Color
    '    Get

    '        Return offcolor

    '    End Get
    '    Set(ByVal value As Color)
    '        ' Button1.BackColor = value
    '        offcolor = value
    '        If btnval = False Then
    '            Button1.BackColor = offcolor
    '        End If

    '    End Set
    'End Property
    '<Category("_Misc"), Description("Background color of control when control is on")>
    'Property ButtonONBackcolor As Color
    '    Get

    '        Return oncolor

    '    End Get
    '    Set(ByVal value As Color)
    '        'Button1.BackColor = value
    '        oncolor = value
    '        If btnval = True Then
    '            Button1.BackColor = oncolor
    '        End If

    '    End Set
    'End Property
    Dim Actionmsg As String
    <Category("_MESSAGE"), Description("Description of action perform by control to record in audit report")>
    Property RecordActionMessage As String
        Get
            Return Actionmsg
        End Get
        Set(ByVal value As String)
            Actionmsg = value
        End Set
    End Property
    'address is plc address

    Dim radd As Integer = 0
    <Browsable(False), _
Category("_ADDRESS")> _
    Property ReadAddress As Integer
        Get
            Return radd
        End Get
        Set(ByVal value As Integer)
            radd = value
            '   wadd = value
        End Set
    End Property
    '-- banner visible address m 


    'address is plc address
    Dim wadd As Integer = 0
    <Browsable(False), _
Category("_ADDRESS")> _
    Property WriteAddress As Integer
        Get
            Return wadd
        End Get
        Set(ByVal value As Integer)
            wadd = value
            '  radd = value
        End Set
    End Property
    Dim read_tag_name As String
    <Browsable(True), _
Category("_ADDRESS"), Description("The tag from which control read value")> _
    Property Read_TagName As String
        Get
            Return read_tag_name

        End Get
        Set(ByVal tag As String)
            read_tag_name = tag
            'writeadd = VALUE
        End Set

    End Property
    Dim write_tag_name As String
    <Browsable(True), _
Category("_ADDRESS"), Description("The tag on which control writes")> _
    Property Write_TagName As String
        Get
            Return write_tag_name

        End Get
        Set(ByVal tag As String)
            ' GenerateEnumerations("tagnamelist")
            write_tag_name = tag
            'writeadd = VALUE
        End Set

    End Property
    'Dim pev As Integer = 0
    ''States the state of button
    ''0- not pressed not state
    ''1-Mouse Down
    ''2-Mouse Up
    'Property pressevent As Integer
    '    Get
    '        Return pev
    '    End Get
    '    Set(ByVal value As Integer)
    '        pev = value
    '    End Set
    'End Property
    'States the whether button is used as button or lamp
    'in case of lamp readonly is true else false
    Dim read1 As Boolean = True
    <Category("_Misc"), Description("Indicates whether the control is enabled or not")>
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


    '  <Editor(GetType(MyClassEditor), GetType(UITypeEditor))>
    ''Dim path_default_image As String
    ''<Editor(GetType(MyFileNameEditor1), GetType(System.Drawing.Design.UITypeEditor)), Browsable(True), Category("_Misc"), DisplayName("ButtonOnImage"), RefreshProperties(RefreshProperties.All)> _
    ''<TypeConverter(GetType(MyConverter1))>
    ''Property Default_image() As String
    ''    Get
    ''        Return path_default_image
    ''    End Get
    ''    Set(ByVal value As String)
    ''        path_default_image = value
    ''    End Set
    ''End Property



    ''Dim button_image As Image
    ''<Browsable(False), Category("_Misc"), Description("Background image when control is off")>
    ''Property ButtonImage As Image
    ''    Get

    ''        Return button_image
    ''        Button1.SizeMode = PictureBoxSizeMode.StretchImage

    ''    End Get
    ''    Set(ByVal value As Image)
    ''        '   Button1.Image = value
    ''        Button1.SizeMode = PictureBoxSizeMode.StretchImage
    ''        button_image = value
    ''        Button1.Image = value
    ''    End Set
    ''End Property


    'Dim pathoffimage As String
    '<Editor(GetType(MyFileNameEditor), GetType(System.Drawing.Design.UITypeEditor)), Browsable(True), Category("_Misc"), DisplayName("ButtonOffImage"), RefreshProperties(RefreshProperties.All)> _
    ' <TypeConverter(GetType(MyConverter))>
    'Property Imageoff() As String
    '    Get
    '        Return pathoffimage
    '    End Get
    '    Set(ByVal value As String)
    '        pathoffimage = value
    '    End Set
    'End Property

    '<Browsable(False), Category("_Misc"), Description("Background image when control is on")>
    'Property ButtonOFFImage As Image
    '    Get

    '        Return offimage
    '        Button1.SizeMode = PictureBoxSizeMode.StretchImage

    '    End Get
    '    Set(ByVal value As Image)
    '        ' Button1.Image = value
    '        Button1.SizeMode = PictureBoxSizeMode.StretchImage
    '        offimage = value
    '        ' If btnval = False Then
    '        'Button1.Image = offimage
    '        ' End If

    '    End Set
    'End Property


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
    Dim directvisibleval As Boolean = True
    <Browsable(True), _
Category("_VISIBLE"), Description("Determines whether the control is visible or hidden")> _
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
Category("_VISIBLE"), Description("Determines the condition to set control visible or hidden")> _
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
    Dim Address_of_M As Integer = 0
    Dim Vissible_tagname As String = ""
    <Browsable(True), _
Category("_VISIBLE"), Description("The tag which determines whether the control is visible or hidden")> _
    Property Visible_Tag As String

        Get
            Return Vissible_tagname
        End Get
        Set(value As String)
            Vissible_tagname = value

        End Set
    End Property
    Dim rw As Boolean = False
    <Browsable(False), _
Category("LIMITS")> _
    Property readwrite As Boolean
        Get
            Return rw
        End Get
        Set(ByVal value As Boolean)
            rw = value
            If rw = True Then
                'Me.Enabled = False
                '     read1 = False
            End If
        End Set
    End Property

    ' Dim t = 0 
    ' Dim t = 0 
    Private Sub Button1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseDown, Label1.MouseDown, Button1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If Login_Register.levelid = 1 Or Login_Register.levelid = Login_Register.mngr Then
                Dim btnp As New buttonproperty(Me.ParentForm.Name, Me.Name, Me.Location.X, Me.Location.Y)
                btnp.TopMost = True
                btnp.StartPosition = FormStartPosition.CenterParent
                btnp.showselected(Me, Me.ParentForm)
                btnp.ShowDialog()

            End If
        Else
            mouse_down()
        End If

    End Sub


    Sub mouse_down()
        If read1 = False Then
            If pushbutton_enable = True Then

                If b_type.ToString = "Momentary" Then

                    pd = 1
                    '   pev = 1
                    Button1.BorderStyle = BorderStyle.Fixed3D
                    Button1.SizeMode = PictureBoxSizeMode.StretchImage
                Else
                    Button1.BorderStyle = BorderStyle.Fixed3D
                    Button1.SizeMode = PictureBoxSizeMode.StretchImage
                End If
                If b_type.ToString = "_Set" Then
                    If recordev.ToString = "WithMessageInAuditTrail" Then
                        '      ev.insertscadaevent(Login_Register.empid, "Button Pressed", Login_Register.levelid, Me.RecordMessage, "", "", "", "", "", "", "", "", "Audittrail")
                        '--popo messagebox for msg record
                        Dim m As New buttonrecordmsg(ButtonTypeRecordMessage, RecordMessage, RecordActionMessage)
                        m.TopMost = True
                        m.StartPosition = FormStartPosition.CenterParent
                        m.ShowDialog()

                    End If
                    'variableclass.wm(WriteAddress) = 1
                    If variableclass.without_plc = False Then
                        plcclass.wrtie_m_singlevalue(WriteAddress, 1)
                    Else
                        writeIndb(WriteAddress, 1, 1)
                        '--variableclass.m(WriteAddress) = 1
                    End If

                    If recordev.ToString = "DirectlyInAuditTrail" Then
                        ev.insertscadaevent(Login_Register.empid, RecordActionMessage, Login_Register.levelid, Me.RecordMessage, ButtonTypeRecordMessage, "", "", "", "", "", Login_Register.lotno, Login_Register.batchno, "Audittrail")
                    End If

                End If
                If b_type.ToString = "Reset" Then
                    'variableclass.wm(WriteAddress) = 0
                    If recordev.ToString = "WithMessageInAuditTrail" Then
                        '      ev.insertscadaevent(Login_Register.empid, "Button Pressed", Login_Register.levelid, Me.RecordMessage, "", "", "", "", "", "", "", "", "Audittrail")
                        '--popo messagebox for msg record
                        Dim m As New buttonrecordmsg(ButtonTypeRecordMessage, RecordMessage, RecordActionMessage)
                        m.TopMost = True
                        m.StartPosition = FormStartPosition.CenterParent
                        m.ShowDialog()

                    End If
                    ' RaiseEvent action()
                    If variableclass.without_plc = False Then
                        plcclass.wrtie_m_singlevalue(WriteAddress, 0)

                    Else
                        writeIndb(WriteAddress, 0, 0)
                    End If
                    
                    If recordev.ToString = "DirectlyInAuditTrail" Then
                        ev.insertscadaevent(Login_Register.empid, RecordActionMessage, Login_Register.levelid, Me.RecordMessage, ButtonTypeRecordMessage, "", "", "", "", "", Login_Register.lotno, Login_Register.batchno, "Audittrail")
                    End If

                End If
            Else
                MessageBox.Show("Access Denied", "Alert")
            End If
        End If
    End Sub





    Private Sub Button1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseUp, Label1.MouseUp, Button1.MouseUp
        '   If t = 1 Then
        If e.Button = Windows.Forms.MouseButtons.Right Then
        Else
            mouse_up()
        End If
    End Sub

    Sub mouse_up()
        If read1 = False Then
            If pushbutton_enable = True Then

                If b_type.ToString = "Momentary" Then
                    pu = 1
                    '  pev = 2
                    Button1.BorderStyle = BorderStyle.None
                    ' Button1.BackColor = Color.GreenYellow
                    'Timer1.Enabled = False
                    ' value = 0
                    '   Label1.Text = offtext
                    '    Button1.BackColor = Me.ButtonOffBackcolor
                    '    Button1.Image = Me.ButtonOFFImage
                    'recordflag = Recordvalue
                    'If recordflag > 0 Then
                    '    ev.insertscadaevent(Login_Register.empid, "Button Pressed", Login_Register.levelid, Me.RecordMessage, "", "", "", "", "", "", "", "", "Audittrail")
                    'End If
                    RaiseEvent action()
                    If recordev.ToString = "DirectlyInAuditTrail" Then
                        ev.insertscadaevent(Login_Register.empid, RecordActionMessage, Login_Register.levelid, Me.RecordMessage, ButtonTypeRecordMessage, "", "", "", "", "", Login_Register.lotno, Login_Register.batchno, "Audittrail")
                    End If
                    If recordev.ToString = "WithMessageInAuditTrail" Then
                        '      ev.insertscadaevent(Login_Register.empid, "Button Pressed", Login_Register.levelid, Me.RecordMessage, "", "", "", "", "", "", "", "", "Audittrail")
                        '--popo messagebox for msg record
                        Dim m As New buttonrecordmsg(ButtonTypeRecordMessage, RecordMessage, RecordActionMessage)
                        m.TopMost = True
                        m.StartPosition = FormStartPosition.CenterParent
                        m.ShowDialog()
                    End If
                    Button1.SizeMode = PictureBoxSizeMode.StretchImage
                Else
                    Button1.BorderStyle = BorderStyle.None
                    ' Button1.BackColor = Color.GreenYellow
                    'Timer1.Enabled = False
                    ' value = 0
                    '   Label1.Text = offtext
                    '    Button1.BackColor = Me.ButtonOffBackcolor
                    '    Button1.Image = Me.ButtonOFFImage
                    Button1.SizeMode = PictureBoxSizeMode.StretchImage
                End If
                '    Me.Enabled = False

                Dim temp4 = 0
                If b_type.ToString = "Toggle" Then
                    ' If variableclass.m(WriteAddress) = 1 Then
                    If Val(variableclass.tag(WriteAddress)) = 1 Then
                        If temp4 = 0 Then
                            RaiseEvent action()
                            If recordev.ToString = "WithMessageInAuditTrail" Then
                                '      ev.insertscadaevent(Login_Register.empid, "Button Pressed", Login_Register.levelid, Me.RecordMessage, "", "", "", "", "", "", "", "", "Audittrail")
                                '--popo messagebox for msg record
                                Dim m As New buttonrecordmsg(ToggleReSetRecordMessage, RecordMessage, RecordActionMessage)
                                m.TopMost = True
                                m.StartPosition = FormStartPosition.CenterParent
                                m.ShowDialog()

                            End If
                            ' plcclass.wrtie_m_singlevalue(WriteAddress, 0)
                            If variableclass.without_plc = False Then
                                plcclass.wrtie_m_singlevalue(WriteAddress, 0)

                            Else
                                '--variableclass.m(WriteAddress) = 0
                                writeIndb(WriteAddress, 0, 0)
                            End If
                            '--variableclass.wm(WriteAddress) = 0  'this is used when for loop is used in an main form "compare" sub

                            'recordflag = Recordvalue
                            'If recordflag > 0 Then
                            '    ev.insertscadaevent(Login_Register.empid, "Button Pressed", Login_Register.levelid, Me.RecordMessage, "", "", "", "", "", "", AuditTrail.lotn, AuditTrail.batchat, "Audittrail")
                            'End If
                            If recordev.ToString = "DirectlyInAuditTrail" Then
                                ev.insertscadaevent(Login_Register.empid, RecordActionMessage, Login_Register.levelid, Me.RecordMessage, ToggleReSetRecordMessage, "", "", "", "", "", Login_Register.lotno, Login_Register.batchno, "Audittrail")
                            End If

                            temp4 = 1
                        End If

                    End If
                    ' If variableclass.m(WriteAddress) = 0 Then
                    If Val(variableclass.tag(WriteAddress)) = 0 Then
                        If temp4 = 0 Then
                            '--variableclass.wm(WriteAddress) = 1 'this is used when for loop is used in an main form "compare" sub
                            If recordev.ToString = "WithMessageInAuditTrail" Then
                                '      ev.insertscadaevent(Login_Register.empid, "Button Pressed", Login_Register.levelid, Me.RecordMessage, "", "", "", "", "", "", "", "", "Audittrail")
                                '--popo messagebox for msg record
                                Dim m As New buttonrecordmsg(ToggleSetRecordMessage, RecordMessage, RecordActionMessage)
                                m.TopMost = True
                                m.StartPosition = FormStartPosition.CenterParent
                                m.ShowDialog()

                            End If
                            If variableclass.without_plc = False Then
                                plcclass.wrtie_m_singlevalue(WriteAddress, 1)

                            Else
                                writeIndb(WriteAddress, 1, 1)
                                '-- variableclass.m(WriteAddress) = 1
                            End If
                            ' RaiseEvent action()
                            'recordflag = Recordvalue
                            'If recordflag > 0 Then
                            '    ev.insertscadaevent(Login_Register.empid, "Button Pressed", Login_Register.levelid, Me.RecordMessage, "", "", "", "", "", "", AuditTrail.lotn, AuditTrail.batchat, "Audittrail")
                            'End If

                            If recordev.ToString = "DirectlyInAuditTrail" Then
                                ev.insertscadaevent(Login_Register.empid, RecordActionMessage, Login_Register.levelid, Me.RecordMessage, ToggleSetRecordMessage, "", "", "", "", "", Login_Register.lotno, Login_Register.batchno, "Audittrail")
                            End If
                            RaiseEvent action()

                            temp4 = 1
                        End If

                    End If
                ElseIf b_type.ToString = "_Set" Then
                    RaiseEvent action()
                ElseIf b_type.ToString = "Reset" Then
                    RaiseEvent action()
                End If
                '       Me.Enabled = True
            Else
                MessageBox.Show("Access Denied", "Alert")
            End If
        End If
        '        Button1.BorderStyle = BorderStyle.None

    End Sub


    'array of images
    ''  Dim imgarray() As Image

    Private Sub buttonrightclick_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'check wheater image path is given or not
        '' Try

        ''    ReDim imgarray(Define_lamp_state.Count - 1)

        ''For i = 0 To Define_lamp_state.Count - 1
        ''    If Define_lamp_state(i).image_on_value <> "" Then
        ''        Dim myresourcefullPath As String
        ''        '    Dim startuppath As String
        ''        Dim savepath As String
        ''        'getting file name from given path
        ''        Dim _filename As String = System.IO.Path.GetFileName(Define_lamp_state(i).image_on_value)
        ''        'configure proper resource folder path
        ''        myresourcefullPath = Path.GetFullPath(My.Resources.ResourceManager.BaseName)

        ''        myresourcefullPath = myresourcefullPath.Substring(0, myresourcefullPath.Length - 24) & "Resource\"
        ''        ' MessageBox.Show(myresourcefullPath)
        ''        '    startuppath = Application.StartupPath & "\resource\"
        ''        '     If startuppath = myresourcefullPath Then
        ''        savepath = myresourcefullPath & _filename
        ''        '   Else
        ''        '  savepath = myresourcefullPath & _filename
        ''        '   End If

        ''        '   MessageBox.Show(savepath)
        ''        'check if file already exist or not
        ''        If System.IO.File.Exists(savepath) Then
        ''            'The file exists

        ''            '  MessageBox.Show("Exist")
        ''        Else

        ''            Dim file = New FileInfo(Define_lamp_state(i).image_on_value)
        ''            file.CopyTo(Path.Combine(myresourcefullPath, file.Name), True)
        ''            'IO.File.Copy(_filename, IO.Path.Combine(myresourcefullPath, _filename))

        ''            'the file doesn't exist
        ''            '  MessageBox.Show("Not Exist")
        ''        End If
        ''        imgarray(i) = System.Drawing.Image.FromFile(savepath)
        ''    End If
        ''Next
        ' '' Button1.Image = 


        ''If path_default_image <> "" Then
        ''    ' path of resource folder
        ''    Dim myresourcefullPath As String
        ''    '    Dim startuppath As String
        ''    Dim savepath As String
        ''    'getting file name from given path
        ''    Dim _filename As String = System.IO.Path.GetFileName(path_default_image)
        ''    'configure proper resource folder path
        ''    myresourcefullPath = Path.GetFullPath(My.Resources.ResourceManager.BaseName)

        ''    myresourcefullPath = myresourcefullPath.Substring(0, myresourcefullPath.Length - 24) & "Resource\"
        ''    ' MessageBox.Show(myresourcefullPath)
        ''    '    startuppath = Application.StartupPath & "\resource\"
        ''    '     If startuppath = myresourcefullPath Then
        ''    savepath = myresourcefullPath & _filename
        ''    '   Else
        ''    '  savepath = myresourcefullPath & _filename
        ''    '   End If

        ''    '   MessageBox.Show(savepath)
        ''    'check if file already exist or not
        ''    If System.IO.File.Exists(savepath) Then
        ''        'The file exists

        ''        '  MessageBox.Show("Exist")
        ''    Else

        ''        Dim file = New FileInfo(path_default_image)
        ''        file.CopyTo(Path.Combine(myresourcefullPath, file.Name), True)
        ''        'IO.File.Copy(_filename, IO.Path.Combine(myresourcefullPath, _filename))

        ''        'the file doesn't exist
        ''        '  MessageBox.Show("Not Exist")
        ''    End If
        ''    button_image = System.Drawing.Image.FromFile(savepath)

        ''    Me.ButtonImage = button_image
        ''    '  MessageBox.Show(path1 & " -- " & myresourcefullPath & " -- " & _filename)
        ''    '  Dim MyImage As Image = Image.FromFile(savepath)
        ''End If

        'If pathoffimage <> "" Then
        '    ' path of resource folder
        '    Dim myresourcefullPath As String
        '    '    Dim startuppath As String
        '    Dim savepath As String
        '    'getting file name from given path
        '    Dim _filename As String = System.IO.Path.GetFileName(pathoffimage)
        '    'configure proper resource folder path
        '    myresourcefullPath = Path.GetFullPath(My.Resources.ResourceManager.BaseName)

        '    myresourcefullPath = myresourcefullPath.Substring(0, myresourcefullPath.Length - 24) & "Resource\"
        '    '  MessageBox.Show(myresourcefullPath)
        '    '    startuppath = Application.StartupPath & "\resource\"
        '    '     If startuppath = myresourcefullPath Then
        '    savepath = myresourcefullPath & _filename
        '    '   Else
        '    '  savepath = myresourcefullPath & _filename
        '    '   End If

        '    '   MessageBox.Show(savepath)
        '    'check if file already exist or not
        '    If System.IO.File.Exists(savepath) Then
        '        'The file exists

        '        '  MessageBox.Show("Exist")
        '    Else

        '        Dim file = New FileInfo(pathoffimage)
        '        file.CopyTo(Path.Combine(myresourcefullPath, file.Name), True)
        '        'IO.File.Copy(_filename, IO.Path.Combine(myresourcefullPath, _filename))

        '        'the file doesn't exist
        '        '  MessageBox.Show("Not Exist")
        '    End If
        '    Me.ButtonOFFImage = System.Drawing.Image.FromFile(savepath)
        '    '  MessageBox.Show(path1 & " -- " & myresourcefullPath & " -- " & _filename)
        '    '  Dim MyImage As Image = Image.FromFile(savepath)
        'End If
        ''  Catch ex As Exception
        ' MessageBox.Show(ex.Message)
        ''    End Try



        If Login_Register.levelid IsNot Nothing And Login_Register.levelid > 0 Then
            rightread(Me, Me.ParentForm)
            'showselected(Me, Me.ParentForm)
        Else
            ' If readonly1 Then
            pushbutton_enable = True
            'Me.Enabled = True
            '   Me.Visible = False
            ' Else
            ' Me.Enabled = True
        End If
        Label1.Parent = Button1
        '   PictureBox1.Controls.Add(Label2)
        '  Label2.
        Button1.SendToBack()
        Label1.BackColor = Color.Transparent
        Label1.BringToFront()
        Label1.Size = Button1.Size
        '    Label2.Location = New Point(PictureBox1.Width / 2, PictureBox1.Height / 2)

        Label1.Location = New Point(0, 0)
        Label2.Parent = Label1


        '     

        Label1.Text = ""
        '   Label2.Parent = Label1
        ' Label2.BringToFront()

        Label2.Location = New Point(Label1.Width / 2 - Label2.Width / 2, Label1.Height / 2 - Label2.Height / 2)
        Label2.BringToFront()
        '  Button1.Controls.Add(Label1)

        ' Button1.MouseLeave += New EventHandler(button_leave)


    End Sub
    <BrowsableAttribute(False)>
    Public Overloads Property Capture As Boolean
    'Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    deleteEntries() 'Deleting old properties of control 
    '    ' InsertEntries()
    '    ev.insertscadaevent(Login_Register.empid, "Button Rights Edited", Login_Register.levelid, Me.Name, "", "", "", "", "", "", "", "", Login_Register.actionname(0))
    '    MsgBox("Changes made Successfully")
    '    ' Panel1.Visible = False
    'End Sub
    ''Private Sub deleteEntries()
    ''    Dim query As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 delete from controlrights where CONVERT(varchar, DecryptByKey(formname))='" & Me.ParentForm.Name & "' and CONVERT(varchar, DecryptByKey(controlname))='" & Me.Name & "'"
    ''    sql.con2()
    ''    Dim sqlcmd As SqlCommand = New SqlCommand(query, sqlclass.sqlcon)
    ''    sqlcmd.ExecuteNonQuery()
    ''    sqlcmd.Dispose()

    ''    sqlclass.cnn2.Close()


    ''End Sub
    ' ''Private Sub InsertEntries()
    '    sql.con2()
    '    Dim query As String
    '    For i = 0 To ListBox1.Items.Count - 1

    '        If ListBox1.SelectedItems.Contains(ListBox1.Items(i)) Then

    '            query = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into controlrights values ((select levelid from leveldetails where CONVERT(varchar, DecryptByKey(levelname))='" & ListBox1.Items(i) & "'),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Me.ParentForm.Name & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Me.Name & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'True')),1)"
    '            sqlqueryexecute(query)
    '        Else
    '            query = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into controlrights values ((select levelid from leveldetails where CONVERT(varchar, DecryptByKey(levelname))='" & ListBox1.Items(i) & "'),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Me.ParentForm.Name & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Me.Name & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'False')),1)"
    '            sqlqueryexecute(query)
    '        End If


    '    Next
    '    For i = 0 To ListBox2.Items.Count - 1

    '        If ListBox2.SelectedItems.Contains(ListBox2.Items(i)) Then

    '            query = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into controlrights values ((select levelid from leveldetails where CONVERT(varchar, DecryptByKey(levelname))='" & ListBox2.Items(i) & "'),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Me.ParentForm.Name & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Me.Name & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'True')),2)"
    '            sqlqueryexecute(query)
    '        Else
    '            query = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 insert into controlrights values ( (select levelid from leveldetails where CONVERT(varchar, DecryptByKey(levelname))='" & ListBox2.Items(i) & "'),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Me.ParentForm.Name & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'" & Me.Name & "')),EncryptByKey( Key_GUID('SymmetricKey1'), CONVERT(varchar,'False')),2)"
    '            sqlqueryexecute(query)
    '        End If


    '    Next

    '    'Dim sqlcmd As SqlCommand = New SqlCommand(query, sqlclass.sqlcon)
    '    'sqlcmd.ExecuteNonQuery()
    '    'sqlcmd.Dispose()

    '    sqlclass.cnn2.Close()


    'End Sub
    ''Private Sub sqlqueryexecute(ByVal query As String)
    ''    ' Dim query As String = "Delete from controlrights where formname='" & Me.ParentForm.Name & "' and controlname='" & Me.Name & "'"
    ''    ' sql.con2()
    ''    Dim sqlcmd As SqlCommand = New SqlCommand(query, sqlclass.sqlcon)
    ''    sqlcmd.ExecuteNonQuery()
    ''    sqlcmd.Dispose()

    ''    '  sqlclass.cnn2.Close()


    ''End Sub
    ' this function is check respective  button will visible or enable to the user or not 
    Public Sub propertiesread(ByVal btn As Control, ByVal frm As Form)
        '  sql.scn3.Close()

        If btn IsNot Nothing And frm IsNot Nothing Then
            btn.Enabled = True
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
                '  Exit Sub
            Else
                btn.Enabled = False

                Dim query As String = "open symmetric key symmetrickey1 decryption by certificate certificate1 select convert(varchar, decryptbykey(controlproperty)),controlstatus from controlrights  where levelid=" & Login_Register.levelid & " and convert(varchar, decryptbykey(formname))='" & frm.Name & "' and convert(varchar, decryptbykey(controlname))='" & btn.Name & "'"
                If sqlclass.database <> "" Then
                    sql.scon3()
                    Dim sqlcmd As SqlCommand = New SqlCommand(query, sql.scn3)
                    Using reader As SqlDataReader = sqlcmd.ExecuteReader
                        While reader.Read
                            ' controlstatus 1 means visible property
                            ' controlstatus 2 means enable property
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
                    tempdirect = 0
                    tempindirect = 0
                    '  visiblecode(btn)
                    visiblecode()
                    sqlcmd.Dispose()
                    sql.scn3.Close()
                End If
            End If
        End If
    End Sub
    '-- new code to the rights of component
    Dim rvisible As Boolean = True
    Dim renable As Boolean = True
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
                    'tempdirect = 0
                    'tempindirect = 0
                    ''  visiblecode(btn)
                    ' visiblecode()
                    '  sqlcmd.Dispose()

                    '  sql.scn3.Close()
                End If
            End If
        End If
    End Sub

    Private Sub buttonrightclick_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        ' below code adjust the label size according to the picture box 
        Label1.Size = Button1.Size
        Label2.Location = New Point(Label1.Width / 2 - Label2.Width / 2, Label1.Height / 2 - Label2.Height / 2)

    End Sub





    Private Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click, Label2.Click, Label1.Click
        If read1 = False Then
            If b_type.ToString = "_Set" Then
                'variableclass.wm(WriteAddress) = 1
                If variableclass.without_plc = False Then
                    plcclass.wrtie_m_singlevalue(WriteAddress, 1)

                Else
                    writeIndb(WriteAddress, 1, 1)
                    '--variableclass.m(WriteAddress) = 1
                End If

                RaiseEvent action()
                If recordev.ToString = "DirectlyInAuditTrail" Then
                    ev.insertscadaevent(Login_Register.empid, RecordActionMessage, Login_Register.levelid, Me.RecordMessage, ButtonTypeRecordMessage, "", "", "", "", "", Login_Register.lotno, Login_Register.batchno, "Audittrail")
                End If
                If recordev.ToString = "WithMessageInAuditTrail" Then
                    '      ev.insertscadaevent(Login_Register.empid, "Button Pressed", Login_Register.levelid, Me.RecordMessage, "", "", "", "", "", "", "", "", "Audittrail")
                    '--popo messagebox for msg record
                    Dim m As New buttonrecordmsg(ButtonTypeRecordMessage, RecordMessage, RecordActionMessage)
                    m.TopMost = True
                    m.StartPosition = FormStartPosition.CenterParent
                    m.ShowDialog()

                End If
            End If
            If b_type.ToString = "Reset" Then
                'variableclass.wm(WriteAddress) = 0
                If variableclass.without_plc = False Then
                    plcclass.wrtie_m_singlevalue(WriteAddress, 0)

                Else
                    writeIndb(WriteAddress, 0, 0)
                    '-- variableclass.m(WriteAddress) = 0
                End If
                'Button1.BorderStyle = BorderStyle.Fixed3D
                RaiseEvent action()
                If recordev.ToString = "DirectlyInAuditTrail" Then
                    ev.insertscadaevent(Login_Register.empid, RecordActionMessage, Login_Register.levelid, Me.RecordMessage, ButtonTypeRecordMessage, "", "", "", "", "", Login_Register.lotno, Login_Register.batchno, "Audittrail")
                End If
                If recordev.ToString = "WithMessageInAuditTrail" Then
                    '      ev.insertscadaevent(Login_Register.empid, "Button Pressed", Login_Register.levelid, Me.RecordMessage, "", "", "", "", "", "", "", "", "Audittrail")
                    '--popo messagebox for msg record
                    Dim m As New buttonrecordmsg(ButtonTypeRecordMessage, RecordMessage, RecordActionMessage)
                    m.TopMost = True
                    m.StartPosition = FormStartPosition.CenterParent
                    m.ShowDialog()

                End If
                'Button1.SizeMode = PictureBoxSizeMode.StretchImage

            End If
            Dim temp4 = 0
            If b_type.ToString = "Toggle" Then
                ' If variableclass.m(WriteAddress) = 1 Then
                If Val(variableclass.tag(WriteAddress)) = 1 Then
                    If temp4 = 0 Then
                        RaiseEvent action()
                        ' plcclass.wrtie_m_singlevalue(WriteAddress, 0)
                        If variableclass.without_plc = False Then
                            plcclass.wrtie_m_singlevalue(WriteAddress, 0)

                        Else
                            '--variableclass.m(WriteAddress) = 0
                            writeIndb(WriteAddress, 0, 0)
                        End If
                        '--variableclass.wm(WriteAddress) = 0  'this is used when for loop is used in an main form "compare" sub

                        'recordflag = Recordvalue
                        'If recordflag > 0 Then
                        '    ev.insertscadaevent(Login_Register.empid, "Button Pressed", Login_Register.levelid, Me.RecordMessage, "", "", "", "", "", "", AuditTrail.lotn, AuditTrail.batchat, "Audittrail")
                        'End If
                        If recordev.ToString = "DirectlyInAuditTrail" Then
                            ev.insertscadaevent(Login_Register.empid, RecordActionMessage, Login_Register.levelid, Me.RecordMessage, ToggleReSetRecordMessage, "", "", "", "", "", Login_Register.lotno, Login_Register.batchno, "Audittrail")
                        End If
                        If recordev.ToString = "WithMessageInAuditTrail" Then
                            '      ev.insertscadaevent(Login_Register.empid, "Button Pressed", Login_Register.levelid, Me.RecordMessage, "", "", "", "", "", "", "", "", "Audittrail")
                            '--popo messagebox for msg record
                            Dim m As New buttonrecordmsg(ToggleReSetRecordMessage, RecordMessage, RecordActionMessage)
                            m.TopMost = True
                            m.StartPosition = FormStartPosition.CenterParent
                            m.ShowDialog()

                        End If
                        temp4 = 1
                    End If

                End If
                ' If variableclass.m(WriteAddress) = 0 Then
                If Val(variableclass.tag(WriteAddress)) = 0 Then
                    If temp4 = 0 Then
                        '--variableclass.wm(WriteAddress) = 1 'this is used when for loop is used in an main form "compare" sub
                        RaiseEvent action()
                        If variableclass.without_plc = False Then
                            plcclass.wrtie_m_singlevalue(WriteAddress, 1)

                        Else
                            writeIndb(WriteAddress, 1, 1)
                            '-- variableclass.m(WriteAddress) = 1
                        End If
                        ' RaiseEvent action()
                        'recordflag = Recordvalue
                        'If recordflag > 0 Then
                        '    ev.insertscadaevent(Login_Register.empid, "Button Pressed", Login_Register.levelid, Me.RecordMessage, "", "", "", "", "", "", AuditTrail.lotn, AuditTrail.batchat, "Audittrail")
                        'End If

                        If recordev.ToString = "DirectlyInAuditTrail" Then
                            ev.insertscadaevent(Login_Register.empid, RecordActionMessage, Login_Register.levelid, Me.RecordMessage, ToggleSetRecordMessage, "", "", "", "", "", Login_Register.lotno, Login_Register.batchno, "Audittrail")
                        End If
                        If recordev.ToString = "WithMessageInAuditTrail" Then
                            '      ev.insertscadaevent(Login_Register.empid, "Button Pressed", Login_Register.levelid, Me.RecordMessage, "", "", "", "", "", "", "", "", "Audittrail")
                            '--popo messagebox for msg record
                            Dim m As New buttonrecordmsg(ToggleSetRecordMessage, RecordMessage, RecordActionMessage)
                            m.TopMost = True
                            m.StartPosition = FormStartPosition.CenterParent
                            m.ShowDialog()

                        End If
                        temp4 = 1
                    End If

                End If
            End If
        End If
        'If readonly1 = True Then
        '    RaiseEvent action()
        'End If
    End Sub


    'value of read tag will assign to it
    Dim buttonvalue = 0

    Dim tempsetlampstatus = 0

    'stores the last value of read tag
    Dim lastvalueonreadtag

    Sub readvalue()
        If b_type.ToString = "Banner" Then
            visiblecode()

        Else
            visiblecode()
            'pd=1 meand pushbutton down
            If pd = 1 Then
                '--variableclass.wm(WriteAddress) = 1
                If variableclass.without_plc = False Then
                    plcclass.wrtie_m_singlevalue(WriteAddress, 1)

                Else
                    '-- variableclass.m(WriteAddress) = 1
                    writeIndb(WriteAddress, 1, 1)
                End If
                'pd=1 and pu=1 means pushbutton down and up frequently
                If pu = 1 And pdf = 0 Then
                    'pdf = 1 means suddenly 0 write nhi hoga next round me hoga uska flag hai 
                    pdf = 1
                Else
                    pdf = 0
                End If
            End If
            'pu=1 means pushbutton up
            If pu = 1 Then
                If pdf = 1 Then
                Else
                    '--variableclass.wm(WriteAddress) = 0
                    If variableclass.without_plc = False Then
                        plcclass.wrtie_m_singlevalue(WriteAddress, 0)

                    Else
                        writeIndb(WriteAddress, 0, 0)
                        '-- variableclass.m(WriteAddress) = 0
                    End If
                    '    RaiseEvent action()
                    pdf = 0
                    pu = 0
                    pd = 0
                End If
            End If
        End If
        'buttonvalue = variableclass.m(ReadAddress)
        If variableclass.tag(radd) = Nothing Then

        Else
            buttonvalue = Val(variableclass.tag(radd))
            'first time color and text value ke according set hoga
            If tempsetlampstatus = 0 Then
                lastvalueonreadtag = buttonvalue
                For i = 0 To Define_lamp_state.Count - 1
                    If Define_lamp_state(i).value = buttonvalue Then

                        Button1.BackColor = Define_lamp_state(i).Backcolor_on_value
                        Label2.Text = Define_lamp_state(i).Text_on_value
                        ''If Define_lamp_state(i).image_on_value <> "" Then
                        ''    Me.ButtonImage = imgarray(i)
                        ''End If
                        tempsetlampstatus = 1

                        Exit Sub
                    End If
                Next
                'if value is not given in discription of lamp state then defaul color and text will be shown
                Button1.BackColor = Default_back_Color
                Label2.Text = Default_Text
                ''If path_default_image <> "" Then
                ''    Me.ButtonImage = button_image
                ''End If
                tempsetlampstatus = 1
                Exit Sub
            End If
            'if value on tag chenges then only color and text on lamp is updated
            If lastvalueonreadtag = buttonvalue Then
            Else
                lastvalueonreadtag = buttonvalue
                ' loop through all given states of lamp 
                For i = 0 To Define_lamp_state.Count - 1
                    If Define_lamp_state(i).value = buttonvalue Then

                        Button1.BackColor = Define_lamp_state(i).Backcolor_on_value
                        Label2.Text = Define_lamp_state(i).Text_on_value
                        ''If Define_lamp_state(i).image_on_value <> "" Then
                        ''    Me.ButtonImage = imgarray(i)
                        ''End If
                        Exit Sub
                    End If
                Next
                'if value is not given in discription of lamp state then defaul color and text will be shown
                Button1.BackColor = Default_back_Color
                Label2.Text = Default_Text
                ''If path_default_image <> "" Then
                ''    Me.ButtonImage = button_image
                ''End If
            End If
        End If

    End Sub

    
    Dim tempdirect = 0
    Dim tempindirect = 0
    Public Sub visiblecode(ByVal test As Control)
        'Dim cst = "::11:00:00"
        'Dim cspt = "::11:00:00"
        'Dim time = DateTime.Parse(cst)
        'Dim time2 = DateTime.Parse(cspt)
        'Dim temp = time2.Subtract(time)
        If Direct = False Then
            If tempdirect = 0 Or tempdirect = 2 Then
                Me.Visible = False
                tempdirect = 1
            End If

        Else
            If tempdirect = 1 Or tempdirect = 0 Then
                Me.Visible = True
                tempdirect = 2
            End If

        End If

        If Me.INDirect = True Then


            ' If variableclass.m(Address_of_M) = 1 Then
            If Val(variableclass.tag(Address_of_M)) = 1 Then
                If tempindirect = 0 Or tempindirect = 2 Then
                    Me.Visible = True
                    tempindirect = 1
                End If
            Else
                If tempindirect = 1 Or tempindirect = 0 Then
                    Me.Visible = False
                    tempindirect = 2
                End If
            End If
        End If

    End Sub
    Dim pvisible As Boolean
    Dim penable As Boolean
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
                'query return tagid of given visible tag name and set it into address of m property for indirect vissiblity of component
                ''  Dim querystring As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id from Tag_data  where convert(varchar, decryptbykey(Tag_name)) = '" & Vissible_tagname & "'"
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
                        Address_of_M = reader.Item("Tag_id")
                    End If
                End Using
                ' sqlcmd1.Dispose()
                sql.scn3.Close()
                Getvissibleaddress = 1
            End If


            'If variableclass.m(Address_of_M) = 1 Then
            If Val(variableclass.tag(Address_of_M)) = 1 Then
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
    Dim pushbutton_enable As Boolean = True

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
                            ' Me.Enabled = True
                            pushbutton_enable = True
                            tempenable = 1
                        End If
                    Else
                        If tempenable = 1 Or tempenable = 0 Then
                            '  renable = False
                            ' Me.Enabled = False
                            pushbutton_enable = False
                            Me.ForeColor = Color.White
                            tempenable = 2
                        End If

                    End If

                Else

                    If tempenable = 1 Or tempenable = 0 Then
                        '  renable = False
                        'Me.Enabled = False
                        pushbutton_enable = False
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
        sql.scon3()
        ''   Dim querystring As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id, convert(varchar, decryptbykey(Tag_name)) as Tag_name from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & read_tag_name & "' or convert(varchar, decryptbykey(Tag_name)) = '" & write_tag_name & "' "
        Dim querystring As String = ""
        'for encrypted or  non_encypted tables
        If variableclass.is_encrypted Then
            querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id, convert(varchar, decryptbykey(Tag_name)) as Tag_name from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & read_tag_name & "' or convert(varchar, decryptbykey(Tag_name)) = '" & write_tag_name & "' "
        Else
            querystring = "select Tag_id, Tag_name from Tag_data  where  Tag_name = '" & read_tag_name & "' or Tag_name = '" & write_tag_name & "' "
        End If

        Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
        sqlcmd1.ExecuteNonQuery()
        Using reader As SqlDataReader = sqlcmd1.ExecuteReader

            While reader.Read
                If reader.Item("Tag_name") = write_tag_name Then
                    WriteAddress = reader.Item("Tag_id")
                    tempwrite = 1
                End If
                If reader.Item("Tag_name") = read_tag_name Then
                    ReadAddress = reader.Item("Tag_id")
                    tempread = 1
                End If
            End While
            If tempwrite = 0 Then
                WriteAddress = 0
                Me._Readonly = True
            End If
            If tempread = 0 Then
                ReadAddress = 0
                'Me._Readonly = True
            End If
        End Using
        ' sqlcmd1.Dispose()
        sql.scn3.Close()
    End Sub
End Class



''Public Class MyFileNameEditor1
''    Inherits FileNameEditor

''    Protected Overrides Sub InitializeDialog(ByVal openFileDialog As OpenFileDialog)
''        MyBase.InitializeDialog(openFileDialog)
''        openFileDialog.Filter = "Image Files (*)|*.bmp;*.gif;*.png;*.jpg"
''    End Sub
''End Class

''Public Class MyConverter1
''    Inherits TypeConverter
''End Class

''Public Class MyClassEditor1
''    Inherits UITypeEditor

''    Public Overrides Function GetEditStyle(ByVal context As ITypeDescriptorContext) As UITypeEditorEditStyle
''        Return UITypeEditorEditStyle.Modal
''    End Function

''    Public Overrides Function EditValue(ByVal context As ITypeDescriptorContext, ByVal provider As IServiceProvider, ByVal value As Object) As Object
''        MessageBox.Show("press ok to continue")
''        Return "You can't edit this"
''    End Function
''End Class

'used for creating collection property for report description column
Public Class lamp_state
    Dim index As Integer = 0
    <DisplayName("Value")>
    Public Property value As Integer
        Get
            Return index
        End Get
        Set(ByVal value1 As Integer)
            index = value1
        End Set
    End Property
    Dim generateText As String
    <DisplayName("Text on value")>
    Public Property Text_on_value As String
        Get
            Return generateText
        End Get
        Set(ByVal value As String)
            generateText = value
        End Set
    End Property
    Dim back_color As Color = Color.Red
    <DisplayName("Backcolor on value")>
    Property Backcolor_on_value As Color
        Get

            Return back_color

        End Get
        Set(ByVal value As Color)
            ' Button1.BackColor = value
            back_color = value
        End Set
    End Property

    ''Dim image_path As String
    ''<Editor(GetType(MyFileNameEditor), GetType(System.Drawing.Design.UITypeEditor)), DisplayName("Image on value"), RefreshProperties(RefreshProperties.All)> _
    ''<TypeConverter(GetType(MyConverter))>
    ''Property image_on_value() As String
    ''    Get
    ''        Return image_path
    ''    End Get
    ''    Set(ByVal value As String)
    ''        image_path = value
    ''    End Set
    ''End Property
End Class