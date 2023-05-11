using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleAppTODO
{
    public class Validation
    {
        public static bool UserExists(List<User> users, string email)
        {
            foreach (User user in users)
            {
                if (user.Email == email)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsValidEmail(string email)
        {
            return !string.IsNullOrWhiteSpace(email) && Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public static bool IsValidPassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password) && Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$");
        }
    }
}
