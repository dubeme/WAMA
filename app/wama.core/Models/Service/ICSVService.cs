using System.Collections.Generic;
using WAMA.Core.Models.Contracts;

namespace WAMA.Core.Models.Service
{
    public interface ICSVService
    {
        string ToCSV<T>(IEnumerable<T> items) where T : ISerializableToCSV;
    }
}