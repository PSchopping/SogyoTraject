using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectReact.Controllers.models
{
    public class Products
    {
        public string shopName { get; set; }
        public string [] name { get; set; }
        public int [] quantity { get; set; }
        public string [] units { get; set; }
        public string [] discount { get; set; }


        public void setDiscount(string shopNameIn,string [] nameIn, int [] quantityIn, string [] unitsIn, string [] discountIn)
        {
            name = nameIn;
            quantity = quantityIn;
            units = unitsIn;
            discount = discountIn;
            shopName = shopNameIn;
        }

        public void setDiscount(string shopNameIn, string nameIn, int quantityIn, string unitsIn, string discountIn)
        {
            name = new string[1];
            name[0]=nameIn;
            quantity = new int[1];
            quantity[0] = quantityIn;
            units = new string[1];
            units[0] = unitsIn;
            discount = new string[1];
            discount[0] = discountIn;
            shopName = shopNameIn;
        }


    }
}
