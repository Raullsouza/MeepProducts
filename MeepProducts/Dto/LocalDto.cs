using MeepProducts.Models;

namespace MeepProducts.Dto
{
    public class LocalDto
    {
        public int Id { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public ICollection<Portal> Portais { get; set; }
    }
}
