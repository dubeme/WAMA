using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using WAMA.Core.Models.Contracts;
using WAMA.Core.Models.Service;

namespace WAMA.Core.Services
{
    /// <summary>
    /// Represents CSVService
    /// </summary>
    /// <seealso cref="WAMA.Core.Models.Service.ICSVService" />
    public class CSVService : ICSVService
    {
        /// <summary>
        /// To the CSV.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        public string ToCSV<T>(IEnumerable<T> items) where T : ISerializableToCSV
        {
            var headerCSV = string.Join(",", items.First().Headers.Select(SanitizeValue));
            var valuesCSV = string.Join(System.Environment.NewLine, items.Select(item =>
                string.Join(",", item.CSVString.Select(SanitizeValue))));

            return $"{headerCSV}\n{valuesCSV}";
        }

        /// <summary>
        /// Sanitizes the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private object SanitizeValue(object value)
        {
            var valueStringWithDoubleQuotesEscaped = Regex.Replace($"{value}", "\"", "\"\"");

            return $"\"{valueStringWithDoubleQuotesEscaped}\"";
        }
    }
}