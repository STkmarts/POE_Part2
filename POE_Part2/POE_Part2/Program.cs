using System;
using System.Collections.Generic;

namespace POE_part_2
{
    public class Ingredient
    {//revieves and sets the values
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string UnitMes { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }
    }

    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Steps { get; set; }

        private List<Ingredient> originalIngredients;

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
        }

        public void AddIngredient(string name, double quantity, string unitOfMeas, int calories, string foodGroup)
        {//passes and adds the values entered to the variables and adds them to a list
            Ingredients.Add(new Ingredient
            {
                Name = name,
                Quantity = quantity,
                UnitMes = unitOfMeas,
                Calories = calories,
                FoodGroup = foodGroup
            });

            // Store the original ingredient quantities
            originalIngredients = new List<Ingredient>(Ingredients);
        }

        public int CalculateTotalCalories()//calorie calculation
        {
            int totalCalories = 0;
            foreach (var ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories;
            }
            return totalCalories;
        }

        public void DisplayRecipe()//displays the recipe
        {
            Console.WriteLine($"Recipe: {Name}");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"{ingredient.Name}: {ingredient.Quantity} {ingredient.UnitMes} ({ingredient.FoodGroup})");
            }
            Console.WriteLine("Steps:");
            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i]}");
            }
            int totalCalories = CalculateTotalCalories();
            Console.WriteLine($"Total Calories: {totalCalories}");
            if (totalCalories > 300)
            {
                Console.WriteLine("Warning: This recipe exceeds 300 calories!");
            }
        }

        public void ScaleRecipe(double scale) //scale calculation
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= scale;
            }
        }

        public void ResetRecipe()
        {
            Ingredients = new List<Ingredient>(originalIngredients);
        }
    }

    public class Program
    {
        static List<Recipe> recipes = new List<Recipe>();

        public delegate void CalorieCheckDelegate(int calories);//delegate

        public static void Main(string[] args)
        {//displays a list to choose from with regard to the recipes
            while (true)
            {
                Console.WriteLine("Main Menu:");
                Console.WriteLine("1. Enter a new recipe");
                Console.WriteLine("2. Display a recipe");
                Console.WriteLine("3. Scale a recipe");
                Console.WriteLine("4. Delete a recipe");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddRecipe();
                        break;
                    case 2:
                        DisplayRecipes();
                        break;
                    case 3:
                        ScaleRecipe();
                        break;
                    case 4:
                        DeleteRecipe();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddRecipe()
        {//adds a recipe to the program
            Recipe recipe = new Recipe();

            Console.Write("Enter the recipe name: ");
            recipe.Name = Console.ReadLine();

            Console.Write("How many ingredients are in the recipe? ");
            int numIngredients = int.Parse(Console.ReadLine());

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Ingredient {i + 1}:");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Quantity: ");
                double quantity = double.Parse(Console.ReadLine());
                Console.Write("Unit of Measurement: ");
                string unitOfMeas = Console.ReadLine();
                Console.Write("Calories: ");
                int calories = int.Parse(Console.ReadLine());
                Console.WriteLine("Select a food group: ");
                Console.WriteLine("1. Starchy food");
                Console.WriteLine("2. Vegetables and fruits");
                Console.WriteLine("3. Dry beans, peas, lentils, and soya");
                Console.WriteLine("4. Chicken, fish, meat, and eggs");
                Console.WriteLine("5. Milk and dairy products");
                Console.WriteLine("6. Fats and oil");
                Console.WriteLine("7. Water");
                Console.Write("Insert a value: ");
                int foodGroupOption = int.Parse(Console.ReadLine());
                string foodGroup = foodGroupOption switch
                {
                    1 => "Starchy food",
                    2 => "Vegetables and fruits",
                    3 => "Dry beans, peas, lentils, and soya",
                    4 => "Chicken, fish, meat, and eggs",
                    5 => "Milk and dairy products",
                    6 => "Fats and oil",
                    7 => "Water",
                    _ => "Unknown"
                };

                recipe.AddIngredient(name, quantity, unitOfMeas, calories, foodGroup);
            }

            Console.Write("How many steps are in the recipe? ");
            int numSteps = int.Parse(Console.ReadLine());
            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Step {i + 1}: ");
                recipe.Steps.Add(Console.ReadLine());
            }

            recipes.Add(recipe);

            Console.WriteLine("Recipe added successfully.");
        }

        static void DisplayRecipes()
        {//displayes the recipe
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes available to display.");
                return;
            }

            recipes.Sort((x, y) => string.Compare(x.Name, y.Name));

            Console.WriteLine("Recipes:");
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipes[i].Name}");
            }
            Console.Write("Enter the number of the recipe you would like to display: ");
            int recipeNumber = int.Parse(Console.ReadLine());
            if (recipeNumber > 0 && recipeNumber <= recipes.Count)
            {
                recipes[recipeNumber - 1].DisplayRecipe();
            }
            else
            {
                Console.WriteLine("Invalid recipe number.");
            }
        }

        static void ScaleRecipe()
        {//scales the recipe
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes available to scale.");
                return;
            }

            Console.WriteLine("Recipes:");
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipes[i].Name}");
            }
            Console.Write("Enter the number of the recipe you would like to scale: ");
            int recipeNumber = int.Parse(Console.ReadLine());
            if (recipeNumber > 0 && recipeNumber <= recipes.Count)
            {
                Console.WriteLine("Select an option of how you would like to scale the recipe");
                Console.WriteLine("Options: 0.5 (half), 2 (double), and 3 (triple)");
                Console.Write("Insert a value: ");
                double scaleValue = double.Parse(Console.ReadLine());

                if (scaleValue == 0.5 || scaleValue == 2 || scaleValue == 3)
                {
                    recipes[recipeNumber - 1].ScaleRecipe(scaleValue);
                    Console.WriteLine("Recipe scaled successfully.");
                    recipes[recipeNumber - 1].DisplayRecipe();
                    recipes[recipeNumber - 1].ResetRecipe();
                }
                else
                {
                    Console.WriteLine("Invalid scale value.");
                }
            }
            else
            {
                Console.WriteLine("Invalid recipe number.");
            }
        }

        static void DeleteRecipe()
        {//deletes the recipe
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes available to delete.");
                return;
            }

            Console.WriteLine("Recipes:");
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipes[i].Name}");
            }
            Console.Write("Enter the number of the recipe you would like to delete: ");
            int recipeNumber = int.Parse(Console.ReadLine());
            if (recipeNumber > 0 && recipeNumber <= recipes.Count)
            {
                recipes.RemoveAt(recipeNumber - 1);
                Console.WriteLine("Recipe deleted successfully.");
            }
            else
            {
                Console.WriteLine("Invalid recipe number.");
            }
        }
    }
}
