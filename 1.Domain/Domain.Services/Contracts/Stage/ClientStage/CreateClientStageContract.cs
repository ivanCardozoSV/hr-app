using System;
using System.Collections.Generic;
using Domain.Services.Contracts.Stage.StageItem;

namespace Domain.Services.Contracts.Stage
{
    public class CreateClientStageContract: CreateStageContract
    {
        public string Interviewer { get; set; }
        public string DelegateName { get; set; }
    }
}
