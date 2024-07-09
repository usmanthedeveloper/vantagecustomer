using Microsoft.AspNetCore.Mvc;
using VantageOnlineCustomer.Classes.CustomerCore;
using CustomerBusinessLogic.CustomerService;

// Author: Usman Chaudhry
// Date: 09/07/2024
// Description: Typical CRUD entry for Customer

namespace CustomerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("customer")]
        public ActionResult<IEnumerable<Customer>> GetAllCustomers()
        {
            var customers = _customerService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("customer/{id}")]
        public ActionResult<Customer> GetCustomerById(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost("customer")]
        public ActionResult CreateCustomer([FromBody] Customer customer)
        {
            _customerService.CreateCustomer(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.ID }, customer);
        }

        [HttpPut("customer/{id}")]
        public ActionResult UpdateCustomer(int id, [FromBody] Customer customer)
        {
            if (id != customer.ID)
            {
                return BadRequest();
            }

            _customerService.UpdateCustomer(customer);
            return NoContent();
        }

        [HttpDelete("customer/{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            _customerService.DeleteCustomer(id);
            return NoContent();
        }

    }
}
