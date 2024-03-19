using System.Reflection.Metadata;

namespace Infiniatask.Areas.Stock.Models
{
    public class ItemModel
    {
        public int qty { get; set; }
        public int item_price { get; set; }
        public string  item_name { get; set; }
        public string item_location { get; set; }
    }
}
