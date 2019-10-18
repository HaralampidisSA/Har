namespace Har.Domain.Entities
{
    public interface ISoftDelete
    {
        int? IsDeleted { get; set; }
    }
}
