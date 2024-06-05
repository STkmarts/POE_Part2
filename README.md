# POE_Part2
# Recipe Management System

## Overview
The Recipe Management System is a console application written in C# that allows users to manage recipes. Users can add, display, scale, and delete recipes. Each recipe consists of a list of ingredients and a series of steps. The application also includes functionality to scale the ingredients of a recipe by a factor (half, double, or triple) and reset to the original quantities.

## Features
- **Add a new recipe**: Users can enter a recipe name, a list of ingredients, and a series of steps.
- **Display a recipe**: Users can view a recipe from the list of added recipes.
- **Scale a recipe**: Users can scale the ingredients of a recipe by a factor of 0.5, 2, or 3.
- **Delete a recipe**: Users can delete a recipe from the list.
- **Sort recipes**: Recipes are displayed in alphabetical order.
- **Calorie check**: The system calculates the total calories of a recipe and warns the user if it exceeds 300 calories.

## Classes and Methods

### Ingredient Class
Represents an ingredient in a recipe.
- **Properties**:
  - `Name`: The name of the ingredient.
  - `Quantity`: The quantity of the ingredient.
  - `UnitMes`: The unit of measurement for the quantity.
  - `Calories`: The number of calories in the ingredient.
  - `FoodGroup`: The food group to which the ingredient belongs.

### Recipe Class
Represents a recipe consisting of ingredients and steps.
- **Properties**:
  - `Name`: The name of the recipe.
  - `Ingredients`: A list of ingredients in the recipe.
  - `Steps`: A list of steps to prepare the recipe.
- **Methods**:
  - `AddIngredient(string name, double quantity, string unitOfMeas, int calories, string foodGroup)`: Adds an ingredient to the recipe.
  - `CalculateTotalCalories()`: Calculates the total calories of the recipe.
  - `DisplayRecipe()`: Displays the recipe details.
  - `ScaleRecipe(double scale)`: Scales the quantities of the ingredients by a given factor.
  - `ResetRecipe()`: Resets the ingredients to their original quantities.

### Program Class
Contains the main program logic and user interface.
- **Methods**:
  - `Main(string[] args)`: Displays the main menu and handles user input.
  - `AddRecipe()`: Prompts the user to enter details of a new recipe and adds it to the list.
  - `DisplayRecipes()`: Displays the list of recipes in alphabetical order and allows the user to view a specific recipe.
  - `ScaleRecipe()`: Allows the user to scale a recipe by a given factor.
  - `DeleteRecipe()`: Allows the user to delete a recipe from the list.

### Delegates
- `CalorieCheckDelegate(int calories)`: Delegate for checking total calories.

## How to Use
1. **Run the application**: Launch the application from the console.
2. **Main Menu Options**:
   - Enter `1` to add a new recipe.
   - Enter `2` to display a recipe.
   - Enter `3` to scale a recipe.
   - Enter `4` to delete a recipe.
   - Enter `5` to exit the application.

3. **Adding a Recipe**:
   - Follow the prompts to enter the recipe name, number of ingredients, details of each ingredient, and steps.
   - Select the food group for each ingredient using the provided options.

4. **Displaying Recipes**:
   - View the list of recipes sorted alphabetically.
   - Enter the number corresponding to the recipe you want to display.

5. **Scaling a Recipe**:
   - Choose the recipe you want to scale.
   - Enter the scale factor (0.5, 2, or 3).
   - The application will display the scaled recipe and then reset it to the original quantities.

6. **Deleting a Recipe**:
   - Choose the recipe you want to delete from the list.

## Example
```plaintext
Main Menu:
1. Enter a new recipe
2. Display a recipe
3. Scale a recipe
4. Delete a recipe
5. Exit
Select an option: 1

Enter the recipe name: Pancakes
How many ingredients are in the recipe? 3
Ingredient 1:
Name: Flour
Quantity: 2
Unit of Measurement: cups
Calories: 200
Select a food group:
1. Starchy food
2. Vegetables and fruits
3. Dry beans, peas, lentils, and soya
4. Chicken, fish, meat, and eggs
5. Milk and dairy products
6. Fats and oil
7. Water
Insert a value: 1
...
```

## Conclusion
This Recipe Management System is a simple yet functional console application that provides basic functionalities to manage recipes, including adding, displaying, scaling, and deleting recipes. The system ensures user-friendly interaction with clear prompts and warnings.
