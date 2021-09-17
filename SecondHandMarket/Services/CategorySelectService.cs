using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SecondHandMarket.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHandMarket.Services
{
    public class CategorySelectService : ICategorySelectService
    {
        private readonly ApplicationDbContext db;

        public CategorySelectService(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<IEnumerable<SelectListItem>> GetCategoriesAsync()
        {
            var selectListGroups= await db.MainCategories
                       .Select(mc => new SelectListGroup
                       {
                            Name = mc.Name
                       })
                       .ToListAsync();

            var selectListItems = new List<SelectListItem>();

            selectListItems.Add(new SelectListItem { Text = "Välj kategori", Selected = true, Disabled = true , Value = "0" });

            foreach (var c in db.Categories)
            {
                selectListItems.Add(new SelectListItem { Text = c.Name, Value = c.Id.ToString(), Group = selectListGroups[c.MainCategoryId-1]});
            }
            return selectListItems;

        }
    }
}
