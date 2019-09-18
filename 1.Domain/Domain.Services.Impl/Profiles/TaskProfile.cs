using AutoMapper;
using Domain.Model;
using Domain.Services.Contracts.Task;
using System;
using System.Collections.Generic;
using System.Text;


namespace Domain.Services.Impl.Profiles
{
    public class TaskProfile: Profile
    {
        public TaskProfile()
        {
            CreateMap<Task, ReadedTaskContract>();
            CreateMap<CreateTaskContract, Task>();
            CreateMap<Task, CreatedTaskContract>();
            CreateMap<UpdateTaskContract, Task>();
        }
    }
}
