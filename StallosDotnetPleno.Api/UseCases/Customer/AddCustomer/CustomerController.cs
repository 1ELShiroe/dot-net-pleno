using StallosDotnetPleno.Application.Interfaces.Services;
using StallosDotnetPleno.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

using Model = StallosDotnetPleno.Domain.Models.Customer;

namespace StallosDotnetPleno.Api.UseCases.Customer.AddCustomer
{
    [ApiController]
    [Route("api/pessoa")]
    public class CustomerController(
            INotificationService Notification) : ControllerBase
    {
        [HttpPost]
        public IActionResult Add([FromBody] CustomerRequest payload)
        {
            var customer = Model.Customer.New(payload.Type, payload.Name, payload.Document, []);

            var addresses = payload.Addresses
                    .Select(a =>
                        Model.CustomerAddress.New(customer.Id, a.ZipCode, a.Street, a.Number, a.Neighborhood, a.City, a.UF))
                    .ToList();

            customer.SetAddresses(addresses);

            if (!customer.IsValid || addresses.Any(a => !a.IsValid))
            {
                Notification.AddNotifications(customer.ValidationResult!);

                foreach (var address in addresses.Where(a => !a.IsValid))
                {
                    Notification.AddNotifications(address.ValidationResult!);
                }

                return BadRequest();
            }

            return Ok(payload);
        }

        public record CustomerAddressRequest(string ZipCode, string Street, string Number, string Neighborhood, string City, string UF);
        public record CustomerRequest(TypeUser Type, string Name, string Document, CustomerAddressRequest[] Addresses);
    }
}