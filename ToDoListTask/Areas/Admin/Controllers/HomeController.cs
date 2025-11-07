using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoListTask.Models;

namespace ToDoListTask.Areas.Admin.Controllers
{
    [Area ("Admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NameEntry()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NameEntry(string Name)
        {

            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(1)
            };

            Response.Cookies.Append("UserName", Name, options);



            return RedirectToAction("ToDoList", "ToDo", new { area = "Admin" });
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       

    }
}
