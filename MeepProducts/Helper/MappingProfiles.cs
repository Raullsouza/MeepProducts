using AutoMapper;
using MeepProducts.Dto;
using MeepProducts.Models;

namespace MeepProducts.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Local, LocalDto>();
            CreateMap<LocalDto, Local>();
            CreateMap<Categoria, CategoriaDto>();
            CreateMap<Produto, ProdutoDto>();
            CreateMap<ProdutoDto, Produto>();
            CreateMap<Portal, PortalDto>();
            CreateMap<PortalDto, Portal>();
            CreateMap<Produto, CategoriaDto>();
            CreateMap<CategoriaDto, Categoria>();        
        }
    }
}
