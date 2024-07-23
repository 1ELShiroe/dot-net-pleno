using StallosDotnetPleno.Application.Boundaries.Customer;
using StallosDotnetPleno.Application.Boundaries;

using Model = StallosDotnetPleno.Domain.Models.Customer;

namespace StallosDotnetPleno.Application.UseCases.Customer.PutCustomer
{
    public class PutCustomerUCRequest(PutCustomer upCustomer)
    {
        public OutputPort<PutCustomerOPP>? OutputPort { get; private set; }
        public Model.Customer? Customer { get; private set; }
        public PutCustomer NewCustomer { get; private set; } = upCustomer;

        public void SetOutputPort(OutputPort<PutCustomerOPP> outputPort) => OutputPort = outputPort;
        public void SetCustomer(Model.Customer customer) => Customer = customer;
    }

    public record PutCustomer(string? Name, string Document, PutCustomerAddress[]? Addresses);
    public record PutCustomerAddress(string? ZipCode, string? Street, string? Number, string? Neighborhood, string? City, string? UF);
}