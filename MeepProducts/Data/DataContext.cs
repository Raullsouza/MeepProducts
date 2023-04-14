using MeepProducts.Models;
using Microsoft.EntityFrameworkCore;

namespace MeepProducts.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Local> Locais { get; set; }
        public DbSet<Portal> Portais { get; set; }
        public DbSet<Produto> Produtos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                 .HasMany(p => p.Produtos)
                 .WithOne(c => c.Categoria)
                 .HasForeignKey(p => p.CategoriaId);

            modelBuilder.Entity<Local>()
                .HasMany(p => p.Portais)
                .WithOne(l => l.Local)
                .HasForeignKey(p => p.LocalId);

            modelBuilder.Entity<Portal>()
                .HasMany(c => c.Categorias)
                .WithOne(p => p.Portal)
                .HasForeignKey(p => p.PortalId);
        }
    }
 }

