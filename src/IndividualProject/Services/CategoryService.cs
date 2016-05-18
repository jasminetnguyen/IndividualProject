using IndividualProject.Infastructure;
using IndividualProject.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualProject.Services {

    public class CategoryService {
        private CategoryRepository _categoryRepo;

        public CategoryService(CategoryRepository cr) {
            _categoryRepo = cr;
        }
        public IList<CategoryDTO> ListAll() {
            return (from c in _categoryRepo.List()
                    select new CategoryDTO {
                        Name = c.Name,
                        Ingredients = (from i in c.Ingredients
                                       select new IngredientDTO() {
                                           Id = i.Ingredient.Id,
                                           Name = i.Ingredient.Name
                                       }).ToList()
                    }).ToList();
        }
    }
}
