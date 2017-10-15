using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget.Models
{
    public class Day
    {
        private DateTime _date;
        public Day(DateTime date)
        {
            _date = date;
        }
        public Day(DateTime date, List<LineItem> items)
        {
            _date = date;
            LineItems = items;
        }
        public DateTime Date{ get { return _date; } }
        public List<LineItem> LineItems { get; set; }
        public double TotalValue
        {
            get
            {
                var total = 0.0;
                foreach (LineItem item in LineItems)
                {
                    total += item.Amount;
                }
                return total;
            }
        }
    }
}
