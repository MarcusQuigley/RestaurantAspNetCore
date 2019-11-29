using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNet_Restaurant.Data
{
  public  class RestaurantDBContext : DbContext
    {
        public DbSet<Restaurant> Restaurant { get; set; }
    }
}
