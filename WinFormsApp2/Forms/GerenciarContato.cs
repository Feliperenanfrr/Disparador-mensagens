using Gweb.WhatsApp.Util;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Gweb.WhatsApp.Forms
{
    public partial class GerenciarContato : Form
    {
        private string myConnectionString;
        private MySqlConnection bdConn;

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
                //CharacterSet = "latin"
            };

            bdConn = new MySqlConnection(builder.ConnectionString);
            bdConn.Open();

            string token = conexaoAPI.ObterToken(email, senha);
            RootContato listaDeContatos =  conexaoAPI.BuscarTodosContatos(idLoja, token);

            List<Contato> contatosLista = listaDeContatos.data;
            textContatos.Text = listaDeContatos.ToString();
            foreach(Contato contato in contatosLista)
            {
                Person pessoa = contato.person;
                string nome = pessoa.name;
                if (nome.StartsWith("Gpd"))
                {
                    string query = "INSERT INTO contatos_underchat (Id_Underchat, Telefone, Nome) VALUES (@Id_Underchat, @Telefone, @Nome)";

                    using (MySqlCommand registrarContato = new MySqlCommand(query, bdConn))
                    {
                        registrarContato.Parameters.AddWithValue("@Id_Underchat", contato.id);
                        registrarContato.Parameters.AddWithValue("@Telefone", contato.value);
                        registrarContato.Parameters.AddWithValue("@Nome", pessoa.name);

                        registrarContato.ExecuteNonQuery();
                    }
                }
            }

            bdConn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
