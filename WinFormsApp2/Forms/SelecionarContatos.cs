using MySql.Data.MySqlClient;
using Gweb.WhatsApp.Util;
using WinFormsApp2;
using System.Data;
using static Gweb.WhatsApp.Forms.SelecionarContatos;

namespace Gweb.WhatsApp.Forms
{
    public partial class SelecionarContatos : Form
    {
        MySqlConnection bdConn;
        operacoesBD operacoesBD = new operacoesBD();
        FormUnderChat formUnderChat = new FormUnderChat();

        private int idMensagem;

        public SelecionarContatos()
        {
            InitializeComponent();
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

        public class MensagemItem
        {
            public int Id { get; set; }
            public string Mensagem { get; set; }

            public override string ToString()
            {
                return $"{Id}: {Mensagem}";
            }
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

        private void boxIdMensagens_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void boxIdMensagens_DropDown(object sender, EventArgs e)
        {
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
                    MensagemItem item = new MensagemItem
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Mensagem = row["mensagem"].ToString()
                    };
                    boxIdMensagens.Items.Add(item);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }

            operacoesBD.EncerrarBancoDados(bdConn);
        }

        private void btnAgendarMensagem_Click(object sender, EventArgs e)
        {
            string server = formUnderChat.txtServer.Text;
            string user = formUnderChat.txtUsuario.Text;
            string senha = formUnderChat.txtSenha.Text;
            string banco = formUnderChat.txtBanco.Text;

            bdConn = operacoesBD.AbrirConexao(server, user, senha, banco);

            MensagemItem mensagemSelecionada = boxIdMensagens.SelectedItem as MensagemItem;
            if (mensagemSelecionada == null)
            {
                MessageBox.Show("Por favor, selecione uma mensagem.");
                return;
            }
            int idMensagem = mensagemSelecionada.Id;
            DateTime dataSelecionada = dataEnvioMensagem.Value;

            foreach (var item in listContatos.CheckedItems)
            {
                ListItem contato = item as ListItem;
                if (contato == null) continue;

                int idContato = contato.Id;

                string query = "INSERT INTO envio_mensagens(id_contato, id_mensagem, data_envio) VALUES (@idContato, @idMensagem, @dataEnvio)";
                using (MySqlCommand cmd = new MySqlCommand(query, bdConn))
                {
                    cmd.Parameters.AddWithValue("@idMensagem", idMensagem);
                    cmd.Parameters.AddWithValue("@idContato", idContato);
                    cmd.Parameters.AddWithValue("@dataEnvio", dataSelecionada);

                    cmd.ExecuteNonQuery();
                }
            }

            bdConn.Close();
        }
    }
}
