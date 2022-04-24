using ExtensionsAndHelpers;
using System.Text;
using Xunit;

namespace ExtensionsAndHelpersTests
{
    public class StringBuilderExtensionsTests
    {
        [Fact]
        public void Clear_ResetsTheStringBuilder()
        {
            // arrange
            StringBuilder sb = new StringBuilder();
            sb.Append(true);
            int expected = 0;
            // act
            StringBuilderExtensions.Clear(sb);
            var result = sb.Length;
            // assert
            Assert.Equal(expected, result);
        }
    }
}
