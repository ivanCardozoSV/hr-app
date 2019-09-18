using System;
using System.Collections.Generic;
using System.Text;

namespace ApiServer.Contracts.Role
{
    public class CreateRoleViewModel
    {
        public string Name { get; set; }
        public bool isActive { get; set; }
    }
}
