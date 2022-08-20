using Dk.BankApp.Web.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace Dk.BankApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly BankContext _context; // Dependency Injection
        public HomeController(BankContext context) // constructor
        {
            _context = context;
        }

        public IActionResult Index()
        {

            return View();
        }
    }
}
