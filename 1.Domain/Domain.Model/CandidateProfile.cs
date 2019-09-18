using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class CandidateProfile : DescriptiveEntity<int>
    {
        public IList<Community> CommunityItems { get; set; }
    }
}
