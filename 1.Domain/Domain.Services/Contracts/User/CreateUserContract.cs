using Domain.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Contracts.User
{
    public class CreateUserContract
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public Roles Role { get; set; }
        public string Password { get; set; }
    }
}
