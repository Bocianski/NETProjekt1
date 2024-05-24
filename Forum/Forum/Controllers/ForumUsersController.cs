using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Forum.Data;
using Forum.Models;

namespace Forum.Controllers
{
    public class ForumUsersController : Controller
    {
        private readonly ForumContext _context;

        public ForumUsersController(ForumContext context)
        {
            _context = context;
        }

        // GET: ForumUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.ForumUser.ToListAsync());
        }

        // GET: ForumUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forumUser = await _context.ForumUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (forumUser == null)
            {
                return NotFound();
            }

            return View(forumUser);
        }

        // GET: ForumUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ForumUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email")] ForumUser forumUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(forumUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(forumUser);
        }

        // GET: ForumUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forumUser = await _context.ForumUser.FindAsync(id);
            if (forumUser == null)
            {
                return NotFound();
            }
            return View(forumUser);
        }

        // POST: ForumUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email")] ForumUser forumUser)
        {
            if (id != forumUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(forumUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ForumUserExists(forumUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(forumUser);
        }

        // GET: ForumUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forumUser = await _context.ForumUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (forumUser == null)
            {
                return NotFound();
            }

            return View(forumUser);
        }

        // POST: ForumUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var forumUser = await _context.ForumUser.FindAsync(id);
            if (forumUser != null)
            {
                _context.ForumUser.Remove(forumUser);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ForumUserExists(int id)
        {
            return _context.ForumUser.Any(e => e.Id == id);
        }
    }
}
