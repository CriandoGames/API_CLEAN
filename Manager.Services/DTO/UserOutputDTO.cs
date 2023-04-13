using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Services.DTO
{

    public class UserOutputDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public UserOutputDTO(string name, string email, string password, Guid id)
        {

            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }



    }
}
