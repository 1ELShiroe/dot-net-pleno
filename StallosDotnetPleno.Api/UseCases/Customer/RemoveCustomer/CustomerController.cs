using StallosDotnetPleno.Application.UseCases.Customer.RemoveCustomer;
using StallosDotnetPleno.Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace StallosDotnetPleno.Api.UseCases.Customer.RemoveCustomer
{
    [ApiController]
    [Authorize]
    [Route("api/pessoa")]
    public class CustomerController(
        RemoveCustomerPresenter Presenter,
        IUseCase<RemoveCustomerUCRequest> UseCase) : ControllerBase
    {
        [HttpDelete("{id}")]
        public IActionResult Update(int id)
        {
            var request = new RemoveCustomerUCRequest(id);
            UseCase.Execute(request);

            return Presenter.ViewModel;
        }
    }

    public record RemoveCustomerRequest(string Document);
    public record RemoveCustomerResponse(string Message);
}