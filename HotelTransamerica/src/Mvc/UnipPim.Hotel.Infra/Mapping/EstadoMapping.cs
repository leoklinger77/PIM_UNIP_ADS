using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnipPim.Hotel.Dominio.Models;

namespace UnipPim.Hotel.Infra.Mapping
{
    public class EstadoMapping : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired();                

            builder.Property(x => x.Uf)
                .IsRequired()
                .HasColumnType("char(2)");

            builder.HasMany(x => x.Cidades)
                .WithOne(x => x.Estado)
                .HasForeignKey(x => x.EstadoId);

            builder.ToTable("TB_Estado");
        }
    }
}
