using Dapper;
using Infiniatask.Areas.Stock.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using static Infiniatask.Areas.Stock.Controllers.ReturnitemController;

namespace Infiniatask.Areas.Stock.Repository
{
    public class RetrunitemRepository : dbcontext
    {
        public static string LoadConnectionString()
        {
            return Getconnection();
        }

        public static int Create(ReturnitemModel item)
        {
            string response = string.Empty;
            string query = "Insert into STK_Returnitem(id,cat_id,stk_id,qty,returning_date,remarks) " +
                "values (@id,@cat_id,@stk_id,@qty,@returning_date,@remarks)";
            /*string query = "BEGIN TRANSACTION;DECLARE @qty_stock INT, @qty_distributed INT;SELECT @qty_stock = qty FROM STK_Stock WHERE stk_id = @stk_id;SELECT @qty_distributed = qty FROM STK_Distributed WHERE stk_id = @stk_id;INSERT INTO STK_Returnitem (id, cat_id, stk_id, qty, returning_date, remarks)VALUES (@id, @cat_id, @stk_id, @qty, @returning_date, @remarks); " +
                "UPDATE STK_Stock SET qty = ((SELECT COALESCE(qty, 0) FROM STK_Stock WHERE stk_id = @stk_id) -  (SELECT COALESCE(SUM(qty), 0) FROM STK_Distributed WHERE stk_id = @stk_id)) WHERE stk_id = @stk_id;COMMIT;";*/
            using (IDbConnection con = new SqlConnection(LoadConnectionString()))
            {
                return con.Execute(query, new
                {
                    item.id,
                    item.cat_id,
                    item.stk_id,
                    item.qty,
                    item.returning_date,
                    item.remarks,
                });
            }

        }

        public static int GetQuantity(int aidi, int cataidi, int stockaidi)
        {
            string query = "SELECT qty FROM STK_Distributed WHERE id = @aidi AND cat_id = @cataidi AND stk_id = @stockaidi";

            using (IDbConnection con = new SqlConnection(LoadConnectionString()))
            {
                // Execute the query and retrieve the result using Dapper's QueryFirstOrDefault method
                int? data = con.QueryFirstOrDefault<int?>(query, new { aidi, cataidi, stockaidi });

                // If data is not null, return its value, otherwise, return 0
                return data ?? 0;
            }
        }


    }
}
