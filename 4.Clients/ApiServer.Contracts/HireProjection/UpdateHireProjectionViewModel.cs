using System;
using System.Collections.Generic;
using System.Text;

namespace ApiServer.Contracts.HireProjection
{
    public class UpdateHireProjectionViewModel
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public int Value { get; set; }
    }
}
