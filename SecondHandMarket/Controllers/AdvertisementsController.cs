using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
        private readonly IWebHostEnvironment environment;
        public AdvertisementsController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IWebHostEnvironment environment)
        {
            db = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.environment = environment;
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
            //TODO längre fram User har Location som förvald       
            //var userId = userManager.GetUserAsync(User).Result.Id;
            //var userLocation = db.ApplicationUsers.Where(u=>u.Id==userId).Select(u=>u.Location)
           
            ViewData["LocationId"] = new SelectList(db.Locations, "Id", "Name");
            return View();
        }

        // POST: Advertisements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Advertisement advertisement = new Advertisement
                {
                    ApplicationUserId = userManager.GetUserId(User),
                    CategoryId = model.Advertisement.CategoryId,
                    LocationId = model.Advertisement.LocationId,
                    SubLocationId = model.Advertisement.SubLocationId,
                    Title = model.Advertisement.Title,
                    Description = model.Advertisement.Description,
                    PublishDate = DateTime.Now,
                    Price = model.Advertisement.Price
                    
                };

                db.Add(advertisement);

                //TODO bryt ut egen metod
                if (model.File != null)
                {
                    string categoryName = db.Categories.First(c => c.Id == advertisement.CategoryId).Name;
                    string path = Path.Combine(environment.WebRootPath, $"uploads/{categoryName}");

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    string fileName = Convert.ToString(Guid.NewGuid());
                    using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                    {
                        model.File.CopyTo(stream);
                        stream.Flush();
                    }

                    Picture picture = new Picture
                    {
                        Path = $"/uploads/{categoryName}/{fileName}",
                        Advertisement = advertisement
                    };


                    db.Add(picture);
                }
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["LocationId"] = new SelectList(db.Locations, "Id", "Name");
            return View(model);
        }
        public IActionResult GetSubLocations(int lId)
        {
            var subLocations = db.Locations.Include(l=> l.SubLocations).FirstOrDefault(l=>l.Id==lId)
                                .SubLocations.ToList();
            return Json(subLocations);
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
