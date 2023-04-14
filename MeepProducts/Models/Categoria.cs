
using System.Collections.ObjectModel;

namespace MeepProducts.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public int PortalId { get; set; }
        public string Nome { get; set; }
        public Portal Portal { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}
