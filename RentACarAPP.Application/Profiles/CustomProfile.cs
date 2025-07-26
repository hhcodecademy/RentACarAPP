using AutoMapper;

using RentACarAPP.Contract.Dtos;
using RentACarAPP.Contract.Dtos.External;
using RentACarAPP.Domain.Entity;

namespace RentACarAPP.Application.Profiles
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<BrandDTO, Brand>().ReverseMap();
            CreateMap<Brand, BrandResponseDto>()
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.LogoUrl))
                .ReverseMap();
            CreateMap<LogData, LogDataDTO>().ReverseMap();

            CreateMap<ProductInboundDto, Product>().ReverseMap();
            CreateMap<Product,ProductDTO>().ReverseMap();
        }
    }
}
