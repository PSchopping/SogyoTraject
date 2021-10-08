using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ProjectReact.Controllers;
using ProjectReact.Controllers.models;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            // Arrange
            
            var controller = new ValuesController();
            var data = new Data();
            data.Inr = -1;
            var result = controller.Create(data);
            var okResult = (CreatedAtActionResult)result;
            


            // message = okObjectResult.ToString();
            Assert.AreEqual("wrong!" , okResult.Value);
        }

        [Test]
        public void IngredientSubmitSendsIngredient()
        {
            var controller = new IngredientSubmitController();
            string[] ingr = { "ei" };
            string[] uni = { "" };
            int[] qua = { 1 };
            var ingredient = new Recipes();
            ingredient.setIngredients("gebakken ei", ingr, qua, uni);
            var result = controller.SubmitIngredients(ingredient);
            var okResult = (CreatedAtActionResult)result;
            Assert.AreEqual("Ingredienten van gebakken ei is toegevoegd", okResult.Value);

        }

        [Test]
        public void IngredientDeleteRemovesIngredient()
        {
            var controller = new IngredientSubmitController();
            string[] ingr = { "ei" };
            string[] uni = { "" };
            int[] qua = { 1 };
            var ingredient = new Recipes();
            ingredient.setIngredients("gebakken ei", ingr, qua, uni);
            var result = controller.SubmitIngredients(ingredient);
            var okResult = (CreatedAtActionResult)result;
            Assert.AreEqual("Ingredienten van gebakken ei is toegevoegd", okResult.Value);
            var controller2 = new RecipeSearchController();
            var result2 = controller2.GetOverviewRecipes();
            var remove = new Remover();
            remove.ingredientID = result2[result2.Count - 1].ID;
            remove.name = result2[result2.Count - 1].name;
            remove.quantity = result2[result2.Count - 1].quantity;
            remove.receptName = result2[result2.Count - 1].receptName;
            remove.unit = result2[result2.Count - 1].units;
            var result3  = controller.DeleteIngredients(remove);
            var okResult2 = (CreatedAtActionResult)result3;
            Assert.AreEqual("Ingredient ei van gebakken ei is verwijderd", okResult2.Value);

        }

        [Test]
        public void IngredientsCanBeExtractedFromDatabase()
        {
            var controller = new IngredientSubmitController();
            string[] ingr = { "ei" };
            string[] uni = { "" };
            int[] qua = { 1 };
            var ingredient = new Recipes();
            ingredient.setIngredients("gebakken ei", ingr, qua, uni);
            controller.SubmitIngredients(ingredient);
            var result = controller.GetIngredients() ;
            
            Assert.AreEqual("ei", result[result.Count - 1].name);
            Assert.AreEqual("", result[result.Count - 1].units);
            Assert.AreEqual(1, result[result.Count - 1].quantity);
            
        }

        [Test]
        public void DiscountSubmitSendsIngredient()
        {
            var controller = new DiscountSubmitController();
            var products = new Products();
            products.setDiscount("aldi", "ei", 1, "","25%");
            var result = controller.SubmitDiscount(products);
            var okResult = (CreatedAtActionResult)result;
            Assert.AreEqual(" is toegevoegd van de aldi", okResult.Value);

        }

        [Test]
        public void GetRecipesWithDiscount()
        {
            var controller2 = new IngredientSubmitController();
            string[] ingr = { "aardappelen" };
            string[] uni = { "kilo" };
            int[] qua = { 1 };
            var ingredient = new Recipes();
            ingredient.setIngredients("gebakken ei", ingr, qua, uni);
            controller2.SubmitIngredients(ingredient);
            var controller3 = new DiscountSubmitController();
            var products = new Products();
            products.setDiscount("aldi", "aardappelen", 1, "kilo", "25%");
            controller3.SubmitDiscount(products);
            var controller = new RecipeSearchController();
            var result = controller.GetRecipes();
            Assert.AreEqual("aldi", result[result.Count - 1].shopName);
            Assert.AreEqual("aardappelen", result[result.Count - 1].name);
            Assert.AreEqual("25%", result[result.Count - 1].discount);
            Assert.AreEqual(1, result[result.Count - 1].toBuy);

        }

        [Test]
        public void GetRecipesWithDiscountName()
        {
            var controller2 = new IngredientSubmitController();
            string[] ingr = { "aardappelen" };
            string[] uni = { "kilo" };
            int[] qua = { 1 };
            var ingredient = new Recipes();
            ingredient.setIngredients("gebakken ei", ingr, qua, uni);
            controller2.SubmitIngredients(ingredient);
            var controller3 = new DiscountSubmitController();
            var products = new Products();
            products.setDiscount("aldi", "aardappelen", 1, "kilo", "25%");
            controller3.SubmitDiscount(products);
            var controller = new RecipeSearchController();
            var result = controller.GetRecipes("gebakken ei");
            Assert.AreEqual("aldi", result[result.Count - 1].shopName);
            Assert.AreEqual("aardappelen", result[result.Count - 1].name);
            Assert.AreEqual("25%", result[result.Count - 1].discount);
            Assert.AreEqual(1, result[result.Count - 1].toBuy);

        }

        [Test]
        public void GetRecipesOverviewWithName()
        {
            var controller2 = new IngredientSubmitController();
            string[] ingr = { "aardappelen" };
            string[] uni = { "kilo" };
            int[] qua = { 1 };
            var ingredient = new Recipes();
            ingredient.setIngredients("gebakken ei", ingr, qua, uni);
            controller2.SubmitIngredients(ingredient);
            var controller = new RecipeSearchController();
            var result = controller.GetOverviewRecipes("gebakken ei");
            Assert.AreEqual("aardappelen", result[result.Count - 1].name);
           

        }

        [Test]
        public void GetPercentagesofInhouseProducts()
        {
            var controller2 = new IngredientSubmitController();
            string[] ingr = { "aardappelen" };
            string[] uni = { "kilo" };
            int[] qua = { 1 };
            var ingredient = new Recipes();
            ingredient.setIngredients("gebakken ei", ingr, qua, uni);
            controller2.SubmitIngredients(ingredient);
            var controller3 = new DiscountSubmitController();
            var products = new Products();
            products.setDiscount("aldi", "aardappelen", 1, "kilo", "25%");
            controller3.SubmitDiscount(products);
            var controller = new RecipeSearchController();
            var result = controller.GetPercentageIngredientsInhouse();
            Assert.AreEqual(100, result[result.Count - 1].Percentage);

        }
        
        [OneTimeTearDown]
        public void CleanUpDatabaseAfterTests()
        {
            var controller = new IngredientSubmitController();
            var controller2 = new RecipeSearchController();
            var result2 = controller2.GetOverviewRecipes();
            var remove = new Remover();
            var x = 1;
            for (int i = 0; i < 9; i++)
            {
                x = x + i;
                remove.ingredientID = result2[result2.Count - x].ID;
                remove.name = result2[result2.Count - x].name;
                remove.quantity = result2[result2.Count - x].quantity;
                remove.receptName = result2[result2.Count - x].receptName;
                remove.unit = result2[result2.Count - x].units;
                var result3 = controller.DeleteIngredients(remove);
                var okResult2 = (CreatedAtActionResult)result3;
                Assert.AreEqual("Ingredient ei van gebakken ei is verwijderd", okResult2.Value);
            }
        
        }



    }
}