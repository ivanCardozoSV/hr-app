using Domain.Services.Contracts.Task;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Contracts.TaskItem
{
    public class CreateTaskItemContract
    {
        public string Text { get; set; }
        public bool Checked { get; set; }

        public int TaskId { get; set; }
        public CreateTaskContract Task { get; set; }
    }
}
