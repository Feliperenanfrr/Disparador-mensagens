using System.ComponentModel.DataAnnotations.Schema;

[Table("contatos_underchat")]
public class ContatoUnderchat
{
    public ContatoUnderchat(string nome, int id)
    {
        Nome = nome;
        Id = id;
    }

    public int Id { get; set; }
 
    [Column("Id_Underchat")]
    public int IdUnderchat {  get; set; }

    public string Nome { get; set; }
    
    public string Telefone { get; set; }

    public ICollection<EnvioMensagem> Envios { get; set; } // Relacionamento com envio de mensagens


}
