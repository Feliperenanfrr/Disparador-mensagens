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
