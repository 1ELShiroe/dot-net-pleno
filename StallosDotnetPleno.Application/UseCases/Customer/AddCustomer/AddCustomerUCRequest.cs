using StallosDotnetPleno.Application.Boundaries;
using StallosDotnetPleno.Application.Boundaries.Customer;

using Model = StallosDotnetPleno.Domain.Models.Customer;

namespace StallosDotnetPleno.Application.UseCases.Customer.AddCustomer
{
    public class AddCustomerUCRequest(Model.Customer customer)
    {
        public OutputPort<AddCustomerOPP> OutputPort { get; private set; }
        public Model.Customer Customer { get; } = customer;
        public AddCustomerOPP? CustomerOPP { get; private set; }

        public void SetOPP(AddCustomerOPP opp) => CustomerOPP = opp;
        public void SetOutputPort(OutputPort<AddCustomerOPP> outputPort) => OutputPort = outputPort;
    }
}