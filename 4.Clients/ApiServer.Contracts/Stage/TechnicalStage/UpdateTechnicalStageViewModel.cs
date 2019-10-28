using Domain.Model.Enum;
using System;
using System.Collections.Generic;

namespace ApiServer.Contracts.Stage
{
    public class UpdateTechnicalStageViewModel : UpdateStageViewModel
    {
        public Seniority Seniority { get; set; }
        public Seniority Seniority1 { get; set; }
        public string Client { get; set; }
    }
}
