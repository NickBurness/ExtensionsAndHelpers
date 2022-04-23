namespace ExtensionsAndHelpers
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// checks if the string is a valid DateTime
        /// </summary>
        public static bool IsDateTime(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            if (DateTime.TryParse(str, out DateTime result))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// checks if the given DateTime is on the weekend
        /// </summary>
        public static bool IsWeekend(this DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// checks if the given DateTime is midweek 
        /// </summary>
        public static bool IsMidWeek(this DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static int Age(this DateTime dateOfBirth)
        {
            return (int)Math.Floor((DateTime.Today - dateOfBirth).TotalDays / 365.25);
        }

        public static int DaysBetween(DateTime start, DateTime end)
        {
            return (end.Date - start.Date).Days;
        }

        public static int HoursBetween(DateTime start, DateTime end)
        {
            return (int)(end.Date - start.Date).TotalHours;
        }
    }
}

