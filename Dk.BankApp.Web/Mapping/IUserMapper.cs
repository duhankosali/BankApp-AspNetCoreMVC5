using Dk.BankApp.Web.Data.Entities;
using Dk.BankApp.Web.Models;
using System.Collections.Generic;

namespace Dk.BankApp.Web.Mapping
{
    public interface IUserMapper
    {
        public List<UserListModel> MapToListOfUserList(List<ApplicationUser> users);

        public UserListModel MapTopUserList(ApplicationUser user);
    }
}
