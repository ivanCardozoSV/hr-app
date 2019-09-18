using System;
using System.Collections.Generic;
using System.Text;

namespace ApiServer.Contracts.Role
{
    public class ReadedRoleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isActive { get; set; }
    }
}
