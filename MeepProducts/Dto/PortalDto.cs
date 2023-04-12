using MeepProducts.Models;

namespace MeepProducts.Dto
{
    public class PortalDto
    {
        public int Id { get; set; }
        public int LocalId { get; set; }
        public string Nome { get; set; }
        public Local Local { get; set; }
    }
}
