using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnipPim.Hotel.Dominio.Models;

namespace UnipPim.Hotel.Infra.Mapping
{
    public class EnderecoMapping: IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Logradouro)
                .IsRequired();

            builder.Property(x => x.Numero)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(x => x.Bairro)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Bairro)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.HasOne(x => x.Cidade)
                 .WithMany(x => x.Enderecos);

            builder.ToTable("TB_Endereco");
        }
    }
}
