using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Seed
{
    public class Dummy: DescriptiveEntity<Guid>
    {
        public string TestValue { get; set; }
    }
}
