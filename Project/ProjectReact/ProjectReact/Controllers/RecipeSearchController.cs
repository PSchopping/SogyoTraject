using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using ProjectReact.Controllers.models;
using ProjectReact.Domain.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectReact.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecipeSearchController : ControllerBase
    {

        [HttpGet]
        [Route("[action]")]
        public List<DiscountRecipes> GetRecipes()
        {
            string cs = @"server=127.0.0.1;userid=root;password=AwE2020!?;database=boodschappen";
            using var con = new MySqlConnection(cs);
            con.Open();
            string query = "SELECT Recepten.receptName ,Aanbiedingen.winkel, Recepten.name, Aanbiedingen.quantity, Aanbiedingen.unit, Aanbiedingen.korting,CEIL(Recepten.quantity/Aanbiedingen.quantity) as count FROM Recepten INNER JOIN Aanbiedingen ON Recepten.name = Aanbiedingen.name; ";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Prepare();
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<DiscountRecipes> products = new List<DiscountRecipes>();
            while (rdr.Read())
            {
               products.Add(new DiscountRecipes(rdr["receptName"].ToString(),rdr["winkel"].ToString(), rdr["name"].ToString(), (int)rdr["quantity"], rdr["unit"].ToString(), rdr["korting"].ToString(),(int)(long)rdr["count"]));
            }
            rdr.Close();
            cmd.Dispose();
            con.Close();
            return products;
        }

        [HttpGet]
        [Route("[action]")]
        public List<RecipesOverview> GetOverviewRecipes()
        {
            string cs = @"server=127.0.0.1;userid=root;password=AwE2020!?;database=boodschappen";
            using var con = new MySqlConnection(cs);
            con.Open();
            string query = "SELECT * FROM boodschappen.recepten;";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Prepare();
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<RecipesOverview> products = new List<RecipesOverview>();
            while (rdr.Read())
            {
                products.Add(new RecipesOverview(rdr["receptName"].ToString(), (int)rdr["ingredientID"], rdr["name"].ToString(), (int)rdr["quantity"], rdr["unit"].ToString()));
            }
            rdr.Close();
            cmd.Dispose();
            con.Close();
            return products;
        }

        [HttpGet]
        [Route("[action]/{recipeName}")]
        public List<RecipesOverview> GetOverviewRecipes(string recipeName)
        {
            string cs = @"server=127.0.0.1;userid=root;password=AwE2020!?;database=boodschappen";
            using var con = new MySqlConnection(cs);
            con.Open();
            string query = "SELECT * FROM boodschappen.recepten WHERE receptName = @receptName";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@receptName", recipeName);
            cmd.Prepare();
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<RecipesOverview> products = new List<RecipesOverview>();
            while (rdr.Read())
            {
                products.Add(new RecipesOverview(rdr["receptName"].ToString(), (int)rdr["ingredientID"], rdr["name"].ToString(), (int)rdr["quantity"], rdr["unit"].ToString()));
            }
            rdr.Close();
            cmd.Dispose();
            con.Close();
            return products;
        }


        [HttpGet]
        [Route("[action]/{recipeName}")]
        public List<DiscountRecipes> GetRecipes(string recipeName)
        {
            string cs = @"server=127.0.0.1;userid=root;password=AwE2020!?;database=boodschappen";
            using var con = new MySqlConnection(cs);
            con.Open();
            string query = "SELECT Recepten.receptName ,Aanbiedingen.winkel, Recepten.name, Aanbiedingen.quantity, Aanbiedingen.unit, Aanbiedingen.korting,CEIL(Recepten.quantity/Aanbiedingen.quantity) as count FROM Recepten INNER JOIN Aanbiedingen ON Recepten.name = Aanbiedingen.name WHERE receptName = @receptName; ";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@receptName", recipeName);
            cmd.Prepare();
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<DiscountRecipes> products = new List<DiscountRecipes>();
            while (rdr.Read())
            {
                products.Add(new DiscountRecipes(rdr["receptName"].ToString(), rdr["winkel"].ToString(), rdr["name"].ToString(), (int)rdr["quantity"], rdr["unit"].ToString(), rdr["korting"].ToString(), (int)(long)rdr["count"]));
            }
            rdr.Close();
            cmd.Dispose();
            con.Close();
            return products;
        }


        [HttpGet]
        [Route("[action]")]
        public List<AverageDiscount> GetAverageDiscount()
        {
            string cs = @"server=127.0.0.1;userid=root;password=AwE2020!?;database=boodschappen";
            using var con = new MySqlConnection(cs);
            con.Open();
            string query = "SELECT Recepten.receptName ,Aanbiedingen.winkel, Recepten.name,Recepten.quantity as Recquantity, Aanbiedingen.quantity, Aanbiedingen.unit, Aanbiedingen.korting,CEIL(Recepten.quantity/Aanbiedingen.quantity) as count FROM Recepten INNER JOIN Aanbiedingen ON Recepten.name = Aanbiedingen.name; ";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Prepare();
            MySqlDataReader rdr = cmd.ExecuteReader();
            DiscountChecker discountChecker = new DiscountChecker();
            while (rdr.Read())
            {
                discountChecker.AddIngredient(rdr["receptName"].ToString(), rdr["name"].ToString(), (int)rdr["Recquantity"], (int)rdr["quantity"], rdr["korting"].ToString(), (int)(long)rdr["count"]);
                
            };
            rdr.Close();
            cmd.Dispose();
            con.Close();
            
           
            
            return discountChecker.CalculateDiscount();
        }


        [HttpGet]
        [Route("[action]")]
        public List<AverageDiscount> CheckDiscounted()
        {
            string cs = @"server=127.0.0.1;userid=root;password=AwE2020!?;database=boodschappen";
            using var con = new MySqlConnection(cs);
            con.Open();
            string query = "SELECT Recepten.receptName ,Aanbiedingen.winkel, Recepten.name,Recepten.quantity as Recquantity, Aanbiedingen.quantity, Aanbiedingen.unit, Aanbiedingen.korting,CEIL(Recepten.quantity/Aanbiedingen.quantity) as count FROM Recepten INNER JOIN Aanbiedingen ON Recepten.name = Aanbiedingen.name; ";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Prepare();
            MySqlDataReader rdr = cmd.ExecuteReader();
            DiscountChecker discountChecker = new DiscountChecker();
            while (rdr.Read())
            {
                discountChecker.AddIngredient(rdr["receptName"].ToString(), rdr["name"].ToString(), (int)rdr["Recquantity"], (int)rdr["quantity"], rdr["korting"].ToString(), (int)(long)rdr["count"]);

            };
            rdr.Close();
            cmd.Dispose();
            con.Close();



            return discountChecker.CheckDiscount();
        }


        [HttpGet]
        [Route("[action]")]
        public List<TotalIngredients> GetPercentageIngredients()
        {
            string cs = @"server=127.0.0.1;userid=root;password=AwE2020!?;database=boodschappen";
            using var con = new MySqlConnection(cs);
            con.Open();
            string query = "SELECT Recepten.receptName ,Aanbiedingen.winkel, Recepten.name,Recepten.quantity as Recquantity, ifnull(Aanbiedingen.quantity,0) as quantity, Aanbiedingen.unit, Aanbiedingen.korting,CEIL(Recepten.quantity/Aanbiedingen.quantity) as count FROM Recepten LEFT JOIN Aanbiedingen ON Recepten.name = Aanbiedingen.name; ";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Prepare();
            MySqlDataReader rdr = cmd.ExecuteReader();
            DiscountChecker discountChecker = new DiscountChecker();
            while (rdr.Read())
            {
                var iets = rdr["quantity"];
                var deze = rdr["Recquantity"];
                if (Convert.IsDBNull(rdr["quantity"]))
                {
                    discountChecker.AddRecipes(rdr["receptName"].ToString(), rdr["name"].ToString(), (int)rdr["Recquantity"], 0);
                }
                else
                {
                    discountChecker.AddRecipes(rdr["receptName"].ToString(), rdr["name"].ToString(), (int)rdr["Recquantity"], (int)(long)rdr["quantity"]);
                }
            };
            rdr.Close();
            cmd.Dispose();
            con.Close();


            return discountChecker.PercentagesIngriedents();
        }

        [HttpGet]
        [Route("[action]")]
        public List<TotalIngredients> GetPercentageIngredientsInhouse()
        {
            string cs = @"server=127.0.0.1;userid=root;password=AwE2020!?;database=boodschappen";
            using var con = new MySqlConnection(cs);
            con.Open();
            string query = "SELECT Recepten.receptName, Recepten.name, recepten.quantity as Recquantity, recepten.unit as recunit,inhouse.quantity,inhouse.unit FROM recepten INNER JOIN Inhouse ON Recepten.name = Inhouse.name WHERE inhouse.quantity > recepten.quantity;";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Prepare();
            MySqlDataReader rdr = cmd.ExecuteReader();
            DiscountChecker discountChecker = new DiscountChecker();
            while (rdr.Read())
            {
                var iets = rdr["quantity"];
                var deze = rdr["Recquantity"];
                if (Convert.IsDBNull(rdr["quantity"]))
                {
                    discountChecker.AddRecipes(rdr["receptName"].ToString(), rdr["name"].ToString(), (int)rdr["Recquantity"], 0);
                }
                else
                {
                    discountChecker.AddRecipes(rdr["receptName"].ToString(), rdr["name"].ToString(), (int)rdr["Recquantity"], (int)rdr["quantity"]);
                }
            };
            rdr.Close();
            cmd.Dispose();
            con.Close();


            return discountChecker.PercentagesIngriedents();
        }


    }
}
