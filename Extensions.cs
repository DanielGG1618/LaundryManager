using System;

namespace LaundryManager
{
    public static class DateTimeExtentions
    {
        public static string ToSQLstring(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }
    }
}
