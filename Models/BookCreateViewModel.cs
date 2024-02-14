using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWorm.Models
{
    public class BookCreateViewModel
    {
        [Display(Name = "Id")]
        public int BookId { get; set; }
        [Required(ErrorMessage = "Title is Mandatory.")]
        [Display(Name = "Title")]
        public string? Title { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string? Description { get; set; }
        [Required]
        [Display(Name = "Price")]
        public double Price { get; set; }
        [Required]
        [Display(Name = "Cover Image")]
        public IFormFile? CoverImage { get; set; }
    }
}
