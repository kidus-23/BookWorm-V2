using System.ComponentModel.DataAnnotations;

namespace BookWorm.Models
{
    public class CoverPage
    {
        [Key]
        public Guid Id { get; set; }
        public string url { get; set; }
    }
}
