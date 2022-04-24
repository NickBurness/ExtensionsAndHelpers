using ExtensionsAndHelpers;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace ExtensionsAndHelpersTests
{
    public class DateTimeExtensionsTests
    {
        private readonly ITestOutputHelper output;
        public DateTimeExtensionsTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        public static IEnumerable<object[]> IsWeekendTestData =>
            new List<object[]>
            {
                new object[] { new DateTime(2022, 01, 01), true },
                new object[] { new DateTime(2022, 01, 02), true },
                new object[] { new DateTime(2022, 01, 03), false },
                new object[] { new DateTime(2022, 01, 04), false },
                new object[] { new DateTime(2022, 01, 05), false },
                new object[] { new DateTime(2022, 01, 06), false },
                new object[] { new DateTime(2022, 01, 07), false },
            };
        public static IEnumerable<object[]> IsMidWeekTestData =>
            new List<object[]>
            {
                 new object[] { new DateTime(2022, 01, 01), false },
                 new object[] { new DateTime(2022, 01, 02), false },
                 new object[] { new DateTime(2022, 01, 03), true },
                 new object[] { new DateTime(2022, 01, 04), true },
                 new object[] { new DateTime(2022, 01, 05), true },
                 new object[] { new DateTime(2022, 01, 06), true },
                 new object[] { new DateTime(2022, 01, 07), true },
            };
        public static IEnumerable<object[]> TotalDaysTestData =>
            new List<object[]>
            {
                 new object[] { new DateTime(2022, 01, 01), new DateTime(2022, 01, 07), 6 },
                 new object[] { new DateTime(2022, 01, 07), new DateTime(2022, 01, 01), -6 },
            };
        public static IEnumerable<object[]> TotalHoursTestData =>
            new List<object[]>
            {
                 new object[]
                 {
                     new DateTime(2022, 01, 01),
                     new DateTime(2022, 01, 07),
                     144
                 },
                 new object[]
                 {
                     new DateTime(2022, 01, 07),
                     new DateTime(2022, 01, 01),
                     -144 },
            };
        public static IEnumerable<object[]> DatesArrayTestData =>
            new List<object[]>
            {
                 new object[] {
                     new DateTime(2022, 01, 01),
                     new DateTime(2022, 01, 07),
                            new DateTime[]
                            {
                                new DateTime(2022, 01, 01), new DateTime(2022, 01, 02),
                                new DateTime(2022, 01, 03), new DateTime(2022, 01, 04),
                                new DateTime(2022, 01, 05), new DateTime(2022, 01, 06),
                                new DateTime(2022, 01, 07)
                            }
                 },

            };

        [Theory]
        [MemberData(nameof(IsWeekendTestData))]
        public void IsWeekend_ReturnsExpectedValue(DateTime date, bool expected)
        {
            // act
            var result = date.IsWeekend();
            // assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(IsMidWeekTestData))]
        public void IsMidweek_ReturnsExpectedValue(DateTime date, bool expected)
        {
            // act
            var result = date.IsMidWeek();
            // assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Age_ReturnsExpectedValue()
        {
            // arrange
            DateTime dateOfBirth = new DateTime(DateTime.Now.Year - 21, 01, 01);
            int expected = 21;
            // act
            int result = dateOfBirth.Age();
            // assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(TotalDaysTestData))]
        public void DaysBetween_ReturnsTotalNumberOfDaysBetweenARange(DateTime start, DateTime end, int expected)
        {
            // act
            var result = DateTimeExtensions.DaysBetween(start, end);
            // assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(TotalHoursTestData))]
        public void HoursBetween_ReturnsTotalNumberOfHoursBetweenARange(DateTime start, DateTime end, int expected)
        {
            // act
            var result = DateTimeExtensions.HoursBetween(start, end);
            // assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(DatesArrayTestData))]
        public void GetDatesArray_ReturnsTotalNumberOfHoursBetweenARange(DateTime start, DateTime end, DateTime[] expected)
        {
            // act
            var result = DateTimeExtensions.GetDatesArray(start, end);
            // assert
            Assert.Equal(expected, result);
        }
    }
}
