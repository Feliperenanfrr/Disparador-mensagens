using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Windows.Forms;

namespace Gweb.WhatsApp.Dados
{
    internal class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Acessa a string de conexão do App.config
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            // Configura o DbContext para usar MySQL
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        }

        // DbSets para as entidades
        public DbSet<EnvioMensagem> EnvioMensagens { get; set; }
        public DbSet<ContatoUnderchat> Contatos { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações adicionais (caso necessário)
            modelBuilder.Entity<EnvioMensagem>()
                .HasOne(e => e.ContatoUnderchat)
                .WithMany(c => c.Envios)
                .HasForeignKey(e => e.IdContato);

            modelBuilder.Entity<EnvioMensagem>()
                .HasOne(e => e.MensagemObj)
                .WithMany(m => m.Envios)
                .HasForeignKey(e => e.IdMensagem);
        }
    }
}
