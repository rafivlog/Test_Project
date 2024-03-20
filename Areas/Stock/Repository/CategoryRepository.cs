using Dapper;
using Infiniatask.Areas.Hrm.Models;
using Infiniatask.Areas.Stock.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Infiniatask.Areas.Stock.Repository
{
    public class CategoryRepository : dbcontext
    {
        public static string LoadConnectionString()
        {
            return Getconnection();
        }

        public static int Create(CategoryModel categryname)
        {
            var datetime = DateTime.Now;
            string response = string.Empty;
            string query = "INSERT INTO STK_Category (catname,stk_id,InsertAT) VALUES (@catname,@stk_id,@InsertAT)";
            using (IDbConnection con = new SqlConnection(LoadConnectionString()))
            {
                return con.Execute(query, new
                {

                    categryname.catname,
                    categryname.stk_id,
                    InsertAT=datetime,
                   
                });
            }


        }


        public static List<CategoryModel> getcategory()
        {
            string response = string.Empty;
            string query = "Select catname,InsertAt from STK_Category";
            using IDbConnection con = new SqlConnection(LoadConnectionString());
            return con.Query<CategoryModel>(query, new DynamicParameters()).ToList();



        }


        public static IEnumerable<dropdownModel> GetDropDownData()
        {
            string query = "SELECT  cat_id as id, catname as dd_value FROM STK_Category";

            using (IDbConnection connection = new SqlConnection(LoadConnectionString()))
            {
                return connection.Query<dropdownModel>(query, new DynamicParameters()).ToList();
            }
        }

    }
}
