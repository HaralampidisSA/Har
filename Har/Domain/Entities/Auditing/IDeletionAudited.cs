namespace Har.Domain.Entities.Auditing
{
    public interface IDeletionAudited : IHasDeletionTime
    {
        string DeleterUserId { get; set; }
    }

    public interface IDeletionAudited<TUser> : IDeletionAudited where TUser : IEntity<string>
    {
        TUser DeleterUser { get; set; }
    }
}
