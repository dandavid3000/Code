Imports System.Data.OleDb

Public Class Database
    Public Shared Function ConnectionData() As OleDbConnection
        'B1: tao chuoi cnStr
        Dim cnStr As String
        cnStr = "Provider = Microsoft.Jet.OLEDB.4.0;"
        cnStr = cnStr + "Data Source = ..\..\Database\TruongHoc.mdb"
        'B2: mo ket noi CSDL
        Dim cn As New OleDbConnection(cnStr)
        cn.Open()
        Return cn
    End Function
End Class
