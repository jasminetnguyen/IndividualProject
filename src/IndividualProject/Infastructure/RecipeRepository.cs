using IndividualProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualProject.Infastructure
{
    public class RecipeRepository
    {
        private ApplicationDbContext _db;
        public RecipeRepository(ApplicationDbContext db) {
            _db = db;
        }

        public IQueryable<Recipe> List() {

            return _db.Recipes;
        }

        public void SaveChanges() {

            _db.SaveChanges();
        }
    }
}
