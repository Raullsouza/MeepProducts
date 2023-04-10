using System.Collections.ObjectModel;

namespace MeepProducts.Models
{
    public class Portal
    {
        public Portal()
        {
            Categorias = new Collection<Categoria>();
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public Local Local { get; set; }
        public ICollection<Categoria> Categorias { get; set; }
    }
}
