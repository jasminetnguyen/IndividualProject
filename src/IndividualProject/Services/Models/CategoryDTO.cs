using IndividualProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualProject.Services.Models {
    public class CategoryDTO {
        public string Name { get; set; }

        public IList<IngredientDTO> Ingredients { get; set; }
    }
}
