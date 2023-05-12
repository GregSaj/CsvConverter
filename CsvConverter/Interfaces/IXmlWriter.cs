using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvConverter.Interfaces
{
    public interface IXmlWriter
    {
        void CreateXml(string csvFilePath, string xmlFilePath);
    }
}
