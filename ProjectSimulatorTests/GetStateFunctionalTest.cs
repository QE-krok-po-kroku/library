using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.Owin.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using ProjectSimulator;
using ProjectSimulator.Models;

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
            var dtos = JsonConvert.DeserializeObject<List<BookDto>>(result);

            Assert.That(dtos.Count, Is.EqualTo(1));
            BookDto dto = dtos.First();
            Assert.That(dto.State, Is.EqualTo("good"));
            Assert.That(dto.Isbn, Is.EqualTo("978-0132350884"));
        }
    }
}
