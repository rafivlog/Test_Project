namespace Infiniatask.Areas.Hrm.Repository
{
    public class dbcontext
    {
        public static readonly string dbconnection = @"Data Source=RAFI\MSSQLSERVER01;Initial Catalog=IGBMS;Integrated Security=True;TrustServerCertificate=True";
        public static string Getconnection()
        {
            return dbconnection;
        }
    }
}
