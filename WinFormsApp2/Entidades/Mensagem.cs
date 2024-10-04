using System.ComponentModel.DataAnnotations.Schema;

[Table("cadastro_mensagens")]
public class Mensagem
{
    public int Id { get; set; }

    [Column("Mensagem")]
    public string MensagemTexto { get; set; } // Renomeado para diferenciar o nome da propriedade e da classe
    
    public string Tipo { get; set; }
    
    public string Imagem { get; set; }

    public ICollection<EnvioMensagem> Envios { get; set; } // Relacionamento com envio de mensagens

    public override string ToString()
    {
        return $"{Id}: {MensagemTexto}";
    }
}
