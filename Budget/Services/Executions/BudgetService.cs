using Budget.Models;
using Budget.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget.Services.Executions
{
    public class BudgetService : IBudgetService
    {
        public async Task<Day> GetDayAsync(DateTime date)
        {
            var items = MockBudgetData.LineItems;
            var day = new Day(date)
            {
                LineItems = items.Where(x => x.Date.Value.Date == date.Date).ToList()
            };
            return day;
        }

        public async Task<Month> GetMonthAsync(DateTime date)
        {
            var items = MockBudgetData.LineItems.Where(x => x.Date.Value.Month == date.Month).ToList();
            var month = new Month(date, items);
            return month;
        }
        

        public static class MockBudgetData
        {
            public static List<LineItem> LineItems;

            static MockBudgetData()
            {
                BuildLineItems();
            }

            private static void BuildLineItems()
            {

                LineItems = new List<LineItem>();

                var random = new Random();
                for (var i = 1; i <= 12; i++)
                {
                    for (var j = 0; j < 25; j++)
                    {
                        try
                        {
                            var y = DateTime.Now.Year;
                            var m = i;
                            var d = 1 + (int)Math.Round((random.NextDouble() * 27), 0);
                            var dt = new DateTime(y, m, d);
                            LineItems.Add(new LineItem
                            {
                                Date = dt,
                                Description = $"Description for Line Item {j * i}.",
                                Name = $"Line Item {j * i}",
                                Notes = $"Notes for Line Item {j * i}.",
                                Amount = random.NextDouble() * 100
                            });
                        }
                        catch { }
                    }
                }
            }
        }
    }
}
