Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf


Public Class Utilidades


    'Metodo Space Para Inserir Espaços em Branco                                <p>
    '1 Argumento                                                                <p>
    '1º Tipo inteiro                                                            <p>
    'Primeiro,Argumento Quantidade de espaços a inserir                         <p>
    'Exemplo de Uso =  Util.Space(1);                                           <p> 
    '* @param Qtde
    '* @return 
    Public Function Space(ByVal Qtde As Integer) As String
        Dim aux As String = ""
        For Indice As Integer = 0 To Qtde
            aux = aux + " "
        Next
        Return aux
    End Function
    '  Metodo Stuff Para Inserir Caracter Em uma Determinda Posição no Campo      <p>
    '  3 Argumentos                                                               <p>
    '  1º do tipo String, Argumento Campo                                         <p>
    '  2º do Tipo Inteito, quantidade de caracter antes da  Posição               <p>
    '  3º do Tipo String,Qual o Caracter a Inserir                                <p>
    '  Exemplo de Uso =  Util.Stuff(Campo,5,"-");                                 <p> 
    '  * @param Campo
    '  * @param Qtde
    '  * @param Caracter
    '  * @return aux
    Public Function Stuff(ByVal Campo As String, ByVal Qtde As Integer, ByVal Caracter As String) As String
        Dim aux As String = ""
        Dim ByteCampo As String = ""
        For Indice As Integer = 0 To Campo.Length - 1
            ByteCampo = Campo.Substring(Indice, 1)
            If Indice = Qtde Then
                aux = aux + Caracter + ByteCampo
            Else
                aux = aux + ByteCampo
            End If
        Next
        Return aux
    End Function
    '  Metodo Padl Para Inserir Caracter a Esquerda do Campo                      <p>
    '  3 Argumentos                                                               <p>
    '  1º do tipo String, Argumento Campo                                         <p>
    '  2º do Tipo Inteito, Quantidade de Caracter a ser Inserido                  <p>
    '  3º do Tipo String,Qual o Caracter a Inserir                                <p>
    '  Exemplo de Uso =  Util.Padl(Campo,3,"0");                                  <p> 
    '  * @param Campo
    '  * @param Qtde
    '  * @param Caracter
    '  * @return aux 
    Public Function Padl(ByVal Campo As String, ByVal Qtde As Integer, ByVal Caracter As String) As String
        Dim aux As String = ""
        For Indice As Integer = 1 To Qtde - Campo.Length
            If Indice = Qtde - Campo.Length Then
                aux = aux + Caracter + Campo
            Else
                aux = aux + Caracter
            End If
        Next
        Return aux
    End Function
    ' Metodo Padr Para Inserir Caracter a Direita do Campo                       <p>
    ' 3 Argumentos                                                               <p>
    ' 1º do tipo String, Argumento Campo                                         <p>
    ' 2º do Tipo Inteito, Quantidade de Caracter a ser Inserido                  <p>
    ' 3º do Tipo String,Qual o Caracter a Inserir                                <p>
    ' Exemplo de Uso =  Util.Padr(Campo,3,"0");                                  <p> 
    ' * @param Campo
    ' * @param Qtde
    ' * @param Caracter
    ' * @return aux
    Public Function Padr(ByVal Campo As String, ByVal Qtde As Integer, ByVal Caracter As String) As String
        Dim aux As String = ""
        For Indice As Integer = 1 To Qtde - Campo.Length
            If Indice = Qtde - Campo.Length Then
                aux = Campo + aux + Caracter
            Else
                aux = aux + Caracter
            End If
        Next
        Return aux
    End Function
    '  Metodo RetZeros Para Retirar Zeros a Esquedas Campo                        <p>
    '  1 Argumentos                                                               <p>
    '  1º do tipo String, Argumento Campo                                         <p>
    '  Exemplo de Uso =  Util.RetZeros(Campo);                                    <p> 
    '  * @param Campo
    '  * @return aux
    Public Function RetZeros(ByVal Campo As String) As String
        Dim aux As String = ""
        For Indice As Integer = 0 To Campo.Length - 1
            If Not Campo.Substring(Indice, 1) = 0 Then
                aux += Campo.Substring(Indice, 1)
            End If
        Next
        Return aux
    End Function
    '  Metodo Para Editar Formato de Moeda                                        <p>
    '  1 Argumentos                                                               <p>
    '  1º do tipo String, Argumento Campo                                         <p>
    '  Exemplo de Uso =  Util.EditaDois(Campo)                                    <p> 
    '  * @param Campo
    '  * @return Valor
    Public Function EditaDois(ByVal Campo As String) As String
        Dim Valor As String = ""
        Dim Mvalor As Single = Str(Val(Campo))
        Dim Valor1 As String = Mvalor
        Dim Valor2 = Valor1.Substring(0, Valor1.Length - 2)
        Dim Valor3 = Valor1.Substring(Valor1.Length - 2)
        Valor = Valor2 + Valor3
        Return Valor
    End Function
    '  Metodo para, Retira Caracteres do campo e Substitui Por Outro              <p>
    '  3 Argumentos                                                               <p>
    '  1º do tipo String                                                          <p>
    '  2º do tipo String                                                          <p>
    '  3º do tipo String                                                          <p>
    '  Exemplo de Uso = Util.StrTran(Campo,Caracteres,SubCaracter);               <p>
    '  StrTran("Am#ar%i?ldo#?@","@?%#",Space(00))                                 <p>
    '  * @param Campo
    '  * @param Caracter
    '  * @param SubCaracter
    '  * @return aux
    Public Function StrTran(ByVal Campo As String, ByVal Caracter As String, ByVal SubCaracter As String) As String
        Dim aux As String = ""
        Dim ByteCampo As String = ""
        Dim ByteCaracter As String = ""
        Dim ContCampo As Integer = 0
        Dim ContCaracter As Integer = 0
        Dim Acrescenta As Integer = 0
        Dim Verifica As Boolean = False
        For I As Integer = 0 To Campo.Length - 1
            ContCaracter = 0
            Acrescenta = 1
            ByteCampo = Campo.Substring(I, 1)
            For J As Integer = 0 To Caracter.Length - 1
                ContCaracter = ContCaracter + 1
                ByteCaracter = Caracter.Substring(J, 1)
                Verifica = ByteCampo.Equals(ByteCaracter)
                If Verifica Then
                    Acrescenta = 0
                End If
            Next
            If Not Verifica And Acrescenta = 1 Then
                Acrescenta = Acrescenta + 1
                aux = aux + ByteCampo
            Else
                aux = aux + SubCaracter
            End If
        Next
        Return aux
    End Function
    '  Metodo para, Deletar Arquivos                                              <p>
    '  2 Argumentos do Tipo String                                                <p>
    '  Primeiro Argumento, Nome do Arquivo                                        <p>
    '  Segundo  Argumento, Quantidade de Arquivos                                 <p>
    '  Exemplo de Uso =  Util.Write(NomeArquivo,Qtde);                            <p> 
    '  * @param arquivo
    '  * @param Qtde
    '  * Void
    Public Sub DelArqs(ByVal arquivo As String, ByVal Qtde As Integer)
        For X As Integer = 0 To X <= Qtde                                            '//-----\  Faz Até Atingir a Quantidade de Arquivos 
            File.Delete(arquivo + "." + Padl(Convert.ToString(X), 3, "0"))           '//----- > Deleta Os Arquivo para Gerar Novos Arquivos
            File.Delete(arquivo + Padl(Convert.ToString(X), 3, "0") + ".Pdf")        '//----- > Deleta Os Arquivo para Gerar Novos Arquivos
        Next                                                                         '//-----/  Apenas se Os Arquivos já Existirem na Pasta
        File.Delete(arquivo + ".OS")                                                 '//----- > Deleta Arquivo .Os Para Gera Novo Arquivo
    End Sub
    '  Metodo para, Contar Total de Linha do Arquivo                              <p>
    '  1 Argumentos do Tipo String                                                <p>
    '  Primeiro Argumento, Nome do Arquivo                                        <p>
    '  * @param Arquivo
    '  * Return quantasLinhas.ToString()
    Public Function TotalLinhas(ByVal Arquivo As String) As Integer
        Dim leitura As StreamReader
        Dim quantasLinhas As Integer
        leitura = File.OpenText(Arquivo)
        While leitura.Peek() <> -1
            leitura.ReadLine()
            quantasLinhas += 1
        End While
        leitura.Close()
        Return quantasLinhas.ToString()
    End Function
    '  Metodo para, Gravar em arquivo Texto                                       <p>
    '  2 Argumentos do Tipo String                                                <p>
    '  Primeiro Argumento, Nome do Arquivo                                        <p>
    '  Segundo  Argumento, Conteudo a Ser Gravado                                 <p>
    '  Exemplo de Uso =  Util.Write(NomeArquivo,Conteudo);                        <p> 
    '  * @param arquivo
    '  * @param conteudo
    '  * Void
    Public Sub Write(ByVal arquivo As String, ByVal conteudo As String)
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(arquivo, True)
        file.WriteLine(conteudo)
        file.Flush()
        file.Dispose()
        file.Close()
    End Sub

    '  Metodo para, Criar Pasta e Move Arquivos Para Um Diretorio Determinado     <p>
    '  3 Argumentos do Tipo String                                                <p>
    '  Primeiro Argumento, Caminho Da Pasta de Origem                             <p>
    '  Primeiro Argumento, Caminho Da Pasta de Destino                            <p>
    '  Segundo  Argumento, Nome do Arquivo a Se Criado Na Pasta                   <p>
    '  Exemplo de Uso =  Util.Diretorio(Caminho_Origem,Caminho_Destino,Arquivo)   <p> 
    '  * @param Caminho_Origem
    '  * @param Caminho_Destino
    '  * @param Arquivo
    '  * Void
    Public Sub Diretorio(ByVal Caminho_Origem As String, ByVal Caminho_Destino As String, ByVal Arquivo As String)
        If Not Directory.Exists(Caminho_Destino) Then
            System.IO.Directory.CreateDirectory(Caminho_Destino)
        End If
        File.Move(Caminho_Origem & "/" & Arquivo, Caminho_Destino & "/" & Arquivo)
    End Sub
    '  Metodo para, Validar e Expirar o Software Após Data Programada            <p>
    '  Exemplo de Uso =  Util.Valida()                                           <p> 
    '  * Void                                                                    <p>
    Public Sub Altenticacao()
        Dim DataFirst = Date.Now
        If File.Exists(Application.StartupPath & "\Amarildo") Then
            Dim A As String() = File.ReadAllLines(Application.StartupPath & "\Amarildo")
            For Each Text As String In A
                Dim resultado As Date
                resultado = BASE64_Decode(Text)
                If Date.Now >= resultado Then
                    MessageBox.Show("O Programa Irá Fechar Porque Ultrapassou O Limite de Dias", "A data Limite Expirou", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Application.Exit()
                End If
            Next
        Else
            Dim Validade As String
            Dim data As Date
            data = Now.Date
            Validade = data.AddDays(3)
            Dim dataencriptada As String = BASE64_Encode(Validade.ToString)
            Using sw As StreamWriter = File.CreateText(Application.StartupPath & "\Amarildo")
                sw.Write(dataencriptada)
            End Using
        End If
        SetAttr(Application.StartupPath & "\Amarildo", vbHidden) 'Oculta Pasta E/Ou Arquivo
        'SetAttr(Application.StartupPath & "\Amarildo", vbNormal) 'DesOculta Pasta E/Ou Arquivo
    End Sub
    '  Metodo para, Criptografia                                                 <p>
    '  Exemplo de Uso =  Util.Valida()                                           <p> 
    Public Function BASE64_Encode(ByVal input As String) As String
        Try
            Return Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(input))
        Catch ex As Exception
            MsgBox("Error !")
            Return 0
        End Try
    End Function
    '  Metodo para, DesCriptografia                                              <p>
    '  Exemplo de Uso =  Util.Valida()                                           <p> 
    Public Function BASE64_Decode(ByVal input As String) As String
        Try
            Return System.Text.Encoding.ASCII.GetString(Convert.FromBase64String(input))
        Catch ex As Exception
            MsgBox("Error !")
            Return 0
        End Try
    End Function
    '  Metodo para, Criar Pdf                                                     <p>
    '  1 Argumentos do Tipo String                                                <p>
    '  Primeiro Argumento, Nome do Arquivo                                        <p>
    '  Exemplo de Uso =  Util.Write(NomeArquivo);                                 <p> 
    '  * @param arquivo
    '  * Void
    Public Sub Writer(ByVal arquivo As String)

        Dim cont As Integer = 0
        Dim contLine As Integer = 0
        Dim indice As Integer = 1
        Dim linha As String = ""
        Dim Imagem As String = ""
        Dim altura As Double = 817

        Try
            '// Class StreamReader Parar Ler o Arquivo Txt
            Dim bufReader As StreamReader
            bufReader = New StreamReader(arquivo)
            linha = bufReader.Read

            '// Cria PDF
            Dim MyDocument As Document = New Document(PageSize.A4)

            '// carregando o gif de Frente
            Dim fundoF = Image.GetInstance("C:/Amarildo/Boleto_VB.Net/Boleto/img/HOEPERSF.gif")
            fundoF.ScaleAbsolute(540, 792)
            fundoF.SetAbsolutePosition(30, 30)

            '// carregando o gif de Verso
            Dim fundoV = Image.GetInstance("C:/Amarildo/Boleto_VB.Net/Boleto/img/HOEPERSV.gif")
            fundoV.ScaleAbsolute(595, 840)
            fundoV.SetAbsolutePosition(0, 0)

            '//Escrever no PDF do TXT   
            Dim Writer = iTextSharp.text.pdf.PdfWriter.GetInstance(MyDocument, New System.IO.FileStream(arquivo + ".Pdf", FileMode.Create))

            '//Abrir PDF 
            MyDocument.Open()

            '// Para Poder Escrever No Pdf
            Dim contentByte As PdfContentByte = Writer.DirectContent()

            '// Objeto codeBarra Para Gerar Codigo de Barras Bancario
            Dim codeBarra As BarcodeInter25 = New BarcodeInter25()
            '// Objeto codePost Para Gerar Codigo de Barras postal
            Dim codePost As BarcodePostnet = New BarcodePostnet()
            '// Objeto Codcif Para Gerar Codigo de Barras CifFac
            Dim codCif As Barcode128 = New Barcode128()
            '// Objeto Qr-Code Para Gerar Codigo de Barras QrCode
            Dim myString As String = "Amarildo Dos Santos de Lima Teste QrCode"
            Dim qrcode As BarcodeQRCode = New BarcodeQRCode(myString.Trim(), 1, 1, Nothing)

            '// define as fontes a serem usadas   
            Dim F1 As BaseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.WINANSI, BaseFont.EMBEDDED)
            Dim F2 As BaseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.WINANSI, BaseFont.EMBEDDED)
            Dim F3 As BaseFont = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.WINANSI, BaseFont.EMBEDDED)

            '// Começa a ler o arquivo Linha a Linha

            While linha <> Nothing
                '//Começo Skip ou next proxima linha
                arquivo &= linha & vbCrLf
                linha = bufReader.ReadLine
                '//Fim Skip ou next proxima linha

                cont = cont + 1
                contLine = contLine + 1

                If cont > 4 And Mid(linha, 2, 6).Equals("$DJDE$") Then
                    contLine = 1
                    If indice <> 1 Then
                        MyDocument.NewPage()
                    End If
                    Imagem = linha.Substring(linha.IndexOf("+$DJDE$ FORMS=") + "+$DJDE$ FORMS=".Length(), linha.IndexOf(",FEED=BAN3,END;") + -",FEED=BAN3,END;".Length() + 1)
                    If Imagem.Equals("HOEPERSF") Then
                        MyDocument.Add(fundoF)
                    ElseIf Imagem.Equals("HOEPERSV") Then
                        MyDocument.Add(fundoV)
                    End If
                    indice = 2
                End If
                If cont > 4 Then

                    '// abre a insercao de texto e insire a fonte do documento   
                    contentByte.BeginText()
                    contentByte.SetFontAndSize(F1, 6)

                    '// define o posicionamento na tela por uma matriz de pixels e escreve o texto   
                    If Imagem.Equals("HOEPERSF") Then
                        '// Objeto qrCode Para Gerar Codigo de Barras qrCode
                        Dim qrcodeImage As Image = qrcode.GetImage()
                        qrcodeImage.SetAbsolutePosition(35, 780)
                        qrcodeImage.ScalePercent(150)
                        MyDocument.Add(qrcodeImage)
                        Select Case contLine
                            Case 1
                                '    contentByte.SetFontAndSize(F3, 9)
                                '    contentByte.SetTextMatrix(MyDocument.Left() + 5, altura - (10))
                            Case 2
                                '    contentByte.SetFontAndSize(F3, 9)
                                '    contentByte.SetTextMatrix(MyDocument.Right() + 5, altura - (14))
                            Case 3
                                contentByte.SetFontAndSize(F1, 8)
                                contentByte.SetTextMatrix(MyDocument.Left() + 215, altura - (51))
                            Case 4
                                contentByte.SetFontAndSize(F3, 9)
                                contentByte.SetTextMatrix(MyDocument.Left() + 5, altura - (80))
                            Case 5
                                contentByte.SetFontAndSize(F3, 12)
                                contentByte.SetTextMatrix(MyDocument.Left() + 247, altura - (343))
                            Case 6
                                contentByte.SetFontAndSize(F3, 11)
                                contentByte.SetTextMatrix(MyDocument.Left() + 185, altura - (580))
                            Case 7
                                contentByte.SetFontAndSize(F3, 9)
                                contentByte.SetTextMatrix(MyDocument.Left() + 5, altura - (597))
                            Case 8
                                '    contentByte.setFontAndSize(F3,8)   
                                '    contentByte.setTextMatrix(MyDocument.left()+05,altura-(599))
                            Case 9
                                contentByte.SetFontAndSize(F3, 8)
                                contentByte.SetTextMatrix(MyDocument.Left() + 5, altura - (614))
                            Case 10
                                contentByte.SetFontAndSize(F3, 8)
                                contentByte.SetTextMatrix(MyDocument.Left() + 400, altura - (597))
                            Case 11
                                contentByte.SetFontAndSize(F2, 8)
                                contentByte.SetTextMatrix(MyDocument.Left() + 400, altura - (615))
                            Case 12
                                contentByte.SetFontAndSize(F2, 8)
                                contentByte.SetTextMatrix(MyDocument.Left() + 5, altura - (631))
                            Case 13
                                contentByte.SetFontAndSize(F2, 8)
                                contentByte.SetTextMatrix(MyDocument.Left() + 110, altura - (631))
                            Case 14
                                contentByte.SetFontAndSize(F2, 8)
                                contentByte.SetTextMatrix(MyDocument.Left() + 195, altura - (631))
                            Case 15
                                contentByte.SetFontAndSize(F2, 8)
                                contentByte.SetTextMatrix(MyDocument.Left() + 235, altura - (631))
                            Case 16
                                contentByte.SetFontAndSize(F2, 8)
                                contentByte.SetTextMatrix(MyDocument.Left() + 310, altura - (631))
                            Case 17
                                contentByte.SetFontAndSize(F2, 8)
                                contentByte.SetTextMatrix(MyDocument.Left() + 400, altura - (631))
                            Case 18
                                contentByte.SetFontAndSize(F2, 8)
                                contentByte.SetTextMatrix(MyDocument.Left() + 105, altura - (649))
                            Case 19
                                contentByte.SetFontAndSize(F2, 8)
                                contentByte.SetTextMatrix(MyDocument.Left() + 152, altura - (649))
                            Case 20
                                contentByte.SetFontAndSize(F3, 8)
                                contentByte.SetTextMatrix(MyDocument.Left() + 400, altura - (649))
                            Case 21
                                contentByte.SetFontAndSize(F2, 8)
                                contentByte.SetTextMatrix(MyDocument.Left() + 5, altura - (659))
                            Case 22
                                contentByte.SetFontAndSize(F2, 8)
                                contentByte.SetTextMatrix(MyDocument.Left() + 5, altura - (680))
                            Case 23
                                contentByte.SetFontAndSize(F2, 8)
                                contentByte.SetTextMatrix(MyDocument.Left() + 5, altura - (690))
                            Case 25
                                contentByte.SetFontAndSize(F2, 8)
                                contentByte.SetTextMatrix(MyDocument.Left() + 5, altura - (690))
                            Case 26
                                contentByte.SetFontAndSize(F2, 8)
                                contentByte.SetTextMatrix(MyDocument.Left() + 5, altura - (694))
                            Case 28
                                contentByte.SetFontAndSize(F2, 8)
                                contentByte.SetTextMatrix(MyDocument.Left() + 5, altura - (750))
                            Case 29
                                contentByte.SetFontAndSize(F2, 8)
                                contentByte.SetTextMatrix(MyDocument.Left() + 5, altura - (758))
                            Case 30
                                contentByte.SetFontAndSize(F2, 8)
                                contentByte.SetTextMatrix(MyDocument.Left() + 5, altura - (766))
                            Case 31
                                '// Linha e Posição do Codigo de Barras no Pdf e Arquivo
                                codeBarra.Code = linha.Substring(37).Trim
                                codeBarra.Font = Nothing
                                contentByte.AddTemplate(codeBarra.CreateTemplateWithBarcode(contentByte, Nothing, Nothing), 60, 10)
                        End Select
                    ElseIf Imagem.Equals("HOEPERSV") Then
                        Select Case contLine
                            Case 1
                                '   contentByte.setFontAndSize(F2,8)   
                                '   contentByte.setTextMatrix(MyDocument.left()+100,altura-(400))
                            Case 2
                                '// Linha e Posição do Codigo Postal no Pdf e Arquivo
                                codePost.Code = linha.Substring(37).Trim
                                contentByte.AddTemplate(codePost.CreateTemplateWithBarcode(contentByte, Nothing, Nothing), 130, 410)
                            Case 3
                                contentByte.SetFontAndSize(F2, 8)
                                contentByte.SetTextMatrix(MyDocument.Left() + 90, altura - (419))
                            Case 4
                                contentByte.SetFontAndSize(F2, 8)
                                contentByte.SetTextMatrix(MyDocument.Left() + 90, altura - (428))
                            Case 5
                                contentByte.SetFontAndSize(F2, 8)
                                contentByte.SetTextMatrix(MyDocument.Left() + 90, altura - (438))
                            Case 6
                                contentByte.SetFontAndSize(F2, 8)
                                contentByte.SetTextMatrix(MyDocument.Left() + 90, altura - (447))
                            Case 7
                                contentByte.SetFontAndSize(F2, 5)
                                contentByte.SetTextMatrix(MyDocument.Left() + 418, altura - (725))
                            Case 8
                                '//Captura O codigo de Cif Fac No Arquivo
                                codCif.Code = linha.Substring(37).Trim
                                'codCif.Font = Nothing
                                contentByte.AddTemplate(codCif.CreateTemplateWithBarcode(contentByte, Nothing, Nothing), 210, 210)
                        End Select
                    End If
                    '// Adiciona as Variaveis no Pdf Texto
                    contentByte.ShowText(Mid(linha, 38, 500))
                    '// encerra o texto da página
                    contentByte.EndText()
                    Application.DoEvents()
                End If
            End While
            '//fecha os arquivos
            bufReader.Dispose()
            bufReader.Close()
            MyDocument.Dispose()
            MyDocument.Close()
            '//fecha os arquivos
        Catch ex As Exception
            MsgBox("Falha ao gerar PDF =" + Space(1) + ex.Message, MsgBoxStyle.Critical, "Falha ao gerar PDF")
        End Try
    End Sub
    ' Metodo para, Gerar Digito de Codigo Postal PostNet Apartir do Campo Cep    <p>
    ' 1 Argumentos                                                               <p>
    ' 1º do tipo String                                                          <p>
    ' Exemplo de Uso = Util.Postnet(Cep);                                        <p>
    ' * @param cep
    ' * Return cepbarra 
    Public Function Postnet(ByVal cep As String) As String

        Dim soma As Integer = 0
        Dim tclint As Integer = 0
        Dim tcrint As Integer = 0
        Dim cepnetint As Integer = 0
        Dim numero As String = cep

        numero = StrTran(numero, " -*.", Space(0))

        Dim ra As String
        Dim cepnet As String
        Dim dig As String
        Dim cepbarra As String
        Dim tcl, tcr As String


        Dim dc1 As String = numero.Substring(0, 1)
        Dim dc2 As String = numero.Substring(1, 1)
        Dim dc3 As String = numero.Substring(2, 1)
        Dim dc4 As String = numero.Substring(3, 1)
        Dim dc5 As String = numero.Substring(4, 1)
        Dim dc6 As String = numero.Substring(5, 1)
        Dim dc7 As String = numero.Substring(6, 1)
        Dim dc8 As String = numero.Substring(7, 1)

        soma = CInt(dc1) + CInt(dc2) + CInt(dc3) + CInt(dc4) + CInt(dc5) + CInt(dc6) + CInt(dc7) + CInt(dc8)

        ra = Convert.ToString(soma)
        If ra.Length() = 1 Then
            ra = "0" + ra
        End If

        tcl = ra.Substring(0, 1)
        tcr = ra.Substring(1, 1)

        If Not tcr.Equals("0") Then
            tclint = CInt(tcl) + 1
        Else
            tclint = CInt(tcl)
        End If

        tcl = Convert.ToString(tclint)
        cepnet = tcl + "0"
        cepnetint = CInt(cepnet) - soma
        dig = Convert.ToString(cepnetint)
        cepbarra = numero + dig

        If cepbarra.Length() <> 9 Then
            cepbarra = "*********"
        Else
            cepbarra = "*" + cepbarra + "*"
        End If

        Return cepbarra

    End Function
    '  Metodo para, Thread Barra De Progresso                                     <p>
    '  Void Metodo sem Retorno                                                    <p>
    '  Exemplo de Uso =  Util.StartThread()                                       <p> 
    '  Boleto.ProgressBar1.Minimum = 0                                            <p>
    '  Boleto.ProgressBar1.Maximum = Cont                                         <p>
    '  Boleto.ProgressBar1.Value = sequencia                                      <p>
    Public Sub StartThread()
        Dim _tread As Threading.Thread
        If (Boleto.ProgressBar1.Value > 0) Then Boleto.ProgressBar1.Value = 0
        _tread = New System.Threading.Thread(AddressOf Monitor)
        _tread.Start()
    End Sub
    Private Delegate Sub Monitor_Action()
    Public Sub Monitor()
        If Boleto.ProgressBar1.InvokeRequired Then
            Dim MonitorInvoke As New Monitor_Action(AddressOf Monitor)
            Boleto.ProgressBar1.Invoke(MonitorInvoke)
        End If
    End Sub

    '  Metodo para, Retorna dias Uteis Ou Seja Menos Feriados e Sabados e Domingo <p>
    ' 1 Argumentos                                                                <p>
    ' 1º do tipo Date                                                             <p>
    '  Exemplo de Uso =  Util.DiaFeriado(Data)                                    <p> 
    ' * @param Data
    ' * Return Boolean

    Public Function DiaFeriado(ByVal Data As Date) As Boolean
        Dim Dia As Integer = Data.Day
        Dim Mes As Integer = Data.Month
        Dim Ano As Integer = Data.Year

        'Festas moveis
        If Data.Date = Carnaval(Ano).Date Then Return True '"Entrudo/Carnaval"
        If Data.Date = SextaFeiraSanta(Ano).Date Then Return True ' "Sexta-Feira Santa"
        If Data.Date = Pascoa(Ano).Date Then Return True '"Páscoa"
        If Data.Date = CorposChristi(Ano).Date Then Return True '"Corpos Christi"

        'Feriados e dias Santos Fixos
        If Dia = 1 And Mes = 1 Then Return True '"Ano Novo"
        If Dia = 21 And Mes = 4 Then Return True '"Tiradentes"
        If Dia = 1 And Mes = 5 Then Return True '"Dia do Trabalhador"
        If Dia = 7 And Mes = 9 Then Return True '"Proclamação da Idependência"
        If Dia = 12 And Mes = 10 Then Return True '"Nossa Sra. Aparecida"
        If Dia = 2 And Mes = 11 Then Return True '"Finados"
        If Dia = 15 And Mes = 11 Then Return True '"Proclamção da Republica"
        If Dia = 25 And Mes = 12 Then Return True '"Natal"

        'Feriados Locais
        'If Dia = 1 And Mes = 7 Then Return "R" '"Feriado Regional(Madeira)"
        'If Dia = 21 And Mes = 8 Then Return "M" '"Feriado Municipal(Funchal)"
        'etc...

        Return False '"Dia Util"
    End Function

    'Festas Moveis
    Public Function Carnaval(ByVal Ano As Integer) As Date
        Dim D As Date = Pascoa(Ano)
        Return DateSerial(Ano, D.Month, D.Day - 47)
    End Function

    Public Function SextaFeiraSanta(ByVal Ano As Integer) As Date
        Dim D As Date = Pascoa(Ano)
        Return DateSerial(Ano, D.Month, D.Day - 2)
    End Function

    Public Function Pascoa(ByVal Ano As Integer) As Date

        Dim A As Integer = Ano Mod 19
        Dim B As Integer = Int(Ano / 100)
        Dim C As Integer = Ano Mod 100
        Dim D As Integer = Int(B / 4)
        Dim E As Integer = B Mod 4
        Dim F As Integer = Int((B + 8) / 25)
        Dim G As Integer = Int((B - F + 1) / 3)
        Dim H As Integer = (19 * A + B - D - G + 15) Mod 30
        Dim I As Integer = Int(C / 4)
        Dim J As Integer = C Mod 4
        Dim L As Integer = (32 + 2 * E + 2 * I - H - J) Mod 7
        Dim M As Integer = Int((A + 11 + H + 22 * L) / 451)

        Dim Mes As Integer = Int((H + L - 7 * M + 114) / 31)
        Dim Dia As Integer = 1 + ((H + L - 7 * M + 114) Mod 31)

        Return DateSerial(Ano, Mes, Dia)
    End Function

    Public Function CorposChristi(ByVal Ano As Integer) As Date
        Dim D As Date = Pascoa(Ano)
        Return DateSerial(Ano, D.Month, D.Day + 60)
    End Function

End Class
