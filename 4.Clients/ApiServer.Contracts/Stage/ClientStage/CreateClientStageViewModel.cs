using System;
using System.Collections.Generic;
using System.Text;

namespace ApiServer.Contracts.Stage
{
    public class CreateClientStageViewModel: CreateStageViewModel
    {
        public string Interviewer { get; set; }
        public string DelegateName { get; set; }
    }
}
