using MeepProducts.Models;

namespace MeepProducts.Dto
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataCriacao { get; set; }

    }
}
