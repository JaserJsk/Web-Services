using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyLibraryApp.Models;

namespace MyLibraryApp.Controllers
{
    public class BooksController : ApiController
    {
        private Book[] book = new Book[]
        {
            new Book {ISBN = 851568, Title = "The Count of Monte Cristo", Author = "Alexandre Dumas ", Price = 9.99M},
            new Book {ISBN = 963257, Title = "Harry Potter", Author = "J. K. Rowling", Price = 6.25M},
            new Book {ISBN = 741528, Title = "The Lord of the Rings", Author = "J. R. R. Tolkien", Price = 12.57M},
            new Book {ISBN = 998752, Title = "The Hobbit", Author = "J. R. R. Tolkien", Price = 3.99M}
        };

        public IEnumerable<Book> GetAllBooks()
        {
            return book;
        }

        public IHttpActionResult GetBook(int isbn)
        {
            var books = book.FirstOrDefault(p => p.ISBN == isbn);
            if (books == null)
            {
                NotFound();
            }
            return Ok(books);

        }
    }
}
