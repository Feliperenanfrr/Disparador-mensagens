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


namespace WinFormsApp2
{
    public partial class FormUnderChat : Form
    {
        private MySqlConnection bdConn; //MySQL
        private MySqlDataAdapter bdAdapter;
        private DataSet bdDataSet; //MySQL
        private string CNPJ;


        ConexaoAPI xonexaoAPI = new ConexaoAPI();

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

            }

            bdConn.Close();
            tmMonitora.Enabled = true;
        }

        private void tmMonitora_Tick(object sender, EventArgs e)
        {

            bdConn.Open();
            MySqlCommand cmd = new MySqlCommand($"Select * from gueppardo.mensagem where Enviada = 0 and CNPJ = '{CNPJ}'", bdConn);
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

                //string sMens = Encoding.UTF8.GetString(Encoding.Default.GetBytes(reader["Mensagem"].ToString()));

                bdConn.Close();

                //Console.WriteLine(reader["CNPJ"].ToString());
                if (sFoto == "")
                {
                    EnviaMensagem(sMens, sTipo, sFone, sCodigo);
                }

                if (sFoto != "")
                {
                    if (sTipo == "cliente_pdf_cupom")
                    {
                        EnviaMensagemPDF(sMens, sTipo, sFone, sCodigo, sFoto);

                    }

                    else if (sTipo != "cliente_pdf_cupom")
                    {

                        EnviaMensagemImagem(sMens, sTipo, sFone, sCodigo, sFoto);

                    }

                }

                //Saindo do While
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
            ConexaoAPI conexaoAPI = new ConexaoAPI();

            string email = textEmail.Text;
            string senha = textSenha.Text;
            dynamic token = conexaoAPI.ObterToken(email, senha);

            string idLoja = textIdLoja.Text;
            //string idSetor = textIdSetor.Text;
            int idSetor = 4389;
            string idCanal = textIdCanal.Text;
            string numero = textContatoNumero.Text;

            string mensagem = textMensagem.Text;

            string respostaAPI = conexaoAPI.buscarContatoPorNumero(idLoja, numero, token);

            Root listaDeContatos = JsonConvert.DeserializeObject<Root>(respostaAPI);

            Contato contato = listaDeContatos.data[0];

            foreach(Contato item in listaDeContatos.data) {
                textTeste.Text = item.ToString();
            }

            //string teste = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOjQwMTcsInBlcnNvbiI6eyJpZCI6OTMyMzA0LCJpZ25vcmVBdXRvbWF0aW9uIjpmYWxzZSwiaWdub3JlQ29udmVyc2F0aW9uIjpmYWxzZSwiY29kZSI6bnVsbCwicGljdHVyZSI6bnVsbCwicGljdHVyZVRhZyI6bnVsbCwibmFtZSI6IkZlbGlwZSBSZW5hbiIsImZpcnN0TmFtZSI6IkZlbGlwZSIsImxhc3ROYW1lIjoiUmVuYW4iLCJhbGlhcyI6IiIsImVtYWlsIjoiZmVsaXBlZmVycmVpcmEzMTQ2QGdtYWlsLmNvbSIsIm5vdGUiOm51bGwsImlzRW1haWxWYWxpZGF0ZWQiOmZhbHNlLCJpc1Bob25lVmFsaWRhdGVkIjpmYWxzZSwiaXNEb2N1bWVudFZhbGlkYXRlZCI6ZmFsc2UsImRvY1R5cGUiOm51bGwsImRvY051bWJlciI6bnVsbCwicGhvbmUiOm51bGwsImJpcnRoZGF5IjpudWxsLCJnZW5kZXIiOm51bGwsIm1hcml0YWxTdGF0dXMiOm51bGwsInBlcnNvblR5cGUiOiJTVEFOREFSRCIsImNyZWF0ZWRBdCI6IjIwMjQtMDMtMjVUMTQ6MzE6MzIuNDkwWiIsInVwZGF0ZWRBdCI6IjIwMjQtMDMtMjVUMTQ6MzI6MDEuMDAwWiIsImRlbGV0ZWRBdCI6bnVsbH0sIm5hbWUiOiJGZWxpcGUgUmVuYW4iLCJ1c2VybmFtZSI6ImZlbGlwZV9yZW5hbl8yMDM3Iiwicm9sZXMiOlsiUk9MRV9VU0VSIl0sInBlcm1pc3Npb25zIjpbIkFUVEVOREFOVDpMSVNUIiwiQ0hBTk5FTDpMSVNUIiwiQ09ORklHOkxJU1QiLCJDT05WRVJTQVRJT046Q0hBTkdFX1RBRyIsIkNPTlZFUlNBVElPTjpDUkVBVEUiLCJDT05WRVJTQVRJT046REVMRVRFX01FU1NBR0UiLCJDT05WRVJTQVRJT046RklOSVNIIiwiQ09OVkVSU0FUSU9OOkdFVF9MSVNUIiwiQ09OVkVSU0FUSU9OOkdFVF9QQVNUIiwiQ09OVkVSU0FUSU9OOkpPSU4iLCJDT05WRVJTQVRJT046TEVBVkUiLCJDT05WRVJTQVRJT046TUVOVSIsIkNPTlZFUlNBVElPTjpQUklWQVRFIiwiQ09OVkVSU0FUSU9OOlJFRElSRUNUIiwiQ09OVkVSU0FUSU9OOlJFVFJZX01FU1NBR0UiLCJDT05WRVJTQVRJT046U0VORF9NRVNTQUdFIiwiQ09OVkVSU0FUSU9OOlZJRVdfSU5fQk9UIiwiQ09OVkVSU0FUSU9OOlZJRVdfUEVORElORyIsIkdST1VQOkxJU1QiLCJNRVNTQUdFX0RBVEFCQVNFOkxJU1QiLCJNRVNTQUdFX0RBVEFCQVNFOk1FTlUiLCJQRVJTT046Q1JFQVRFIiwiUEVSU09OOkRFTEVURSIsIlBFUlNPTjpMSVNUIiwiUEVSU09OOk1FTlUiLCJQRVJTT046VVBEQVRFIiwiU0VDVE9SOkxJU1QiLCJUQUc6TElTVCIsIlRBRzpNRU5VIiwiVVNFUjpHRVRfU0VMRiIsIlVTRVI6VVBEQVRFX1BBU1NXT1JEIiwiVVNFUjpVUERBVEVfUFJPRklMRSIsIkNPTkZJRzpVUERBVEUiLCJSRVBPUlQ6VklFVyIsIkNPTlZFUlNBVElPTjpWSUVXX0FMTF9TRUNUT1IiLCJDT05WRVJTQVRJT046VklFV19BTExfQVRURU5EQU5UUyIsIlBFUlNPTjpFWFBPUlQiLCJQRVJTT046REVMRVRFX0FMTCIsIlBFUlNPTjpWQUxJREFURSIsIklOVk9JQ0U6TUVOVSIsIklOVk9JQ0U6Q1JFQVRFIiwiSU5WT0lDRTpDSEVDS09VVCIsIklOVk9JQ0U6Q0FOQ0VMIiwiSU5WT0lDRTpMSVNUIiwiR1JPVVA6TUVOVSIsIkdST1VQOkNSRUFURSIsIkdST1VQOlVQREFURSIsIkdST1VQOkRFTEVURSIsIlRBRzpDUkVBVEUiLCJUQUc6VVBEQVRFIiwiVEFHOkRFTEVURSIsIkFUVEVOREFOVDpNRU5VIiwiQVRURU5EQU5UOkNSRUFURSIsIkFUVEVOREFOVDpVUERBVEUiLCJBVFRFTkRBTlQ6REVMRVRFIiwiQVRURU5EQU5UOlRJTUVfVEFCTEUiLCJTRUNUT1I6TUVOVSIsIlNFQ1RPUjpDUkVBVEUiLCJTRUNUT1I6VVBEQVRFIiwiU0VDVE9SOkRFTEVURSIsIkNIQU5ORUw6TUVOVSIsIkNIQU5ORUw6Q1JFQVRFIiwiQ0hBTk5FTDpVUERBVEUiLCJDSEFOTkVMOkRFTEVURSIsIkNIQU5ORUw6UkVGUkVTSCIsIkNIQU5ORUw6RElTQ09OTkVDVCIsIk1FU1NBR0VfREFUQUJBU0U6Q1JFQVRFIiwiTUVTU0FHRV9EQVRBQkFTRTpVUERBVEUiLCJNRVNTQUdFX0RBVEFCQVNFOkRFTEVURSIsIkNIQVRfQk9UOk1FTlUiLCJDSEFUX0JPVDpCQUNLVVBfRVhQT1JUIiwiQ0hBVF9CT1Q6QkFDS1VQX0lNUE9SVCIsIkNIQVRfQk9UOkJBQ0tVUF9FWEVDVVRFIiwiQ0hBVF9CT1Q6QkFDS1VQX0RFTEVURSIsIkNIQVRfQk9UOkJBQ0tVUF9HRVQiLCJDSEFUX0JPVDpCQUNLVVBfTElTVCIsIkNIQVRfQk9UOkNSRUFURSIsIkNIQVRfQk9UOlVQREFURSIsIkNIQVRfQk9UOkRFTEVURSIsIkNIQVRfQk9UOkxJU1QiLCJTQ0hFRFVMRTpNRU5VIiwiU0NIRURVTEU6Q1JFQVRFIiwiU0NIRURVTEU6VVBEQVRFIiwiU0NIRURVTEU6REVMRVRFIiwiU0NIRURVTEU6TElTVCIsIlNDSEVEVUxFOlNUQVRVUyIsIlNDSEVEVUxFOlJFVFJZIl0sImlhdCI6MTcxNDUwNTg1MCwiZXhwIjoxNzE1MTEwNjUwfQ.uGVu6RSNcuCy5dxi0Ad45Nr7mzhy1xjaAMzdt6FhvyA";

            int idAtendimento = conexaoAPI.criarAtendimento(idLoja, contato, idSetor, idCanal, mensagem, token);




        }


    }

}