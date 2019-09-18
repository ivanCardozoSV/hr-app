using System;

namespace Core.ExtensionHelpers
{
    public static class AuditableExtensions
    {
        public static void AuditCreate(this IAuditable auditable, string userName)
        {
            auditable.CreatedBy = userName;
            auditable.CreatedDate = DateTime.Now;

            auditable.LastModifiedBy = auditable.CreatedBy;
            auditable.LastModifiedDate = auditable.CreatedDate;
        }

        public static void AuditModify(this IAuditable auditable, string userName)
        {
            auditable.LastModifiedBy = userName;
            auditable.LastModifiedDate = DateTime.Now;
        }
    }
}
