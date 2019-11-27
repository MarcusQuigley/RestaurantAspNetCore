using System;
using System.Collections.Generic;
using System.Text;

namespace AspNet_Restaurant.Core
{
    public class Restaurant
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Location { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
