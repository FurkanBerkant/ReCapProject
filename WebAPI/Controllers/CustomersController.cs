using Business.Abstract;
using Entites.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = customerService.GetAll();
            if (result.Succes)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Data);
        }
        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            var result = customerService.Add(customer);
            if (result.Succes)
            {
                return Created(result.Message, customer);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getByCustomerId")]
        public IActionResult GetByCustomerId(int id)
        {
            var result = customerService.GetById(id);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPut("update")]
        public IActionResult Update(Customer customer)
        {
            var result = customerService.Update(customer);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Customer customer)
        {
            var result = customerService.Delete(customer);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
