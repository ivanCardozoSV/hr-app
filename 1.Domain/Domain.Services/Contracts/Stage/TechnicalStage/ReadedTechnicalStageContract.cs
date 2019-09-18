using Domain.Services.Contracts.Candidate;
using Domain.Services.Contracts.Stage.StageItem;
using System;
using System.Collections.Generic;
using Domain.Services.Contracts.Consultant;
using Domain.Model.Enum;

namespace Domain.Services.Contracts.Stage
{
    public class ReadedTechnicalStageContract: ReadedStageContract
    {
        public Seniority Seniority { get; set; }
        public string Client { get; set; }
    }
}