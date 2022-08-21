using Dk.BankApp.Web.Data.Context;
using Dk.BankApp.Web.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Dk.BankApp.Web.Data.Repositories
{
    public class ApplicationUserRepository
    {
        private readonly BankContext _context;

        public ApplicationUserRepository(BankContext context)
        {
            _context = context;
        }

        public List<ApplicationUser> GetAll()
        {
            return _context.ApplicationUsers.ToList();
        }
        public ApplicationUser GetById(int id)
        {
            return _context.ApplicationUsers.SingleOrDefault(x=>x.Id == id);
        }
    }
}
