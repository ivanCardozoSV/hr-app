using System;
using System.Collections.Generic;
using Domain.Model;
using Domain.Model.Enum;
using Domain.Services.Contracts.Stage.StageItem;

namespace Domain.Services.Contracts.Stage
{
    public class UpdateOfferStageContract: UpdateStageContract
    {        
        public DateTime HireDate { get; set; }
        public Seniority Seniority { get; set; }        
        public bool BackgroundCheckDone { get; set; }
        public DateTime? BackgroundCheckDoneDate { get; set; }
        public bool PreocupationalDone { get; set; }
        public DateTime? PreocupationalDoneDate { get; set; }
        public List<Offer> Offers { get; set; }
    }
}
