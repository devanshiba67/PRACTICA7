
using System.ComponentModel.DataAnnotations;

namespace FeedbackManagement.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Enter a valid email.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Select a category.")]
        public string Category { get; set; } = string.Empty;

        [Range(1, 5, ErrorMessage = "Select a rating from 1 to 5.")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Comments are required.")]
        [StringLength(500, MinimumLength = 5)]
        public string Comments { get; set; } = string.Empty;
    }
}
