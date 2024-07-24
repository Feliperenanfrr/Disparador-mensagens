namespace Gweb.WhatsApp.Forms
{
    partial class GerenciarMensagens
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
            menuStrip1 = new MenuStrip();
            btnCriarMensagem = new ToolStripMenuItem();
            listarMensagensExistentesToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ControlDark;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { btnCriarMensagem, listarMensagensExistentesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1266, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // btnCriarMensagem
            // 
            btnCriarMensagem.Name = "btnCriarMensagem";
            btnCriarMensagem.Size = new Size(167, 24);
            btnCriarMensagem.Text = "Criar nova mensagem";
            btnCriarMensagem.Click += btnCriarMensagem_Click;
            // 
            // listarMensagensExistentesToolStripMenuItem
            // 
            listarMensagensExistentesToolStripMenuItem.Name = "listarMensagensExistentesToolStripMenuItem";
            listarMensagensExistentesToolStripMenuItem.Size = new Size(205, 24);
            listarMensagensExistentesToolStripMenuItem.Text = "Listar mensagens existentes";
            // 
            // GerenciarMensagens
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1266, 694);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "GerenciarMensagens";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GerenciarMensagens";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem btnCriarMensagem;
        private ToolStripMenuItem listarMensagensExistentesToolStripMenuItem;
    }
}