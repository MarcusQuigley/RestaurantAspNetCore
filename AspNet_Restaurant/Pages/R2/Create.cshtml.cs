using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspNet_Restaurant.Core;
using AspNet_Restaurant.Data;

namespace AspNet_Restaurant.R2
{
    public class CreateModel : PageModel
    {
        private readonly RestaurantDBContext _context;
        readonly IHtmlHelper _htmlHelper;

        public CreateModel(RestaurantDBContext context, IHtmlHelper htmlHelper)
        {
            _context = context;
            _htmlHelper = htmlHelper;
        }

        public IEnumerable<SelectListItem> CuisineTypes { get; set; }

        public IActionResult OnGet()
        {
            CuisineTypes = _htmlHelper.GetEnumSelectList<CuisineType>();
            return Page();
        }

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Restaurants.Add(Restaurant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
