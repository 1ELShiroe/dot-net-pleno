using Model = StallosDotnetPleno.Domain.Models.Customer;

namespace StallosDotnetPleno.Application.Boundaries.Customer
{
    public record GetCustomerOPP(string Message, GetCustomerDataOPP Data);
    public record GetCustomerDataOPP(Model.Customer Customer);
}