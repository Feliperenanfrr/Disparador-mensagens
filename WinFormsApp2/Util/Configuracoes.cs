using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gweb.WhatsApp.Util
{
    public static class Configuracoes
    {
        public static string APIEmail => ConfigurationManager.AppSettings["APIEmail"];
        public static string APISenha => ConfigurationManager.AppSettings["APISenha"];
        public static string IdLoja => ConfigurationManager.AppSettings["IdLoja"];
    }
}
