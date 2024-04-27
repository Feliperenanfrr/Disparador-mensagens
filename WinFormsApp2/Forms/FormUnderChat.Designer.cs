namespace WinFormsApp2
{
    partial class FormUnderChat
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUnderChat));
            txtMensagem = new TextBox();
            txtFone = new TextBox();
            groupBox1 = new GroupBox();
            txtChave = new TextBox();
            txtLink = new TextBox();
            label9 = new Label();
            label8 = new Label();
            btnAtivar = new Button();
            txtPorta = new TextBox();
            txtSenha = new TextBox();
            txtUsuario = new TextBox();
            txtServer = new TextBox();
            btnSair = new Button();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tmMonitora = new System.Windows.Forms.Timer(components);
            label6 = new Label();
            label7 = new Label();
            txtEmpresa = new TextBox();
            txtErros = new TextBox();
            label10 = new Label();
            txtImagem = new TextBox();
            button2 = new Button();
            labelEmail = new Label();
            textEmail = new TextBox();
            textSenha = new TextBox();
            labelSenha = new Label();
            buttonEnviarMensagem = new Button();
            textIdLoja = new TextBox();
            labelIdLoja = new Label();
            labelIdSetor = new Label();
            labelIdCanal = new Label();
            textIdSetor = new TextBox();
            textIdCanal = new TextBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            labelContatoNome = new Label();
            labelContatoSobrenome = new Label();
            labelContatoNumero = new Label();
            label11 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // txtMensagem
            // 
            txtMensagem.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtMensagem.Location = new Point(80, 34);
            txtMensagem.Name = "txtMensagem";
            txtMensagem.Size = new Size(161, 27);
            txtMensagem.TabIndex = 1;
            txtMensagem.Text = "Olá usuário, isso é um teste!";
            // 
            // txtFone
            // 
            txtFone.Location = new Point(325, 71);
            txtFone.Name = "txtFone";
            txtFone.Size = new Size(161, 27);
            txtFone.TabIndex = 2;
            txtFone.Text = "5583999982407";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtChave);
            groupBox1.Controls.Add(txtLink);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(btnAtivar);
            groupBox1.Controls.Add(txtPorta);
            groupBox1.Controls.Add(txtSenha);
            groupBox1.Controls.Add(txtUsuario);
            groupBox1.Controls.Add(txtServer);
            groupBox1.Controls.Add(btnSair);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(15, 405);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(633, 274);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Monitorador";
            // 
            // txtChave
            // 
            txtChave.Enabled = false;
            txtChave.ForeColor = Color.Maroon;
            txtChave.Location = new Point(97, 222);
            txtChave.Name = "txtChave";
            txtChave.Size = new Size(516, 27);
            txtChave.TabIndex = 13;
            // 
            // txtLink
            // 
            txtLink.Enabled = false;
            txtLink.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txtLink.ForeColor = Color.Maroon;
            txtLink.Location = new Point(99, 185);
            txtLink.Name = "txtLink";
            txtLink.Size = new Size(514, 27);
            txtLink.TabIndex = 11;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(24, 229);
            label9.Name = "label9";
            label9.Size = new Size(55, 20);
            label9.TabIndex = 12;
            label9.Text = "Chave:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(36, 192);
            label8.Name = "label8";
            label8.Size = new Size(43, 20);
            label8.TabIndex = 11;
            label8.Text = "Link:";
            // 
            // btnAtivar
            // 
            btnAtivar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAtivar.Location = new Point(295, 30);
            btnAtivar.Name = "btnAtivar";
            btnAtivar.Size = new Size(318, 84);
            btnAtivar.TabIndex = 10;
            btnAtivar.Text = "Obter token";
            btnAtivar.UseVisualStyleBackColor = true;
            btnAtivar.Click += btnAtivar_Click;
            // 
            // txtPorta
            // 
            txtPorta.Enabled = false;
            txtPorta.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txtPorta.Location = new Point(97, 146);
            txtPorta.Name = "txtPorta";
            txtPorta.Size = new Size(182, 27);
            txtPorta.TabIndex = 6;
            txtPorta.Text = "3306";
            // 
            // txtSenha
            // 
            txtSenha.Enabled = false;
            txtSenha.Location = new Point(97, 104);
            txtSenha.Name = "txtSenha";
            txtSenha.PasswordChar = '*';
            txtSenha.Size = new Size(182, 27);
            txtSenha.TabIndex = 9;
            txtSenha.Text = "gpd1664";
            // 
            // txtUsuario
            // 
            txtUsuario.Enabled = false;
            txtUsuario.Location = new Point(97, 68);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(182, 27);
            txtUsuario.TabIndex = 8;
            txtUsuario.Text = "gueppardo";
            // 
            // txtServer
            // 
            txtServer.Enabled = false;
            txtServer.Location = new Point(97, 30);
            txtServer.Name = "txtServer";
            txtServer.Size = new Size(182, 27);
            txtServer.TabIndex = 7;
            txtServer.Text = "mysql.gueppardo.net";
            // 
            // btnSair
            // 
            btnSair.Location = new Point(295, 121);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(318, 52);
            btnSair.TabIndex = 5;
            btnSair.Text = "Sair";
            btnSair.UseVisualStyleBackColor = true;
            btnSair.Click += btnSair_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(36, 153);
            label5.Name = "label5";
            label5.Size = new Size(51, 20);
            label5.TabIndex = 6;
            label5.Text = "Porta:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 111);
            label4.Name = "label4";
            label4.Size = new Size(55, 20);
            label4.TabIndex = 2;
            label4.Text = "Senha:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 71);
            label3.Name = "label3";
            label3.Size = new Size(67, 20);
            label3.TabIndex = 1;
            label3.Text = "Usuário:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 37);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 0;
            label2.Text = "Servidor:";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(274, 78);
            label1.Name = "label1";
            label1.Size = new Size(44, 20);
            label1.TabIndex = 4;
            label1.Text = "Fone:";
            // 
            // tmMonitora
            // 
            tmMonitora.Interval = 1000;
            tmMonitora.Tick += tmMonitora_Tick;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(29, 37);
            label6.Name = "label6";
            label6.Size = new Size(48, 20);
            label6.TabIndex = 8;
            label6.Text = "Texto:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 78);
            label7.Name = "label7";
            label7.Size = new Size(69, 20);
            label7.TabIndex = 9;
            label7.Text = "Empresa:";
            // 
            // txtEmpresa
            // 
            txtEmpresa.Location = new Point(81, 72);
            txtEmpresa.Name = "txtEmpresa";
            txtEmpresa.Size = new Size(160, 27);
            txtEmpresa.TabIndex = 10;
            txtEmpresa.Text = "Gueppardo";
            // 
            // txtErros
            // 
            txtErros.Location = new Point(940, 38);
            txtErros.Multiline = true;
            txtErros.Name = "txtErros";
            txtErros.Size = new Size(314, 642);
            txtErros.TabIndex = 12;
            txtErros.Text = "Area de Mensagens";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(258, 37);
            label10.Name = "label10";
            label10.Size = new Size(67, 20);
            label10.TabIndex = 14;
            label10.Text = "Imagem:";
            // 
            // txtImagem
            // 
            txtImagem.Location = new Point(328, 34);
            txtImagem.Name = "txtImagem";
            txtImagem.Size = new Size(320, 27);
            txtImagem.TabIndex = 15;
            txtImagem.Text = "https://www.gueppardo.net/imagens/gpd.jpg";
            // 
            // button2
            // 
            button2.Location = new Point(43, 124);
            button2.Name = "button2";
            button2.Size = new Size(198, 36);
            button2.TabIndex = 17;
            button2.Text = "WhatsApp";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(6, 197);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(123, 20);
            labelEmail.TabIndex = 18;
            labelEmail.Text = "Email UnderChat:";
            // 
            // textEmail
            // 
            textEmail.Location = new Point(135, 190);
            textEmail.Name = "textEmail";
            textEmail.Size = new Size(333, 27);
            textEmail.TabIndex = 19;
            textEmail.Text = "felipeferreira3146@gmail.com";
            // 
            // textSenha
            // 
            textSenha.Location = new Point(134, 233);
            textSenha.Name = "textSenha";
            textSenha.Size = new Size(125, 27);
            textSenha.TabIndex = 20;
            textSenha.Text = "1664";
            // 
            // labelSenha
            // 
            labelSenha.AutoSize = true;
            labelSenha.Location = new Point(6, 240);
            labelSenha.Name = "labelSenha";
            labelSenha.Size = new Size(123, 20);
            labelSenha.TabIndex = 22;
            labelSenha.Text = "Senha UnderChat";
            // 
            // buttonEnviarMensagem
            // 
            buttonEnviarMensagem.Location = new Point(380, 342);
            buttonEnviarMensagem.Name = "buttonEnviarMensagem";
            buttonEnviarMensagem.Size = new Size(130, 45);
            buttonEnviarMensagem.TabIndex = 23;
            buttonEnviarMensagem.Text = "Enviar";
            buttonEnviarMensagem.UseVisualStyleBackColor = true;
            buttonEnviarMensagem.Click += buttonEnviarMensagem_Click;
            // 
            // textIdLoja
            // 
            textIdLoja.Location = new Point(135, 277);
            textIdLoja.Name = "textIdLoja";
            textIdLoja.Size = new Size(125, 27);
            textIdLoja.TabIndex = 24;
            textIdLoja.Text = "832";
            // 
            // labelIdLoja
            // 
            labelIdLoja.AutoSize = true;
            labelIdLoja.Location = new Point(51, 277);
            labelIdLoja.Name = "labelIdLoja";
            labelIdLoja.Size = new Size(78, 20);
            labelIdLoja.TabIndex = 25;
            labelIdLoja.Text = "Id da Loja:";
            // 
            // labelIdSetor
            // 
            labelIdSetor.AutoSize = true;
            labelIdSetor.Location = new Point(47, 323);
            labelIdSetor.Name = "labelIdSetor";
            labelIdSetor.Size = new Size(86, 20);
            labelIdSetor.TabIndex = 26;
            labelIdSetor.Text = "Id do Setor:";
            // 
            // labelIdCanal
            // 
            labelIdCanal.AutoSize = true;
            labelIdCanal.Location = new Point(43, 360);
            labelIdCanal.Name = "labelIdCanal";
            labelIdCanal.Size = new Size(86, 20);
            labelIdCanal.TabIndex = 27;
            labelIdCanal.Text = "Id do canal:";
            // 
            // textIdSetor
            // 
            textIdSetor.Location = new Point(135, 316);
            textIdSetor.Name = "textIdSetor";
            textIdSetor.Size = new Size(125, 27);
            textIdSetor.TabIndex = 28;
            textIdSetor.Text = "4389";
            // 
            // textIdCanal
            // 
            textIdCanal.Location = new Point(134, 360);
            textIdCanal.Name = "textIdCanal";
            textIdCanal.Size = new Size(125, 27);
            textIdCanal.TabIndex = 29;
            textIdCanal.Text = "1215";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(705, 237);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 30;
            textBox1.Text = "Felipe";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(705, 270);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 31;
            textBox2.Text = "Renan";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(705, 303);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 32;
            textBox3.Text = "81415600";
            // 
            // labelContatoNome
            // 
            labelContatoNome.AutoSize = true;
            labelContatoNome.Location = new Point(640, 240);
            labelContatoNome.Name = "labelContatoNome";
            labelContatoNome.Size = new Size(53, 20);
            labelContatoNome.TabIndex = 33;
            labelContatoNome.Text = "Nome:";
            // 
            // labelContatoSobrenome
            // 
            labelContatoSobrenome.AutoSize = true;
            labelContatoSobrenome.Location = new Point(604, 273);
            labelContatoSobrenome.Name = "labelContatoSobrenome";
            labelContatoSobrenome.Size = new Size(89, 20);
            labelContatoSobrenome.TabIndex = 34;
            labelContatoSobrenome.Text = "Sobrenome:";
            // 
            // labelContatoNumero
            // 
            labelContatoNumero.AutoSize = true;
            labelContatoNumero.Location = new Point(627, 306);
            labelContatoNumero.Name = "labelContatoNumero";
            labelContatoNumero.Size = new Size(66, 20);
            labelContatoNumero.TabIndex = 35;
            labelContatoNumero.Text = "Numero:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(561, 207);
            label11.Name = "label11";
            label11.Size = new Size(132, 20);
            label11.TabIndex = 36;
            label11.Text = "Dados do contato:";
            // 
            // FormUnderChat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1266, 694);
            Controls.Add(label11);
            Controls.Add(labelContatoNumero);
            Controls.Add(labelContatoSobrenome);
            Controls.Add(labelContatoNome);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(textIdCanal);
            Controls.Add(textIdSetor);
            Controls.Add(labelIdCanal);
            Controls.Add(labelIdSetor);
            Controls.Add(labelIdLoja);
            Controls.Add(textIdLoja);
            Controls.Add(buttonEnviarMensagem);
            Controls.Add(labelSenha);
            Controls.Add(textSenha);
            Controls.Add(textEmail);
            Controls.Add(labelEmail);
            Controls.Add(button2);
            Controls.Add(txtImagem);
            Controls.Add(label10);
            Controls.Add(txtErros);
            Controls.Add(txtEmpresa);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Controls.Add(txtFone);
            Controls.Add(txtMensagem);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormUnderChat";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Monitorador UnderChat - CNPJ:";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtMensagem;
        private TextBox txtFone;
        private GroupBox groupBox1;
        private Label label1;
        private Button btnSair;
        private Label label2;
        private Label label5;
        private Label label4;
        private Label label3;
        private System.Windows.Forms.Timer tmMonitora;
        private TextBox txtSenha;
        private TextBox txtUsuario;
        private TextBox txtServer;
        private TextBox txtPorta;
        private Button btnAtivar;
        private Label label6;
        private Label label7;
        private TextBox txtEmpresa;
        private Label label8;
        private TextBox txtLink;
        private Label label9;
        private TextBox txtChave;
        private TextBox txtErros;
        private Label label10;
        private TextBox txtImagem;
        private Button button2;
        private Label labelIdLoja;
        private TextBox textEmail;
        private TextBox textSenha;
        private Label labelEmail;
        private Label labelSenha;
        private Button buttonEnviarMensagem;
        private TextBox textIdLoja;
        private Label labelIdSetor;
        private Label labelIdCanal;
        private TextBox textIdSetor;
        private TextBox textIdCanal;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label labelContatoNome;
        private Label labelContatoSobrenome;
        private Label labelContatoNumero;
        private Label label11;
    }
}