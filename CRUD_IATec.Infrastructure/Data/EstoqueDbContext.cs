using CRUD_IATec.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CRUD_IATec.Infrastructure.Data
{
    public class EstoqueDbContext : DbContext
    {
        public EstoqueDbContext(DbContextOptions<EstoqueDbContext> options) : base(options)
        {
        }

        public DbSet<Estoque> Estoques { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração da entidade Estoque
            modelBuilder.Entity<Estoque>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.NomeProduto)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Preco)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                entity.Property(e => e.Quantidade)
                    .IsRequired();
            });
        }
    }
}