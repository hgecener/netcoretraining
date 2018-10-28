using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers
{
  
  //[Route("about")]  //This is "Attribute Routing"
  [Route("[controller]")]  // The [controller] token is used...
 // [Route("api/[controller]/[action]")]  // The api/[controller]/[action] token is used...And literal syntax as well.
  public class AboutController2 : Controller
  {
     [Route("")] // If this is blank means default 
    public string Phone(){
        return "1+555+555+5555";
    }
     //[Route("address")]
     [Route("address")]  // The [action] token is used.
    public string Address(){
        return "USA";
    }

    // public IActionResult Index()
    // {
    //   return View();
    // }

    // public IActionResult Welcome()
    // {
    //   ViewData["Message"] = "Your welcome message";

    //   return View();
    // }
  }
}