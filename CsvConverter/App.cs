using CsvConverter.Interfaces;
using CsvConverter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CsvConverter
{
    internal class App : IApp
    {
        private readonly ICsvReader _csvReader;
        private readonly IXmlWriter _xmlWriter;
        private readonly IJsonWriter<Filter> _jsonWriter;
        private readonly IJsonReader<Filter> _jsonReader;
        private readonly ITxtWriter _txtWriter;

        public App(
            ICsvReader csvReader, 
            IXmlWriter xmlWriter, 
            IJsonWriter<Filter> jsonWriter, 
            IJsonReader<Filter> jsonReader,
            ITxtWriter txtWriter
            )
        {
            _csvReader = csvReader;
            _xmlWriter = xmlWriter;
            _jsonWriter = jsonWriter;
            _jsonReader = jsonReader;
            _txtWriter = txtWriter;
        }

        public void Run()
        {
            string filePath = @"Files\filtr-catalogue.csv"; //jak zapisać do innego folderu w katalogu projektu
            string xmlFilePath = @"Files\filtr-catalogue.xml";
            string jsonFilePath = @"Files\filtr-catalogue.json";
            string txtFilePath = @"Files\filtr-catalogue.txt";

            var filters = _csvReader.ProcessFilters(filePath);

            var groups = filters
                .GroupBy(x => x.Type)
                .Select((g => new
                {
                    Type = g.Key,
                    AverageNetPrice = g.Average(c => c.NetPrice),
                    LowestNetPrice = g.Min(c => c.NetPrice),
                    HighestNetPrice = g.Max(c => c.NetPrice),
                    Variety = g.Count(),
                }))
                .OrderByDescending(g => g.AverageNetPrice)
               ;

            foreach (var item in groups)
            {
                Console.WriteLine($"Type: {item.Type}");
                Console.WriteLine($"\tAverage net price: {item.AverageNetPrice:F2}");
                Console.WriteLine($"\tHighset net price: {item.HighestNetPrice:F2}");
                Console.WriteLine($"\tLowest net price: {item.LowestNetPrice:F2}");
                Console.WriteLine($"\tVariety: {item.Variety}");
            }

            _xmlWriter.CreateXml(filePath, xmlFilePath);
            _jsonWriter.WriteToJson(filters, jsonFilePath);
            
            var listOfObjects = _jsonReader.ReadJson(jsonFilePath);

            var filtersFromJson = listOfObjects.GroupBy(x => x.Type)
                .Select((g => new
                {
                    Type = g.Key,
                    AverageNetPrice = g.Average(c => c.NetPrice),
                    LowestNetPrice = g.Min(c => c.NetPrice),
                    HighestNetPrice = g.Max(c => c.NetPrice),
                    Variety = g.Count(),
                }))
                .OrderByDescending(g => g.AverageNetPrice)
               ;

            Console.WriteLine("Filters from Json:");
            foreach (var item in filtersFromJson)
            {
                Console.WriteLine($"Type: {item.Type}");
                Console.WriteLine($"\tAverage net price: {item.AverageNetPrice:F2}");
                Console.WriteLine($"\tHighset net price: {item.HighestNetPrice:F2}");
                Console.WriteLine($"\tLowest net price: {item.LowestNetPrice:F2}");
                Console.WriteLine($"\tVariety: {item.Variety:F2}");

            }


            _txtWriter.TxtWrite(txtFilePath, listOfObjects);

        }
    }
}
