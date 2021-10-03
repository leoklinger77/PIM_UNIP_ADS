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

            //builder.HasOne(x => x.Frigobar)
            //    .WithOne(x => x.Quarto);


            builder.ToTable("TB_Quarto");
        }
    }

    public class FrigobarMapping : IEntityTypeConfiguration<Frigobar>
    {
        public void Configure(EntityTypeBuilder<Frigobar> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.ProdutosFrigobar)
                 .WithOne(x => x.Frigobar)
                 .HasForeignKey(x => x.FrigobarId);

            builder.HasMany(x => x.ProdutosConsumido)
                 .WithOne(x => x.Frigobar)
                 .HasForeignKey(x => x.FrigobarId);

            builder.ToTable("TB_Frigobar");
        }
    }

    public class ProdutosFrigobarMapping : IEntityTypeConfiguration<ProdutosFrigobar>
    {
        public void Configure(EntityTypeBuilder<ProdutosFrigobar> builder)
        {
            builder.HasKey(x => x.Id);           

            builder.ToTable("TB_ProdutosFrigobar");
        }
    }

    public class ProdutosConsumidosMapping : IEntityTypeConfiguration<ProdutosConsumidos>
    {
        public void Configure(EntityTypeBuilder<ProdutosConsumidos> builder)
        {
            builder.HasKey(x => x.Id);           

            builder.ToTable("TB_ProdutosConsumidos");
        }
    }
}
