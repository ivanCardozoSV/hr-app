using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Exceptions.Task
{
    public enum TaskErrorSubCodes
    {
        InvalidUpdateStatus,
        DeleteTaskNotFound,
        TaskDeleted,
        InvalidUpdate,
        UpdateTaskNotFound,
        UpdateHasNotChanges,
        TaskNotFound
    }
}
