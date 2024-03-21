using Dapper;
using Infiniatask.Areas.Hrm.Models;
using Infiniatask.Areas.Stock.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Infiniatask.Areas.Stock.Repository
{
    public class DistributedRepository : dbcontext
    {
        public static string LoadConnectionString()
        {
            return Getconnection();
        }

        public static IEnumerable<itemdropdownModel> GetDropDownData(int cat_id)
        {
            string query = "SELECT stk_id as id, CONCAT(item_name, ' | ', qty) as dd_value FROM STK_Stock WHERE cat_id = @cat_id";

            using IDbConnection con = new SqlConnection(LoadConnectionString());

            return con.Query<itemdropdownModel>(query, new { cat_id });
        }
        
        public static int Create(DistributedModel item)
        {
            string response = string.Empty;
            string query = "Insert into STK_Distributed(id,cat_id,stk_id,qty,distributed_date,remarks) " +
                "values (@id,@cat_id,@stk_id,@qty,@distributed_date,@remarks)";
            using (IDbConnection con = new SqlConnection(LoadConnectionString()))
            {
                return con.Execute(query, new
                {
                    item.id,
                    item.cat_id,
                    item.stk_id,
                    item.qty,
                    item.distributed_date,
                    item.remarks,
                });
            }

        }

        public static List<DistributedModel> getdistributed()
        {
            string response = string.Empty;
            string query = "SELECT  (SELECT empname FROM HRM_Employees WHERE id = STK_Distributed.id) AS empname, (SELECT catname FROM STK_Category WHERE cat_id = STK_Distributed.cat_id) AS catname, (SELECT item_name FROM STK_Stock WHERE stk_id = STK_Distributed.stk_id) AS item_name, qty, distributed_date FROM   STK_Distributed;";
            using IDbConnection con = new SqlConnection(LoadConnectionString());
            return con.Query<DistributedModel>(query, new DynamicParameters()).ToList();


        }

       
    }
}
