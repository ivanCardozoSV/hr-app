using ApiServer.Contracts.Consultant;
using ApiServer.Contracts.Role;
using Domain.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiServer.Contracts.Employee
{
    public class CreateEmployeeViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int DNI { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string LinkedInProfile { get; set; }
        public string AdditionalInformation { get; set; }
        public EmployeeStatus Status { get; set; }
        public int RecruiterId { get; set; }
        public CreateConsultantViewModel Recruiter { get; set; }
        public int RoleId { get; set; }
        public CreateRoleViewModel Role { get; set; }
        public bool isReviewer { get; set; }
        public int? ReviewerId { get; set; }
        public CreateEmployeeViewModel Reviewer { get; set; }
    }
}
