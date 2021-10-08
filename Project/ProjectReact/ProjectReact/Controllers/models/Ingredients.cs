using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectReact.Controllers.models
{
    public class Ingredients
    {
        public string receptName { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public string units { get; set; }


        public Ingredients(string receptNameIn,string nameIn, int quantityIn, string unitsIn)
        {
            name = nameIn;
            quantity = quantityIn;
            units = unitsIn;
            receptName = receptNameIn;
        }

        public Ingredients()
        {
   
        }
    }
}
