using StallosDotnetPleno.Application.UseCases.Customer.AddCustomer;
using StallosDotnetPleno.Application.Interfaces.Services;
using StallosDotnetPleno.Domain.Models.Customer;
using StallosDotnetPleno.Application.UseCases;
using Microsoft.AspNetCore.Mvc;


namespace StallosDotnetPleno.Api.UseCases.Customer.AddCustomer
{
    [ApiController]
    [Route("api/pessoa")]
    public class CustomerController(
            INotificationService Notification,
            IUseCase<AddCustomerUCRequest> UseCase,
            AddCustomerPresenter Presenter) : ControllerBase
    {
        [HttpPost]
        public IActionResult Add([FromBody] AddCustomerRequest payload)
        {
            var customer = CustomerModel.New(payload.Type, payload.Name, payload.Document, []);

            var addresses = payload.Addresses
                    .Select(a =>
                        CustomerAddressModel.New(customer.Id, a.ZipCode, a.Street, a.Number, a.Neighborhood, a.City, a.UF))
                    .ToList();

            customer.SetAddresses(addresses);

            if (!customer.IsValid || addresses.Any(a => !a.IsValid))
            {
                if (!customer.IsValid)
                {
                    Notification.AddNotifications(customer.ValidationResult!);
                    return Presenter.ViewModel;
                }

                foreach (var address in addresses.Where(a => !a.IsValid))
                {
                    Notification.AddNotifications(address.ValidationResult!);
                }

                return Presenter.ViewModel;
            }

            var request = new AddCustomerUCRequest(customer);
            UseCase.Execute(request);

            return Presenter.ViewModel;
        }
    }
}