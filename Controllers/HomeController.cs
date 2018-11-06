using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OdeToFood.Models;

namespace OdeToFood.Controllers
{

    public class HomeController : Controller // : Controller class provides MVC methods...
    {
        private IRestaurantData _restaurantaData;

        //Create an inctance for this request.. Also looks at this constructor and gets restaurantData
        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantaData = restaurantData;
        }
        public IActionResult Index()
        {


            var model= _restaurantaData.GetAll();
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
