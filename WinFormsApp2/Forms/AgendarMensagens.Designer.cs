namespace Gweb.WhatsApp.Forms
{
    partial class AgendarMensagens
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
            dataEnvioMensagem = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnAgendarMensagem = new Button();
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
            // dataEnvioMensagem
            // 
            dataEnvioMensagem.AccessibleRole = AccessibleRole.None;
            dataEnvioMensagem.CustomFormat = "dd/MM/yyyy HH:mm";
            dataEnvioMensagem.Format = DateTimePickerFormat.Custom;
            dataEnvioMensagem.Location = new Point(434, 55);
            dataEnvioMensagem.Name = "dataEnvioMensagem";
            dataEnvioMensagem.Size = new Size(169, 27);
            dataEnvioMensagem.TabIndex = 2;
            dataEnvioMensagem.Value = new DateTime(2024, 7, 25, 0, 0, 0, 0);
            dataEnvioMensagem.ValueChanged += this.dataEnvioMensagem_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 122);
            label1.Name = "label1";
            label1.Size = new Size(151, 20);
            label1.TabIndex = 3;
            label1.Text = "Escolha a mensagem:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(434, 32);
            label2.Name = "label2";
            label2.Size = new Size(169, 20);
            label2.TabIndex = 4;
            label2.Text = "Escolha a data de envio:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(434, 122);
            label3.Name = "label3";
            label3.Size = new Size(156, 20);
            label3.TabIndex = 5;
            label3.Text = "Selecione os contatos:";
            // 
            // btnAgendarMensagem
            // 
            btnAgendarMensagem.Location = new Point(564, 558);
            btnAgendarMensagem.Name = "btnAgendarMensagem";
            btnAgendarMensagem.Size = new Size(177, 29);
            btnAgendarMensagem.TabIndex = 6;
            btnAgendarMensagem.Text = "Agendar mensagem";
            btnAgendarMensagem.UseVisualStyleBackColor = true;
            btnAgendarMensagem.Click += btnAgendarMensagem_Click;
            // 
            // AgendarMensagens
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(832, 623);
            Controls.Add(btnAgendarMensagem);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataEnvioMensagem);
            Controls.Add(boxIdMensagens);
            Controls.Add(listContatos);
            Name = "AgendarMensagens";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SelecionarContatos";
            Load += SelecionarContatos_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox listContatos;
        private ComboBox boxIdMensagens;
        private DateTimePicker dataEnvioMensagem;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnAgendarMensagem;
    }
}