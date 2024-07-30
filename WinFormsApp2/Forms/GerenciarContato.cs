using Gweb.WhatsApp.Util;
using MySql.Data.MySqlClient;
using System.Data;

namespace Gweb.WhatsApp.Forms
{
    public partial class GerenciarContato : Form
    {
        private MySqlConnection bdConn;
        private DataSet bdDataSet;

        ConexaoAPI conexaoAPI = new ConexaoAPI();
        string idLoja = "832";
        string email = "felipeferreira3146@gmail.com";
        string senha = "1664";

        public GerenciarContato()
        {
            InitializeComponent();
        }

        private void btnCadastrarContato(object sender, EventArgs e)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "mysql.gueppardo.net",
                Database = "gueppardo",
                UserID = "gueppardo",
                Password = "gpd1664",
                CharacterSet = "utf8"
            };

            try
            {
                // Faz um GET na API do UnderChat cria uma instância da classe Contato(Util/Contato.cs) para cada contato cadastrado
                // Adiciona todos os contatos a uma lista do tipo Contato
                bdDataSet = new DataSet();
                bdConn = new MySqlConnection(builder.ConnectionString);
                bdConn.Open();

                string token = conexaoAPI.ObterToken(email, senha);
                RootContato listaDeContatos = conexaoAPI.BuscarTodosContatos(idLoja, token);

                List<Contato> contatosLista = listaDeContatos.data;
                textContatos.Text = listaDeContatos.ToString();

                foreach (Contato contato in contatosLista)
                {
                    // Cadastra apenas os contatos com os prefixos e que não estejam cadastrados no BD
                    Person pessoa = contato.person;
                    string nome = pessoa.name;
                    if (nome.StartsWith("Gpd") || nome.StartsWith("Cli-") || nome.StartsWith("Parc-"))
                    {
                        string checkContato = "SELECT COUNT(*) FROM contatos_underchat WHERE Id_Underchat = @Id_Underchat AND Telefone = @Telefone";
                        using (MySqlCommand checkCmd = new MySqlCommand(checkContato, bdConn))
                        {
                            checkCmd.Parameters.AddWithValue("@Id_Underchat", contato.id);
                            checkCmd.Parameters.AddWithValue("@Telefone", contato.value);

                            int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                            if (count == 0)
                            {
                                string insertQuery = "INSERT INTO contatos_underchat (Id_Underchat, Telefone, Nome) VALUES (@Id_Underchat, @Telefone, @Nome)";
                                using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, bdConn))
                                {
                                    insertCmd.Parameters.AddWithValue("@Id_Underchat", contato.id);
                                    insertCmd.Parameters.AddWithValue("@Telefone", contato.value);
                                    insertCmd.Parameters.AddWithValue("@Nome", pessoa.name);

                                    insertCmd.ExecuteNonQuery();
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                textContatos.Text = ex.Message;
            }
            bdConn.Close();
        }

        private void btnListarContatos_Click(object sender, EventArgs e)
        {
            ListarContatos listarContatos = new ListarContatos();
            listarContatos.Show();
        }
    }
}
