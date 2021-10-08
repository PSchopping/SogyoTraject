using ProjectReact.Controllers.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectReact.Domain.src
{
    public class DiscountChecker
    {
        public List<string> ingredientName = new List<string>();
        public List<string> recipeName = new List<string>();
        public List<int> quantityRecipe = new List<int>();
        public List<int> quantityDiscount = new List<int>();
        public List<string> discount = new List<string>();
        public List<int> sortCount = new List<int>();
        public List<List<string>> avavailble = new List<List<string>>();


        public List<AverageDiscount> CalculateDiscount()
        {
            List<string> distinct = recipeName.Distinct().ToList();
            List<AverageDiscount> averageDiscount = new List<AverageDiscount>();
            int i = 0;
            foreach (string recipe in distinct)
            {
                
                int totalDiscount = 0;
                int numIngredients = 0;
                int discountIngredients = 0;

                for (int j=0; j < recipeName.Count(); j++)
                {
                    if (recipeName[j] == recipe)
                    {
                        int percentage = int.Parse(discount[j].Trim('%'));
                        int count = sortCount[j];
                        int quantity = quantityDiscount[j] * count;
                        totalDiscount += percentage * quantity;
                        numIngredients += quantity;
                        if (quantity > 0)
                        {
                            discountIngredients = discountIngredients + 1;
                        }
                    }
                }
                int averagePriceOff = 0;
                if (totalDiscount ==0 | numIngredients == 0)
                {

                }
                else
                {
                    averagePriceOff = (totalDiscount / numIngredients);
                }
                averageDiscount.Add(new AverageDiscount { RecipeName = recipe, AveragePriceOff = averagePriceOff , NumberDiscount = discountIngredients});
                
               i++;
                
            }
            return averageDiscount;
        }

        public List<AverageDiscount> CheckDiscount()
        {
            List<string> distinct = recipeName.Distinct().ToList();
            List<string> ingredientNameChecked = new List<string>();
            List<AverageDiscount> averageDiscount = new List<AverageDiscount>();
            int i = 0;
            foreach (string recipe in distinct)
            {

                int discountIngredients = 0;

                for (int j = 0; j < recipeName.Count(); j++)
                {
                    if (recipeName[j] == recipe)
                    {
                        int count = sortCount[j];
                        int quantity = quantityDiscount[j] * count;
                        if (quantity > 0)
                        {
                            discountIngredients = discountIngredients + 1;
                        }
                        
                    }
                    
                }
                averageDiscount.Add(new AverageDiscount { RecipeName = recipe, NumberDiscount = discountIngredients });

                i++;

            }
            return averageDiscount;
        }

        public List<TotalIngredients> PercentagesIngriedents()
        {
            List<string> distinct = recipeName.Distinct().ToList();
            
            List<TotalIngredients> totalIngredients = new List<TotalIngredients>();
            int i = 0;
            foreach (string recipe in distinct)
            {
                List<string> ingredientNameChecked = new List<string>();
                double discountIngredients = 0;
                double recipeIngredients = 0;
                for (int j = 0; j < recipeName.Count(); j++)
                {

                    if (recipeName[j] == recipe && (j<1 || !ingredientNameChecked.Contains(ingredientName[j])))
                    {
                        if (quantityDiscount[j] > 0)
                        {
                            discountIngredients = discountIngredients + 1;
                        }
                        if (quantityRecipe[j] > 0)
                        {
                            recipeIngredients = recipeIngredients + 1;
                        }
                        ingredientNameChecked.Add(ingredientName[j]);
                    }

                }
                double percentage;
                if (discountIngredients ==0 | recipeIngredients == 0)
                {
                        percentage = 0;
                } else
                {
                     percentage = (discountIngredients / recipeIngredients)*100;
                }
                
                if(Double.IsNaN(percentage))
                {
                    percentage = 0;
                }
                totalIngredients.Add(new TotalIngredients { RecipeName = recipe, Total = recipeIngredients, Percentage = percentage });

                i++;

            }
            return totalIngredients;
        }


        //Beter twee DTO maken??

        public void AddIngredient(string recipeNameIn, string ingredientNameIn,int quantityRecipeIn, int quantityDiscountIn, string discountIn, int countIn)
        {
            ingredientName.Add(ingredientNameIn);
            quantityDiscount.Add(quantityDiscountIn);
            quantityRecipe.Add(quantityRecipeIn);
            recipeName.Add(recipeNameIn);
            discount.Add(discountIn);
            sortCount.Add(countIn);
            
        }

        public void AddRecipes(string recipeNameIn, string ingredientNameIn, int quantityRecipeIn, int quantityDiscountIn)
        {
            recipeName.Add(recipeNameIn);
            quantityRecipe.Add(quantityRecipeIn);
            quantityDiscount.Add(quantityDiscountIn);
            ingredientName.Add(ingredientNameIn);
        }

        
    }
}
