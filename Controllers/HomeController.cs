using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OdeToFood.Controllers
{

  public class HomeController : Controller
  {
      public string Index()
      {
          return "Hello from the HomeController";
      }

  }
}
