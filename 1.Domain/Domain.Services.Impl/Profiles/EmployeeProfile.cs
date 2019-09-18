using AutoMapper;
using Domain.Model;
using Domain.Services.Contracts.Employee;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Impl.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, ReadedEmployeeContract>().ForMember(contract => contract.RecruiterId, opt => opt.MapFrom(employee => employee.Recruiter.Id)); ;
            CreateMap<CreateEmployeeContract, Employee>();
            CreateMap<Employee, CreatedEmployeeContract>();
            CreateMap<UpdateEmployeeContract, Employee>();
        }
    }
}
