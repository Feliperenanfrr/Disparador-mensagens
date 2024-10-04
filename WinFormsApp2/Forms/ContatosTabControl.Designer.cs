namespace Gweb.WhatsApp.Forms
{
    partial class ContatosTabControl
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
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabPage1 = new TabPage();
            btnCadastrarContato = new MaterialSkin.Controls.MaterialButton();
            tabPage2 = new TabPage();
            materialTabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // materialTabControl1
            // 
            materialTabControl1.Controls.Add(tabPage1);
            materialTabControl1.Controls.Add(tabPage2);
            materialTabControl1.Depth = 0;
            materialTabControl1.Dock = DockStyle.Fill;
            materialTabControl1.Location = new Point(3, 64);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(1246, 517);
            materialTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnCadastrarContato);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1238, 484);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnCadastrarContato
            // 
            btnCadastrarContato.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCadastrarContato.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnCadastrarContato.Depth = 0;
            btnCadastrarContato.HighEmphasis = true;
            btnCadastrarContato.Icon = null;
            btnCadastrarContato.Location = new Point(458, 171);
            btnCadastrarContato.Margin = new Padding(4, 6, 4, 6);
            btnCadastrarContato.MouseState = MaterialSkin.MouseState.HOVER;
            btnCadastrarContato.Name = "btnCadastrarContato";
            btnCadastrarContato.NoAccentTextColor = Color.Empty;
            btnCadastrarContato.Size = new Size(158, 36);
            btnCadastrarContato.TabIndex = 0;
            btnCadastrarContato.Text = "materialButton1";
            btnCadastrarContato.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnCadastrarContato.UseAccentColor = false;
            btnCadastrarContato.UseVisualStyleBackColor = true;
            btnCadastrarContato.Click += btnCadastrarContato_Click;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1238, 484);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // ContatosTabControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1252, 584);
            Controls.Add(materialTabControl1);
            Name = "ContatosTabControl";
            Text = "Gerenciar Contatos";
            materialTabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private MaterialSkin.Controls.MaterialButton btnCadastrarContato;
    }
}