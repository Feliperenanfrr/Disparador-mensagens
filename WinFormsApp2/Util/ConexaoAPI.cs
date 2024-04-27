using Newtonsoft.Json;
using PhoneNumbers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gweb.WhatsApp.Util
{
    internal class ConexaoAPI
    {
        public string ObterToken(string email, string senha)
        {
            var client = new RestClient("https://api.underchat.com.br/");
            var request = new RestRequest("/user/auth", Method.POST);

            //string email = textEmail.Text;
            //string senha = textSenha.Text;

            var login = new
            {
                username = email,
                password = senha
            };

            request.AddJsonBody(login);

            IRestResponse response = client.Execute(request);

            if (response.ErrorException != null)
            {
                //MessageBox.Show($"Erro ao fazer a solicitação: {response.ErrorException.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            else
            {
                dynamic responseObject = JsonConvert.DeserializeObject<dynamic>(response.Content);
                string token = responseObject.data.token;

                return token;
            }
        }

        public dynamic BuscarContatoPorNumero(string idLoja, string numero, string token, int tentativas = 0)
        {
            var client = new RestClient("https://api.underchat.com.br/");
            var request = new RestRequest($"/store/{idLoja}/contact", Method.GET);
            request.AddParameter("filter[value]", numero);
            request.AddParameter("fields", "id,status,value");
            request.AddHeader("Authorization", "Bearer " + token);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content);
                var contato = data[0];
                if (contato != null) return contato;
            }

            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            var numeroBrasil = phoneNumberUtil.Parse(numero, "BR");

            if (phoneNumberUtil.IsValidNumber(numeroBrasil) && tentativas == 0)
            {
                var isBrazilianNumber = phoneNumberUtil.IsPossibleNumberWithReason(numeroBrasil);

                if (isBrazilianNumber == PhoneNumberUtil.ValidationResult.IS_POSSIBLE)
                {
                    var semNoveDigitos = phoneNumberUtil.Format(numeroBrasil, PhoneNumberFormat.RFC3966);
                    semNoveDigitos = semNoveDigitos.Replace("tel:", "");
                    return BuscarContatoPorNumero(idLoja, semNoveDigitos, token, 1);
                }
                else
                {
                    var comNoveDigitos = phoneNumberUtil.Format(numeroBrasil, PhoneNumberFormat.RFC3966);
                    comNoveDigitos = comNoveDigitos.Replace("tel:", "");
                    return BuscarContatoPorNumero(idLoja, comNoveDigitos, token, 1);
                }
            }

            return null;
        }

        public static dynamic BuscarContatoPorId(string idLoja, string id, string token)
        {
            var client = new RestClient("https://api.example.com");
            var request = new RestRequest($"/store/{idLoja}/contact", Method.GET);
            request.AddParameter("filter[id]", id);
            request.AddParameter("fields", "id,status,value");
            request.AddHeader("Authorization", "Bearer " + token);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content);
                var contato = data[0];
                return contato;
            }

            return null;
        }

        public static void VerificaSeContatoFoiValidado(string idLoja, string idContato, string token, int tentativas = 1)
        {
            //Console.WriteLine($"[{DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss")}] Verificando se o contato já foi validado ({tentativas}º Tentativa)...");

            dynamic contato = BuscarContatoPorId(idLoja, idContato, token);
            bool isValidated = contato != null && contato.status == "VALIDATED";

            if (!isValidated)
            {
                if (tentativas < 10)
                {
                    Thread.Sleep(1000); // Aguarda 1 segundo antes de tentar novamente
                    VerificaSeContatoFoiValidado(idLoja, idContato, token, tentativas + 1);
                }
                else
                {
                    throw new Exception("O contato não foi validado, tente novamente mais tarde.");
                }
            }
        }



    }
}
