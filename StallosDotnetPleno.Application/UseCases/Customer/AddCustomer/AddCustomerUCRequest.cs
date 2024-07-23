using StallosDotnetPleno.Application.Boundaries.Customer;
using StallosDotnetPleno.Application.Boundaries;
using StallosDotnetPleno.Domain.Models.Customer;

namespace StallosDotnetPleno.Application.UseCases.Customer.AddCustomer
{
    public class AddCustomerUCRequest(CustomerModel customer)
    {
        public OutputPort<AddCustomerOPP>? OutputPort { get; private set; }
        public CustomerModel Customer { get; } = customer;
        
        public void SetOutputPort(OutputPort<AddCustomerOPP> outputPort) => OutputPort = outputPort;
    }
}