using Microsoft.AspNetCore.Mvc;

namespace Cavardi.Controllers
{
    public class TestController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult xyz()
        {
            return View();
        }
    }
}
