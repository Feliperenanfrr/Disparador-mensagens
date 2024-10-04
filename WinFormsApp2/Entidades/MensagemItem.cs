namespace Gweb.WhatsApp.Entidades
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
