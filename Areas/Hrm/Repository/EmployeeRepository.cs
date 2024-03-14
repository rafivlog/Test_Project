using Infiniatask.Areas.Hrm.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;
using static Infiniatask.Areas.Controllers.EmployeeController;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
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


        //Attendance er jnne dropdown er jnne collect kortci .

        public static IEnumerable<DropDownModel> GetDropDownData()
        {
            string query = "SELECT id as id , CONCAT(desig_id , ' | ',empname  ) as dd_value FROM HRM_Employees";

            using (IDbConnection connection  = new SqlConnection(LoadConnectionString()))
            {
                return connection .Query<DropDownModel>(query,new DynamicParameters()).ToList();
            }
        }


        //deleted work
        public static int delete(int id)
        {
            string query = "DELETE  FROM HRM_Employees WHERE desig_id = @id";
            using (IDbConnection con = new SqlConnection(LoadConnectionString()))
            {
                return con.Execute(query, new
                {
                   id 
                });
            }


        }

       

        //updated work

        public static int Update(EmployeeModel employee)
        {
            string response = string.Empty;
            string query = "Update  HRM_Employees SET  empname=@empname,dtjoin=@dtjoin,dtbirth=@dtbirth,dept_id=@dept_id,desig_id=@desig_id,salary=@salary,emp_status=@emp_status,address=@address,email=@email,password=@password WHERE id=@id";


            using (IDbConnection con = new SqlConnection(LoadConnectionString()))
            {
                return con.Execute(query, new
                {
                    employee.id,
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

        //Auto data show on edit page 
        public static EmployeeModel geteditdata(int desig_id)
        {
            string query = @"SELECT * FROM HRM_Employees WHERE desig_id = " + desig_id;
            using IDbConnection con = new SqlConnection(LoadConnectionString());
            return con.Query <EmployeeModel>(query, new DynamicParameters()).FirstOrDefault();
        }


    }
}
