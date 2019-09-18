using ApiServer.Contracts.Skills;
using AutoMapper;
using Domain.Services.Contracts.Skill;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiServer.Profiles
{
    public class SkillProfile: Profile
    {
        public SkillProfile()
        {
            CreateMap<CreateSkillViewModel, CreateSkillContract>();
            CreateMap<CreatedSkillContract, CreatedSkillViewModel>();
            CreateMap<ReadedSkillContract, ReadedSkillViewModel>();
            CreateMap<UpdateSkillViewModel, UpdateSkillContract>();
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
