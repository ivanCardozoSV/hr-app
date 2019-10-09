using HrApp.API.Beans;
using System;
using System.Collections.Generic;
using System.Text;

namespace HrApp.Services.Interfaces
{
    public interface ICandidateService
    {
        IEnumerable<CandidatesResponse> Get();
    }
}
