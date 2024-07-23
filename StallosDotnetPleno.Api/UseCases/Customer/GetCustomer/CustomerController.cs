using Microsoft.AspNetCore.Mvc;

namespace StallosDotnetPleno.Api.UseCases.Customer.GetCustomer
{
    [ApiController]
    [Route("api/pessoa")]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public IActionResult Update([FromQuery] int id)
        {
            return Ok();
        }
    }
}