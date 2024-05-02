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
            //imgFoto.ImageLocation = txtImagem.Text;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new RestClient(txtLink.Text);
            var txt = new string(textMensagem.Text);

            client.Timeout = -1;

            var request = new RestRequest(Method.POST);

            request.AddHeader("Authorization", txtChave.Text);

            request.AddHeader("Content-Type", "application/json");

            var body = "{ \r\n\n\"messaging_product\":\"whatsapp\",\r\n\n \"to\": \"" + txtFone.Text + "\", \r\n\n\"type\": \"text\",\r\n\n\"text\": {\r\n\n\"body\":\"" + txt + "\"\r\n\n}\r\n\n}";

            request.AddParameter("application/json", body, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            Console.WriteLine(response.Content);

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

            // Aqui é pego a chave o link da api para enviar mensagem, traga isso para o UC
            /*
            while (reader.Read())
            {
                txtLink.Text = reader["Link"].ToString();
                txtChave.Text = reader["Chave"].ToString();
            }

            if (txtChave.Text == "")
            {
                var result = MessageBox.Show("Não existe um CNPJ cadastrado no site de controle Gueppardo.Net!", "ERRO!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                Close();

            }*/

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
            var sIdSetor = dadosLoja["IdSetor"].ToString();

            bdConn.Close();

            bdConn.Open();
            MySqlCommand cmd = new MySqlCommand($"Select * from gueppardo.mensagem_testes where Enviada = 0 and CNPJ = '{CNPJ}' and API = 1", bdConn);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

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

                Root listaDeContatos = JsonConvert.DeserializeObject<Root>(respostaAPI);

                Contato contato = listaDeContatos.data[0];

                /*foreach (Contato item in listaDeContatos.data)
                {
                    textTeste.Text = item.ToString();
                }*/

                int idAtendimento = conexaoAPI.criarAtendimento(sIdLoja, contato, sIdSetor, sIdCanal, sMens, token);

                conexaoAPI.enviarMensagem(sMens, sIdLoja, idAtendimento, token);

                textTeste.Text = textTeste.Text + " ";
                textTeste.Text = textTeste.Text + $"Mensagem: Código: {sCodigo} - Número: {sFone} - Tipo: {sTipo}";

                bdConn.Open();
                MySqlCommand cmd2 = new MySqlCommand($"Update gueppardo.mensagem_testes set Enviada = 1 where Codigo = {sCodigo} and CNPJ = {CNPJ}", bdConn);
                cmd2.ExecuteNonQuery();
                bdConn.Close();

                return;

            }

            bdConn.Close();

        }

        private void EnviaMensagem(string sMens, string sTipo, string sFone, string sCodigo)
        {

            var client = new RestClient(txtLink.Text);
            var txt = new string(sMens);

            client.Timeout = -1;

            var request = new RestRequest(Method.POST);

            request.AddHeader("Authorization", txtChave.Text);

            request.AddHeader("Content-Type", "application/json");

            var body = "{\r\n\n\"messaging_product\":\"whatsapp\",\r\n\n\"to\":\"" + sFone + "\", \r\n\n\"type\":\"template\",\r\n\n\"template\":{\r\n\n\"name\":\"" + sTipo + "\",\r\n\n\"language\": { \r\n\n\"code\":\"en_US\" \r\n\n},\r\n\n\r\n\n\"components\": [\r\n\n{\r\n\n\"type\": \"body\",\r\n\n\"parameters\": [\r\n\n{\r\n\n\"type\": \"text\",\r\n\n\"text\":\"" + txt + "\"\r\n\n}\r\n\n]\r\n\n}\r\n\n]\r\n\n}\r\n\n}";

            request.AddParameter("application/json", body, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            textTeste.Text = response.Content + textTeste.Text;

            Console.WriteLine(response.Content);

            //Grava como Enviado
            bdConn.Open();
            MySqlCommand cmd2 = new MySqlCommand("Update gueppardo.mensagem set Enviada = 1, Retorno = '" + response.StatusDescription + "' where Codigo = " + sCodigo + " and CNPJ = '" + CNPJ + "'", bdConn);
            cmd2.ExecuteNonQuery();
            bdConn.Close();

        }

        private void EnviaMensagemImagem(string sMens, string sTipo, string sFone, string sCodigo, string sFoto)
        {

            var client = new RestClient(txtLink.Text);
            var txt = new string(sMens);

            client.Timeout = -1;

            var request = new RestRequest(Method.POST);

            request.AddHeader("Authorization", txtChave.Text);

            request.AddHeader("Content-Type", "application/json");

            var body = @"{
                " + "\n" +
                @"""messaging_product"": ""whatsapp"", 
                " + "\n" +
                @"""to"": ""TELEFONE"", 
                " + "\n" +
                @"""type"": ""template"", 
                " + "\n" +
                @"""template"": { 
                " + "\n" +
                @"    ""name"": ""cliente_imagem_full"",
                " + "\n" +
                @"    ""language"": { 
                " + "\n" +
                @"        ""code"": ""en_US"" 
                " + "\n" +
                @"    },
                " + "\n" +
                @"
                " + "\n" +
                @"""components"": [
                " + "\n" +
                @"
                " + "\n" +
                @"            {
                " + "\n" +
                @"                ""type"": ""header"",
                " + "\n" +
                @"                ""parameters"": [
                " + "\n" +
                @"                    {
                " + "\n" +
                @"                        ""type"": ""image"",
                " + "\n" +
                @"                        ""image"": {
                " + "\n" +
                @"                          ""link"" : ""FOTO""
                " + "\n" +
                @"                        }
                " + "\n" +
                @"                    }
                " + "\n" +
                @"                ]
                " + "\n" +
                @"            },
                " + "\n" +
                @"    {
                " + "\n" +
                @"        ""type"": ""body"",
                " + "\n" +
                @"        ""parameters"": [
                " + "\n" +
                @"            {
                " + "\n" +
                @"                ""type"": ""text"",
                " + "\n" +
                @"                ""text"": ""MENSAGEM""
                " + "\n" +
                @"            }
                " + "\n" +
                @"        ]
                " + "\n" +
                @"    }
                " + "\n" +
                @"]
                " + "\n" +
                @"}
                " + "\n" +
                @"}";

            body = body.Replace("MENSAGEM", sMens);
            body = body.Replace("TELEFONE", sFone);
            body = body.Replace("FOTO", sFoto);

            request.AddParameter("application/json", body, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            textTeste.Text = response.Content + textTeste.Text;

            Console.WriteLine(response.Content);

            //Grava como Enviado
            bdConn.Open();
            MySqlCommand cmd2 = new MySqlCommand("Update gueppardo.mensagem set Enviada = 1, Retorno = '" + response.StatusDescription + "' where Codigo = " + sCodigo + " and CNPJ = '" + CNPJ + "'", bdConn);
            cmd2.ExecuteNonQuery();
            bdConn.Close();

        }

        private void EnviaMensagemPDF(string sMens, string sTipo, string sFone, string sCodigo, string sFoto)
        {

            var client = new RestClient(txtLink.Text);
            var txt = new string(sMens);

            client.Timeout = -1;

            var request = new RestRequest(Method.POST);

            request.AddHeader("Authorization", txtChave.Text);

            request.AddHeader("Content-Type", "application/json");

            var body = @"{
                " + "\n" +
                @"""messaging_product"": ""whatsapp"", 
                " + "\n" +
                @"""to"": ""TELEFONE"", 
                " + "\n" +
                @"""type"": ""template"", 
                " + "\n" +
                @"""template"": { 
                " + "\n" +
                @"    ""name"": ""cliente_pdf_cupom"",
                " + "\n" +
                @"    ""language"": { 
                " + "\n" +
                @"        ""code"": ""en_US"" 
                " + "\n" +
                @"    },
                " + "\n" +
                @"
                " + "\n" +
                @"""components"": [
                " + "\n" +
                @"
                " + "\n" +
                @"            {
                " + "\n" +
                @"                ""type"": ""header"",
                " + "\n" +
                @"                ""parameters"": [
                " + "\n" +
                @"                    {
                " + "\n" +
                @"                        ""type"": ""document"",
                " + "\n" +
                @"                        ""document"": {
                " + "\n" +
                @"                          ""link"" : ""FOTO"",
                " + "\n" +
                @"                          ""filename"" : ""Cupom""
                " + "\n" +
                @"                        }
                " + "\n" +
                @"                    }
                " + "\n" +
                @"                ]
                " + "\n" +
                @"            },
                " + "\n" +
                @"    {
                " + "\n" +
                @"        ""type"": ""body"",
                " + "\n" +
                @"        ""parameters"": [
                " + "\n" +
                @"            {
                " + "\n" +
                @"                ""type"": ""text"",
                " + "\n" +
                @"                ""text"": ""MENSAGEM""
                " + "\n" +
                @"            }
                " + "\n" +
                @"        ]
                " + "\n" +
                @"    }
                " + "\n" +
                @"]
                " + "\n" +
                @"}
                " + "\n" +
                @"}";

            body = body.Replace("MENSAGEM", sMens);
            body = body.Replace("TELEFONE", sFone);
            body = body.Replace("FOTO", sFoto);

            request.AddParameter("application/json", body, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            textTeste.Text = response.Content + textTeste.Text;

            Console.WriteLine(response.Content);

            //Grava como Enviado
            bdConn.Open();
            MySqlCommand cmd2 = new MySqlCommand("Update gueppardo.mensagem set Enviada = 1, Retorno = '" + response.StatusDescription + "' where Codigo = " + sCodigo + " and CNPJ = '" + CNPJ + "'", bdConn);
            cmd2.ExecuteNonQuery();
            bdConn.Close();

        }


        private void btnEnvia2_Click(object sender, EventArgs e)
        {

            var client = new RestClient(txtLink.Text);
            var txt = new string(txtEmpresa.Text);

            client.Timeout = -1;

            var request = new RestRequest(Method.POST);

            request.AddHeader("Authorization", txtChave.Text);

            request.AddHeader("Content-Type", "application/json");

            var body = "{\r\n\n\"messaging_product\":\"whatsapp\",\r\n\n\"to\":\"" + txtFone.Text + "\", \r\n\n\"type\":\"template\",\r\n\n\"template\":{\r\n\n\"name\":\"cliente_compra\",\r\n\n\"language\": { \r\n\n\"code\":\"en_US\" \r\n\n},\r\n\n\r\n\n\"components\": [\r\n\n{\r\n\n\"type\": \"body\",\r\n\n\"parameters\": [\r\n\n{\r\n\n\"type\": \"text\",\r\n\n\"text\":\"" + txt + "\"\r\n\n}\r\n\n]\r\n\n}\r\n\n]\r\n\n}\r\n\n}";

            request.AddParameter("application/json", body, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            Console.WriteLine(response.Content);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var client = new RestClient(txtLink.Text);
            var txt = new string(txtEmpresa.Text);

            client.Timeout = -1;

            var request = new RestRequest(Method.POST);

            request.AddHeader("Authorization", txtChave.Text);

            request.AddHeader("Content-Type", "application/json");


            var body = @"{
                " + "\n" +
                @"""messaging_product"": ""whatsapp"", 
                " + "\n" +
                @"""to"": ""TELEFONE"", 
                " + "\n" +
                @"""type"": ""template"", 
                " + "\n" +
                @"""template"": { 
                " + "\n" +
                @"    ""name"": ""cliente_imagem"",
                " + "\n" +
                @"    ""language"": { 
                " + "\n" +
                @"        ""code"": ""en_US"" 
                " + "\n" +
                @"    },
                " + "\n" +
                @"
                " + "\n" +
                @"""components"": [
                " + "\n" +
                @"
                " + "\n" +
                @"            {
                " + "\n" +
                @"                ""type"": ""header"",
                " + "\n" +
                @"                ""parameters"": [
                " + "\n" +
                @"                    {
                " + "\n" +
                @"                        ""type"": ""image"",
                " + "\n" +
                @"                        ""image"": {
                " + "\n" +
                @"                          ""link"" : ""FOTO""
                " + "\n" +
                @"                        }
                " + "\n" +
                @"                    }
                " + "\n" +
                @"                ]
                " + "\n" +
                @"            },
                " + "\n" +
                @"    {
                " + "\n" +
                @"        ""type"": ""body"",
                " + "\n" +
                @"        ""parameters"": [
                " + "\n" +
                @"            {
                " + "\n" +
                @"                ""type"": ""text"",
                " + "\n" +
                @"                ""text"": ""MENSAGEM""
                " + "\n" +
                @"            }
                " + "\n" +
                @"        ]
                " + "\n" +
                @"    }
                " + "\n" +
                @"]
                " + "\n" +
                @"}
                " + "\n" +
                @"}";

            body = body.Replace("MENSAGEM", textMensagem.Text);
            body = body.Replace("TELEFONE", txtFone.Text);
            body = body.Replace("FOTO", txtImagem.Text);


            request.AddParameter("application/json", body, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            Console.WriteLine(response.Content);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonEnviarMensagem_Click(object sender, EventArgs e)
        {
            string email = textEmail.Text;
            string senha = textSenha.Text;
            string idLoja = textIdLoja.Text;
            string idCanal = textIdCanal.Text;
            string numero = textContatoNumero.Text;
            string mensagem = textMensagem.Text;
            string idSetor = textIdSetor.Text;

            ConexaoAPI conexaoAPI = new ConexaoAPI();

            dynamic token = conexaoAPI.ObterToken(email, senha);

            string respostaAPI = conexaoAPI.buscarContatoPorNumero(idLoja, numero, token);

            Root listaDeContatos = JsonConvert.DeserializeObject<Root>(respostaAPI);

            Contato contato = listaDeContatos.data[0];

            foreach(Contato item in listaDeContatos.data) {
                textTeste.Text = item.ToString();
            }

            int idAtendimento = conexaoAPI.criarAtendimento(idLoja, contato, idSetor, idCanal, mensagem, token);

            conexaoAPI.enviarMensagem(mensagem, idLoja, idAtendimento, token);
        }


    }

}