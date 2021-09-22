using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnipPim.Hotel.Dominio.Models;

namespace UnipPim.Hotel.Infra.Mapping
{
    public class FuncionarioMapping : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NomeCompleto)
                .IsRequired();

            builder.Property(x => x.Cpf)
                .IsRequired()
                .HasColumnType("varchar(11)");

            builder.HasOne(x => x.Cargo)
                .WithMany(x => x.Funcionarios);

            builder.HasMany(x => x.Emails)
                .WithOne(x => x.Funcionario)
                .HasForeignKey(x => x.FuncionarioId);

            builder.HasMany(x => x.Telefones)
               .WithOne(x => x.Funcionario)
                .HasForeignKey(x => x.FuncionarioId);

            builder.HasMany(x => x.Enderecos)
                 .WithOne(x => x.Funcionario)
                .HasForeignKey(x => x.FuncionarioId);

            builder.ToTable("TB_Funcionario");
        }
    }
}
