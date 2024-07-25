using StallosDotnetPleno.Application.Boundaries.Customer;
using StallosDotnetPleno.Application.Boundaries;
using StallosDotnetPleno.Domain.Models.Customer;
using StallosDotnetPleno.Domain.Models.Logs;
using StallosDotnetPleno.Domain.Enums;

namespace StallosDotnetPleno.Application.UseCases.Customer.PutCustomer
{
    public class PutCustomerUCRequest(PutCustomer upCustomer)
    {
        public OutputPort<PutCustomerOPP>? OutputPort { get; private set; }
        public CustomerModel? Customer { get; private set; }
        public PutCustomer NewCustomer { get; private set; } = upCustomer;
        public List<LogModel> Logs { get; set; } = [];

        public void Process(string service, string message)
           => Logs.Add(LogModel.New(TypeLog.Process, message, "", service, DateTime.Now));

        public void Error(string service, string message, string stackTrace)
            => Logs.Add(LogModel.New(TypeLog.Error, message, stackTrace, service, DateTime.Now));

        public void Info(string service, string message)
            => Logs.Add(LogModel.New(TypeLog.Information, message, "", service, DateTime.Now));

        public void SetOutputPort(OutputPort<PutCustomerOPP> outputPort) => OutputPort = outputPort;
        public void SetCustomer(CustomerModel customer) => Customer = customer;
    }

    public record PutCustomer(string? Name, int Id, PutCustomerAddress[]? Addresses);
    public record PutCustomerAddress(string? ZipCode, string? Street, string? Number, string? Neighborhood, string? City, string? UF);
}