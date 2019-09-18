using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Contracts.Seed
{
    public class CreateDummyContract
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string TestValue { get; set; }
    }
}
