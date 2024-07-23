using StallosDotnetPleno.Domain.Models.Customer;

namespace StallosDotnetPleno.Application.Boundaries.Customer
{
    public record PutCustomerOPP(string Message, PutCustomerDataOPP Data);
    public record PutCustomerDataOPP(CustomerModel Customer);
}