using Gweb.WhatsApp.Dados;
using Gweb.WhatsApp.Util;
using MaterialSkin.Controls;
using Microsoft.EntityFrameworkCore;
using WinFormsApp2;

namespace Gweb.WhatsApp.Forms
{
    public partial class ContatosTabControl : MaterialForm
    {
        FormUnderChat formUnderChat = new FormUnderChat();
        ConexaoAPI conexaoAPI = new ConexaoAPI();
        string idLoja = "832";
        string email = "felipeferreira3146@gmail.com";

        public ContatosTabControl()
        {
            InitializeComponent();
        }

        private async void btnCadastrarContatos_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                try
                {
                    // Faz um GET na API do UnderChat e cria uma instância da classe Contato para cada contato
                    string token = conexaoAPI.ObterToken(email, "1664");
                    RootContato listaDeContatos = conexaoAPI.BuscarTodosContatos(idLoja, token);

                    List<Contato> contatosLista = listaDeContatos.data;
                    int contatosCadastrados = 0;

                    foreach (Contato contato in contatosLista)
                    {
                        // Cadastra apenas os contatos com os prefixos desejados
                        Person pessoa = contato.person;
                        string nome = pessoa.name;

                        if (nome.StartsWith("Gpd") || nome.StartsWith("Cli-") || nome.StartsWith("Parc-"))
                        {
                            // Verifica de forma assíncrona se o contato já existe no banco de dados
                            bool contatoExistente = await context.Contatos
                                .AnyAsync(c => c.IdUnderchat == contato.id && c.Telefone == contato.value);

                            if (!contatoExistente)
                            {
                                // Cria uma nova instância de ContatoUnderchat, sem definir o campo Id (autoincremento)
                                var novoContato = new ContatoUnderchat
                                (
                                    nome: pessoa.name,
                                    telefone: contato.value
                                )
                                {
                                    IdUnderchat = contato.id // Define o IdUnderchat (vindo da API)
                                };

                                // Adiciona o novo contato ao contexto
                                context.Contatos.Add(novoContato);
                                contatosCadastrados++;
                            }
                        }
                    }

                    // Salva as mudanças no banco de dados de forma assíncrona
                    await context.SaveChangesAsync();

                    MaterialMessageBox.Show($"Total de contatos cadastrados: {contatosCadastrados}", "Contatos Cadastrados");
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show($"Erro: {ex.Message}");
                }
            }
        }


        private void btnListarContatos_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                try
                {
                    // Limpa os itens existentes no ListView
                    contatosListView.Items.Clear();

                    // Busca todos os contatos cadastrados
                    var contatos = context.Contatos.ToList();

                    // Preenche o ListView com os dados dos contatos
                    foreach (var contato in contatos)
                    {
                        var item = new ListViewItem(contato.Id.ToString()); // ID como primeiro item
                        item.SubItems.Add(contato.IdUnderchat.ToString());  // Id_Underchat como subitem
                        item.SubItems.Add(contato.Nome);                   // Nome como subitem
                        item.SubItems.Add(contato.Telefone);               // Telefone como subitem

                        contatosListView.Items.Add(item);
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
