using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OdeToFood.Models;

namespace OdeToFood.Controllers
{

    public class HomeController : Controller // : Controller class provides MVC methods...
    {
        public IActionResult Index()
        {
            // this does not write immediately to response, returns to IAction then decides. Allows unit testing
            var model = new Restaurant
            {
                Id = 1,
                Name = "Scott's Pizza Place"
            };

            return View(model); //If a index.cshtml is not found gives an error.
        }

    }
}
