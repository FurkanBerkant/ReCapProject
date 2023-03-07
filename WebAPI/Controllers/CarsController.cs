using Business.Abstract;
using Entites.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CarsController : Controller
    {
        readonly ICarService carService;

        public CarsController(ICarService carService)
        {
            this.carService = carService;
        }
        [HttpGet]
        public IActionResult GetAll() {
            var result = carService.GetAll();
            if (result.Succes)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Data);
        }
        [HttpPost]
        public IActionResult Post(Car car)
        {
            var result = carService.Add(car);
            if (result.Succes)
            {
                return Created(result.Message,car);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getByCarId")]
        public IActionResult GetByCarId(int id) 
        {
            var result = carService.GetById(id);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPut("update")]
        public IActionResult Update(Car car) 
        {
            var result = carService.Update(car);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Car car) 
        {
            var result = carService.Delete(car);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
