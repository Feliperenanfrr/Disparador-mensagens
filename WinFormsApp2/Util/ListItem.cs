using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gweb.WhatsApp.Util
{
    public class ListItem
    {
        public string Nome { get; }
        public int Id { get; }

        public ListItem(string nome, int id)
        {
            Nome = nome;
            Id = id;
        }

        public override string ToString()
        {
            return $"{Id}: {Nome}";
        }
    }
}
