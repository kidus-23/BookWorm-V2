using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWorm.Models
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }
        public int BookId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public CoverPage CoverImage { get; set; }
    }
}
