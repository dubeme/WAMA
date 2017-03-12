using System.Text.RegularExpressions;

namespace WAMA.Core.Extensions
{
    /// <summary>
    /// Represents StringExtensions
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Removes the word "controller" from the end of the string
        /// </summary>
        /// <param name="controllerName">String to search</param>
        /// <returns>
        /// Cleaned string
        /// </returns>
        public static string StripController(this string controllerName)
        {
            return Regex.Replace(controllerName, @"(?=\w+)controller$", "", RegexOptions.IgnoreCase);
        }
    }
}