namespace Gweb.WhatsApp.Entidades
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
