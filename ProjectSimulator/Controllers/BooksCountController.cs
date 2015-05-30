using System.Web.Http;
using ProjectSimulator.Dao;
using ProjectSimulator.Models;
using System.Linq;

namespace ProjectSimulator.Controllers
{
    [RoutePrefix("api/library/bookscount")]
    public class BooksCountController : ApiController
    {
        readonly BookDao _dao = new BookDao();

        [Route("")]
        [HttpGet]
        public Count GetBooksCount()
        {
            //TODO: Sprint 3
            var count = _dao.GetBooksForDisplay().Count();
            return new Count() { BooksCount = count };
        }
    }
}
