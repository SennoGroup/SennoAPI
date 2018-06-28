using System;

namespace SennoAPI.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime StartOfDay(this DateTime source)
        {
            return source.Date;
        }

        public static DateTime EndOfDay(this DateTime source)
        {
            return source.Date.AddDays(1).AddTicks(-1);
        }
    }
}
