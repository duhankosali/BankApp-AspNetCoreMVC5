using Dk.BankApp.Web.Data.Entities;
using Dk.BankApp.Web.Models;

namespace Dk.BankApp.Web.Mapping
{
    public interface IAccountMapper
    {
        public Account Map(AccountCreateModel account);
    }
}
