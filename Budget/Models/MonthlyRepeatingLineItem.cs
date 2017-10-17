using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget.Models
{
    public class MonthlyRepeatingLineItem : AbstractLineItem
    {
        public long RID { get; set; }

        public int DayOfMonth { get; set; }
        
        public new long Id
        {
            get
            {
                return RID;
            }
        }

        public new bool Expected => true;

        public LineItem ToLineItem(int month, int year)
        {
            int daysInMonth = DateTime.DaysInMonth(year, month);
            DateTime _date = new DateTime(year, month, (DayOfMonth > daysInMonth) ? daysInMonth : DayOfMonth);
            return new LineItem
            {
                Amount = Amount,
                Description = Description,
                Expected = Expected,
                Name = Name,
                Notes = Notes,
                Date = _date
            };
        }
    }
}
