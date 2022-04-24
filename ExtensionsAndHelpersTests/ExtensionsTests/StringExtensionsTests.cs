using ExtensionsAndHelpers;
using System;
using Xunit;

namespace ExtensionsAndHelpersTests
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData(null, false)]
        [InlineData("test", true)]
        [InlineData("", true)]
        public void IsNotNull_ReturnsExpectedValue(string str, bool expected)
        {
            // act
            bool result = str.IsNotNull();
            // assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("test", true)]
        [InlineData("", false)]
        public void IsNotNullOrEmpty_ReturnsExpectedValue(string str, bool expected)
        {
            // act
            bool result = str.IsNotNullOrEmpty();
            // assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(null, true)]
        [InlineData("test", false)]
        [InlineData("", false)]
        public void IsNull_ReturnsExpectedValue(string str, bool expected)
        {
            // act
            bool result = str.IsNull();
            // assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("racecar", "racecar")]
        [InlineData("test", "tset")]
        [InlineData("x","x")]
        public void Reverse_ReturnsExpectedValue(string str, string expected)
        {
            // act
            string result = str.Reverse();
            // assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("test123", 123)]
        [InlineData("test", null)]
        [InlineData("012", 012)]
        [InlineData("2147483647", int.MaxValue)]
        [InlineData(" ", null)]
        public void ParseAlphanumericString(string str, int? expected)
        {
            // act
            int? result = str.TryParseAlphanumericString();
            // assert
            Assert.Equal(expected, result);
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
        [InlineData("123", true)]
        [InlineData("test", false)]
        [InlineData(null, false)]
        public void IsNumeric_ReturnsBool(string str, bool expected)
        {
            // act
            var result = str.IsNumeric();
            // assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("tester", 6, false)]
        [InlineData("Tester", 6, false)]
        [InlineData("Tester1", 6, false)]
        [InlineData("Tester1!", 6, true)]
        public void IsStrongPassword_ReturnsBool(string str, int minLength, bool expected)
        {
            // act
            var result = str.IsStrongPassword(minLength);
            // assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("racecar", 5,"ar")]
        [InlineData(null, 5, null)]
        public void Right_ReturnsCharactersFromSpecifiedLength(string str, int length, string expected)
        {
            // act
            var result = str.Right(length);
            // assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("racecar", 5, "racec")]
        [InlineData(null, 5, null)]
        public void Left_ReturnsCharactersFromSpecifiedLength(string str, int length, string expected)
        {
            // act
            var result = str.Left(length);
            // assert
            Assert.Equal(expected, result);
        }
    }
}