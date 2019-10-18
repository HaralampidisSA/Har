using System;

namespace Har.Domain.Entities.Auditing
{
    public interface IHasDeletionTime : ISoftDelete
    {
        DateTime? DateDeleted { get; set; }
    }
}
