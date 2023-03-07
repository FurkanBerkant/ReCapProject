using Business.Abstract;
using Entites.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = userService.GetAll();
            if (result.Succes)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Data);
        }
        [HttpPost]
        public IActionResult Post(User user)
        {
            var result = userService.Add(user);
            if (result.Succes)
            {
                return Created(result.Message, user);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getByUserId")]
        public IActionResult GetByUserId(int id)
        {
            var result = userService.GetById(id);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPut("update")]
        public IActionResult Update(User user)
        {
            var result = userService.Update(user);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(User user)
        {
            var result = userService.Delete(user);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
