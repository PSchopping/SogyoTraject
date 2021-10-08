using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectReact.Controllers.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;



namespace ProjectReact.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DiscountSubmitController : ControllerBase
    {

        [HttpPost]
        [Route("[action]")]
        public IActionResult SubmitDiscount([FromBody] Products products)
        {
            string cs = @"server=127.0.0.1;userid=root;password=AwE2020!?;database=boodschappen";
            using var con = new MySqlConnection(cs);

            for (int i = 0; i < products.name.Length; i++)
            {
                if (products.name[i] == "")
                {
                    continue;
                }
                else
                {
                    con.Open();
                    string query = "INSERT INTO Aanbiedingen(winkel, name, quantity, unit, korting) VALUES(@winkel,@name,@quantity,@unit,@korting)";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@winkel", products.shopName);
                    cmd.Parameters.AddWithValue("@name", products.name[i]);
                    cmd.Parameters.AddWithValue("@quantity", products.quantity[i]);
                    cmd.Parameters.AddWithValue("@unit", products.units[i]);
                    cmd.Parameters.AddWithValue("@korting", products.discount[i]);
                    cmd.Prepare();
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    con.Close();
                }
            }

            return CreatedAtAction(nameof(SubmitDiscount), " is toegevoegd van de "+products.shopName );
        }

        

        [HttpGet]
        [Route("[action]")]
        public List<Products> GetDiscount()
        {
            string cs = @"server=127.0.0.1;userid=root;password=AwE2020!?;database=boodschappen";
            using var con = new MySqlConnection(cs);
            con.Open();
            string query = "SELECT * FROM boodschappen.aanbiedingen";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Prepare();
            MySqlDataReader rdr = cmd.ExecuteReader();          
            List<Products> products = new List<Products>();
            while (rdr.Read())
            {
                /*ingredients.name = rdr["name"].ToString();
                ingredients.units = rdr["unit"].ToString();
                ingredients.quantity = (int) rdr["quantity"];*/
                products.Add(new Products());
                products[products.Count-1].setDiscount(rdr["shopName"].ToString(),rdr["name"].ToString(), (int)rdr["quantity"], rdr["unit"].ToString(),rdr["korting"].ToString());
            }
            con.Close();
            return products;
        }

      }
}
