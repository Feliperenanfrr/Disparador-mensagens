using Gweb.WhatsApp.Util;
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

namespace Gweb.WhatsApp.Forms
{
    public partial class CriarMensagem : Form
    {
        private MySqlConnection bdConn;
        private DataSet bdDataSet;

        public CriarMensagem()
        {
            InitializeComponent();
        }

        private void btnCriarMensagem_Click(object sender, EventArgs e)
        {
            string mensagem = textoMensagem.Text;
            string tipo = tipoMensagem.Text;
            string imagem = linkImagem.Text;

            var builder = new MySqlConnectionStringBuilder
            {
                Server = "mysql.gueppardo.net",
                Database = "gueppardo",
                UserID = "gueppardo",
                Password = "gpd1664",
                CharacterSet = "utf8"
            };

            try
            {
                bdConn = new MySqlConnection(builder.ConnectionString);
                bdConn.Open();

                string criarMensagem = "INSERT INTO cadastro_mensagens(Mensagem, Tipo, Imagem) VALUES (@Mensagem, @Tipo, @Imagem)";
                using (MySqlCommand insertCmd = new MySqlCommand(criarMensagem, bdConn))
                {
                    insertCmd.Parameters.AddWithValue("@Mensagem", mensagem);
                    insertCmd.Parameters.AddWithValue("@Tipo", tipo);
                    insertCmd.Parameters.AddWithValue("@Imagem", imagem);

                    int linhasAfetadas = insertCmd.ExecuteNonQuery();

                    if(linhasAfetadas > 0)
                    {
                        textoMensagem.Clear();
                        linkImagem.Clear();
                        tipoMensagem.Clear();
                        MessageBox.Show("Mensagem gravada com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("A mensagem não foi gravada!");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
