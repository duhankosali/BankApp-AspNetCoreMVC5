using Dk.BankApp.Web.Data.Context;
using Dk.BankApp.Web.Data.Entities;
using Dk.BankApp.Web.Data.Interfaces;
using Dk.BankApp.Web.Data.Repositories;
using Dk.BankApp.Web.Mapping;
using Dk.BankApp.Web.Models;
using Dk.BankApp.Web.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Dk.BankApp.Web.Controllers
{
    public class HomeController : Controller
    {
        //private readonly BankContext _context; // Artık Interfaceler üzerinden ilerliyoruz. Context kullanmamıza gerek kalmıyor. Context'leri diğer classlarımızda kullanıyoruz.
        //private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IUserMapper _userMapper;
        private readonly IUow _uow;
        public HomeController(/*BankContext context, IApplicationUserRepository applicationUserRepository,*/ IUserMapper userMapper, IUow uow) // constructor
        {
            //_applicationUserRepository = applicationUserRepository; 
            _userMapper = userMapper;
            _uow = uow;
        }

        public IActionResult Index()
        {

            return View(_userMapper.MapToListOfUserList(_uow.GetRepository<ApplicationUser>().GetAll()));
        }

        // DRY --> Don't repeat yourself.
        
    }
}
