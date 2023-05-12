using CsvConverter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CsvConverter.Services
{
    internal class XmlWriter : IXmlWriter
    {
        private readonly ICsvReader _csvReader;

        public XmlWriter(ICsvReader csvReader)
        {
            _csvReader = csvReader;
        }

        public void CreateXml(string csvFilePath, string xmlFilePath) //jak zrobić generyczna metode
        {
            var records = _csvReader.ProcessFilters(csvFilePath);

            var document = new XDocument();
            var objects = new XElement("Filters", records
                .Select(x =>
                new XElement("Filter",
                new XAttribute("Id", x.Id),
                new XAttribute("Name", x.Name),
                new XAttribute("Type", x.Type),
                new XAttribute("Currency", x.Currency),
                new XAttribute("NetPrice", x.NetPrice),
                new XAttribute("GrossPrice", x.GrossPrice))
                ));
            
            document.Add(objects);
            document.Save(xmlFilePath);

        }
    }
}
