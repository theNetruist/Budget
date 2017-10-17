using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget.Models
{
    public class MonthlyRepeatingLineItemList : List<MonthlyRepeatingLineItem>
    {
        public List<LineItem> ToLineItems(int month, int year)
        {
            List<LineItem> items = new List<LineItem>();
            foreach (var r in this)
            {
                items.Add(r.ToLineItem(month, year));
            }
            return items;
        }
    }
}
