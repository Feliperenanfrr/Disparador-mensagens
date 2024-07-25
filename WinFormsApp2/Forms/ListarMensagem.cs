using MySql.Data.MySqlClient;
using Gweb.WhatsApp.Util;
using WinFormsApp2;
using System.Data;
using System.Windows.Forms;

namespace Gweb.WhatsApp.Forms
{
    public partial class ListarMensagem : Form
    {
        operacoesBD operacoesBD = new operacoesBD();
        private MySqlConnection bdConn;

        public ListarMensagem()
        {
            InitializeComponent();
        }

        private void btnPesquisarMensagem_Click(object sender, EventArgs e)
        {
            FormUnderChat formUnderChat = new FormUnderChat();

            string server = formUnderChat.txtServer.Text;
            string user = formUnderChat.txtUsuario.Text;
            string senha = formUnderChat.txtSenha.Text;
            string banco = formUnderChat.txtBanco.Text;

            bdConn = operacoesBD.AbrirConexao(server, user, senha, banco);

            try
            {
                string query = "SELECT * FROM cadastro_mensagens";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, bdConn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridMensagens.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }

        }

        private void btnSelecionarContatos_Click(object sender, EventArgs e)
        {
            AgendarMensagens selecionarContatos = new AgendarMensagens();
            selecionarContatos.Show();
        }

    }
}
