using Dk.BankApp.Web.Data.Context;
using Dk.BankApp.Web.Data.Interfaces;
using Dk.BankApp.Web.Data.Repositories;

namespace Dk.BankApp.Web.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly BankContext _context;
        // readonly --> Constructor içinde setlenebilir, başka bir yerde setlenemez.
        public Uow(BankContext context)
        {
            _context = context; 
        }

        public IRepository <T> GetRepository<T>() where T : class, new() // T newlenebilir bir classtır.
        {
            return new Repository<T>(_context);
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
