using ApiServer.Contracts.Consultant;
using ApiServer.Contracts.TaskItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiServer.Contracts.Task
{
    public class CreateTaskViewModel
    {
        public string Title { get; set; }

        public bool IsApprove { get; set; }
        public bool IsNew { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime EndDate { get; set; }

        public int ConsultantId { get; set; }
        public CreateConsultantViewModel Consultant { get; set; }

        public ICollection<CreateTaskItemViewModel> TaskItems { get; set; }
    }
}
