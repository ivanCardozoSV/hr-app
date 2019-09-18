using System;
using System.Collections.Generic;
using System.Text;
using ApiServer.Contracts.Community;

namespace ApiServer.Contracts.CandidateProfile
{
    public class UpdateCandidateProfileViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<CreateCommunityViewModel> CommunityItems { get; set; }
    }
}
