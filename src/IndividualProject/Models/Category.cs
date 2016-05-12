using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualProject.Models {
    public class Category {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<IngredientCategory> Ingredients { get; set; }
    }
}
