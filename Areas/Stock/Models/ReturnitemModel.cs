namespace Infiniatask.Areas.Stock.Models
{
    public class ReturnitemModel
    {
        public int id { get; set; }

        public int cat_id { get; set; }

        public int stk_id { get; set; }

        public int qty { get; set; }

        public DateTime returning_date { get; set; }

        public string remarks { get; set; }

        public string empname { get; set; }

        public string catname { get; set; }


        public string item_name { get; set; }
    }
}
