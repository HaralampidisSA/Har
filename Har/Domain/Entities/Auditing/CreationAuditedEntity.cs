using Har.Timing;
using System;

namespace Har.Domain.Entities.Auditing
{
    public abstract class CreationAuditedEntity : CreationAuditedEntity<int>, IEntity
    {
        public byte[] Timestamp { get; set; }
    }

    public abstract class CreationAuditedEntity<TPrimaryKey> : BaseEntity<TPrimaryKey>, ICreationAudited
    {
        public virtual string CreatorUserId { get; set; }
        public virtual DateTime DateCreated { get; set; }

        protected CreationAuditedEntity()
        {
            DateCreated = Clock.Now;
        }
    }

    public abstract class CreationAuditedEntity<TPrimaryKey, TUser> : CreationAuditedEntity<TPrimaryKey>, ICreationAudited<TUser> where TUser : IEntity<string>
    {
        public virtual TUser CreatorUser { get; set; }
    }
}
