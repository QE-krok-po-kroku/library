using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSimulator.Dao
{
    public class BookDetailsDto
    {
        public BookDetailsDto(string isbn, string title, string author, int year, string state)
        {
            Isbn = isbn;
            Title = title;
            Author = author;
            Year = year;
            State = state.ToLower();
        }

        public string Isbn { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int Year { get; private set; }
        public string State { get; private set; }
    }
}
