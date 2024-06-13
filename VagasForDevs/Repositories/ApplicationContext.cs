using Microsoft.AspNetCore.Mvc.ModelBinding;
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
            //RELAÇÕES [(CANDIDATURA - USUARIO), (CANDIDATURA - PERFIL)] -> MUITOS PARA MUITOS
            modelBuilder.Entity<Candidatura>()
                .HasOne(candidatura => candidatura.Usuario)
                .WithMany(usuario => usuario.Candidaturas)
                .HasForeignKey(candidatura => candidatura.Id_Usuario);

            modelBuilder.Entity<Candidatura>()
                .HasOne(candidatura => candidatura.Vaga)
                .WithMany(vaga => vaga.Candidaturas)
                .HasForeignKey(candidatura => candidatura.Id_Vaga);


            //RELAÇÕES [(USUARIO - PERFILUSUARIO)] -> UM PARA MUITOS
            modelBuilder.Entity<Usuario>()
                .HasOne(usuario => usuario.Perfil)
                .WithMany()
                .HasForeignKey(usuario => usuario.Id_Perfil);


            //RELAÇÃO [(VAGA - PERFILVAGA)] -> UM PRA MUITOS
            modelBuilder.Entity<Vaga>()
                .HasOne(vaga => vaga.Perfil)
                .WithMany()
                .HasForeignKey(vaga => vaga.Id_Perfil);
            
        }
    }
}
