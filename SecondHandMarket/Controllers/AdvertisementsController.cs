using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SecondHandMarket.Data;
using SecondHandMarket.Models;

namespace SecondHandMarket.Controllers
{
    public class AdvertisementsController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public AdvertisementsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            db = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        // GET: Advertisements
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = db.Advertisements.Include(a => a.ApplicationUser).Include(a => a.Category).Include(a => a.Location);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Advertisements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisement = await db.Advertisements
                .Include(a => a.ApplicationUser)
                .Include(a => a.Category)
                .Include(a => a.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (advertisement == null)
            {
                return NotFound();
            }

            return View(advertisement);
        }

        // GET: Advertisements/Create
        [Authorize]
        public IActionResult Create()
        {
            //ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Name");
            ViewData["LocationId"] = new SelectList(db.Locations, "Id", "Name");
            return View();
        }

        // POST: Advertisements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Price,CategoryId,LocationId")] Advertisement advertisement)
        {
            if (ModelState.IsValid)
            {
                advertisement.ApplicationUserId = userManager.GetUserId(User);
                advertisement.PublishDate = DateTime.Now;
                db.Add(advertisement);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(db.ApplicationUsers, "Id", "Id", advertisement.ApplicationUserId);
            
            //ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Name", advertisement.CategoryId);
            ViewData["LocationId"] = new SelectList(db.Locations, "Id", "Name", advertisement.LocationId);
            return View(advertisement);
        }

        // GET: Advertisements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisement = await db.Advertisements.FindAsync(id);
            if (advertisement == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(db.ApplicationUsers, "Id", "Id", advertisement.ApplicationUserId);
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Id", advertisement.CategoryId);
            ViewData["LocationId"] = new SelectList(db.Locations, "Id", "Id", advertisement.LocationId);
            return View(advertisement);
        }

        // POST: Advertisements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Price,PublishDate,CategoryId,LocationId,ApplicationUserId")] Advertisement advertisement)
        {
            if (id != advertisement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(advertisement);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdvertisementExists(advertisement.Id))
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
            ViewData["ApplicationUserId"] = new SelectList(db.ApplicationUsers, "Id", "Id", advertisement.ApplicationUserId);
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Id", advertisement.CategoryId);
            ViewData["LocationId"] = new SelectList(db.Locations, "Id", "Id", advertisement.LocationId);
            return View(advertisement);
        }

        // GET: Advertisements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisement = await db.Advertisements
                .Include(a => a.ApplicationUser)
                .Include(a => a.Category)
                .Include(a => a.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (advertisement == null)
            {
                return NotFound();
            }

            return View(advertisement);
        }

        // POST: Advertisements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var advertisement = await db.Advertisements.FindAsync(id);
            db.Advertisements.Remove(advertisement);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdvertisementExists(int id)
        {
            return db.Advertisements.Any(e => e.Id == id);
        }
    }
}
