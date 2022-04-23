using System.Text;

namespace ExtensionsAndHelpers
{
    public static class StringBuilderExtensions
    {
        public static void Clear(this StringBuilder sb)
        {
            sb.Length = 0;
        }
    }
}
