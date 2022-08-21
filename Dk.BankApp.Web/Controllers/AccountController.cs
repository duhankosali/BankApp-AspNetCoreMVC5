using Dk.BankApp.Web.Data.Context;
using Dk.BankApp.Web.Data.Repositories;
using Dk.BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Dk.BankApp.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly BankContext _context; // dependency injection
        private readonly ApplicationUserRepository _applicationUserRepository; 

        public AccountController(BankContext context, ApplicationUserRepository applicationUserRepository) // constructor
        {
            _context = context;
            _applicationUserRepository = new ApplicationUserRepository(_context);
        }

        public IActionResult Create(int id) // ilgili user datası
        {
            var userInfo = _context.ApplicationUsers.Select(x=>new UserListModel
            {
                Id = x.Id,  
                Name = x.Name,
                Surname = x.Username
            }).SingleOrDefault(x=>x.Id == id); // ilgili "id" değeri ile uyuşan bir kullanıcı var mı?
            return View(userInfo);
        }

        [HttpPost] // Postlama yolu ile bu methoda ilgili model bilgileri gönderildi.
        public IActionResult Create(AccountCreateModel model) 
        {
            _context.Accounts.Add(new Data.Entities.Account
            {
                AccountNumber = model.AccountNumber,
                ApplicationUserId = model.ApplicationUserId,
                Balance = model.Balance
            });
            _context.SaveChanges(); // Postlama yolu ile gelen datalar ile yeni bir kayıt oluşturuldu ve veritabanına kaydedildi.

            return RedirectToAction("Index", "Home");
        }
    }
}
