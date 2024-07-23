using StallosDotnetPleno.Application.Interfaces.Services;

namespace StallosDotnetPleno.Application.UseCases.Customer.PutCustomer.Handlers
{
    public class ValidateCustomerHandler(
        INotificationService Notification) : Handler<PutCustomerUCRequest>
    {
        public override void ProcessRequest(PutCustomerUCRequest req)
        {
            Console.WriteLine(HandlerName, "Starting validation process for customer update");

            Console.WriteLine(req.Customer!.Addresses.Any(a => !a.IsValid));

            if (!req.Customer.IsValid || req.Customer.Addresses.Any(a => !a.IsValid))
            {
                if (!req.Customer.IsValid)
                {
                    Notification.AddNotifications(req.Customer.ValidationResult!);
                    return;
                }

                Console.WriteLine(req.Customer.Addresses.Where(a => !a.IsValid).Count());

                foreach (var address in req.Customer.Addresses.Where(a => !a.IsValid))
                {
                    Notification.AddNotifications(address.ValidationResult!);
                    return;
                }
            }

            Console.WriteLine(HandlerName, "Validation succeeded, proceeding to next handler");
            Successor?.ProcessRequest(req);
        }
    }
}
