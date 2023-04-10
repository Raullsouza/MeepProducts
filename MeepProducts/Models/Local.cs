using System.Collections.ObjectModel;

namespace MeepProducts.Models
{
    public class Local
    {
        public Local()
        {
            Portais = new Collection<Portal>();
        }
        public int Id { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public ICollection<Portal> Portais { get; set; }
    }
}
