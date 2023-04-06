namespace MeepProducts.Models
{
    public class Portal
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Local Local { get; set; }
        public ICollection<Produto> Produtos { get; set; }
        public ICollection<Categoria> Categorias { get; set; }
    }
}
