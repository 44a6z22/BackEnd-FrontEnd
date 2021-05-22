using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersWebServiceClient.ViewModel;

namespace UsersWebServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            UserLocalService userLocalService = new UserLocalService(new UsersService.UsersWebService());

               UserViewModel authedUser = new UserViewModel();
            UI ui = new UI(authedUser);
            int choice = 99999; 
            while (choice != 0) {
                choice = ui.Menu();
                switch (choice) {
                    case 1:

                        Console.WriteLine("Username : ");
                        string username = Console.ReadLine();
                        Console.WriteLine("Password : ");
                        string password = Console.ReadLine();
                        authedUser = userLocalService.Login(username, password);

                        ui.updateCurrentUser(authedUser);
                        break;
                    case 2:
                        Console.WriteLine("Username : ");
                        string usrname = Console.ReadLine();
                        Console.WriteLine("Password : ");
                        string pwd = Console.ReadLine();
                        Console.WriteLine("Firstname : ");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("LastName : ");
                        string lastName = Console.ReadLine();

                        bool result = userLocalService.Register(firstName, lastName, usrname, pwd);
                        if (result) {

                            ui.ErrorMessage("good");
                        } else {
                            ui.ErrorMessage("something went wrong .");
                        }
                        break;
                    case 3:

                        List<UserViewModel> users = userLocalService.getUsers(ui.currentUser);
                        if (users == null ) {
                            ui.ErrorMessage("you're not logged in");
                            break;
                        }
                        ui.Show(users);
                        break;
                    case 4:
                        userLocalService.logout();
                        choice = 0;
                        break;


                }
                Console.Clear();
            }
            Console.ReadLine();
        }
    }
}
