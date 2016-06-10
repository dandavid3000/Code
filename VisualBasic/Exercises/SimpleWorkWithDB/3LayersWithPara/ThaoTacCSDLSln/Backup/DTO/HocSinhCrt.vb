Public Class HocSinhCrt

#Region "Attributes"

    Private _ma As Integer
    Private _ten As String
    Private _ngaySinhTu As DateTime
    Private _ngaySinhDen As DateTime
    Private _diaChi As String
    Private _toanTu As Double
    Private _toanDen As Double
    Private _lyTu As Double
    Private _lyDen As Double
    Private _hoaTu As Double
    Private _hoaDen As Double
    Private _dtbTu As Double
    Private _dtbDen As Double
    Private _maLop As Integer

    Private _checkNgaySinh As Boolean
    Private _checkDiaChi As Boolean
    Private _checkToan As Boolean
    Private _checkLy As Boolean
    Private _checkHoa As Boolean
    Private _checkDTB As Boolean
    Private _checkLopHoc As Boolean

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

    Public Property NgaySinhTu() As Date
        Get
            Return _ngaySinhTu
        End Get
        Set(ByVal value As Date)
            _ngaySinhTu = value
        End Set
    End Property

    Public Property NgaySinhDen() As Date
        Get
            Return _ngaySinhDen
        End Get
        Set(ByVal value As Date)
            _ngaySinhDen = value
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

    Public Property ToanTu() As Double
        Get
            Return _toanTu
        End Get
        Set(ByVal value As Double)
            _toanTu = value
        End Set
    End Property

    Public Property ToanDen() As Double
        Get
            Return _toanDen
        End Get
        Set(ByVal value As Double)
            _toanDen = value
        End Set
    End Property

    Public Property LyTu() As Double
        Get
            Return _lyTu
        End Get
        Set(ByVal value As Double)
            _lyTu = value
        End Set
    End Property

    Public Property LyDen() As Double
        Get
            Return _lyDen
        End Get
        Set(ByVal value As Double)
            _lyDen = value
        End Set
    End Property

    Public Property HoaTu() As Double
        Get
            Return _hoaTu
        End Get
        Set(ByVal value As Double)
            _hoaTu = value
        End Set
    End Property

    Public Property HoaDen() As Double
        Get
            Return _hoaDen
        End Get
        Set(ByVal value As Double)
            _hoaDen = value
        End Set
    End Property

    Public Property DTBTu() As Double
        Get
            Return _dtbTu
        End Get
        Set(ByVal value As Double)
            _dtbTu = value
        End Set
    End Property

    Public Property DTBDen() As Double
        Get
            Return _dtbDen
        End Get
        Set(ByVal value As Double)
            _dtbDen = value
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

    Public Property CheckNgaySinh() As Boolean
        Get
            Return _checkNgaySinh
        End Get
        Set(ByVal value As Boolean)
            _checkNgaySinh = value
        End Set
    End Property

    Public Property CheckDiaChi() As Boolean
        Get
            Return _checkDiaChi
        End Get
        Set(ByVal value As Boolean)
            _checkDiaChi = value
        End Set
    End Property

    Public Property CheckToan() As Boolean
        Get
            Return _checkToan
        End Get
        Set(ByVal value As Boolean)
            _checkToan = value
        End Set
    End Property

    Public Property CheckLy() As Boolean
        Get
            Return _checkLy
        End Get
        Set(ByVal value As Boolean)
            _checkLy = value
        End Set
    End Property

    Public Property CheckHoa() As Boolean
        Get
            Return _checkHoa
        End Get
        Set(ByVal value As Boolean)
            _checkHoa = value
        End Set
    End Property

    Public Property CheckDTB() As Boolean
        Get
            Return _checkDTB
        End Get
        Set(ByVal value As Boolean)
            _checkDTB = value
        End Set
    End Property

    Public Property CheckLopHoc() As Boolean
        Get
            Return _checkLopHoc
        End Get
        Set(ByVal value As Boolean)
            _checkLopHoc = value
        End Set
    End Property

#End Region

#Region "Constructors"
    Public Sub New()
        Ma = 0
        Ten = ""
        NgaySinhTu = New DateTime(1950, 1, 1)
        NgaySinhDen = New DateTime(1997, 1, 1)
        DiaChi = ""
        ToanTu = 0
        ToanDen = 10
        LyTu = 0
        LyDen = 10
        HoaTu = 0
        HoaDen = 10
        DTBTu = 0
        DTBDen = 10
        MaLop = 0
        CheckNgaySinh = False
        CheckDiaChi = False
        CheckToan = False
        CheckLy = False
        CheckHoa = False
        CheckDTB = False
        CheckLopHoc = False
    End Sub
#End Region
End Class
