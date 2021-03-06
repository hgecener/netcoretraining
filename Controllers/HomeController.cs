using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OdeToFood.Models;
using OdeToFood.Services;
using OdeToFood.ViewModels;

namespace OdeToFood.Controllers
{

    public class HomeController : Controller // : Controller class provides MVC methods...
    {
        private IRestaurantData _restaurantaData;
        private IGreeter _greeter;

        //Create an inctance for this request.. Also looks at this constructor and gets restaurantData
        public HomeController(IRestaurantData restaurantData,
                              IGreeter greeter)
        {
            _restaurantaData = restaurantData;
            _greeter = greeter;
        }
        public IActionResult Index()
        {


            //var model = _restaurantaData.GetAll();

            var model = new HomeIndexViewModel(); // uses for get all data in model object. this is output model
            model.Restaurants = _restaurantaData.GetAll();
            model.CurrentMessage = _greeter.GetMessageOfTheDay(); // To get the message added IGreeter services above 
            // this does not write immediately to response, returns to IAction then decides. Allows unit testing
            // var model = new Restaurant
            // {
            //     Id = 1,
            //     Name = "Scott's Pizza Place"
            // };

            return View(model); //If a index.cshtml is not found gives an error.
        }

        public IActionResult Details(int id) // home/details/2  or home/details?id=2 also works.. also look Posted form value of id
        // if home/details/3?id=2  is requested , restaurant 3 returns not 2... Looking first routing value
        {
            // return Content(id.ToString());
            var model = _restaurantaData.Get(id); // Get method should be added IRestaurantData (interface) 
                                                  //that id preferrable to avoid null data
            if (model == null)
            {
                //return View("Not Found");
                //return NotFound(); // API much better gives 404 not found..
                //return RedirectToAction("Index");  redirects to Home/Index page.
                return RedirectToAction(nameof(Index)); // redirects to Home/Index page.. name of for easy to refactoring...

            }
            return View(model);
        }

        [HttpGet]  // Same Create name 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  // This needs validate Crosssite Forgery validation
        public IActionResult Create(RestaurantEditModel model)
        {
            // It calls model binding here 
            // Also gete model state here
            if (ModelState.IsValid)
            {
                // Creates a new Restaurant
                var newRestaurant = new Restaurant();
                newRestaurant.Name = model.Name;
                newRestaurant.Cuisine = model.Cuisine;

                newRestaurant = _restaurantaData.Add(newRestaurant);

                // return View("Details", newRestaurant); // This sends the page immadiately..It should be redirected..
                return RedirectToAction(nameof(Details), new { id = newRestaurant.Id, foo = "bar" }); // redirects to Home/Details/Id .. foo=bar is in QueryString

            }
            else
            {
                return View(); // Displays the the page that was submitted but didn't pass validation and displays erro meesages in the page ...
                // Look at the Create.cshtml   <span asp-validation-for="Name"></span>

            }
            // return Content("POST");


        }

    }
}
