Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class popup
    Dim sql As New sqlclass
    Dim sadd As Integer = 0
    Dim saddvalue As Integer = 0
    Dim hadd As Integer = 0
    Dim haddvalue As Integer = 0
    Public tempformobj As New Form
    'tempflag is flag is to maintain that form ek bar display ho gya bar bar display ka code na chale
    Public tempflagshow = 0
    Public tempflaghide = 0
    <Browsable(False)>
    Property ShowFormAddressM As Integer
        Get
            Return sadd
        End Get
        Set(ByVal value As Integer)
            sadd = value
        End Set
    End Property
    Dim showTag As String = ""
    Property ShowFormTag As String 'tag name on which form is shown
        Get
            Return showTag
        End Get
        Set(value As String)
            showTag = value
        End Set
    End Property
    Property ShowFormValue As Integer
        Get
            Return saddvalue
        End Get
        Set(ByVal value As Integer)
            saddvalue = value
        End Set
    End Property
    <Browsable(False)>
    Property HideFormAddressM As Integer 'is address pe jo value h uspe hide hoga 
        Get
            Return hadd
        End Get
        Set(ByVal value As Integer)
            hadd = value
        End Set
    End Property
    Dim hideTag As String = ""
    Property HideFormTag As String  'tag name on which form is hide
        Get
            Return hideTag
        End Get
        Set(value As String)
            hideTag = value
        End Set
    End Property
    Property HideFormValue As Integer 'is address pe jo value h uspe hide hoga 
        Get
            Return haddvalue
        End Get
        Set(ByVal value As Integer)
            haddvalue = value
        End Set
    End Property
    Dim fname As String = ""
    Property Formname As String
        Get


            Return fname
        End Get
        Set(ByVal value As String)
            fname = value

        End Set
    End Property

    'Dim pop As New List(Of popuptest)

    'Property popupcollection As List(Of popuptest)
    '    Get


    '        Return pop
    '    End Get
    '    Set(ByVal value As List(Of popuptest))
    '        pop = value
    '        '   MsgBox(pop.Count)

    '    End Set
    'End Property
    Public Function GetForm(ByVal Formname As String) As Form
        Dim t As Type = Type.GetType(Formname) ', True, True)
        If t Is Nothing Then
            Dim Fullname As String = Application.ProductName & "." & Formname
            t = Type.GetType(Fullname, True, True)
        End If
        Return CType(Activator.CreateInstance(t), Form)

    End Function

    Public Function GetForm(ByVal Formname As String, ByVal app As Application) As Form
        Dim t As Type = Type.GetType(Formname) ', True, True)
        If t Is Nothing Then
            ' Me.parent()
            Dim Fullname As String = Application.ProductName & "." & Formname
            t = Type.GetType(Fullname, True, True)
        End If
        Return CType(Activator.CreateInstance(t), Form)

    End Function
    '-- show form sub display the respective of its address when bit is on
    'Sub showform() old code with single addresss
    '    If fname.Length = 0 Then
    '    Else


    '        '  tempformobj = GetForm(fname)
    '        If variableclass.m(AddressM) = 1 Then
    '            If tempflag = 0 Then
    '                '  MsgBox("show")
    '                tempformobj.Show()
    '                tempflag = 1
    '            End If
    '        Else
    '            ' MsgBox("hide")
    '            tempformobj.Hide()
    '            tempflag = 0
    '        End If
    '    End If
    'End Sub
    '-- new code with multiple addresss show form
    Sub showform()
        Try
            If fname.Length = 0 Then
            Else


                ' show form condition
                ' If variableclass.m(ShowFormAddressM) = saddvalue Then
                If Val(variableclass.tag(ShowFormAddressM)) = saddvalue Then
                    If tempflagshow = 0 Then
                        '  MsgBox("show")
                        tempformobj.StartPosition = FormStartPosition.CenterScreen
                        '--tempformobj.BringToFront()
                        tempformobj.TopMost = True
                        tempformobj.Show()
                        tempflagshow = 1
                    End If
                Else

                    tempflagshow = 0
                End If
                'hide from condition
                'If variableclass.m(HideFormAddressM) = haddvalue Then
                If Val(variableclass.tag(HideFormAddressM)) = haddvalue Then
                    '    MsgBox("hide")
                    If tempflaghide = 0 Then
                        tempformobj.Hide()
                        tempflaghide = 1
                        '  MsgBox("hide")
                        tempflaghide = 1
                    End If
                Else
                    tempflaghide = 0
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub showformdialogbox()
        Try
            If fname.Length = 0 Then
            Else


                ' show form condition
                ' If variableclass.m(ShowFormAddressM) = saddvalue Then
                If Val(variableclass.tag(ShowFormAddressM)) = saddvalue Then
                    If tempflagshow = 0 Then
                        '  MsgBox("show")
                        tempformobj.StartPosition = FormStartPosition.CenterScreen
                        '--tempformobj.BringToFront
                        '   tempformobj.TopMost = True
                        tempformobj.ShowDialog()
                        tempflagshow = 1
                    End If
                Else

                    tempflagshow = 0
                End If
                'hide from condition
                ' If variableclass.m(HideFormAddressM) = haddvalue Then
                If Val(variableclass.tag(HideFormAddressM)) = haddvalue Then
                    '    MsgBox("hide")
                    If tempflaghide = 0 Then
                        tempformobj.Hide()
                        tempflaghide = 1
                    End If
                Else
                    tempflaghide = 0
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    'Sub showformpopup()
    '    For i = 0 To pop.Count - 1
    '        If pop(i).Formname.Length = 0 Then
    '        Else


    '            '  tempformobj = GetForm(fname)
    '            If variableclass.m(pop(i).AddressM) = 1 Then
    '                If pop(i).tempflag = 0 Then
    '                    '  MsgBox("show")
    '                    pop(i).tempformobj.Show()
    '                    pop(i).tempflag = 1
    '                End If
    '            Else
    '                ' MsgBox("hide")
    '                pop(i).tempformobj.Hide()
    '                pop(i).tempflag = 0
    '            End If
    '        End If
    '    Next
    'End Sub

    'Sub showform(ByVal app As Application)
    '    If fname.Length = 0 Then
    '    Else


    '        tempformobj = GetForm(fname, app)
    '        If variableclass.m(ShowFormAddressM) = 1 Then
    '            If tempflag = 0 Then
    '                tempformobj.Show()
    '                tempflag = 1
    '            End If
    '        Else

    '            tempformobj.Hide()
    '            tempflag = 0
    '        End If
    '    End If
    'End Sub

    'function which update show and hide address of form from given tag
    Sub updatevalue()
        Sql.scon3()
        ''  Dim querystring As String = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id, convert(varchar, decryptbykey(Tag_name)) as Tag_name from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & showTag & "' or convert(varchar, decryptbykey(Tag_name)) = '" & hideTag & "' "
        Dim querystring As String = ""
        'for encrypted or  non_encypted tables
        If variableclass.is_encrypted Then
            querystring = "OPEN SYMMETRIC KEY SymmetricKey1 DECRYPTION BY CERTIFICATE Certificate1 select Tag_id, convert(varchar, decryptbykey(Tag_name)) as Tag_name from Tag_data  where  convert(varchar, decryptbykey(Tag_name)) = '" & showTag & "' or convert(varchar, decryptbykey(Tag_name)) = '" & hideTag & "' "

        Else
            querystring = "select Tag_id, Tag_name from Tag_data  where  Tag_name = '" & showTag & "' or Tag_name = '" & hideTag & "' "

        End If

        Dim sqlcmd1 As SqlCommand = New SqlCommand(querystring, sql.scn3)
        sqlcmd1.ExecuteNonQuery()
        Using reader As SqlDataReader = sqlcmd1.ExecuteReader

            While reader.Read
                If reader.Item("Tag_name") = showTag Then
                    ShowFormAddressM = reader.Item("Tag_id")
                End If
                If reader.Item("Tag_name") = hideTag Then
                    HideFormAddressM = reader.Item("Tag_id")
                End If
            End While

        End Using
        ' sqlcmd1.Dispose()
        sql.scn3.Close()
    End Sub
End Class
Public Class popuptest
    Dim radd As Integer = 0
    Public tempformobj As Form
    Public tempflag = 0
    Public Property AddressM As Integer
        Get
            Return radd
        End Get
        Set(ByVal value As Integer)
            radd = value
        End Set
    End Property
    Dim fname As String = ""
    Public Property Formname As String
        Get


            Return fname
        End Get
        Set(ByVal value As String)
            fname = value

        End Set
    End Property

End Class
