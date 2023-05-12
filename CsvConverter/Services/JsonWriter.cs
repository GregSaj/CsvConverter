using CsvConverter.Interfaces;
using CsvConverter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CsvConverter.Services
{
    public class JsonWriter<T> : IJsonWriter<T> where T : class
    {
        public void WriteToJson(List<T> list, string fileJsonPath)
        {
            string json = JsonSerializer.Serialize(list);
            File.WriteAllText(fileJsonPath, json);
        }
    }
}
