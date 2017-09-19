using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DesignDirect.Data;
using DesignDirect.Models;
using Microsoft.AspNetCore.Identity;
using DesignDirect.Models.IdeaboardViewModels;
using Microsoft.AspNetCore.Authorization;

namespace DesignDirect.Controllers
{
    public class IdeaboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public IdeaboardController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context; 
            _userManager = userManager;   
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Ideaboard
        public async Task<IActionResult> Index()
        {
            ViewIdeaboardsViewModel model = new ViewIdeaboardsViewModel();
            var user = await GetCurrentUserAsync();
            model.Ideaboards = await _context.Ideaboard.Where(i => i.User.Id == user.Id).ToListAsync();
            var userTags = await _context.ImageTag.Where(i => i.User.Id == user.Id).Select(t => t.TagId).ToListAsync();
            var allContractorTags = await _context.ContractorTag.ToListAsync();
            var contractorTags = (from t in allContractorTags
                                from u in userTags
                                where t.TagId == u
                                select t.ContractorId).ToList();
            var allContractors = await _context.Contractor.Include(i => i.User).Include(f => f.Services).ToListAsync();
            model.MatchingContractors = (from c in allContractors
                                    from t in contractorTags
                                    where c.ContractorId == t
                                    select c).ToList(); 
            return View(model);
        }

        // GET: Ideaboard/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ideaboard = await _context.Ideaboard
                .SingleOrDefaultAsync(m => m.IdeaboardId == id);
            if (ideaboard == null)
            {
                return NotFound();
            }
            var user = await GetCurrentUserAsync();
            var model = new IdeaboardDetailsViewModel(_context, user, ideaboard.IdeaboardId);
            model.Ideaboard = ideaboard;

            return View(model);
        }

        // GET: Ideaboard/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ideaboard/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ideaboard ideaboard)
        {
            ModelState.Remove("User");
            ideaboard.User = await GetCurrentUserAsync();
            if (ModelState.IsValid)
            {
                _context.Add(ideaboard);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ideaboard);
        }

        // GET: Ideaboard/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ideaboard = await _context.Ideaboard.SingleOrDefaultAsync(m => m.IdeaboardId == id);
            if (ideaboard == null)
            {
                return NotFound();
            }
            return View(ideaboard);
        }

        // POST: Ideaboard/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdeaboardId,Title")] Ideaboard ideaboard)
        {
            if (id != ideaboard.IdeaboardId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ideaboard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdeaboardExists(ideaboard.IdeaboardId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(ideaboard);
        }

        // GET: Ideaboard/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ideaboard = await _context.Ideaboard
                .SingleOrDefaultAsync(m => m.IdeaboardId == id);
            if (ideaboard == null)
            {
                return NotFound();
            }

            return View(ideaboard);
        }

        // POST: Ideaboard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ideaboard = await _context.Ideaboard.SingleOrDefaultAsync(m => m.IdeaboardId == id);
            _context.Ideaboard.Remove(ideaboard);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool IdeaboardExists(int id)
        {
            return _context.Ideaboard.Any(e => e.IdeaboardId == id);
        }
    }
}
