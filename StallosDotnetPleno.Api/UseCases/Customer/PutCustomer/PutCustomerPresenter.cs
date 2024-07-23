using StallosDotnetPleno.Application.Boundaries.Customer;
using StallosDotnetPleno.Application.Boundaries;
using Microsoft.AspNetCore.Mvc;

namespace StallosDotnetPleno.Api.UseCases.Customer.PutCustomer
{
    public class PutCustomerPresenter : OutputPort<PutCustomerOPP>
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

        public override void Standard(PutCustomerOPP opp)
        {
            var customer = opp.Data.Customer;

            var response = new PutCustomerResponse(
                opp.Message,
                new(
                    customer.Id,
                    customer.Name,
                    customer.Document,
                    customer.Addresses.Select(ad =>
                    new PutCustomerAddressResponse(
                        ad.ZipCode,
                        ad.Street,
                        ad.Number,
                        ad.Neighborhood,
                        ad.City,
                        ad.UF
                    )).ToArray()
                )
            );

            ViewModel = new OkObjectResult(response);
        }
    }
}