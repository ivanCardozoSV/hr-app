using System;
using System.Collections.Generic;
using System.Text;
using ApiServer.Contracts.Consultant;
using Domain.Model.Enum;

namespace ApiServer.Contracts.Stage
{
    public class ReadedHrStageViewModel : ReadedStageViewModel
    {
        public float ActualSalary { get; set; }
        public float WantedSalary { get; set; }
        public EnglishLevel EnglishLevel { get; set; }
        public RejectionReasonsHr RejectionReasonsHr { get; set; }

    }
}
