using GiftOfTheGivers.Web.Data;
using GiftOfTheGivers.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GiftOfTheGivers.Web.Controllers
{
    public class DonationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DonationsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new DonationViewModel
            {
                Currencies = new List<string> { "ZAR", "USD", "EUR" },
                Projects = await _context.ReliefProjects.ToListAsync()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DonationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var donation = new Donation
                {
                    Amount = model.Amount,
                    Currency = model.Currency,
                    IsRecurring = model.IsRecurring,
                    RecurrenceFrequency = model.IsRecurring ? model.RecurrenceFrequency : null,
                    ProjectId = model.ProjectId,
                    DonationDate = DateTime.UtcNow,
                    IsAnonymous = model.IsAnonymous
                };

                // If user is logged in and not anonymous, associate with user
                if (User.Identity?.IsAuthenticated == true && !model.IsAnonymous)
                {
                    var user = await _userManager.GetUserAsync(User);
                    donation.DonorUserId = user?.Id;
                }

                _context.Donations.Add(donation);
                await _context.SaveChangesAsync();

                return RedirectToAction("Certificate", new { id = donation.Id });
            }

            // Repopulate dropdowns if invalid
            model.Currencies = new List<string> { "ZAR", "USD", "EUR" };
            model.Projects = await _context.ReliefProjects.ToListAsync();
            return View(model);
        }

        public async Task<IActionResult> Certificate(int id)
        {
            var donation = await _context.Donations
                .Include(d => d.Donor)
                .Include(d => d.Project)
                .FirstOrDefaultAsync(d => d.Id == id);
            if (donation == null) return NotFound();
            return View(donation);
        }
    }
}