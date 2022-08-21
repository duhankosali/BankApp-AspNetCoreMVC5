using Dk.BankApp.Web.Data.Context;
using Dk.BankApp.Web.Data.Repositories;
using Dk.BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Dk.BankApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly BankContext _context; // Dependency Injection
        private readonly ApplicationUserRepository applicationUserRepository;
        public HomeController(BankContext context, ApplicationUserRepository applicationUserRepository) // constructor
        {
            _context = context;
            applicationUserRepository = new ApplicationUserRepository(_context);
        }

        public IActionResult Index()
        {

            return View(applicationUserRepository.GetAll());
        }

        // DRY --> Don't repeat yourself.
        
    }
}
