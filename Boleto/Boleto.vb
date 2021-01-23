Imports Marpress
Imports Marpress.FichaCompensacao.Bradesco
Imports System.Threading

Public Class Boleto

    Private Util As New Utilidades()

    Private Sub Boleto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Util.Altenticacao()
        GroupBox1.Visible = False
        Dim Posta As New Fac()
        Posta.Fac()
    End Sub

    Private Sub Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buscar.Click

        Saida.Focus()

        Dim Arquivo_Entrada As String
        Dim Arquivo_Saida As String
        Dim Banco As New Dados()
        Dim Gerar As New Spool()
        Dim Posta As New Fac()

        If Not Posta.Modalidade Then

            OpenFileDialog1.ShowDialog()

            Arquivo_Entrada = OpenFileDialog1.FileName

            TextBox1.Text = System.IO.Path.GetFileName(Arquivo_Entrada)

            Arquivo_Saida = Mid(TextBox1.Text, 1, Len(TextBox1.Text) - 4)

            Banco.Zap()
            Banco.Append(Arquivo_Entrada)
            Posta.Processa()
            Gerar.Spool(Arquivo_Saida)

        End If


    End Sub

    Private Sub Saida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Saida.Click
        Saida.FindForm().Close()
    End Sub

End Class

