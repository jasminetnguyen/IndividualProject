namespace IndividualProject.Controllers {

    export class HomeController {
        public ingredients;
        public findRecipes;
        public categories;

        constructor(private $http: ng.IHttpService) {
            // When controller initializes
            $http.get('/api/Ingredients').then((response) => {
                this.ingredients = response.data;
                console.log(response.data);
            });

            // Define function here
           
            this.findRecipes = (event) => {
                event.preventDefault();


                // Finding all the checked ingredients
                var checkedIngreds = $("input[name ='ingreds']:checked");

                // Get all the ingredients and structure an object and push it into an array
                var selectedIngreds = [];
                checkedIngreds.each(function () {
                    var name = $(this).attr('data-ingred');
                    var id = $(this).attr('value');

                    var ingredient = {
                        name,
                        id
                    };

                    selectedIngreds.push(ingredient);
                });

                console.log(selectedIngreds);
            }

            $http.get('/api/categories').then((response) => {
                this.categories = response.data;
                console.log(response.data);
            });
            
        }
    }

    export class AboutController {
        public message = 'Hello from the about page!';
    }

    export class SubmitController {
        public message = 'Hello from the submit page!';
    }
}
