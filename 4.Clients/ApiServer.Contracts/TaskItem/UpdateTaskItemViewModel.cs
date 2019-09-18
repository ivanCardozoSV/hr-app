using ApiServer.Contracts.Task;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiServer.Contracts.TaskItem
{
    public class UpdateTaskItemViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Checked { get; set; }

        public int TaskId { get; set; }
        public UpdateTaskViewModel Task { get; set; }
    }
}
