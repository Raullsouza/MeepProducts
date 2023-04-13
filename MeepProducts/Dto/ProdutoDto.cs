using MeepProducts.Models;

namespace MeepProducts.Dto
{
    public class ProdutoDto
    {
        public int ProdutoId { get; set; }
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Preco { get; set; }
        public DateTime DataCriacao { get; set; }

    }
}
