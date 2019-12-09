using AspNet_Restaurant.Core;
using AspNet_Restaurant.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNet_Restaurant
{
    public class DeleteModel : PageModel
    {
         readonly IRestaurantDataService service;

        public DeleteModel(IRestaurantDataService service)
        {
            this.service = service;
        }
       
        public Restaurant Restaurant { get; set; }

        public IActionResult OnGet(int restaurantId)
        {

            Restaurant = service.GetById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int restaurantId)
        {
            Restaurant = service.Delete(restaurantId);
            service.Commit();
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
             
            TempData["Message"] = $"{Restaurant.Name} has been deleted.";
            return RedirectToPage("List");
        }
    }
}