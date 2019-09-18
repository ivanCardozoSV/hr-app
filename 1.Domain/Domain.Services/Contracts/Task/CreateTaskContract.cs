using Domain.Services.Contracts.Consultant;
using Domain.Services.Contracts.TaskItem;
using System;
using System.Collections.Generic;

namespace Domain.Services.Contracts.Task
{
    public class CreateTaskContract
    {
        public string Title { get; set; }

        public bool IsApprove { get; set; }
        public bool IsNew { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime EndDate { get; set; }

        public int ConsultantId { get; set; }
        //public CreateConsultantContract Consultant { get; set; }

        public ICollection<CreateTaskItemContract> TaskItems { get; set; }
    }
}
