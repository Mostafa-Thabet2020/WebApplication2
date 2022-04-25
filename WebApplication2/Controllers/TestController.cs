using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class TestController : Controller
    {
        public string Hello()
        {
            return "Hello first controller";
        }
        public IActionResult FirstPage()
        {
            ViewData["FirstViewData"] = "Hello from view data";
            return View();
        }
    }
}
