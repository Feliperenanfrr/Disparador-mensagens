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
            boxIdMensagens = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            SuspendLayout();
            // 
            // listContatos
            // 
            listContatos.FormattingEnabled = true;
            listContatos.Location = new Point(434, 145);
            listContatos.Name = "listContatos";
            listContatos.Size = new Size(307, 378);
            listContatos.TabIndex = 0;
            // 
            // boxIdMensagens
            // 
            boxIdMensagens.FormattingEnabled = true;
            boxIdMensagens.Location = new Point(12, 145);
            boxIdMensagens.Name = "boxIdMensagens";
            boxIdMensagens.Size = new Size(394, 28);
            boxIdMensagens.TabIndex = 1;
            boxIdMensagens.DropDown += boxIdMensagens_DropDown;
            boxIdMensagens.SelectedIndexChanged += boxIdMensagens_SelectedIndexChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(459, 21);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 2;
            // 
            // SelecionarContatos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(832, 623);
            Controls.Add(dateTimePicker1);
            Controls.Add(boxIdMensagens);
            Controls.Add(listContatos);
            Name = "SelecionarContatos";
            Text = "SelecionarContatos";
            Load += SelecionarContatos_Load;
            ResumeLayout(false);
        }

        #endregion

        private CheckedListBox listContatos;
        private ComboBox boxIdMensagens;
        private DateTimePicker dateTimePicker1;
    }
}