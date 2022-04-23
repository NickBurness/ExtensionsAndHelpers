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
    }
}