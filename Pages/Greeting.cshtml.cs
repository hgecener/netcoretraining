using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Services;

namespace OdeToFood.Pages
{
    // Greeting.cshtml implement using @model
    public class GreetingModel : PageModel
    {
        private IGreeter _greeter;
        public string CurrentGreeting {get; set;}

        public GreetingModel(IGreeter greeter)
        {
            _greeter = greeter;
        }
        //"name" is string paramater is recived from URL  hostname/<pagename>/{name}
        public void OnGet(string name)
        {
            //CurrentGreeting = _greeter.GetMessageOfTheDay();
            CurrentGreeting = $"{name}: {_greeter.GetMessageOfTheDay()}";
        }
    }
}