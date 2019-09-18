using Core;
using Domain.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class Employee : Entity<int>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int DNI { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string LinkedInProfile { get; set; }
        public string AdditionalInformation { get; set; }
        public EmployeeStatus Status { get; set; }
        public Consultant Recruiter { get; set; }
        public Role Role { get; set; }
        public bool isReviewer { get; set; }
        public Employee Reviewer { get; set; }
    }
}
