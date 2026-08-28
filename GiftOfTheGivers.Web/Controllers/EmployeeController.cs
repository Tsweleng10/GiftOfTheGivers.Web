using GiftOfTheGivers.Web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GiftOfTheGivers.Web.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Dashboard()
        {
            // Get recent volunteer sign-ups
            var volunteers = await _context.VolunteerInterests
                .OrderByDescending(v => v.SubmittedAt)
                .Take(20)
                .ToListAsync();

            // Get recent donations
            var recentDonations = await _context.Donations
                .Include(d => d.Donor)
                .OrderByDescending(d => d.DonationDate)
                .Take(10)
                .ToListAsync();

            ViewBag.RecentDonations = recentDonations;
            return View(volunteers);
        }

        [HttpPost]
        public IActionResult PostUpdate(string title, string description)
        {
            // For prototype, just store a temporary message
            TempData["UpdateMessage"] = $"✅ Update posted: {title}";
            return RedirectToAction("Dashboard");
        }
    }
}