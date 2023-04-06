namespace MeepProducts.Models
{
    public class Local
    {
        public int Id { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public ICollection<Portal> Portais { get; set; }
    }
}
