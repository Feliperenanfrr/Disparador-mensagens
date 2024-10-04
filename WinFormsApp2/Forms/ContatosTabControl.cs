using Gweb.WhatsApp.Util;
using MaterialSkin.Controls;
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
using WinFormsApp2;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Gweb.WhatsApp.Forms
{
    public partial class ContatosTabControl : MaterialForm
    {
        operacoesBD operacoesBD = new operacoesBD();
        private MySqlConnection bdConn;
        FormUnderChat formUnderChat = new FormUnderChat();
        private DataSet bdDataSet;
        ConexaoAPI conexaoAPI = new ConexaoAPI();

        private int idMensagem;
        private string server;
        private string user;
        private string senha;
        private string banco;

        string idLoja = "832";
        string email = "felipeferreira3146@gmail.com";

        public ContatosTabControl()
        {
            InitializeComponent();
            this.server = formUnderChat.txtServer.Text;
            this.user = formUnderChat.txtUsuario.Text;
            this.senha = formUnderChat.txtSenha.Text;
            this.banco = formUnderChat.txtBanco.Text;
        }

        private void btnCadastrarContato_Click(object sender, EventArgs e)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = server,
                Database = banco,
                UserID = user,
                Password = senha,
                CharacterSet = "utf8"
            };

            try
            {
                // Faz um GET na API do UnderChat cria uma instância da classe Contato(Util/Contato.cs) para cada contato cadastrado
                // Adiciona todos os contatos a uma lista do tipo Contato
                bdDataSet = new DataSet();
                bdConn = new MySqlConnection(builder.ConnectionString);
                bdConn.Open();

                string token = conexaoAPI.ObterToken(email, "1664");
                RootContato listaDeContatos = conexaoAPI.BuscarTodosContatos(idLoja, token);

                List<Contato> contatosLista = listaDeContatos.data;
                //textContatos.Text = listaDeContatos.ToString();

                int contatosCadastrados = 0;

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
                                contatosCadastrados++;
                            }

                        }
                    }
                }

                MaterialMessageBox.Show($"Total de contatos cadastrados: {contatosCadastrados}", "Contatos Cadastrados");
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show("Erro");
                //textContatos.Text = ex.Message;
            }
            bdConn.Close();
        }
    }
}
