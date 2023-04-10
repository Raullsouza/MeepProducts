using MeepProducts.Data;
using MeepProducts.Models;

namespace MeepProducts
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
                var Locais = new List<Local>()
                {
                    new Local()
                    {
                        Cidade = "Belo Horizonte",
                        Estado = "Minas Gerais",
                        Portais = new List<Portal>()
                        {
                            new Portal
                            {
                                Nome = "Hacienda",
                                Categorias = new List<Categoria>()
                                {
                                    new Categoria
                                    {
                                        Nome = "Bebidas",
                                        Produtos = new List<Produto>()
                                        {
                                            new Produto { Nome = "Água", Descricao = "Sem Gás" },
                                            new Produto { Nome = "Água", Descricao = "Com Gás" },
                                            new Produto { Nome = "Hamburguer", Descricao = "Frango"},
                                            new Produto { Nome = "Pizza", Descricao = "Calabresa"},
                                        }
                                    },
                                     new Categoria
                                    {
                                        Nome = "Comidas",
                                        Produtos = new List<Produto>()
                                        {
                                            new Produto { Nome = "Arroz", Descricao = "branco"},
                                            new Produto { Nome = "Feijão", Descricao = "Preto" },
                                            new Produto { Nome = "Farinha", Descricao = "trigo"},
                                            new Produto { Nome = "Torta", Descricao = "Frango"},

                                        }
                                    },
                                }
                            },
                            new Portal
                            {
                                Nome = "Havanna",
                                Categorias = new List<Categoria>()
                                {
                                    new Categoria
                                    {
                                        Nome = "Bebidas",
                                        Produtos = new List<Produto>()
                                        {
                                            new Produto { Nome = "Água", Descricao = "Sem Gás" },
                                            new Produto { Nome = "Coca cola", Descricao = "Refrigerante" },
                                            new Produto { Nome = "Vodka", Descricao = "Alcoolica" }
                                        }
                                    }
                                }
                            }
                        }
                    },
                   new Local()
                    {
                        Cidade = "Santos",
                        Estado = "São Paulo",
                        Portais = new List<Portal>()
                        {
                            new Portal
                            {
                                Nome = "Arena XP",
                                Categorias = new List<Categoria>()
                                {
                                    new Categoria
                                    {
                                        Nome = "Alcoolicas",
                                        Produtos = new List<Produto>()
                                        {
                                            new Produto { Nome = "Cerveja", Descricao = "Puro malte" },
                                            new Produto { Nome = "Cachaça", Descricao = "Amarela" },
                                            new Produto { Nome = "Vodka", Descricao = "Ciroc"},
                                            new Produto { Nome = "Corote", Descricao = "Saborizado"},
                                        }
                                    },
                                     new Categoria
                                    {
                                        Nome = "Churrasco",
                                        Produtos = new List<Produto>()
                                        {
                                            new Produto { Nome = "Picanha", Descricao = "Boi"},
                                            new Produto { Nome = "Asa", Descricao = "Frango" },
                                            new Produto { Nome = "Linguiça", Descricao = "Porco"},
                                            new Produto { Nome = "Lombo", Descricao = "Proco"},

                                        }
                                    },
                                }
                            },
                            new Portal
                            {
                                Nome = "Bosque park",
                                Categorias = new List<Categoria>()
                                {
                                    new Categoria
                                    {
                                        Nome = "Destilados",
                                        Produtos = new List<Produto>()
                                        {
                                            new Produto { Nome = "Vodka", Descricao = "Absolut" },
                                            new Produto { Nome = "Whisky", Descricao = "Red Label" },
                                            new Produto { Nome = "Pinga", Descricao = "Da roça" }
                                        }
                                    }
                                }
                            }
                        }
                    },
                };
            dataContext.Locais.AddRange(Locais);
            dataContext.SaveChanges();
            }
        }
    } 

        
