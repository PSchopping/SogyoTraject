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
    public class IngredientSubmitController : ControllerBase
    {

        [HttpPost]
        [Route("[action]")]
        public IActionResult SubmitIngredients([FromBody] Recipes recipes)
        {
            string cs = @"server=127.0.0.1;userid=root;password=AwE2020!?;database=boodschappen";
            using var con = new MySqlConnection(cs);
            
            for (int i = 0; i < recipes.name.Length; i++)
            {
                if (recipes.name[i] == "")
                {
                    continue;
                }
                else
                {

                    con.Open();
                    string query = "INSERT INTO Recepten(receptName ,name, quantity, unit) VALUES(@receptName,@name,@quantity,@unit)";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@receptName", recipes.receptName);
                    cmd.Parameters.AddWithValue("@name", recipes.name[i]);
                    cmd.Parameters.AddWithValue("@quantity", recipes.quantity[i]);
                    cmd.Parameters.AddWithValue("@unit", recipes.units[i]);
                    cmd.Prepare();
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    con.Close();
                }
            }
            

            return CreatedAtAction(nameof(SubmitIngredients), "Ingredienten van "+recipes.receptName+" is toegevoegd" );
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult DeleteIngredients([FromBody] Remover remove)
        {
            string cs = @"server=127.0.0.1;userid=root;password=AwE2020!?;database=boodschappen";
            using var con = new MySqlConnection(cs);

                    con.Open();
                    string query = "DELETE FROM recepten WHERE ingredientID = @ingredientID";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@ingredientID", remove.ingredientID);
                    cmd.Prepare();
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    con.Close();


            return CreatedAtAction(nameof(DeleteIngredients), "Ingredient " + remove.name + " van " + remove.receptName + " is verwijderd");
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
