namespace Gweb.WhatsApp.Forms
{
    partial class CriarMensagem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CriarMensagem));
            textoMensagem = new RichTextBox();
            linkImagem = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tipoMensagem = new RichTextBox();
            btnCriarMensagem = new Button();
            SuspendLayout();
            // 
            // textoMensagem
            // 
            textoMensagem.Location = new Point(12, 50);
            textoMensagem.Name = "textoMensagem";
            textoMensagem.Size = new Size(248, 191);
            textoMensagem.TabIndex = 0;
            textoMensagem.Text = "";
            // 
            // linkImagem
            // 
            linkImagem.Location = new Point(270, 50);
            linkImagem.Name = "linkImagem";
            linkImagem.Size = new Size(200, 33);
            linkImagem.TabIndex = 1;
            linkImagem.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(85, 20);
            label1.TabIndex = 2;
            label1.Text = "Mensagem:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(270, 9);
            label2.Name = "label2";
            label2.Size = new Size(115, 20);
            label2.TabIndex = 3;
            label2.Text = "Link da imagem";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(269, 98);
            label3.Name = "label3";
            label3.Size = new Size(137, 20);
            label3.TabIndex = 4;
            label3.Text = "Tipo da mensagem";
            // 
            // tipoMensagem
            // 
            tipoMensagem.Location = new Point(268, 133);
            tipoMensagem.Name = "tipoMensagem";
            tipoMensagem.Size = new Size(200, 33);
            tipoMensagem.TabIndex = 5;
            tipoMensagem.Text = "";
            // 
            // btnCriarMensagem
            // 
            btnCriarMensagem.Location = new Point(268, 208);
            btnCriarMensagem.Name = "btnCriarMensagem";
            btnCriarMensagem.Size = new Size(200, 33);
            btnCriarMensagem.TabIndex = 6;
            btnCriarMensagem.Text = "Criar";
            btnCriarMensagem.UseVisualStyleBackColor = true;
            btnCriarMensagem.Click += btnCriarMensagem_Click;
            // 
            // CriarMensagem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 253);
            Controls.Add(btnCriarMensagem);
            Controls.Add(tipoMensagem);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(linkImagem);
            Controls.Add(textoMensagem);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CriarMensagem";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CriarMensagem";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox textoMensagem;
        private RichTextBox linkImagem;
        private Label label1;
        private Label label2;
        private Label label3;
        private RichTextBox tipoMensagem;
        internal Button btnCriarMensagem;
        private Button button1;
    }
}