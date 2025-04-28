using DreamsAI.Data;
using DreamsAI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DreamsAI.Controllers
{
    [Authorize] // Ensures only logged-in users can access the home page
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);

            // Retrieve the last 7 sleep sessions for quick overview
            var recentSessions = await _context.SleepSessions
                .Where(s => s.UserId == userId)
                .OrderByDescending(s => s.BedTime)
                .Take(7)
                .ToListAsync();

            // Calculate average sleep duration over last 7 days
            var avgSleepDuration = recentSessions.Any()
                ? recentSessions.Average(s => s.Duration)
                : 0;

            ViewData["AvgSleepDuration"] = avgSleepDuration;

            return View(recentSessions);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
