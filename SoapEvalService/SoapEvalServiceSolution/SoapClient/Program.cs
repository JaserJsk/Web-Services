using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoapClient.RiksbankServiceReference;
using SoapClient.SoapServiceReference;
using Exception = System.Exception;

namespace SoapClient
{
    class Program
    {
        static void Main(string[] args)
        {
            MediaService();

            //SweaService();
        }

        private static void MediaService()
        {
            MediaServiceClient client = new MediaServiceClient("WSHttpBinding_IMediaService");

            try
            {
                #region ADD
                Book br1 = new Book
                {
                    Id = 1,
                    Title = "Tom Sawyer",
                    NbrOfPages = 652,
                    Type = "AudioBook",
                    Price = 7.57M
                };

                Book br2 = new Book
                {
                    Id = 2,
                    Title = "The Count OF Monte Cristo",
                    NbrOfPages = 1052,
                    Type = "HardCover",
                    Price = 12.60M
                };
                client.PostBooks(br1);
                client.PostBooks(br2);
                #endregion

                #region GET
                var result = client.GetAllBooks();
                foreach (var item in result) 
                {
                    Console.WriteLine($"ID: {item.Id} - TITLE: {item.Title} - NUMBER OF PAGES: {item.NbrOfPages} - TYPE: {item.Type} - PRICE: {item.Price}");
                }
                #endregion

                #region REMOVE
                var removed = client.RemoveBookFromLIbrary(1);
                Console.WriteLine("\nDeleted Books");
                Console.WriteLine($"ID: {removed.Id} - TITLE: {removed.Title} - NUMBER OF PAGES: {removed.NbrOfPages} - TYPE: {removed.Type} - PRICE: {removed.Price}");
                #endregion

                Console.ReadLine();

                #region GET
                var resultt = client.GetAllBooks();
                foreach (var item in resultt)
                {
                    Console.WriteLine($"ID: {item.Id} - TITLE: {item.Title} - NUMBER OF PAGES: {item.NbrOfPages} - TYPE: {item.Type} - PRICE: {item.Price}");
                }
                #endregion

                Console.ReadLine();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            
        }

        private static void SweaService()
        {
            SweaWebServicePortTypeClient swea = new SweaWebServicePortTypeClient("SweaWebServiceHttpSoap12Endpoint");

            var result = swea.getAllCrossNames(LanguageType.sv);
            foreach (var item in result)
            {
                Console.WriteLine($"ID: {item.seriesid} - Name: {item.seriesname} - Description: {item.seriesdescription}");
            }

            Console.ReadLine();
        }
    }
}
