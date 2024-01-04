
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms.Control
Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Collections.Generic
Imports System.Web
Imports System.Drawing.Imaging
Imports System.Windows.Forms
Imports System.Object
Imports System.ComponentModel.Component
Imports System.Windows.Forms.BorderStyle
Imports System.Windows.Forms.TextBox
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
Imports System.Drawing.Design
Imports System.Data.SqlClient

Public Class Bannercontrol
    Implements ICustomTypeDescriptor
    Dim s3 As New List(Of ab)
    <Browsable(True), _
  EditorBrowsable(EditorBrowsableState.Always), _
  Category("Z"), _
  Description("The items with sub items that should be displayed"), _
  DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Property AddValues As List(Of ab)
        Get
            Return s3
        End Get
        Set(ByVal value As List(Of ab))
            s3 = value
        End Set
    End Property
    Dim x1 As String = "0"
    Property Value As String
        Get

            Return x1
        End Get
        Set(ByVal value As String)

            x1 = value
            If IsNumeric(x1) Then
                ' UserValues()
                UserValuesname()
            End If
        End Set
    End Property
    Dim baddress As Integer = 0

    Property BRAddress As Integer
        Get

            Return (baddress)
        End Get
        Set(ByVal value As Integer)

            baddress = value

        End Set
    End Property
    Dim radd As Boolean = False
    Public Property Readadd As Boolean
        Get

            Return radd
        End Get
        Set(ByVal value As Boolean)

            radd = value

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

    Private Sub BannerControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If s3.Count <> 0 Then
            PictureBox1.Tag = s3(0).Values
        End If
    End Sub

    Public Sub UserValues()

        For i = 0 To s3.Count - 1
            If x1 = s3(i).Values Then
                If PictureBox1.Tag <> s3(i).Values Then
                    PictureBox1.Image = Nothing
                    PictureBox1.Image = My.Resources.box1
                    PictureBox1.Image = s3(i).Setimage
                    PictureBox1.Tag = s3(i).Values
                    PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage

                    Exit Sub
                End If
            End If
        Next
        '  PictureBox1.Image = Image.FromFile("D:\68.jpg");
    End Sub

    Public Sub UserValuesname()

        For i = 0 To s3.Count - 1
            If x1 = s3(i).Values Then
                If PictureBox1.Tag <> s3(i).Values Then
                    If PictureBox1.Image IsNot Nothing Then
                        PictureBox1.Image.Dispose()
                        PictureBox1.Image = Nothing
                    End If


                    '   PictureBox1.Image = Image.FromFile(s3(i).Setimagename)
                    PictureBox1.Image = My.Resources.ResourceManager.GetObject(s3(i).Setimagename)
                    'PictureBox1.Image =
                    PictureBox1.Tag = s3(i).Values
                    PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage

                    Exit Sub
                End If
            End If
        Next

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub


    Public Function GetAttributes() As System.ComponentModel.AttributeCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetAttributes
        Return TypeDescriptor.GetAttributes(Me, True)
    End Function

    Public Function GetClassName() As String Implements System.ComponentModel.ICustomTypeDescriptor.GetClassName
        Return TypeDescriptor.GetClassName(Me, True)
    End Function

    Public Function GetComponentName() As String Implements System.ComponentModel.ICustomTypeDescriptor.GetComponentName
        Return TypeDescriptor.GetComponentName(Me, True)
    End Function

    Public Function GetConverter() As System.ComponentModel.TypeConverter Implements System.ComponentModel.ICustomTypeDescriptor.GetConverter

        Return TypeDescriptor.GetConverter(Me, True)
    End Function

    Public Function GetDefaultEvent() As System.ComponentModel.EventDescriptor Implements System.ComponentModel.ICustomTypeDescriptor.GetDefaultEvent
        Return TypeDescriptor.GetDefaultEvent(Me, True)
    End Function

    Public Function GetDefaultProperty() As System.ComponentModel.PropertyDescriptor Implements System.ComponentModel.ICustomTypeDescriptor.GetDefaultProperty
        Return TypeDescriptor.GetDefaultProperty(Me, True)
    End Function

    Public Function GetEditor(ByVal editorBaseType As System.Type) As Object Implements System.ComponentModel.ICustomTypeDescriptor.GetEditor
        Return TypeDescriptor.GetEditor(Me, editorBaseType, True)
    End Function
    ' The following 2 methods will get the EventDescriptor objects for all events declared in
    ' this user control, included those inherited from the UserControl object and its ancestors.
    ' We then call the FilterEvents method to return a new EventDescriptorCollection with the 
    ' required events removed.
    Public Function GetEvents(ByVal attributes() As System.Attribute) As System.ComponentModel.EventDescriptorCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetEvents

        Dim orig As EventDescriptorCollection = TypeDescriptor.GetEvents(Me, attributes, True)
        Return FilterEvents(orig)
    End Function

    Public Function GetEvents() As System.ComponentModel.EventDescriptorCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetEvents

        Dim orig As EventDescriptorCollection = TypeDescriptor.GetEvents(Me, True)
        Return FilterEvents(orig)
    End Function

    ' The following 2 methods will get the PropertyDescriptor objects for all properties declared in
    ' this user control, included those inherited from the UserControl object and its ancestors.
    ' We then call the FilterProperties method to return a new PropertyDescriptorCollection with the 
    ' required properties removed.
    Public Function GetProperties(ByVal attributes() As System.Attribute) As System.ComponentModel.PropertyDescriptorCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetProperties

        Dim orig As PropertyDescriptorCollection = TypeDescriptor.GetProperties(Me, attributes, True)
        Return FilterProperties(orig)
    End Function

    Public Function GetProperties() As System.ComponentModel.PropertyDescriptorCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetProperties

        Dim orig As PropertyDescriptorCollection = TypeDescriptor.GetProperties(Me, True)
        Return FilterProperties(orig)
    End Function

    Public Function GetPropertyOwner(ByVal pd As System.ComponentModel.PropertyDescriptor) As Object Implements System.ComponentModel.ICustomTypeDescriptor.GetPropertyOwner

        Return Me
    End Function
    Private excludeBrowsableProperties As String() = {}

    Private excludeBrowsableEvents As String() = {}

    Private Function FilterProperties(ByVal originalCollection As PropertyDescriptorCollection) As PropertyDescriptorCollection
        ' Create an enumerator containing only the properties that are not in the provided list of property names
        ' and fill an array with those selected properties
        Dim selectedProperties As IEnumerable(Of PropertyDescriptor) = originalCollection.OfType(Of PropertyDescriptor)().Where(Function(p) Not excludeBrowsableProperties.Contains(p.Name))
        Dim descriptors As PropertyDescriptor() = selectedProperties.ToArray()

        ' Return a PropertyDescriptorCollection containing only the filtered descriptors
        Dim newCollection As New PropertyDescriptorCollection(descriptors)
        Return newCollection
    End Function

    Private Function FilterEvents(ByVal origEvents As EventDescriptorCollection) As EventDescriptorCollection
        ' Create an enumerator containing only the events that are not in the provided list of event names
        ' and fill an array with those selected events
        Dim selectedEvents As IEnumerable(Of EventDescriptor) = origEvents.OfType(Of EventDescriptor)().Where(Function(e) Not excludeBrowsableEvents.Contains(e.Name))
        Dim descriptors As EventDescriptor() = selectedEvents.ToArray()

        ' Return an EventDescriptorCollection containing only the filtered descriptors
        Dim newCollection As New EventDescriptorCollection(descriptors)
        Return newCollection
    End Function

    Dim sql As New scadacomponent.sqlclass
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
                BRAddress = reader.Item("Tag_id")
                ' radd = reader.Item("Tag_id")
            Else
                BRAddress = 0
                ' radd = 0
                '  Me.Read_Only = True
            End If
        End Using
        sqlcmd1.Dispose()
        sql.scn3.Close()
    End Sub


End Class

Public Class ab


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
    Private img As Image = Nothing
    Private imgname As String = ""
    Public Property Setimage() As Image
        Get
            Return img
        End Get
        Set(ByVal value As Image)
            img = value
        End Set
    End Property
    <EditorAttribute(GetType(FileNameEditor), GetType(UITypeEditor))>
    Public Property Setimagename() As String
        Get
            Return imgname
        End Get
        Set(ByVal value As String)
            imgname = Path.GetFileNameWithoutExtension(value)
        End Set
    End Property
End Class
