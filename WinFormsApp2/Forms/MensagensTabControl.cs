﻿using Gweb.WhatsApp.Util;
using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System.Data;
using WinFormsApp2;

namespace Gweb.WhatsApp.Forms
{
    public partial class MensagensTabControl : MaterialForm
    {
        operacoesBD operacoesBD = new operacoesBD();
        private MySqlConnection bdConn;
        FormUnderChat formUnderChat = new FormUnderChat();

        private int idMensagem;
        private string server;
        private string user;
        private string senha;
        private string banco;

        public MensagensTabControl()
        {
            InitializeComponent();
            this.server = formUnderChat.txtServer.Text;
            this.user = formUnderChat.txtUsuario.Text;
            this.senha = formUnderChat.txtSenha.Text;
            this.banco = formUnderChat.txtBanco.Text;
        }

        private void btnPesquisarMensagem_Click(object sender, EventArgs e)
        {
            // Seleciona todas as mensagens cadastradas no BD e exibe elas em um Data Grid
            using (bdConn = operacoesBD.AbrirConexao(server, user, senha, banco))
            {
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
        }

        private void boxIdMensagem_DropDown(object sender, EventArgs e)
        {
            // Utiliza a classe MensagemItem para receber os dados da tabela cadastro_mensagens e exiibir no ComboBox
            using (bdConn = operacoesBD.AbrirConexao(server, user, senha, banco))
            {
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
            }
        }

        private void btnAgendarMensagem_Click(object sender, EventArgs e)
        {
            using (bdConn = operacoesBD.AbrirConexao(server, user, senha, banco))
            {
                MensagemItem mensagemSelecionada = boxIdMensagens.SelectedItem as MensagemItem;
                if (mensagemSelecionada == null)
                {
                    MessageBox.Show("Por favor, selecione uma mensagem.");
                    return;
                }

                int idMensagem = mensagemSelecionada.Id;
                DateTime dataSelecionada = dataEnvioMensagem.Value;
                int linhasAfetadas = 0;
                List<int> idsContatos = new List<int>();

                // Cria instâncias da classe ListItem para cada contato selecionado na checklist
                // Insere um registro com a mensagem selecionada para cada contato
                foreach (var item in listContatos.CheckedItems)
                {
                    ListItem contato = item as ListItem;
                    if (contato == null) continue;
                    int idContato = contato.Id;
                    idsContatos.Add(idContato);

                    string query = "INSERT INTO envio_mensagens (id_contato, id_mensagem, data_envio) VALUES (@idContato, @idMensagem, @dataEnvio)";
                    using (MySqlCommand cmd = new MySqlCommand(query, bdConn))
                    {
                        cmd.Parameters.AddWithValue("@idMensagem", idMensagem);
                        cmd.Parameters.AddWithValue("@idContato", idContato);
                        cmd.Parameters.AddWithValue("@dataEnvio", dataSelecionada);
                        linhasAfetadas += cmd.ExecuteNonQuery();
                    }
                }

                // Recebe a quantidade de linhas afetadas no banco para garantir que as alterações foram feitas
                if (linhasAfetadas > 0)
                {
                    // Recebe os dados da mensagem através do ID inserido na tabela pela funçaõ acima
                    string mensagemQuery = "SELECT mensagem, imagem FROM cadastro_mensagens WHERE id = @idMensagem";
                    string? mensagem = null;
                    string? imagem = null;

                    using (MySqlCommand cmd = new MySqlCommand(mensagemQuery, bdConn))
                    {
                        cmd.Parameters.AddWithValue("idMensagem", idMensagem);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                mensagem = reader["mensagem"].ToString();
                                imagem = reader["imagem"].ToString();
                            }
                        }
                        mensagem = cmd.ExecuteScalar().ToString();
                    }

                    // Varre a lista de números inteiros instânciada nessa função
                    foreach (int idContato in idsContatos)
                    {
                        // Recebe o nome e telefone do contato através do ID
                        string contatoQuery = "SELECT nome, telefone FROM contatos_underchat WHERE id = @idContato";
                        string nomeContato = null;
                        string telefone = null;
                        using (MySqlCommand cmd = new MySqlCommand(contatoQuery, bdConn))
                        {
                            cmd.Parameters.AddWithValue("@idContato", idContato);
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    nomeContato = reader["nome"].ToString();
                                    telefone = reader["telefone"].ToString();
                                }
                            }
                        }

                        // Atualiza os registros na tabela envio_mensagens com os dados obtidos nessa função
                        // Após isso, fecha o formulário para evitar registros duplicados
                        string updateQuery = "UPDATE envio_mensagens SET Mensagem = @mensagem, Imagem = @imagem, Nome_Contato = @nomeContato, Telefone = @telefone WHERE id_contato = @idContato AND id_mensagem = @idMensagem AND data_envio = @dataEnvio";
                        using (MySqlCommand cmd = new MySqlCommand(updateQuery, bdConn))
                        {
                            cmd.Parameters.AddWithValue("@mensagem", mensagem);
                            cmd.Parameters.AddWithValue("@imagem", imagem);
                            cmd.Parameters.AddWithValue("@nomeContato", nomeContato);
                            cmd.Parameters.AddWithValue("@telefone", telefone);
                            cmd.Parameters.AddWithValue("@idContato", idContato);
                            cmd.Parameters.AddWithValue("@idMensagem", idMensagem);
                            cmd.Parameters.AddWithValue("@dataEnvio", dataSelecionada);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Mensagens agendadas com sucesso!");
                }
            }
        }

        private void boxIdMensagem_DropDown_1(object sender, EventArgs e)
        {
            // Utiliza a classe MensagemItem para receber os dados da tabela cadastro_mensagens e exiibir no ComboBox
            using (bdConn = operacoesBD.AbrirConexao(server, user, senha, banco))
            {
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
            }

        }

        private void MensagensTabControl_Load(object sender, EventArgs e)
        {
            try
            {
                using (bdConn = operacoesBD.AbrirConexao(server, user, senha, banco))
                {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar contatos: {ex.Message}");
            }
        }
        
    }
}
