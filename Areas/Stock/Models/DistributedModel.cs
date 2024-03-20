using System.Reflection.Metadata;

namespace Infiniatask.Areas.Stock.Models
{
    public class DistributedModel
    {
        public int qty {  get; set; }

        public DateTime distributed_date { get; set; }

        public string remarks {  get; set; }
    }
}
