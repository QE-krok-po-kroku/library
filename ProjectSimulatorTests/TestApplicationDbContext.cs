using System.Data.Entity;
using ProjectSimulator.Models;

namespace ProjectSimulatorTests
{
    public class TestApplicationDbContext : DbContext
    {
        public TestApplicationDbContext() : base("MyDatabase")
        {
        }

        public IDbSet<Book> Books { get; set; }
    }

    public class TestApplicationDbInitializer : DropCreateDatabaseAlways<TestApplicationDbContext>
    {
    }
}
