using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gweb.WhatsApp.Util
{
    internal class Atendimento
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
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
