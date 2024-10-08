using System.ComponentModel.DataAnnotations.Schema;

[Table("envio_mensagens")]
public class EnvioMensagem
{
    public int Id { get; set; }

    [Column("id_contato")]
    public int IdContato { get; set; }

    [Column("id_mensagem")]
    public int IdMensagem { get; set; }

    [Column("data_envio")]
    public DateTime DataEnvio { get; set; }

    public int Envio {  get; set; }

    [Column("Nome_Contato")]
    public string NomeContato { get; set; }

    [Column("Telefone")]
    public string Telefone { get; set; }

    [Column("Mensagem")]
    public string Mensagem { get; set; }

    [Column("imagem")]
    public string Imagem { get; set; }

    // Relacionamentos
    public ContatoUnderchat ContatoUnderchat{ get; set; }
    public Mensagem MensagemObj { get; set; }
}
