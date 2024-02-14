using System.ComponentModel.DataAnnotations;

namespace BookWorm.Models
{
    public class BookEditViewModel
    {
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
