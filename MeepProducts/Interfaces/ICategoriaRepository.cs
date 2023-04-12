﻿using MeepProducts.Models;

namespace MeepProducts.Interfaces
{
    public interface ICategoriaRepository
    {
        ICollection<Categoria> GetCategorias();
        Categoria GetCategoria(int id);
        Categoria GetCategoria(string name);
        ICollection<Produto> GetProdutosByCategoria(int categoriaId);   
        bool CategoriaExists(int id);
        bool ExistsByName(string name);
         
    }
}
