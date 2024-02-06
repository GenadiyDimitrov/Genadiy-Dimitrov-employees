using System;
using System.Collections.Generic;

namespace Employees
{
    /// <summary>
    /// Extention for getting Min and Max from Two dates.
    /// </summary>
    public static class DateExtentions
    {
        public static DateTime Max(this DateTime first, DateTime second)
        {
            if (Comparer<DateTime>.Default.Compare(first, second) > 0)
                return first;
            return second;
        }
        public static DateTime Min(this DateTime first, DateTime second)
        {
            if (Comparer<DateTime>.Default.Compare(first, second) > 0)
                return second;
            return first;
        }
    }
}
