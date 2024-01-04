Imports AxActUtlTypeLib
Imports System.Windows.Forms

Public Class plcclass
    Public Shared ax As AxActUtlType
    Public Shared Sub wrtie_m_singlevalue(ByVal arrayindex As Integer, ByVal value As Integer)
        Try
            Dim connected = True

            Dim Device As String = "M" & arrayindex
            Dim ireturncode As Integer = 0
            ireturncode = ax.WriteDeviceRandom("M" & arrayindex, 1, value)
            If ireturncode = 0 Then
                connected = True
            Else
                connected = False
            End If
        Catch ex1 As ArithmeticException
            MessageBox.Show("Value Overflow", "Alert")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Shared Sub write_single_DValue(ByVal address As Integer, ByVal valtowrite As Integer)
        Dim connected = True

        Try
            Dim devicetowrite As String = "D" & address
            Dim ireturncode As Integer = ax.WriteDeviceBlock2(devicetowrite, 1, valtowrite)
            If ireturncode = 0 Then
                ' uc.Write = 0
                connected = True
            Else
                connected = False
            End If
        Catch ex1 As ArithmeticException
            MessageBox.Show("Value Overflow1", "Alert")

        Catch ex As Exception
            MsgBox("Class1- write_single_value: " & ex.Message)
        End Try

    End Sub
    Public Shared Function write_single_D_Value(ByVal address As Integer, ByVal valtowrite As Integer) As String
        Dim connected = True

        Try
            Dim devicetowrite As String = "D" & address
            Dim ireturncode As Integer = ax.WriteDeviceBlock2(devicetowrite, 1, valtowrite)
            If ireturncode = 0 Then
                ' uc.Write = 0
                connected = True
            Else
                connected = False
            End If
            Return True
        Catch ex1 As ArithmeticException
            MessageBox.Show("Value Overflow1", "Alert")
            Return False


        Catch ex As Exception
            MsgBox("Class1- write_single_value: " & ex.Message)
            Return False

        End Try

    End Function
End Class
