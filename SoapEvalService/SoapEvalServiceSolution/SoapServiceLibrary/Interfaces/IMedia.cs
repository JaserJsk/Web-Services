using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SoapServiceLibrary.Models;

namespace SoapServiceLibrary.Interfaces
{
    [ServiceContract]
    public interface IMedia
    {
        #region BOOKS
        [OperationContract]
        List<Book> GetAllBooks();

        [OperationContract]
        void PostBooks(Book book);

        [OperationContract]
        Book RemoveBookFromLIbrary(int id);
        #endregion

        #region PAPER
        [OperationContract]
        List<Paper> GetAllPapers();

        [OperationContract]
        void PostPaper(Paper paper);

        [OperationContract]
        Paper RemovePaperFromLIbrary(int id);
        #endregion
    }
}
