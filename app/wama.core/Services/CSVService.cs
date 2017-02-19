using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using WAMA.Core.Models.Contracts;
using WAMA.Core.Models.Service;

namespace WAMA.Core.Services
{
    public class CSVService : ICSVService
    {
        public string ToCSV<T>(IEnumerable<T> items) where T : ISerializableToCSV
        {
            var headerCSV = string.Join(",", items.First().Headers.Select(SanitizeValue));
            var valuesCSV = string.Join(System.Environment.NewLine, items.Select(item =>
                string.Join(",", item.CSVString.Select(SanitizeValue))));

            return $"{headerCSV}\n{valuesCSV}";
        }

        private object SanitizeValue(object value)
        {
            var valueStringWithDoubleQuotesEscaped = Regex.Replace($"{value}", "\"", "\"\"");

            return $"\"{valueStringWithDoubleQuotesEscaped}\"";
        }
    }
}