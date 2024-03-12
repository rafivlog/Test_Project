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

        public static int Create(AttendanceModel employee)
        {
            string response = string.Empty;
            string query = "Insert into HRM_Attendance(desig_id,starttime,endtime,is_active,status,remarks) " +
                "values (@desig_id,@starttime,@endtime,@is_active,@status,@remarks)";
            using (IDbConnection con = new SqlConnection(LoadConnectionString()))
            {
                return con.Execute(query, new
                {

                    employee.desig_id,
                    employee.starttime,
                    employee.endtime,
                    employee.is_active,
                    employee.status,
                    employee.remarks
                });
            }


        }

       
    }
}
