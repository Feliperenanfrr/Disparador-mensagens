using System.Data;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Gweb.WhatsApp.Util;
using Gweb.WhatsApp.Forms;
using MaterialSkin.Controls;


namespace WinFormsApp2
{
    public partial class FormUnderChat : MaterialForm
    {
        private MySqlConnection bdConn; //MySQL
        private MySqlDataAdapter bdAdapter;
        private DataSet bdDataSet; //MySQL
        private string CNPJ;

        ConexaoAPI conexaoAPI;
        operacoesBD operacoesBD;

        public FormUnderChat()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAtivar_Click(object sender, EventArgs e)
        {
            if (btnAtivar.Text == "Desativar")
            {
                btnAtivar.Text = "Ativar";
                btnSair.Enabled = true;
                tmMonitora.Enabled = false;
                bdConn.Close();
                return;
            }

            var builder = new MySqlConnectionStringBuilder
            {
                Server = txtServer.Text,
                Database = "gueppardo",
                UserID = txtUsuario.Text,
                Password = txtSenha.Text,
                CharacterSet = "utf8"
            };

            bdDataSet = new DataSet();
            bdConn = new MySqlConnection(builder.ConnectionString);

            try
            {
                bdConn.Open();
                btnAtivar.Text = "Desativar";
                btnSair.Enabled = false;
                tmMonitora.Enabled = true;
            }
            catch
            {
                if (bdConn.State != ConnectionState.Open)
                {
                    MessageBox.Show("Impossível estabelecer uma conexão");
                    Close();
                }
                btnAtivar.Text = "Desativar";
                btnSair.Enabled = false;
            }
        }

        private void tmMonitora_Tick(object sender, EventArgs e)
        {
            if (bdConn.State != System.Data.ConnectionState.Open)
            {
                bdConn.Open();
            }

            var emailUnderChat = textEmail.Text;
            var senhaUnderChat = textSenha.Text;
            var idLojaUnderChat = textIdLoja.Text;
            var idCanalUnderChat = textIdCanal.Text;
            var idSetorUnderChat = int.Parse(textIdSetor.Text);

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM gueppardo.envio_mensagens WHERE envio = 0 AND data_envio <= NOW()", bdConn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                //Captura dados das mensagens retornadas pelo BD
                var idEnvioMensagem = reader["id"].ToString();
                var mensagem = reader["Mensagem"].ToString();
                var telefone = reader["telefone"].ToString();
                var imagem = reader["imagem"].ToString();
                var nomeContato = reader["Nome_contato"].ToString();

                // Utiliza a classe ConexaoApi criada na pasta Util para fazer requisições HTTP para a API do UnderChat
                // Utiliza a classe Contato criada na pasta Util para receber os dados retornados pela API
                // Utiliza a biblioteca Newtonsoft.Json para desserializar e manipular JSON
                conexaoAPI = new ConexaoAPI();
                dynamic token = conexaoAPI.ObterToken(emailUnderChat, senhaUnderChat);
                string respostaAPI = conexaoAPI.buscarContatoPorNumero(idLojaUnderChat, telefone, token);
                RootContato listaDeContatos = JsonConvert.DeserializeObject<RootContato>(respostaAPI);
                Contato contato = listaDeContatos.data[0];
                int idAtendimento = conexaoAPI.criarAtendimento(idLojaUnderChat, contato, idSetorUnderChat, idCanalUnderChat, mensagem, token);

                if (imagem == "")
                {
                    conexaoAPI.enviarMensagem(mensagem, idLojaUnderChat, idAtendimento, token);
                }
                else
                {
                    conexaoAPI.enviarMensagemComImagem(mensagem, idLojaUnderChat, idAtendimento, imagem, token);
                }

                reader.Close();

                // Insere os dados das mensagens enviadas em uma caixa de texto
                textMensagens.Clear();
                textMensagens.Text = textMensagens.Text + " ";
                textMensagens.Text = textMensagens.Text + $"Código: {idEnvioMensagem} - Número: {telefone} - Cliente: {nomeContato}";

                using (MySqlCommand marcarComoEnviada = new MySqlCommand("UPDATE gueppardo.envio_mensagens SET envio = 1 WHERE id = @idEnvioMensagem AND telefone = @telefone AND Nome_Contato = @nomeContato", bdConn))
                {
                    marcarComoEnviada.Parameters.AddWithValue("@idEnvioMensagem", idEnvioMensagem);
                    marcarComoEnviada.Parameters.AddWithValue("@telefone", telefone);
                    marcarComoEnviada.Parameters.AddWithValue("@nomeContato", nomeContato);
                    marcarComoEnviada.ExecuteNonQuery();
                }
                return;
            }
            bdConn.Close();
        }

        private void btnContatos_Click(object sender, EventArgs e)
        {
            ContatosTabControl contatosTabControl = new ContatosTabControl();
            contatosTabControl.Show();
        }
        
        private void btnMensagens_Click(object sender, EventArgs e)
        {
            MensagensTabControl mensagensTabControl = new MensagensTabControl();
            mensagensTabControl.Show();
            //GerenciarMensagens gerenciarMensagens = new GerenciarMensagens();
            //gerenciarMensagens.Show();
        }
    }

}