using System;
using System.Collections.Generic;
using System.Text;
using Domain.Services.Contracts.Community;

namespace Domain.Services.Contracts.CandidateProfile
{
    public class UpdateCandidateProfileContract
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<CreateCommunityContract> CommunityItems { get; set; }
    }
}
