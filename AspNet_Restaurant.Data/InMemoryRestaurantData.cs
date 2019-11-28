﻿using System;
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
        public IEnumerable<Restaurant> GetRestaurantByName(string name = null)
        {
            return _restaurants
                    .Where(r => string.IsNullOrEmpty(name) || r.Name.ToLower().StartsWith(name.ToLower()))
                    .OrderBy(r => r.Name);
        }

        public Restaurant GetById(int id)
        {
            return _restaurants
                    .SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = _restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }
    }
}
