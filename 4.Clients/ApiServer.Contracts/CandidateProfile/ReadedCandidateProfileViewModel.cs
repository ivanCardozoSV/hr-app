using System;
using System.Collections.Generic;
using System.Text;
using ApiServer.Contracts.Community;

namespace ApiServer.Contracts.CandidateProfile
{
    public class ReadedCandidateProfileViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ReadedCommunityViewModel> CommunityItems { get; set; }
    }
}
