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

        public DbSet<Piante> Piante { get; set; } 
        public DbSet<Trattamenti> Trattamenti { get; set; }
        public DbSet<IdeeCasa> IdeeCasa { get; set; }
        public DbSet<Consigli> Consigli { get; set; }
        public DbSet<Tossicità> Tossicità { get; set; }
        public DbSet<Allerte> Allerte { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

           
            builder.Entity<Piante>()
                .HasOne(p => p.User)
                .WithMany() 
                .HasForeignKey(p => p.UserId) 
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}