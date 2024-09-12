using MaterialSkin.Controls;

namespace Gweb.WhatsApp.Forms
{
    partial class GerenciarContato
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GerenciarContato));
            btn_CadastrarContato = new MaterialButton();
            textContatos = new TextBox();
            menuStrip1 = new MenuStrip();
            btnListarContatos = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btn_CadastrarContato
            // 
            btn_CadastrarContato.Location = new Point(46, 507);
            btn_CadastrarContato.Name = "btn_CadastrarContato";
            btn_CadastrarContato.Size = new Size(200, 113);
            btn_CadastrarContato.TabIndex = 0;
            btn_CadastrarContato.Text = "Cadastrar novos contatos";
            btn_CadastrarContato.UseVisualStyleBackColor = true;
            btn_CadastrarContato.Click += btnCadastrarContato;
            // 
            // textContatos
            // 
            textContatos.Location = new Point(825, 58);
            textContatos.Multiline = true;
            textContatos.Name = "textContatos";
            textContatos.Size = new Size(399, 624);
            textContatos.TabIndex = 1;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { btnListarContatos });
            menuStrip1.Location = new Point(3, 64);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1260, 28);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // btnListarContatos
            // 
            btnListarContatos.Name = "btnListarContatos";
            btnListarContatos.Size = new Size(119, 24);
            btnListarContatos.Text = "Listar contatos";
            btnListarContatos.Click += btnListarContatos_Click;
            // 
            // GerenciarContato
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1266, 694);
            Controls.Add(textContatos);
            Controls.Add(btn_CadastrarContato);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "GerenciarContato";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GerenciarContato";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialButton btn_CadastrarContato;
        private TextBox textContatos;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem btnListarContatos;
    }
}