using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AspNet_Restaurant.Core;

namespace AspNet_Restaurant.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
       readonly List<Restaurant> _restaurants;
        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>()
            {
                new Restaurant{Id=1,Name="Scotts Pizza", Cuisine=CuisineType.Italian, Location="Brooklyn"},
                new Restaurant{Id=2,Name="El Lobo", Cuisine=CuisineType.Mexican, Location="Astoria"},
                new Restaurant{Id=3,Name="Kaap", Cuisine=CuisineType.Thai, Location="Brooklyn"}
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(r=>r.Name);
        }
    }
}
