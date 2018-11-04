using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OdeToFood.Models;

namespace OdeToFood.Controllers
{

  public class HomeController_Sample1 : Controller // : Controller class provides MVC methods...
  {
    //   public ContentResult Index()
    //   {
    //   }
      public IActionResult Index()  
      {
          // this does not write immediately to response, returns to IAction then decides. Allows unit testing
          var model = new Restaurant { Id = 1, Name = "Scott's Pizza Place"};

          return new ObjectResult(model); // This returns serialize the object to Json format.. Even index.cshtml does not exist.
      }

  }
}
