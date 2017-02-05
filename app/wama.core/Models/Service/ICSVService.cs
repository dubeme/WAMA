using System.Collections.Generic;

namespace WAMA.Core.Models.Service
{
    public interface ICSVService
    {
        string ToCSV<T>(IEnumerable<T> items);
    }
}