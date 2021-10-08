using ProjectReact.Controllers.models;

namespace ProjectReact.Controllers
{
    public class DiscountRecipes
    {
        public string receptName { get; set; }
        public string shopName { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public string units { get; set; }
        public string discount { get; set; }
        public int toBuy { get; set; }

        public DiscountRecipes(string receptNameIn, string shopNameIn, string nameIn , int quantityIn, string unitsIn, string discountIn, int countIn)
        {
            name = nameIn;
            quantity = quantityIn;
            units = unitsIn;
            receptName = receptNameIn;
            shopName = shopNameIn;
            discount = discountIn;
            toBuy = countIn;
         
        }

       
    }
}