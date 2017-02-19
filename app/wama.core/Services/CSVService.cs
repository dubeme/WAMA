using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using WAMA.Core.Models.Attributes;
using WAMA.Core.Models.Service;

namespace WAMA.Core.Services
{
    public class CSVService : ICSVService
    {
        public string ToCSV<T>(IEnumerable<T> items)
        {
            // https://stackoverflow.com/questions/3199604/is-there-a-quick-way-to-convert-an-entity-to-csv-file
            var serializableProperties = items
                .First()
                .GetType()
                .GetProperties()
                .Where(property => property.GetCustomAttribute<CSVIgnoreAttribute>() == default(CSVIgnoreAttribute));

            var headers = serializableProperties.Select(prop => prop.Name);
            var headerCSV = string.Join(",", headers);

            var values = items.Select(item => ObjectToCSV(item, serializableProperties));
            var valuesCSV = string.Join("\n", values);

            return $"{headerCSV}\n{valuesCSV}";
        }

        private string ObjectToCSV<T>(T item, IEnumerable<PropertyInfo> serializableProperties)
        {
            var values = serializableProperties.Select(property => SanitizeValue(property.GetValue(item)));

            return string.Join(",", values);
        }

        private object SanitizeValue(object value)
        {
            var valueStringWithDoubleQuotesEscaped = Regex.Replace($"{value}", "\"", "\"\"");

            return $"\"{valueStringWithDoubleQuotesEscaped}\"";
        }
    }
}