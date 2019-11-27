using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNet_Restaurant.Core;
using AspNet_Restaurant.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace AspNet_Restaurant.Pages
{
    public class ListModel : PageModel
    {
        readonly IConfiguration _configuration;
        readonly IRestaurantData _restaurantData;

        public ListModel(IConfiguration configuration,
           IRestaurantData restaurantData)
        {
            _configuration = configuration;
            _restaurantData = restaurantData;
        }
        public string MyProperty { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        public void OnGet()
        {
            Restaurants = _restaurantData.GetAll();
        }
    }
}
