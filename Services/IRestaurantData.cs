using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood.Models;

// This is Interface... 
public interface IRestaurantData
{
    // Defines a method which is called "GetAll"
    IEnumerable<Restaurant> GetAll(); // returns a Restaurnt object list that is iterable
    Restaurant Get(int id); // returns Restaurant object
}

