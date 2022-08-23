using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MedNow.Infra.Auditing
{
    public interface IEntryAuditor
    {
        void AuditCreate(EntityEntry entry, DateTime? date = null);

        void AuditUpdate(EntityEntry entry, DateTime? date = null);

        void AuditDelete(EntityEntry entry, DateTime? date = null);
    }
}
