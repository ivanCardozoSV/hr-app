using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class Role : Entity<int>
    {
        public string Name { get;set;}
        public bool isActive { get; set; }
    }
}
