using System;

namespace Har.Domain.Entities.Auditing
{
    public interface IHasCreationTime
    {
        DateTime DateCreated { get; set; }
    }
}
