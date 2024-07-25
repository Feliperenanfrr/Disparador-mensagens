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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListarMensagem));
            dataGridMensagens = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Tipo = new DataGridViewTextBoxColumn();
            Mensagem = new DataGridViewTextBoxColumn();
            Imagem = new DataGridViewTextBoxColumn();
            btnPesquisarMensagem = new Button();
            btnSelecionarContatos = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridMensagens).BeginInit();
            SuspendLayout();
            // 
            // dataGridMensagens
            // 
            dataGridMensagens.BackgroundColor = SystemColors.Control;
            dataGridMensagens.BorderStyle = BorderStyle.None;
            dataGridMensagens.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.Gray;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.GrayText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridMensagens.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridMensagens.ColumnHeadersHeight = 30;
            dataGridMensagens.Columns.AddRange(new DataGridViewColumn[] { ID, Tipo, Mensagem, Imagem });
            dataGridMensagens.Location = new Point(1, 197);
            dataGridMensagens.Name = "dataGridMensagens";
            dataGridMensagens.RowHeadersWidth = 51;
            dataGridMensagens.RowTemplate.Height = 29;
            dataGridMensagens.Size = new Size(553, 496);
            dataGridMensagens.TabIndex = 0;
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
            // btnPesquisarMensagem
            // 
            btnPesquisarMensagem.Location = new Point(12, 12);
            btnPesquisarMensagem.Name = "btnPesquisarMensagem";
            btnPesquisarMensagem.Size = new Size(141, 29);
            btnPesquisarMensagem.TabIndex = 1;
            btnPesquisarMensagem.Text = "Pesquisar";
            btnPesquisarMensagem.UseVisualStyleBackColor = true;
            btnPesquisarMensagem.Click += btnPesquisarMensagem_Click;
            // 
            // btnSelecionarContatos
            // 
            btnSelecionarContatos.Location = new Point(185, 12);
            btnSelecionarContatos.Name = "btnSelecionarContatos";
            btnSelecionarContatos.Size = new Size(181, 29);
            btnSelecionarContatos.TabIndex = 2;
            btnSelecionarContatos.Text = "Selecionar contatos";
            btnSelecionarContatos.UseVisualStyleBackColor = true;
            btnSelecionarContatos.Click += btnSelecionarContatos_Click;
            // 
            // ListarMensagem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1266, 694);
            Controls.Add(btnSelecionarContatos);
            Controls.Add(btnPesquisarMensagem);
            Controls.Add(dataGridMensagens);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ListarMensagem";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ListarMensagem";
            ((System.ComponentModel.ISupportInitialize)dataGridMensagens).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnPesquisarMensagem;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Tipo;
        private DataGridViewTextBoxColumn Mensagem;
        private DataGridViewTextBoxColumn Imagem;
        private Button btnSelecionarContatos;
        public DataGridView dataGridMensagens;
    }
}