using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppTODO
{
    public class AppEntry
    {
        public static void MyAppEntry()
        {
            bool isLoggedIn = false;
            List<User> users = new List<User>();

            while (true)
            {
                Animation.DisplayWelcome();

                if (isLoggedIn == false)
                {
                    MyMethod.DisplayMenu();

                    string choice = Console.ReadLine();
                    Console.WriteLine();

                    switch (choice)
                    {
                        case "1":
                            UserManager.Register();
                            Animation.DisplayRegistrationSuccess();
                            isLoggedIn = true;
                            break;

                        case "2":
                            UserManager.Login();
                            Animation.DisplayLoginSuccess();
                            isLoggedIn = true;
                            break;

                        case "3":
                            Console.WriteLine("Exiting...");
                            Animation.DisplayLogoutSuccess();
                            return;

                        default:
                            Console.WriteLine("Invalid choice.");
                            Animation.DisplayInvalidChoice();
                            break;
                    }
                }
                else
                {
                    User currentUser = UserManager.users.FirstOrDefault(u => u.IsLoggedIn);
                    List<Task> tasks = currentUser.Tasks;
                    MyMethod.DisplayTaskMenu(currentUser.Email);

                    string choice = Console.ReadLine();
                    Console.WriteLine();

                    switch (choice)
                    {
                        case "1":
                            TaskManager.AddTask(tasks, currentUser.Id);
                            MyMethod.PrintTable(tasks);
                            break;

                        case "2":
                            MyMethod.DisplayCalHeader();
                            MyMethod.PrintTable(tasks);
                            TaskManager.ViewAllTasks(tasks);
                            break;

                        case "3":
                            MyMethod.PrintTable(tasks);
                            TaskManager.EditTask(tasks);
                            break;

                        case "4":
                            TaskManager.ViewAllTasks(tasks);
                            TaskManager.DeleteTask(tasks, currentUser);
                            break;

                        case "5":
                            TaskManager.ViewAllTasks(tasks);
                            TaskManager.CompleteTask(tasks);
                            MyMethod.PrintTable(tasks);
                            break;

                        case "6":
                            isLoggedIn = false;
                            Console.WriteLine("Logged out.");
                            Animation.DisplayLogoutSuccess();
                            break;

                        default:
                            Console.WriteLine("Invalid choice.");
                            Animation.DisplayInvalidChoice();
                            break;
                    }
                }
                Animation.PressAnyKeyToContinue();
            }

        }
    }
}
