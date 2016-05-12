using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualProject.Models
{
    public class Ingredient
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public IList<IngredientCategory> Categories { get; set; }

        public IList<IngredientRecipe> Recipes { get; set; }
    }
}
