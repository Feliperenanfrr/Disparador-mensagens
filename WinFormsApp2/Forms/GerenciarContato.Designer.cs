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
            btn_CadastrarContato = new Button();
            textContatos = new TextBox();
            SuspendLayout();
            // 
            // btn_CadastrarContato
            // 
            btn_CadastrarContato.Location = new Point(12, 58);
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
            // GerenciarContato
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1266, 694);
            Controls.Add(textContatos);
            Controls.Add(btn_CadastrarContato);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "GerenciarContato";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GerenciarContato";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_CadastrarContato;
        private TextBox textContatos;
    }
}