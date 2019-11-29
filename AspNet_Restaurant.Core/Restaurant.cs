using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspNet_Restaurant.Core
{
    public class Restaurant
    {
        public int Id { get; set; }
        
        [Required, StringLength(80)]
        public String Name { get; set; }
        
        [Required, StringLength(255)]
        public String Location { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
