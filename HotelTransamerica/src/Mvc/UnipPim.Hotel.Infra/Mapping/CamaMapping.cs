using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnipPim.Hotel.Dominio.Models;

namespace UnipPim.Hotel.Infra.Mapping
{
    public class CamaMapping : IEntityTypeConfiguration<Cama>
    {
        public void Configure(EntityTypeBuilder<Cama> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Quarto)
                .WithMany(x => x.Camas);

            builder.ToTable("TB_Cama");
        }
    }
}
