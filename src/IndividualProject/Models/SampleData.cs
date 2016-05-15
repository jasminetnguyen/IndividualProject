using System;
using System.Linq;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace IndividualProject.Models {
    public class SampleData {
        public async static Task Initialize(IServiceProvider serviceProvider) {
            var db = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            // Ensure Stephen (IsAdmin)
            var stephen = await userManager.FindByNameAsync("Stephen.Walther@CoderCamps.com");
            if (stephen == null) {
                // create user
                stephen = new ApplicationUser {
                    UserName = "Stephen.Walther@CoderCamps.com",
                    Email = "Stephen.Walther@CoderCamps.com"
                };
                await userManager.CreateAsync(stephen, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(stephen, new Claim("IsAdmin", "true"));
            }

            // Ensure Mike (not IsAdmin)
            var mike = await userManager.FindByNameAsync("Mike@CoderCamps.com");
            if (mike == null) {
                // create user
                mike = new ApplicationUser {
                    UserName = "Mike@CoderCamps.com",
                    Email = "Mike@CoderCamps.com"
                };
                await userManager.CreateAsync(mike, "Secret123!");
            }
            var ingredients = new List<Ingredient>() {
                new Ingredient () { Name = "Sugar" },
                new Ingredient () { Name = "Flour" },
                new Ingredient () { Name = "Lemon Pepper" },
                new Ingredient () { Name = "Lemon" },
                new Ingredient () { Name = "Mayo" }
            };
            for (int i = 0; i < ingredients.Count; i++) {
                var ingredient = ingredients[i];
                var dbIngredient = db.Ingredients.FirstOrDefault(n => n.Name == ingredient.Name);

                if (dbIngredient == null) {
                    db.Ingredients.Add(ingredient);
                }
                else {
                    ingredients[i] = dbIngredient;
                }
            }
            db.SaveChanges();

            var categories = new List<Category>() {
                new Category () { Name = "Seasoning" },
                new Category () { Name = "Fruit" },
                new Category () { Name = "Veggie" },
                new Category () { Name = "Dry Mix" }
            };

            for (int i = 0; i < categories.Count; i++) {
                var category = categories[i];
                var dbCategory = db.Categories.FirstOrDefault(c => c.Name == category.Name);

                if(dbCategory == null) {
                    db.Categories.Add(category);
                }
                else {
                    categories[i] = dbCategory;
                }
            }
            db.SaveChanges();

            
            //var ingredientCategories = new List<IngredientCategory>() {
            //    new IngredientCategory() {
            //        Category = categories.FirstOrDefault(c => c.Name == "Seasoning"),
            //        Ingredient = ingredients.FirstOrDefault(n => n.Name == "Lemon Pepper"),
            //        Id = 1

            //    },
            //    new IngredientCategory () {
            //        Category = categories.FirstOrDefault(c => c.Name == "Fruit"),
            //        Ingredient = ingredients.FirstOrDefault(n => n.Name =="Lemon"),
            //        Id = 2
            //    }

            //};

            //for (int i = 0; i < ingredientCategories.Count; i++) {
            //    var ingredientCategory = ingredientCategories[i];
            //    var dbIngredientCategory = db.IngredientCatergories.FirstOrDefault(l => l.Id == ingredientCategory.Id);
            
            //    if(dbIngredientCategory == null) {
            //        db.IngredientCatergories.Add(ingredientCategory);
            //    }
            //    else {
            //        ingredientCategories[i] = dbIngredientCategory;
            //    }
                
            //}
            //db.SaveChanges();
            

        }

    }
}