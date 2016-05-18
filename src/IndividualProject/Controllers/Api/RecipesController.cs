using IndividualProject.Models;
using IndividualProject.Services;
using IndividualProject.Services.Models;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualProject.Controllers.Api {
    [Produces("application/json")]
    [Route("api/Recipes")]
    public class RecipesController : Controller {
        private RecipeService _service;

        public RecipesController (RecipeService service) {
            _service = service;
        }

        //GET: api/Recipes
        [HttpGet]
        public IEnumerable<RecipeDTO> GetRecipes() {
            return _service.ListAll();
        }
    }
}
