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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(x => x.UserId);

            modelBuilder.Entity<InscricaoModel>()
                .HasOne(i => i.User)
                .WithMany()
                .HasForeignKey(i => i.UserId)
                .IsRequired();

            modelBuilder.Entity<InscricaoModel>()
                .HasOne(i => i.Vaga)
                .WithMany()
                .HasForeignKey(i => i.VagaId);
        }
    }
}
