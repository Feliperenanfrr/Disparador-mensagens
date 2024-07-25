using RestSharp;
using System.Data;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Text;
using System;
using System.Xml;
using static System.Windows.Forms.LinkLabel;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Windows.Forms;
using Gweb.WhatsApp;
using Newtonsoft.Json;
using PhoneNumbers;
using Gweb.WhatsApp.Util;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Newtonsoft.Json.Linq;
using Gweb.WhatsApp.Forms;


namespace WinFormsApp2
{
    public partial class FormUnderChat : Form
    {
        private MySqlConnection bdConn; //MySQL
        private MySqlDataAdapter bdAdapter;
        private DataSet bdDataSet; //MySQL
        private string CNPJ;

        ConexaoAPI conexaoAPI = new ConexaoAPI();

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
                CharacterSet = "latin"
            };

            //Definição do dataset
            bdDataSet = new DataSet();
            //Define string de conexão
            bdConn = new MySqlConnection(builder.ConnectionString);

            //Abre conexão 1
            try
            {
                bdConn.Open();
                btnAtivar.Text = "Desativar";
                btnSair.Enabled = false;
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

            //Buscando Link e Chave e consulta CNPJ
            /*MySqlCommand cmd = new MySqlCommand("Select * from gueppardo.mensagem_uc where CNPJ = '" + CNPJ + "'", bdConn);
            MySqlDataReader reader = cmd.ExecuteReader();
            bdConn.Close();
            tmMonitora.Enabled = true;*/
        }

        private void tmMonitora_Tick(object sender, EventArgs e)
        {

            bdConn.Open();

            MySqlCommand consultaMensagensNaoEnviadas = new MySqlCommand($"Select * from gueppardo.envio_mensagens where envio = 0 ", bdConn);
            MySqlDataReader mensagemNaoEnviadas = consultaMensagensNaoEnviadas.ExecuteReader();
            mensagemNaoEnviadas.Read();

            var emailUnderChat = textEmail.Text;
            var senhaUnderChat = textSenha.Text;
            var idLojaUnderChat = textIdLoja.Text;
            var idCanalUnderChat = textIdCanal.Text;
            var idSetorUnderChat = textIdSetor.Text;

            bdConn.Close();

            bdConn.Open();
            MySqlCommand cmd = new MySqlCommand($"Select * from gueppardo.envio_mensagens where envio = 0", bdConn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                //Captura Código
                var idEnvioMensagem = reader["id"].ToString();
                var mensagem = reader["Mensagem"].ToString();
                var tipoMensagem = reader["tipo"].ToString();
                var telefone = reader["telefone"].ToString();
                var imagem = reader["Foto"].ToString();
                var nomeContato = reader["Nome"].ToString();

                bdConn.Close();

                ConexaoAPI conexaoAPI = new ConexaoAPI();
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

                textMensagens.Text = textMensagens.Text + " ";
                textMensagens.Text = textMensagens.Text + $"Código: {idEnvioMensagem} - Número: {telefone} - Clinete: {nomeContato}";
                bdConn.Open();
                MySqlCommand marcarComoEnviada = new MySqlCommand($"Update gueppardo.envio_mensagens set envio = 1 where Codigo = {idEnvioMensagem} and telefone = {telefone} and Nome_Contato = {nomeContato}", bdConn);
                marcarComoEnviada.ExecuteNonQuery();
                bdConn.Close();
                return;
            }

            bdConn.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormWhatsApp formWpp = new FormWhatsApp();
            formWpp.Show();
        }

        private void btnContatos_Click(object sender, EventArgs e)
        {
            GerenciarContato gerenciarContato = new GerenciarContato();
            gerenciarContato.Show();
        }

        private void FormUnderChat_Load(object sender, EventArgs e)
        {

        }

        private void btnMensagens_Click(object sender, EventArgs e)
        {
            GerenciarMensagens gerenciarMensagens = new GerenciarMensagens();
            gerenciarMensagens.Show();
        }
    }

}