using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoapClient.RiksbankServiceReference;
using SoapClient.SoapEvalReference;
using Exception = System.Exception;

namespace SoapClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //SweaService();
            MediaService();
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

        private static void MediaService()
        {
            MediaClient client = new MediaClient("WSHttpBinding_IMedia");

            try
            {
                #region ADD BOOKS
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

                #region ADD PAPER
                Paper pr3 = new Paper
                {
                    Id = 3,
                    Title = "Final Exam",
                    NbrOfPages = 31,
                    Category = "Essay",
                    Price = 2.32M
                };

                Paper pr4 = new Paper
                {
                    Id = 4,
                    Title = "Infinity War",
                    NbrOfPages = 107,
                    Category = "Manuscript",
                    Price = 59.20M
                };

                client.PostPaper(pr3);
                client.PostPaper(pr4);
                #endregion

                #region GET BOOKS
                var resultBooks = client.GetAllBooks();
                Console.WriteLine("\nAdded Books");
                foreach (var item in resultBooks) 
                {
                    Console.WriteLine(
                        $"" +
                        $"ID: {item.Id} - " +
                        $"TITLE: {item.Title} - " +
                        $"NUMBER OF PAGES: {item.NbrOfPages} - " +
                        $"TYPE: {item.Type} - " +
                        $"PRICE: {item.Price}");
                }
                #endregion

                #region GET PAPERS
                var resultPaper = client.GetAllPapers();
                Console.WriteLine("\nAdded Papers");
                foreach (var item in resultPaper)
                {
                    Console.WriteLine(
                        $"" +
                        $"ID: {item.Id} - " +
                        $"TITLE: {item.Title} - " +
                        $"NUMBER OF PAGES: {item.NbrOfPages} - " +
                        $"CATEGORY: {item.Category} - " +
                        $"PRICE: {item.Price}");
                }
                #endregion

                #region REMOVE BOOKS
                var removedBooks = client.RemoveBookFromLIbrary(1);
                Console.WriteLine("\nDeleted Books");
                Console.WriteLine(
                    $"ID: {removedBooks.Id} - " +
                    $"TITLE: {removedBooks.Title} - " +
                    $"NUMBER OF PAGES: {removedBooks.NbrOfPages} - " +
                    $"TYPE: {removedBooks.Type} - " +
                    $"PRICE: {removedBooks.Price}");
                #endregion

                #region REMOVE PAPERS
                var removedPapers = client.RemovePaperFromLIbrary(4);
                Console.WriteLine("\nDeleted Papers");
                Console.WriteLine(
                    $"ID: {removedPapers.Id} - " +
                    $"TITLE: {removedPapers.Title} - " +
                    $"NUMBER OF PAGES: {removedPapers.NbrOfPages} - " +
                    $"CATEGORY: {removedPapers.Category} - " +
                    $"PRICE: {removedPapers.Price}");
                #endregion

                #region GET REMAINING BOOKS
                var newResultBooks = client.GetAllBooks();
                Console.WriteLine("\nRemaining Books");
                foreach (var item in newResultBooks)
                {
                    Console.WriteLine(
                        $"" +
                        $"ID: {item.Id} - " +
                        $"TITLE: {item.Title} - " +
                        $"NUMBER OF PAGES: {item.NbrOfPages} - " +
                        $"TYPE: {item.Type} - " +
                        $"PRICE: {item.Price}");
                }
                #endregion

                #region GET REMAINING PAPERS
                var newResultPapers = client.GetAllPapers();
                Console.WriteLine("\nRemaining Papers");
                foreach (var item in newResultPapers)
                {
                    Console.WriteLine(
                        $"" +
                        $"ID: {item.Id} - " +
                        $"TITLE: {item.Title} - " +
                        $"NUMBER OF PAGES: {item.NbrOfPages} - " +
                        $"CATEGORY: {item.Category} - " +
                        $"PRICE: {item.Price}");
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
    }
}
