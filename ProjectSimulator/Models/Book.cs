using System.ComponentModel.DataAnnotations;

namespace ProjectSimulator.Models
{
    public class Book
    {
        [Key]
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string State { get; set; }
    }
}
