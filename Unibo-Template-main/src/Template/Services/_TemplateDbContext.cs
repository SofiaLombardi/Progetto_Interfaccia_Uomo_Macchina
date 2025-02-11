using Template.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Template.Services.Shared;

namespace Template.Services
{
    public class TemplateDbContext : DbContext
    {
        private static bool _databaseInitialized;

        //public TemplateDbContext()
        //{
        //}

        public TemplateDbContext(DbContextOptions<TemplateDbContext> options) : base(options)
        {
            if (_databaseInitialized!)
            {
                _databaseInitialized = true;
                DataGenerator.InitializeUsers(this);
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<PlantArticle> PlantArticles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plant>()
                .HasOne(p => p.Article) //every plant has ONLY ONE article
                .WithOne(article => article.Plant) //every article is linked to ONLY ONE plant
                .HasForeignKey<PlantArticle>(article => article.PlantId) //PlantId is both PK and FK
                .OnDelete(DeleteBehavior.Cascade); //if the plant is deleted, so is the article 

            base.OnModelCreating(modelBuilder);
        }
    }
}
