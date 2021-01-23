Public Class Fac

    Private Util As New Utilidades()


    Public Sub Fac()

        Dim Modelo As String() = {"Hoepers_01", "Hoepers_02", "Hoepers_03", "Hoepers_04", "Hoepers_05"}
        Dim Gerar As String() = {"Teste", "Produção"}
        Dim Contrato As String() = {"Hoepers", "Lopes", "DmCard", "Ici", "Marpress", "FacBB"}
        Dim Peso As String() = {"2,40", "4,80", "5,80", "9,30", "11,80"}
        Dim Semana As String = ""
        Dim Data As Date

        '*************** Começo Calcula Data Uteis
        Data = Now.Date.AddDays(3)
        Semana = WeekdayName(Weekday(Data)).ToString.Trim

        If (Util.DiaFeriado(Data)) Then
            Data = Data.AddDays(1)
        End If

        If (Semana.Equals("sábado")) Then
            Data = Data.AddDays(2)
        ElseIf (Semana.Equals("domingo")) Then
            Data = Data.AddDays(1)
        End If
        '*************** Final Calcula Data Uteis

        Boleto.ComboBox1.DataSource = Modelo
        Boleto.ComboBox2.DataSource = Gerar
        Boleto.ComboBox3.DataSource = Contrato
        Boleto.ComboBox4.DataSource = Peso
        Boleto.GroupBox1.Visible = True
        Boleto.MaskedDataPostagem.Text = Data

    End Sub

    Public Function Modalidade() As Boolean
        Dim Verifica As String = False
        Dim Semana As String = ""
        Dim Data As Date
        Data = Boleto.MaskedDataPostagem.Text
        Semana = WeekdayName(Weekday(Data)).ToString.Trim

        If Boleto.ComboBox2.SelectedItem.Equals("Produção") Then
            Dim result As Integer = MessageBox.Show("Verifique se Os Itens Abaixo Estão Corretos:" + vbCrLf + _
                                                    "--------------------------------------------" + vbCrLf + _
                                                    "" + Space(7) + "1° Item Modelo     " + Space(0) + " = " + Space(3) + Boleto.ComboBox1.SelectedItem + vbCrLf + _
                                                    "" + Space(7) + "2° Item Gerar      " + Space(3) + " = " + Space(3) + Boleto.ComboBox2.SelectedItem + vbCrLf + _
                                                    "" + Space(7) + "3° Item Contrato   " + Space(0) + " = " + Space(3) + Boleto.ComboBox3.SelectedItem + vbCrLf + _
                                                    "" + Space(7) + "4° Item Peso       " + Space(3) + " = " + Space(3) + Boleto.ComboBox4.SelectedItem + vbCrLf + _
                                                    "" + Space(7) + "5° Item Data       " + Space(3) + " = " + Space(3) + Boleto.MaskedDataPostagem.Text + vbCrLf + _
                                                    "--------------------------------------------", vbCrLf + _
                                                    "Confirmação Das Configurações Para Produção", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            If result = DialogResult.Cancel Then
                MessageBox.Show("Você Pedio Para Sair do Sistema!!!")
                Boleto.Saida.FindForm().Close()
            ElseIf result = DialogResult.No Then
                MessageBox.Show("Corrija As Configurações!!!")
                Verifica = True
            ElseIf (Util.DiaFeriado(Boleto.MaskedDataPostagem.Text) Or + _
                     Semana.Equals("sábado") Or + _
                     Semana.Equals("domingo") Or Date.Now >= Data) Then
                MessageBox.Show("Data Invalida, Data Menor que o dia, Feriado, Sabado Ou Domingo Por Favor Corrigir!! ", "A Data Digitada Não é Uma Data Util", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Verifica = True
                Boleto.ComboBox1.Enabled = True
                Boleto.ComboBox2.Enabled = True
                Boleto.ComboBox3.Enabled = True
                Boleto.ComboBox4.Enabled = True
                Boleto.MaskedDataPostagem.Enabled = True
            ElseIf result = DialogResult.Yes Then
                MessageBox.Show("Configurações Confirmadas!!!")
                Boleto.ComboBox1.Enabled = False
                Boleto.ComboBox2.Enabled = False
                Boleto.ComboBox3.Enabled = False
                Boleto.ComboBox4.Enabled = False
                Boleto.MaskedDataPostagem.Enabled = False
            End If

            End If

        Return Verifica

    End Function


    Public Sub Processa()

        Dim ArqErr As String = Mid(Boleto.TextBox1.Text, 1, Len(Boleto.TextBox1.Text) - 4) + ".Err"
        Dim DataPostagem As String = Boleto.MaskedDataPostagem.Text
        Dim Caminho_Origem As String = Util.StrTran(Application.StartupPath, "\", "/")
        Dim Caminho_Destino As String = "C:/Amarildo/Boleto_VB.Net/Boleto/bin/Debug/" & Mid(Util.StrTran(DataPostagem, "/", ""), 1, 4) & _
                                                        Mid(Util.StrTran(DataPostagem, "/", ""), 7, 2) & _
                                                    "/" & Boleto.ComboBox3.SelectedItem & _
                                                    "/" & Boleto.ComboBox3.SelectedItem & _
                                                    "_" & Mid(Util.StrTran(Boleto.ComboBox4.SelectedItem, ".,", ""), 1, 2)

        Dim CepB As String
        Dim NumLote As Integer = 0
        Dim Sequencia As Integer = 0
        Dim XTotal As Integer = 0
        Dim NumPostal As String = " "
        Dim Categoria As String = "     "
        Dim CodCep As String = " "
        Dim CodTri As String = " "
        Dim CodCif As String = " "
        Dim Eof As New ADODB.Recordset
        Dim Conecta As New Banco()

        If Boleto.ComboBox2.SelectedItem.Equals("Produção") Then

            '//*********************************  Começo Seleciona Banco de Dados Contrato Fac ************************************   
            Eof = Conecta.getDataRS("SELECT * FROM" & Space(1) & Boleto.ComboBox3.SelectedItem, "0") '// Seleciona o Banco de Dados Por Ordem de Cep
            ' //********************************* Final Seleciona Banco de Dados Contrato Fac   ************************************   

            NumLote = Eof.Fields("Num_Lote").Value + 1

            Conecta.setData("Update " & Space(1) & Boleto.ComboBox3.SelectedItem & Space(1) & "set Num_Lote = " & "'" & NumLote.ToString & "'")

            Dim Codigo_Dr As String = Eof.Fields("Codigo_dr").Value
            Dim Cod_Admin As String = Eof.Fields("Cod_Admin").Value
            Dim Num_Cartao As String = Eof.Fields("Num_Cartao").Value
            Dim Cod_Postag As String = Eof.Fields("Cod_Postag").Value
            Dim Cep_Origem As String = Eof.Fields("Cep_Origem").Value
            Dim N_Contrato As String = Eof.Fields("N_Contrato").Value


            Dim Midia As String = Cod_Admin & _
                                  "_" & Util.Padl(NumLote, 5, "0") & _
                                  "_" & "UNICA" + _
                                  "_" & Codigo_Dr + _
                                  ".Txt"

            Util.Write(Midia, "1" & _
                              Codigo_Dr & _
                              Cod_Admin & _
                              Num_Cartao & _
                              Util.Padl(NumLote.ToString.Trim, 5, "0") & _
                              Cod_Postag & _
                              Cep_Origem & _
                              N_Contrato)


            '//*********************************  Começo Seleciona Banco de Dados Dos Registro Fac ************************************   
            Eof = Conecta.getDataRS("SELECT * FROM Tipo01 ORDER BY Cep ASC", "0") '// Seleciona o Banco de Dados Por Ordem de Cep
            '//*********************************  Final Seleciona Banco de Dados Dos Registro Fac ************************************   

            '//*********************************  Começo While para limpar os ceps e repassar categorias
            Eof.MoveFirst()
            While Not Eof.EOF

                CepB = Util.StrTran(Eof.Fields("Cep").Value, "- .", "")

                If Val(CepB) >= 1001000 And Val(CepB) < 2000000 Or + _
                   Val(CepB) >= 3001000 And Val(CepB) < 7000000 Or + _
                   Val(CepB) >= 9001000 And Val(CepB) < 10000000 Then
                    Categoria = "82015"
                    CodCep = "1"
                    CodTri = "1"
                ElseIf Val(CepB) >= 2001000 And Val(CepB) < 3000000 Or + _
                       Val(CepB) >= 7001000 And Val(CepB) < 9000000 Then
                    Categoria = "82015"
                    CodCep = "1"
                    CodTri = "2"
                ElseIf Val(CepB) >= 11000000 And Val(CepB) < 14000000 Then
                    Categoria = "82023"
                    CodCep = "2"
                    CodTri = "3"
                ElseIf Val(CepB) >= 14000000 And Val(CepB) < 20000000 Then
                    Categoria = "82023"
                    CodCep = "2"
                    CodTri = "4"
                ElseIf Val(CepB) >= 20000000 And Val(CepB) < 60000000 Then
                    Categoria = "82031"
                    CodCep = "3"
                    CodTri = "5"
                ElseIf Val(CepB) >= 60000000 And Val(CepB) < 100000000 Then
                    Categoria = "82031"
                    CodCep = "3"
                    CodTri = "6"
                ElseIf Val(CepB) = 0 Or + _
                       Val(CepB) = 11111111 Or + _
                       Val(CepB) = 22222222 Or + _
                       Val(CepB) = 33333333 Or + _
                       Val(CepB) = 44444444 Or + _
                       Val(CepB) = 55555555 Or + _
                       Val(CepB) = 66666666 Or + _
                       Val(CepB) = 77777777 Or + _
                       Val(CepB) = 88888888 Or + _
                       Val(CepB) = 99999999 Then
                    CodTri = " "
                End If

                CodTri = ValidaCep(CepB, Eof.Fields("Estado").Value, CodTri).Trim

                If CodTri.Equals(" ") Then
                    Util.Write(ArqErr, Eof.Fields("Cpf").Value & _
                                 ";" + Eof.Fields("Nome").Value & _
                                 ";" + Eof.Fields("Endereco").Value & _
                                 ";" + Eof.Fields("Cidade").Value & _
                                 ";" + Eof.Fields("Estado").Value & _
                                 ";" + Eof.Fields("Cep").Value)
                    Eof.Delete()
                Else
                    Sequencia = Sequencia + 1

                    NumPostal = Util.Padl(Util.StrTran(DataPostagem, "/", "") & Util.Padl(Sequencia.ToString.Trim, 11, "0"), 20, "0")

                    CodCif = Codigo_Dr & _
                             Cod_Admin & _
                             Util.Padl(NumLote, 5, "0") & _
                             Util.Padl(Sequencia.ToString.Trim, 11, "0") & _
                             CodCep & _
                             "0" + Mid(Util.StrTran(DataPostagem, "/", ""), 1, 4) & _
                                   Mid(Util.StrTran(DataPostagem, "/", ""), 7, 2)

                    Conecta.setData("Update Tipo01 set CodTRi    = " & "'" & CodTri & "'," & _
                                                     " CodCep    = " & "'" & CodCep & "'," & _
                                                     " CodCif    = " & "'" & CodCif & "'," & _
                                                     " NumPostal = " & "'" & NumPostal & "'," & _
                                                     " Categoria = " & "'" & Categoria & "'" & _
                                          Space(1) & " Where Id  = " & "'" & Eof.Fields("Id").Value & "'")

                    Util.Write(Midia, "2" & _
                          Util.Padl(Sequencia.ToString.Trim, 11, "0") & _
                          Util.Padl(Util.StrTran(Boleto.ComboBox4.SelectedItem, ".,", ""), 6, "0") & _
                          CepB & _
                          Categoria)

                End If

                '//********************************* Começo Move Ponteiro no Banco
                Eof.MoveNext()
                '//********************************* Final  Move Ponteiro no Banco

            End While

            XTotal = Sequencia * Util.StrTran(Boleto.ComboBox4.SelectedItem, ".,", "")

            Util.Write(Midia, "4" & _
            Util.Padl(Sequencia.ToString.Trim, 7, "0") & _
            Util.Padl(XTotal.ToString.Trim, 10, "0"))

            Util.Diretorio(Caminho_Origem, Caminho_Destino, Midia)

        End If

    End Sub


    Public Function ValidaCep(ByVal XCep As String, ByVal XEstado As String, ByVal XCodTri As String) As String

        Dim CodTri As String = XCodTri

        '************************ ACRE
        If Val(XCep) >= 69900000 And + _
           Val(XCep) <= 69999999 And + _
           Not XEstado.ToUpper().Equals("AC") Then
            CodTri = " "
            '************************ ALAGOAS
        ElseIf Val(XCep) >= 57000000 And + _
               Val(XCep) <= 57999999 And + _
               Not XEstado.ToUpper().Equals("AL") Then
            CodTri = " "
            '************************ AMAZONAS
        ElseIf Val(XCep) >= 69000000 And + _
               Val(XCep) <= 69299999 Or + _
               Val(XCep) >= 69400000 And + _
               Val(XCep) <= 69899999 And + _
               Not XEstado.ToUpper().Equals("AM") Then
            CodTri = " "
            '*********************** AMAPA
        ElseIf Val(XCep) >= 68900000 And + _
               Val(XCep) <= 68999999 And + _
               Not XEstado.ToUpper().Equals("AP") Then
            CodTri = " "
            '************************ BAHIA
        ElseIf Val(XCep) >= 40000000 And + _
               Val(XCep) <= 48999999 And + _
               Not XEstado.ToUpper().Equals("BA") Then
            CodTri = " "
            '************************ CEARA
        ElseIf Val(XCep) >= 60000000 And + _
               Val(XCep) <= 63999999 And + _
               Not XEstado.ToUpper().Equals("CE") Then
            CodTri = " "
            '************************ DISTRITO FEDERAL
        ElseIf Val(XCep) >= 70000000 And + _
               Val(XCep) <= 72799999 Or + _
               Val(XCep) >= 73000000 And + _
               Val(XCep) <= 73699999 And + _
               Not XEstado.ToUpper().Equals("DF") Then
            CodTri = " "
            '************************ ESPIRITO SANTO
        ElseIf Val(XCep) >= 29000000 And + _
               Val(XCep) <= 29999999 And + _
               Not XEstado.ToUpper().Equals("ES") Then
            CodTri = " "
            '************************ GOIAS
        ElseIf Val(XCep) >= 72800000 And + _
               Val(XCep) <= 72999999 Or + _
               Val(XCep) >= 73700000 And + _
               Val(XCep) <= 76799999 And + _
               Not XEstado.ToUpper().Equals("GO") Then
            CodTri = " "
            '************************ MARANHAO
        ElseIf Val(XCep) >= 65000000 And + _
               Val(XCep) <= 65999999 And + _
               Not XEstado.ToUpper().Equals("MA") Then
            CodTri = " "
            '************************ MINAS GERAIS
        ElseIf Val(XCep) >= 30000000 And + _
               Val(XCep) <= 39999999 And + _
               Not XEstado.ToUpper().Equals("MG") Then
            CodTri = " "
            '************************ MATO GROSSO DO SUL
        ElseIf Val(XCep) >= 79000000 And + _
               Val(XCep) <= 79999999 And + _
               Not XEstado.ToUpper().Equals("MS") Then
            CodTri = " "
            '************************ MATO GROSSO
        ElseIf Val(XCep) >= 78000000 And + _
               Val(XCep) <= 78899999 And + _
               Not XEstado.ToUpper().Equals("MT") Then
            CodTri = " "
            '************************ PARA
        ElseIf Val(XCep) >= 66000000 And + _
               Val(XCep) <= 68899999 And + _
               Not XEstado.ToUpper().Equals("PA") Then
            CodTri = " "
            '************************ PARAIBA
        ElseIf Val(XCep) >= 58000000 And + _
               Val(XCep) <= 58999999 And + _
               Not XEstado.ToUpper().Equals("PB") Then
            CodTri = " "
            '************************ PERNAMBUCO
        ElseIf Val(XCep) >= 50000000 And + _
               Val(XCep) <= 56999999 And + _
               Not XEstado.ToUpper().Equals("PE") Then
            CodTri = " "
            '************************ PIAUI
        ElseIf Val(XCep) >= 64000000 And + _
               Val(XCep) <= 64999999 And + _
               Not XEstado.ToUpper().Equals("PI") Then
            CodTri = " "
            '************************ PARANA
        ElseIf Val(XCep) >= 80000000 And + _
               Val(XCep) <= 87999999 And + _
               Not XEstado.ToUpper().Equals("PR") Then
            CodTri = " "
            '************************ RIO DE JANEIRO
        ElseIf Val(XCep) >= 20000000 And + _
               Val(XCep) <= 28999999 And + _
               Not XEstado.ToUpper().Equals("RJ") Then
            CodTri = " "
            '************************ RIO GRANDE DO NORTE
        ElseIf Val(XCep) >= 59000000 And + _
               Val(XCep) <= 59999999 And + _
               Not XEstado.ToUpper().Equals("RN") Then
            CodTri = " "
            '************************ RONDONIA
        ElseIf Val(XCep) >= 78900000 And + _
               Val(XCep) <= 78999999 And + _
               Not XEstado.ToUpper().Equals("RO") Then
            CodTri = " "
            '************************ RORAIMA
        ElseIf Val(XCep) >= 69300000 And + _
               Val(XCep) <= 69399999 And + _
               Not XEstado.ToUpper().Equals("RR") Then
            CodTri = " "
            '************************ RIO GRANDE DO SUL
        ElseIf Val(XCep) >= 90000000 And + _
               Val(XCep) <= 99999999 And + _
               Not XEstado.ToUpper().Equals("RS") Then
            CodTri = " "
            '************************ SANTA CATARINA
        ElseIf Val(XCep) >= 88000000 And + _
               Val(XCep) <= 88999999 And + _
               Not XEstado.ToUpper().Equals("SC") Then
            CodTri = " "
            '************************ SERGIPE
        ElseIf Val(XCep) >= 49000000 And + _
               Val(XCep) <= 49999999 And + _
               Not XEstado.ToUpper().Equals("SE") Then
            CodTri = " "
            '************************ SAO PAULO
        ElseIf Val(XCep) >= 1000000 And + _
               Val(XCep) <= 19999999 And + _
               Not XEstado.ToUpper().Equals("SP") Then
            CodTri = " "
            '************************ TOCANTINS
        ElseIf Val(XCep) >= 77000000 And + _
               Val(XCep) <= 77999999 And + _
               Not XEstado.ToUpper().Equals("TO") Then
            CodTri = " "
        End If

        Return CodTri

    End Function


End Class
