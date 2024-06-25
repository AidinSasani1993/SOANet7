using AutoMapper;
using OnlineShopping.Application.Dtos.Customer;
using OnlineShopping.Application.Dtos.Person;
using OnlineShopping.Application.Dtos.ProductCategory;
using OnlineShopping.Domain.Entities;

namespace OnlineShopping.Application.Profiles
{
    public class AutoMap : Profile
    {
        public AutoMap()
        {
            CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();
            
            CreateMap<Person, PersonDto>().ReverseMap();

            CreateMap<Customer, CustomerDto>().ReverseMap();

            CreateMap<Person, IdPersonDto>().ReverseMap();
        }
    }
}
