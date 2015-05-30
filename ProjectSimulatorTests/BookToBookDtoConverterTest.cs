using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ProjectSimulator.Models;
using ProjectSimulator.Utils;

namespace ProjectSimulatorTests
{
    [TestFixture]
    public class BookToBookDtoConverterTest
    {
        [Test]
        public void ShouldReturnEmptyListWhenEmptyListPassed()
        {
            IList<Book> books = new List<Book>();

            IList<BookDto> dtos = BookToBookDto.Convert(books);

            Assert.That(dtos, Is.Empty);
        }

        [Test]
        public void ShouldConvertBookIntoBookDto()
        {
            IList<Book> books = new List<Book>();
            books.Add(TestDataProvider.CleanCode());

            IList<BookDto> dtos = BookToBookDto.Convert(books);

            Assert.That(dtos.Count, Is.EqualTo(1));
            BookDto dto = dtos.First();
            Assert.That(dto.Isbn, Is.EqualTo("978-0132350884"));
            Assert.That(dto.State, Is.EqualTo("good"));
        }
    }
}
