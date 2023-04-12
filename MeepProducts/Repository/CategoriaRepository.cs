using MeepProducts.Data;
using MeepProducts.Interfaces;
using MeepProducts.Models;

namespace MeepProducts.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly DataContext _context;

        public CategoriaRepository(DataContext context)
        {
            _context = context;
        }
        public bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(c => c.Id == id);
        }

        public ICollection<Categoria> GetCategorias()
        {
            return _context.Categorias.OrderBy(c => c.Id).ToList();
        }

        public Categoria GetCategoria(int id)
        {
            return _context.Categorias.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<Produto> GetProdutosByCategoria(int categoriaId)
        {
            return _context.Produtos.Where(p => p.CategoriaId == categoriaId).ToList();
        }
    }
}
