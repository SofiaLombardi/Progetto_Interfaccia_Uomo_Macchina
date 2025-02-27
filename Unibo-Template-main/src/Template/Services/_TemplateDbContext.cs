using Microsoft.EntityFrameworkCore;
using System.Threading;
using Template.Infrastructure;
using Template.Services.Shared;

namespace Template.Services
{
    public class TemplateDbContext : DbContext
    {
        private static int _databaseInitialized = 0; // Usa un intero per sicurezza nei thread

        public TemplateDbContext(DbContextOptions<TemplateDbContext> options) : base(options)
        {
            if (Interlocked.CompareExchange(ref _databaseInitialized, 1, 0) == 0)
            {
                DataGenerator.InitializeUsers(this);
            }
        }

        //Definizione delle tabelle nel database
        public DbSet<User> Users { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<PlantArticle> PlantArticles { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<HomeInspiration> HomeInspirations { get; set; }
        public DbSet<Suggestion> Suggestions { get; set; }
        public DbSet<UserPlant> UserPlants { get; set; }
        public DbSet<Alert> Alerts { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relazione 1 a 1 tra Plant e PlantArticle
            modelBuilder.Entity<PlantArticle>()
               .HasOne<Plant>() 
               .WithOne()
               .HasForeignKey<PlantArticle>(article => article.PlantId)
               .OnDelete(DeleteBehavior.Cascade);

            // Relazione tra Alert e Plant (1 a N)
            modelBuilder.Entity<Alert>()
                .HasOne<Plant>()
                .WithMany()
                .HasForeignKey(a => a.PlantId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relazione tra Alert e Treatment (1 a 1)
            modelBuilder.Entity<Alert>()
                .HasOne<Treatment>()
                .WithMany()
                .HasForeignKey(a => a.TreatmentId)
                .OnDelete(DeleteBehavior.SetNull);

            // Configura gli Owned Types per PlantArticle
            modelBuilder.Entity<PlantArticle>().OwnsOne(p => p.Content);
            modelBuilder.Entity<PlantArticle>().OwnsOne(p => p.Card);

            //Configura gli Owned Types per Treatment
            modelBuilder.Entity<Treatment>().OwnsOne(t => t.Details);
            modelBuilder.Entity<Treatment>().OwnsOne(t => t.Scheduling);

            //Relazione 1:N tra Suggestion e Plant
            modelBuilder.Entity<Suggestion>()
                .HasOne<Plant>()
                .WithMany()
                .HasForeignKey(s => s.PlantId)
                .OnDelete(DeleteBehavior.Cascade);

            //Relazione 1:N tra HomeInspiration e Plant
            modelBuilder.Entity<HomeInspiration>()
                .HasOne<Plant>()
                .WithMany()
                .HasForeignKey(s => s.PlantId)
                .OnDelete(DeleteBehavior.Cascade);


            //Configura relazione tra user e pianta con la tabella join UserPlant
            modelBuilder.Entity<UserPlant>()
            .HasKey(up => new { up.UserId, up.PlantId });

            modelBuilder.Entity<UserPlant>()
                .HasOne<User>()
                .WithMany(u => u.UserPlants)
                .HasForeignKey(up => up.UserId);

            modelBuilder.Entity<UserPlant>()
                .HasOne<Plant>()
                .WithMany()
                .HasForeignKey(up => up.PlantId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
