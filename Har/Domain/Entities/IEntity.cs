namespace Har.Domain.Entities
{
    public interface IEntity : IEntity<int>
    {
        byte[] Timestamp { get; set; }
    }

    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}
