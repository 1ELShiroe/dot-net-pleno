using StallosDotnetPleno.Domain.Models.Logs;
using StallosDotnetPleno.Domain.Enums;

namespace StallosDotnetPleno.Application.UseCases.Customer.RemoveCustomer
{
    public class RemoveCustomerUCRequest(int id)
    {
        public int Id { get; } = id;
        public List<LogModel> Logs { get; set; } = [];

        public void Process(string service, string message)
           => Logs.Add(LogModel.New(TypeLog.Process, message, "", service, DateTime.Now));

        public void Error(string service, string message, string stackTrace)
            => Logs.Add(LogModel.New(TypeLog.Error, message, stackTrace, service, DateTime.Now));

        public void Info(string service, string message)
            => Logs.Add(LogModel.New(TypeLog.Information, message, "", service, DateTime.Now));
    }
}