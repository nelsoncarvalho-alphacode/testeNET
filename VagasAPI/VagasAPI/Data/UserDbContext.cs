using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VagasAPI.Models;

namespace VagasAPI.Data
{
    public class UserDbContext : IdentityDbContext<IdentityUser>
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<VagaModel> Vagas { get; set; }
        public DbSet<InscricaoModel> Inscricoes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Adicione esta linha

            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(x => x.UserId);
        }
    }
}
