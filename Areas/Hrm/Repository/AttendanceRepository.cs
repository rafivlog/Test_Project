using Dapper;
using Infiniatask.Areas.Hrm.Models;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Data;
using System.Data.Common;

namespace Infiniatask.Areas.Hrm.Repository
{
    public class AttendanceRepository : dbcontext
    {
        public static string LoadConnectionString()
        {
            return Getconnection();
        }



       /* public async Task<IEnumerable<EmployeeModel>> GetAllEmployeesAsync()
        {
            using (IDbConnection dbConnection = dbcontext)
            {
                dbConnection.Open();
                return await dbConnection.QueryAsync<EmployeeModel>("SELECT * FROM Employees");
            }
        }*/
    }
}
