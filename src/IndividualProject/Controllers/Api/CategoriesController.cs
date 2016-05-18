using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using IndividualProject.Models;
using IndividualProject.Services;
using IndividualProject.Services.Models;

namespace IndividualProject.Controllers
{
    [Produces("application/json")]
    [Route("api/Categories")]
    public class CategoriesController : Controller
    {
        private CategoryService _service;

        public CategoriesController(CategoryService service)
        {
            _service = service;
        }

        // GET: api/Categories
        [HttpGet]
        public IEnumerable<CategoryDTO> GetCategories()
        {
            return _service.ListAll();
        }

        // GET: api/Categories/5
        //[HttpGet("{id}", Name = "GetCategory")]
        //public async Task<IActionResult> GetCategory([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return HttpBadRequest(ModelState);
        //    }

        //    Category category = await _service.Categories.SingleAsync(m => m.Id == id);

        //    if (category == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return Ok(category);
        //}

        // PUT: api/Categories/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCategory([FromRoute] int id, [FromBody] Category category)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return HttpBadRequest(ModelState);
        //    }

        //    if (id != category.Id)
        //    {
        //        return HttpBadRequest();
        //    }

        //    _service.Entry(category).State = EntityState.Modified;

        //    try
        //    {
        //        await _service.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CategoryExists(id))
        //        {
        //            return HttpNotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
        //}

        //// POST: api/Categories
        //[HttpPost]
        //public async Task<IActionResult> PostCategory([FromBody] Category category)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return HttpBadRequest(ModelState);
        //    }

        //    _service.Categories.Add(category);
        //    try
        //    {
        //        await _service.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (CategoryExists(category.Id))
        //        {
        //            return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("GetCategory", new { id = category.Id }, category);
        //}

        //// DELETE: api/Categories/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return HttpBadRequest(ModelState);
        //    }

        //    Category category = await _service.Categories.SingleAsync(m => m.Id == id);
        //    if (category == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    _service.Categories.Remove(category);
        //    await _service.SaveChangesAsync();

        //    return Ok(category);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _service.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool CategoryExists(int id)
        //{
        //    return _service.Categories.Count(e => e.Id == id) > 0;
        //}
    }
}