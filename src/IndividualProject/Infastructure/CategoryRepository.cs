using IndividualProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualProject.Infastructure {
    public class CategoryRepository {

        private ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) {

            _db = db;
        }

        public IQueryable<Category> List() {

            return _db.Categories;
        }
        public void SaveChanges() {

            _db.SaveChanges();
        }
    }
}
