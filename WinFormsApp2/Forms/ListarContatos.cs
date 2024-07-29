using Gweb.WhatsApp.Util;
using MySql.Data.MySqlClient;
using System.Data;
using WinFormsApp2;

namespace Gweb.WhatsApp.Forms
{
    public partial class ListarContatos : Form
    {
        operacoesBD operacoesBD = new operacoesBD();
        private MySqlConnection bdConn;

        public ListarContatos()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnListarContatos_Click(object sender, EventArgs e)
        {
            FormUnderChat formUnderChat = new FormUnderChat();

            string server = formUnderChat.txtServer.Text;
            string user = formUnderChat.txtUsuario.Text;
            string senha = formUnderChat.txtSenha.Text;
            string banco = formUnderChat.txtBanco.Text;

            bdConn = operacoesBD.AbrirConexao(server, user, senha, banco);

            try
            {
                string query = "SELECT * FROM contatos_underchat";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, bdConn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridContatos.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }
    }
}
