using System.Collections.Generic;
using ProjectSimulator.Models;

namespace ProjectSimulator.Utils
{
    public class BookToBookDto
    {
        public static IList<BookDto> Convert(IList<Book> books)
        {
            IList<BookDto> result  = new List<BookDto>();
            foreach (var book in books)
            {
                result.Add(new BookDto
                {
                    Isbn = book.Isbn,
                    State = book.State
                });
            }
            return result;
        }
    }
}
