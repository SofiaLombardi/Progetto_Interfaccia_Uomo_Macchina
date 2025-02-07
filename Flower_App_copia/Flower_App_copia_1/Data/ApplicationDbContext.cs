using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Flower_App_copia_1.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        // DbSets per le entità
        public DbSet<Pianta> Piante { get; set; }
        public DbSet<Trattamenti> Trattamenti { get; set; }
        public DbSet<IdeaCasa> IdeeCasa { get; set; }
        public DbSet<Consigli> Consigli { get; set; }
        public DbSet<Tossicità> Tossicità { get; set; }
        public DbSet<Allerte> Allerte { get; set; }

        // DbSet per la tabella di associazione molti-a-molti
        public DbSet<ClientePianta> ClientePianta { get; set; }
        public DbSet<Cliente> Clienti { get; set; }

        // Configurazione delle relazioni nel modello
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configurazione relazione molti-a-molti tra Clienti e Piante tramite ClientePianta
            builder.Entity<ClientePianta>()
                .HasKey(cp => new { cp.ClienteId, cp.PiantaId });  // La chiave primaria è la combinazione di ClienteId e PiantaId

            builder.Entity<ClientePianta>()
                .HasOne(cp => cp.Cliente)  // Relazione con Cliente
                .WithMany(c => c.ClientePiante)  // Un cliente può avere molte piante
                .HasForeignKey(cp => cp.ClienteId)  // Chiave esterna ClienteId
                .OnDelete(DeleteBehavior.Cascade);  // Se il Cliente viene eliminato, elimina le sue associazioni con le piante

            builder.Entity<ClientePianta>()
                .HasOne(cp => cp.Pianta)  // Relazione con Pianta
                .WithMany(p => p.ClientePiante)  // Una pianta può appartenere a molti clienti
                .HasForeignKey(cp => cp.PiantaId)  // Chiave esterna PiantaId
                .OnDelete(DeleteBehavior.Cascade);  // Se la Pianta viene eliminata, elimina le sue associazioni con i clienti

            builder.Entity<Cliente>()
                    .HasOne(p => p.User)
                    .WithMany()
                    .HasForeignKey(p => p.UserId)
                    .OnDelete(DeleteBehavior.Cascade);





        }
    }
}
