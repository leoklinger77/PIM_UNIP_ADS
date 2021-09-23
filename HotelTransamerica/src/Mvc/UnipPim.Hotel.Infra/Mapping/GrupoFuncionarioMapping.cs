using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnipPim.Hotel.Dominio.Models;

namespace UnipPim.Hotel.Infra.Mapping
{
    public class GrupoFuncionarioMapping : IEntityTypeConfiguration<GrupoFuncionario>
    {
        public void Configure(EntityTypeBuilder<GrupoFuncionario> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");            

            builder.ToTable("TB_GrupoFuncionario");
        }
    }

    public class AcessoMapping : IEntityTypeConfiguration<Acesso>
    {
        public void Configure(EntityTypeBuilder<Acesso> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ClaimType)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(x => x.ClaimValue)
                .IsRequired()
                .HasColumnType("varchar(255)");

            builder.ToTable("TB_Acesso");
        }
    }
}
