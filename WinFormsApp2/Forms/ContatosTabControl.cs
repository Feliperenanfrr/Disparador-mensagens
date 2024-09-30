using Gweb.WhatsApp.Util;
using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp2;

namespace Gweb.WhatsApp.Forms
{
    public partial class ContatosTabControl : MaterialForm
    {
        operacoesBD operacoesBD = new operacoesBD();
        private MySqlConnection bdConn;
        FormUnderChat formUnderChat = new FormUnderChat();

        private int idMensagem;
        private string server;
        private string user;
        private string senha;
        private string banco;

        public ContatosTabControl()
        {
            InitializeComponent();
            this.server = formUnderChat.txtServer.Text;
            this.user = formUnderChat.txtUsuario.Text;
            this.senha = formUnderChat.txtSenha.Text;
            this.banco = formUnderChat.txtBanco.Text;
        }
    }
}
