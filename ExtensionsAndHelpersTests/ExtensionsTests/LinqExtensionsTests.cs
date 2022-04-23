using ExtensionsAndHelpers;
using System.Collections.Generic;
using Xunit;

namespace ExtensionsAndHelpersTests
{
    public class LinqExtensionsTests
    {
        public static List<string> _myList => new List<string>() { "foo", "bar", "foo" };

        [Fact]
        public void None_ReturnsFalseWhenIsNotEmpty()
        {
            // act
            bool result = _myList.None(x => x == "foo" || x == "bar");
            bool result2 = _myList.None();
            // assert
            Assert.False(result);
            Assert.False(result2);
        }

        [Fact]
        public void Many_ReturnsTrueIfGreaterThanOneInCollectionOrFromExpression()
        {
            // act
            bool result = _myList.Many();
            bool result2 = _myList.Many(x => x == "foo");
            bool result3 = _myList.Many(x => x == "bar" || x == "fong");
            // assert
            Assert.True(result);
            Assert.True(result2);
            Assert.False(result3);
        }

        [Fact]
        public void OneOf_ReturnsFalseIfNotExactlyOne()
        {
            // act
            bool result = _myList.OneOf();
            bool result2 = _myList.OneOf(x => x == "foo");
            bool result3 = _myList.OneOf(x => x == "bar");
            // assert
            Assert.False(result);
            Assert.False(result2);
            Assert.True(result3);
        }

        [Fact]
        public void XOf_WorksCorrectly()
        {
            // act
            bool result = _myList.XOf(3);
            bool result2 = _myList.XOf(x => x == "foo", 2);
            bool result3 = _myList.XOf(x => x == "bar", 1);
            bool result4 = _myList.XOf(x => x == "baz", 2);
            // assert
            Assert.True(result);
            Assert.True(result2);
            Assert.True(result3);
            Assert.False(result4);
        }
    }
}
