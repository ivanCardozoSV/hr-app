using System;
using System.Collections.Generic;
using Domain.Services.Contracts.Community;

namespace Domain.Services.Contracts.CandidateProfile
{
    public class CreateCandidateProfileContract
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<CreateCommunityContract> CommunityItems { get; set; }
    }
}
