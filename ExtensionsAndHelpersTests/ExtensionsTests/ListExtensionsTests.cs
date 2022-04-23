using ExtensionsAndHelpers;
using System.Collections.Generic;
using Xunit;

namespace ExtensionsAndHelpersTests
{
    public class ListExtensionsTests
    {
        List<int> _list = new List<int>() { 1, 2, 3 };
        List<int> _items = new List<int>() { 4, 5, };

        [Fact]
        public void AddIf_AddsToListWhenConditionIsTrue()
        {
            // arrange
            int expected = 4;
            // act
            _list.AddIf(true, 4);
            int result = _list.Count;
            // assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void AddIf_IsUnchangedWhenConditionIsFalse()
        {
            // arrange
            int expected = 3;
            // act
            _list.AddIf(false, 3);
            int result = _list.Count;
            // assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void AddRangeIf_AddsToListWhenConditionIsTrue()
        {
            // arrange
            int expected = 5;
            // act
            _list.AddRangeIf(true, _items);
            int result = _list.Count;
            // assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void AddRangeIf_IsUnchangedWhenConditionIsFalse()
        {
            // arrange
            int expected = 3;
            // act
            _list.AddRangeIf(false, _items);
            int result = _list.Count;
            // assert
            Assert.Equal(expected, result);
        }
    }
}
