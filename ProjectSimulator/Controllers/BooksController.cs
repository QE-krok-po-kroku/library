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
        List<string> listOfBooks = new List<string> { "new", "good", "bad", "very_bad" };

        [Route("")]
        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            //TODO: Sprint 2

            return _dao.GetBooks();
        }

//TODO: Sprint 1
        [Route("")]
        [HttpPost]
       public HttpResponseMessage Post([FromBody] IEnumerable<Book> books)
        {
            foreach(var book in books)
            {
                if (book.State != "very_bad" && listOfBooks.IndexOf(book.State) >= 0)
                {
                    _dao.AddBook(book);
                }
            }
            return Request.CreateResponse(HttpStatusCode.Created, _dao.GetBooks().Count());
        }
    }
}
