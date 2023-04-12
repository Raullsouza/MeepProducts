﻿namespace MeepProducts.Dto
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Preco { get; set; }
        public DateTime DataCriacao { get; set; }
        public int CategoriaId { get; set; }
    }
}
