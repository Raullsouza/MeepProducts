using MeepProducts.Models;

namespace MeepProducts.Interfaces
{
    public interface IProdutoRepository
    {
        ICollection<Produto> GetProdutos();
        Produto GetProduto(int id);
        Produto GetProduto(string nome);
        bool ProdutoExists(int prodId);
    }
}
