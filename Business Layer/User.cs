using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Business_Layer
{
    public class User
    {
        [Key]
        public int ID {get; set;}

        [StringLength(20, MinimumLength = 1,
        ErrorMessage = "First Name should be minimum 1 characters and a maximum of 20 characters")]
        public string Name { get; set; }

        [StringLength(20, MinimumLength = 1,
       ErrorMessage = "Surname should be minimum 1 characters and a maximum of 20 characters")]
        public string Surname { get; set; }
        [Range(18, 81,
        ErrorMessage = "Age must be between 18 and 81" )]
        public int Age { get; set; }
        [StringLength(20, MinimumLength = 1,
     ErrorMessage = "Username should be minimum 1 characters and a maximum of 20 characters")]
        public string Username { get; set; }

        [StringLength(70, MinimumLength = 1,
     ErrorMessage = "Password should be minimum 1 characters and a maximum of 20 characters")]
        public string Password { get; set; }

        [StringLength(20, MinimumLength = 1,
     ErrorMessage = "Email should be minimum 1 characters and a maximum of 20 characters")]
        public string Email { get; set; }

        public List<User> Friends { get; set; }

        public List<Interest> Interests { get; set; }

        public User( string name, string surname, int age, string username, string password, string email)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Username = username;
            Password = password;
            Email = email;
            List<User> Friends = new List<User>();
                 Interests = new List<Interest>();
        }
        public User()
        {
            List<User> Friends = new List<User>();
            List<Interest> Interests = new List<Interest>();
        }
    }
}
