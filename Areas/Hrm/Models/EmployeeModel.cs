namespace Infiniatask.Areas.Hrm.Models
{
    public class EmployeeModel
    {
        /// <summary>
        /// public int id { get; set; }
        /// </summary>
        public string empname { get; set; }
        public DateTime dtjoin { get; set; }
        public DateTime dtbirth { get; set; }
        public int dept_id { get; set; }
        public int desig_id { get; set; }
        public int salary { get; set; }
        public bool emp_status { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public int id { get; set; }
    }
}

