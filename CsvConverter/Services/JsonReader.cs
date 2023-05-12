using CsvConverter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CsvConverter.Services
{
    internal class JsonReader<T> : IJsonReader<T> where T : class
    {
        public IEnumerable<T> ReadJson(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            var objects = JsonSerializer.Deserialize<IEnumerable<T>>(jsonString);
            return objects;
        }
    }
}
