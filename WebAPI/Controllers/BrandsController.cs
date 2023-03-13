using Business.Abstract;
using Entites.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result= _brandService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbybrandid")]
        public IActionResult GetByBrandId(int id)
        {
            var result = _brandService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost]
        public IActionResult Post(Brand brand)
        {
            var result = _brandService.Add(brand);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPut]
        public IActionResult Put(Brand brand)
        {
            var result = _brandService.Update(brand);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete]
        public IActionResult Delete(Brand brand)
        {
            var result = _brandService.Delete(brand);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }


    }
}
