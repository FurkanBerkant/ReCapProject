using Business.Abstract;
using Entites.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CarImagesController : Controller
    {
        readonly ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Succes)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Data);
        }
        [HttpPost]
        public IActionResult Post(CarImages carImages)
        {
            var result = _carImageService.Add(carImages);
            if (result.Succes)
            {
                return Created(result.Message, carImages);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getByCarImageId")]
        public IActionResult GetByCarImageId(int id)
        {
            var result = _carImageService.GetById(id);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPut("update")]
        public IActionResult Update(CarImages carImages)
        {
            var result = _carImageService.Update(carImages);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(CarImages carImages)
        {
            var result = _carImageService.Delete(carImages);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
