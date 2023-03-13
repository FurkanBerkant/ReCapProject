using Business.Abstract;
using Entites.Concrete;
using Microsoft.AspNetCore.Mvc;
namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ColorsController : Controller
    {
        readonly IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _colorService.GetAll();
            if (result.Success)
            { 
                return Ok(result.Data);
            }
            return BadRequest(result.Data);
        }
        [HttpPost]
        public IActionResult Post(Color color)
        {
            var result = _colorService.Add(color);
            if (result.Success)
            {
                return Created(result.Message, color);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getByColorId")]
        public IActionResult GetByColorId(int id)
        {
            var result = _colorService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPut("update")]
        public IActionResult Update(Color color)
        {
            var result = _colorService.Update(color);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Color color)
        {
            var result = _colorService.Delete(color);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
