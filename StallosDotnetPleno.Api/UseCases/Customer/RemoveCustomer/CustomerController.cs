using StallosDotnetPleno.Application.UseCases.Customer.RemoveCustomer;
using StallosDotnetPleno.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace StallosDotnetPleno.Api.UseCases.Customer.RemoveCustomer
{
    [ApiController]
    [Route("api/pessoa")]
    public class CustomerController(
        RemoveCustomerPresenter Presenter,
        IUseCase<RemoveCustomerUCRequest> UseCase) : ControllerBase
    {
        [HttpDelete]
        public IActionResult Update([FromBody] RemoveCustomerRequest payload)
        {
            var request = new RemoveCustomerUCRequest(payload.Document);
            UseCase.Execute(request);

            return Presenter.ViewModel;
        }
    }

    public record RemoveCustomerRequest(string Document);
    public record RemoveCustomerResponse(string Message);
}