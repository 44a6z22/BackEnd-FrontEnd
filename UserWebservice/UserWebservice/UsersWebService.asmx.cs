using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using UserWebservice.Business;

namespace UserWebservice
{
    /// <summary>
    /// Summary description for UsersWebService
    /// </summary>
    [WebService(Namespace = "http://HDCETEST.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UsersWebService : System.Web.Services.WebService
    {
        private UserBusiness userBusiness;
        public UsersWebService()
        {
            this.userBusiness = new UserBusiness(new UserDbEntities());
        }

        [WebMethod(EnableSession = true)]
        public bool AddUser(string username, string _password, string firstname, string lastname) {

            User user = new User()
            {
                UserName = username,
                password = _password,
                FirstName = firstname,
                LastName = lastname
            };

            bool res = this.userBusiness.AddNewUser(user);

            return res;
        }

        [WebMethod(EnableSession = true)]
        public User login(string username, string passwrod)
        {
            // to avoide re cheking the database eventho the user is already logged in.
            if (this.isUserLoggedIn())
                return null;

            User user = this.userBusiness.login(username, passwrod);
            if (user != null)
                Session["LoggedInUser"] = user.FirstName;
            return user;
        }
        [WebMethod(EnableSession = true)]
        public List<User> getUsers()
        {
            List<User> users = this.userBusiness.getUsers();

            return users;
        }
        [WebMethod(EnableSession = true)]
        public bool isUserLoggedIn()
        {
            return Session["LoggedInUser"] == null ? false: true ;
        }

        [WebMethod(EnableSession = true)]
        public void logout()
        {
            Session["LoggedInUser"] = null;
        }


    }
}
