namespace Har.Domain.Entities.Auditing
{
    public interface ICreationAudited : IHasCreationTime
    {
        string CreatorUserId { get; set; }
    }

    public interface ICreationAudited<TUser> : ICreationAudited where TUser : IEntity<string>
    {
        TUser CreatorUser { get; set; }
    }
}
