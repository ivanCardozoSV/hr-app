using System;
using System.Collections.Generic;
using System.Text;
using ApiServer.Contracts.Consultant;

namespace ApiServer.Contracts.Stage
{
    public class ReadedClientStageViewModel: ReadedStageViewModel
    {
        public string Interviewer { get; set; }
        public string DelegateName { get; set; }
    }
}
