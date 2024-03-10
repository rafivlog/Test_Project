using Infiniatask.Areas.Hrm.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;
namespace Infiniatask.Areas.Hrm.Repository
{
    public class EmployeeRepository : dbcontext
    {
        public static string LoadConnectionString()
        {
            return Getconnection();
        }

        //ekhane data save kortci db te 
        public static int Create(EmployeeModel employee)
        {
            string response = string.Empty;
            string query = "Insert into HRM_Employees(empname,dtjoin,dtbirth,dept_id,desig_id,salary,emp_status,address,email,password) " +
                "values (@empname,@dtjoin,@dtbirth,@dept_id,@desig_id,@salary,@emp_status,@address,@email,@password )";
            using (IDbConnection con = new SqlConnection(LoadConnectionString()))
            {
                return con.Execute(query, new
                {
                     
                    employee.empname,
                    employee.dtjoin,
                    employee.dtbirth,
                    employee.dept_id,
                    employee.desig_id,
                    employee.salary,
                    employee.emp_status,
                    employee.address,
                    employee.email,
                    employee.password
                });
            }


        }


        //ekhane load use kore save kora data sthe sthe dekhayci 
        public static List<EmployeeModel> getemployee()
        {
            string response = string.Empty;
            string query = "Select empname,dtbirth,dept_id,desig_id,salary,emp_status,address,email from HRM_Employees";
            using IDbConnection con = new SqlConnection(LoadConnectionString());
            return con.Query<EmployeeModel>(query, new DynamicParameters()).ToList();
            

        }


    }
}
