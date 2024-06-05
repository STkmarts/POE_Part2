using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using POE_part_2;
using static System.Formats.Asn1.AsnWriter;

namespace POE_part_2
{
    public class Ingrediants
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string UnitMes { get; set; }
        public int calories { get; set; }
        public string foodgroup { get; set; }
    }
    public class Recipe
    {
        public List<string> steps { get; set; }
        //public List<string> name = new List<string>();
        //public List<string> UoM = new List<string>();
        // public List<int> Quantity = new List<int>();
        public List<Ingrediants> Ingrediants { get; set; }
        //public List<int> calories = new List<int>();
        //public List<string> foodgroup = new List<string>();
        public SortedList<int, string> recname = new SortedList<int, string>();
        int counter = 1;
        double incder;

        public Recipe()
        {
            Ingrediants = new List<Ingrediants>();
            steps = new List<string>();
            recname = new SortedList<int, string>();

        }
        public void AddIngrediants(string name, double quantity, string unitOfMeas, int calories, string foodGroup)
        {
            Ingrediants.Add(new Ingrediants
            {
                Name = name,
                Quantity = quantity,
                UnitMes = unitOfMeas,
                calories = calories,
                foodgroup = foodGroup
            });

        }
        // calculated the calories
        public int CaloriesCalc()
        {

            int totalCalories = 0;
            foreach (var ingrediant in Ingrediants)
            {
                totalCalories += ingrediant.calories;
            }
            return totalCalories;
        }


        public void Display()
        {

            int counter = 1;
            Console.WriteLine("Recipes:");
            while (counter > 0)
            {
                foreach (var kvp in recname)
                {
                    counter++;
                    Console.WriteLine($"{kvp.Key}. {kvp.Value}");
                }
            }

            Console.WriteLine("Insert the value of the recipe you would like to display: ");

            int number = Convert.ToInt32(Console.ReadLine());

            //Checking the value
            if (number == null)
            {
                Console.WriteLine("The entered operator is invalid.Try Again.");
                Console.WriteLine("Recipes:");
                while (counter > 0)
                {
                    foreach (var kvp in recname)
                    {
                        counter++;
                        Console.WriteLine($"{kvp.Key}. {kvp.Value}");
                    }
                }

                Console.WriteLine("Insert the value of the recipe you would like to display: ");
                number = Convert.ToInt32(Console.ReadLine());
            }
            else if (number > counter)
            {
                Console.WriteLine("The entered operator is invalid.Try Again.");

                Console.WriteLine("Recipes:");
                while (counter > 0)
                {
                    foreach (var kvp in recname)
                    {
                        counter++;
                        Console.WriteLine($"{kvp.Key}. {kvp.Value}");
                    }
                }

                Console.WriteLine("Insert the value of the recipe you would like to display: ");
                number = Convert.ToInt32(Console.ReadLine());
            }

            //Displays the recipe that is selected
            while (number > 0)
            {

                Console.WriteLine("Recipe: ");
                foreach (var kvp in recname)
                {
                    counter++;
                    Console.Write($"{kvp.Value}");
                }
                Console.WriteLine("Ingredients:");
                foreach (var ingrediant in Ingrediants)
                {
                    Console.WriteLine($"{ingrediant.Name}: {ingrediant.Quantity} {ingrediant.UnitMes} :{ingrediant.foodgroup}");
                }
                Console.WriteLine("Steps:");
                int stepNumber = 1;
                foreach (var step in steps)
                {
                    Console.WriteLine($"{stepNumber}. {step}");
                    stepNumber++;
                }
                Console.WriteLine($"Total Calories: {CaloriesCalc()}");

                Console.WriteLine("Would you like to display another recipe? y/n >>");
                char displaymore = Convert.ToChar(Console.ReadLine());

                //the steps to follow depending on the users selection
                // reruns the above code to select a recipe to show
                if (displaymore == 'y')
                {
                    Console.WriteLine("Recipes:");
                    while (counter > 0)
                    {
                        foreach (var kvp in recname)
                        {
                            counter++;
                            Console.WriteLine($"{kvp.Key}. {kvp.Value}");
                        }
                    }

                    Console.WriteLine("Insert the value of the recipe you would like to display: ");

                    number = Convert.ToInt32(Console.ReadLine());
                    if (number == null)
                    {
                        Console.WriteLine("The entered operator is invalid.Try Again.");
                        Console.WriteLine("Recipes:");
                        while (counter > 0)
                        {
                            foreach (var kvp in recname)
                            {
                                counter++;
                                Console.WriteLine($"{kvp.Key}. {kvp.Value}");
                            }
                        }

                        Console.WriteLine("Insert the value of the recipe you would like to display: ");
                        number = Convert.ToInt32(Console.ReadLine());
                    }
                    else if (number > counter)
                    {
                        Console.WriteLine("The entered operator is invalid.Try Again.");
                        Console.WriteLine("The entered operator is invalid.Try Again.");
                        Console.WriteLine("Recipes:");
                        while (counter > 0)
                        {
                            foreach (var kvp in recname)
                            {
                                counter++;
                                Console.WriteLine($"{kvp.Key}. {kvp.Value}");
                            }
                        }

                        Console.WriteLine("Insert the value of the recipe you would like to display: ");
                        number = Convert.ToInt32(Console.ReadLine());
                    }


                    while (number > 0)
                    {

                        Console.WriteLine("Recipe: " + recname);
                        Console.WriteLine("Ingredients:");
                        foreach (var ingrediant in Ingrediants)
                        {
                            Console.WriteLine($"{ingrediant.Name}: {ingrediant.Quantity} {ingrediant.UnitMes} :{ingrediant.foodgroup}");
                        }
                        Console.WriteLine("Steps:");
                        stepNumber = 1;
                        foreach (var step in steps)
                        {
                            Console.WriteLine($"{stepNumber}. {step}");
                            stepNumber++;
                        }
                        Console.WriteLine($"Total Calories: {CaloriesCalc()}");

                        Console.WriteLine("Would you like to display another recipe? y/n >>");
                        displaymore = Convert.ToChar(Console.ReadLine());
                    }

                }

                else if (displaymore == 'n')
                {
                    return;
                }




            }
        }

        public void Scale()
        {

            int counter = 1;
            var i = 0;

            Console.WriteLine("Recipes:");
            while (counter > 0)
            {
                foreach (var kvp in recname)
                {
                    counter++;
                    Console.WriteLine($"{kvp.Key}. {kvp.Value}");
                }
            }
            Console.WriteLine("Which recipe would you like to scale>>");
            int scaleno = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("This is the original Recipe:");
            Console.WriteLine("Recipe: " + recname);
            Console.WriteLine("Ingredients:");
            foreach (var ingrediant in Ingrediants)
            {
                Console.WriteLine($"{ingrediant.Name}: {ingrediant.Quantity} {ingrediant.UnitMes} :{ingrediant.foodgroup}");
            }
            Console.WriteLine("Steps:");
            int stepNumber = 1;
            foreach (var step in steps)
            {
                Console.WriteLine($"{stepNumber}. {step}");
                stepNumber++;
            }
            Console.WriteLine($"Total Calories: {CaloriesCalc()}");

            Console.WriteLine("Select an option of how you would like to scale the recipe");
            Console.WriteLine("Options: 0,5(half), 2(double), and 3(triple) please insert the value:");


            try
            {
                var scaleVal = double.Parse(Console.ReadLine()); // stores the value inserted to process the code

                // Validate scaleVal
                if (scaleVal != 0.5 && scaleVal != 2 && scaleVal != 3)
                {
                    throw new ArgumentException("Invalid operator please try again with the indicated values.");
                }

                // performs the calculation
                foreach (var ingrediant in Ingrediants)
                {

                    if (scaleVal == 0.5)
                    {
                        incder = ingrediant.Quantity * 0.5;
                    }
                    else if (scaleVal == 2)
                    {
                        incder = ingrediant.Quantity * 2;
                    }
                    else if (scaleVal == 3)
                    {
                        incder = ingrediant.Quantity * 3;
                    }

                    Console.WriteLine("Ingredient " + (i + 1) + ": " + incder);
                }

                Console.WriteLine("This is the recipe scaled according to: " + scaleVal);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a numeric value (0.5, 2, or 3).");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }




            /*
            for (i = 0; i < Quantity.Count; i++)
            {
                if (incder >= 2)
                {
                    Console.WriteLine();
                }

            }
            */

        }

        public void Delete()
        {
            // Check if there are any recipes to delete
            if (recname.Count == 0)
            {
                Console.WriteLine("No recipes available to delete.");
                return;
            }

            Console.WriteLine("Recipes:");
            foreach (var kvp in recname)
            {
                Console.WriteLine($"{kvp.Key}. {kvp.Value}");
            }

            Console.WriteLine("Enter the number of the recipe you would like to delete: ");
            int deleteNumber = Convert.ToInt32(Console.ReadLine());

            if (recname.ContainsKey(deleteNumber))
            {
                string deletedRecipe = recname[deleteNumber];
                recname.Remove(deleteNumber);
                Console.WriteLine($"Recipe '{deletedRecipe}' has been deleted.");

                // Adjust the keys after deletion
                SortedList<int, string> tempRecname = new SortedList<int, string>();
                int newKey = 1;
                foreach (var kvp in recname)
                {
                    tempRecname.Add(newKey, kvp.Value);
                    newKey++;
                }
                recname = tempRecname;
            }
            else
            {
                Console.WriteLine("Invalid recipe number. Please try again.");
            }

            // Display remaining recipes and options
            if (recname.Count > 0)
            {
                Console.WriteLine("Remaining recipes:");
                foreach (var kvp in recname)
                {
                    Console.WriteLine($"{kvp.Key}. {kvp.Value}");
                }

                Console.WriteLine("Would you like to view another recipe or return to the main menu? (view/menu)");
                string choice = Console.ReadLine();

                if (choice.ToLower() == "view")
                {
                    Display();
                }
            }
            else
            {
                Console.WriteLine("No recipes left.");
            }
        }

    }

}

