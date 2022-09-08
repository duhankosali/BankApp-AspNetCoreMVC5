using Dk.BankApp.Web.Data.Entities;
using Dk.BankApp.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace Dk.BankApp.Web.Mapping
{
    public class UserMapper : IUserMapper// Bize bir liste gelecek (Entity), Gelen listeyi View'e çevireceğiz.
    {
        public List<UserListModel> MapToListOfUserList(List<ApplicationUser> users)
        {
            return users.Select(x => new UserListModel
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Username
            }).ToList();
        }

        public UserListModel MapTopUserList(ApplicationUser user)
        {
            return new UserListModel
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Username
            };
        }
    }
}
