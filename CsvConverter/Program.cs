using CsvConverter.Interfaces;
using CsvConverter.Models;
using CsvConverter.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CsvConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddSingleton<IApp, App>();
            services.AddSingleton<ICsvReader, CsvReader>();
            services.AddSingleton<IXmlWriter, XmlWriter>();
            services.AddSingleton<IJsonWriter<Filter>, JsonWriter<Filter>>();   
            services.AddSingleton<IJsonReader<Filter>, JsonReader<Filter>>();   
            services.AddSingleton<ITxtWriter, TxtWriter>();
           
            var serviceProvide = services.BuildServiceProvider();
            var app = serviceProvide.GetService<IApp>()!;
            app.Run();


        }
    }
}