using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleAppTODO
{
    public class UserManager
    {
        public static List<User> users = new List<User>();
        public static void Register()
        {
            while (true)
            {
                Console.Write("Enter your name: ");
                string name = Console.ReadLine();

                while (true)
                {
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        MyMethod.DisplayInvalidInputMessage("Name cannot be null, empty, or white space.");
                        Console.Write("Enter a valid name format: ");
                        name = Console.ReadLine();
                        continue;
                    }

                    if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                    {
                        MyMethod.DisplayInvalidInputMessage("Name can only contain letters.");
                        Console.Write("Enter a valid name format: ");
                        name = Console.ReadLine();
                        continue;
                    }

                    int minLength = 2;
                    int maxLength = 50;

                    if (name.Length < minLength || name.Length > maxLength)
                    {
                        MyMethod.DisplayInvalidInputMessage($"Name should have a length between {minLength} and {maxLength} characters.");
                        Console.Write("Enter a valid name format: ");
                        name = Console.ReadLine();
                        continue;
                    }

                    break;
                }

                Console.Write("Enter your email address: ");
                string email = Console.ReadLine();
                while (!Validation.IsValidEmail(email) || Validation.UserExists(users, email))
                {
                    if (string.IsNullOrWhiteSpace(email))
                    {
                        MyMethod.DisplayInvalidInputMessage("Email cannot be null, empty, or white space.");
                    }
                    else if (!Validation.IsValidEmail(email))
                    {
                        MyMethod.DisplayInvalidInputMessage("Email is not in a valid format of example@example.com.");
                    }
                    else
                    {
                        MyMethod.DisplayInvalidInputMessage("A user with that email address already exists.");
                    }

                    Console.Write("Enter a unique and valid email address: ");
                    email = Console.ReadLine();
                }

                Console.Write("Enter your password: ");
                string password = "";
                ConsoleKeyInfo key;

                while (true)
                {
                    key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.Enter)
                    {
                        if (!Validation.IsValidPassword(password))
                        {
                            MyMethod.DisplayInvalidInputMessage("\nThe password must have at least 8 characters," +
                                " 1 uppercase letter, 1 lowercase letter," +
                                " 1 number, and 1 special character.");
                            Console.Write("Enter a valid and strong password: ");
                            password = "";
                        }
                        else
                        {
                            Console.Write("\nConfirm your password: ");
                            string confirmPassword = "";

                            while (true)
                            {
                                key = Console.ReadKey(true);

                                if (key.Key == ConsoleKey.Enter)
                                {
                                    if (confirmPassword == password)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        MyMethod.DisplayInvalidInputMessage("\nPasswords do not match. Please try again.");
                                        Console.Write("\nConfirm your password: ");
                                        confirmPassword = "";
                                    }
                                }
                                else if (key.Key == ConsoleKey.Backspace)
                                {
                                    if (confirmPassword.Length > 0)
                                    {
                                        confirmPassword = confirmPassword.Substring(0, confirmPassword.Length - 1);
                                        Console.Write("\b \b");
                                    }
                                }
                                else
                                {
                                    confirmPassword += key.KeyChar;
                                    Console.Write("*");
                                }
                            }

                            break;
                        }
                    }
                    else if (key.Key == ConsoleKey.Backspace)
                    {
                        if (password.Length > 0)
                        {
                            password = password.Substring(0, password.Length - 1);
                            Console.Write("\b \b");
                        }
                    }
                    else
                    {
                        password += key.KeyChar;
                        Console.Write("*");
                    }
                }
                User user = new User
                {
                    Name = name,
                    Email = email,
                    Password = password,
                    IsLoggedIn = true
                };
                User currentUser = user;
                users.Add(user);
                MyMethod.DisplaySuccessInputMessage("\nRegistration successful!");
                MyMethod.DisplaySuccessInputMessage("You are now logged in.");
                break;
            }
        }
        public static void Login()
        {
            while (true)
            {
                Console.Write("Enter your email address: ");
                string email = Console.ReadLine();

                while (string.IsNullOrWhiteSpace(email) || !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    if (string.IsNullOrWhiteSpace(email))
                    {
                        MyMethod.DisplayInvalidInputMessage("Email cannot be null, empty, or white space.");
                    }
                    else
                    {
                        MyMethod.DisplayInvalidInputMessage("Email is not in a valid format of example@example.com.");
                    }

                    Console.Write("Enter a valid email address: ");
                    email = Console.ReadLine();
                }

                User user = FindUserByEmail(users, email);
                if (user != null)
                {
                    Console.Write("Enter your password: ");
                    string password = "";
                    ConsoleKeyInfo key;

                    while (true)
                    {
                        key = Console.ReadKey(true);

                        if (key.Key == ConsoleKey.Enter)
                        {
                            if (string.IsNullOrWhiteSpace(password) || !Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$"))
                            {
                                MyMethod.DisplayInvalidInputMessage("The password must have at least 8 characters, 1 uppercase letter, " +
                                    "1 lowercase letter, and 1 number.");
                                Console.Write("Enter a valid password: ");
                                password = "";
                            }
                            else
                            {
                                break;
                            }
                        }
                        else if (key.Key == ConsoleKey.Backspace)
                        {
                            if (password.Length > 0)
                            {
                                password = password.Substring(0, password.Length - 1);
                                Console.Write("\b \b");
                            }
                        }
                        else
                        {
                            password += key.KeyChar;
                            Console.Write("*");
                        }
                    }

                    User currentUser = users.FirstOrDefault(u => u.Email == email && u.Password == password);

                    if (currentUser != null)
                    {
                        MyMethod.DisplaySuccessInputMessage($"Welcome back, {email}!");
                        break;
                    }
                    else
                    {
                        MyMethod.DisplayInvalidInputMessage("Invalid email or password.");
                    }
                }
                else
                {
                    MyMethod.DisplayInvalidInputMessage("This email is not registered. Do you want to register? (Y/N)");
                    string response = Console.ReadLine();
                    if (response.ToLower() == "y")
                    {
                        Register();
                    }
                    else
                    {
                        Login();
                        return;
                    }
                }
                break;
            }
        }
        static User FindUserByEmail(List<User> users, string email)
        {
            foreach (User user in users)
            {
                if (user.Email == email)
                {
                    return user;
                }
            }
            return null;
        }

    }
}
