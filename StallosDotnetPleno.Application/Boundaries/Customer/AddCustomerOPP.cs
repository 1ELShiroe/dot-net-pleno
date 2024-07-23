using Model = StallosDotnetPleno.Domain.Models.Customer;

namespace StallosDotnetPleno.Application.Boundaries.Customer
{
    public record AddCustomerOPP(string Message, AddCustomerDataOPP Data);
    public record AddCustomerDataOPP(Model.Customer Customer);
}