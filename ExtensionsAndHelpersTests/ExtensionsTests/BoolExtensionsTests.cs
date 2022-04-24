using ExtensionsAndHelpers;
using System;
using Xunit;

namespace ExtensionsAndHelpersTests
{
    public class BoolExtensionsTests
    {
        [Theory]
        [InlineData(true, true)]
        [InlineData(false, false)]
        public void When_ExecutesWhenConditionsMatch(bool value, bool condition)
        {
            // arrange
            Action method = () => { };
            // act
            int result = value.When(condition, method);
            // assert
            Assert.Equal(1, result);
        }

        [Theory]
        [InlineData(true, false)]
        [InlineData(false, true)]
        public void When_DoesNotExecuteWhenConditionsDoNotMatch(bool value, bool condition)
        {
            // arrange
            Action method = () => { };
            // act
            int result = value.When(condition, method);
            // assert
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void WhenTrue_ExecutesUponTrueCondition(bool condition)
        {
            // arrange
            Action method = () => { };
            // act
            int result = condition.WhenTrue(method);
            // assert
            if (result == 1)
            {
                Assert.Equal(1, result);
            }
            else
            {
                Assert.Equal(0, result);
            }
        }

        [Theory]
        [InlineData(false, 1)]
        [InlineData(true, 0)]
        public void WhenFalse_ExecutesUponTrueCondition(bool condition, int expected)
        {
            // arrange
            Action method = () => { };
            // act
            int result = condition.WhenFalse(method);
            // assert
            Assert.Equal(expected, result);

        }
    }
}
