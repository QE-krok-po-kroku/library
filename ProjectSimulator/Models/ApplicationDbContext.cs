using System.Data.Entity;

namespace ProjectSimulator.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("MyDatabase") {}

        public IDbSet<Book> Books { get; set; }
    }

    public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            base.Seed(context);

            Book[] books = new Book[]
            {
                new Book
                {
                    Isbn = "978-0201485677",
                    Title = "Refactoring: Improving the Design of Existing Code",
                    Author = "Martin Fowler",
                    Year = 1999,
                    State = "BAD"
                },
                new Book
                {
                    Isbn = "978-0596007126",
                    Title = "Head First Design Patterns",
                    Author = "Eric Freeman",
                    Year = 2004,
                    State = "VERY_BAD"
                }
            };

            foreach (Book book in books)
            {
                context.Books.Add(book);
            }
        }
    }
}
