using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StallosDotnetPleno.Application.UseCases;
using StallosDotnetPleno.Application.UseCases.Customer.PutCustomer;

namespace StallosDotnetPleno.Api.UseCases.Customer.PutCustomer
{
    [ApiController]
    [Authorize]
    [Route("api/pessoa")]
    public class CustomerController(
        PutCustomerPresenter Presenter,
        IUseCase<PutCustomerUCRequest> UseCase) : ControllerBase
    {
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] PutCustomerRequest payload)
        {
            var request = new PutCustomerUCRequest(new(
                payload.Name,
                id,
                payload.Addresses?.Select(e =>
                    new PutCustomerAddress(e.ZipCode, e.Street, e.Number, e.Neighborhood, e.City, e.UF))
                    .ToArray()));

            UseCase.Execute(request);

            return Presenter.ViewModel;
        }
    }
}