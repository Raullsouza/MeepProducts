﻿
using System.Collections.ObjectModel;

namespace MeepProducts.Models
{
    public class Categoria
    {
        public Categoria()
        {
            Produtos = new Collection<Produto>();
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public Portal Portal { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}
