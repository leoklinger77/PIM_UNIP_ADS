using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnipPim.Hotel.Dominio.Models;

namespace UnipPim.Hotel.Infra.Mapping
{
    public class CidadeMapping : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired();

            builder.HasMany(x => x.Enderecos)
                .WithOne(x => x.Cidade)
                .HasForeignKey(x => x.CidadeId);

            builder.HasOne(x => x.Estado)
                .WithMany(x => x.Cidades);

            builder.ToTable("TB_Cidade");
        }
    }
}
