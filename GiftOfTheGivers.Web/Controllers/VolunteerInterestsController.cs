using GiftOfTheGivers.Web.Data;
using GiftOfTheGivers.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace GiftOfTheGivers.Web.Controllers
{
    public class VolunteerInterestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VolunteerInterestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VolunteerInterest model)
        {
            if (ModelState.IsValid)
            {
                model.SubmittedAt = DateTime.UtcNow;
                _context.VolunteerInterests.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("ThankYou");
            }
            return View(model);
        }

        public IActionResult ThankYou()
        {
            return View();
        }
    }
}