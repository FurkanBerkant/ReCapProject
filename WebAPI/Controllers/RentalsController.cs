using Business.Abstract;
using Entites.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RentalsController : Controller
    {
        readonly IRentalService rentalService;

        public RentalsController(IRentalService rentalService)
        {
            this.rentalService = rentalService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = rentalService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Data);
        }
        [HttpPost]
        public IActionResult Post(Rental rental)
        {
            var result = rentalService.Add(rental);
            if (result.Success)
            {
                return Created(result.Message, rental);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getByRentalId")]
        public IActionResult GetByRentalId(int id)
        {
            var result = rentalService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPut("update")]
        public IActionResult Update(Rental rental)
        {
            var result = rentalService.Update(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = rentalService.Delete(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
