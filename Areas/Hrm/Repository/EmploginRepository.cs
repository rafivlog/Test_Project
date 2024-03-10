using Infiniatask.Areas.Hrm.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
namespace Infiniatask.Areas.Hrm.Repository
{
    public class EmploginRepository : dbcontext
    {
        public static string LoadConnectionString()
        {
            return Getconnection();
        }

        public static int match(EmploginModel employee)
        {
            using (IDbConnection con = new SqlConnection(LoadConnectionString()))
            {
                var data = con.QueryFirstOrDefault<EmploginModel>(
                    "SELECT id FROM HRM_Employees WHERE email = @email AND password = @password",
                    new { email = employee.email, password = employee.password });
                if(data == null)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }

        }
    }
}
