namespace Gweb.WhatsApp.Forms
{
    partial class SelecionarContatos
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
            listContatos = new CheckedListBox();
            SuspendLayout();
            // 
            // listContatos
            // 
            listContatos.FormattingEnabled = true;
            listContatos.Location = new Point(12, 169);
            listContatos.Name = "listContatos";
            listContatos.Size = new Size(307, 378);
            listContatos.TabIndex = 0;
            // 
            // SelecionarContatos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 565);
            Controls.Add(listContatos);
            Name = "SelecionarContatos";
            Text = "SelecionarContatos";
            Load += SelecionarContatos_Load;
            ResumeLayout(false);
        }

        #endregion

        private CheckedListBox listContatos;
    }
}