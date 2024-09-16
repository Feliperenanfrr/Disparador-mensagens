using System.Windows.Forms;

namespace Gweb.WhatsApp.Forms
{
    partial class MensagensTabControl
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MensagensTabControl));
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabListarMensagens = new TabPage();
            btnPesquisarMensagem = new MaterialSkin.Controls.MaterialButton();
            dataGridMensagens = new DataGridView();
            tabAgendarMensagem = new TabPage();
            listContatos = new MaterialSkin.Controls.MaterialCheckedListBox();
            labelData = new Label();
            dataEnvioMensagem = new DateTimePicker();
            boxIdMensagem = new ComboBox();
            labelMensagem = new Label();
            tabCriarMensagem = new TabPage();
            imageList1 = new ImageList(components);
            btnAgendarMensagem = new MaterialSkin.Controls.MaterialButton();
            materialTabControl1.SuspendLayout();
            tabListarMensagens.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridMensagens).BeginInit();
            tabAgendarMensagem.SuspendLayout();
            SuspendLayout();
            // 
            // materialTabControl1
            // 
            materialTabControl1.Controls.Add(tabListarMensagens);
            materialTabControl1.Controls.Add(tabAgendarMensagem);
            materialTabControl1.Controls.Add(tabCriarMensagem);
            materialTabControl1.Depth = 0;
            materialTabControl1.Dock = DockStyle.Fill;
            materialTabControl1.ImageList = imageList1;
            materialTabControl1.Location = new Point(3, 64);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(1260, 627);
            materialTabControl1.TabIndex = 0;
            // 
            // tabListarMensagens
            // 
            tabListarMensagens.BackColor = Color.White;
            tabListarMensagens.Controls.Add(btnPesquisarMensagem);
            tabListarMensagens.Controls.Add(dataGridMensagens);
            tabListarMensagens.ImageKey = "list.png";
            tabListarMensagens.Location = new Point(4, 39);
            tabListarMensagens.Name = "tabListarMensagens";
            tabListarMensagens.Padding = new Padding(3);
            tabListarMensagens.Size = new Size(1252, 584);
            tabListarMensagens.TabIndex = 1;
            tabListarMensagens.Text = "Listar mensagens ";
            // 
            // btnPesquisarMensagem
            // 
            btnPesquisarMensagem.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnPesquisarMensagem.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnPesquisarMensagem.Depth = 0;
            btnPesquisarMensagem.HighEmphasis = true;
            btnPesquisarMensagem.Icon = null;
            btnPesquisarMensagem.Location = new Point(982, 507);
            btnPesquisarMensagem.Margin = new Padding(4, 6, 4, 6);
            btnPesquisarMensagem.MouseState = MaterialSkin.MouseState.HOVER;
            btnPesquisarMensagem.Name = "btnPesquisarMensagem";
            btnPesquisarMensagem.NoAccentTextColor = Color.Empty;
            btnPesquisarMensagem.Size = new Size(100, 36);
            btnPesquisarMensagem.TabIndex = 1;
            btnPesquisarMensagem.Text = "Pesquisar";
            btnPesquisarMensagem.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnPesquisarMensagem.UseAccentColor = false;
            btnPesquisarMensagem.UseVisualStyleBackColor = true;
            btnPesquisarMensagem.Click += btnPesquisarMensagem_Click;
            // 
            // dataGridMensagens
            // 
            dataGridMensagens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridMensagens.Location = new Point(313, 42);
            dataGridMensagens.Name = "dataGridMensagens";
            dataGridMensagens.RowHeadersWidth = 51;
            dataGridMensagens.RowTemplate.Height = 29;
            dataGridMensagens.Size = new Size(550, 501);
            dataGridMensagens.TabIndex = 0;
            // 
            // tabAgendarMensagem
            // 
            tabAgendarMensagem.Controls.Add(btnAgendarMensagem);
            tabAgendarMensagem.Controls.Add(listContatos);
            tabAgendarMensagem.Controls.Add(labelData);
            tabAgendarMensagem.Controls.Add(dataEnvioMensagem);
            tabAgendarMensagem.Controls.Add(boxIdMensagem);
            tabAgendarMensagem.Controls.Add(labelMensagem);
            tabAgendarMensagem.ImageKey = "clock.png";
            tabAgendarMensagem.Location = new Point(4, 39);
            tabAgendarMensagem.Name = "tabAgendarMensagem";
            tabAgendarMensagem.Size = new Size(1252, 584);
            tabAgendarMensagem.TabIndex = 2;
            tabAgendarMensagem.Text = "Agendar envio";
            tabAgendarMensagem.UseVisualStyleBackColor = true;
            // 
            // listContatos
            // 
            listContatos.AutoScroll = true;
            listContatos.BackColor = Color.Transparent;
            listContatos.Depth = 0;
            listContatos.Location = new Point(667, 193);
            listContatos.MouseState = MaterialSkin.MouseState.HOVER;
            listContatos.Name = "listContatos";
            listContatos.Size = new Size(250, 272);
            listContatos.Striped = false;
            listContatos.StripeDarkColor = Color.Empty;
            listContatos.TabIndex = 7;
            listContatos.Paint += listContatos_Paint;
            // 
            // labelData
            // 
            labelData.AutoSize = true;
            labelData.Location = new Point(667, 74);
            labelData.Name = "labelData";
            labelData.Size = new Size(169, 20);
            labelData.TabIndex = 6;
            labelData.Text = "Escolha a data de envio:";
            // 
            // dataEnvioMensagem
            // 
            dataEnvioMensagem.AccessibleRole = AccessibleRole.None;
            dataEnvioMensagem.CustomFormat = "dd/MM/yyyy HH:mm";
            dataEnvioMensagem.Format = DateTimePickerFormat.Custom;
            dataEnvioMensagem.Location = new Point(667, 107);
            dataEnvioMensagem.Name = "dataEnvioMensagem";
            dataEnvioMensagem.Size = new Size(169, 27);
            dataEnvioMensagem.TabIndex = 5;
            dataEnvioMensagem.Value = new DateTime(2024, 7, 25, 0, 0, 0, 0);
            // 
            // boxIdMensagem
            // 
            boxIdMensagem.FormattingEnabled = true;
            boxIdMensagem.Location = new Point(87, 106);
            boxIdMensagem.Name = "boxIdMensagem";
            boxIdMensagem.Size = new Size(328, 28);
            boxIdMensagem.TabIndex = 1;
            boxIdMensagem.DropDown += boxIdMensagem_DropDown;
            // 
            // labelMensagem
            // 
            labelMensagem.AutoSize = true;
            labelMensagem.Location = new Point(83, 74);
            labelMensagem.Name = "labelMensagem";
            labelMensagem.Size = new Size(143, 20);
            labelMensagem.TabIndex = 0;
            labelMensagem.Text = "Escola a mensagem:";
            // 
            // tabCriarMensagem
            // 
            tabCriarMensagem.BackColor = Color.White;
            tabCriarMensagem.ImageKey = "plus.png";
            tabCriarMensagem.Location = new Point(4, 39);
            tabCriarMensagem.Name = "tabCriarMensagem";
            tabCriarMensagem.Padding = new Padding(3);
            tabCriarMensagem.Size = new Size(1252, 584);
            tabCriarMensagem.TabIndex = 0;
            tabCriarMensagem.Text = "Criar mensagem";
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "plus.png");
            imageList1.Images.SetKeyName(1, "list.png");
            imageList1.Images.SetKeyName(2, "clock.png");
            // 
            // btnAgendarMensagem
            // 
            btnAgendarMensagem.AutoSize = false;
            btnAgendarMensagem.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAgendarMensagem.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAgendarMensagem.Depth = 0;
            btnAgendarMensagem.HighEmphasis = true;
            btnAgendarMensagem.Icon = null;
            btnAgendarMensagem.Location = new Point(667, 501);
            btnAgendarMensagem.Margin = new Padding(4, 6, 4, 6);
            btnAgendarMensagem.MouseState = MaterialSkin.MouseState.HOVER;
            btnAgendarMensagem.Name = "btnAgendarMensagem";
            btnAgendarMensagem.NoAccentTextColor = Color.Empty;
            btnAgendarMensagem.Size = new Size(250, 45);
            btnAgendarMensagem.TabIndex = 8;
            btnAgendarMensagem.Text = "Agendar mensagem";
            btnAgendarMensagem.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAgendarMensagem.UseAccentColor = false;
            btnAgendarMensagem.UseVisualStyleBackColor = true;
            btnAgendarMensagem.Click += btnAgendarMensagem_Click;
            // 
            // MensagensTabControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1266, 694);
            Controls.Add(materialTabControl1);
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = materialTabControl1;
            Name = "MensagensTabControl";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gerenciador de mensagens";
            materialTabControl1.ResumeLayout(false);
            tabListarMensagens.ResumeLayout(false);
            tabListarMensagens.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridMensagens).EndInit();
            tabAgendarMensagem.ResumeLayout(false);
            tabAgendarMensagem.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private TabPage tabCriarMensagem;
        private TabPage tabListarMensagens;
        private ImageList imageList1;
        private TabPage tabAgendarMensagem;
        private DataGridView dataGridMensagens;
        private MaterialSkin.Controls.MaterialButton btnPesquisarMensagem;
        private Label labelMensagem;
        private ComboBox boxIdMensagem;
        private Label labelData;
        private DateTimePicker dataEnvioMensagem;
        private MaterialSkin.Controls.MaterialCheckedListBox listContatos;
        private MaterialSkin.Controls.MaterialButton btnAgendarMensagem;
    }
}