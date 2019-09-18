using Domain.Model.Enum;
using System;
using System.Collections.Generic;

namespace ApiServer.Contracts.Stage
{
    public class UpdateHrStageViewModel : UpdateStageViewModel
    {
        public float ActualSalary { get; set; }
        public float WantedSalary { get; set; }
        public EnglishLevel EnglishLevel { get; set; }
    }
}
