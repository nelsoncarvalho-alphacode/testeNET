using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TesteDotNetApp.Models;

namespace TesteDotNetApp.Mapping
{
    public class CandidatoMap : IEntityTypeConfiguration<Candidato>
    {
        public void Configure(EntityTypeBuilder<Candidato> builder)
        {
            builder.ToTable("Candidato");

            builder.HasKey(x => x.ID);
            builder.Property(x => x.Nome).IsRequired().HasColumnName("NVARCHAR").HasMaxLength(80);
            builder.Property(x => x.Email).IsRequired().HasColumnName("VARCHAR").HasMaxLength(80);

        }
    }
}
