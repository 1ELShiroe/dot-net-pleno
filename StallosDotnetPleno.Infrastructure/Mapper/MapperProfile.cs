using StallosDotnetPleno.Domain.Models.Customer;
using AutoMapper;

using Entity = StallosDotnetPleno.Infrastructure.Database.Entities.Customer;

namespace StallosDotnetPleno.Infrastructure.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CustomerModel, Entity.Customer>().ReverseMap();
            CreateMap<CustomerAddressModel, Entity.CustomerAddress>().ReverseMap();
        }
    }
}