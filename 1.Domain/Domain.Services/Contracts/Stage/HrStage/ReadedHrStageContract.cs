using Domain.Services.Contracts.Candidate;
using Domain.Services.Contracts.Stage.StageItem;
using System;
using System.Collections.Generic;
using Domain.Services.Contracts.Consultant;
using Domain.Model.Enum;

namespace Domain.Services.Contracts.Stage
{
    public class ReadedHrStageContract: ReadedStageContract
    {
        public float? ActualSalary { get; set; }
        public float? WantedSalary { get; set; }
        public EnglishLevel? EnglishLevel { get; set; }
    }
}