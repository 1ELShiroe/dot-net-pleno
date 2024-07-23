using StallosDotnetPleno.Domain.Models.Customer;

namespace StallosDotnetPleno.Application.UseCases.Customer.PutCustomer.Handlers
{
    public class MountCustomerHandler : Handler<PutCustomerUCRequest>
    {
        public override void ProcessRequest(PutCustomerUCRequest req)
        {
            Console.WriteLine(HandlerName, "Starting process");

            var addresses = req.NewCustomer.Addresses?.Select(a =>
                CustomerAddressModel.New(
                    req.Customer!.Id,
                    a.ZipCode ?? string.Empty,
                    a.Street ?? string.Empty,
                    a.Number ?? string.Empty,
                    a.Neighborhood ?? string.Empty,
                    a.City ?? string.Empty,
                    a.UF ?? string.Empty))
                .ToList();

            var customer = CustomerModel.New(
                req.Customer!.Type,
                req.NewCustomer.Name ?? req.Customer.Name,
                req.Customer.Document,
                req.Customer!.Addresses);

            if (addresses?.Count >= 1)
            {
                customer.SetAddresses(addresses);
            }

            customer.Id = req.Customer!.Id;

            req.SetCustomer(customer);

            Successor?.ProcessRequest(req);
        }
    }
}