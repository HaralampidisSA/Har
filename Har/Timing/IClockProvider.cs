using System;

namespace Har.Timing
{
    public interface IClockProvider
    {
        DateTime Now { get; }

        DateTimeKind DateTimeKind { get; }

        bool SupportsMultipleTimezone { get; }

        DateTime Normalize(DateTime dateTime);
    }
}
