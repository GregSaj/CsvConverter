using CsvConverter.Interfaces;
using CsvConverter.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CsvConverter.Services
{
    internal class TxtWriter : ITxtWriter
    {
        public void TxtWrite(string path, IEnumerable<Filter> list)
        {
            //using (TextWriter tw = new StreamWriter(path))
            //{
            //    foreach (var item in list)
            //    {
            //        tw.WriteLine($"Id: {item.Id} \t Name: {item.Name} \t Type: {item.Type} \t Currency: {item.Currency} \t NetPrice: {item.NetPrice}");

            //    }
            //}

            using (var writer = File.AppendText(path))
            {
                foreach (var item in list)
                {
                    writer.WriteLine($"{DateTime.UtcNow} Id: {item.Id} \t Name: {item.Name} \t Type: {item.Type} \t Currency: {item.Currency} \t NetPrice: {item.NetPrice}");
                   
                }
                writer.Dispose();
            }

            
        }
    }
}
