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

            $http.get('/api/Categories').then((response) => {
                this.categories = response.data;
                console.log(response.data);
            });

        }
    }

    export class AboutController {
        public message = 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus tristique, turpis tempus posuere consequat, eros odio tempus neque, in finibus turpis nibh eget massa. Maecenas eu gravida nibh. Vestibulum auctor erat consectetur massa rhoncus hendrerit. Phasellus magna arcu, rhoncus non volutpat eget, malesuada nec nisl. Ut facilisis tincidunt mi, eu aliquet ex vestibulum sed. Nam vulputate fermentum risus, a feugiat velit feugiat a. Nulla consequat mi sed viverra auctor. Etiam ac bibendum leo, nec ultricies velit. Nam dictum metus vel odio porttitor interdum. Pellentesque tristique quis augue at vestibulum.In justo quam, tempus vel commodo eu, scelerisque vel lacus. Quisque mauris diam, tincidunt sed commodo vitae, dictum non libero. Vivamus congue orci eu lorem congue, elementum interdum nulla placerat.Etiam venenatis faucibus sapien, non consequat velit ultrices et. Maecenas ante ante, mollis ut mi maximus, ultricies condimentum elit. In porttitor in lacus venenatis posuere.Ut eget neque lorem. Donec gravida, nisi vel iaculis commodo, justo augue ultrices dolor, eget mollis tellus urna ac lectus.Aliquam aliquam sapien quis nunc imperdiet, id blandit lacus molestie.Sed euismod ullamcorper nibh at rutrum. Nullam sem tortor, consectetur eget placerat sed, maximus sit amet sapien.Fusce laoreet tellus at justo volutpat, non pellentesque metus consequat. Vestibulum ac massa tellus.Pellentesque in congue urna, non venenatis elit. Cras ullamcorper mi odio, a sagittis urna vestibulum malesuada. Etiam auctor semper pellentesque.Nulla ligula ex, lacinia vel dignissim eu, eleifend vitae nisi. Curabitur vitae dui eu ante sollicitudin commodo non vitae urna.Vestibulum semper fermentum orci eu pretium. Aliquam auctor neque eu lacus commodo, ut interdum risus porttitor.'

    };

    export class SubmitController {
        public message = 'Hello from the submit page!';


    }
    export class TopController {
        public message = "Hello from the Top 10 Recipes page!";

        public recipes;

        constructor($http: ng.IHttpService) {
            $http.get('/api/recipes').then((results) => {
                this.recipes = results.data;
                console.log(results.data);
            });

        }
    }
}

