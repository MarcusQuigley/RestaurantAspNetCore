using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNet_Restaurant.Core;
using AspNet_Restaurant.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace AspNet_Restaurant.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        readonly IRestaurantData _restaurantData;
        readonly IHtmlHelper _htmlHelper;
        readonly ILogger _logger;
        public EditModel(IRestaurantData restaurantData,
                         IHtmlHelper htmlHelper,
                         ILogger<EditModel> logger)
        {
            _restaurantData = restaurantData;
            _htmlHelper = htmlHelper;
            _logger = logger;
        }
        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public IActionResult OnGet(int restaurantId)
        {
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
            Restaurant = _restaurantData.GetById(restaurantId);
            if (Restaurant == null)
            {
                RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Restaurant = _restaurantData.Update(Restaurant);
                _restaurantData.Commit();
            }
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
            return Page();
        }
    }
}