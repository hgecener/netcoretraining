using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Models
{
    public class Restaurant
    {
        public int Id { get; set;}

        [Display(Name="Restarurant Name")]
       // [DataType(DataType.Password)] /// Turns editable field as type="password"
        [Required, MaxLength(80)]  // Tag helper creates attributes appropriately
        public string Name { get; set;}
        public CuisineType Cuisine { get; set; }

    }
    
}