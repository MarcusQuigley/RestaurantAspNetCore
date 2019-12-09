using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AspNet_Restaurant.Core;
using Microsoft.EntityFrameworkCore;

namespace AspNet_Restaurant.Data
{
    public class SqlRestaurantData : IRestaurantDataService
    {
        readonly RestaurantDBContext db;

        public SqlRestaurantData(RestaurantDBContext db)
        {
            this.db = db;
        }

        public int CountOfRestaurants => db.Restaurants.Count();

        public Restaurant Add(Restaurant newRestaurant)
        {
            db.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            if (restaurant != null)
            {
                db.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public Restaurant GetById(int id)
        {
            return db.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return db.Restaurants.Where(r =>string.IsNullOrEmpty(name) || r.Name.StartsWith(name) )
                                 .OrderBy(r=>r.Name);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = db.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
