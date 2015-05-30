﻿using System.Collections.Generic;
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

            return _dao.GetBooksForDisplay();
        }

        //TODO: Sprint 1
        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] List<Book> books)
        {
            var validBooks = books.Where(IsValid).ToList();
            foreach (var book in validBooks)
            {
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

        public bool IsbnInDB(string isbn)
        {
            foreach (var book in _dao.GetBooks())
            {
                if (book.Isbn == isbn)
                    return false;
            }
            return true;
        }
        private static bool IsValid(Book book)
        {
            return BookDao.ValidStatuses.Any(s => s == book.State.ToUpper());
        }
    }
}
