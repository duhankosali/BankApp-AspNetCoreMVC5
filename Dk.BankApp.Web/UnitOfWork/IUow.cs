using Dk.BankApp.Web.Data.Interfaces;

namespace Dk.BankApp.Web.UnitOfWork
{
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T : class, new(); // T newlenebilir bir classtır.
        void SaveChanges();
    }
}