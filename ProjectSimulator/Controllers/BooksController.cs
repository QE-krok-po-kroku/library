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

        [Route("")]
        [HttpGet]
        public IEnumerable<BookDetailsDto> GetBooks()
        {
            //TODO: Sprint 2

            return _dao.GetBooksForDisplay().Select(b => new BookDetailsDto(b.Isbn, b.Title, b.Author, b.Year, b.State));
        }

        //TODO: Sprint 1
        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] List<Book> books)
        {
            var validBooks = books.Where(IsValid).ToList();
            foreach (var book in validBooks)
            {
                book.State = book.State.ToUpper();
                _dao.AddBook(book);
            }
            if (validBooks.Count() == 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Nic sie nie dodalo");
            var count = _dao.GetBooksForDisplay().Count();
            return Request.CreateResponse(HttpStatusCode.Created, new Count
            {
                BooksCount =  count
            });
        }

        private bool IsValid(Book book)
        {
            return BookDao.ValidStatuses.Any(s => s == book.State.ToUpper())
                && !_dao.BookExists(book);
        }
    }
}
