using Gweb.WhatsApp.Entidades;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using Gweb.WhatsApp.Dados;

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

        // Evento de carregamento do combo box com as mensagens
        private void boxIdMensagem_DropDown(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                try
                {
                    var mensagens = context.Mensagens.ToList();
                    boxIdMensagens.Items.Clear();

                    foreach (var mensagem in mensagens)
                    {
                        MensagemItem item = new MensagemItem
                        {
                            Id = mensagem.Id,
                            Mensagem = mensagem.MensagemTexto
                        };
                        boxIdMensagens.Items.Add(item);
                    }
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
            using (var context = new MyDbContext())
            {
                Mensagem mensagemSelecionada = boxIdMensagens.SelectedItem as Mensagem;
                if (mensagemSelecionada == null)
                {
                    MessageBox.Show("Por favor, selecione uma mensagem.");
                    return;
                }

                int idMensagem = mensagemSelecionada.Id;
                DateTime dataSelecionada = dataEnvioMensagem.Value;

                List<int> idsContatos = new List<int>();

                // Inserção de mensagens agendadas para os contatos selecionados
                foreach (var item in listContatos.CheckedItems)
                {
                    ContatoUnderchat contato = item as ContatoUnderchat;
                    if (contato == null) continue;

                    var envioMensagem = new EnvioMensagem
                    {
                        IdContato = contato.Id,
                        IdMensagem = idMensagem,
                        DataEnvio = dataSelecionada,
                        NomeContato = contato.Nome,  // Simulação do nome do contato
                        Telefone = contato.Telefone  // Simulação do telefone do contato
                    };

                    context.EnvioMensagens.Add(envioMensagem);
                }

                try
                {
                    context.SaveChanges();
                    MessageBox.Show("Mensagens agendadas com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
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
                        listContatos.Items.Add(new ListItem(contato.Nome, contato.Id));
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
                    var mensagens = context.Mensagens.ToList();
                    boxIdMensagens.Items.Clear();

                    foreach (var mensagem in mensagens)
                    {
                        MensagemItem item = new MensagemItem
                        {
                            Id = mensagem.Id,
                            Mensagem = mensagem.MensagemTexto
                        };
                        boxIdMensagens.Items.Add(item);
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
