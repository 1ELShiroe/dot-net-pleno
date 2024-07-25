using StallosDotnetPleno.Domain.Models.Customer;

namespace StallosDotnetPleno.Application.Interfaces.Services
{
    public interface IJWTService
    {
        public string Generate(CustomerModel model);
    }
}