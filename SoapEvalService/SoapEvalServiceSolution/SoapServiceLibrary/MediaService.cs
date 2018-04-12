using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SoapServiceLibrary
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MediaService : IMediaService
    {
        List<Book> Books = new List<Book>();
        List<Paper> Papers = new List<Paper>();

        #region BOOKS
        public List<Book> GetAllBooks()
        {
            return Books;
        }

        public void PostBooks(Book book)
        {
            Books.Add(book);
        }

        public Book RemoveBookFromLIbrary(int id)
        {
            var rb = Books.FirstOrDefault(x => x.Id == id);

            Books.Remove(rb);
            return rb;
        }
        #endregion

        #region PAPER
        public List<Paper> GetAllPapers()
        {
            return Papers;
        }

        public void PostPaper(Paper paper)
        {
            Papers.Add(paper);
        }

        public Paper RemovePaperFromLIbrary(int id)
        {
            var rp = Papers.FirstOrDefault(x => x.Id == id);

            Papers.Remove(rp);
            return rp;
        }
        #endregion
    }
}
