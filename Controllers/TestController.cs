using FinalProjectAl1.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectAl1.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            var data = new TestViewModel
            {
                name = "Dave",
                dateOfBirth = new DateTime(1984, 05, 13)
            };
            return View(data);
        }
    }
}
