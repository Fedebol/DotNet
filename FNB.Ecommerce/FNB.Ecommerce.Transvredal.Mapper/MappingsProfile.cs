using AutoMapper;
using FNB.Ecommerce.Domain.Entity;
using FNB.Ecommerce.Application.DTO;

namespace FNB.Ecommerce.Transvredal.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Customers, CustomersDTO>().ReverseMap();

           /* Mapeo de campo a campo
            * CreateMap<Customers, CustomersDTO>().ReverseMap()
                .ForMember(destination => destination.CustomerId, source => source.MapFrom(src => src.CustomerId))
                .ForMember(destination => destination.CompanyName, source => source.MapFrom(src => src.CompanyName))
                .ForMember(destination => destination.ContactName, source => source.MapFrom(src => src.ContactName))
                .ForMember(destination => destination.ContactTitle, source => source.MapFrom(src => src.ContactTitle))
                .ForMember(destination => destination.Address, source => source.MapFrom(src => src.Address))
                .ForMember(destination => destination.City, source => source.MapFrom(src => src.City))
                .ForMember(destination => destination.Region, source => source.MapFrom(src => src.Region))
                .ForMember(destination => destination.PostalCode, source => source.MapFrom(src => src.PostalCode))
                .ForMember(destination => destination.Country, source => source.MapFrom(src => src.Country))
                .ForMember(destination => destination.Phone, source => source.MapFrom(src => src.Phone))
                .ForMember(destination => destination.Fax, source => source.MapFrom(src => src.Fax));
            */


        }
    }
}