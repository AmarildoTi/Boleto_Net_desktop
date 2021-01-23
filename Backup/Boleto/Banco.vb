Imports ADODB
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient


Public Class Banco
    Dim conn As Connection
    Dim connMode As Integer = ConnectModeEnum.adModeUnknown
    Dim ConnectionString As String
    Dim connNet As SqlConnection

    Public Sub New()
        'ConnectionString = "Provider=SQLOLEDB.1;Password=pwdcard;Persist Security Info=True;User ID=admcartoes;Initial Catalog=DB_Cartoes;Data Source=192.168.0.40"
        ConnectionString = "Provider=SQLOLEDB.1;Server=AMARILDO-PC\SQLEXPRESS;Database=Boleto;Trusted_Connection=yes;"
    End Sub

    Private Function AbreBanco() As Boolean
        Try
            conn = New Connection
            conn.CursorLocation = CursorLocationEnum.adUseClient
            conn.Open(ConnectionString, "", "", connMode)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub FechaBanco()
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
                conn = Nothing
            End If
        Catch ex As Exception
        Finally
            GC.Collect()
        End Try
    End Sub

    Public Function getDataRS(ByVal SQl As String, ByVal Membro As String) As Recordset
        Dim rs As New ADODB.Recordset
        Try
            If AbreBanco() Then
                rs.DataMember = Membro
                rs.Open(SQl, conn, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic, 0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Falha de rede")
        End Try

        Return rs
    End Function

    Public Sub setData(ByVal SQl As String)
        Try
            If AbreBanco() Then
                conn.Execute(SQl)
                FechaBanco()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox("Falha na conexão dos Dados. Tente novamente mais tarde", MsgBoxStyle.Critical, "Falha de rede")
        End Try
    End Sub

    Public Function getDataDA(ByVal SQl As String, ByVal Membro As String) As DataSet
        Dim cn = New OleDbCommand(SQl, New OleDbConnection(ConnectionString))
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(cn)
        Dim ds As DataSet = New DataSet
        Try
            da.Fill(ds, Membro)
        Catch ex As Exception
            MsgBox("Falha na conexão dos Dados. Tente novamente mais tarde", MsgBoxStyle.Critical, "Falha de rede")
        End Try
        Return ds
    End Function

    Public Sub SetDataNet(ByVal SQl As String, ByVal server As String, ByVal DataSource As String, ByVal user As String, ByVal pwd As String)
        Dim conexao As SqlConnection
        Dim comando As SqlCommand
        conexao = New SqlConnection("server=" & server & ";uid=" & user & ";pwd=" & pwd & ";database=" & DataSource)
        conexao.Open()
        comando = New SqlCommand(SQl, conexao)
        comando.ExecuteNonQuery()
        conexao.Close()
    End Sub

End Class

