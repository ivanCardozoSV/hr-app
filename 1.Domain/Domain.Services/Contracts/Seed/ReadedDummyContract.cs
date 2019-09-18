using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Contracts.Seed
{
    public class ReadedDummyContract
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TestValue { get; set; }
    }
}
