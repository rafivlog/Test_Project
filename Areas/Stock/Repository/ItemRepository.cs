using Dapper;
using Infiniatask.Areas.Hrm.Models;
using Infiniatask.Areas.Stock.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Infiniatask.Areas.Stock.Repository
{
    public class ItemRepository : dbcontext
    {
        public static string LoadConnectionString()
        {
            return Getconnection();
        }

        public static int Create(ItemModel item)
        {
            string response = string.Empty;
            string query = "Insert into STK_Stock(cat_id,item_name,item_price,qty,item_location) " +
                "values (@cat_id,@item_name,@item_price,@qty,@item_location)";
            using (IDbConnection con = new SqlConnection(LoadConnectionString()))
            {
                return con.Execute(query, new
                {
                    item.cat_id,
                    item.item_name,
                    item.item_price,
                    item.qty,
                    item.item_location,
                });
            }


        }

        public static List<ItemModel> getitemlist()
        {
            string response = string.Empty;
            string query = "Select item_name , item_price , qty , item_location from STK_Stock";
            using IDbConnection con = new SqlConnection(LoadConnectionString());
            return con.Query<ItemModel>(query, new DynamicParameters()).ToList();



        }

    }
}
