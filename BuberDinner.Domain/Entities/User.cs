using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }=Guid.NewGuid();
        public string FirstName { get; set; } = null;
        public string LastName { get; set; } = null;
        public string Email { get; set; } = null;
        public string Password { get; set; } = null;
        public User(string firstname,string lastname,string email,string password) 
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Email = email;
            this.Password = password;
        }
    }
}
