using Core;
using System.Collections.Generic;

namespace Domain.Model
{
    public class Consultant : Entity<int>
    {
        public string Name { get; set; }

        public string LastName { get; set; }
        
        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public string AdditionalInformation { get; set; }

        public IList<Candidate> Candidates { get; set; }

        public IList<Task> Tasks { get; set; }
    }
}
