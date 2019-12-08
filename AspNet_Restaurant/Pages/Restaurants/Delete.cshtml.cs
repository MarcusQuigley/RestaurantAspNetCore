using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNet_Restaurant.Core;
using AspNet_Restaurant.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNet_Restaurant
{
    public class DeleteModel : PageModel
    {
        
        readonly            IRestaurantDataService service;

        public DeleteModel(IRestaurantDataService service)
        {
            this.service = service;
        }

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public IActionResult OnGet(int restaurantId) {

            Restaurant = service.GetById(restaurantId);
            if (Restaurant==null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int restaurantId)
        {
            Restaurant = service.Delete(restaurantId);
                if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
         //   service.Commit();

            return RedirectToPage("List");
        }

        
    }
}