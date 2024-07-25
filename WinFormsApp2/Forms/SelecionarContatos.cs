using MySql.Data.MySqlClient;
using Gweb.WhatsApp.Util;
using WinFormsApp2;
using System.Data;

namespace Gweb.WhatsApp.Forms
{
    public partial class SelecionarContatos : Form
    {
        MySqlConnection bdConn;
        operacoesBD operacoesBD = new operacoesBD();
        public SelecionarContatos()
        {
            InitializeComponent();
        }

        private void SelecionarContatos_Load(object sender, EventArgs e)
        {
            FormUnderChat formUnderChat = new FormUnderChat();

            string server = formUnderChat.txtServer.Text;
            string user = formUnderChat.txtUsuario.Text;
            string senha = formUnderChat.txtSenha.Text;
            string banco = formUnderChat.txtBanco.Text;

            try
            {
                bdConn = operacoesBD.AbrirConexao(server, user, senha, banco);
                string query = "SELECT * FROM contatos_underchat";
                MySqlCommand cmd = new MySqlCommand(query, bdConn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string nome = reader["nome"].ToString();
                    int id = Convert.ToInt32(reader["id"]);
                    listContatos.Items.Add(new ListItem(nome, id));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar contatos: {ex.Message}");
            }
        }

        public class ListItem
        {
            public string Nome { get; }
            public int Id { get; }

            public ListItem(string nome, int id)
            {
                Nome = nome;
                Id = id;
            }

            public override string ToString()
            {
                return $"{Id}: {Nome}";
            }
        }

        private void boxIdMensagens_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void boxIdMensagens_DropDown(object sender, EventArgs e)
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

                boxIdMensagens.Items.Clear();

                foreach (DataRow row in dataTable.Rows)
                {
                    boxIdMensagens.Items.Add($"{row["id"]}: {row["mensagem"].ToString()}");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }
    }
}
