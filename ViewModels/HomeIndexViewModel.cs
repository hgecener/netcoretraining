using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood.Models;

// This is created for providing the restaurant and medssage of the day data in one place that HomeController needs.
// this id called DTO data transfer object
namespace OdeToFood.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; } // this comes from restaurant data in Memory
        public string CurrentMessage { get; set; } // comes from enviroment variable
    }
    // put all together in one vieaw model
}