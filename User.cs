using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTODO
{
    public class User
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsLoggedIn { get; set; }
        public List<Task> Tasks { get; set; }

        public User()
        {
            Tasks = new List<Task>();
        }

    }       
}
