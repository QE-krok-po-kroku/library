using System.Collections.Generic;
using ProjectSimulator.Models;
using System.Linq;

namespace ProjectSimulator.Dao
{
    class BookDao
    {
        public static IList<string> ValidStatuses = new List<string>() { "NEW", "GOOD", "BAD" };

        readonly ApplicationDbContext _db = new ApplicationDbContext();

        public IEnumerable<Book> GetBooks()
        {
            return _db.Books;
        }

        public IEnumerable<Book> GetBooksForDisplay()
        {
            return GetBooks().Where(CanShow);
        }

        public void AddBook(Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
        }

        public void ResetDatabase()
        {
            _db.Database.Initialize(true);
        }

        private bool CanShow(Book book)
        {
            return ValidStatuses.Any(s => s == book.State.ToUpper());
        }
    }
}
