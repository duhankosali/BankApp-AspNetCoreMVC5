using Dk.BankApp.Web.Data.Context;
using Dk.BankApp.Web.Data.Entities;
using Dk.BankApp.Web.Data.Interfaces;

namespace Dk.BankApp.Web.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankContext _context;

        public AccountRepository(BankContext context)
        {
            _context = context;
        }

        public void Create(Account account)
        {
            _context.Set<Account>().Add(account);
            _context.SaveChanges();
        }

        public void Remove(Account account)
        {
            _context.Set<Account>().Remove(account);
            _context.SaveChanges();
        }
    }
}
