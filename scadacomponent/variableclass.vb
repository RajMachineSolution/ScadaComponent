Public Class variableclass
    Public Shared tag() As String  'array of tag
    Public Shared d() As Short
    Public Shared m() As Short
    Public Shared wd() As Integer
    Public Shared wm() As Integer
    Public Shared iv() As String
    Public Shared wiv() As String
    'Public Shared d(1350) As Short
    'Public Shared m(1600) As Short
    'Public Shared wd(1350) As Integer
    'Public Shared wm(1600) As Integer
    'Public Shared iv(1000) As String
    'Public Shared wiv(1000) As String
    Public Shared datee As String
    Public Shared timee As String
    Public Shared without_plc As Boolean = True
    'if it is zero means date time will be updated from system in scada
    'if any one of the datetime component has update datetime variable property to yes then it will become 1
    Public Shared datetimeupdate_counter = 0
    'for tag table encryption or un_encryption
    Public Shared is_encrypted = False
    Public Shared Iv_tag_start_id As Integer = 0

    Public Shared on_screen_keyboard = True

    Public Shared enable_keyboard = True



End Class
