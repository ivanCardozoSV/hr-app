using ApiServer.Contracts.SkillType;
using AutoMapper;
using Domain.Services.Contracts.SkillType;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiServer.Profiles
{
    public class SkillTypeProfile : Profile
    {
        public SkillTypeProfile()
        {
            CreateMap<CreateSkillTypeViewModel, CreateSkillTypeContract>();
            CreateMap<CreatedSkillTypeContract, CreatedSkillTypeViewModel>();
            CreateMap<ReadedSkillTypeContract, ReadedSkillTypeViewModel>();
            CreateMap<UpdateSkillTypeViewModel, UpdateSkillTypeContract>();
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
