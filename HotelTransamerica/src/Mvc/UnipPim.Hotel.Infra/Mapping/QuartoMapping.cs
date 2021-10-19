using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnipPim.Hotel.Dominio.Models;

namespace UnipPim.Hotel.Infra.Mapping
{
    public class QuartoMapping : IEntityTypeConfiguration<Quarto>
    {
        public void Configure(EntityTypeBuilder<Quarto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Camas)
                .WithOne(x => x.Quarto)
                .HasForeignKey(x => x.QuaroId);

            builder.HasMany(x => x.Anuncios)
                .WithOne(x => x.Quarto)
                .HasForeignKey(x => x.QuartoId);
         

            builder.ToTable("TB_Quarto");
        }
    }
}
