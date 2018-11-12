using System.ComponentModel.DataAnnotations;
using OdeToFood.Models;

namespace OdeToFood.ViewModels
{
    public class RestaurantEditModel
    {

        [Required, MaxLength(80)]   // Data annotations
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }

}