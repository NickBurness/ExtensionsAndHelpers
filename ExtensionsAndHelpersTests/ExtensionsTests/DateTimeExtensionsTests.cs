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

        public static IEnumerable<object[]> IsWeekendData =>
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
        public static IEnumerable<object[]> IsMidWeekData =>
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

        public DateTimeExtensionsTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData("01/01/2022 00:00:00.00", true)]
        [InlineData("01/01/2022", true)]
        [InlineData("01 January 2022", true)]
        [InlineData("Sat, 01 Jan 2022", true)]
        [InlineData("Sat, 01 January 2022", true)]
        [InlineData("Sat, 1 Jan 22", true)]
        [InlineData("test", false)]
        [InlineData(null, false)]
        [InlineData("", false)]
        public void IsDateTime_ReturnsExpectedValue(string str, bool expected)
        {
            // act
            var result = str.IsDateTime();
            // assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(IsWeekendData))]
        public void IsWeekend_ReturnsExpectedValue(DateTime date, bool expected)
        {
            // act
            var result = date.IsWeekend();
            // assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(IsMidWeekData))]
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
    }
}
