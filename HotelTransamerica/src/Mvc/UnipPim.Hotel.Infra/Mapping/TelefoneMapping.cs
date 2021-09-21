using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnipPim.Hotel.Dominio.Models;

namespace UnipPim.Hotel.Infra.Mapping
{
    public class TelefoneMapping : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Ddd)
                .IsRequired()
                .HasColumnType("char(2)");

            builder.Property(x => x.Numero)
                .IsRequired()
                .HasColumnType("varchar(9)");

            builder.ToTable("TB_Telefone");
        }
    }
}
