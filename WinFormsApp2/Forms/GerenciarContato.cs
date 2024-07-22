﻿using Gweb.WhatsApp.Util;
using Newtonsoft.Json;

namespace Gweb.WhatsApp.Forms
{
    public partial class GerenciarContato : Form
    {
        ConexaoAPI conexaoAPI = new ConexaoAPI();

        string idLoja = "832";
        string email = "felipeferreira3146@gmail.com";
        string senha = "1664";

        public GerenciarContato()
        {
            InitializeComponent();
        }

        private void btnCadastrarContato(object sender, EventArgs e)
        {
            string token = conexaoAPI.ObterToken(email, senha);
            RootContato listaDeContatos =  conexaoAPI.BuscarTodosContatos(idLoja, token);

            List<Contato> contatosLista = listaDeContatos.data;
            textContatos.Text = listaDeContatos.ToString();
            foreach(Contato contato in contatosLista)
            {
                textContatos.Text += contato.ToString();
            }

            /*List<RootContato> contatos = conexaoAPI.BuscarTodosContatos(idLoja, token);
            RootContato listaDeContatos = JsonConvert.DeserializeObject<RootContato>(contatos);
            textContatos.Text = listaDeContatos.ToString();*/
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
