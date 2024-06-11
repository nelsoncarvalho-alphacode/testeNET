using Microsoft.EntityFrameworkCore;
using VagasForDevs.Models;

namespace Vagas.Repositories
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Vaga> Vaga { get; set; }
        public DbSet<Candidatura> Candidatura { get; set; }
        public DbSet<PerfilUsuario> PerfilUsuario { get; set; }
        public DbSet<PerfilVaga> PerfilVaga { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(); 
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
