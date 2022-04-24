namespace ExtensionsAndHelpers
{
    public static class DateTimeExtensions
    {
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

        /// <summary>
        /// Calculates the Age from a date of birth
        /// </summary>
        /// <param name="dateOfBirth"></param>
        /// <returns>Age as int</returns>
        public static int Age(this DateTime dateOfBirth)
        {
            return (int)Math.Floor((DateTime.Today - dateOfBirth).TotalDays / 365.25);
        }

        /// <summary>
        /// Calculates the total number of days between a date range
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>Number of days between range</returns>
        public static int DaysBetween(DateTime start, DateTime end)
        {
            return (end.Date - start.Date).Days;
        }

        /// <summary>
        /// Calculates the total number of hours between a date range
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>Number of hours between range</returns>
        public static int HoursBetween(DateTime start, DateTime end)
        {
            return (int)(end.Date - start.Date).TotalHours;
        }

        /// <summary>
        /// Takes a start and end date and returns a list of those dates in an array.
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns>A list of dates between a range in an array</returns>
        public static DateTime[] GetDatesArray(this DateTime fromDate, DateTime toDate)
        {
            //int days = (toDate - fromDate).Days;
            int days = DaysBetween(fromDate, toDate);

            DateTime[] dates = new DateTime[days + 1];

            for (int i = 0; i <= days; i++)
            {
                dates[i] = fromDate.AddDays(i);
            }

            return dates;
        }
    }
}

