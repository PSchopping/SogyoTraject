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
    public class InhouseSubmitController : ControllerBase
    {

        [HttpPost]
        [Route("[action]")]
        public IActionResult SubmitIngredients([FromBody] InhouseProducts inhouse)
        {
            string cs = @"server=127.0.0.1;userid=root;password=AwE2020!?;database=boodschappen";
            using var con = new MySqlConnection(cs);
            
            for (int i = 0; i < inhouse.name.Length; i++)
            {
                if (inhouse.name[i] == "")
                {
                    continue;
                }
                else
                {

                    con.Open();
                    string query = "INSERT INTO INHOUSE(name, quantity, unit) VALUES(@name,@quantity,@unit)";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", inhouse.name[i]);
                    cmd.Parameters.AddWithValue("@quantity", inhouse.quantity[i]);
                    cmd.Parameters.AddWithValue("@unit", inhouse.units[i]);
                    cmd.Prepare();
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    con.Close();
                }
            }
            

            return CreatedAtAction(nameof(SubmitIngredients), inhouse.name.Length +  " ingredienten zijn toegevoegd" );
        }

        

        [HttpGet]
        [Route("[action]")]
        public List<Ingredients> GetIngredients()
        {
            string cs = @"server=127.0.0.1;userid=root;password=AwE2020!?;database=boodschappen";
            using var con = new MySqlConnection(cs);
            con.Open();
            string query = "SELECT * FROM boodschappen.recepten";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Prepare();
            MySqlDataReader rdr = cmd.ExecuteReader();
            Ingredients ingredients = new Ingredients();
            List<Ingredients> ingredientsL = new List<Ingredients>();
            while (rdr.Read())
            {
                /*ingredients.name = rdr["name"].ToString();
                ingredients.units = rdr["unit"].ToString();
                ingredients.quantity = (int) rdr["quantity"];*/
                ingredientsL.Add(new Ingredients(rdr["receptName"].ToString(),rdr["name"].ToString(), (int)rdr["quantity"], rdr["unit"].ToString()));
            }
            return ingredientsL;
        }

      }
}
