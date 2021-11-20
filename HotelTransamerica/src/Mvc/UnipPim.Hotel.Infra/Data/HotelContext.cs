using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Models;

namespace UnipPim.Hotel.Infra.Data
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options) { }

        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Email> Email { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Hospede> Hospede { get; set; }
        public DbSet<GrupoFuncionario> GrupoFuncionario { get; set; }
        public DbSet<Acesso> Acesso { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Cama> Cama { get; set; }
        public DbSet<Quarto> Quarto { get; set; }
        public DbSet<Anuncio> Anuncio { get; set; }
        public DbSet<Foto> Foto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Dominio.Models.Produto> Produto { get; set; }        
        public DbSet<Reserva> Reserva { get; set; }
        public DbSet<Caixa> Caixa { get; set; }
        public DbSet<OrderVenda> OrderVenda { get; set; }
        public DbSet<ItensVenda> ItensVenda { get; set; }        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(255)");

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HotelContext).Assembly);

            //ManyToMany
            modelBuilder.Entity<ItensVenda>()
                .HasKey(x => new { x.OrderVendaId, x.ProdutoId });
            modelBuilder.Entity<ItensVenda>()
                .HasOne(x => x.Produto)
                .WithMany(x => x.ItensVendas)
                .HasForeignKey(x => x.ProdutoId);
            modelBuilder.Entity<ItensVenda>()
                .HasOne(x => x.OrderVenda)
                .WithMany(x => x.ItensVendas)
                .HasForeignKey(x => x.OrderVendaId);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("InsertDate") != null || entry.Entity.GetType().GetProperty("UpdateDate") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("InsertDate").CurrentValue = DateTime.Now;                    

                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("InsertDate").IsModified = false;
                    entry.Property("UpdateDate").CurrentValue = DateTime.Now;
                }
            }           

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken); 
        }
    }
}
