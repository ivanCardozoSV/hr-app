using Domain.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class TechnicalStage: Stage
    {
        public Seniority Seniority { get; set; }
        public Seniority Seniority1 { get; set; }
        public string Client { get; set; }
    }
}
