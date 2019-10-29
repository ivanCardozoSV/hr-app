using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class ClientStage: Stage
    {
        public string interviewer { get; set; }
        public string delegateName { get; set; }
    }
}
