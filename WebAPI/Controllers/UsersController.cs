using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
