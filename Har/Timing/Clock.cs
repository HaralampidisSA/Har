using System;

namespace Har.Timing
{
    public static class Clock
    {
        private static IClockProvider _provider;

        public static IClockProvider Provider
        {
            get
            {
                return _provider;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Can not set Clock.Provider to null!");
                }

                _provider = value;
            }
        }

        static Clock()
        {
            Provider = ClockProviders.Unspecified;
        }

        public static DateTime Now => Provider.Now;

        public static DateTimeKind Kind => Provider.DateTimeKind;

        public static bool SupportsMultipleTimezone => Provider.SupportsMultipleTimezone;

        public static DateTime Normalize(DateTime dateTime)
        {
            return Provider.Normalize(dateTime);
        }
    }
}
