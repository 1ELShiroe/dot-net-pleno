using StallosDotnetPleno.Application.Boundaries.Customer;
using StallosDotnetPleno.Application.Boundaries;
using StallosDotnetPleno.Domain.Models.Customer;
using StallosDotnetPleno.Domain.Models.Logs;
using StallosDotnetPleno.Domain.Enums;

namespace StallosDotnetPleno.Application.UseCases.Customer.AddCustomer
{
    public class AddCustomerUCRequest(CustomerModel customer)
    {
        public OutputPort<AddCustomerOPP>? OutputPort { get; private set; }
        public CustomerModel Customer { get; } = customer;
        public List<LogModel> Logs { get; set; } = [];

        public void Process(string service, string message)
           => Logs.Add(LogModel.New(TypeLog.Process, message, "", service, DateTime.Now));

        public void Error(string service, string message, string stackTrace)
            => Logs.Add(LogModel.New(TypeLog.Error, message, stackTrace, service, DateTime.Now));

        public void Info(string service, string message)
            => Logs.Add(LogModel.New(TypeLog.Information, message, "", service, DateTime.Now));

        public void SetOutputPort(OutputPort<AddCustomerOPP> outputPort) => OutputPort = outputPort;
    }
}