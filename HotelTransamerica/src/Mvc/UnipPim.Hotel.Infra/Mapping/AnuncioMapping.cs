using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnipPim.Hotel.Dominio.Models;

namespace UnipPim.Hotel.Infra.Mapping
{
    public class AnuncioMapping : IEntityTypeConfiguration<Anuncio>
    {
        public void Configure(EntityTypeBuilder<Anuncio> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Quarto)
               .WithMany(x => x.Anuncios);

            builder.HasMany(x => x.Fotos)
               .WithOne(x => x.Anuncio)
               .HasForeignKey(x => x.AnuncioId);

            builder.ToTable("TB_Anuncio");
        }
    }
}
