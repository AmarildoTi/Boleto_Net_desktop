Imports System.IO

Public Class Dados

    Private Util As New Utilidades()
    Private Conecta As New Banco()

    Dim header As String
    Dim tabela As String
    Dim campos As String
    Dim dados As String
    Dim Contador As Integer = 0
    Dim ContId As Integer = 0

    'Metodo Zap Para Limpar as Tabelas                                            <p>
    'void                                                                         <p>
    'Exemplo de Uso =  Estrutura.Zap();                                           <P>
    Public Sub Zap()
        Conecta.setData("TRUNCATE TABLE Tipo00")
        Conecta.setData("TRUNCATE TABLE Tipo01")
        Conecta.setData("TRUNCATE TABLE Tipo02")
        Conecta.setData("TRUNCATE TABLE Tipo03")
    End Sub

    '  Metodo Append Para Carregar As Tabelas Com os Dados                          <p>
    '  1 Argumento                                                                  <p>
    '  1º Tipo String                                                               <p>
    '  Exemplo de Uso =  Append(Arquivo_Entrada);                                   <p>
    '  * @param Arquivo_Entrada
    '  * @return 

    Public Sub Append(ByVal Arquivo_Entrada As String)

        '****** Começo Data de processamento
        Dim DataProcessamento As String = DateTime.Now.ToString("ddMMyyyyHH:mm:ss")
        '****** Final Data de processamento

        '****** Começo Invoca Thread Barra de Progresso e Carrega Com o Total de Linhas dos Arquivo
        Boleto.ProgressBar1.Minimum = 0
        Boleto.ProgressBar1.Maximum = Util.TotalLinhas(Arquivo_Entrada)
        '****** Final Invoca Thread Barra de Progresso e Carrega Com o Total de Linhas dos Arquivo

        '****** Começo Layout de Arquivo Carrega o Banco Conexão Sql Server
        If IO.File.Exists(Arquivo_Entrada) Then
            'MsgBox(Arquivo_Entrada)
            For Each Input As String In File.ReadAllLines(Arquivo_Entrada)

                Contador = Contador + 1
                Boleto.ProgressBar1.Value = Contador

                header = ""
                tabela = ""
                campos = ""
                dados = ""

                header = Input.Trim.Substring(0, 2)

                If header.Equals("01") Then
                    ContId = ContId + 1
                    '****** Começo Label de Aviso de Inicialização
                    Boleto.Contador.Text = "Aguarde Carregando Banco de Dados.:" + Space(1) + CStr(ContId)
                    '****** Final Label de Aviso de Inicialização
                End If

                If header.Equals("00") Then     '**** Tabela Tipo00
                    Dim Matriz As New Dictionary(Of String, String)
                    Matriz.Add("TipoRegistro", Mid(Input, 1, 2))
                    Matriz.Add("Agencia     ", Mid(Input, 3, 5))
                    Matriz.Add("Conta       ", Mid(Input, 8, 11))
                    Matriz.Add("Carteira    ", Mid(Input, 19, 2))
                    Matriz.Add("Lixo        ", Mid(Input, 21, 8))
                    Matriz.Add("Banco       ", Mid(Input, 29, 8))
                    Dim lista As New List(Of String)(Matriz.Keys)
                    Dim str As String
                    For Each str In lista
                        campos += str.Trim + ","
                        dados += "'" + Matriz.Item(str).Trim + "'" + ","
                    Next
                ElseIf header.Equals("01") Then '**** Tabela Tipo01
                    Dim Matriz As New Dictionary(Of String, String)
                    Matriz.Add("TipoRegistro", Mid(Input, 1, 2))
                    Matriz.Add("Cep         ", Mid(Input, 3, 8))
                    Matriz.Add("Processo    ", Mid(Input, 11, 8))
                    Matriz.Add("Nossonum    ", Mid(Input, 19, 14))
                    Matriz.Add("DigNosso    ", Mid(Input, 33, 1))
                    Matriz.Add("Nome        ", Mid(Input, 34, 40))
                    Matriz.Add("Cpf         ", Mid(Input, 74, 14))
                    Matriz.Add("Endereco    ", Mid(Input, 88, 55))
                    Matriz.Add("Cidade      ", Mid(Input, 143, 20))
                    Matriz.Add("Estado      ", Mid(Input, 163, 2))
                    Matriz.Add("Vencimento  ", Mid(Input, 165, 10))
                    Matriz.Add("Limite      ", Mid(Input, 175, 10))
                    Matriz.Add("Telefone    ", Mid(Input, 185, 12))
                    Matriz.Add("CodDevedor  ", Mid(Input, 197, 8))
                    Matriz.Add("CodCredor   ", Mid(Input, 205, 4))
                    Matriz.Add("Remessa     ", Mid(Input, 209, 6))
                    Matriz.Add("Brancos     ", Mid(Input, 215, 52))
                    Matriz.Add("Filial01    ", Mid(Input, 267, 70))
                    Matriz.Add("Filial02    ", Mid(Input, 337, 70))
                    Matriz.Add("Filial03    ", Mid(Input, 407, 70))
                    Matriz.Add("Filial04    ", Mid(Input, 477, 70))
                    Matriz.Add("Filial05    ", Mid(Input, 547, 70))
                    Matriz.Add("Filial06    ", Mid(Input, 617, 70))
                    Matriz.Add("Filial07    ", Mid(Input, 687, 70))
                    Matriz.Add("Titulo1     ", Mid(Input, 757, 50))
                    Matriz.Add("Titulo2     ", Mid(Input, 807, 50))
                    Matriz.Add("Contrato    ", Mid(Input, 857, 20))
                    Matriz.Add("Desconto    ", Mid(Input, 877, 3))
                    Matriz.Add("ValorTot    ", Mid(Input, 880, 10))
                    Matriz.Add("CodDivida   ", Mid(Input, 890, 10))
                    Matriz.Add("Lixo_1_To1  ", Mid(Input, 900, 10))
                    Matriz.Add("NossoNum2   ", Mid(Input, 910, 16))
                    Matriz.Add("Brancos01   ", Mid(Input, 926, 9))
                    Matriz.Add("Id          ", Util.Padl(Convert.ToString(ContId) + Util.StrTran(DataProcessamento.Trim, ":", ""), 24, "0"))
                    Dim lista As New List(Of String)(Matriz.Keys)
                    Dim str As String
                    For Each str In lista
                        campos += str.Trim + ","
                        dados += "'" + Matriz.Item(str).Trim + "'" + ","
                    Next
                ElseIf header.Equals("02") Then '**** Tabela Tipo02
                    Dim Matriz As New Dictionary(Of String, String)
                    Matriz.Add("TipoRegistro", Mid(Input, 1, 2))
                    Matriz.Add("Vencimento  ", Mid(Input, 3, 10))
                    Matriz.Add("ValorAtual  ", Mid(Input, 13, 10))
                    Matriz.Add("Desconto    ", Mid(Input, 23, 10))
                    Matriz.Add("ValorDesc   ", Mid(Input, 33, 10))
                    Matriz.Add("Contrato    ", Mid(Input, 43, 10))
                    Matriz.Add("CodSegu2    ", Mid(Input, 53, 10))
                    Matriz.Add("PercDesc2   ", Mid(Input, 63, 10))
                    Matriz.Add("Id          ", Util.Padl(Convert.ToString(ContId) + Util.StrTran(DataProcessamento.Trim, ":", ""), 24, "0"))
                    Dim lista As New List(Of String)(Matriz.Keys)
                    Dim str As String
                    For Each str In lista
                        campos += str.Trim + ","
                        dados += "'" + Matriz.Item(str).Trim + "'" + ","
                    Next
                ElseIf header.Equals("03") Then '**** Tabela Tipo03
                    Dim Matriz As New Dictionary(Of String, String)
                    Matriz.Add("TipoRegistro", Mid(Input, 1, 2))
                    Matriz.Add("Parcelas    ", Mid(Input, 3, 2))
                    Matriz.Add("ValorEntrada", Mid(Input, 5, 10))
                    Matriz.Add("ValorParcela", Mid(Input, 15, 10))
                    Matriz.Add("ValorAvista ", Mid(Input, 25, 10))
                    Matriz.Add("CodSeg      ", Mid(Input, 35, 10))
                    Matriz.Add("PercDesc3   ", Mid(Input, 45, 10))
                    Matriz.Add("Cet_Mes     ", Mid(Input, 55, 10))
                    Matriz.Add("Cet_Ano     ", Mid(Input, 65, 10))
                    Matriz.Add("Id          ", Util.Padl(Convert.ToString(ContId) + Util.StrTran(DataProcessamento.Trim, ":", ""), 24, "0"))
                    Dim lista As New List(Of String)(Matriz.Keys)
                    Dim str As String
                    For Each str In lista
                        campos += str.Trim + ","
                        dados += "'" + Matriz.Item(str).Trim + "'" + ","
                    Next
                End If
                '//************* Começo Trata String SQL, Carrega Banco e Atualiza Formulário
                tabela = "Tipo" + header + Space(1)
                campos = campos.Substring(0, campos.Length - 1)
                dados = dados.Substring(0, dados.Length - 1)
                Conecta.setData("Insert Into" + Space(1) + tabela + "(" + campos + ") values (" + dados + ")")
                Application.DoEvents() 'Atualiza Mudanças No Formulario
                '//************* Final Trata String SQL,Carrega Banco e Atualiza Formulário
            Next
            Conecta.FechaBanco()
        Else
            MessageBox.Show("Arquivo não existe")
        End If
        '****** Final Layout de Arquivo Carrega o Banco Conexão Sql Server
    End Sub

End Class
