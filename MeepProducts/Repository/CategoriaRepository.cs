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
        public bool ExistsByName(string name)
        {
            return _context.Categorias.Any(c => c.Nome == name);
        }

        public ICollection<Categoria> GetCategorias()
        {
            return _context.Categorias.OrderBy(c => c.Id).ToList();
        }

        public Categoria GetCategoria(int id)
        {
            return _context.Categorias.Where(c => c.Id == id).FirstOrDefault();
        }
        public Categoria GetCategoria(string nome)
        {
            return _context.Categorias.Where(c => c.Nome == nome).FirstOrDefault();
        }

        public ICollection<Produto> GetProdutosByCategoria(int categoriaId)
        {
            return _context.Produtos.Where(p => p.Categoria.Id == categoriaId).ToList();
        }

        public bool CreateCategoria(Categoria categoria)
        {
            _context.Add(categoria);
            return Save();
        }
        public bool UpdateCategoria(Categoria categoria)
        {
            _context.Update(categoria);
            return Save();
        }
        public bool DeleteCategoria(Categoria categoria)
        {
            _context.Remove(categoria);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
      
}
