using AspNet_Restaurant.Core;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AspNet_Restaurant.Data
{
    public interface IRestaurantDataService
    {
        IEnumerable<Restaurant> GetRestaurantByName(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Add(Restaurant newRestaurant);
        int Commit();

    }
}
