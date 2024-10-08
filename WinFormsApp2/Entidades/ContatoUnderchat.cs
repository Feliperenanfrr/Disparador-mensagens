using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("contatos_underchat")]
public class ContatoUnderchat
{
    public ContatoUnderchat(string nome, int id, string telefone)
    {
        Nome = nome;
        Id = id;
        Telefone = telefone;
    }

    public ContatoUnderchat(string nome, string telefone)
    {
        Nome = nome;
        Telefone = telefone;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
 
    [Column("Id_Underchat")]
    public int IdUnderchat {  get; set; }

    public string Nome { get; set; }
    
    public string Telefone { get; set; }

    public ICollection<EnvioMensagem> Envios { get; set; } // Relacionamento com envio de mensagens

    public override string ToString()
    {
        return $"{Id}: {Nome}";
    }

}
