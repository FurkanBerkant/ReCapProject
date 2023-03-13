using Business.Abstract;
using Core.Utilites.Results;
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
            return StatusCode(result.Success ? 200 : 400 , result);
        }

        [HttpPost]
        public IActionResult Post(IFormFile file, [FromForm] CarImages carImages)
        {
            var result = _carImageService.Add(file,carImages);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpGet("getByCarImageId")]
        public IActionResult GetByCarImageId(int id)
        {
            var result = _carImageService.GetById(id);
            return StatusCode(result.Success? 200 : 400 , result);
        }

        [HttpPut("update")]
        public IActionResult Update([FromForm(Name = "Image")] IFormFile file, 
                                            [FromForm] CarImages carImages)
        {
            var result = _carImageService.Update(file, carImages);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(CarImages carImages)
        {
            var result = _carImageService.Delete(carImages);
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
