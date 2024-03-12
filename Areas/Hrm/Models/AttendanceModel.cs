namespace Infiniatask.Areas.Hrm.Models
{
    public class AttendanceModel
    {
        public string name { get; set; }
        public int desig_id { get; set; }
        public DateTime starttime { get; set; }
        public DateTime endtime { get; set; }
        public bool is_active { get; set; }
        public string status { get; set; }
        public string remarks { get; set; }
    }
}
