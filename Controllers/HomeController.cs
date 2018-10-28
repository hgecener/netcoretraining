using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OdeToFood.Controllers
{

  public class HomeController : Controller // : Controller class provides MVC methods
  {
      public IActionResult Index()
      {
          return Content("Hello from the HomeController");
      }

  }
}
