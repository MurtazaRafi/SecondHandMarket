using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHandMarket.Services
{
    public interface ICategorySelectService
    {
        Task<IEnumerable<SelectListItem>> GetCategoriesAsync();

    }
}
