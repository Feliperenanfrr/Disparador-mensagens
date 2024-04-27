using Newtonsoft.Json;
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
        public string obterToken(string email, string senha)
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
                MessageBox.Show($"Erro ao fazer a solicitação: {response.ErrorException.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            else
            {
                dynamic responseObject = JsonConvert.DeserializeObject<dynamic>(response.Content);
                string token = responseObject.data.token;

                return token;
            }
        }

    }
}
