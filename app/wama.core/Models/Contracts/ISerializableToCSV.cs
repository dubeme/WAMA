using System.Collections.Generic;

namespace WAMA.Core.Models.Contracts
{
    public interface ISerializableToCSV
    {
        IEnumerable<string> Headers { get; }

        IEnumerable<string> CSVString { get;  }
    }
}