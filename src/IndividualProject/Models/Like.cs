using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualProject.Models
{
    public class Like
    {
        public int Id { get; set; }

        public string AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public ApplicationUser AppUser { get; set;}

        public int RecipeId { get; set; }
        [ForeignKey("RecipeId")]
        public Recipe Recipe { get; set; }
    }
}
