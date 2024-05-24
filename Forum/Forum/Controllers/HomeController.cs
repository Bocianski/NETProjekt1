using Forum.Data;
using Forum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Forum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ForumContext _context;

        public HomeController(ILogger<HomeController> logger, ForumContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
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

        public IActionResult SavedInSession()
        {
            var Data = HttpContext.Session.GetString("Data"); 
            if (Data != null) 
                ViewBag.Hero = JsonConvert.DeserializeObject<ForumUser>(Data); 
            return View();
        }

        public IActionResult Create(ForumUser hero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hero);
                _context.SaveChanges();
                HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(hero));
                return RedirectToAction(nameof(SavedInSession));
            }
            // ViewBag.TeamId = new SelectList(_context.Team, "Id", "Name", hero.TeamId);
            return View(hero);
        }
    }
}
