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

            var tim = await userManager.FindByNameAsync("tim@CoderCamps.com");
            if (tim == null) {
                // create user
                tim = new ApplicationUser {
                    UserName = "tim@CoderCamps.com",
                    Email = "tim@CoderCamps.com"
                };
                await userManager.CreateAsync(tim, "Secret123!");
            }
            db.SaveChanges();
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
                new Ingredient () { Name = "Potatoes" },
                new Ingredient () { Name = "Half and Half Cream" },
                new Ingredient () { Name = "Peanut Butter" },
                new Ingredient () { Name = "Almond Flour" },
                new Ingredient () { Name ="Cream Cheese" },
                new Ingredient () { Name = "Instant Vanilla Pudding Mix" } };
               

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
                    AppUser = db.Users.FirstOrDefault(u => u.UserName == "Mike@CoderCamps.com"),
                    RecipeName = "Vanilla Ice Cream",
                    Ingredients = new List<IngredientRecipe> {
                        new IngredientRecipe { Ingredient = db.Ingredients.FirstOrDefault(i => i.Name == "Half and Half Cream") },
                        new IngredientRecipe { Ingredient = db.Ingredients.FirstOrDefault(i => i.Name == "Heavy Cream") },
                        new IngredientRecipe { Ingredient = db.Ingredients.FirstOrDefault(i => i.Name == "Sugar") },
                        new IngredientRecipe { Ingredient = db.Ingredients.FirstOrDefault(i => i.Name == "Vanilla Extract") },
                        new IngredientRecipe { Ingredient = db.Ingredients.FirstOrDefault(i => i.Name == "Salt") }
                     },
                    PictureUrl = "https://s-media-cache-ak0.pinimg.com/564x/b6/cd/9c/b6cd9c8ea056ada7e88fee935a4c07dc.jpg",
                    DateCreated = DateTime.Now.AddDays(4),
                    Description = "Combine half-and-half, cream, sugar, vanilla and salt in freezer container of ice cream maker. Freeze according to manufacturer's instructions.",
                 },
                new Recipe () {
                    AppUser = db.Users.FirstOrDefault(u => u.UserName == "Mike@CoderCamps.com"),
                    RecipeName = "Peach Cobbler",
                    Ingredients = new List<IngredientRecipe> {
                        new IngredientRecipe { Ingredient = db.Ingredients.FirstOrDefault(i => i.Name == "Milk") },
                        new IngredientRecipe { Ingredient = db.Ingredients.FirstOrDefault(i => i.Name == "Self Rising Flour") },
                        new IngredientRecipe { Ingredient = db.Ingredients.FirstOrDefault(i => i.Name == "Sugar") },
                        new IngredientRecipe { Ingredient = db.Ingredients.FirstOrDefault(i => i.Name == "Butter") },
                        new IngredientRecipe { Ingredient = db.Ingredients.FirstOrDefault(i => i.Name == "Peach") }
                     },
                    PictureUrl = "https://s-media-cache-ak0.pinimg.com/564x/e9/94/1f/e9941f0b6bd6b3aff5bab208663263d6.jpg",
                    DateCreated = DateTime.Now.AddDays(9),
                    Description = "Preheat oven to 375 degrees F (190 degrees C). Grease an 11x17-inch baking dish. Whisk milk, flour, and 1 cup sugar together in a bowl until blended; add butter. Stir to combine. Arrange peaches in prepared baking dish; sprinkle with 1 tablespoon sugar. Cover peaches with batter, without stirring. Bake in the preheated oven until browned and bubbling, about 40 minutes.",
                 },
                 new Recipe () {
                    AppUser = db.Users.FirstOrDefault(u => u.UserName == "Mike@CoderCamps.com"),
                    RecipeName = "Peanut Butter Cookies",
                    Ingredients = new List<IngredientRecipe> {
                        new IngredientRecipe { Ingredient = db.Ingredients.FirstOrDefault(i => i.Name == "Peanut Butter") },
                         new IngredientRecipe { Ingredient = db.Ingredients.FirstOrDefault(i => i.Name == "Sugar") },
                        new IngredientRecipe { Ingredient = db.Ingredients.FirstOrDefault(i => i.Name == "Butter") },
                       },
                    PictureUrl = "https://s-media-cache-ak0.pinimg.com/236x/2b/9f/ac/2b9fac76efc6d30a0045fd69098ab7a3.jpg",
                    DateCreated = DateTime.Now.AddDays(9),
                    Description = "Preheat oven to 350 degrees F (175 degrees C). Mix peanut butter, sugar, and egg together in a bowl using an electric mixer until smooth and creamy.Roll mixture into small balls and arrange on a baking sheet; flatten each with a fork, making a criss - cross pattern. Bake in the preheated oven for 10 minutes.Cool cookies on the baking sheet for 2 minutes before moving to a plate.",
                 },
                  new Recipe () {
                    AppUser = db.Users.FirstOrDefault(u => u.UserName == "Mike@CoderCamps.com"),
                    RecipeName = "Macaroons",
                    Ingredients = new List<IngredientRecipe> {
                        new IngredientRecipe { Ingredient = db.Ingredients.FirstOrDefault(i => i.Name == "Eggs") },
                        new IngredientRecipe { Ingredient = db.Ingredients.FirstOrDefault(i => i.Name == "Confectioner Sugar") },
                        new IngredientRecipe { Ingredient = db.Ingredients.FirstOrDefault(i => i.Name == "Almond Flour") },
                        new IngredientRecipe { Ingredient = db.Ingredients.FirstOrDefault(i => i.Name == "Sugar") },
                        new IngredientRecipe { Ingredient = db.Ingredients.FirstOrDefault(i => i.Name == "Salt") }
                     },
                    PictureUrl = "https://s-media-cache-ak0.pinimg.com/564x/75/52/00/755200db4b27f5860f68c4d852dd0fc7.jpg",
                    DateCreated = DateTime.Now.AddDays(4),
                    Description = "Place egg whites into a metal mixing bowl and refrigerate overnight. The next day, bring egg whites to room temperature. Preheat oven to 280 degrees F (138 degrees C). Line baking sheets with parchment paper. Whisk confectioners' sugar and almond flour in a bowl. Beat the egg whites with salt in metal bowl with an electric mixer on medium speed until foamy, about 1 minute; increase speed to high and gradually beat in superfine sugar, about 1 tablespoon at a time, until the egg whites are glossy and hold stiff peaks, 3 to 5 more minutes. Gently fold almond flour mixture into whipped egg whites until thoroughly incorporated; spoon meringue into a pastry big fitted with a 3 / 8 - inch tip. Pipe 1 - inch disks of meringue onto the prepared baking sheets, leaving 2 inches of space between cookies.The batter will spread. Lift the baking sheets a few inches above the work surface and hit them lightly on the work surface several times to remove any air bubbles from the cookies.Let the cookies stand at room temperature until the shiny surfaces become dull and a thin skin forms, about 15 minutes. Place the baking sheets in the preheated oven and bake with the oven door open slightly until the macarons' surfaces are completely dry, about 15 minutes. Let cookies cool completely on a baking sheet before peeling parchment paper from the cookies. Spread half the cookies with any desired filling, top with remaining cookies to make sandwiches, and refrigerate at least 2 hours to overnight to let the cookies soften.",
                 },
                  new Recipe () {
                    AppUser = db.Users.FirstOrDefault(u => u.UserName == "Mike@CoderCamps.com"),
                    RecipeName = "Banana Pudding",
                    Ingredients = new List<IngredientRecipe> {
                        new IngredientRecipe { Ingredient = db.Ingredients.FirstOrDefault(i => i.Name == "Cream Cheese") },
                        new IngredientRecipe { Ingredient = db.Ingredients.FirstOrDefault(i => i.Name == "Instant Vanilla Pudding Mix") },
                        new IngredientRecipe { Ingredient = db.Ingredients.FirstOrDefault(i => i.Name == "Milk") },
                        new IngredientRecipe { Ingredient = db.Ingredients.FirstOrDefault(i => i.Name == "Vanilla Extract") },
                        new IngredientRecipe { Ingredient = db.Ingredients.FirstOrDefault(i => i.Name == "Banana") }
                     },
                    PictureUrl = "https://s-media-cache-ak0.pinimg.com/564x/5b/5d/ce/5b5dcee1df4c82dfeebbde809285e0af.jpg",
                    DateCreated = DateTime.Now.AddDays(4),
                    Description = "1 (8 ounce) package cream cheese 1 (14 ounce) can sweetened condensed milk 1 (5 ounce) package instant vanilla pudding mix 3 cups cold milk 1 teaspoon vanilla extract 1 (8 ounce) container frozen whipped topping, thawed 4 bananas, sliced",
                 },
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