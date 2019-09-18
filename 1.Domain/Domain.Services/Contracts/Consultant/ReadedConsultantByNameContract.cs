using System.Collections.Generic;

namespace Domain.Services.Contracts.Consultant
{
    public class ReadedConsultantByNameContract
    {
        public int Total { get; set; }

        public List<ReadedConsultantContract> Results { get; set; }
    }
}
