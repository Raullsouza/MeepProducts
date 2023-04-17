using MeepProducts.Models;

namespace MeepProducts.Interfaces
{
    public interface IProdutoRepository
    {
        ICollection<Produto> GetProdutos();
        Produto GetProdutoById(int id);
        Produto GetProdutoByName(string nome);
        ICollection<Produto> GetProdutosByCategoria(int categoriaId);
        bool ProdutoExists(int prodId);
        bool ProdutoExistsByName(string nome);
        bool CategoriaExists(int categoriaId);
        bool CreateProduto(Produto produto);
        bool UpdateProduto(Produto produto);
        bool DeleteProduto(Produto produto);
        bool Save();
    }
}
