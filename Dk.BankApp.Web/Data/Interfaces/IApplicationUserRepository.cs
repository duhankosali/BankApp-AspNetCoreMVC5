using Dk.BankApp.Web.Data.Entities;
using System.Collections.Generic;

namespace Dk.BankApp.Web.Data.Interfaces
{
    public interface IApplicationUserRepository
    {
        List<ApplicationUser> GetAll(); 
        ApplicationUser GetById(int id);    
    }
}
