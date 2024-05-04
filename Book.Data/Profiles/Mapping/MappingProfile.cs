using AutoMapper;
using Books.Data.Entities;
using Books.Data.Profiles.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Data.Profiles.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //mapping Domain -> Dto
            CreateMap<Product, ProductDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Cover, CoverDto>();
            CreateMap<Author, AuthorDto>();
            CreateMap<ApplicationUser, ApplicationUserDto>();
            CreateMap<Company, CompanyDto>();
            CreateMap<ShopingCart, ShoppingCartDto>();
            CreateMap<OrderHeader, OrderHeaderDto>();
            CreateMap<OrderDetail, OrderDetailDto>();

            //mapping Dto -> Domain
            CreateMap<ProductDto, Product>().ForMember(p => p.Id, opt => opt.Ignore());
            CreateMap<CategoryDto, Category>().ForMember(p => p.Id, opt => opt.Ignore());
            CreateMap<CoverDto, Cover>().ForMember(p => p.Id, opt => opt.Ignore());
            CreateMap<AuthorDto, Author>().ForMember(p => p.Id, opt => opt.Ignore());
            CreateMap<ApplicationUserDto, ApplicationUser>().ForMember(p => p.Id, opt => opt.Ignore());
            CreateMap<CompanyDto, Company>().ForMember(p => p.Id, opt => opt.Ignore());
            CreateMap<ShoppingCartDto, ShopingCart>().ForMember(p => p.Id, opt => opt.Ignore());
            CreateMap<OrderHeaderDto, OrderHeader>().ForMember(p => p.Id, opt => opt.Ignore());
            CreateMap<OrderDetailDto, OrderDetail>().ForMember(p => p.Id, opt => opt.Ignore());

        }
    }
}
