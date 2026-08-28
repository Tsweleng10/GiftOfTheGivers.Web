using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGivers.Web.Models
{
    public class VolunteerInterest
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Phone { get; set; } = string.Empty;

        public string? Skills { get; set; }

        public string? Availability { get; set; } // e.g., "Weekends, Evenings"

        public DateTime SubmittedAt { get; set; }
    }
}