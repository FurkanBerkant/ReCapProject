using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class RentalsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
