using System;
using System.Collections.Generic;
using Domain.Services.Contracts.Role;

namespace Domain.Services.Contracts.Role
{
    public class CreateRoleContract
    {
        public string Name { get; set; }
        public bool isActive { get; set; }
    }
}
