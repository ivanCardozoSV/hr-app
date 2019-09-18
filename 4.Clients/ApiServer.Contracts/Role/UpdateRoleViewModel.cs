using System;
using System.Collections.Generic;
using System.Text;

namespace ApiServer.Contracts.Role
{
    public class UpdateRoleViewModel
    {
        public string Name { get; set; }
        public bool isActive { get; set; }
    }
}
