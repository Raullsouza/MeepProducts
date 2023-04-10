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

    }
}
