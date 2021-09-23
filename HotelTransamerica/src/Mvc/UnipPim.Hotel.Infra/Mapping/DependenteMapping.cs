using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnipPim.Hotel.Dominio.Models;

namespace UnipPim.Hotel.Infra.Mapping
{
    public class DependenteMapping : IEntityTypeConfiguration<Dependente>
    {
        public void Configure(EntityTypeBuilder<Dependente> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NomeCompleto)
                .IsRequired();

            builder.Property(x => x.Cpf)
                .IsRequired()
                .HasColumnType("varchar(11)");

            builder.HasOne(x => x.Responsabel)
             .WithMany(x => x.Dependentes);

            builder.ToTable("TB_Dependente");
        }
    }
}
