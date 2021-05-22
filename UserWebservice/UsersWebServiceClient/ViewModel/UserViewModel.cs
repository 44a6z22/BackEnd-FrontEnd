using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersWebServiceClient.ViewModel
{
    class UserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public string password { get; set; }
        public bool isLoggedIn { get; set; } = false;
    }
}
