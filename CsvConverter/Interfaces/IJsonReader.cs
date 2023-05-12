using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvConverter.Interfaces
{
    public interface IJsonReader<T>
    {
        IEnumerable<T> ReadJson(string filePath);
    }
}
