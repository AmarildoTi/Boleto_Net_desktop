<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Boleto
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Contador = New System.Windows.Forms.Label
        Me.Local = New System.Windows.Forms.Label
        Me.Estadual = New System.Windows.Forms.Label
        Me.Nacional = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Buscar = New System.Windows.Forms.Button
        Me.Saida = New System.Windows.Forms.Button
        Me.DataPostagem = New System.Windows.Forms.Label
        Me.MaskedDataPostagem = New System.Windows.Forms.MaskedTextBox
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ComboBox4 = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.ComboBox3 = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Location = New System.Drawing.Point(191, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fac"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(46, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(367, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Boleto Hoepers Layout Multipla Bradesco"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label3.Location = New System.Drawing.Point(14, 201)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(168, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Aquivo de Entrada..:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label4.Location = New System.Drawing.Point(14, 242)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(169, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Aquivo de Saida......:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label5.Location = New System.Drawing.Point(80, 441)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 17)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Aguarde....:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label5.Visible = False
        '
        'Contador
        '
        Me.Contador.AutoSize = True
        Me.Contador.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Contador.Location = New System.Drawing.Point(80, 282)
        Me.Contador.Name = "Contador"
        Me.Contador.Size = New System.Drawing.Size(102, 17)
        Me.Contador.TabIndex = 10
        Me.Contador.Text = "Contador...:"
        '
        'Local
        '
        Me.Local.AutoSize = True
        Me.Local.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Local.Location = New System.Drawing.Point(46, 324)
        Me.Local.Name = "Local"
        Me.Local.Size = New System.Drawing.Size(94, 17)
        Me.Local.TabIndex = 11
        Me.Local.Text = "Local........:"
        '
        'Estadual
        '
        Me.Estadual.AutoSize = True
        Me.Estadual.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Estadual.Location = New System.Drawing.Point(45, 365)
        Me.Estadual.Name = "Estadual"
        Me.Estadual.Size = New System.Drawing.Size(95, 17)
        Me.Estadual.TabIndex = 12
        Me.Estadual.Text = "Estadual...:"
        '
        'Nacional
        '
        Me.Nacional.AutoSize = True
        Me.Nacional.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Nacional.Location = New System.Drawing.Point(45, 400)
        Me.Nacional.Name = "Nacional"
        Me.Nacional.Size = New System.Drawing.Size(94, 17)
        Me.Nacional.TabIndex = 13
        Me.Nacional.Text = "Nacional...:"
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(181, 198)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(181, 24)
        Me.TextBox1.TabIndex = 4
        '
        'Buscar
        '
        Me.Buscar.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Buscar.Location = New System.Drawing.Point(368, 196)
        Me.Buscar.Name = "Buscar"
        Me.Buscar.Size = New System.Drawing.Size(75, 26)
        Me.Buscar.TabIndex = 5
        Me.Buscar.Text = "Buscar"
        Me.Buscar.UseVisualStyleBackColor = True
        '
        'Saida
        '
        Me.Saida.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Saida.Location = New System.Drawing.Point(179, 496)
        Me.Saida.Name = "Saida"
        Me.Saida.Size = New System.Drawing.Size(75, 28)
        Me.Saida.TabIndex = 7
        Me.Saida.Text = "Saida"
        Me.Saida.UseVisualStyleBackColor = True
        '
        'DataPostagem
        '
        Me.DataPostagem.AutoSize = True
        Me.DataPostagem.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataPostagem.ForeColor = System.Drawing.Color.Red
        Me.DataPostagem.Location = New System.Drawing.Point(300, 55)
        Me.DataPostagem.Name = "DataPostagem"
        Me.DataPostagem.Size = New System.Drawing.Size(125, 13)
        Me.DataPostagem.TabIndex = 8
        Me.DataPostagem.Text = "Data de Postagem"
        '
        'MaskedDataPostagem
        '
        Me.MaskedDataPostagem.Location = New System.Drawing.Point(303, 68)
        Me.MaskedDataPostagem.Mask = "00/00/0000"
        Me.MaskedDataPostagem.Name = "MaskedDataPostagem"
        Me.MaskedDataPostagem.Size = New System.Drawing.Size(120, 22)
        Me.MaskedDataPostagem.TabIndex = 9
        Me.MaskedDataPostagem.ValidatingType = GetType(Date)
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(17, 472)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(426, 18)
        Me.ProgressBar1.TabIndex = 14
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ComboBox4)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.ComboBox3)
        Me.GroupBox1.Controls.Add(Me.DataPostagem)
        Me.GroupBox1.Controls.Add(Me.MaskedDataPostagem)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.ComboBox2)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.GroupBox1.Location = New System.Drawing.Point(14, 80)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(431, 97)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Configurações"
        '
        'ComboBox4
        '
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Location = New System.Drawing.Point(209, 68)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(88, 22)
        Me.ComboBox4.TabIndex = 21
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(2, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 13)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Modelo"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(207, 55)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Peso"
        '
        'ComboBox3
        '
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(109, 68)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(94, 22)
        Me.ComboBox3.TabIndex = 19
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(107, 55)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Contrato"
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(6, 68)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(96, 22)
        Me.ComboBox2.TabIndex = 17
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(2, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Gerar"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(5, 32)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(418, 22)
        Me.ComboBox1.TabIndex = 0
        '
        'Boleto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(460, 529)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Saida)
        Me.Controls.Add(Me.Buscar)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Nacional)
        Me.Controls.Add(Me.Estadual)
        Me.Controls.Add(Me.Local)
        Me.Controls.Add(Me.Contador)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.Name = "Boleto"
        Me.Text = "Boleto"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DataPostagem As System.Windows.Forms.Label
    Friend WithEvents Contador As System.Windows.Forms.Label
    Friend WithEvents Local As System.Windows.Forms.Label
    Friend WithEvents Estadual As System.Windows.Forms.Label
    Friend WithEvents Nacional As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Buscar As System.Windows.Forms.Button
    Friend WithEvents Saida As System.Windows.Forms.Button
    Friend WithEvents MaskedDataPostagem As System.Windows.Forms.MaskedTextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
