﻿using AutoMapper;
using MeepProducts.Dto;
using MeepProducts.Models;

namespace MeepProducts.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Local, LocalDto>();
            CreateMap<Local, PortalDto>();
            CreateMap<Categoria, CategoriaDto>();
            CreateMap<Produto, ProdutoDto>();
            CreateMap<Portal, PortalDto>();
        }
    }
}