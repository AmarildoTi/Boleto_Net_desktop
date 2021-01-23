Imports Marpress
Imports System.IO
Imports Marpress.FichaCompensacao.Bradesco

Public Class Spool

    Private Util As New Utilidades()

    Dim Eof As New ADODB.Recordset
    Dim QtdeArqs, sequencia, SeqX As Integer
    Dim SeqExt As Integer = 1
    Dim Ind1 As Integer = 1
    Dim CepLocal, ImpCepLocal As Integer
    Dim CepEstadual, ImpCepEstadual As Integer
    Dim CepNacional, ImpCepNacional As Integer
    Dim Quebra As Integer = 500
    Dim Arq, ArqOs, CodCif As String
    Dim Imprime, Fim As Boolean
    Dim TipoX() As String = New String(1) {}
    Dim LinhaF(,) As String = New String(1, 31) {}
    Dim LinhaV(,) As String = New String(1, 9) {}

    '  Metodo para, Criar Spool de Impressão para Posicionamento de Variaveis     <p>
    '  1 Argumento                                                                <p>
    '  1º do tipo String                                                          <p>
    '  Exemplo de Uso = ImprimeSpool(String Arquivo)                              <p>
    '  Retorno void                                                               <p>
    '  * @param Arquivo
    '  * @throws java.sql.SQLException

    Public Sub Spool(ByVal arquivo As String)

        Dim Conecta As New Banco()

        '//*********************************  Começo Seleciona Banco de Dados ************************************   
        Eof = Conecta.getDataRS("SELECT * FROM Tipo01 ORDER BY Cep ASC", "0") '// Seleciona o Banco de Dados Por Ordem de Cep
        ' //********************************* Final Seleciona Banco de Dados *** *********************************   

        '//********************************* Começo Invoca Thread Barra de Progresso e Carrega Quantidade de Registro de uma Tabela ***************   
        Dim Cont As Integer = Eof.RecordCount
        Boleto.ProgressBar1.Minimum = 0
        Boleto.ProgressBar1.Maximum = Cont
        '//*********************************  Final  Invoca Thread Barra de Progresso e Carrega Quantidade de Registro de uma Tabela ***************   

        '//*********************************  Começo Contador para Quebra de Arquivo
        QtdeArqs = Cont / Quebra + 1
        '//*********************************  Final  Contador para Quebra de Arquivo

        '//*********************************  Começo Deletar Aquivos Para Gerar Novos 
        Util.DelArqs(arquivo, QtdeArqs)
        '//*********************************  Final Deletar Aquivos Para Gerar Novos  

        '//*********************************  Começo While para Captuar as Variavéis para Impressão
        Eof.MoveFirst()
        While Not Eof.EOF
            '//***************************** Começo Total de Registros com ProgressBar e Label Contador
            sequencia = sequencia + 1
            SeqX = SeqX + 1
            Boleto.ProgressBar1.Value = sequencia
            Boleto.Contador.Text = "Gerando Spool Contador...: " + Space(1) + CStr(sequencia)
            '//***************************** Final Total de Registros e Label Contador

            '//***************************** Começo Totais Local Estadual  Nacional e Cep erro
            '//**** Local  
            If CInt(Eof.Fields("Cep").Value < 10000000) Then
                CepLocal = CepLocal + 1
                ImpCepLocal = ImpCepLocal + 1
                Boleto.Local.Text = "Local........: " + Space(1) + CStr(ImpCepLocal)
            End If
            '//**** Estadual  
            If CInt(Eof.Fields("Cep").Value) >= 11000000 And (Eof.Fields("Cep").Value) < 20000000 Then
                CepEstadual = CepEstadual + 1
                ImpCepEstadual = ImpCepEstadual + 1
                Boleto.Estadual.Text = "Estadual...: " + Space(1) + CStr(ImpCepEstadual)
            End If
            '//**** Nacional  
            If CInt(Eof.Fields("Cep").Value >= 20000000) Then
                CepNacional = CepNacional + 1
                ImpCepNacional = ImpCepNacional + 1
                Boleto.Nacional.Text = "Nacional...: " + Space(1) + CStr(ImpCepNacional)
            End If
            '//***************************** Final Totais Local Estadual  Nacional e Cep erro

            ArqOs = arquivo + ".OS"
            Arq = arquivo + "." + Util.Padl(Convert.ToString(SeqExt), 3, "0")
            Boleto.Label4.Text = "Aquivo de Saida......:" + Space(1) + Arq

            If sequencia Mod Quebra = 1 Then
                Util.Write(Arq, "%!")
                Util.Write(Arq, "XGF")
                Util.Write(Arq, "500 SETBUFSIZE")
                Util.Write(Arq, "(PRINCIPAL.JDT) STARTLM")
            End If

            If sequencia Mod Quebra = 0 Or sequencia = Cont Then
                Fim = True
                SeqExt = SeqExt + 1
                Util.Write(ArqOs, "A;" + Arq + ";" + Space(1) + Util.Padl(Convert.ToString(SeqX).Trim(), 5, "0") + ";" + Space(1) + Util.Padl(Convert.ToString(CepLocal).Trim(), 5, "0") + ";" + Space(1) + Util.Padl(Convert.ToString(CepEstadual).Trim(), 5, "0") + ";" + Space(1) + Util.Padl(Convert.ToString(CepNacional).Trim(), 5, "0"))

                If sequencia = Cont Then
                    Util.Write(ArqOs, "J;" + "PRINCIPAL.JDT")
                    Util.Write(ArqOs, "J;" + "HOEPERS93.JDT")
                    Util.Write(ArqOs, "J;" + "HOEPERS.JDT")
                    Util.Write(ArqOs, "P;" + "hoepers93.ps")
                    Util.Write(ArqOs, "P;" + "hoepers.ps")
                End If

                SeqX = 0
                CepLocal = 0
                CepEstadual = 0
                CepNacional = 0

            Else
                Fim = False
            End If

            Dim XVencDia = Util.StrTran(Eof.Fields("Vencimento").Value.Trim(), "/", "").Substring(0, 2)
            Dim XVencMes = Util.StrTran(Eof.Fields("Vencimento").Value.Trim(), "/", "").Substring(2, 2)
            Dim XVencAno = Util.StrTran(Eof.Fields("Vencimento").Value.Trim(), "/", "").Substring(4, 4)

            Dim DataProcessamento As String = DateTime.Now.ToString("ddMMyyyy")

            '//********************************* Começo Captura dados Para o Boleto Bancario Sets
            Dim brad As New Bradesco(6, 324, 7, 169983, 0, Str(Val(Eof.Fields("NossoNum").Value)), Convert.ToDouble(Util.EditaDois(Eof.Fields("ValorTot").Value)), New Date(XVencAno, XVencMes, XVencDia))
            '//********************************* Final Captura dados Para o Boleto Bancario Sets

            '//********************************* Começo Canal do Spool Repassar Codigo Cif Ou Id Com 34 Posições
            If Boleto.ComboBox2.SelectedItem.Equals("Produção") Then
                TipoX(Ind1) = "01" + Space(1) + Eof.Fields("CodCif").Value
            Else
                TipoX(Ind1) = "01" + Space(1) + Util.Padl(Eof.Fields("Id").Value, 34, "0")
            End If
            '//********************************* Final Canal do Spool  Repassar Codigo Cif Ou Id Com 34 Posições

            '//********************************* Começo Carrega As Variaveis Para Impressao 

            '//********************************* Começo Parte Da Frente Boleto
            LinhaF(Ind1, 1) = Space(1) + Eof.Fields("Cpf").Value
            LinhaF(Ind1, 2) = Space(1) + Eof.Fields("Contrato").Value
            LinhaF(Ind1, 3) = Space(1) + Eof.Fields("Nome").Value
            LinhaF(Ind1, 4) = Space(1) + "R$" + Space(1) + CDbl(Util.EditaDois(Eof.Fields("ValorTot").Value)).ToString("#,###.00")
            LinhaF(Ind1, 5) = Space(1) + brad.LinhaDigitavel
            LinhaF(Ind1, 6) = Space(1) + brad.LocalPagamento
            LinhaF(Ind1, 7) = Space(1) + "Após Vencimento somente no Bradesco"
            LinhaF(Ind1, 8) = Space(1) + "Hoepers S/A."
            LinhaF(Ind1, 9) = Space(1) + Eof.Fields("Vencimento").Value
            LinhaF(Ind1, 10) = Space(1) + brad.AgenciaCodigoCedente
            LinhaF(Ind1, 11) = Space(1) + Util.Stuff(Util.Stuff(DataProcessamento, 2, "/"), 5, "/")
            LinhaF(Ind1, 12) = Space(1) + brad.NumeroDocumento
            LinhaF(Ind1, 13) = Space(1) + brad.EspecieDocumento
            LinhaF(Ind1, 14) = Space(1) + brad.Aceite
            LinhaF(Ind1, 15) = Space(1) + Util.Stuff(Util.Stuff(DataProcessamento, 2, "/"), 5, "/")
            LinhaF(Ind1, 16) = Space(1) + brad.NossoNumero
            LinhaF(Ind1, 17) = Space(1) + brad.Carteira()
            LinhaF(Ind1, 18) = Space(1) + "R$"
            LinhaF(Ind1, 19) = Space(1) + CDbl(Util.EditaDois(Eof.Fields("ValorTot").Value)).ToString("#,###.00")
            LinhaF(Ind1, 20) = Space(1)
            LinhaF(Ind1, 21) = Space(1) + "APOS O VENCIMENTO COBRAR MULTA DE 2%"
            LinhaF(Ind1, 22) = Space(1) + "APOS O VENCIMENTO COBRAR R$ 0,50 POR DIA"
            LinhaF(Ind1, 23) = Space(1) + ""
            LinhaF(Ind1, 24) = Space(1) + ""
            LinhaF(Ind1, 25) = Space(1) + ""
            LinhaF(Ind1, 26) = Space(1)
            LinhaF(Ind1, 27) = Space(1) + Eof.Fields("Nome").Value
            LinhaF(Ind1, 28) = Space(1) + Eof.Fields("Endereco").Value
            LinhaF(Ind1, 29) = Space(1) + Util.Stuff(Eof.Fields("Cep").Value, 6, "-") + " - " + Eof.Fields("Cidade").Value.trim() + " - " + Eof.Fields("Estado").Value
            LinhaF(Ind1, 30) = Space(1) + brad.CodigoDeBarras  'Funcoes.Cod_Bar(brad.CodigoDeBarras)
            '//********************************* Final Parte Da Frente Boleto

            '//********************************* Começo Verso Do Boleto Endereçamento
            LinhaV(Ind1, 1) = Space(1) + Util.StrTran(Util.Postnet(Eof.Fields("Cep").Value), "*", "")
            LinhaV(Ind1, 2) = Space(1) + Eof.Fields("Nome").Value
            LinhaV(Ind1, 3) = Space(1) + Eof.Fields("Endereco").Value
            LinhaV(Ind1, 4) = Space(1) + Eof.Fields("Cidade").Value.trim() + " - " + Eof.Fields("Estado").Value
            LinhaV(Ind1, 5) = Space(1) + Util.Stuff(Eof.Fields("Cep").Value, 5, "-")
            LinhaV(Ind1, 6) = Space(1) + Util.Padl(Convert.ToString(sequencia), 7, "0") + Space(1) + "Arq:" + Space(1) + Arq
            LinhaV(Ind1, 7) = Space(1) + Mid(TipoX(Ind1), 4, 34).Trim
            LinhaV(Ind1, 8) = Space(1)
            '//********************************* Final Verso Do Boleto Endereçamento

            '//********************************* Final Carrega As Variaveis Para Impressao 

            '//********************************* Começo Imprime e Limpa Variaveis
            Util.Write(Arq, "+$DJDE$ FORMS=HOEPERSF,FEED=BAN3,END;")
            For Ind1 As Integer = 1 To 1
                For Ind2 As Integer = 1 To 30
                    Util.Write(Arq, TipoX(Ind1) + LinhaF(Ind1, Ind2))                           '//Para Imprimir as Variaveis Em arquivo Texto
                Next
            Next
            Util.Write(Arq, "+$DJDE$ FORMS=HOEPERSV,FEED=BAN3,END;")
            For Ind1 As Integer = 1 To 1
                For Ind2 As Integer = 1 To 8
                    Util.Write(Arq, TipoX(Ind1) + LinhaV(Ind1, Ind2))                           '//Para Imprimir as Variaveis Em arquivo Texto    
                Next
            Next
            '//********************************* Final Imprime e Limpa Variaveis

            '//********************************* Começo = Fecha, Finaliza Quebra de arquivo e gera o PDF
            If Fim Then
                Boleto.Label5.Visible = True
                Boleto.Label5.Text = "Aguarde...: Gerando Pdf "
                Application.DoEvents()
                Util.Writer(Arq)                                                           '//Gerar Pdf
            Else
                Boleto.Label5.Visible = False
                Application.DoEvents()
            End If
            '//********************************* Final  = Fecha, Finaliza Quebra de arquivo e gera o PDF

            '//********************************* Começo Move Ponteiro no Banco
            Eof.MoveNext()
            '//********************************* Final  Move Ponteiro no Banco

            '//********************************* Começo Atualiza Formulário
            Application.DoEvents()
            '//********************************* Final  Atualiza Formulário

        End While
        '//********************************* Final  While para Captuar as Variavéis para Impressão
        Boleto.Label5.Text = "Processo Finalizado com sucesso!!"
        Application.DoEvents()
        '//********************************* Começo Fecha Arquivo Texto e Banco de dados
        Eof.Close()
        Conecta.FechaBanco()
        Boleto.ComboBox1.Enabled = True
        Boleto.ComboBox2.Enabled = True
        Boleto.ComboBox3.Enabled = True
        Boleto.ComboBox4.Enabled = True
        Boleto.MaskedDataPostagem.Enabled = True
        '//********************************* Final  Fecha Arquivo Texto e Banco de dados
    End Sub

End Class
