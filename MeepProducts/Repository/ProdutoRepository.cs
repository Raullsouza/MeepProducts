using MeepProducts.Data;
using MeepProducts.Interfaces;
using MeepProducts.Models;

namespace MeepProducts.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataContext _context;

        public ProdutoRepository(DataContext context)
        {
          _context = context;
        }
        public ICollection<Produto> GetProdutos()
        {
            return _context.Produtos.OrderBy(p => p.Id).ToList();
        }
        public Produto GetProdutoById(int id)
        {
            return _context.Produtos.Where(p => p.Id == id).FirstOrDefault();
        }
        public Produto GetProdutoByName(string nome)
        {
            return _context.Produtos.Where(p => p.Nome == nome).FirstOrDefault();
        }

        public bool ProdutoExists(int prodId)
        {
            return _context.Produtos.Any(p => p.Id == prodId);
        }

        public bool ProdutoExistsByName(string nome)
        {
            return _context.Produtos.Any(p =>p.Nome == nome);
        }

        public bool CategoriaExists(int categoriaId)
        {
            return _context.Categorias.Any(c => c.Id == categoriaId);
        }

        public ICollection<Produto> GetProdutosByCategoria(int categoriaId)
        {
            return _context.Produtos.Where(p => p.Categoria.Id == categoriaId).ToList();
        }

        public bool CreateProduto(Produto produto)
        {
            _context.Add(produto);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
