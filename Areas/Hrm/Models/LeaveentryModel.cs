namespace Infiniatask.Areas.Hrm.Models
{
    public class LeaveentryModel
    {
        public string empname { get; set; }
        public string leavetype { get; set; }
        public DateTime leavefrom { get; set; }
        public DateTime leaveto { get; set; }
        public int totaldays { get; set; }
        public string remarks { get; set; }
       
    }
}
