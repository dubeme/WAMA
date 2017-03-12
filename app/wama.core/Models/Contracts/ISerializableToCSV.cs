using System.Collections.Generic;

namespace WAMA.Core.Models.Contracts
{
    /// <summary>
    /// Contract to assist with converting an object to CSV
    /// </summary>
    public interface ISerializableToCSV
    {
        /// <summary>
        /// Gets the headers.
        /// </summary>
        IEnumerable<string> Headers { get; }

        /// <summary>
        /// Gets the CSV string.
        /// </summary>
        IEnumerable<string> CSVString { get; }
    }
}