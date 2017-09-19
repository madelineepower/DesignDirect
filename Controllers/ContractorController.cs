using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DesignDirect.Data;
using DesignDirect.Models;
using DesignDirect.Models.ContractorViewModels;
using Microsoft.AspNetCore.Identity;

namespace DesignDirect.Controllers
{
    public class ContractorController : Controller
    {
        private readonly ApplicationDbContext _context;

         private readonly UserManager<ApplicationUser> _userManager;
        public ContractorController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context; 
            _userManager = userManager;   
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Contractor
        public async Task<IActionResult> Index()
        {
            var contractors = await _context.Contractor.Include(i => i.User).Include(f => f.Services).ToListAsync();
            var model = new FindContractorsViewModel(_context);
            model.CurrentUser = await GetCurrentUserAsync();
            model.Contractors = contractors;
            return View(model);
        }

        public async Task<IActionResult> Filter(FindContractorsViewModel model)
        {
            List<int> serviceIds = model.FilterServiceIds;
            if (serviceIds == null)
            {
                return RedirectToAction("Index");
            }
            var allContractors = await _context.Contractor.Include(i => i.User).Include(f => f.Services).ToListAsync();
            var allContractorServices = await _context.ContractorService.ToListAsync();
            var contractorServices = (from c in allContractorServices
                                      from s in serviceIds
                                      where c.ServiceId == s
                                      select c).ToList();
            var filteredContractors = (from c in allContractors
                                      from s in contractorServices
                                      where c.ContractorId == s.ContractorId
                                      select c).ToList();
            FindContractorsViewModel newModel = new FindContractorsViewModel(_context);
            newModel.Contractors = filteredContractors;

            return View(newModel);
        }
        // GET: Contractor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractor = await _context.Contractor
                .SingleOrDefaultAsync(m => m.ContractorId == id);
            if (contractor == null)
            {
                return NotFound();
            }

            return View(contractor);
        }

        // GET: Contractor/Create
        public async Task<IActionResult> Create()
        {
            CreateContractorViewModel model = new CreateContractorViewModel(_context);
            var user = await GetCurrentUserAsync();
            model.User = user;
            return View(model);
        }

        // POST: Contractor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateContractorViewModel model)
        {
            ModelState.Remove("Contractor.User");
            
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                model.Contractor.User = user;
                _context.Add(model.Contractor);
                await _context.SaveChangesAsync();

                if (model.SelectedTags.Count > 0)
                    {
                        foreach (int tagId in model.SelectedTags)
                        {
                            ContractorTag contractorTags = new ContractorTag(){
                                TagId = tagId,
                                ContractorId = model.Contractor.ContractorId 
                            };
                            await _context.AddAsync(contractorTags);
                        }
                    }
                await _context.SaveChangesAsync();
                if (model.SelectedServices.Count > 0)
                    {
                        foreach (int serviceId in model.SelectedServices)
                        {
                            ContractorService contractorServices = new ContractorService(){
                                ServiceId = serviceId,
                                ContractorId = model.Contractor.ContractorId 
                            };
                            await _context.AddAsync(contractorServices);
                        }
                    }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Contractor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractor = await _context.Contractor.SingleOrDefaultAsync(m => m.ContractorId == id);
            if (contractor == null)
            {
                return NotFound();
            }
            return View(contractor);
        }

        // POST: Contractor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContractorId,City,State,PhoneNumber,Website")] Contractor contractor)
        {
            if (id != contractor.ContractorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contractor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractorExists(contractor.ContractorId))
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
            return View(contractor);
        }

        // GET: Contractor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractor = await _context.Contractor
                .SingleOrDefaultAsync(m => m.ContractorId == id);
            if (contractor == null)
            {
                return NotFound();
            }

            return View(contractor);
        }

        // POST: Contractor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contractor = await _context.Contractor.SingleOrDefaultAsync(m => m.ContractorId == id);
            _context.Contractor.Remove(contractor);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ContractorExists(int id)
        {
            return _context.Contractor.Any(e => e.ContractorId == id);
        }
    }
}
