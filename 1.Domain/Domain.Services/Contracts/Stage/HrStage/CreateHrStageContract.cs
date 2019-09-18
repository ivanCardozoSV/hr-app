using System;
using System.Collections.Generic;
using Domain.Model.Enum;
using Domain.Services.Contracts.Stage.StageItem;

namespace Domain.Services.Contracts.Stage
{
    public class CreateHrStageContract: CreateStageContract
    {
        public float ActualSalary { get; set; }
        public float WantedSalary { get; set; }
        public EnglishLevel EnglishLevel { get; set; }
    }
}
