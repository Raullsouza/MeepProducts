using System.Collections.ObjectModel;

namespace MeepProducts.Models
{
    public class Portal
    {
        public int PortalId { get; set; }
        public Local Local { get; set; }
        public string Nome { get; set; }
        public ICollection<Categoria> Categorias { get; set; }
    }
}
