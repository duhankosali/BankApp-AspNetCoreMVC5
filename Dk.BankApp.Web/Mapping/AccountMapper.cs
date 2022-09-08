using Dk.BankApp.Web.Data.Entities;

namespace Dk.BankApp.Web.Mapping
{
    public class AccountMapper : IAccountMapper
    {
        // --> Account'u AccountCreateModel'e çevireceğiz.
        public Account Map(Models.AccountCreateModel model)
        {
            return new Account
            {
                AccountNumber = model.AccountNumber,
                ApplicationUserId = model.ApplicationUserId,
                Balance = model.Balance,
            };
        }
    }
}
