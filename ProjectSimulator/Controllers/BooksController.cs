using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using ProjectSimulator.Models;
using ProjectSimulator.Dao;

namespace ProjectSimulator.Controllers
{
    [RoutePrefix("api/library/books")]
    public class BooksController : ApiController
    {
        readonly BookDao _dao = new BookDao();
        List<string> listOfBooks = new List<string> { "NEW", "GOOD", "BAD", "VERY_BAD" };

        [Route("")]
        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            //TODO: Sprint 2

            return _dao.GetBooksNotVeryBad();
        }

//TODO: Sprint 1
        [Route("")]
        [HttpPost]
       public HttpResponseMessage Post([FromBody] IEnumerable<Book> books)
        {
            var counter = 0;
            foreach(var book in books)
            {
                if (book.State != "VERY_BAD" && listOfBooks.IndexOf(book.State) >= 0 && IsbnInDB(book.Isbn))
                {
                    counter++;
                    _dao.AddBook(book);
                }
            }
            if (counter == 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Nic sie nie dodalo");
            return Request.CreateResponse(HttpStatusCode.Created, _dao.GetBooks().Count());
        }

        public bool IsbnInDB(string isbn)
        {
            foreach (var book in _dao.GetBooks())
            {
                if (book.Isbn == isbn)
                    return false;
            }
            return true;
        }

    }
}
