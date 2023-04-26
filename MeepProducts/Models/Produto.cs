using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeepProducts.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(8,2)")]
       
        public decimal Preco { get; set; }

        public DateTime DataCriacao { get; set; }
        public Categoria Categoria { get; set; }   
    }
}
