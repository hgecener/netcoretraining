using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood.Models;

// This is Interface.. 
public interface IRestaurantData
{
    IEnumerable<Restaurant> GetAll();
}