using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.Owin.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using ProjectSimulator;
using ProjectSimulator.Models;
using System.Net.Http;
using ProjectSimulator.Dao;

namespace ProjectSimulatorTests
{
    [TestFixture]
    public class GetStateFunctionalTest
    {
        private TestServer server;

        [TestFixtureSetUp]
        public void FixtureInit()
        {
            Database.SetInitializer(new TestApplicationDbInitializer());
            TestApplicationDbContext db = new TestApplicationDbContext();
            db.Database.Initialize(true);
            db.Books.Add(TestDataProvider.CleanCode());
            db.SaveChanges();
            server = TestServer.Create<Startup>();
        }

        [TestFixtureTearDown]
        public void FixtureDispose()
        {
            server.Dispose();
        }

        [Test]
        public void WebApiGetAllTest()
        {
            var response = server.HttpClient.GetAsync("api/library/books_state").Result;

            var result = response.Content.ReadAsStringAsync().Result;
            var dtos = JsonConvert.DeserializeObject<List<BookDetailsDto>>(result);

            Assert.That(dtos.Count, Is.EqualTo(1));
            BookDetailsDto dto = dtos.First();
            Assert.That(dto.State, Is.EqualTo("good"));
            Assert.That(dto.Isbn, Is.EqualTo("978-0132350884"));
        }


        [Test]
        public void WebApiPostBookTest()
        {
            var book1 = new Book
            {
                Author = "Author",
                Isbn = "2432342623462",
                State = "GOOD",
                Title = "Title",
                Year = 2022
            };

            var book2 = new Book
            {
                Author = "Author 2",
                Isbn = "2432342623462",
                State = "VERY BAD",
                Title = "Title 2",
                Year = 2022
            };

            var book3 = new Book
            {
                Author = "Author 2",
                Isbn = "2432342623462",
                State = "VERY BAD",
                Title = "Title 2",
                Year = 2022
            };
            var books = new List<Book>() { book1, book2, book3 };

            var content = new StringContent(JsonConvert.SerializeObject(books));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = server.HttpClient.PostAsync("api/library/books", content).Result;

            var result = response.Content.ReadAsStringAsync().Result;
            var dtos = JsonConvert.DeserializeObject<Count>(result);

            Assert.That(dtos.BooksCount, Is.EqualTo(2));
        }

        [Test]
        public void WebApiGetBooksCountTest()
        {
            var response = server.HttpClient.GetAsync("api/library/bookscount").Result;

            var result = response.Content.ReadAsStringAsync().Result;
            var dtos = JsonConvert.DeserializeObject<Count>(result);

            Assert.That(dtos.BooksCount, Is.EqualTo(1));
        }
    }
}
