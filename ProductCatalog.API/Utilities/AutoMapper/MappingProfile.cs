using AutoMapper;
using ProductCatalog.Entities.DTOs;
using ProductCatalog.Entities.Models;

namespace ProductCatalog.API.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductCreateDto, Product>();    
        }
    }
}
