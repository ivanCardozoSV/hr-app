using Domain.Services.Contracts.Task;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Contracts.TaskItem
{
    public class ReadedTaskItemContract
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Checked { get; set; }

        public int TaskId { get; set; }
        public ReadedTaskContract Task { get; set; }
    }
}
