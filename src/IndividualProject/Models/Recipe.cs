using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualProject.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        public string AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public ApplicationUser AppUser { get; set; }

        public string RecipeName { get; set; }

        public IList<Ingredient> Ingredients { get; set; }

        public string PictureUrl { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public IList<Like> Likes { get; set; }
    }
}
