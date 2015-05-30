using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ProjectSimulator.Dao;
using ProjectSimulator.Models;
using ProjectSimulator.Utils;

namespace ProjectSimulator.Controllers
{
    [RoutePrefix("api/library/books_state")]
    public class BooksStateController : ApiController
    {
        readonly BookDao _dao = new BookDao();

        [Route("")]
        [HttpGet]
        public IEnumerable<BookDto> GetBooksState()
        {
            return BookToBookDto.Convert(_dao.GetBooks().ToList());
        }
    }
}
