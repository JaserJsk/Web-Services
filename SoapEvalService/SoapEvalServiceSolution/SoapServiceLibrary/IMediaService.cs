using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SoapServiceLibrary
{
    [ServiceContract]
    public interface IMediaService
    {
        [OperationContract]
        List<Book> GetAllBooks();

        [OperationContract]
        void PostBooks(Book book);

        [OperationContract]
        Book RemoveBookFromLIbrary(int id);

        [OperationContract]
        List<Paper> GetAllPapers();

        [OperationContract]
        void PostPaper(Paper paper);

        [OperationContract]
        Paper RemovePaperFromLIbrary(int id);
    }
}
