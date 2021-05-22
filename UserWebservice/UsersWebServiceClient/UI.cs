using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersWebServiceClient.ViewModel;

namespace UsersWebServiceClient
{
    class UI
    {
        public UserViewModel currentUser { get; set;  }
        public UI(UserViewModel obj)
        {
            this.currentUser = obj;
        }
        public void updateCurrentUser( UserViewModel obj)
        {
            this.currentUser = obj;
        }

        public void ErrorMessage(string error)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }
        public int Menu()
        {
            int choice = 0;
            bool error = true; 
            while (error != false  ) {

                Console.WriteLine("*************************************************");

                if (!currentUser.isLoggedIn) {
                    Console.WriteLine("1. Login");
                    Console.WriteLine("2. Register ");
                }
                if (currentUser.isLoggedIn) {
                    Console.WriteLine("3. List users ");
                }

                if (currentUser.isLoggedIn) {
                    Console.WriteLine("4. Logout ");
                }
                Console.WriteLine("0. Exit");
                Console.WriteLine("*************************************************");
                Console.WriteLine("chose :");

                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    error = false;
                }catch
                {
                    this.ErrorMessage("input Error");
                }
                Console.Clear();
            }
            return choice;
        }
        public void Show(List<UserViewModel> users){
            foreach (UserViewModel user in users) {
                Console.WriteLine("FirstName: {0} \t LastName: {1} \t  Created: {2}", user.FirstName, user.LastName, user.Created);
            }
            Console.ReadLine();
        }
    }
}
