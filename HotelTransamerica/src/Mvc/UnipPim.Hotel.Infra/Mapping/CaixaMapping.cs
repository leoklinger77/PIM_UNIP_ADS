using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnipPim.Hotel.Dominio.Models;

namespace UnipPim.Hotel.Infra.Mapping
{
    public class CaixaMapping : IEntityTypeConfiguration<Caixa>
    {
        public void Configure(EntityTypeBuilder<Caixa> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("TB_Caixa");
        }
    }

    public class OrderVendaMapping : IEntityTypeConfiguration<OrderVenda>
    {
        public void Configure(EntityTypeBuilder<OrderVenda> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("TB_OrderVenda");
        }
    }   
    
}
