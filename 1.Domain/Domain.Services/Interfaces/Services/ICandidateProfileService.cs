using Domain.Services.Contracts.CandidateProfile;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Interfaces.Services
{
    public interface ICandidateProfileService
    {
        CreatedCandidateProfileContract Create(CreateCandidateProfileContract contract);
        ReadedCandidateProfileContract Read(int Id);
        void Update(UpdateCandidateProfileContract contract);
        void Delete(int Id);

        IEnumerable<ReadedCandidateProfileContract> List();
    }
}
