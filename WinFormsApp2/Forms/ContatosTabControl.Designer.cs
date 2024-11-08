namespace Gweb.WhatsApp.Forms
{
    partial class ContatosTabControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabPage1 = new TabPage();
            contatosListView = new MaterialSkin.Controls.MaterialListView();
            Id = new ColumnHeader();
            IdUnderchat = new ColumnHeader();
            Nome = new ColumnHeader();
            Telefone = new ColumnHeader();
            btnListarContatos = new MaterialSkin.Controls.MaterialButton();
            btnCadastrarContatos = new MaterialSkin.Controls.MaterialButton();
            tabPage2 = new TabPage();
            materialTabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // materialTabControl1
            // 
            materialTabControl1.Controls.Add(tabPage1);
            materialTabControl1.Controls.Add(tabPage2);
            materialTabControl1.Depth = 0;
            materialTabControl1.Dock = DockStyle.Fill;
            materialTabControl1.Location = new Point(3, 64);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(1260, 627);
            materialTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(contatosListView);
            tabPage1.Controls.Add(btnListarContatos);
            tabPage1.Controls.Add(btnCadastrarContatos);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1252, 594);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Controle";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // contatosListView
            // 
            contatosListView.AutoSizeTable = false;
            contatosListView.BackColor = Color.FromArgb(255, 255, 255);
            contatosListView.BorderStyle = BorderStyle.None;
            contatosListView.Columns.AddRange(new ColumnHeader[] { Id, IdUnderchat, Nome, Telefone });
            contatosListView.Depth = 0;
            contatosListView.Font = new Font("Segoe UI", 9F);
            contatosListView.FullRowSelect = true;
            contatosListView.Location = new Point(281, 88);
            contatosListView.MinimumSize = new Size(200, 100);
            contatosListView.MouseLocation = new Point(-1, -1);
            contatosListView.MouseState = MaterialSkin.MouseState.OUT;
            contatosListView.Name = "contatosListView";
            contatosListView.OwnerDraw = true;
            contatosListView.Size = new Size(536, 453);
            contatosListView.TabIndex = 2;
            contatosListView.UseCompatibleStateImageBehavior = false;
            contatosListView.View = View.Details;
            // 
            // Id
            // 
            Id.Text = "Id";
            Id.Width = 100;
            // 
            // IdUnderchat
            // 
            IdUnderchat.Text = "Id Underchat";
            IdUnderchat.Width = 120;
            // 
            // Nome
            // 
            Nome.Text = "Nome";
            Nome.Width = 150;
            // 
            // Telefone
            // 
            Telefone.Text = "Telefone";
            Telefone.Width = 150;
            // 
            // btnListarContatos
            // 
            btnListarContatos.AutoSize = false;
            btnListarContatos.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnListarContatos.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnListarContatos.Depth = 0;
            btnListarContatos.HighEmphasis = true;
            btnListarContatos.Icon = null;
            btnListarContatos.Location = new Point(891, 407);
            btnListarContatos.Margin = new Padding(4, 6, 4, 6);
            btnListarContatos.MouseState = MaterialSkin.MouseState.HOVER;
            btnListarContatos.Name = "btnListarContatos";
            btnListarContatos.NoAccentTextColor = Color.Empty;
            btnListarContatos.Size = new Size(279, 45);
            btnListarContatos.TabIndex = 1;
            btnListarContatos.Text = "Listar contatos";
            btnListarContatos.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnListarContatos.UseAccentColor = false;
            btnListarContatos.UseVisualStyleBackColor = true;
            btnListarContatos.Click += btnListarContatos_Click;
            // 
            // btnCadastrarContatos
            // 
            btnCadastrarContatos.AutoSize = false;
            btnCadastrarContatos.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCadastrarContatos.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnCadastrarContatos.Depth = 0;
            btnCadastrarContatos.HighEmphasis = true;
            btnCadastrarContatos.Icon = null;
            btnCadastrarContatos.Location = new Point(891, 496);
            btnCadastrarContatos.Margin = new Padding(4, 6, 4, 6);
            btnCadastrarContatos.MouseState = MaterialSkin.MouseState.HOVER;
            btnCadastrarContatos.Name = "btnCadastrarContatos";
            btnCadastrarContatos.NoAccentTextColor = Color.Empty;
            btnCadastrarContatos.Size = new Size(279, 45);
            btnCadastrarContatos.TabIndex = 0;
            btnCadastrarContatos.Text = "Cadastrar novos contatos";
            btnCadastrarContatos.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnCadastrarContatos.UseAccentColor = false;
            btnCadastrarContatos.UseVisualStyleBackColor = true;
            btnCadastrarContatos.Click += btnCadastrarContatos_Click;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1252, 594);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // ContatosTabControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1266, 694);
            Controls.Add(materialTabControl1);
            Name = "ContatosTabControl";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gerenciar Contatos";
            materialTabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private MaterialSkin.Controls.MaterialButton btnListarContatos;
        private MaterialSkin.Controls.MaterialButton btnCadastrarContatos;
        private MaterialSkin.Controls.MaterialListView contatosListView;
        private ColumnHeader Id;
        private ColumnHeader IdUnderchat;
        private ColumnHeader Nome;
        private ColumnHeader Telefone;
    }
}