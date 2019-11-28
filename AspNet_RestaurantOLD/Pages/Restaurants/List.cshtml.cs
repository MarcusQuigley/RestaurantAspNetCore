using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNet_Restaurant.Core;
using AspNet_Restaurant.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AspNet_Restaurant.Pages
{
    public class ListModel : PageModel
    {
        readonly IConfiguration _configuration;
        readonly IRestaurantData _restaurantData;
        readonly ILogger _logger;
        public ListModel(IConfiguration configuration,
           IRestaurantData restaurantData,
           ILogger<ListModel> logger)
        {
            _configuration = configuration;
            _restaurantData = restaurantData;
            _logger = logger;
         }

        [BindProperty(SupportsGet=true)]
        public string SearchTerm { get; set; }

        public IEnumerable<Restaurant> Restaurants { get; set; }
        
        public void OnGet()
        {
            _logger.LogDebug("Executing ListModel");
            Restaurants = _restaurantData.GetRestaurantByName(SearchTerm);
        }
    }
}
