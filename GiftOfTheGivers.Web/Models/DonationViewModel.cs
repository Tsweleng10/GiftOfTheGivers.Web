using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGivers.Web.Models
{
    public class DonationViewModel
    {
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        public string Currency { get; set; } = "ZAR";

        public bool IsRecurring { get; set; }

        public string? RecurrenceFrequency { get; set; } // Monthly, Weekly

        public int? ProjectId { get; set; }

        public bool IsAnonymous { get; set; }

        // For dropdowns
        public List<string> Currencies { get; set; } = new List<string> { "ZAR", "USD", "EUR" };
        public List<ReliefProject> Projects { get; set; } = new List<ReliefProject>();
    }
}