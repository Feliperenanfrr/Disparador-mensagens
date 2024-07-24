namespace Gweb.WhatsApp.Forms
{
    partial class ListarMensagem
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
            dataGridMensagens = new DataGridView();
            btnPesquisarMensagem = new Button();
            ID = new DataGridViewTextBoxColumn();
            Tipo = new DataGridViewTextBoxColumn();
            Mensagem = new DataGridViewTextBoxColumn();
            Imagem = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridMensagens).BeginInit();
            SuspendLayout();
            // 
            // dataGridMensagens
            // 
            dataGridMensagens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridMensagens.Columns.AddRange(new DataGridViewColumn[] { ID, Tipo, Mensagem, Imagem });
            dataGridMensagens.Location = new Point(-1, 192);
            dataGridMensagens.Name = "dataGridMensagens";
            dataGridMensagens.RowHeadersWidth = 51;
            dataGridMensagens.RowTemplate.Height = 29;
            dataGridMensagens.Size = new Size(1266, 502);
            dataGridMensagens.TabIndex = 0;
            // 
            // btnPesquisarMensagem
            // 
            btnPesquisarMensagem.Location = new Point(12, 12);
            btnPesquisarMensagem.Name = "btnPesquisarMensagem";
            btnPesquisarMensagem.Size = new Size(94, 29);
            btnPesquisarMensagem.TabIndex = 1;
            btnPesquisarMensagem.Text = "Pesquisar";
            btnPesquisarMensagem.UseVisualStyleBackColor = true;
            btnPesquisarMensagem.Click += btnPesquisarMensagem_Click;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Width = 125;
            // 
            // Tipo
            // 
            Tipo.DataPropertyName = "Tipo";
            Tipo.HeaderText = "Tipo";
            Tipo.MinimumWidth = 6;
            Tipo.Name = "Tipo";
            Tipo.ReadOnly = true;
            Tipo.Width = 125;
            // 
            // Mensagem
            // 
            Mensagem.DataPropertyName = "Mensagem";
            Mensagem.HeaderText = "Mensagem";
            Mensagem.MinimumWidth = 6;
            Mensagem.Name = "Mensagem";
            Mensagem.ReadOnly = true;
            Mensagem.Width = 125;
            // 
            // Imagem
            // 
            Imagem.DataPropertyName = "Imagem";
            Imagem.HeaderText = "Imagem";
            Imagem.MinimumWidth = 6;
            Imagem.Name = "Imagem";
            Imagem.ReadOnly = true;
            Imagem.Width = 125;
            // 
            // ListarMensagem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1266, 694);
            Controls.Add(btnPesquisarMensagem);
            Controls.Add(dataGridMensagens);
            Name = "ListarMensagem";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ListarMensagem";
            ((System.ComponentModel.ISupportInitialize)dataGridMensagens).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridMensagens;
        private Button btnPesquisarMensagem;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Tipo;
        private DataGridViewTextBoxColumn Mensagem;
        private DataGridViewTextBoxColumn Imagem;
    }
}