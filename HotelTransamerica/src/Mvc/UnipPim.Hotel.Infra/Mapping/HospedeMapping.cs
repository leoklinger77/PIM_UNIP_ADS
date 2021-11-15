using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnipPim.Hotel.Dominio.Models;

namespace UnipPim.Hotel.Infra.Mapping
{
    public class HospedeMapping : IEntityTypeConfiguration<Hospede>
    {
        public void Configure(EntityTypeBuilder<Hospede> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NomeCompleto)
                .IsRequired();

            builder.Property(x => x.Cpf)
                .IsRequired()
                .HasColumnType("varchar(11)");          

            builder.HasMany(x => x.Emails)
                .WithOne(x => x.Hospede)
                .HasForeignKey(x => x.HospedeId);

            builder.HasMany(x => x.Telefones)
                .WithOne(x => x.Hospede)
                .HasForeignKey(x => x.HospedeId);

            builder.HasMany(x => x.Enderecos)
                .WithOne(x => x.Hospede)
                .HasForeignKey(x => x.HospedeId);            

            builder.ToTable("TB_Hospede");
        }
    }
}
