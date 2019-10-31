using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class ClientStage: Stage
    {
        public string Interviewer { get; set; }
        public string DelegateName { get; set; }
    }
}
