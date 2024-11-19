using System.Data;
using Newtonsoft.Json;
using Gweb.WhatsApp.Util;
using Gweb.WhatsApp.Forms;
using MaterialSkin.Controls;
using Microsoft.EntityFrameworkCore;
using Gweb.WhatsApp.Dados;
using Gweb.WhatsApp.Entidades;

namespace WinFormsApp2
{
    public partial class FormUnderChat : MaterialForm
    {
        private MyDbContext _dbContext;
        ConexaoAPI conexaoAPI;

       

        public FormUnderChat()
        {
            InitializeComponent();
            _dbContext = new MyDbContext();
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
                return;
            }

            try
            {
                _dbContext.Database.OpenConnection();
                btnAtivar.Text = "Desativar";
                btnSair.Enabled = false;
                tmMonitora.Enabled = true;
            }
            catch
            {
                if (!_dbContext.Database.CanConnect())
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
            var emailUnderChat = textEmail.Text;
            var senhaUnderChat = textSenha.Text;
            var idLojaUnderChat = textIdLoja.Text;
            var idCanalUnderChat = textIdCanal.Text;
            var idSetorUnderChat = int.Parse(textIdSetor.Text);

            // Recupera as mensagens que ainda não foram enviadas
            var mensagensPendentes = _dbContext.EnvioMensagens
                .Include(em => em.ContatoUnderchat)
                .Include(em => em.MensagemObj)
                .Where(em => em.Envio == 0 && em.DataEnvio <= DateTime.Now)
                .ToList();

            foreach (var envioMensagem in mensagensPendentes)
            {
                try
                {
                    var mensagem = envioMensagem.Mensagem;
                    var telefone = envioMensagem.Telefone;
                    var imagem = envioMensagem.Imagem;
                    var nomeContato = envioMensagem.NomeContato;

                    // Utiliza a API do UnderChat
                    conexaoAPI = new ConexaoAPI();
                    dynamic token = conexaoAPI.ObterToken(emailUnderChat, senhaUnderChat);
                    string respostaAPI = conexaoAPI.buscarContatoPorNumero(idLojaUnderChat, telefone, token);
                    RootContato listaDeContatos = JsonConvert.DeserializeObject<RootContato>(respostaAPI);
                    Contato contato = listaDeContatos.data[0];
                    int idAtendimento = conexaoAPI.criarAtendimento(idLojaUnderChat, contato, idSetorUnderChat, idCanalUnderChat, mensagem, token);

                    if (string.IsNullOrEmpty(imagem))
                    {
                        conexaoAPI.enviarMensagem(mensagem, idLojaUnderChat, idAtendimento, token);
                    }
                    else
                    {
                        conexaoAPI.enviarMensagemComImagem(mensagem, idLojaUnderChat, idAtendimento, imagem, token);
                    }

                    // Atualiza a mensagem como enviada
                    envioMensagem.Envio = 1;
                    _dbContext.SaveChanges();

                    // Insere os dados das mensagens enviadas em uma caixa de texto
                    textMensagens.AppendText($"Código: {envioMensagem.Id} - Número: {telefone} - Cliente: {nomeContato}\n");
                    textMensagens.AppendText("");

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
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
        }
    }
}
