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
        List<string> listOfBooks = new List<string> { "new", "good", "bad", "very_bad" };

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
            foreach(var book in books)
            {
                if (book.State != "very_bad" && listOfBooks.IndexOf(book.State) >= 0 && !IsbnInDB(book.Isbn))
                {
                    _dao.AddBook(book);
                }
            }
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
