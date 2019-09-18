using System;
using System.Collections.Generic;
using System.Text;
using ApiServer.Contracts.Consultant;
using Domain.Model.Enum;

namespace ApiServer.Contracts.Stage
{
    public class ReadedOfferStageViewModel : ReadedStageViewModel
    {
        public DateTime OfferDate { get; set; }
        public DateTime HireDate { get; set; }
        public Seniority Seniority { get; set; }
        public float AgreedSalary { get; set; }
        public bool BackgroundCheckDone { get; set; }
        public DateTime? BackgroundCheckDoneDate { get; set; }
        public bool PreocupationalDone { get; set; }
        public DateTime? PreocupationalDoneDate { get; set; }
    }
}
