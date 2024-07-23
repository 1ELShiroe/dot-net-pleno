using StallosDotnetPleno.Domain.Models.Customer;

namespace StallosDotnetPleno.Application.UseCases.Services.GetHistoryCPF
{
    public class GetHistoryCPFUCRequest
    {
        public List<CustomerModel> Customers { get; private set; } = [];

        public void SetCustomers(List<CustomerModel> customers) => Customers = customers;
    }
}