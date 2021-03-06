using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserWebservice.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName {get; set; }
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public DateTime Created { get; set; } = DateTime.Today;
        public string PassWord { get; set; }
    }
}