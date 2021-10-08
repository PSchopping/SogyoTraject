using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectReact.Controllers.models
{
    public class RecipesOverview
    {
        public string receptName { get; set; }
        public int ID { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public string units { get; set; }
        

        public RecipesOverview(string receptnameIn, int IDIn, string nameIn, int quantityIn, string unitsIn)
        {
            receptName = receptnameIn;
            name = nameIn;
            quantity = quantityIn;
            units = unitsIn;
            ID = IDIn;
        }

        

      
    }
}
