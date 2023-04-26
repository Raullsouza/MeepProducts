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
                                            new Produto { Nome = "Água", Descricao = "Sem Gás" , DataCriacao = DateTime.Now, Preco = 10},
                                            new Produto { Nome = "Água", Descricao = "Com Gás", DataCriacao = DateTime.Now, Preco = 100 },
                                            new Produto { Nome = "Hamburguer", Descricao = "Frango", DataCriacao = DateTime.Now, Preco = 500},
                                            new Produto { Nome = "Pizza", Descricao = "Calabresa", DataCriacao = DateTime.Now, Preco = 17},
                                        }
                                    },
                                     new Categoria
                                    {
                                        Nome = "Comidas",
                                        Produtos = new List<Produto>()
                                        {
                                            new Produto { Nome = "Arroz", Descricao = "branco", DataCriacao = DateTime.Now, Preco = 810},
                                            new Produto { Nome = "Feijão", Descricao = "Preto", DataCriacao = DateTime.Now, Preco = 10 },
                                            new Produto { Nome = "Farinha", Descricao = "trigo", DataCriacao = DateTime.Now, Preco = 190},
                                            new Produto { Nome = "Torta", Descricao = "Frango", DataCriacao = DateTime.Now, Preco = 110},

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
                                            new Produto { Nome = "Água", Descricao = "Sem Gás", DataCriacao = DateTime.Now, Preco = 150 },
                                            new Produto { Nome = "Coca cola", Descricao = "Refrigerante", DataCriacao = DateTime.Now, Preco = 16 },
                                            new Produto { Nome = "Vodka", Descricao = "Alcoolica", DataCriacao = DateTime.Now, Preco = 140 }
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
                                            new Produto { Nome = "Cerveja", Descricao = "Puro malte", DataCriacao = DateTime.Now, Preco = 14 },
                                            new Produto { Nome = "Cachaça", Descricao = "Amarela", DataCriacao = DateTime.Now, Preco = 5 },
                                            new Produto { Nome = "Vodka", Descricao = "Ciroc", DataCriacao = DateTime.Now, Preco = 15},
                                            new Produto { Nome = "Corote", Descricao = "Saborizado", DataCriacao = DateTime.Now, Preco = 20},
                                        }
                                    },
                                     new Categoria
                                    {
                                        Nome = "Churrasco",
                                        Produtos = new List<Produto>()
                                        {
                                            new Produto { Nome = "Picanha", Descricao = "Boi", DataCriacao = DateTime.Now, Preco = 20},
                                            new Produto { Nome = "Asa", Descricao = "Frango", DataCriacao = DateTime.Now, Preco = 35 },
                                            new Produto { Nome = "Linguiça", Descricao = "Porco", DataCriacao = DateTime.Now, Preco = 41},
                                            new Produto { Nome = "Lombo", Descricao = "Proco", DataCriacao = DateTime.Now, Preco = 54},

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
                                            new Produto { Nome = "Vodka", Descricao = "Absolut", DataCriacao = DateTime.Now, Preco = 66 },
                                            new Produto { Nome = "Whisky", Descricao = "Red Label", DataCriacao = DateTime.Now, Preco = 14 },
                                            new Produto { Nome = "Pinga", Descricao = "Da roça", DataCriacao = DateTime.Now, Preco = 78 }
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new Local()
                    {
                        Cidade = "Rio De Janeiro",
                        Estado = "Rio De Janeiro",
                        Portais = new List<Portal>()
                        {
                            new Portal
                            {
                                Nome = "Maracana",
                                Categorias = new List<Categoria>()
                                {
                                    new Categoria
                                    {
                                        Nome = "Bolos",
                                        Produtos = new List<Produto>()
                                        {
                                            new Produto { Nome = "Chocolate", Descricao = "8 pedaços", DataCriacao = DateTime.Now, Preco = 189 },
                                            new Produto { Nome = "Morango", Descricao = "6 pedaços", DataCriacao = DateTime.Now, Preco = 45 },
                                            new Produto { Nome = "Abacaxi", Descricao = "8 pedaços", DataCriacao = DateTime.Now, Preco = 61},
                                            new Produto { Nome = "Banana", Descricao = "4 pedaços", DataCriacao = DateTime.Now, Preco = 72},
                                        }
                                    },
                                     new Categoria
                                    {
                                        Nome = "Espetos",
                                        Produtos = new List<Produto>()
                                        {
                                            new Produto { Nome = "Picanha", Descricao = "Boi", DataCriacao = DateTime.Now, Preco = 63},
                                            new Produto { Nome = "Coração", Descricao = "Frango", DataCriacao = DateTime.Now, Preco = 24 },
                                            new Produto { Nome = "Pernil", Descricao = "Porco", DataCriacao = DateTime.Now, Preco = 31},
                                            new Produto { Nome = "Lombo", Descricao = "Proco", DataCriacao = DateTime.Now, Preco = 74},

                                        }
                                    },
                                }
                            },
                            new Portal
                            {
                                Nome = "Villa Gourmet",
                                Categorias = new List<Categoria>()
                                {
                                    new Categoria
                                    {
                                        Nome = "Destilados",
                                        Produtos = new List<Produto>()
                                        {
                                            new Produto { Nome = "Vodka", Descricao = "Absolut", DataCriacao = DateTime.Now, Preco = 19 },
                                            new Produto { Nome = "Whisky", Descricao = "Red Label", DataCriacao = DateTime.Now, Preco = 32 },
                                            new Produto { Nome = "Pinga", Descricao = "Da roça", DataCriacao = DateTime.Now, Preco = 61 }
                                        }
                                    }
                                }
                            }
                        }
                    },
                     new Local()
                    {
                        Cidade = "Salvador",
                        Estado = "Bahia",
                        Portais = new List<Portal>()
                        {
                            new Portal
                            {
                                Nome = "Somando sabores",
                                Categorias = new List<Categoria>()
                                {
                                    new Categoria
                                    {
                                        Nome = "Sucos",
                                        Produtos = new List<Produto>()
                                        {
                                            new Produto { Nome = "Laranja", Descricao = "Natural", DataCriacao = DateTime.Now, Preco = 66 },
                                            new Produto { Nome = "Uva", Descricao = "Integral", DataCriacao = DateTime.Now, Preco = 97 },
                                            new Produto { Nome = "Morango", Descricao = "Polpa", DataCriacao = DateTime.Now, Preco = 98},
                                            new Produto { Nome = "Acerola", Descricao = "Polpa", DataCriacao = DateTime.Now, Preco = 47},
                                        }
                                    },
                                     new Categoria
                                    {
                                        Nome = "Churrasco",
                                        Produtos = new List<Produto>()
                                        {
                                            new Produto { Nome = "Picanha", Descricao = "Boi", DataCriacao = DateTime.Now, Preco =64},
                                            new Produto { Nome = "Asa", Descricao = "Frango", DataCriacao = DateTime.Now, Preco = 94 },
                                            new Produto { Nome = "Linguiça", Descricao = "Porco", DataCriacao = DateTime.Now, Preco = 67},
                                            new Produto { Nome = "Lombo", Descricao = "Proco", DataCriacao = DateTime.Now, Preco = 34},

                                        }
                                    },
                                }
                            },
                            new Portal
                            {
                                Nome = "Vibe Bar",
                                Categorias = new List<Categoria>()
                                {
                                    new Categoria
                                    {
                                        Nome = "Destilados",
                                        Produtos = new List<Produto>()
                                        {
                                            new Produto { Nome = "Vodka", Descricao = "Absolut", DataCriacao = DateTime.Now, Preco = 92 },
                                            new Produto { Nome = "Whisky", Descricao = "Red Label", DataCriacao = DateTime.Now, Preco = 157 },
                                            new Produto { Nome = "Pinga", Descricao = "Da roça", DataCriacao = DateTime.Now, Preco = 164 }
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

        
