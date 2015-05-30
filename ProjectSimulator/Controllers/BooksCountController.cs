using System.Web.Http;
using ProjectSimulator.Dao;
using ProjectSimulator.Models;

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
            int counter = 0;
            foreach (var book in _dao.GetBooksForDisplay())
                counter++;
            return new Count() { BooksCount = counter };
        }
    }
}
