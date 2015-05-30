﻿using System.Collections.Generic;
using ProjectSimulator.Models;

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

        public IEnumerable<Book> GetBooksNotVeryBad()
        {
            List<Book> arr = new List<Book>();

            foreach (var book in this.GetBooks())
            {
                if (book.State != "VERY_BAD")
                    arr.Add(book);
            }

            return arr;
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
    }
}
