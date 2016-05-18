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
                new Ingredient () { Name = "Salt" },
                new Ingredient () { Name = "Carrots" },
                new Ingredient () { Name = "Grapes" },
                new Ingredient () { Name = "Baking Soda" },
                new Ingredient () { Name = "Heavy Cream" },
                new Ingredient () { Name = "Eggs" },
                new Ingredient () { Name = "Brown Sugar" },
                new Ingredient () { Name = "Unsweetened Chocolate" },
                new Ingredient () { Name = "Confectioner Sugar" },
                new Ingredient () { Name = "Vanilla Extract" },
                new Ingredient () { Name = "Sour Cream" },
                new Ingredient () { Name = "Milk" },
                new Ingredient () { Name = "Garlic Powder" },
                new Ingredient () { Name = "Cinnamon" },
                new Ingredient () { Name = "Chili Powder" },
                new Ingredient () { Name = "Onion Powder" },
                new Ingredient () { Name = "Nutmeg" },
                new Ingredient () { Name = "Ginger Powder" },
                new Ingredient () { Name = "Apple" },
                new Ingredient () { Name = "Banana" },
                new Ingredient () { Name = "Pineapple" },
                new Ingredient () { Name = "Peach" },
                new Ingredient () { Name = "Plum" },
                new Ingredient () { Name = "Pear" },
                new Ingredient () { Name = "Cherry" },
                new Ingredient () { Name = "Artichoke" },
                new Ingredient () { Name = "Broccoli" },
                new Ingredient () { Name = "Brussel Sprout" },
                new Ingredient () { Name = "Cailiflower" },
                new Ingredient () { Name = "Corn" },
                new Ingredient () { Name = "Eggplant" },
                new Ingredient () { Name = "Green Bean" },
                new Ingredient () { Name = "Pea" },
                new Ingredient () { Name = "Potatoes" }
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
                new Category () {
                    Name = "Seasoning"
                },
                new Category () {
                    Name = "Fruit"
                },
                new Category () {
                    Name = "Veggie"
                },
                new Category () {
                    Name = "Dry Ingredients"
                },
                new Category () {
                    Name = "Wet Ingredients"
                }
            };

            for (int i = 0; i < categories.Count; i++) {
                var category = categories[i];
                var dbCategory = db.Categories.FirstOrDefault(c => c.Name == category.Name);

                if (dbCategory == null) {
                    db.Categories.Add(category);
                }
                else {
                    categories[i] = dbCategory;
                }
            }
            db.SaveChanges();


            var recipes = new List<Recipe>()
            {
                new Recipe () {
                    AppUser = db.Users.FirstOrDefault(u => u.UserName == "Stephen.Walther@CoderCamps.com"),
                    RecipeName = "Fabulous Fudge Chocolate Cake",
                    Ingredients = new List<IngredientRecipe> {
                        new IngredientRecipe { Ingredient = db.Ingredients.FirstOrDefault(i => i.Name == "Eggs") },
                        new IngredientRecipe { Ingredient = db.Ingredients.FirstOrDefault(i => i.Name == "Sugar") },
                        new IngredientRecipe { Ingredient = db.Ingredients.FirstOrDefault(i => i.Name == "Baking Soda") },
                        new IngredientRecipe { Ingredient = db.Ingredients.FirstOrDefault(i => i.Id == 5) },
                        new IngredientRecipe { Ingredient = db.Ingredients.FirstOrDefault(i => i.Name == "Flour") },
                        new IngredientRecipe { Ingredient = db.Ingredients.FirstOrDefault(i => i.Name == "Heavy Cream") },
                        new IngredientRecipe { Ingredient = db.Ingredients.FirstOrDefault(i => i.Name == "Butter") },
                        new IngredientRecipe { Ingredient = db.Ingredients.FirstOrDefault(i => i.Name == "Brown Sugar") },
                        new IngredientRecipe {Ingredient = db.Ingredients.FirstOrDefault(i => i.Name == "Vanilla Extract") },
                        new IngredientRecipe {Ingredient = db.Ingredients.FirstOrDefault(i => i.Name == " Unsweetened Chocolate") },
                        new IngredientRecipe {Ingredient = db.Ingredients.FirstOrDefault(i => i.Name == "Sour Cream") },
                        new IngredientRecipe {Ingredient = db.Ingredients.FirstOrDefault(i => i.Name == "Milk") },
                     

                    },
                    PictureUrl = "http://images.media-allrecipes.com/userphotos/250x250/971031.jpg",
                    DateCreated = DateTime.Now,
                    Description = "Preheat oven to 350 degrees F (175 degrees C). Sift together the flour, baking soda and salt. Set aside.In a large bowl, beat 1/2 cup butter or margarine and 2 1/2 cups brown sugar until well mixed. Add eggs one at a time. Beat in the vanilla and melted chocolate squares. Add 1/2 the sour cream and then 1/2 the dry ingredients to the butter mixture until well blended. Add the remaining sour cream and dry ingredients to the batter. Stir in boiling water. Bake in a greased 9 X 13 inch pan for 35 minutes. Let cool 10 minutes before icing.",
                 }
           };

            for (int i = 0; i < recipes.Count; i++) {
                var recipe = recipes[i];
                var dbRecipe = db.Recipes.FirstOrDefault(r => r.RecipeName == recipe.RecipeName);

                if (dbRecipe == null) {
                    db.Recipes.Add(recipe);
                }
                else {
                    recipes[i] = dbRecipe;
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