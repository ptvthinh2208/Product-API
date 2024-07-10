using AutoMapper;
using Product.Core.Dto;
using Product.Core.Entities;

namespace Product.API.Models
{
    public class MappingProducts : Profile
    {
        public MappingProducts()
        {
            // CreateMap<ProductDto,Products>().ReverseMap();
            CreateMap<Products, ProductDto>()
                .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category.Name))
                //.ForMember(d => d.ProductPicture, o => o.MapFrom<ProductUrlResolver>())
                .ReverseMap();

            CreateMap<CreateProductDto, Products>().ReverseMap();
            //CreateMap<Products, UpdateProductDto>().ReverseMap();




        }
    }
}