// Delegate to notify when a recipe exceeds 300 calories
public delegate void RecipeExceedsCaloriesHandler(SortedList<int, string> recipename, int totalCalories);

public class Program
{
    // List to store all recipes
    static List<Recipe> recipes = new List<Recipe>();

    // Event to be triggered when a recipe exceeds 300 calories
    public static event RecipeExceedsCaloriesHandler RecipeExceedsCalories;

    // Method to handle recipe exceeding 300 calories
    static void HandleRecipeExceedsCalories(SortedList<int, string> recipename, int totalCalories)
    {
        Recipe r = new Recipe();
        int counter = 1;
        foreach (var kvp in r.recname)
        {
            counter++;
            Console.WriteLine($"Warning: Recipe '{kvp.Value}' exceeds 300 calories. Total Calories:{totalCalories}");
        }
    }


    static void AddRecipes()
    {
        Recipe r = new Recipe();
        int recnum;
        int counter = 1;

        Console.WriteLine("How many recipes are you entering? ");
        recnum = Convert.ToInt32(Console.ReadLine());

        while (recnum > 0)
        {
            int numI;
            r.recname = new SortedList<int, string>();

            Console.WriteLine("Enter the recipe name>>");
            r.recname.Add(counter, Console.ReadLine());
            Console.WriteLine("How many ingrediants are in the recipe:");
            numI = Convert.ToInt32(Console.ReadLine());



            for (int i = 0; i < numI; i++)
            {

                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine("Ingrediant number: " + (i + 1));
                Console.WriteLine("Name >>");
                string name = Console.ReadLine();
                Console.WriteLine("Quantity>>");
                double quantity = double.Parse(Console.ReadLine());
                Console.WriteLine("Unit of Measurement>>");
                string unitOfMeas = Console.ReadLine();
                Console.WriteLine("Select a food group (1. Starchy food \n 2. Vegetables and fruits \n " +
                    "3. Dry beans, peas, lentils, and soya \n 4. Chicken, fish, meat, and eggs \n 5. Milk and dairy products" +
                    "6. Fats and oil \n 7. Water )" + "\nInsert a value>>");

                string foodgroup = "";
                int calories = 0;
                var enterednum = int.Parse(Console.ReadLine());
                switch (enterednum)
                {
                    case 1:
                        foodgroup = "Starchy food";
                        Console.WriteLine("Enter the calories for this ingrediant>>");
                        calories = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 2:
                        foodgroup = "Vegetables and fruits";
                        Console.WriteLine("Enter the calories for this ingrediant>>");
                        calories = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 3:
                        foodgroup = "Dry beans, peas, lentils, and soya";
                        Console.WriteLine("Enter the calories for this ingrediant>>");
                        calories = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 4:
                        foodgroup = "Chicken, fish, meat, and eggs";
                        Console.WriteLine("Enter the calories for this ingrediant>>");
                        calories = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 5:
                        foodgroup = "Milk and dairy products";
                        Console.WriteLine("Enter the calories for this ingrediant>>");
                        calories = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 6:
                        foodgroup = "Fats and oil";
                        Console.WriteLine("Enter the calories for this ingrediant>>");
                        calories = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 7:
                        foodgroup = "Water";
                        Console.WriteLine("Enter the calories for this ingrediant>>");
                        calories = Convert.ToInt32(Console.ReadLine());
                        break;

                }
                r.AddIngrediants(name, quantity, unitOfMeas, calories, foodgroup);
            }

            Console.WriteLine("-------------------------------------------------------------------------------------");
            Console.WriteLine("How many steps are there in the recipe:");
            int numS = int.Parse(Console.ReadLine());


            for (int s = 0; s < numS; s++)
            {
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine("Enter your " + (s + 1) + " step:");
                r.steps.Add(Console.ReadLine());
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine();
            }

            recipes.Add(r);
            if (r != null)
            {
                Console.WriteLine("All your recipes have been saved!");
            }
            else if (r == null)
            {
                Console.WriteLine("Enter a recipe there are no recipes stored");
            }

            // Check if total calories exceed 300
            int totalCalories = r.CaloriesCalc();
            if (totalCalories > 300 && RecipeExceedsCalories != null)
            {
                RecipeExceedsCalories(r.recname, totalCalories);
            }

        }
    }


    static void Main(string[] args)
    {
        Recipe r = new Recipe();
        RecipeExceedsCalories += HandleRecipeExceedsCalories;

        while (true)
        {
            Console.WriteLine("1. Enter the recipes");
            Console.WriteLine("2. Display the recipe");
            Console.WriteLine("3. Scale recipe");
            Console.WriteLine("4. Reset to the originial recipe");
            Console.WriteLine("5. Clear Recipe");
            Console.WriteLine("6. Exit Application");
            var listItem = int.Parse(Console.ReadLine());

            switch (listItem)
            {
                case (1):
                    AddRecipes();
                    break;
                case (2):
                    r.Display();
                    break;
                case (3):
                    r.Scale();
                    break;
                case (4):
                    r.Display();
                    break;
                case (5):
                    r.Delete();
                    break;
                case (6):
                    System.Environment.Exit(0);
                    break;
                default:
                    // default message in hte case of the wrong value being entered 
                    Console.WriteLine();
                    Console.WriteLine("Invalid selection please try again");
                    break;

            }

        }
    }

}



