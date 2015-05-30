using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectSimulator.Models;

namespace ProjectSimulatorTests
{
    public class TestDataProvider
    {
        public static Book CleanCode(string state = "good")
        {
            return new Book
            {
                Isbn = "978-0132350884",
                Title = "Clean Code: A Handbook of Agile Software Craftsmanship",
                Author = "Robert C. Martin",
                Year = 2008,
                State = state
            };
        }
    }
}
