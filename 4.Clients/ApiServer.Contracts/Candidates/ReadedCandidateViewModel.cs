﻿using ApiServer.Contracts.CandidateSkill;
using ApiServer.Contracts.Community;
using ApiServer.Contracts.Consultant;
using ApiServer.Contracts.CandidateProfile;
using ApiServer.Contracts.Office;
using Domain.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiServer.Contracts.Candidates
{
    public class ReadedCandidateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int DNI { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string LinkedInProfile { get; set; }
        public string AdditionalInformation { get; set; }
        public EnglishLevel EnglishLevel { get; set; }
        public CandidateStatus Status { get; set; }
        public ReadedConsultantViewModel Recruiter { get; set; }
        public ReadedCommunityViewModel Community { get; set; }
        public ReadedCandidateProfileViewModel Profile { get; set; }
        public bool IsReferred { get; set; }
        public DateTime ContactDay { get; set; }
        public int PreferredOfficeId { get; set; }        

        public ICollection<ReadedCandidateSkillViewModel> CandidateSkills { get; set; }
    }
}
