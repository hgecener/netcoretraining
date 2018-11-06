using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood.Models;

namespace OdeToFood.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        //
        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
              new Restaurant {Id = 1, Name = "Scott's Pizza Place" },
              new Restaurant {Id = 2, Name = "Tersiguels" },
              new Restaurant {Id = 1, Name = "King's Contrivance" }

            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(r => r.Name);
        }
        List<Restaurant> _restaurants;


    }
}