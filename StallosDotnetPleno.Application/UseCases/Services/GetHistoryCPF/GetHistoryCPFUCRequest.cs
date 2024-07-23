using Model = StallosDotnetPleno.Domain.Models.Customer;

namespace StallosDotnetPleno.Application.UseCases.Services.GetHistoryCPF
{
    public class GetHistoryCPFUCRequest
    {
        public List<Model.Customer> Customers { get; private set; } = [];

        public void SetCustomers(List<Model.Customer> customers) => Customers = customers;
    }
}