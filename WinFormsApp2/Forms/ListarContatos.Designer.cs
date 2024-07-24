namespace Gweb.WhatsApp.Forms
{
    partial class ListarContatos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListarContatos));
            btnListarContatos = new Button();
            dataGridContatos = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Id_Underchat = new DataGridViewTextBoxColumn();
            Telefone = new DataGridViewTextBoxColumn();
            Nome = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridContatos).BeginInit();
            SuspendLayout();
            // 
            // btnListarContatos
            // 
            btnListarContatos.Location = new Point(12, 12);
            btnListarContatos.Name = "btnListarContatos";
            btnListarContatos.Size = new Size(94, 29);
            btnListarContatos.TabIndex = 0;
            btnListarContatos.Text = "Listar contatos";
            btnListarContatos.UseVisualStyleBackColor = true;
            btnListarContatos.Click += btnListarContatos_Click;
            // 
            // dataGridContatos
            // 
            dataGridContatos.BackgroundColor = Color.White;
            dataGridContatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridContatos.Columns.AddRange(new DataGridViewColumn[] { ID, Id_Underchat, Telefone, Nome });
            dataGridContatos.Location = new Point(0, 194);
            dataGridContatos.Name = "dataGridContatos";
            dataGridContatos.RowHeadersWidth = 51;
            dataGridContatos.RowTemplate.Height = 29;
            dataGridContatos.Size = new Size(1266, 502);
            dataGridContatos.TabIndex = 1;
            dataGridContatos.CellContentClick += dataGridView1_CellContentClick;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.Width = 125;
            // 
            // Id_Underchat
            // 
            Id_Underchat.DataPropertyName = "Id_Underchat";
            Id_Underchat.HeaderText = "Id Underchat";
            Id_Underchat.MinimumWidth = 6;
            Id_Underchat.Name = "Id_Underchat";
            Id_Underchat.Width = 125;
            // 
            // Telefone
            // 
            Telefone.DataPropertyName = "Telefone";
            Telefone.HeaderText = "Telefone";
            Telefone.MinimumWidth = 6;
            Telefone.Name = "Telefone";
            Telefone.Width = 125;
            // 
            // Nome
            // 
            Nome.DataPropertyName = "Nome";
            Nome.HeaderText = "Nome";
            Nome.MinimumWidth = 6;
            Nome.Name = "Nome";
            Nome.Width = 125;
            // 
            // ListarContatos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1266, 694);
            Controls.Add(dataGridContatos);
            Controls.Add(btnListarContatos);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ListarContatos";
            Text = "ListarContatos";
            ((System.ComponentModel.ISupportInitialize)dataGridContatos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnListarContatos;
        private DataGridView dataGridContatos;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Id_Underchat;
        private DataGridViewTextBoxColumn Telefone;
        private DataGridViewTextBoxColumn Nome;
    }
}