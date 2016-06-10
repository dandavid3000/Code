Imports System.Data.OleDb
Imports DTO

Public Class LopHocDao
    Public Function LayDanhSach() As IList
        Dim ds As New ArrayList()
        Dim cn As OleDbConnection
        Dim strSQL As String
        'B1 & B2: Tao chuoi ket noi, mo ket noi bang doi tuong ket noi
        cn = Database.ConnectionData()
        'B3: Tao chuoi strSQL thao tac CSDL
        strSQL = "Select * From LopHoc"
        'B4: Thuc thi chuoi strSQL
        Dim cmd As New OleDbCommand(strSQL, cn)
        Dim dr As OleDbDataReader
        dr = cmd.ExecuteReader()
        Dim lh As New LopHocDto()
        While (dr.Read())
            lh = New LopHocDto()
            lh.Ma = dr("Ma")
            lh.Ten = dr("Ten")
            ds.Add(lh)
        End While
        'B5: Dong ket noi CSDL
        cn.Close()
        Return ds
    End Function

    Public Function LayBang() As DataTable
        Dim dt As New DataTable()
        'B1 & B2: Tao chuoi ket noi, mo ket noi bang doi tuong ket noi
        Dim cn As OleDbConnection
        cn = Database.ConnectionData()
        'B3: Tao chuoi strSQL thao tac CSDL
        Dim strSQL As String
        strSQL = "Select * From LopHoc"
        'B4: Thuc thi chuoi strSQL
        Dim da As New OleDbDataAdapter(strSQL, cn)
        da.Fill(dt)
        'B5: Dong ket noi CSDL
        cn.Close()
        Return dt
    End Function

    Public Sub CapNhatBang(ByVal dt As DataTable)
        'B1 & B2: Tao chuoi ket noi, mo ket noi bang doi tuong ket noi
        Dim cn As OleDbConnection
        cn = Database.ConnectionData()
        'B3: Tao chuoi strSQL thao tac CSDL
        Dim strSQL As String
        strSQL = "Select * From LopHoc"
        'B4: Thuc thi chuoi strSQL
        Dim da As New OleDbDataAdapter(strSQL, cn)
        Dim cb As New OleDbCommandBuilder(da)
        da.Update(dt)
        'B5: Dong ket noi CSDL
        cn.Close()
    End Sub

    Public Function TimKiem(ByVal maLop As Integer) As LopHocDto
        Dim lhDto As New LopHocDto()
        'B1 & B2: Tao chuoi ket noi, mo ket noi bang doi tuong ket noi
        Dim cn As OleDbConnection
        cn = Database.ConnectionData()
        'B3: Tao chuoi strSQL thao tac CSDL
        Dim strSQL As String
        strSQL = "Select * From LopHoc Where Ma = ?"
        'B4: Thuc thi chuoi strSQL
        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.Parameters.Add("@Ma", OleDbType.Integer)
        cmd.Parameters("@Ma").Value = maLop
        Dim dr As OleDbDataReader
        dr = cmd.ExecuteReader()
        While (dr.Read())
            lhDto.Ma = dr("Ma")
            lhDto.Ten = dr("Ten")
        End While
        'B5: Dong ket noi CSDL
        dr.Close()
        cn.Close()
        Return lhDto
    End Function

    Public Sub Them(ByVal lhDto As LopHocDto)
        'B1 & B2: Tao chuoi ket noi, mo ket noi bang doi tuong ket noi
        Dim cn As OleDbConnection
        cn = Database.ConnectionData()
        'B3: Tao chuoi strSQL thao tac CSDL
        Dim strSQL As String
        strSQL = "Insert into LopHoc(Ten) values(?)"
        'B4: Thuc thi chuoi strSQL
        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.Parameters.Add("@Ten", OleDbType.WChar)
        cmd.ExecuteNonQuery()
        strSQL = "Select @@IDENTITY"
        cmd = New OleDbCommand(strSQL, cn)
        lhDto.Ma = cmd.ExecuteScalar()
        'B5: Dong ket noi CSDL
        cn.Close()
    End Sub

    Public Sub Xoa(ByVal maLop As Integer)
        'B1 & B2: Tao chuoi ket noi, mo ket noi bang doi tuong ket noi
        Dim cn As OleDbConnection
        cn = Database.ConnectionData()
        'B3: Tao chuoi strSQL thao tac CSDL
        Dim strSQL As String
        strSQL = "Delete From LopHoc Where Ma = ?"
        'B4: Thuc thi chuoi strSQL
        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.Parameters.Add("@Ma", OleDbType.Integer)
        cmd.Parameters("@Ma").Value = maLop
        cmd.ExecuteNonQuery()
        'B5: Dong ket noi CSDL
        cn.Close()
    End Sub

    Public Sub Sua(ByVal lhDto As LopHocDto)
        'B1 & B2: Tao chuoi ket noi, mo ket noi bang doi tuong ket noi
        Dim cn As OleDbConnection
        cn = Database.ConnectionData()
        'B3: Tao chuoi strSQL thao tac CSDL
        Dim strSQL As String
        strSQL = "Update LopHoc Set Ten = ? Where Ma = ?"
        'B4: Thuc thi chuoi strSQL
        Dim cmd As New OleDbCommand(strSQL, cn)
        cmd.Parameters.Add("@Ten", OleDbType.WChar)
        cmd.Parameters.Add("@Ma", OleDbType.Integer)
        cmd.Parameters("@Ten").Value = lhDto.Ten
        cmd.Parameters("@Ma").Value = lhDto.Ma
        cmd.ExecuteNonQuery()
        'B5: Dong ket noi CSDL
        cn.Close()
    End Sub
End Class
