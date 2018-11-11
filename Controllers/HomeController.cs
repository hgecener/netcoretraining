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

            var model = new HomeIndexViewModel(); // uses for get all data in model object
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

    }
}
