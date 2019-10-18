using Har.Domain.Entities.Auditing;
using Har.Extensions;

namespace Har.Domain.Entities
{
    public static class BaseEntityExtensions
    {
        public static bool IsNullOrDeleted(this ISoftDelete entity)
        {
            return entity == null || entity.IsDeleted == 1;
        }

        public static void UdDelete(this ISoftDelete entity)
        {
            entity.IsDeleted = 0;
            if (entity is IDeletionAudited)
            {
                var deletionAuditedEntity = entity.As<IDeletionAudited>();
                deletionAuditedEntity.DateDeleted = null;
                deletionAuditedEntity.DeleterUserId = null;
            }
        }
    }
}
