using AspNet_Restaurant.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet_Restaurant.ViewComponents
{
    public class RestaurantCountViewComponent
        :ViewComponent
    {
        readonly IRestaurantDataService service;
        public RestaurantCountViewComponent(IRestaurantDataService service)
        {
            this.service = service;
        }
        public IViewComponentResult Invoke()
        {
            var count = service.CountOfRestaurants;
            return View(count); //default view
        }
    }

    
}
