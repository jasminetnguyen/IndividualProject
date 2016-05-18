using IndividualProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualProject.Infastructure {
    public class IngredientRepository {
        private ApplicationDbContext _db;

        public IngredientRepository(ApplicationDbContext db) {

            _db = db;
        }

        public IQueryable<Ingredient> List() {

            return _db.Ingredients;
        }
        public void SaveChanges() {

            _db.SaveChanges();
        }
    }
}
