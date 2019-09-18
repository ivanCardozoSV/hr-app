using System;
using System.Collections.Generic;
using System.Text;
using Domain.Services.Contracts.Role;

namespace Domain.Services.Contracts.Role
{
    public class ReadedRoleContract
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isActive { get; set; }
    }
}
