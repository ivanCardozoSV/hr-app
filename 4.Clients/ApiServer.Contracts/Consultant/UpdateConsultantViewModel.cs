using System;
using System.Collections.Generic;
using System.Text;

namespace ApiServer.Contracts.Consultant
{
    public class UpdateConsultantViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string AdditionalInformation { get; set; }
    }
}
