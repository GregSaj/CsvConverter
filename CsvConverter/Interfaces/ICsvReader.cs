using CsvConverter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvConverter.Interfaces
{
    interface ICsvReader
    {
        List<Filter> ProcessFilters(string filePath);
    }
}
