using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AspNet_Restaurant.Core;
using AspNet_Restaurant.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantDataService restaurantDataService;
        public Restaurant Restaurant { get; set; }
        [TempData]
        public string Message { get; set; }

        public DetailModel(IRestaurantDataService restaurantData)
        {
            this.restaurantDataService = restaurantData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantDataService.GetById(restaurantId);
            if(Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}