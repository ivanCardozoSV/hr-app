using System;
using System.Collections.Generic;
using System.Text;

namespace ApiServer.Contracts.Consultant
{
    public class ReadedConsultantByNameViewModel
    {
        public int Total { get; set; }

        public List<ReadedConsultantViewModel> Results { get; set; }
    }
}
