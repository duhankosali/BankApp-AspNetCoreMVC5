using Dk.BankApp.Web.Data.Context;
using Dk.BankApp.Web.Data.Entities;
using Dk.BankApp.Web.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Dk.BankApp.Web.Data.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
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
        public void Create(ApplicationUser user)
        {
            _context.Set<ApplicationUser>().Add(user);
            _context.SaveChanges();
        }
        public void Remove(ApplicationUser user)
        {
            _context.Set<ApplicationUser>().Remove(user);
            _context.SaveChanges();
        }

    }

}
