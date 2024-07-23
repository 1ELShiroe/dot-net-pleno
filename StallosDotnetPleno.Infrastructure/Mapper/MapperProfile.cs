using AutoMapper;

using Model = StallosDotnetPleno.Domain.Models.Customer;
using Entity = StallosDotnetPleno.Infrastructure.Database.Entities.Customer;

namespace StallosDotnetPleno.Infrastructure.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Model.Customer, Entity.Customer>().ReverseMap();
            CreateMap<Model.CustomerAddress, Entity.CustomerAddress>().ReverseMap();
        }
    }
}