using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNet_Restaurant.Core;
using AspNet_Restaurant.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNet_Restaurant.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        readonly IRestaurantDataService _service;
        readonly IHtmlHelper _htmlHelper;
        public EditModel(IRestaurantDataService service,
            IHtmlHelper htmlHelper)
        {
            _service = service;
            _htmlHelper = htmlHelper;
        }

        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }
        
        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
            if (restaurantId.HasValue)
            {
                Restaurant = _service.GetById(restaurantId.Value);
            }
            else
            {
                Restaurant = new Restaurant();
            }
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }

            if (Restaurant.Id == 0)
            {
                _service.Add(Restaurant);
            }
            else
            {
                Restaurant = _service.Update(Restaurant);
            }
            _service.Commit();
            TempData["Message"] = "Restaurant saved";
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
        }
    }
}