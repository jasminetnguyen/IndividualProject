using IndividualProject.Infastructure;
using IndividualProject.Models;
using IndividualProject.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualProject.Services
{
    public class RecipeService
    {
        private RecipeRepository _repo;

        public RecipeService(RecipeRepository repo) {
            _repo = repo;
        }

        public IList<RecipeDTO> ListAll() {
            var model = (from r in _repo.List()
                select new RecipeDTO {
                    Id = r.Id,
                    RecipeName = r.RecipeName,
                    PictureUrl = r.PictureUrl,
                    Description = r.Description,
                    DateCreated = r.DateCreated,
                    AppUser = new ApplicationUser {
                        Id = r.AppUserId,
                        Email = r.AppUser.Email
                    },
                    Ingredients = (from t in r.Ingredients select new IngredientDTO {
                        Id = t.Id,
                        Name = t.Ingredient.Name
                    }).ToList(),
            }).ToList();

            return model;
        }
    }
}
