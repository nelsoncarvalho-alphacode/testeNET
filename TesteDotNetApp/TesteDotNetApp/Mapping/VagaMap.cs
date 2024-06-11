using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TesteDotNetApp.Models;

namespace TesteDotNetApp.Mapping
{
    public class VagaMap : IEntityTypeConfiguration<Vaga>
    {
        public void Configure(EntityTypeBuilder<Vaga> builder)
        {
            builder.ToTable("Vaga");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.Titulo).IsRequired().HasColumnType("NVARCHAR").HasMaxLength(80);
            builder.Property(x => x.Descricao).IsRequired().HasColumnType("NVARCHAR").HasMaxLength(255);
            builder.Property(x => x.Tipo).IsRequired().HasColumnType("NVARCHAR").HasMaxLength(80);
            builder.Property(x => x.Ativa).IsRequired();
            builder.HasMany(x => x.Candidatos).WithMany();
            
        }
    }
}
