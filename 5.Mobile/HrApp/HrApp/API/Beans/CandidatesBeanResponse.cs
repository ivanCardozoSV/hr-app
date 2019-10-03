using System;
using System.Collections.Generic;
using System.Text;

namespace HrApp.API.Beans
{
    public class CandidatesBeanResponse
    {
        public List<CandidatesResponse> Candidates { get; set; } = new List<CandidatesResponse>();
    }
}
