namespace MeepProducts.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int NCM { get; set; }
        public int CFOP { get; set; }
        public int CEST { get; set; }
        public bool Habilitado { get; set; }
        public  DateTime DataCriacao { get; set; }
        public Categoria Categoria { get; set; }
        public Portal Portal { get; set; }
    }
}
