using ApiServer.Contracts.CandidateProfile;
using Domain.Services.Contracts.CandidateProfile;
using System.Collections.Generic;
using System.Collections;
using AutoMapper;
using ApiServer.Profiles;

namespace ApiServer.CandidateProfiles
{
    public class CandidateProfileProfile : CandidateProfile
    {
        public CandidateProfileProfile()
        {
            CreateMap<CreateCandidateProfileViewModel, CreateCandidateProfileContract>();
            CreateMap<CreatedCandidateProfileContract, CreatedCandidateProfileViewModel>();
            CreateMap<ReadedCandidateProfileContract, ReadedCandidateProfileViewModel>();
            CreateMap<UpdateCandidateProfileViewModel, UpdateCandidateProfileContract>();
        }

        //private static string ConverToString(System.Type propertyType, object propertyValue)
        //{
        //    var enumProperty = propertyValue as IEnumerable;
        //    if (enumProperty != null && propertyType != typeof(string))
        //    {
        //        var stringValues = new List<string>();
        //        foreach (var item in enumProperty)
        //        {
        //            stringValues.Add(item.ToString());
        //        }
        //        return string.Join(",", stringValues);
        //    }
        //    return propertyValue.ToString();
        //}
    }
}
