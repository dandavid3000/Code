Imports System.Data.OleDb
Module MDatabase
    Public Function ConnectionData() As OleDbConnection
        Dim cnStr As String
        cnStr = "Provider=Microsoft.Jet.OLEDB.4.0;"
        cnStr += " Data Source= PTNK.mdb"
        Dim cn As New OleDbConnection(cnStr)
        cn.Open()
        Return cn
    End Function
End Module
