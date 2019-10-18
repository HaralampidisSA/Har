namespace Har.Domain.Entities.Auditing
{
    public interface IModificationAudited : IHasModificationTime
    {
        string LastModifierUserId { get; set; }
    }

    public interface IModificationAudited<TUser> : IModificationAudited where TUser : IEntity<string>
    {
        TUser LastModifierUser { get; set; }
    }
}
