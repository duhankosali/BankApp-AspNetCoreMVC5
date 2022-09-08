using Dk.BankApp.Web.Data.Context;
using Dk.BankApp.Web.Data.Entities;
using Dk.BankApp.Web.Data.Interfaces;
using Dk.BankApp.Web.Data.Repositories;
using Dk.BankApp.Web.Mapping;
using Dk.BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
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

        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<ApplicationUser> _applicationUserRepository;
        public AccountController(IRepository<Account> accountRepository, IRepository<ApplicationUser> applicationUserRepository)
        {
            _accountRepository = accountRepository;
            _applicationUserRepository = applicationUserRepository;
        }

        public IActionResult Create(int id) // ilgili user datası
        {
            var userInfo = _applicationUserRepository.GetById(id);

            return View(new UserListModel
            {
                Id = userInfo.Id,
                Name = userInfo.Name,
                Surname = userInfo.Username // Surname yerine Username diye eklemişim yanlışlıkla.
            });
        }

        [HttpPost] // Postlama yolu ile bu methoda ilgili model bilgileri gönderildi.
        public IActionResult Create(AccountCreateModel model) 
        {
            _accountRepository.Create(new Account
            {
                AccountNumber = model.AccountNumber,
                Balance = model.Balance,
                ApplicationUserId = model.ApplicationUserId,
            });

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult GetByUserId(int id)
        {
            var query = _accountRepository.GetQueryable(); // query SQL sorguları yazmamızı sağlıyor.
            var accounts = query.Where(x => x.ApplicationUserId == id).ToList();
            
            var user = _applicationUserRepository.GetById(id);

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

            ViewBag.FullName = user.Name + user.Username; // Viewbag ile controller'dan view e veri taşıma.

            return View(list);

            
        }
    }
}
