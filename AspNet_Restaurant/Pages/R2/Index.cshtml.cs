using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNet_Restaurant.Core;
using AspNet_Restaurant.Data;

namespace AspNet_Restaurant.R2
{
    public class IndexModel : PageModel
    {
        private readonly AspNet_Restaurant.Data.RestaurantDBContext _context;

        public IndexModel(AspNet_Restaurant.Data.RestaurantDBContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get;set; }

        public async Task OnGetAsync()
        {
            Restaurant = await _context.Restaurants.ToListAsync();
        }
    }
}
