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
            tabCriarMensagem = new TabPage();
            tabListarMensagens = new TabPage();
            imageList1 = new ImageList(components);
            tabAgendarMensagem = new TabPage();
            materialTabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // materialTabControl1
            // 
            materialTabControl1.Controls.Add(tabCriarMensagem);
            materialTabControl1.Controls.Add(tabListarMensagens);
            materialTabControl1.Controls.Add(tabAgendarMensagem);
            materialTabControl1.Depth = 0;
            materialTabControl1.Dock = DockStyle.Fill;
            materialTabControl1.ImageList = imageList1;
            materialTabControl1.Location = new Point(3, 64);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(1278, 674);
            materialTabControl1.TabIndex = 0;
            // 
            // tabCriarMensagem
            // 
            tabCriarMensagem.BackColor = Color.White;
            tabCriarMensagem.ImageKey = "plus.png";
            tabCriarMensagem.Location = new Point(4, 39);
            tabCriarMensagem.Name = "tabCriarMensagem";
            tabCriarMensagem.Padding = new Padding(3);
            tabCriarMensagem.Size = new Size(1270, 631);
            tabCriarMensagem.TabIndex = 0;
            tabCriarMensagem.Text = "Criar mensagem";
            // 
            // tabListarMensagens
            // 
            tabListarMensagens.BackColor = Color.White;
            tabListarMensagens.ImageKey = "list.png";
            tabListarMensagens.Location = new Point(4, 39);
            tabListarMensagens.Name = "tabListarMensagens";
            tabListarMensagens.Padding = new Padding(3);
            tabListarMensagens.Size = new Size(1270, 631);
            tabListarMensagens.TabIndex = 1;
            tabListarMensagens.Text = "Listar mensagens ";
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
            // tabAgendarMensagem
            // 
            tabAgendarMensagem.ImageKey = "clock.png";
            tabAgendarMensagem.Location = new Point(4, 39);
            tabAgendarMensagem.Name = "tabAgendarMensagem";
            tabAgendarMensagem.Size = new Size(1270, 631);
            tabAgendarMensagem.TabIndex = 2;
            tabAgendarMensagem.Text = "Agendar envio";
            tabAgendarMensagem.UseVisualStyleBackColor = true;
            // 
            // MensagensTabControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1284, 741);
            Controls.Add(materialTabControl1);
            Name = "MensagensTabControl";
            Text = "Gerenciador de mensagens";
            materialTabControl1.ResumeLayout(false);
            ResumeLayout(false);
            materialTabControl1.Visible = true;
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private TabPage tabCriarMensagem;
        private TabPage tabListarMensagens;
        private ImageList imageList1;
        private TabPage tabAgendarMensagem;
    }
}