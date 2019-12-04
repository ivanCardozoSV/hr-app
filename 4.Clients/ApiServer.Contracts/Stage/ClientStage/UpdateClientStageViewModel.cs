using System;
using System.Collections.Generic;

namespace ApiServer.Contracts.Stage
{
    public class UpdateClientStageViewModel: UpdateStageViewModel
    {
        public string Interviewer { get; set; }
        public string DelegateName { get; set; }
    }
}
