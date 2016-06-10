Imports System.Data.OleDb
Imports DTO

Public Class HocSinhDao
    Public Function LayBang() As DataTable
        Dim dt As New DataTable
        Dim cn As OleDbConnection
        'B1 & B2: Tao chuoi ket noi, mo ket noi bang doi tuong ket noi
        cn = Database.ConnectionData()
        'B3: Tao chuoi strSQL thao tac CSDL
        Dim strSQL As String
        strSQL = "Select * From HocSinh"
        'B4: Thuc thi chuoi strSQL
        Dim da As OleDbDataAdapter
        da = New OleDbDataAdapter(strSQL, cn)
        da.Fill(dt)
        'B5: Dong ket noi CSDL
        cn.Close()
        Return dt
    End Function

    Public Sub CapNhatBang(ByVal dt As DataTable)
        Dim cn As OleDbConnection
        'B1 & B2: Tao chuoi ket noi, mo ket noi bang doi tuong ket noi
        cn = Database.ConnectionData()
        'B3: Tao chuoi strSQL thao tac CSDL
        Dim strSQL As String
        strSQL = "Select * From HocSinh"
        'B4: Thuc thi chuoi strSQL
        Dim da As OleDbDataAdapter
        da = New OleDbDataAdapter(strSQL, cn)
        Dim cb As New OleDbCommandBuilder(da)
        da.Update(dt)
        'B5: Dong ket noi CSDL
        cn.Close()
    End Sub

    Public Function LayDanhSach() As IList
        Dim ds As New ArrayList()
        'B1 & B2: Tao chuoi ket noi, mo ket noi bang doi tuong ket noi
        Dim cn As OleDbConnection
        cn = Database.ConnectionData()
        'B3: Tao chuoi strSQL thao tac CSDL
        Dim strSQL As String
        strSQL = "Select * From HocSinh"
        Dim cmd As New OleDbCommand(strSQL, cn)
        Dim dr As OleDbDataReader
        dr = cmd.ExecuteReader()
        While (dr.Read())
            Dim hsDto As New HocSinhDto
            hsDto.Ma = dr("Ma")
            hsDto.Ten = dr("Ten")
            hsDto.DiaChi = dr("DiaChi")
            hsDto.Toan = dr("Toan")
            hsDto.Ly = dr("Ly")
            hsDto.Hoa = dr("Hoa")
            hsDto.DTB = dr("DTB")
            hsDto.MaLop = dr("MaLop")
            ds.Add(hsDto)
        End While
        'B5: Dong ket noi CSDL
        dr.Close()
        cn.Close()
        Return ds
    End Function

    Public Function TimKiem(ByVal maHocSinh As Integer)
        Dim hsDto As New HocSinhDto
        Dim cn As OleDbConnection
        'B1 & B2: Tao chuoi ket noi, mo ket noi bang doi tuong ket noi
        cn = Database.ConnectionData()
        'B3: Tao chuoi strSQL thao tac CSDL
        Dim strSQL As String
        strSQL = "Select * From HocSinh Where Ma = ?"
        'B4: Thuc thi chuoi strSQL
        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.Parameters.Add("@Ma", OleDbType.Integer)
        cmd.Parameters("@Ma").Value = maHocSinh
        Dim dr As OleDbDataReader
        dr = cmd.ExecuteReader()
        While (dr.Read())
            hsDto.Ma = dr("Ma")
            hsDto.Ten = dr("Ten")
            hsDto.DiaChi = dr("DiaChi")
            hsDto.Toan = dr("Toan")
            hsDto.Ly = dr("Ly")
            hsDto.Hoa = dr("Hoa")
            hsDto.DTB = dr("DTB")
            hsDto.MaLop = dr("MaLop")
        End While
        'B5: Dong ket noi CSDL
        dr.Close()
        cn.Close()
        Return hsDto
    End Function

    Public Sub Them(ByVal hsDto As HocSinhDto)
        Dim cn As OleDbConnection
        'B1 & B2: Tao chuoi ket noi, mo ket noi bang doi tuong ket noi
        cn = Database.ConnectionData()
        'B3: Tao chuoi strSQL thao tac CSDL
        Dim strSQL As String
        strSQL = "Insert into HocSinh(Ten, NgaySinh, DiaChi, Toan, Ly, Hoa, DTB, MaLop) values (?, ?, ?, ?, ?, ?, ?, ?)"

        'B4: Thuc thi chuoi strSQL
        Dim cmd As New OleDbCommand(strSQL, cn)

        cmd.Parameters.Add("@Ten", OleDbType.WChar)
        cmd.Parameters.Add("@NgaySinh", OleDbType.Date)
        cmd.Parameters.Add("@DiaChi", OleDbType.WChar)
        cmd.Parameters.Add("@Toan", OleDbType.Double)
        cmd.Parameters.Add("@Ly", OleDbType.Double)
        cmd.Parameters.Add("@Hoa", OleDbType.Double)
        cmd.Parameters.Add("@DTB", OleDbType.Double)
        cmd.Parameters.Add("@MaLop", OleDbType.Integer)

        cmd.Parameters("@Ten").Value = hsDto.Ten
        cmd.Parameters("@NgaySinh").Value = hsDto.NgaySinh
        cmd.Parameters("@DiaChi").Value = hsDto.DiaChi
        cmd.Parameters("@Toan").Value = hsDto.Toan
        cmd.Parameters("@Ly").Value = hsDto.Ly
        cmd.Parameters("@Hoa").Value = hsDto.Hoa
        cmd.Parameters("@DTB").Value = hsDto.DTB
        cmd.Parameters("@MaLop").Value = hsDto.MaLop

        cmd.ExecuteNonQuery()

        strSQL = "Select @@IDENTITY"
        cmd = New OleDbCommand(strSQL, cn)
        hsDto.Ma = cmd.ExecuteScalar()
        'B5: Dong ket noi CSDL
        cn.Close()
    End Sub

    Public Sub Xoa(ByVal maHocSinh As Integer)
        Dim cn As OleDbConnection
        'B1 & B2: Tao chuoi ket noi, mo ket noi bang doi tuong ket noi
        cn = Database.ConnectionData()
        'B3: Tao chuoi strSQL thao tac CSDL
        Dim strSQL As String
        strSQL = "Delete From HocSinh Where Ma = ? "
        'B4: Thuc thi chuoi strSQL
        Dim cmd As New OleDbCommand(strSQL, cn)

        cmd.Parameters.Add("@Ma", OleDbType.Integer)

        cmd.Parameters("@Ma").Value = maHocSinh

        cmd.ExecuteNonQuery()
        'B5: Dong ket noi CSDL
        cn.Close()
    End Sub

    Public Sub Sua(ByVal hsDto As HocSinhDto)
        Dim cn As OleDbConnection
        'B1 & B2: Tao chuoi ket noi, mo ket noi bang doi tuong ket noi
        cn = Database.ConnectionData()
        'B3: Tao chuoi strSQL thao tac CSDL
        Dim strSQL As String
        strSQL = _
            "Update HocSinh Set Ten = ? , NgaySinh = ? , DiaChi = ? , Toan = ? , Ly = ? , Hoa = ? , DTB = ? , MaLop = ? Where Ma = ?"
        'B4: Thuc thi chuoi strSQL
        Dim cmd As New OleDbCommand(strSQL, cn)

        cmd.Parameters.Add("@Ten", OleDbType.WChar)
        cmd.Parameters.Add("@NgaySinh", OleDbType.Date)
        cmd.Parameters.Add("@DiaChi", OleDbType.WChar)
        cmd.Parameters.Add("@Toan", OleDbType.Double)
        cmd.Parameters.Add("@Ly", OleDbType.Double)
        cmd.Parameters.Add("@Hoa", OleDbType.Double)
        cmd.Parameters.Add("@DTB", OleDbType.Double)
        cmd.Parameters.Add("@MaLop", OleDbType.Integer)
        cmd.Parameters.Add("@Ma", OleDbType.Integer)

        cmd.Parameters("@Ten").Value = hsDto.Ten
        cmd.Parameters("@NgaySinh").Value = hsDto.NgaySinh
        cmd.Parameters("@DiaChi").Value = hsDto.DiaChi
        cmd.Parameters("@Toan").Value = hsDto.Toan
        cmd.Parameters("@Ly").Value = hsDto.Ly
        cmd.Parameters("@Hoa").Value = hsDto.Hoa
        cmd.Parameters("@DTB").Value = hsDto.DTB
        cmd.Parameters("@MaLop").Value = hsDto.MaLop
        cmd.Parameters("@Ma").Value = hsDto.Ma

        cmd.ExecuteNonQuery()
        'B5: Dong ket noi CSDL
        cn.Close()
    End Sub

    Public Function TimKiem(ByVal hsCrt As HocSinhCrt) As DataTable
        Dim dt As New DataTable()
        Dim cn As OleDbConnection
        cn = Database.ConnectionData()
        Dim cmd As OleDbCommand = BuildQuery(hsCrt, cn)
        Dim da As New OleDbDataAdapter(cmd)
        da.Fill(dt)
        Return dt
    End Function

    Private Function BuildQuery(ByVal hsCrt As HocSinhCrt, ByVal cn As OleDbConnection) As OleDbCommand
        Dim cmd As New OleDbCommand()
        Dim strDKMaHocSinh = " 1=1 "
        Dim strDKTenHocSinh = " 1=1 "
        Dim strDKNgaySinh = " 1=1 "
        Dim strDKDiaChi = " 1=1 "
        Dim strDKDiemToan = " 1=1 "
        Dim strDKDiemLy = " 1=1 "
        Dim strDKDiemHoa = " 1=1 "
        Dim strDKDTB = " 1=1 "
        Dim strDKLopHoc = " 1=1 "

        If (hsCrt.Ma <> 0) Then
            strDKMaHocSinh = " Ma = ? "
            cmd.Parameters.Add("@Ma", OleDbType.Integer)
            cmd.Parameters("@Ma").Value = hsCrt.Ma
        End If
        If (hsCrt.Ten <> "") Then
            strDKTenHocSinh = " Ten like ?"
            cmd.Parameters.Add("@Ten", OleDbType.WChar)
            cmd.Parameters("@Ten").Value = "%" + hsCrt.Ten + "%"
        End If
        If (hsCrt.CheckNgaySinh) Then
            strDKNgaySinh = " NgaySinh between ? and ? "
            cmd.Parameters.Add("@NgaySinhTu", OleDbType.Date)
            cmd.Parameters.Add("@NgaySinhDen", OleDbType.Date)
            cmd.Parameters("@NgaySinhTu").Value = hsCrt.NgaySinhTu
            cmd.Parameters("@NgaySinhDen").Value = hsCrt.NgaySinhDen
        End If
        If (hsCrt.CheckDiaChi And hsCrt.DiaChi <> "") Then
            strDKDiaChi = " DiaChi like '?' "
            cmd.Parameters.Add("@DiaChi", OleDbType.WChar)
            cmd.Parameters("@DiaChi").Value = "%" + hsCrt.DiaChi + "%"
        End If
        If (hsCrt.CheckToan) Then
            strDKDiemToan = " Toan between ? and ? "
            cmd.Parameters.Add("@DiemToanTu", OleDbType.Double)
            cmd.Parameters.Add("@DiemToanDen", OleDbType.Double)
            cmd.Parameters("@DiemToanTu").Value = hsCrt.ToanTu
            cmd.Parameters("@DiemToanDen").Value = hsCrt.ToanDen
        End If
        If (hsCrt.CheckLy) Then
            strDKDiemLy = " Ly between ? and ? "
            cmd.Parameters.Add("@DiemLyTu", OleDbType.Double)
            cmd.Parameters.Add("@DiemLyDen", OleDbType.Double)
            cmd.Parameters("@DiemLyTu").Value = hsCrt.ToanTu
            cmd.Parameters("@DiemLyDen").Value = hsCrt.ToanDen
        End If
        If (hsCrt.CheckHoa) Then
            strDKDiemHoa = " Hoa between ? and ? "
            cmd.Parameters.Add("@DiemHoaTu", OleDbType.Double)
            cmd.Parameters.Add("@DiemHoaDen", OleDbType.Double)
            cmd.Parameters("@DiemHoaTu").Value = hsCrt.ToanTu
            cmd.Parameters("@DiemHoaDen").Value = hsCrt.ToanDen
        End If
        If (hsCrt.CheckDTB) Then
            strDKDTB = " DTB between ? and ? "
            cmd.Parameters.Add("@DTBTu", OleDbType.Double)
            cmd.Parameters.Add("@DTBDen", OleDbType.Double)
            cmd.Parameters("@DTBTu").Value = hsCrt.ToanTu
            cmd.Parameters("@DTBDen").Value = hsCrt.ToanDen
        End If
        If (hsCrt.CheckLopHoc) Then
            strDKLopHoc = " MaLop = ? "
            cmd.Parameters.Add("@MaLop", OleDbType.Integer)
            cmd.Parameters("@MaLop").Value = hsCrt.MaLop
        End If

        Dim strDKWhere As String = " Where "
        strDKWhere += strDKMaHocSinh
        strDKWhere += " and " + strDKTenHocSinh
        strDKWhere += " and " + strDKNgaySinh
        strDKWhere += " and " + strDKDiaChi
        strDKWhere += " and " + strDKDiemToan
        strDKWhere += " and " + strDKDiemLy
        strDKWhere += " and " + strDKDiemHoa
        strDKWhere += " and " + strDKDTB
        strDKWhere += " and " + strDKLopHoc
        Dim strSQL As String = "Select * From HocSinh "
        strSQL += strDKWhere
        strSQL += " Order by Ten "

        cmd.Connection = cn
        cmd.CommandText = strSQL
        Return cmd
    End Function
End Class
