using Dk.BankApp.Web.Data.Context;
using Dk.BankApp.Web.Data.Entities;
using Dk.BankApp.Web.Data.Interfaces;
using Dk.BankApp.Web.Data.Repositories;
using Dk.BankApp.Web.Mapping;
using Dk.BankApp.Web.Models;
using Dk.BankApp.Web.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Dk.BankApp.Web.Controllers
{
    public class AccountController : Controller
    {
        ////private readonly BankContext _context; // dependency injection
        //private readonly IApplicationUserRepository _applicationUserRepository;
        //private readonly IAccountRepository _accountRepository;
        //private readonly IUserMapper _userMapper;
        //private readonly IAccountMapper _accountMapper;

        //public AccountController(IApplicationUserRepository applicationUserRepository, IUserMapper userMapper, IAccountRepository accountRepository, IAccountMapper accountMapper) // constructor
        //{

        //    _applicationUserRepository = applicationUserRepository;
        //    _userMapper = userMapper;
        //    _accountRepository = accountRepository;
        //    _accountMapper = accountMapper;
        //}

        //private readonly IRepository<Account> _accountRepository;
        //private readonly IRepository<ApplicationUser> _applicationUserRepository;
        //public AccountController(IRepository<Account> accountRepository, IRepository<ApplicationUser> applicationUserRepository)
        //{
        //    _accountRepository = accountRepository;
        //    _applicationUserRepository = applicationUserRepository;
        //}

        private readonly IUow _uow;

        public AccountController(IUow uow)
        {
            _uow = uow;
        }

        public IActionResult Create(int id) // ilgili user datası
        {
            var userInfo = _uow.GetRepository<ApplicationUser>().GetById(id);

            return View(new UserListModel
            {
                Id = userInfo.Id,
                Name = userInfo.Name,
                Surname = userInfo.Username // Surname yerine Username diye eklemişim yanlışlıkla.
            });
            _uow.SaveChanges();
        }

        [HttpPost] // Postlama yolu ile bu methoda ilgili model bilgileri gönderildi.
        public IActionResult Create(AccountCreateModel model) 
        {
            _uow.GetRepository<Account>().Create(new Account
            {
                AccountNumber = model.AccountNumber,
                Balance = model.Balance,
                ApplicationUserId = model.ApplicationUserId,
            });

            _uow.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult GetByUserId(int id)
        {
            var query = _uow.GetRepository<Account>().GetQueryable(); // query SQL sorguları yazmamızı sağlıyor.
            var accounts = query.Where(x => x.ApplicationUserId == id).ToList();
            
            var user = _uow.GetRepository<ApplicationUser>().GetById(id);

            var list = new List<AccountListModel>();
            foreach (var account in accounts)
            {
                list.Add(new()
                {
                    AccountNumber=account.AccountNumber,
                    ApplicationUserId=account.ApplicationUserId,
                    Balance=account.Balance,
                    Id = account.Id,
                });
            }

 

            return View(list);

            
        }

        [HttpGet]
        public IActionResult SendMoney(int accountId)
        {
            //Case: 
            // Bir kullanıcı başka bir kullanıcıya para gönderebilir, 
            // 2 Farklı hesabı olan kullanıcı 1. Hesabından 2. Hesabına para gönderebilir.

            var query = _uow.GetRepository<Account>().GetQueryable();

            var accounts = query.Where(x=>x.Id != accountId).ToList(); // Para, çıktığı hesap dışında bütün hesaplara gönderilebilir.

            var list = new List<AccountListModel>();

            ViewBag.SenderId = accountId;

            foreach (var account in accounts)
            {
                list.Add(new()
                {
                    AccountNumber = account.AccountNumber,
                    ApplicationUserId = account.ApplicationUserId,
                    Balance = account.Balance,
                    Id=account.Id,
                });
            }

            //var list2 = new SelectList(list); // Select List, Listeden seçilen veriyi bulmamızı sağlayan bir class.
            //var items = list2.Items;

            return View(new SelectList(list,"Id","AccountNumber"));
        }

        [HttpPost]
        public IActionResult SendMoney(SendMoneyModel model)
        {
            // Böyle durumlarda Unit of Work Pattern kullanılmalıdır.
            // Örneğin A kullanıcısı B kullanıcısına para gönderirken sistemde kopukluk olabilir. A kullanıcısından para çıkarken, B kullanıcısına para ulaşmamış olabilir.
            // Böyle durumların yaşanmaması için Unit Of Work kullanılmalıdır!!

            var account = _uow.GetRepository<Account>().GetById(model.AccountId); // Alıcı ID
            var senderAccount = _uow.GetRepository<Account>().GetById(model.SenderId); // Gönderici ID

            senderAccount.Balance = senderAccount.Balance - model.Amount; // Para gönderildi.
            _uow.GetRepository<Account>().Update(senderAccount);

            account.Balance = account.Balance + model.Amount; // Para alındı.
            _uow.GetRepository<Account>().Update(account);

            _uow.SaveChanges();

            return RedirectToAction("Index", "Home");
         
        }
    }
}
