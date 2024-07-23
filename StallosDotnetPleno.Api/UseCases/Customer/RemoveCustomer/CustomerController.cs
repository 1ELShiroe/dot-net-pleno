using Microsoft.AspNetCore.Mvc;

namespace StallosDotnetPleno.Api.UseCases.Customer.RemoveCustomer
{
    [ApiController]
    [Route("api/pessoa")]
    public class CustomerController(
        RemoveCustomerPresenter Presenter) : ControllerBase
    {
        [HttpDelete]
        public IActionResult Update([FromBody] RemoveCustomerRequest payload)
        {

            return Presenter.ViewModel;
        }
    }

    public record RemoveCustomerRequest(string Document);
    public record RemoveCustomerResponse(string Message);
}