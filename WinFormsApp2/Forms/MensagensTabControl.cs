using MaterialSkin.Controls;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using Gweb.WhatsApp.Dados;
using Gweb.WhatsApp.Util;

namespace Gweb.WhatsApp.Forms
{
    public partial class MensagensTabControl : MaterialForm
    {
        public MensagensTabControl()
        {
            InitializeComponent();
        }

        // Evento de pesquisa de mensagens
        private void btnPesquisarMensagem_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                try
                {
                    // Busca todas as mensagens cadastradas
                    var mensagens = context.Mensagens.ToList();
                    dataGridMensagens.DataSource = mensagens.Select(m => new
                    {
                        m.Id,
                        m.MensagemTexto,
                        m.Tipo,
                        m.Imagem
                    }).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }
            }
        }

        // Evento de agendamento de mensagens
        private void btnAgendarMensagem_Click(object sender, EventArgs e)
        {
            // Certifique-se de que uma mensagem foi selecionada
            Mensagem mensagemSelecionada = boxIdMensagens.SelectedItem as Mensagem;
            if (mensagemSelecionada == null)
            {
                MessageBox.Show("Por favor, selecione uma mensagem.");
                return;
            }

            DateTime dataSelecionada = dataEnvioMensagem.Value;

            // Lista de envios de mensagens a serem criadas
            List<EnvioMensagem> envios = new List<EnvioMensagem>();

            // Coleta todos os contatos selecionados no CheckedListBox
            foreach (var item in listContatos.CheckedItems)
            {
                ContatoUnderchat contatoSelecionado = item as ContatoUnderchat;  // `Contato` do banco de dados, não da API
                if (contatoSelecionado == null) continue;

                // Cria um novo envio de mensagem para cada contato
                var envioMensagem = new EnvioMensagem
                {
                    IdContato = contatoSelecionado.Id,
                    IdMensagem = mensagemSelecionada.Id,
                    DataEnvio = dataSelecionada,
                    NomeContato = contatoSelecionado.Nome,
                    Telefone = contatoSelecionado.Telefone,
                    Mensagem = mensagemSelecionada.MensagemTexto,  // Atribui a mensagem correspondente
                    Imagem = mensagemSelecionada.Imagem
                };

                envios.Add(envioMensagem);  // Adiciona o envio à lista
            }

            // Verifica se há pelo menos um contato selecionado
            if (envios.Count == 0)
            {
                MessageBox.Show("Por favor, selecione ao menos um contato.");
                return;
            }

            // Insere todos os envios de mensagens de uma só vez no banco de dados
            using (var context = new MyDbContext())
            {
                try
                {
                    context.EnvioMensagens.AddRange(envios);  // Adiciona todos os envios em lote
                    context.SaveChanges();  // Salva todas as mudanças no banco de dados

                    MessageBox.Show("Mensagens agendadas com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao agendar mensagens: {ex.Message}");
                }
            }
        }

        // Evento de carregamento dos contatos
        private void MensagensTabControl_Load(object sender, EventArgs e)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var contatos = context.Contatos.ToList();
                    foreach (var contato in contatos)
                    {
                        // Adiciona o contato na lista com o formato "ID - Nome"
                        listContatos.Items.Add(new ContatoUnderchat(contato.Nome, contato.Id, contato.Telefone));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar contatos: {ex.Message}");
            }
        }


        // Evento para criar uma nova mensagem
        private void btnCriarMensagem_Click(object sender, EventArgs e)
        {
            string mensagemTexto = textoMensagem.Text;
            string tipo = tipoMensagem.Text;
            string imagem = linkImagem.Text;

            try
            {
                using (var context = new MyDbContext())
                {
                    var novaMensagem = new Mensagem
                    {
                        MensagemTexto = mensagemTexto,
                        Tipo = tipo,
                        Imagem = imagem
                    };

                    context.Mensagens.Add(novaMensagem);
                    context.SaveChanges();

                    textoMensagem.Clear();
                    linkImagem.Clear();
                    tipoMensagem.Clear();
                    MessageBox.Show("Mensagem gravada com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Evento de carregamento do combo box
        private void boxIdMensagem_DropDown_1(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                try
                {
                    // Obtém todas as mensagens do banco de dados
                    var mensagens = context.Mensagens.ToList();
                    boxIdMensagens.Items.Clear();

                    // Adiciona cada mensagem diretamente no ComboBox
                    foreach (var mensagem in mensagens)
                    {
                        // Adiciona o objeto Mensagem diretamente
                        boxIdMensagens.Items.Add(mensagem);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }
            }
        }
    }
}
