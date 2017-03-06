using System.Collections.Generic;
using WAMA.Core.Models.Contracts;

namespace WAMA.Core.Models.Service
{
    /// <summary>
    /// Contract for to assist with converting an object to CSV
    /// </summary>
    public interface ICSVService
    {
        /// <summary>
        /// To the CSV.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        string ToCSV<T>(IEnumerable<T> items) where T : ISerializableToCSV;
    }
}