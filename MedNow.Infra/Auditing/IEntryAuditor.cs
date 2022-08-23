using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace MedNow.Infra.Auditing
{
    public interface IEntryAuditor
    {
        void AuditCreate(EntityEntry entry, DateTime? date = null);

        void AuditUpdate(EntityEntry entry, DateTime? date = null);

        void AuditDelete(EntityEntry entry, DateTime? date = null);
    }
}
