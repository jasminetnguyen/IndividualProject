using IndividualProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualProject.Services.Models
{
    public class RecipeDTO
    {
        public int Id { get; set; }

        public ApplicationUser AppUser { get; set; }

        public string RecipeName { get; set; }

        public IList<IngredientDTO> Ingredients { get; set; }

        public string PictureUrl { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public IList<Like> Likes { get; set; }
    }
}
