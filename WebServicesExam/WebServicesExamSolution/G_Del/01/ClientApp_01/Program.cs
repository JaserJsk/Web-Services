using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientApp_01.SweaServiceReference;

namespace ClientApp_01
{
    class Program
    {
        static void Main(string[] args)
        {
            SweaWebServicePortTypeClient client = new SweaWebServicePortTypeClient("SweaWebServiceHttpSoap12Endpoint");

            var result = client.getAllCrossNames(LanguageType.sv);
            foreach (var item in result)
            {
                Console.WriteLine($"ID: {item.seriesid} - Name: {item.seriesname} - Description: {item.seriesdescription}");
            }

            Console.ReadLine();

        }
    }
}
