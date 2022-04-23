using System.Text.RegularExpressions;

namespace ExtensionsAndHelpers
{
    public static class StringExtensions
    {
        /// <summary>
        /// checks if the string is not null
        /// </summary>
        public static bool IsNotNull(this string str)
        {
            return str != null;
        }

        /// <summary>
        /// checks if the string is not null or a empty value
        /// </summary>
        public static bool IsNotNullOrEmpty(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// checks if the string is not null
        /// </summary>
        public static bool IsNull(this string str)
        {
            return str == null;
        }

        /// <summary>
        /// reverses the contents of a string
        /// </summary>
        public static string Reverse(this string str)
        {
            if (str.Length <= 1)
            {
                return str;
            }

            char[] characters = str.ToCharArray();
            Array.Reverse(characters);

            return new string(characters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int? TryParseAlphanumericString(this string str)
        {
            str = Regex.Replace(str, "[^0-9]+", string.Empty);

            if (int.TryParse(str, out int result))
            {
                return result;
            };

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNumeric(this string str)
        {
            if (int.TryParse(str, out int result))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="minLength"></param>
        /// <returns></returns>
        public static bool IsStrongPassword(this string str, int minLength)
        {
            if (str.Length >= minLength)
            {
                bool containsInt = Regex.IsMatch(str, @"[\d]");
                bool containsLower = Regex.IsMatch(str, @"[a-z]");
                bool containsUpper = Regex.IsMatch(str, @"[A-Z]");
                bool containsNonAlpha = Regex.IsMatch(str, @"[\s~!@#\$%\^&\*\(\)\{\}\|\[\]\\:;'?,.`+=<>\/]");

                if (containsInt && containsLower && containsUpper && containsNonAlpha)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static MemoryStream ToMemoryStream(this string str)
        {
            byte[] Bytes = System.Text.Encoding.ASCII.GetBytes(str);

            return new MemoryStream(Bytes);
        }
    }
}

