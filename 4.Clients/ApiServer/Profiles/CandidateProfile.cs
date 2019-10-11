using ApiServer.Contracts.Candidates;
using AutoMapper;
using Domain.Services.Contracts.Candidate;
using System.Collections;
using System.Collections.Generic;

namespace ApiServer.Profiles
{
    public class CandidateProfile : Profile
    {
        public CandidateProfile()
        {
            CreateMap<CreateCandidateViewModel, CreateCandidateContract>();
            CreateMap<CreatedCandidateContract, CreatedCandidateViewModel>();
            CreateMap<ReadedCandidateContract, ReadedCandidateViewModel>();
            CreateMap<ReadedCandidateAppContract, ReadedCandidateAppViewModel>();
            CreateMap<UpdateCandidateViewModel, UpdateCandidateContract>();
        }

        private static string ConverToString(System.Type propertyType, object propertyValue)
        {
            var enumProperty = propertyValue as IEnumerable;
            if (enumProperty != null && propertyType != typeof(string))
            {
                var stringValues = new List<string>();
                foreach (var item in enumProperty)
                {
                    stringValues.Add(item.ToString());
                }
                return string.Join(",", stringValues);
            }
            return propertyValue.ToString();
        }
    }
}
