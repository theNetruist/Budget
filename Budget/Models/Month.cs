﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget.Models
{
    public class Month
    {
        public Month(DateTime date)
        {
            _date = date;
        }

        public Month(DateTime date, List<LineItem> items)
        {
            _date = date;
            Days = new List<Day>();
            for (var i = 1; i <= NumberOfDays; i++)
            {
                var thisDay = new DateTime(date.Year, date.Month, i);
                var thisDaysItems = items.Where(x => x.Date.Date == thisDay.Date).ToList();
                Days.Add(new Day(thisDay, thisDaysItems));
            }
        }
        private DateTime _date;
        public List<Day> Days { get; set; }
        public DateTime Date { get { return _date; } }
        public string Name
        {
            get
            {
                return NameMap.GetValueOrDefault(_date.Month);
            }
        }
        public int MonthNumber
        {
            get
            {
                return _date.Month;
            }
        }
        public int NumberOfDays
        {
            get
            {
                return DateTime.DaysInMonth(_date.Year, _date.Month);
            }
        }
        public double TotalValue
        {
            get
            {
                var total = 0.0;
                foreach (var day in Days)
                {
                    foreach (LineItem item in day.LineItems)
                    {
                        total += item.Amount;
                    }
                }
                return total;
            }
        }

        private static Dictionary<int, string> NameMap = new Dictionary<int, string>
        {
            { 1, "January" },
            { 2, "February" },
            { 3, "March" },
            { 4, "April" },
            { 5, "May" },
            { 6, "June" },
            { 7, "July" },
            { 8, "August" },
            { 9, "September" },
            { 10, "October" },
            { 11, "November" },
            { 12, "December" },
        };
    }
}
