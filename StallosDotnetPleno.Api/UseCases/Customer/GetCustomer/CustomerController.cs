using StallosDotnetPleno.Application.UseCases.Customer.GetCustomer;
using StallosDotnetPleno.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace StallosDotnetPleno.Api.UseCases.Customer.GetCustomer
{
    [ApiController]
    [Route("api/pessoa")]
    public class CustomerController(
        IUseCase<GetCustomerUCRequest> UseCase,
        GetCustomerPresenter Presenter) : ControllerBase
    {
        [HttpGet]
        public IActionResult Update([FromQuery] int id)
        {
            var request = new GetCustomerUCRequest(id);
            UseCase.Execute(request);

            return Presenter.ViewModel;
        }
    }
}