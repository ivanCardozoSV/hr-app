using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Exceptions.SkillType
{
    public enum SkillTypeErrorSubCodes
    {
        InvalidUpdateStatus,
        DeleteSkillTypeNotFound,
        SkillTypeDeleted,
        InvalidUpdate,
        UpdateSkillTypeNotFound,
        UpdateHasNotChanges,
        SkillTypeNotFound
    }
}
