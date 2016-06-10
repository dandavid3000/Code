Public Class HocSinhDto

#Region "Attributes"

    Private _ma As Integer
    Private _ten As String
    Private _ngaySinh As DateTime
    Private _diaChi As String
    Private _toan As Double
    Private _ly As Double
    Private _hoa As Double
    Private _dtb As Double
    Private _maLop As Integer

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

    Public Property DiaChi() As String
        Get
            Return _diaChi
        End Get
        Set(ByVal value As String)
            _diaChi = value
        End Set
    End Property

    Public Property Toan() As Double
        Get
            Return _toan
        End Get
        Set(ByVal value As Double)
            _toan = value
        End Set
    End Property

    Public Property Ly() As Double
        Get
            Return _ly
        End Get
        Set(ByVal value As Double)
            _ly = value
        End Set
    End Property

    Public Property Hoa() As Double
        Get
            Return _hoa
        End Get
        Set(ByVal value As Double)
            _hoa = value
        End Set
    End Property

    Public Property MaLop() As Integer
        Get
            Return _maLop
        End Get
        Set(ByVal value As Integer)
            _maLop = value
        End Set
    End Property

    Public Property DTB() As Double
        Get
            Return _dtb
        End Get
        Set(ByVal value As Double)
            _dtb = value
        End Set
    End Property

    Public Property NgaySinh() As Date
        Get
            Return _ngaySinh
        End Get
        Set(ByVal value As Date)
            _ngaySinh = value
        End Set
    End Property

#End Region

#Region "Constructors"

    Public Sub New()
        Ma = 0
        Ten = ""
        DiaChi = ""
        Toan = 0
        Ly = 0
        Hoa = 0
        MaLop = 0
    End Sub

#End Region
End Class
