using System;

namespace Har.Domain.Entities.Auditing
{
    public abstract class FullAuditedEntity : FullAuditedEntity<int>, IEntity
    {
        public byte[] Timestamp { get; set; }
    }

    public abstract class FullAuditedEntity<TPrimaryKey> : AuditedEntity<TPrimaryKey>, IFullAudited
    {
        public virtual string DeleterUserId { get; set; }
        public virtual DateTime? DateDeleted { get; set; }
        public virtual int? IsDeleted { get; set; }
    }

    public abstract class FullAuditedEntity<TPrimaryKey, TUser> : AuditedEntity<TPrimaryKey, TUser>, IFullAudited<TUser> where TUser : IEntity<string>
    {
        public virtual TUser DeleterUser { get; set; }
        public string DeleterUserId { get; set; }
        public DateTime? DateDeleted { get; set; }
        public int? IsDeleted { get; set; }
    }
}
