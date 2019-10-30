using System;
using System.Collections.Generic;

namespace ApiServer.Contracts.Stage
{
    public class UpdateClientStageViewModel: UpdateStageViewModel
    {
        public string interviewer { get; set; }
        public string delegateName { get; set; }
    }
}
