using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PhoneNumbers;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Gweb.WhatsApp.Util.Atendimento;

namespace Gweb.WhatsApp.Util
{
    internal class ConexaoAPI
    {
        public string ObterToken(string email, string senha)
        {
            //Monta corpo da requisição
            var client = new RestClient("https://api.underchat.com.br/");
            var request = new RestRequest("/user/auth", Method.POST);

            //Adiciona credenciais de login ao corpo da requisição
            var login = new
            {
                username = email,
                password = senha
            };
            request.AddJsonBody(login);

            //Executa requisição
            IRestResponse response = client.Execute(request);

            if (response.ErrorException != null)
            {
                return null;
            }
            else
            {
                dynamic responseObject = JsonConvert.DeserializeObject<dynamic>(response.Content);
                string token = responseObject.data.token;
                return token;
            }
        }

        public dynamic buscarContatoPorNumero(string idLoja, string numero, string token, int tentativas = 0)
        {
            //Monta e executa corpo da requisição
            var client = new RestClient("https://api.underchat.com.br/");
            var request = new RestRequest($"/store/{idLoja}/contact", Method.GET);
            request.AddParameter("filter[value]", numero);
            request.AddParameter("fields", "id,status,value");
            request.AddHeader("Authorization", "Bearer " + token);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                string contato = response.Content;

                return contato;
            }

            //Faz a validação do número de telefone e converte para o padrão BR
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            var numeroBrasil = phoneNumberUtil.Parse(numero, "BR");

            if (phoneNumberUtil.IsValidNumber(numeroBrasil) && tentativas == 0)
            {
                var isBrazilianNumber = phoneNumberUtil.IsPossibleNumberWithReason(numeroBrasil);

                if (isBrazilianNumber == PhoneNumberUtil.ValidationResult.IS_POSSIBLE)
                {
                    var semNoveDigitos = phoneNumberUtil.Format(numeroBrasil, PhoneNumberFormat.RFC3966);
                    semNoveDigitos = semNoveDigitos.Replace("tel:", "");
                    return buscarContatoPorNumero(idLoja, semNoveDigitos, token, 1);
                }
                else
                {
                    var comNoveDigitos = phoneNumberUtil.Format(numeroBrasil, PhoneNumberFormat.RFC3966);
                    comNoveDigitos = comNoveDigitos.Replace("tel:", "");
                    return buscarContatoPorNumero(idLoja, comNoveDigitos, token, 1);
                }
            }

            return null;
        }

        public static dynamic BuscarContatoPorId(string idLoja, string id, string token)
        {
            //Busca contato pelo ID e tenta retornar, caso o numero não seja encontrado retorna nulo
            var client = new RestClient("https://api.example.com");
            var request = new RestRequest($"/store/{idLoja}/contact", Method.GET);
            request.AddParameter("filter[id]", id);
            request.AddParameter("fields", "id,status,value");
            request.AddHeader("Authorization", "Bearer " + token);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var contato = response.Content;
                if (contato != null) return contato;
            }

            return null;
        }

        public static void VerificaSeContatoFoiValidado(string idLoja, string idContato, string token, int tentativas = 1)
        {
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

        public int criarAtendimento(string idLoja, Contato contato, dynamic idSetor, string idCanal, string mensagem, string token)
        {
            var client = new RestClient("https://api.underchat.com.br/");
            var request = new RestRequest($"/store/{idLoja}/conversation/new", Method.POST);

            var body = new
            {
                contact = contato.id,
                sector = idSetor,
                channel = idCanal
            };

            request.AddJsonBody(body);
            request.AddHeader("Authorization", "Bearer " + token);

            IRestResponse response = client.Execute(request);

            int idAtendimento = 0;

            if (response.IsSuccessful)
            {
                dynamic dadosDaResposta = JsonConvert.DeserializeObject<dynamic>(response.Content);
                idAtendimento = dadosDaResposta.data.id;


            }
            else
            {
                Atendimento.RootAtendimento dadosDaResposta = JsonConvert.DeserializeObject<Atendimento.RootAtendimento>(response.Content);
                idAtendimento = dadosDaResposta.meta;

                finalizarAtendimento(idLoja, idAtendimento, token);

            }

            return idAtendimento;

        }

        public void enviarMensagem(string mensagem, string idLoja, int idAtendimento, string token)
        {
            var client = new RestClient("https://api.underchat.com.br/");
            var request = new RestRequest($"/store/{idLoja}/conversation/{idAtendimento}/message", Method.POST);

            var body = new
            {
                message = mensagem
            };

            request.AddJsonBody(body);
            request.AddHeader("Authorization", "Bearer " + token);

            IRestResponse response = client.Execute(request);

        }

        public void finalizarAtendimento(string idLoja, int idAtendimento, string token)
        {
            var client = new RestClient("https://api.underchat.com.br/");
            var request = new RestRequest($"/store/${idLoja}/conversation/${idAtendimento}/finish", Method.POST);

            var body = new
            {
                sendFinishMessage = false
            };

            request.AddJsonBody(body);
            request.AddHeader("Authorization", "Bearer " + token);

            IRestResponse response = client.Execute(request);

        }

        public void enviarMensagemComImagem(string mensagem, string idLoja, int idAtendimento, string imageUrl, string token)
        {
            try
            {
                Console.WriteLine("Enviando mensagem com imagem...");

                // Baixar o conteúdo da imagem
                WebClient webClient = new WebClient();
                byte[] imageBytes = webClient.DownloadData(imageUrl);

                // Salvar a imagem em um arquivo temporário
                string tempDir = Path.GetTempPath();
                string tempFilePath = Path.Combine(tempDir, "image.jpg");
                File.WriteAllBytes(tempFilePath, imageBytes);

                // Criar um objeto para representar o arquivo no disco
                var client = new RestClient("https://api.underchat.com.br/");
                RestRequest request = new RestRequest($"/store/{idLoja}/conversation/{idAtendimento}/message", Method.POST);
                request.AddFile("file", tempFilePath);
                request.AddParameter("message", mensagem);

                // Adicionar o token de autorização ao cabeçalho da requisição
                request.AddHeader("Authorization", "Bearer " + token);

                // Enviar a requisição
                IRestResponse response = client.Execute(request);

                if (response.IsSuccessful)
                {
                    Console.WriteLine("Mensagem com imagem enviada com sucesso!");
                }
                else
                {
                    Console.WriteLine($"Ocorreu um erro ao enviar a mensagem com imagem. ERR: {response.ErrorMessage}");
                }

                // Remover o arquivo temporário depois de usar
                File.Delete(tempFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO ao enviar mensagem com imagem: {ex.Message}");
            }
        }

        public RootContato BuscarTodosContatos(string idLoja, string token)
        {
            var client = new RestClient("https://api.underchat.com.br/");
            var request = new RestRequest($"/store/{idLoja}/contact", Method.GET);
            request.AddHeader("Authorization", "Bearer " + token);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                string contato = response.Content;
                RootContato ListaDeContatos = JsonConvert.DeserializeObject<RootContato>(contato);
                if (contato != null) return ListaDeContatos;
            }

            return null;
        }


    }
}
