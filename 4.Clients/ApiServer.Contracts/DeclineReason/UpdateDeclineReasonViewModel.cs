using System;
using System.Collections.Generic;
using System.Text;

namespace ApiServer.Contracts.DeclineReason
{
    public class UpdateDeclineReasonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
