using Domain.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class HrStage: Stage
    {
        public float ActualSalary { get; set; }
        public float WantedSalary { get; set; }
        public EnglishLevel EnglishLevel { get; set; }
        public RejectionReasonsHr RejectionReasonsHr { get; set; }
    }
}
