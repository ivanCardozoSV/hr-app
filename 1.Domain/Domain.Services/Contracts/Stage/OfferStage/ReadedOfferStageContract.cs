using Domain.Services.Contracts.Candidate;
using Domain.Services.Contracts.Stage.StageItem;
using System;
using System.Collections.Generic;
using Domain.Services.Contracts.Consultant;
using Domain.Model.Enum;
using Domain.Model;

namespace Domain.Services.Contracts.Stage
{
    public class ReadedOfferStageContract: ReadedStageContract
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