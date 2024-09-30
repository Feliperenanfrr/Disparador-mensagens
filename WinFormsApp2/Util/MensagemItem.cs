using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gweb.WhatsApp.Util
{
    public class MensagemItem
    {
        public int Id { get; set; }
        public string Mensagem { get; set; }
        public override string ToString()
        {
            return $"{Id}: {Mensagem}";
        }
    }
}
