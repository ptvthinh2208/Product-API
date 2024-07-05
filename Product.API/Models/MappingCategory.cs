using AutoMapper;
using Product.Core.Dto;
using Product.Core.Entities;

namespace Product.API.Models
{
    public class MappingCategory : Profile
    {
        public MappingCategory()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<ListCategoryDto, Category>().ReverseMap();
        }
    }
}
