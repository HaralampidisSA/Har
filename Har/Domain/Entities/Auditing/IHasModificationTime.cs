using System;

namespace Har.Domain.Entities.Auditing
{
    public interface IHasModificationTime
    {
        DateTime? DateUpdated { get; set; }
    }
}
