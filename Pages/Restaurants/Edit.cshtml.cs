using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Models;
using OdeToFood.Services;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private IRestaurantData _restaurantData;

        public Restaurant Restaurant {get; set;} // OdeToFood.Models

        public EditModel(IRestaurantData restaurantData) //OdeToFood.Services
        {
            _restaurantData = restaurantData;
        }

      //  public void OnGet(int id)
        public IActionResult OnGet(int id) // Return action result
        {
            Restaurant = _restaurantData.Get(id); // Gets Restaurant data by id from SQL
            if(Restaurant == null)
            {
                return RedirectToAction("Index", "Home"); // Redirect to Home if is null
            }
            return Page();  // like render a view method , renders the page.
        }
    }
}
