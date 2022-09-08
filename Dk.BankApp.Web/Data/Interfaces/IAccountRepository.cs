using Dk.BankApp.Web.Data.Entities;

namespace Dk.BankApp.Web.Data.Interfaces
{
    public interface IAccountRepository
    {
        public void Create(Account account);
        
    }
}
