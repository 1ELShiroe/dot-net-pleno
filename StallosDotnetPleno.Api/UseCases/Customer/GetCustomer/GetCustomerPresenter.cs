using StallosDotnetPleno.Application.Boundaries.Customer;
using StallosDotnetPleno.Application.Boundaries;
using Microsoft.AspNetCore.Mvc;

namespace StallosDotnetPleno.Api.UseCases.Customer.GetCustomer
{
    public class GetCustomerPresenter : OutputPort<GetCustomerOPP>
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

        public override void Standard(GetCustomerOPP opp)
        {
            var customer = opp.Data.Customer;

            var response = new GetCustomerResponse(
                opp.Message,
                new(new(
                    customer.Id,
                    customer.Type.ToString(),
                    customer.Name,
                    customer.Document,
                    customer.Addresses.Select(ad =>
                    new ResponseGetCustomerAddress(
                        ad.ZipCode,
                        ad.Street,
                        ad.Neighborhood,
                        ad.City,
                        ad.UF
                    )).ToArray(),
                    [.. customer.Histories]),
                    opp.Data.Token
                )
            );

            ViewModel = new OkObjectResult(response) { StatusCode = 201 };
        }
    }
}