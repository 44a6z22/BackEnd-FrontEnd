using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersWebServiceClient.ViewModel;

namespace UsersWebServiceClient
{
    class UserLocalService
    {
        UsersService.UsersWebService usersService ;
        public UserLocalService(UsersService.UsersWebService obj) {
            this.usersService = obj;
        }
        public UserViewModel Login(string username, string password)
        {

            var user = usersService.login(username, password);
            if (user == null)
            {
                return null;
            };
           UserViewModel authedUser = new UserViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Created = user.Created,
                isLoggedIn = true
            };
            return authedUser;
        }
        public List<UserViewModel> getUsers(UserViewModel user)
        {
            List<UserViewModel> users = new List<UserViewModel>();
            if (!user.isLoggedIn)
            {
                return null;
            }
            var r = this.usersService.getUsers();
            if (r == null)
            {
                return null;
            }
            else
            {
                users = (from us in r
                         select new UserViewModel()
                         {

                             FirstName = us.FirstName,
                             LastName = us.LastName,
                             Created = us.Created
                         }).ToList();
            }
            return users;
        }

        public bool Register( string firstName, string lastname, string username, string password)
        {
            return this.usersService.AddUser(username, password, firstName, lastname);
        }
        public void logout()
        {
            this.usersService.logout();
        }
    }
}
