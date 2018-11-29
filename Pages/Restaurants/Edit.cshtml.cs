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

         //This attribute tells framework take the information from incoming request and bound it to Restaurant object
        [BindProperty]
        public Restaurant Restaurant {get; set;} // OdeToFood.Models

        public EditModel(IRestaurantData restaurantData) //OdeToFood.Services
        {
            _restaurantData = restaurantData;
        }

        //  public void OnGet(int id)  // Previously ***
        public IActionResult OnGet(int id) // Return action result
        {
            Restaurant = _restaurantData.Get(id); // Gets Restaurant data by id from SQL
            if(Restaurant == null)
            {
                return RedirectToAction("Index", "Home"); // Redirect to Home if is null
            }
            return Page();  // like render a view method , renders the page.
        }

         public IActionResult OnPost() // Receive post action result
        {
            if (ModelState.IsValid)
            {
                _restaurantData.Update(Restaurant);  // Entity frameworks update Restaurant data 
                return RedirectToAction("Details","Home", new { id = Restaurant.Id}); // Redirects to Home/Details
            }
            return Page();
        }
    }
}
