using Microsoft.AspNetCore.Identity;

namespace GiftOfTheGivers.Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
    }
}