﻿using System.Collections.Generic;
using ProjectSimulator.Models;

namespace ProjectSimulator.Dao
{
    class BookDao
    {
        readonly ApplicationDbContext _db = new ApplicationDbContext();

        public IEnumerable<Book> GetBooks()
        {
            return _db.Books;
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