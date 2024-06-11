using Microsoft.EntityFrameworkCore;
using TesteDotNetApp.Mapping;
using TesteDotNetApp.Models;

namespace TesteDotNetApp.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Vaga> Vagas { get; set; } = null!;
        public DbSet<Candidato> Candidatos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CandidatoMap());
            modelBuilder.ApplyConfiguration(new VagaMap());
        }
    }
}
