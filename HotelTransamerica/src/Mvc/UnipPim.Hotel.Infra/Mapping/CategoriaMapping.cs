using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnipPim.Hotel.Dominio.Models;

namespace UnipPim.Hotel.Infra.Mapping
{
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(x => x.Id);                      

            builder.HasMany(x => x.Produtos)
               .WithOne(x => x.Categoria)
               .HasForeignKey(x => x.CategoriaId);

            builder.ToTable("TB_Categoria");
        }
    }
}
