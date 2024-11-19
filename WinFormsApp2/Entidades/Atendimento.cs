using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gweb.WhatsApp.Entidades
{
    internal class Atendimento
    {
        // Classe auxiliar usada para manipular o JSON do atendimento vindo da API do UnderChat
        public class Data
        {
            public int id { get; set; }
        }

        public class RootAtendimento
        {
            public int code { get; set; }
            public string status { get; set; }
            public string message { get; set; }
            public Data data { get; set; }
            public int meta { get; set; }
        }


    }
}
