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

            XmlDocument document = new XmlDocument();
            document.Load("Config.Xml");
            XmlNodeList livros = document.SelectNodes("/geral/empresa/CNPJ");
            CNPJ = livros.Item(0).InnerText;

            if (CNPJ == "")
            {
                var result = MessageBox.Show("Não existe um CNPJ Ativo!", "ERRO!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                Close();

            }

            FormUnderChat.ActiveForm.Text = "Monitorador UnderChat - CNPJ:" + CNPJ;

            if (btnAtivar.Text == "Desativar")
            {
                btnAtivar.Text = "Ativar";
                btnSair.Enabled = true;
                //btnEnvia.Enabled = true;
                //btnEnvia2.Enabled = true;
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
                //btnEnvia.Enabled = false;
                //btnEnvia2.Enabled = false;
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
                //btnEnvia.Enabled = false;
                //btnEnvia2.Enabled = false;

            }

            //Buscando Link e Chave e consulta CNPJ
            MySqlCommand cmd = new MySqlCommand("Select * from gueppardo.mensagem_uc where CNPJ = '" + CNPJ + "'", bdConn);
            MySqlDataReader reader = cmd.ExecuteReader();

            bdConn.Close();
            tmMonitora.Enabled = true;
        }

        private void tmMonitora_Tick(object sender, EventArgs e)
        {

            bdConn.Open();

            MySqlCommand consultaDadosLoja = new MySqlCommand($"Select * from gueppardo.mensagem_uc where CNPJ = '{CNPJ}' ", bdConn);
            MySqlDataReader dadosLoja = consultaDadosLoja.ExecuteReader();
            dadosLoja.Read();

            var sEmail = dadosLoja["Email"].ToString();
            var sSenha = dadosLoja["Senha"].ToString();
            var sIdLoja = dadosLoja["IdLoja"].ToString();
            var sIdCanal = dadosLoja["IdCanal"].ToString();
            var sIdSetor = dadosLoja["IdSetor"];

            bdConn.Close();

            bdConn.Open();
            MySqlCommand cmd = new MySqlCommand($"Select * from gueppardo.mensagem_testes where Enviada = 0 and CNPJ = '{CNPJ}' and API = 1", bdConn);
            MySqlDataReader reader = cmd.ExecuteReader();

            

            while (reader.Read())
            {

                //Captura Codigo
                var sCodigo = reader["Codigo"].ToString();
                var sMens = reader["Mensagem"].ToString();
                var sTipo = reader["TipoMensagem"].ToString();
                var sFone = reader["Fone"].ToString();
                var sFoto = reader["Foto"].ToString();
                var sCNPJ = reader["CNPJ"].ToString();

                bdConn.Close();

                ConexaoAPI conexaoAPI = new ConexaoAPI();
                dynamic token = conexaoAPI.ObterToken(sEmail, sSenha);

                string respostaAPI = conexaoAPI.buscarContatoPorNumero(sIdLoja, sFone, token);

                RootContato listaDeContatos = JsonConvert.DeserializeObject<RootContato>(respostaAPI);

                Contato contato = listaDeContatos.data[0];

                int idAtendimento = conexaoAPI.criarAtendimento(sIdLoja, contato, sIdSetor, sIdCanal, sMens, token);

                if (sFoto == "")
                {
                    conexaoAPI.enviarMensagem(sMens, sIdLoja, idAtendimento, token);
                }
                else
                {
                    conexaoAPI.enviarMensagemComImagem(sMens, sIdLoja, idAtendimento, sFoto ,token);
                }

                textTeste.Text = textTeste.Text + " ";
                textTeste.Text = textTeste.Text + $"Mensagem: Código: {sCodigo} - Número: {sFone} - Tipo: {sTipo}";

                bdConn.Open();
                MySqlCommand marcarComoEnviada = new MySqlCommand($"Update gueppardo.mensagem_testes set Enviada = 1 where Codigo = {sCodigo} and CNPJ = '{CNPJ}'", bdConn);
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

    }

}