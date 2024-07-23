using Microsoft.AspNetCore.Mvc;

namespace StallosDotnetPleno.Api.UseCases.Customer.PutCustomer
{
    [ApiController]
    [Route("api/pessoa")]
    public class CustomerController(
        PutCustomerPresenter Presenter) : ControllerBase
    {
        [HttpPut]
        public IActionResult Update([FromBody] PutCustomerRequest payload)
        {
            return Presenter.ViewModel;
        }
    }
}