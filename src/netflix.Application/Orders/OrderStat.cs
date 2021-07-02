using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.Orders
{
    public class OrderStat
    {
        public List<OrderAndProf> OrderAndProfs { get; set; }
    }
    public class OrderAndProf
    {
        public DateTime Date { get; set; }
        public int Prof { get; set; }
    }
}
