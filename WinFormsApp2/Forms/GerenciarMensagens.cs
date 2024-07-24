using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gweb.WhatsApp.Forms
{
    public partial class GerenciarMensagens : Form
    {
        public GerenciarMensagens()
        {
            InitializeComponent();
        }

        private void btnCriarMensagem_Click(object sender, EventArgs e)
        {
            CriarMensagem criarMensagem = new CriarMensagem();
            criarMensagem.Show();
        }

        private void btnListarMensagens_Click(object sender, EventArgs e)
        {
            ListarMensagem listarMensagem = new ListarMensagem();
            listarMensagem.Show();
        }
    }
}
