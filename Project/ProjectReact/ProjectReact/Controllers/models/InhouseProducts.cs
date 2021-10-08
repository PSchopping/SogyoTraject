using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectReact.Controllers.models
{
    public class InhouseProducts
    {
        
        public string [] name { get; set; }
        public int [] quantity { get; set; }
        public string []units { get; set; }
        

        public void setIngredients(string[] nameIn, int[] quantityIn, string[] unitsIn)
        {
            
            name = nameIn;
            quantity = quantityIn;
            units = unitsIn;
        }

        

      
    }
}
