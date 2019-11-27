using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNet_Restaurant.Core;
using AspNet_Restaurant.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNet_Restaurant.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        readonly IRestaurantData _restaurantData;
        public DetailModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }
        public Restaurant Restaurant { get; set; }
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = _restaurantData.GetById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}