using StallosDotnetPleno.Application.Boundaries.Customer;
using StallosDotnetPleno.Application.Boundaries;
using Microsoft.AspNetCore.Mvc;

namespace StallosDotnetPleno.Api.UseCases.Customer.AddCustomer
{
    public class AddCustomerPresenter : OutputPort<AddCustomerOPP>
    {
        public IActionResult ViewModel { get; private set; } = new ObjectResult(new { StatusCode = 500 });

        public override void Error(string message)
        {
            var problemDetails = new ProblemDetails()
            {
                Title = "An error occurred",
                Detail = message
            };

            ViewModel = new BadRequestObjectResult(problemDetails);
        }

        public override void NotAuthorized(string message) => ViewModel = new UnauthorizedObjectResult(message);

        public override void NotFound(string message) => ViewModel = new NotFoundObjectResult(message);

        public override void Standard(AddCustomerOPP opp)
        {
            var customer = opp.Data.Customer;

            var response = new AddCustomerResponse(
                opp.Message,
                new(
                    customer.Id,
                    customer.Type.ToString(),
                    customer.Name,
                    customer.Document,
                    customer.Addresses.Select(ad =>
                    new AddCustomerAddressResponse(
                        ad.ZipCode,
                        ad.Street,
                        ad.Neighborhood,
                        ad.City,
                        ad.UF
                    )).ToArray(),
                [.. customer.Histories]
                )
            );

            ViewModel = new OkObjectResult(response) { StatusCode = 201 };
        }
    }
}