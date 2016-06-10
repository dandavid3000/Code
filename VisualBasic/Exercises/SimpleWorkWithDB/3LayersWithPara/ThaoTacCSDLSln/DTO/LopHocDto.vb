Public Class LopHocDto

#Region "Attributes"

    Private _ma As Integer
    Private _ten As String

#End Region

#Region "Properties"

    Public Property Ma() As Integer
        Get
            Return _ma
        End Get
        Set(ByVal value As Integer)
            _ma = value
        End Set
    End Property

    Public Property Ten() As String
        Get
            Return _ten
        End Get
        Set(ByVal value As String)
            _ten = value
        End Set
    End Property

#End Region

#Region "Constructors"

    Public Sub New()
        Ma = 0
        Ten = ""
    End Sub

#End Region
End Class
