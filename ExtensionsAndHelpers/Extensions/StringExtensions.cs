using System.Text.RegularExpressions;

namespace ExtensionsAndHelpers
{
    public static class StringExtensions
    {
        /// <summary>
        /// checks if the string is not null
        /// </summary>
        public static bool IsNull(this string str)
        {
            return str == null;
        }

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
        /// Tries to parse an alphanumeric string like "abc123" into a number 123
        /// </summary>
        /// <param name="str"></param>
        /// <returns>nullable int representing the numeric result</returns>
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
        /// Checks if a string can be parsed into a number
        /// </summary>
        /// <param name="str"></param>
        /// <returns>bool value representing the result</returns>
        public static bool IsNumeric(this string str)
        {
            if (int.TryParse(str, out int result))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if a string conforms to a regeex password policy
        /// </summary>
        /// <param name="str"></param>
        /// <param name="minLength"></param>
        /// <returns>bool value representing if it is a strong password</returns>
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
        /// checks if the string is a valid DateTime
        /// </summary>
        public static bool IsDateTime(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            if (DateTime.TryParse(str, out DateTime result))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns characters from right of specified length
        /// </summary>
        /// <param name="str">String value</param>
        /// <param name="length">Max number of charaters to return</param>
        /// <returns>Returns string from right</returns>
        public static string Right(this string str, int length)
        {
            if (str.IsNotNull() && str.Length > length)
            {
                return str.Substring(length);
            }
            else
            {
                return str;
            }
        }

        /// <summary>
        /// Returns characters from left of specified length
        /// </summary>
        /// <param name="str">String value</param>
        /// <param name="length">Max number of charaters to return</param>
        /// <returns>Returns string from left</returns>
        public static string Left(this string str, int length)
        {
            if (str.IsNotNull() && str.Length > length)
            {
                return str.Substring(0, length);
            }
            else
            {
                return str;
            }
        }
    }
}

