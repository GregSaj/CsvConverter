using CsvConverter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvConverter.Interfaces
{
    internal interface IJsonWriter<T>
    {
        void WriteToJson(List<T> list, string fileJsonPath);

    }
}
