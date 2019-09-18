using System;
using System.Collections.Generic;
using System.Text;

namespace ApiServer.Contracts.Process
{
    public class RejectProcessViewModel
    {
        public int Id { get; set; }
        public string RejectionReason { get; set; }
    }
}
