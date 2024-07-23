using StallosDotnetPleno.Domain.Models.Customer;

namespace StallosDotnetPleno.Application.UseCases.Services.GetHistoryCNPJ
{
    public class GetHistoryCNPJUCRequest
    {
        public List<CustomerModel> Customers { get; private set; } = [];

        public void SetCustomers(List<CustomerModel> customers) => Customers = customers;
    }
}