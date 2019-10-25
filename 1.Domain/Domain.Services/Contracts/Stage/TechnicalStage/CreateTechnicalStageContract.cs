using System;
using System.Collections.Generic;
using Domain.Model.Enum;
using Domain.Services.Contracts.Stage.StageItem;

namespace Domain.Services.Contracts.Stage
{
    public class CreateTechnicalStageContract :CreateStageContract
    {
        public Seniority Seniority { get; set; }
        public Seniority Seniority1 { get; set; }
        public string Client { get; set; }
    }
}
