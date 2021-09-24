using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnipPim.Hotel.Dominio.Models;

namespace UnipPim.Hotel.Infra.Mapping
{
    public class FotoMapping : IEntityTypeConfiguration<Foto>
    {
        public void Configure(EntityTypeBuilder<Foto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Anuncio)
               .WithMany(x => x.Fotos);

            builder.ToTable("TB_Foto");
        }
    }
}
