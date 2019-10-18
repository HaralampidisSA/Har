namespace Har.Domain.Entities
{
    public abstract class BaseEntity : BaseEntity<int>, IEntity
    {
        public virtual byte[] Timestamp { get; set; }
    }

    public abstract class BaseEntity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }
    }
}
