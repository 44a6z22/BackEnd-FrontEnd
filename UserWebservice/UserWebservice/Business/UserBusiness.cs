using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserWebservice.Business
{
    public class UserBusiness
    {
        private UserDbEntities _ctx;
        public UserBusiness(UserDbEntities ctx)
        {
            this._ctx = ctx;
        }

        public bool AddNewUser(User obj)
        {
            this._ctx.Users.Add(obj);
            this._ctx.SaveChanges();

            return true;
        }
        public User login(string username, string password)
        {
            User authedUser = (from user in this._ctx.Users where user.UserName == username && user.password == password select user).FirstOrDefault();
            return authedUser;
        }
        public List<User> getUsers()
        {
            return (from user in this._ctx.Users select user).ToList();
        }

    }
}