﻿using Dapper;
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
    }
}
