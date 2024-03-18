using Dapper;
using Infiniatask.Areas.Hrm.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Infiniatask.Areas.Hrm.Repository
{
    public class LeaveentryRepository : dbcontext
    {
        public static string LoadConnectionString()
        {
            return Getconnection();
        }

        public static int Create(LeaveentryModel employee)
        {
            string response = string.Empty;
            string query = "Insert into HRM_LeaveEntry(empname,leavetype,leavefrom,leaveto,totaldays,remarks) " +
                "values (@empname,@leavetype,@leavefrom,@leaveto,@totaldays,@remarks)";
            using (IDbConnection con = new SqlConnection(LoadConnectionString()))
            {
                return con.Execute(query, new
                {

                    employee.empname,
                    employee.leavetype,
                    employee.leavefrom,
                    employee.leaveto,
                    employee.totaldays,
                    employee.remarks,
                    
                     
                });
            }


        }
    }
}
