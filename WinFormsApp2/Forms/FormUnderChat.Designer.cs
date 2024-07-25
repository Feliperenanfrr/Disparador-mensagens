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
            groupBox1 = new GroupBox();
            btnAtivar = new Button();
            txtBanco = new TextBox();
            txtSenha = new TextBox();
            txtUsuario = new TextBox();
            txtServer = new TextBox();
            btnSair = new Button();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            button2 = new Button();
            tmMonitora = new System.Windows.Forms.Timer(components);
            textMensagens = new TextBox();
            labelEmail = new Label();
            textEmail = new TextBox();
            textSenha = new TextBox();
            labelSenha = new Label();
            textIdLoja = new TextBox();
            labelIdLoja = new Label();
            labelIdSetor = new Label();
            labelIdCanal = new Label();
            textIdSetor = new TextBox();
            textIdCanal = new TextBox();
            label1 = new Label();
            btnContatos_Menu = new ToolStripMenuItem();
            btnMensagens_menu = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            groupBox1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAtivar);
            groupBox1.Controls.Add(txtBanco);
            groupBox1.Controls.Add(txtSenha);
            groupBox1.Controls.Add(txtUsuario);
            groupBox1.Controls.Add(txtServer);
            groupBox1.Controls.Add(btnSair);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(button2);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(15, 405);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(633, 274);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Monitorador";
            // 
            // btnAtivar
            // 
            btnAtivar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAtivar.Location = new Point(295, 30);
            btnAtivar.Name = "btnAtivar";
            btnAtivar.Size = new Size(318, 84);
            btnAtivar.TabIndex = 10;
            btnAtivar.Text = "Ativar";
            btnAtivar.UseVisualStyleBackColor = true;
            btnAtivar.Click += btnAtivar_Click;
            // 
            // txtBanco
            // 
            txtBanco.Enabled = false;
            txtBanco.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txtBanco.Location = new Point(97, 146);
            txtBanco.Name = "txtBanco";
            txtBanco.Size = new Size(182, 27);
            txtBanco.TabIndex = 6;
            txtBanco.Text = "gueppardo";
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
            label5.Size = new Size(52, 20);
            label5.TabIndex = 6;
            label5.Text = "Banco";
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
            // 
            // button2
            // 
            button2.Location = new Point(295, 179);
            button2.Name = "button2";
            button2.Size = new Size(318, 52);
            button2.TabIndex = 17;
            button2.Text = "WhatsApp";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // tmMonitora
            // 
            tmMonitora.Interval = 1000;
            tmMonitora.Tick += tmMonitora_Tick;
            // 
            // textMensagens
            // 
            textMensagens.Location = new Point(744, 64);
            textMensagens.Multiline = true;
            textMensagens.Name = "textMensagens";
            textMensagens.Size = new Size(501, 586);
            textMensagens.TabIndex = 12;
            textMensagens.Text = "Area de Mensagens";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(12, 98);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(123, 20);
            labelEmail.TabIndex = 18;
            labelEmail.Text = "Email UnderChat:";
            // 
            // textEmail
            // 
            textEmail.Location = new Point(142, 95);
            textEmail.Name = "textEmail";
            textEmail.Size = new Size(237, 27);
            textEmail.TabIndex = 19;
            textEmail.Text = "felipeferreira3146@gmail.com";
            // 
            // textSenha
            // 
            textSenha.Location = new Point(141, 138);
            textSenha.Name = "textSenha";
            textSenha.PasswordChar = '*';
            textSenha.Size = new Size(125, 27);
            textSenha.TabIndex = 20;
            textSenha.Text = "1664";
            // 
            // labelSenha
            // 
            labelSenha.AutoSize = true;
            labelSenha.Location = new Point(12, 141);
            labelSenha.Name = "labelSenha";
            labelSenha.Size = new Size(123, 20);
            labelSenha.TabIndex = 22;
            labelSenha.Text = "Senha UnderChat";
            // 
            // textIdLoja
            // 
            textIdLoja.Location = new Point(142, 182);
            textIdLoja.Name = "textIdLoja";
            textIdLoja.Size = new Size(125, 27);
            textIdLoja.TabIndex = 24;
            textIdLoja.Text = "832";
            // 
            // labelIdLoja
            // 
            labelIdLoja.AutoSize = true;
            labelIdLoja.Location = new Point(57, 178);
            labelIdLoja.Name = "labelIdLoja";
            labelIdLoja.Size = new Size(78, 20);
            labelIdLoja.TabIndex = 25;
            labelIdLoja.Text = "Id da Loja:";
            // 
            // labelIdSetor
            // 
            labelIdSetor.AutoSize = true;
            labelIdSetor.Location = new Point(53, 224);
            labelIdSetor.Name = "labelIdSetor";
            labelIdSetor.Size = new Size(86, 20);
            labelIdSetor.TabIndex = 26;
            labelIdSetor.Text = "Id do Setor:";
            // 
            // labelIdCanal
            // 
            labelIdCanal.AutoSize = true;
            labelIdCanal.Location = new Point(49, 261);
            labelIdCanal.Name = "labelIdCanal";
            labelIdCanal.Size = new Size(86, 20);
            labelIdCanal.TabIndex = 27;
            labelIdCanal.Text = "Id do canal:";
            // 
            // textIdSetor
            // 
            textIdSetor.Location = new Point(142, 221);
            textIdSetor.Name = "textIdSetor";
            textIdSetor.Size = new Size(125, 27);
            textIdSetor.TabIndex = 28;
            textIdSetor.Text = "4389";
            // 
            // textIdCanal
            // 
            textIdCanal.Location = new Point(141, 265);
            textIdCanal.Name = "textIdCanal";
            textIdCanal.Size = new Size(125, 27);
            textIdCanal.TabIndex = 29;
            textIdCanal.Text = "1215";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 64);
            label1.Name = "label1";
            label1.Size = new Size(116, 20);
            label1.TabIndex = 37;
            label1.Text = "Dados de envio:";
            // 
            // btnContatos_Menu
            // 
            btnContatos_Menu.Name = "btnContatos_Menu";
            btnContatos_Menu.Size = new Size(82, 24);
            btnContatos_Menu.Text = "Contatos";
            btnContatos_Menu.Click += btnContatos_Click;
            // 
            // btnMensagens_menu
            // 
            btnMensagens_menu.Name = "btnMensagens_menu";
            btnMensagens_menu.Size = new Size(97, 24);
            btnMensagens_menu.Text = "Mensagens";
            btnMensagens_menu.Click += btnMensagens_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ControlDark;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { btnContatos_Menu, btnMensagens_menu });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1266, 28);
            menuStrip1.TabIndex = 38;
            menuStrip1.Text = "menuStrip1";
            // 
            // FormUnderChat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Menu;
            ClientSize = new Size(1266, 694);
            Controls.Add(label1);
            Controls.Add(textIdCanal);
            Controls.Add(textIdSetor);
            Controls.Add(labelIdCanal);
            Controls.Add(labelIdSetor);
            Controls.Add(labelIdLoja);
            Controls.Add(textIdLoja);
            Controls.Add(labelSenha);
            Controls.Add(textSenha);
            Controls.Add(textEmail);
            Controls.Add(labelEmail);
            Controls.Add(textMensagens);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "FormUnderChat";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Disparador de Mensagens";
            Load += FormUnderChat_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox1;
        private Button btnSair;
        private Label label2;
        private Label label5;
        private Label label4;
        private Label label3;
        private System.Windows.Forms.Timer tmMonitora;
        private Button btnAtivar;
        private TextBox textMensagens;
        private Button button2;
        private Label labelIdLoja;
        private TextBox textEmail;
        private TextBox textSenha;
        private Label labelEmail;
        private Label labelSenha;
        private TextBox textIdLoja;
        private Label labelIdSetor;
        private Label labelIdCanal;
        private TextBox textIdSetor;
        private TextBox textIdCanal;
        private Label label1;
        public TextBox txtServer;
        public TextBox txtSenha;
        public TextBox txtUsuario;
        public TextBox txtBanco;
        private ToolStripMenuItem btnContatos_Menu;
        private ToolStripMenuItem btnMensagens_menu;
        private MenuStrip menuStrip1;
    }
}