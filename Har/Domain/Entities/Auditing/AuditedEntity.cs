using System;

namespace Har.Domain.Entities.Auditing
{
    public abstract class AuditedEntity : AuditedEntity<int>, IEntity
    {
        public byte[] Timestamp { get; set; }
    }

    public abstract class AuditedEntity<TPrimaryKey> : CreationAuditedEntity<TPrimaryKey>, IAudited
    {
        public virtual string LastModifierUserId { get; set; }
        public virtual DateTime? DateUpdated { get; set; }
    }

    public abstract class AuditedEntity<TPrimaryKey, TUser> : AuditedEntity<TPrimaryKey>, IAudited<TUser> where TUser : IEntity<string>
    {
        public virtual TUser CreatorUser { get; set; }
        public virtual TUser LastModifierUser { get; set; }
    }
}
