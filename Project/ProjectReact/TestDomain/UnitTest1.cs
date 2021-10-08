using NUnit.Framework;
using ProjectReact.Domain.src;

namespace TestDomain
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CalculateAveragePrice()
        {
            DiscountChecker check = new DiscountChecker();
            check.AddIngredient("gebakken ei", "ei", 1, 12, "10", 1);
            check.AddIngredient("gumbo", "paprika", 1, 3, "20", 1);
            check.AddIngredient("gumbo", "selderij", 1, 3, "20", 1);
            check.AddIngredient("gumbo", "ui", 1, 3, "20", 1);
            check.AddIngredient("gumbo", "worst", 1, 3, "20", 1);
            var result =check.CalculateDiscount();
            Assert.AreEqual("gumbo", result[1].RecipeName);
            Assert.AreEqual(20, result[1].AveragePriceOff);
        }

        [Test]
        public void Count()
        {
            DiscountChecker check = new DiscountChecker();
            check.AddIngredient("gebakken ei", "ei", 1, 12, "10",1);
            check.AddIngredient("gumbo", "paprika", 1, 3, "20",1);
            check.AddIngredient("gumbo", "selderij", 1, 3, "20",1);
            check.AddIngredient("gumbo", "ui", 1, 3, "20",1);
            check.AddIngredient("gumbo", "worst", 1, 3, "20",1);
            var result = check.CheckDiscount();
            Assert.AreEqual(4, result[1].NumberDiscount);
            Assert.AreEqual(1, result[0].NumberDiscount);
        }

        [Test]
        public void PercentageRecipes()
        {
            DiscountChecker check = new DiscountChecker();
            check.AddRecipes("gumbo","paprika", 1, 2);
            check.AddRecipes("gumbo","worst", 1, 0);
            var result = check.PercentagesIngriedents();
            Assert.AreEqual(50.0, result[0].Percentage);
            Assert.AreEqual(2, result[0].Total);
          
        }



        [Test]
        public void PercentageRecipesZero()
        {
            DiscountChecker check = new DiscountChecker();
            check.AddRecipes("gumbo", "paprika", 1, 1);
            check.AddRecipes("gumbo", "worst", 1, 0);
            var result = check.PercentagesIngriedents();
            Assert.AreEqual(50.0, result[0].Percentage);
            Assert.AreEqual(2, result[0].Total);

        }

        
    }
}