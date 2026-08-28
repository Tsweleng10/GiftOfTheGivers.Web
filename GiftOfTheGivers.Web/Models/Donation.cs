using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGivers.Web.Models
{
    public class Donation
    {
        public int Id { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }

        [Required]
        public string Currency { get; set; } = "ZAR";   // default ZAR

        public bool IsRecurring { get; set; }

        public string? RecurrenceFrequency { get; set; } // e.g., "Monthly"

        public int? ProjectId { get; set; }              // optional link to ReliefProject

        public string? DonorUserId { get; set; }         // null if anonymous

        public DateTime DonationDate { get; set; }

        public bool IsAnonymous { get; set; }

        // Navigation properties
        public virtual ApplicationUser? Donor { get; set; }
        public virtual ReliefProject? Project { get; set; }
    }
}