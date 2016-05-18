using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using IndividualProject.Models;

namespace IndividualProject.Controllers {
    [Produces("application/json")]
    [Route("api/Ingredients")]
    public class IngredientsController : Controller {
        private ApplicationDbContext _context;

        public IngredientsController(ApplicationDbContext context) {
            _context = context;
        }

        // GET: api/Ingredients
        [HttpGet]
        public IEnumerable<Ingredient> GetIngredients() {
            return _context.Ingredients;
        }

        // GET: api/Ingredients/5
        [HttpGet("{id}", Name = "GetIngredient")]
        public async Task<IActionResult> GetIngredient([FromRoute] int id) {
            if (!ModelState.IsValid) {
                return HttpBadRequest(ModelState);
            }

            Ingredient ingredient = await _context.Ingredients.SingleAsync(m => m.Id == id);

            if (ingredient == null) {
                return HttpNotFound();
            }

            return Ok(ingredient);
        }

        // PUT: api/Ingredients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngredient([FromRoute] int id, [FromBody] Ingredient ingredient) {
            if (!ModelState.IsValid) {
                return HttpBadRequest(ModelState);
            }

            if (id != ingredient.Id) {
                return HttpBadRequest();
            }

            _context.Entry(ingredient).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!IngredientExists(id)) {
                    return HttpNotFound();
                }
                else {
                    throw;
                }
            }

            return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
        }

        // POST: api/Ingredients
        [HttpPost]
        public async Task<IActionResult> PostIngredient([FromBody] Ingredient ingredient) {
            if (!ModelState.IsValid) {
                return HttpBadRequest(ModelState);
            }

            _context.Ingredients.Add(ingredient);
            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException) {
                if (IngredientExists(ingredient.Id)) {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else {
                    throw;
                }
            }

            return CreatedAtRoute("GetIngredient", new { id = ingredient.Id }, ingredient);
        }

        // DELETE: api/Ingredients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredient([FromRoute] int id) {
            if (!ModelState.IsValid) {
                return HttpBadRequest(ModelState);
            }

            Ingredient ingredient = await _context.Ingredients.SingleAsync(m => m.Id == id);
            if (ingredient == null) {
                return HttpNotFound();
            }

            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();

            return Ok(ingredient);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IngredientExists(int id) {
            return _context.Ingredients.Count(e => e.Id == id) > 0;
        }
    }
}