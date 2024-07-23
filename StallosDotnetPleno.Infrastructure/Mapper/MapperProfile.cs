using StallosDotnetPleno.Infrastructure.Database.Entities.Customer;
using StallosDotnetPleno.Domain.Models.Customer;
using AutoMapper;

namespace StallosDotnetPleno.Infrastructure.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CustomerModel, CustomerEntity>().ReverseMap();
            CreateMap<CustomerAddressModel, CustomerAddressEntity>().ReverseMap();
        }
    }
}