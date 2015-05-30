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
        public IEnumerable<Book> GetBooks()
        {
            //TODO: Sprint 2
            return new List<Book>();
        }

//TODO: Sprint 1
        [Route("")]
        [HttpPost]
       public HttpResponseMessage Post([FromBody] Book book)
        {
            _dao.AddBook(book);
            return Request.CreateResponse(HttpStatusCode.Created, _dao.GetBooks());
        }
    }
}
