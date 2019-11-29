using AspNet_Restaurant.Core;
using AspNet_Restaurant.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantDataService restaurantDataService;

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config,
                         IRestaurantDataService restaurantData)
        {
            this.config = config;
            this.restaurantDataService = restaurantData;
        }

        public void OnGet()
        {
            Message = config["Message"];
            Restaurants = restaurantDataService.GetRestaurantByName(SearchTerm);
        }
    }
}