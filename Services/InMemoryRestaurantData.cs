using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood.Models;

namespace OdeToFood.Services
{
    
        //Disabled after added "Update" method to IRestaurantData Interface, because this service caused Error. 
        //No implementation Update method here. So it's disbaled.
    //     public InMemoryRestaurantData()
    //     {
    //         _restaurants = new List<Restaurant>
    //         {
    //           new Restaurant {Id = 1, Name = "Scott's Pizza Place" },
    //           new Restaurant {Id = 2, Name = "Tersiguels" },
    //           new Restaurant {Id = 3, Name = "King's Contrivance" }

    //         };
    //     }
    //     public IEnumerable<Restaurant> GetAll()
    //     {
    //         return _restaurants.OrderBy(r => r.Name);
    //     }

    //     public Restaurant Get(int id)
    //     {
    //         return _restaurants.FirstOrDefault(r => r.Id == id);
    //     }

    //     public Restaurant Add(Restaurant restaurant)
    //     {
    //         restaurant.Id = _restaurants.Max(r => r.Id) + 1;
    //         _restaurants.Add(restaurant); // This Add method for list restaurant C# function.
    //         return restaurant; // Holds the data in memeory.
    //     }

    //     List<Restaurant> _restaurants;


    // }
}