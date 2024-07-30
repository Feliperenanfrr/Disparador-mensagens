using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gweb.WhatsApp.Util
{
    internal class operacoesBD
    {
        //FAZER: Verificar se essa classe é realmente é útil, caso seja, aplicá-la em todos os formulários para padronizar
        //FAZER: Caso mantenha a classe, criar função para inserir, consultar, apagar e atualizar o BD através de funções dessa classe
        // Classe auxiliar usada para facilitar a manipualação do banco de dados nos formulários
        MySqlConnection bdConn;

        public MySqlConnection AbrirConexao(string server, string user, string password, string database, string charset = "utf8mb4")
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = server,
                Database = database,
                UserID = user,
                Password = password,
                CharacterSet = charset
            };

            bdConn = new MySqlConnection(builder.ConnectionString);
            bdConn.Open();
            return bdConn;
        }

        public void EncerrarBancoDados(MySqlConnection connection)
        {
            if (connection != null)
            {
                connection.Close();
            }
        }
    }
}
